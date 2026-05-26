using System;
using System.IO.Ports;
using System.Threading;

// C# port of Basic.dll — RRU9809 RFID reader SDK
// Protocol: CRC-16/MCRF4XX (poly=0x8408, init=0xFFFF, residue=0x0000)
// Packet layout: [LEN, ADDR, CMD, DATA..., CRC_LO, CRC_HI]
//   LEN = total_bytes - 1 (covers addr + cmd + data + 2 crc bytes)
// Response: [LEN, ADDR_ECHO, CMD_ECHO, ERR_CODE, DATA..., CRC_LO, CRC_HI]
//   ERR_CODE = 0 on success

namespace ReaderB
{
    public static class StaticClassReaderB
    {
        // ── error codes ──────────────────────────────────────────────────────────
        private const int ERR_OK      = 0;
        private const int ERR_COMM    = 48;   // 0x30 comm / timeout
        private const int ERR_CRC     = 49;   // 0x31 CRC mismatch
        private const int ERR_BUSY    = 53;   // 0x35 port already open
        private const int ERR_INVALID = 55;   // 0x37 port not open / invalid
        private const int ERR_CMD     = 238;  // 0xEE command echo mismatch
        private const byte ERR_ANTICOLL = 0xFC; // anti-collision error — next byte holds tag count

        // ── global state (mirrors the original DLL's static data segment) ────────
        private static readonly object _lock = new object();

        // 50 slots; index 0 unused, valid ports are 1-49
        private static readonly SerialPort?[] _ports   = new SerialPort[51];
        private static readonly bool[]        _portOpen = new bool[51];

        // scan-time multiplier set by GetReaderInformation / OpenComPort
        private static bool _useScanTimeMult = false;
        private static byte _scanTimeMult    = 0;   // answered-time field from reader

        // shared receive buffer (0x1388 = 5000 bytes in the original)
        private static readonly byte[] _rxBuf = new byte[5000];
        private static int _rxLen = 0;

        // ── baud-rate table ───────────────────────────────────────────────────────
        private static readonly int[] BaudRates =
        {
            9600, 19200, 38400, 0 /*invalid*/, 56000, 57600, 115200
        };

        // ═════════════════════════════════════════════════════════════════════════
        // CRC  (CRC-16/MCRF4XX — poly 0x8408, init 0xFFFF, refIn=refOut=true)
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Compute CRC-16/MCRF4XX over <paramref name="length"/> bytes of
        /// <paramref name="buf"/>. Writes the two CRC bytes into
        /// buf[length] and buf[length+1] (matching the original GetCRC export).
        /// </summary>
        public static void GetCRC(byte[] buf, int length)
        {
            ushort crc = ComputeCrc(buf, length);
            buf[length]     = (byte)(crc & 0xFF);
            buf[length + 1] = (byte)(crc >> 8);
        }

        /// <summary>
        /// Verify the CRC stored at buf[length] / buf[length+1] against
        /// recomputed CRC over buf[0..length-1].
        /// Returns 0 on success, ERR_CRC on failure.
        /// </summary>
        public static long CheckCRC(byte[] buf, int length)
        {
            ushort computed = ComputeCrc(buf, length);
            ushort received = (ushort)(buf[length] | (buf[length + 1] << 8));
            return computed == received ? ERR_OK : ERR_CRC;
        }

        private static ushort ComputeCrc(byte[] buf, int length)
        {
            uint crc = 0xFFFF;
            for (int i = 0; i < length; i++)
            {
                crc ^= buf[i];
                for (int b = 0; b < 8; b++)
                {
                    if ((crc & 1) != 0)
                        crc = (crc >> 1) ^ 0x8408u;
                    else
                        crc >>= 1;
                }
            }
            return (ushort)crc;
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Port management
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>Returns 42 (version / identity marker).</summary>
        public static long fnRRU9809() => 42;

        /// <summary>
        /// Open COM<paramref name="portNum"/> at the baud rate encoded by
        /// <paramref name="baudCode"/> (0=9600 … 6=115200).
        /// </summary>
        public static long OpenCom(int portNum, byte baudCode)
        {
            if (portNum < 1 || portNum > 50) return ERR_INVALID;
            long r = OpenComCore(portNum, baudCode);
            return r;
        }

        // Opens the physical serial port without acquiring _lock; caller must hold _lock.
        private static long OpenComCore(int portNum, byte baudCode)
        {
            if (baudCode == 3 || baudCode >= BaudRates.Length) return ERR_COMM;

            int baud = BaudRates[baudCode];
            var sp = new SerialPort($"COM{portNum}", baud, Parity.None, 8, StopBits.One)
            {
                ReadTimeout  = 1000,
                WriteTimeout = 500,
                DtrEnable    = false,
                RtsEnable    = false
            };

            try { sp.Open(); }
            catch { return ERR_COMM; }

            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();

            _ports[portNum]?.Close();
            _ports[portNum] = sp;
            return ERR_OK;
        }

        /// <summary>Close all open COM ports.</summary>
        public static long CloseComPort()
        {
            lock (_lock)
            {
                for (int i = 1; i <= 50; i++)
                {
                    if (_ports[i] != null && _ports[i]!.IsOpen)
                    {
                        _ports[i]!.Close();
                        _ports[i] = null;
                        _portOpen[i] = false;
                    }
                }
            }
            return ERR_OK;
        }

        /// <summary>Close the COM port at <paramref name="portNum"/>.</summary>
        public static long CloseSpecComPort(int portNum)
        {
            lock (_lock)
            {
                if (portNum < 1 || portNum > 50) return ERR_INVALID;
                if (_ports[portNum] == null || !_ports[portNum]!.IsOpen)
                    return ERR_OK;
                try
                {
                    _ports[portNum]!.Close();
                    _ports[portNum] = null;
                    _portOpen[portNum] = false;
                    return ERR_OK;
                }
                catch { return ERR_COMM; }
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Low-level send / receive
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Write <paramref name="count"/> bytes from <paramref name="data"/> to the
        /// specified port, purging buffers first.
        /// </summary>
        public static long SendDataToPort(byte[] data, uint count, int portNum)
        {
            if (portNum < 1 || portNum > 50) return ERR_INVALID;
            var sp = _ports[portNum];
            if (sp == null || !sp.IsOpen) return ERR_INVALID;
            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();
            try
            {
                sp.Write(data, 0, (int)count);
                return ERR_OK;
            }
            catch { return ERR_COMM; }
        }

        /// <summary>
        /// Read a complete response frame into <paramref name="buf"/>.
        /// The frame is complete when buf[0]+1 bytes have been received and
        /// buf[0] > 3. Sets <paramref name="count"/> to the number of bytes read.
        /// Returns ERR_OK on success or ERR_COMM on timeout.
        /// </summary>
        public static long GetDataFromPort(byte[] buf, ref int count, int portNum)
        {
            if (portNum < 1 || portNum > 50) return ERR_INVALID;
            var sp = _ports[portNum];
            if (sp == null || !sp.IsOpen) return ERR_INVALID;

            int timeoutMs = _useScanTimeMult ? (100 * _scanTimeMult) : 1000;
            count = 0;
            Array.Clear(buf, 0, buf.Length);

            long start = Environment.TickCount64;

            while (true)
            {
                try
                {
                    int avail = sp.BytesToRead;
                    if (avail > 0)
                    {
                        byte[] tmp = new byte[Math.Min(avail, 100)];
                        int n = sp.Read(tmp, 0, tmp.Length);
                        if (n > 0)
                        {
                            int canCopy = Math.Min(n, buf.Length - count);
                            if (canCopy > 0) { Array.Copy(tmp, 0, buf, count, canCopy); count += canCopy; }
                        }
                    }
                }
                catch { /* port error handled by timeout */ }

                if (count > 0)
                {
                    int lenByte = buf[0];
                    if (lenByte + 1 == count && (byte)lenByte > 3)
                        return ERR_OK;
                }

                long elapsed = Environment.TickCount64 - start;
                if ((elapsed > 500 && count == 0) || elapsed > timeoutMs)
                    return ERR_COMM;

                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Read multiple consecutive response frames (used by inventory commands).
        /// Raw bytes accumulate directly into buf; a local parse pointer advances through
        /// completed frames to detect the terminal frame (type 0xFB or 1-2), matching
        /// the original DLL's design where byte_18007C1B0 is the accumulation target.
        /// </summary>
        public static long GetQueryDataFromPort(byte[] buf, ref int count, int portNum)
        {
            if (portNum < 1 || portNum > 50) return ERR_INVALID;
            var sp = _ports[portNum];
            if (sp == null || !sp.IsOpen) return ERR_INVALID;

            int timeoutMs = _useScanTimeMult ? (100 * _scanTimeMult) : 1000;
            count = 0;
            Array.Clear(buf, 0, buf.Length);

            int parsedUpTo = 0;
            long start = Environment.TickCount64;

            while (true)
            {
                try
                {
                    int avail = sp.BytesToRead;
                    if (avail > 0)
                    {
                        byte[] tmp = new byte[Math.Min(avail, 100)];
                        int n = sp.Read(tmp, 0, tmp.Length);
                        if (n > 0)
                        {
                            int canCopy = Math.Min(n, buf.Length - count);
                            if (canCopy > 0) { Array.Copy(tmp, 0, buf, count, canCopy); count += canCopy; }
                        }
                    }
                }
                catch { }

                // advance the parse cursor through any newly completed frames
                while (parsedUpTo < count)
                {
                    if (count - parsedUpTo < 4) break;
                    int frameLen = (buf[parsedUpTo] & 0xFF) + 1;
                    if (count - parsedUpTo < frameLen) break;

                    byte frameType = buf[parsedUpTo + 3];
                    bool isTerminal = (frameType == 0xFB || (byte)(frameType - 1) <= 1);
                    parsedUpTo += frameLen;

                    if (isTerminal)
                        return ERR_OK;
                }

                long elapsed = Environment.TickCount64 - start;
                // original GetQueryDataFromPort uses 0x3E8 (1000ms) for count==0 early exit
                if ((elapsed > 1000 && count == 0) || elapsed > timeoutMs)
                    return ERR_COMM;

                Thread.Sleep(1);
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Helpers for building and sending commands
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Build a packet into <paramref name="pkt"/> and return the total byte count.
        /// packet layout: [len, addr, cmd, data..., crc_lo, crc_hi]
        ///   len = total - 1
        ///   CRC covers bytes [0 .. total-3]
        /// </summary>
        private static int BuildPacket(byte[] pkt, byte addr, byte cmd,
                                       byte[]? data = null, int dataOffset = 0, int dataLen = 0)
        {
            int total = 5 + dataLen; // 1(len) + 1(addr) + 1(cmd) + dataLen + 2(crc)
            pkt[0] = (byte)(total - 1);
            pkt[1] = addr;
            pkt[2] = cmd;
            if (data != null && dataLen > 0)
                Array.Copy(data, dataOffset, pkt, 3, dataLen);
            ushort crc = ComputeCrc(pkt, total - 2);
            pkt[total - 2] = (byte)(crc & 0xFF);
            pkt[total - 1] = (byte)(crc >> 8);
            return total;
        }

        /// <summary>
        /// Purge, send packet, receive response into _rxBuf/_rxLen.
        /// Must be called inside lock(_lock).
        /// Returns ERR_COMM on timeout, ERR_CRC on bad checksum, else ERR_OK.
        /// </summary>
        private static long SendReceive(byte[] pkt, int pktLen, int portNum,
                                        bool useQueryReceive = false, int sleepBeforeReceiveMs = 0)
        {
            var sp = _ports[portNum];
            if (sp == null || !sp.IsOpen) return ERR_INVALID;

            sp.DiscardInBuffer();
            sp.DiscardOutBuffer();

            try { sp.Write(pkt, 0, pktLen); }
            catch { return ERR_COMM; }

            if (sleepBeforeReceiveMs > 0)
                Thread.Sleep(sleepBeforeReceiveMs);

            Array.Clear(_rxBuf, 0, _rxBuf.Length);
            _rxLen = 0;

            long result;
            if (useQueryReceive)
                result = GetQueryDataFromPort(_rxBuf, ref _rxLen, portNum);
            else
                result = GetDataFromPort(_rxBuf, ref _rxLen, portNum);

            if (result != ERR_OK) return result;

            // verify CRC: compute over [0.._rxLen-3], compare to [_rxLen-2.._rxLen-1]
            if (_rxLen < 3) return ERR_CRC;
            ushort computedCrc = ComputeCrc(_rxBuf, _rxLen - 2);
            ushort receivedCrc = (ushort)(_rxBuf[_rxLen - 2] | (_rxBuf[_rxLen - 1] << 8));
            if (computedCrc != receivedCrc) return ERR_CRC;

            return ERR_OK;
        }

        /// <summary>
        /// Send a simple command (no extra data beyond addr/cmd), receive response.
        /// Returns ERR_OK on link success; caller still checks _rxBuf[3] for reader error.
        /// </summary>
        private static long SimpleCommand(byte addr, byte cmd, int portNum)
        {
            byte[] pkt = new byte[8];
            int n = BuildPacket(pkt, addr, cmd);
            return SendReceive(pkt, n, portNum);
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Reader configuration commands
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Query reader info. On success fills address, firmware version, reader type,
        /// transport type, scan time, RF power, beep enable, and antenna config.
        /// Port number is passed as the last parameter (matching original signature).
        /// </summary>
        public static long GetReaderInformation(
            ref byte  addr,
            ref ushort fwVersion,
            ref byte   readerType,
            ref ushort trType,
            ref byte   inventScanTime,
            ref byte   rfPower,
            ref byte   beepEnable,
            ref byte   antennaConf,
            int portNum)
        {
            lock (_lock)
            {
                byte[] pkt = new byte[8];
                int n = BuildPacket(pkt, addr, 0x21); // cmd 0x21 = GetReaderInformation
                long r = SendReceive(pkt, n, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[2] != 0x21) return ERR_CMD;
                if (_rxBuf[3] != 0)    return (byte)_rxBuf[3];

                addr          = _rxBuf[1];
                fwVersion     = (ushort)(_rxBuf[4] | (_rxBuf[5] << 8));
                readerType    = _rxBuf[6];
                trType        = (ushort)(_rxBuf[7] | (_rxBuf[8] << 8));
                inventScanTime = _rxBuf[8];   // overlaps trType hi-byte, matches original
                rfPower       = _rxBuf[9];
                beepEnable    = _rxBuf[10];
                antennaConf   = _rxBuf[11];

                // store raw antennaConf byte; timeout = 100 * _scanTimeMult ms, flag set in Inventory_G2
                _scanTimeMult = antennaConf;

                return ERR_OK;
            }
        }

        /// <summary>
        /// Open and initialise a COM port, communicating with the reader to confirm
        /// it responds and retrieve its address.
        /// Returns 0 on success; portHandle receives the port number on success or -1 on failure.
        /// </summary>
        public static long OpenComPort(int portNum, ref byte addr, byte baudCode, ref uint portHandle)
        {
            lock (_lock)
            {
                if (portNum < 1 || portNum > 50) { portHandle = uint.MaxValue; return ERR_COMM; }
                if (_portOpen[portNum]) { portHandle = (uint)portNum; return ERR_BUSY; }

                // open the physical port (up to 5 tries)
                int openTries = 0;
                while (OpenComCore(portNum, baudCode) != ERR_OK)
                {
                    if (++openTries >= 5) { portHandle = uint.MaxValue; return ERR_COMM; }
                }

                // handshake: confirm reader responds with valid GetReaderInformation reply
                for (int attempt = 0; attempt < 2; attempt++)
                {
                    ushort fwVersion = 0; ushort trType = 0;
                    byte readerType = 0, inventScanTime = 0, rfPower = 0, beepEnable = 0, antennaConf = 0;
                    byte a = addr;
                    // GetReaderInformation re-acquires _lock; safe because Monitor is reentrant
                    long r = GetReaderInformation(ref a, ref fwVersion, ref readerType, ref trType,
                                                  ref inventScanTime, ref rfPower, ref beepEnable,
                                                  ref antennaConf, portNum);
                    if (r == ERR_OK)
                    {
                        addr = a;
                        _portOpen[portNum] = true;
                        portHandle = (uint)portNum;
                        return ERR_OK;
                    }
                }

                _ports[portNum]?.Close();
                _ports[portNum] = null;
                portHandle = uint.MaxValue;
                return ERR_COMM;
            }
        }

        /// <summary>
        /// Automatically scan COM1-COM50 looking for a reader. Sets portNum and portHandle
        /// to the found port, or -1 if none found.
        /// </summary>
        public static long AutoOpenComPort(ref int portNum, ref byte addr, byte baudCode, ref int portHandle)
        {
            lock (_lock)
            {
                for (int p = 1; p <= 50; p++)
                {
                    uint ph = 0;
                    byte a = addr;
                    long r = OpenComPort(p, ref a, baudCode, ref ph);
                    if (r == ERR_OK)
                    {
                        portNum   = p;
                        addr      = a;
                        portHandle = p;
                        return ERR_OK;
                    }
                }
                portNum    = -1;
                portHandle = -1;
                return ERR_COMM;
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Gen 2 inventory
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// ISO 18000-6C (Gen 2) inventory.
        /// maskFlag=0 → simple inventory; maskFlag=1 → filtered by q/session.
        /// On success epcBuf receives concatenated EPC data, totalTags the count of tags found.
        /// </summary>
        public static long Inventory_G2(
            ref byte addr,
            byte     q,
            byte     session,
            byte     maskFlag,
            byte[]   epcBuf,
            ref int  epcLen,
            ref uint totalTags,
            int      portNum)
        {
            lock (_lock)
            {
                var sp = _ports[portNum];
                if (sp == null || !sp.IsOpen) return ERR_INVALID;

                byte[] data = maskFlag == 1 ? new byte[] { q, session } : Array.Empty<byte>();
                byte[] pkt  = new byte[16];
                int pktLen  = BuildPacket(pkt, addr, 0x01, data, 0, data.Length);

                sp.DiscardInBuffer();
                sp.DiscardOutBuffer();
                try { sp.Write(pkt, 0, pktLen); } catch { return ERR_COMM; }

                Array.Clear(_rxBuf, 0, _rxBuf.Length);
                _rxLen = 0;
                long r;
                _useScanTimeMult = true;
                try   { r = GetQueryDataFromPort(_rxBuf, ref _rxLen, portNum); }
                finally { _useScanTimeMult = false; }

                if (r != ERR_OK) return r;

                // collect all EPC payloads from multi-frame response directly into epcBuf
                int accLen    = 0;
                int remaining = _rxLen;
                int pos       = 0;

                while (remaining > 0 && pos < _rxLen)
                {
                    int frameLenByte = _rxBuf[pos];
                    int frameTotal   = frameLenByte + 1;
                    if (remaining < frameTotal) break;

                    byte errCode = _rxBuf[pos + 3];
                    if ((byte)(errCode - 1) <= 3) // success frame
                    {
                        totalTags = _rxBuf[pos + 4];
                        int epcBytes = frameLenByte - 6; // payload: skip addr,cmd,err,tagCnt + 2 CRC
                        if (epcBytes > 0)
                        {
                            int canCopy = Math.Min(epcBytes, epcBuf.Length - accLen);
                            if (canCopy > 0) { Array.Copy(_rxBuf, pos + 5, epcBuf, accLen, canCopy); accLen += canCopy; }
                        }
                    }
                    pos       += frameTotal;
                    remaining -= frameTotal;
                }

                epcLen = accLen;
                return _rxBuf[3]; // error code from first frame
            }
        }

        // ── read / write helpers shared by G2 card operations ────────────────────

        private static long G2CardResponse(ref byte addr, ref uint errorCode, bool hasData, byte[]? dataOut)
        {
            if (_rxBuf[3] != 0)
            {
                if (_rxBuf[3] == ERR_ANTICOLL)
                    errorCode = _rxBuf[4];
                return (byte)_rxBuf[3];
            }
            addr      = _rxBuf[1];
            errorCode = uint.MaxValue;
            if (hasData && dataOut != null)
            {
                int dataBytes = _rxLen - 6; // total - len - addr - cmd - err - 2crc
                if (dataBytes > 0)
                    Array.Copy(_rxBuf, 4, dataOut, 0, Math.Min(dataBytes, dataOut.Length));
            }
            return ERR_OK;
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Gen 2 read
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Read data from a Gen 2 tag.
        /// epcLen = length of EPC in bytes.
        /// </summary>
        public static long ReadCard_G2(
            ref byte  addr,
            byte[]    epc,
            byte      memBank,
            byte      wordPtr,
            byte      wordCnt,
            ref uint  password,
            byte      rfuA,
            byte      rfuB,
            byte      accessPwdFlag,
            byte[]    dataBuf,
            uint      epcLen,
            ref uint  errorCode,
            int       portNum)
        {
            lock (_lock)
            {
                // packet: [len, addr, 0x02, epcLen/2, epc..., memBank, wordPtr, wordCnt,
                //          password(4), [rfuA, rfuB if accessPwdFlag==1], crc]
                int eL   = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                int dataLen = 1 + eL + 3 + 4 + extra;
                byte[] data = new byte[dataLen];
                data[0] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, 1, eL);
                data[1 + eL] = memBank;
                data[2 + eL] = wordPtr;
                data[3 + eL] = wordCnt;
                WriteUInt32LE(data, 4 + eL, password);
                if (accessPwdFlag == 1) { data[8 + eL] = rfuA; data[9 + eL] = rfuB; }

                byte[] pkt = new byte[dataLen + 8];
                int pktLen = BuildPacket(pkt, addr, 0x02, data, 0, dataLen);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                return G2CardResponse(ref addr, ref errorCode, true, dataBuf);
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Gen 2 write
        // ═════════════════════════════════════════════════════════════════════════

        private static long G2WriteCommand(
            ref byte addr, byte cmd,
            byte[] epc, byte memBank, byte wordPtr, uint epcLen,
            byte[] writeData, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag,
            byte epcDataLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                // epcLen   = write data byte count  (confusingly named in original SDK)
                // epcDataLen = EPC byte count
                int eL   = (int)(byte)epcLen;       // write data bytes
                int wL   = (int)(byte)epcDataLen;   // EPC bytes
                int extra = accessPwdFlag == 1 ? 2 : 0;

                // original packet: [writeWordCnt, epcWordCnt, epc(wL), memBank, wordPtr, writeData(eL), pwd(4), [rfuA,rfuB]]
                byte[] data = new byte[2 + wL + 2 + eL + 4 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);    // write word count
                data[di++] = (byte)(wL >> 1);    // EPC word count
                Array.Copy(epc, 0, data, di, wL); di += wL;   // EPC data
                data[di++] = memBank;
                data[di++] = wordPtr;
                Array.Copy(writeData, 0, data, di, eL); di += eL;  // write data
                WriteUInt32LE(data, di, password); di += 4;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, cmd, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum, sleepBeforeReceiveMs: 100);
                if (r != ERR_OK) return r;

                if (_rxBuf[3] != 0)
                {
                    if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4];
                    else errorCode = uint.MaxValue;
                    return (byte)_rxBuf[3];
                }
                addr      = _rxBuf[1];
                errorCode = uint.MaxValue;
                return ERR_OK;
            }
        }

        public static long WriteCard_G2(
            ref byte addr, byte[] epc, byte memBank, byte wordPtr,
            uint epcLen, byte[] writeData, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag, long reserved,
            byte epcDataLen, ref uint errorCode, int portNum)
            => G2WriteCommand(ref addr, 0x03, epc, memBank, wordPtr, epcLen,
                              writeData, ref password, rfuA, rfuB, accessPwdFlag,
                              epcDataLen, ref errorCode, portNum);

        public static long WriteBlock_G2(
            ref byte addr, byte[] epc, byte memBank, byte wordPtr,
            uint epcLen, byte[] writeData, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag, long reserved,
            byte epcDataLen, ref uint errorCode, int portNum)
            => G2WriteCommand(ref addr, 0x10, epc, memBank, wordPtr, epcLen,
                              writeData, ref password, rfuA, rfuB, accessPwdFlag,
                              epcDataLen, ref errorCode, portNum);

        // ═════════════════════════════════════════════════════════════════════════
        // Gen 2 EAS / protect / lock / destroy / erase / EPC-write
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>Set EAS alarm on a Gen 2 tag.</summary>
        public static long SetEASAlarm_G2(
            ref byte addr, byte[] epc, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag, byte easAlarm,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 4 + 1 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                WriteUInt32LE(data, di, password); di += 4;
                data[di++] = easAlarm;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x0C, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Check EAS alarm status on a Gen 2 tag.</summary>
        public static long CheckEASAlarm_G2(ref byte addr, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                long r = SimpleCommand(addr, 0x0D, portNum);
                if (r != ERR_OK) return r;
                if (_rxBuf[3] != 0) { if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4]; return (byte)_rxBuf[3]; }
                addr      = _rxBuf[1];
                errorCode = uint.MaxValue;
                return ERR_OK;
            }
        }

        /// <summary>Set card protect (lock) on a Gen 2 tag.</summary>
        public static long SetCardProtect_G2(
            ref byte addr, byte[] epc, byte protectCtrl1, byte protectCtrl2,
            ref uint password, byte rfuA, byte rfuB, byte accessPwdFlag,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 2 + 4 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                data[di++] = protectCtrl1;
                data[di++] = protectCtrl2;
                WriteUInt32LE(data, di, password); di += 4;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x06, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Erase a memory bank on a Gen 2 tag.</summary>
        public static long EraseCard_G2(
            ref byte addr, byte[] epc, byte memBank, byte wordPtr, byte wordCnt,
            ref uint password, byte rfuA, byte rfuB, byte accessPwdFlag,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 3 + 4 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                data[di++] = memBank;
                data[di++] = wordPtr;
                data[di++] = wordCnt;
                WriteUInt32LE(data, di, password); di += 4;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x07, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Write EPC to a Gen 2 tag.</summary>
        public static long WriteEPC_G2(
            ref byte addr, ref uint pwd, byte[] newEpc,
            byte newEpcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[1 + 4 + newEpcLen];
                data[0] = (byte)(newEpcLen >> 1);
                WriteUInt32LE(data, 1, pwd);
                Array.Copy(newEpc, 0, data, 5, newEpcLen);

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x04, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Destroy (permanently kill) a Gen 2 tag.</summary>
        public static long DestroyCard_G2(
            ref byte addr, byte[] epc, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 4 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                WriteUInt32LE(data, di, password); di += 4;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x05, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Set read-protect on a Gen 2 tag.</summary>
        public static long SetReadProtect_G2(
            ref byte addr, byte[] epc, ref uint password,
            byte rfuA, byte rfuB, byte accessPwdFlag,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = accessPwdFlag == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 4 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                WriteUInt32LE(data, di, password); di += 4;
                if (accessPwdFlag == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x08, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Set read-protect on multiple Gen 2 tags by password.</summary>
        public static long SetMultiReadProtect_G2(ref byte addr, ref uint password, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[4];
                WriteUInt32LE(data, 0, password);

                byte[] pkt = new byte[12];
                int pktLen = BuildPacket(pkt, addr, 0x09, data, 0, 4);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Remove read-protect from Gen 2 tags.</summary>
        public static long RemoveReadProtect_G2(ref byte addr, ref uint password, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[4];
                WriteUInt32LE(data, 0, password);

                byte[] pkt = new byte[12];
                int pktLen = BuildPacket(pkt, addr, 0x0A, data, 0, 4);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Check if a Gen 2 tag has read-protect set.</summary>
        public static long CheckReadProtected_G2(ref byte addr, ref byte protectStatus, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                long r = SimpleCommand(addr, 0x0B, portNum);
                if (r != ERR_OK) return r;
                if (_rxBuf[3] != 0) { if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4]; return (byte)_rxBuf[3]; }
                addr          = _rxBuf[1];
                protectStatus = _rxBuf[4];
                errorCode     = uint.MaxValue;
                return ERR_OK;
            }
        }

        /// <summary>Lock the user memory block on a Gen 2 tag.</summary>
        public static long LockUserBlock_G2(
            ref byte addr, byte[] epc, ref uint password,
            byte rfuA, byte rfuB, byte rfuC, byte lockCode,
            uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int eL    = (int)(byte)epcLen;
                int extra = rfuC == 1 ? 2 : 0;
                byte[] data = new byte[1 + eL + 4 + 1 + extra];
                int di = 0;
                data[di++] = (byte)(eL >> 1);
                Array.Copy(epc, 0, data, di, eL); di += eL;
                WriteUInt32LE(data, di, password); di += 4;
                data[di++] = lockCode;
                if (rfuC == 1) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x0E, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Monza 4QT
        // ═════════════════════════════════════════════════════════════════════════

        public static long GetMonza4QTWorkParamter_G2(
            ref byte addr, byte[] epc, byte epcDataLen, ref uint password,
            byte rfuA, byte rfuB, uint epcLen, byte[] paramOut, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                // epcDataLen = EPC byte count (a3 in original)
                // epcLen     = access pwd flag: 1 = include rfuA/rfuB (NumberOfBytesWritten in original)
                int dL = (int)(byte)epcDataLen;
                bool hasPwdFlag = (byte)epcLen == 1;
                int dataLen = 1 + dL + 4 + (hasPwdFlag ? 2 : 0);
                byte[] data = new byte[dataLen];
                int di = 0;
                data[di++] = (byte)(dL >> 1);
                Array.Copy(epc, 0, data, di, dL); di += dL;
                WriteUInt32LE(data, di, password); di += 4;
                if (hasPwdFlag) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x11, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[3] != 0)
                {
                    if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4];
                    return (byte)_rxBuf[3];
                }
                addr = _rxBuf[1];
                if (paramOut != null && paramOut.Length > 0)
                    paramOut[0] = _rxBuf[5]; // BYTE1(qword_18007C1B4) = _rxBuf[5]
                errorCode = uint.MaxValue;
                return ERR_OK;
            }
        }

        public static long SetMonza4QTWorkParamter_G2(
            ref byte addr, byte[] epc, byte epcDataLen, ref uint password,
            byte rfuA, byte rfuB, byte qtParam, uint epcLen, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                // epcDataLen = EPC byte count (a3 in original)
                // qtParam    = access flag: 1 = include rfuA/rfuB (a7 in original)
                // epcLen     = QT param value written to packet (NumberOfBytesWritten in original)
                int dL = (int)(byte)epcDataLen;
                bool hasPwdFlag = qtParam == 1;
                int dataLen = 1 + dL + 2 + 4 + (hasPwdFlag ? 2 : 0);
                byte[] data = new byte[dataLen];
                int di = 0;
                data[di++] = (byte)(dL >> 1);
                Array.Copy(epc, 0, data, di, dL); di += dL;
                data[di++] = 0;              // reserved byte (always 0)
                data[di++] = (byte)epcLen;   // QT param value
                WriteUInt32LE(data, di, password); di += 4;
                if (hasPwdFlag) { data[di++] = rfuA; data[di++] = rfuB; }

                byte[] pkt = new byte[di + 8];
                int pktLen = BuildPacket(pkt, addr, 0x12, data, 0, di);
                long r = SendReceive(pkt, pktLen, portNum, sleepBeforeReceiveMs: 100);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // ISO 18000-6B (Tag-it / 6B) commands
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>Inventory a single ISO 18000-6B tag. On success fills tagId (8 bytes).</summary>
        public static long Inventory_6B(ref byte addr, ref ulong tagId, int portNum)
        {
            lock (_lock)
            {
                long r = SimpleCommand(addr, 0x50, portNum);
                if (r != ERR_OK) return r;
                if (_rxBuf[0] == 13) // length = 13 means 8-byte tag ID returned
                    tagId = ReadUInt64LE(_rxBuf, 4);
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Inventory 6B tags with mask filter.</summary>
        public static long inventory2_6B(
            ref byte addr, byte maskStart, byte maskLen, byte maskData,
            ref ulong tagId, byte[] tagBuf, ref uint tagCount, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[11];
                data[0]  = maskStart;
                data[1]  = maskLen;
                data[2]  = maskData;
                WriteUInt64LE(data, 3, tagId);

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x51, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[0] > 5)
                {
                    tagCount = _rxBuf[4];
                    if (_rxBuf[4] > 0)
                        Array.Copy(_rxBuf, 5, tagBuf, 0, Math.Min(8 * _rxBuf[4], tagBuf.Length));
                }
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Read data from a 6B tag.</summary>
        public static long ReadCard_6B(
            ref byte addr, ref ulong tagId, byte startAddr, byte count,
            byte[] dataBuf, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[10];
                data[0] = startAddr;
                WriteUInt64LE(data, 1, tagId);
                data[9] = count;

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x52, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[3] != 0) { if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4]; return (byte)_rxBuf[3]; }
                if (_rxLen > 6 && dataBuf != null)
                    Array.Copy(_rxBuf, 4, dataBuf, 0, Math.Min(_rxLen - 6, dataBuf.Length));
                errorCode = uint.MaxValue;
                return ERR_OK;
            }
        }

        /// <summary>Write data to a 6B tag.</summary>
        public static long WriteCard_6B(
            ref byte addr, ref ulong tagId, byte startAddr, byte[] writeData,
            uint writeLen, ref byte writtenCount, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                int wL = (int)(byte)writeLen;
                // original: LEN = wL + 19 → total = wL + 20; packet has 6 zero-padding bytes after writeData
                byte[] data = new byte[1 + 8 + wL + 6];
                data[0] = startAddr;
                WriteUInt64LE(data, 1, tagId);
                Array.Copy(writeData, 0, data, 9, wL);
                // bytes [9+wL..14+wL] remain zero (reserved padding, matches original)

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x53, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[3] != 0) { if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4]; return (byte)_rxBuf[3]; }
                errorCode    = uint.MaxValue;
                writtenCount = (byte)wL;
                return ERR_OK;
            }
        }

        /// <summary>Lock a byte on a 6B tag (makes it read-only).</summary>
        public static long LockByte_6B(ref byte addr, ref ulong tagId, byte byteAddr, ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[9];
                data[0] = byteAddr;
                WriteUInt64LE(data, 1, tagId);

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x55, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return SimpleErrResponse(ref errorCode);
            }
        }

        /// <summary>Check lock status of a byte on a 6B tag.</summary>
        public static long CheckLock_6B(
            ref byte addr, ref ulong tagId, byte byteAddr, ref byte lockStatus,
            ref uint errorCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = new byte[9];
                data[0] = byteAddr;
                WriteUInt64LE(data, 1, tagId);

                byte[] pkt = new byte[data.Length + 8];
                int pktLen = BuildPacket(pkt, addr, 0x54, data, 0, data.Length);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;

                if (_rxBuf[3] != 0) { if (_rxBuf[3] == ERR_ANTICOLL) errorCode = _rxBuf[4]; return (byte)_rxBuf[3]; }
                lockStatus = _rxBuf[4];
                errorCode  = uint.MaxValue;
                return ERR_OK;
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Reader configuration writes
        // ═════════════════════════════════════════════════════════════════════════

        /// <summary>Write RF carrier / session frequency parameters.</summary>
        public static long Writedfre(ref byte addr, ref byte freqMin, ref byte freqMax, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { freqMin, freqMax };
                byte[] pkt  = new byte[10];
                int pktLen  = BuildPacket(pkt, addr, 0x22, data, 0, 2);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Write the reader's COM address.</summary>
        public static long WriteComAdr(ref byte addr, ref byte newAddr, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { newAddr };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x24, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Write the inventory scan time.</summary>
        public static long WriteScanTime(ref byte addr, ref byte scanTime, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { scanTime };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x25, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Write the baud rate index.</summary>
        public static long Writebaud(ref byte addr, ref byte baudIndex, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { baudIndex };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x28, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                if (_rxBuf[3] != 0) return (byte)_rxBuf[3];

                // reconfigure the serial port to the new baud rate (mirrors original DCB update)
                if (baudIndex < BaudRates.Length && BaudRates[baudIndex] != 0)
                {
                    var sp = _ports[portNum];
                    if (sp != null && sp.IsOpen)
                    {
                        try
                        {
                            sp.BaudRate = BaudRates[baudIndex];
                            sp.DiscardInBuffer();
                            sp.DiscardOutBuffer();
                        }
                        catch
                        {
                            sp.Close();
                            _ports[portNum] = null;
                            return ERR_COMM;
                        }
                    }
                }
                return ERR_OK;
            }
        }

        /// <summary>Set RF output power in dBm.</summary>
        public static long SetPowerDbm(ref byte addr, byte powerDbm, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { powerDbm };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x2F, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Control the reader's buzzer and LED.</summary>
        public static long BuzzerAndLEDControl(
            ref byte addr, byte buzzerCtrl, byte ledCtrl, byte buzzerTime, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { buzzerCtrl, ledCtrl, buzzerTime };
                byte[] pkt  = new byte[12];
                int pktLen  = BuildPacket(pkt, addr, 0x33, data, 0, 3);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Set tag-specific custom function code.</summary>
        public static long SetTagCustomFunction(ref byte addr, ref byte funcCode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { funcCode };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x34, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                // original checks cmd echo (byte_18007C1B2 == 52) before returning
                if (_rxBuf[2] != 0x34) return ERR_CMD;
                if (_rxBuf[3] != 0) return (byte)_rxBuf[3];
                addr     = _rxBuf[1];
                funcCode = _rxBuf[4];
                return ERR_OK;
            }
        }

        /// <summary>Set the beep mode.</summary>
        public static long SetBeep(ref byte addr, ref byte beepMode, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { beepMode };
                byte[] pkt  = new byte[8];
                int pktLen  = BuildPacket(pkt, addr, 0x35, data, 0, 1);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                if (beepMode < 0x50)  // update regardless of error code (original: if (*a2 < 0x50) *a2 = data)
                    beepMode = _rxBuf[4];
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Set EPC length mask (2 bytes).</summary>
        public static long SetLenMask(ref byte addr, byte[] mask, int portNum)
        {
            lock (_lock)
            {
                byte[] data = { mask[0], mask[1] };
                byte[] pkt  = new byte[10];
                int pktLen  = BuildPacket(pkt, addr, 0x40, data, 0, 2);
                long r = SendReceive(pkt, pktLen, portNum);
                if (r != ERR_OK) return r;
                return (byte)_rxBuf[3];
            }
        }

        /// <summary>Get EPC length mask (2 bytes).</summary>
        public static long GetLenMask(ref byte addr, ref ushort mask, int portNum)
        {
            lock (_lock)
            {
                long r = SimpleCommand(addr, 0x41, portNum);
                if (r != ERR_OK) return r;
                if (_rxBuf[3] == 0)
                    mask = (ushort)(_rxBuf[4] | (_rxBuf[5] << 8));
                return (byte)_rxBuf[3];
            }
        }

        // ═════════════════════════════════════════════════════════════════════════
        // Private utility helpers
        // ═════════════════════════════════════════════════════════════════════════

        private static long SimpleErrResponse(ref uint errorCode)
        {
            if (_rxBuf[3] != 0)
            {
                if (_rxBuf[3] == ERR_ANTICOLL)
                    errorCode = _rxBuf[4];
                else
                    errorCode = uint.MaxValue;
                return (byte)_rxBuf[3];
            }
            errorCode = uint.MaxValue;
            return ERR_OK;
        }

        private static void WriteUInt32LE(byte[] buf, int offset, uint value)
        {
            buf[offset]     = (byte)(value & 0xFF);
            buf[offset + 1] = (byte)((value >> 8) & 0xFF);
            buf[offset + 2] = (byte)((value >> 16) & 0xFF);
            buf[offset + 3] = (byte)((value >> 24) & 0xFF);
        }

        private static void WriteUInt64LE(byte[] buf, int offset, ulong value)
        {
            for (int i = 0; i < 8; i++)
                buf[offset + i] = (byte)((value >> (8 * i)) & 0xFF);
        }

        private static ulong ReadUInt64LE(byte[] buf, int offset)
        {
            ulong v = 0;
            for (int i = 0; i < 8; i++)
                v |= ((ulong)buf[offset + i]) << (8 * i);
            return v;
        }
    }
}
