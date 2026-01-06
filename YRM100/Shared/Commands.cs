using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.Shared
{
    public class Commands
    {
        /// <summary>
        /// lock payload type, 20 bits in total, high 4 bits are reserved.
        /// user can joint the 3 bytes to generate parameter ld for BuildLockFrame function. 
        /// </summary>
        public struct lock_payload_type
        {
            /// <summary>
            /// byte0 of lock payload, high 4 bits are reserved.
            /// </summary>
            public byte byte0;

            /// <summary>
            /// byte1 of lock payload. It is middle 8 bits.
            /// </summary>
            public byte byte1;

            /// <summary>
            /// byte2 of lock payload. It is the lowest 8 bits .
            /// </summary>
            public byte byte2;
        }
        private ModuleType device_mt;


        public Commands(ModuleType mt)
        {
            device_mt = mt;
        }

        /// <summary>
        /// Calculate the checksum of data. It will add all hexadecimal number of data,
        /// and only uses the LSB.
        /// </summary>
        /// <param name="data">data should be hexadecimal format</param>
        /// <returns>checksum of data, described in hexadecimal string</returns>
        public string CalcCheckSum(string data)
        {
            if (data == null)
            {
                return "";
            }
            int checksum = 0;
            string dataNoSpace = data.Replace(" ", "");
            try
            {
                for (int j = 0; j < dataNoSpace.Length; j += 2)
                {
                    checksum += Convert.ToInt32(dataNoSpace.Substring(j, 2), 16);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("do checksum error" + ex);
            }
            return (checksum % 256).ToString("X2");
        }

        /// <summary>
        /// Build a whole frame
        /// </summary>
        /// <param name="data">this should not include checksum </param>
        /// <returns>Whole frame. Frame header, ender and checksum will be added
        /// automatically. It will insert a space between every two chars. </returns>
        public string BuildFrame(string data)
        {
            if (data == null)
            {
                return "";
            }
            string frame_start = "AA";
            string frame_end = "DD";
            if (device_mt == ModuleType.YRM100)
            {
                frame_start = "BB";
                frame_end = "7E";
            }
            string frame = data.Replace(" ", "");
            string checkSum = CalcCheckSum(frame);
            return frame_start + frame + checkSum + frame_end;
        }

        /// <summary>
        /// Build a Whole Frame that Doesn't Have Data Field
        /// </summary>
        /// <param name="msgType">Packet Type</param>
        /// <param name="cmdCode">Command Code</param>
        /// <returns>Whole frame. Frame header, ender and checksum will be added
        /// automatically. It will insert a space between every two chars. </returns>
        public string BuildFrame(string msgType, string cmdCode)
        {
            if (msgType == null || cmdCode == null)
            {
                return "";
            }

            string frame_start = "AA";
            string frame_end = "DD";
            if (device_mt == ModuleType.YRM100)
            {
                frame_start = "BB";
                frame_end = "7E";
            }

            msgType = msgType.Replace(" ", "");
            if (msgType.Length == 1)
            {
                msgType = "0" + msgType;
            }
            cmdCode = cmdCode.Replace(" ", "");
            if (cmdCode.Length == 1)
            {
                cmdCode = "0" + cmdCode;
            }
            string frame = msgType + cmdCode + "0000";
            frame = frame_start + frame + cmdCode + frame_end;
            return AutoAddSpace(frame);
        }

        /// <summary>
        /// Build a whole frame
        /// </summary>
        /// <param name="msgType">Packet Type</param>
        /// <param name="cmdCode">Command Code</param>
        /// <param name="data">Data field</param>
        /// <returns>Whole frame. Frame header, ender and checksum will be added
        /// automatically. It will insert a space between every two chars. </returns>
        public string BuildFrame(string msgType, string cmdCode, string data)
        {
            if (msgType == null || cmdCode == null)
            {
                return "";
            }

            string frame_start = "AA";
            string frame_end = "DD";
            if (device_mt == ModuleType.YRM100)
            {
                frame_start = "BB";
                frame_end = "7E";
            }

            msgType = msgType.Replace(" ", "");
            if (msgType.Length == 1)
            {
                msgType = "0" + msgType;
            }
            cmdCode = cmdCode.Replace(" ", "");
            if (cmdCode.Length == 1)
            {
                cmdCode = "0" + cmdCode;
            }
            int dataHexLen = 0;
            if (data != null)
            {
                data = data.Replace(" ", "");
                if (data.Length == 1)
                {
                    data = "0" + data;
                }
                dataHexLen = data.Length / 2;
                data = data.Substring(0, dataHexLen * 2);
            }
            string frame = msgType + cmdCode + dataHexLen.ToString("X4") + data;
            string checkSum = CalcCheckSum(frame);
            frame = frame_start + frame + checkSum + frame_end;
            return AutoAddSpace(frame);
        }

        /// <summary>
        /// Build a whole frame
        /// </summary>
        /// <param name="msgType">Packet Type</param>
        /// <param name="cmdCode">Command Code</param>
        /// <param name="dataArr">Data field</param>
        /// <returns>Whole frame. Frame header, ender and checksum will be added
        /// automatically. It will insert a space between every two chars.</returns>
        public string BuildFrame(string msgType, string cmdCode, string[] dataArr)
        {
            if (msgType == null || cmdCode == null)
            {
                return "";
            }
            string frame_start = "AA";
            string frame_end = "DD";
            if (device_mt == ModuleType.YRM100)
            {
                frame_start = "BB";
                frame_end = "7E";
            }

            msgType = msgType.Replace(" ", "");
            if (msgType.Length == 1)
            {
                msgType = "0" + msgType;
            }
            cmdCode = cmdCode.Replace(" ", "");
            if (cmdCode.Length == 1)
            {
                cmdCode = "0" + cmdCode;
            }
            int dataHexLen = 0;
            if (dataArr != null)
            {
                dataHexLen = dataArr.Length;
            }
            string frame = frame_start + msgType + cmdCode + dataHexLen.ToString("X4");
            int checksum = 0;
            checksum += 391;
            try
            {
                for (int i = 0; i < dataHexLen; i++)
                {
                    dataArr[i] = dataArr[i].Replace(" ", "");
                    frame = ((dataArr[i].Length != 1) ? (frame + dataArr[i]) : (frame + "0" + dataArr[i]));
                    checksum += Convert.ToInt32(dataArr[i], 16);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("convert error " + ex);
            }
            return frame + (checksum % 256).ToString("X2") + frame_end;
        }

        /// <summary>
        /// Insert a Space Between Every Two Chars
        /// </summary>
        /// <param name="Str">String that has no spaces</param>
        /// <returns>String inserted spaces</returns>
        public string AutoAddSpace(string Str)
        {
            string StrDone = string.Empty;
            if (Str == null || Str.Length == 0)
            {
                return StrDone;
            }
            int i;
            for (i = 0; i <= Str.Length - 2; i += 2)
            {
                StrDone = StrDone + Str[i] + Str[i + 1] + " ";
            }
            if (Str.Length % 2 != 0)
            {
                StrDone = StrDone + "0" + Str[i];
            }
            return StrDone;
        }

        /// <summary>
        /// Build Get Module Information Command Packet
        /// </summary>
        /// <param name="infoType">Information Type(Hardware version, Software version or Manufacture Information</param>
        /// <returns>Get Module Information Command Packet</returns>
        public string BuildGetModuleInfoFrame(string infoType)
        {
            return BuildFrame("00", "03", infoType);
        }

        /// <summary>
        /// Build set region Packet
        /// </summary>
        /// <param name="region">Region Code</param>
        /// <returns>Set Region Packet</returns>
        public string BuildSetRegionFrame(string region)
        {
            if (region == null || region.Length == 0)
            {
                return "";
            }
            return BuildFrame("00", "07", region);
        }

        /// <summary>
        /// Build Set RF Channel Packet
        /// </summary>
        /// <param name="ch">Channel Number</param>
        /// <returns>Set RF Channel Packet</returns>
        public string BuildSetRfChannelFrame(string ch)
        {
            if (ch == null || ch.Length == 0)
            {
                return "";
            }
            return BuildFrame("00", "AB", ch);
        }

        /// <summary>
        /// Build Get RF Channel Packet
        /// </summary>
        /// <returns>Get RF Channel Packet</returns>
        public string BuildGetRfChannelFrame()
        {
            return BuildFrame("00", "AA");
        }

        /// <summary>
        /// Build Set HFSS On/Off Packet
        /// </summary>
        /// <param name="OnOff">SET_ON/SET_OFF</param>
        /// <returns>Set HFSS On/Off Packet</returns>
        public string BuildSetFhssFrame(string OnOff)
        {
            if (OnOff == null || OnOff.Replace(" ", "").Length == 0)
            {
                return "";
            }
            return BuildFrame("00", "AD", OnOff);
        }

        /// <summary>
        /// Build Set Reader Switch Ant
        /// </summary>
        /// <param name="Ant">Switch Ant</param>
        /// <returns>Set Reader Switch Ant Packet</returns>
        public string BuildSetPaAntFrame(short Ant, byte staytime)
        {
            string strAnt = Ant.ToString("X4");
            string strStaytime = staytime.ToString("X2");
            return BuildFrame("00", "A8", strAnt + strStaytime);
        }

        /// <summary>
        /// Build Get Reader Switch Ant
        /// </summary>
        /// <returns>Get Reader Switch Ant Packet</returns>
        public string BuildGetPaAntFrame()
        {
            return BuildFrame("00", "A7");
        }

        /// <summary>
        /// Build Set PA Power Packet
        /// </summary>
        /// <param name="powerdBm">dBm * 100, eg. 7.5dBm = 750</param>
        /// <returns>Set PA Power Packet</returns>
        public string BuildSetPaPowerFrame(short powerdBm)
        {
            string strPower = powerdBm.ToString("X4");
            return BuildFrame("00", "B6", strPower);
        }

        /// <summary>
        /// Build Get PA Power Packet
        /// </summary>
        /// <returns>Get PA Power Packet</returns>
        public string BuildGetPaPowerFrame()
        {
            return BuildFrame("00", "B7");
        }

        /// <summary>
        /// Build Set CW On/Off Packet
        /// </summary>
        /// <param name="OnOff">On("FF")/Off("00")</param>
        /// <returns>Set CW On/Off Packet</returns>
        public string BuildSetCWFrame(string OnOff)
        {
            if (OnOff == null || OnOff.Replace(" ", "").Length == 0)
            {
                return "";
            }
            return BuildFrame("00", "B0", OnOff);
        }

        /// <summary>
        /// Build Read Single Tag ID Packet
        /// </summary>
        /// <returns>Read Single Tag ID Packet</returns>
        public string BuildReadSingleFrame()
        {
            return BuildFrame("00", "22");
        }

        /// <summary>
        /// Build Read Multi Tag ID Packet
        /// </summary>
        /// <param name="loopNum">Loop Number</param>
        /// <returns>Read Multi Tag ID Packet</returns>
        public string BuildReadMultiFrame(int loopNum)
        {
            if (loopNum <= 0 || loopNum > 65536)
            {
                return "";
            }
            return BuildFrame("00", "27", "22" + loopNum.ToString("X4"));
        }

        /// <summary>
        /// Build Stop Read Multi TAG ID Packet
        /// </summary>
        /// <returns>Stop Read Multi TAG ID Packet</returns>
        public string BuildStopReadFrame()
        {
            return BuildFrame("00", "28");
        }

        /// <summary>
        /// Build Set Query Parameter Packet
        /// </summary>
        /// <param name="dr">DR(1 bit)     DR=8(0)、DR=64/3(1)</param>
        /// <param name="m">M(2 bit)      M=1(00)、M=2(01)、M=4(10)、M=8(11)</param>
        /// <param name="TRext">TRext(1 bit)   no pilot tone(0)、use pilot tone(1)</param>
        /// <param name="sel">Sel(2 bit)     ALL(00 01)、~SL(10)、SL(11)</param>
        /// <param name="session">Session(2 bit)  S0(00)、S1(01)、S2(10)、S3(11)</param>
        /// <param name="target">Target(1 bit)   A(0)、B(1)</param>
        /// <param name="q">Q(4 bit)       0-15</param>
        /// <returns>Set Query Parameter Packet</returns>
        public string BuildSetQueryFrame(int dr, int m, int TRext, int sel, int session, int target, int q)
        {
            string dataField = ((dr << 7) | (m << 5) | (TRext << 4) | (sel << 2) | session).ToString("X2") + ((target << 7) | (q << 3)).ToString("X2");
            return BuildFrame("00", "0E", dataField);
        }

        /// <summary>
        /// Build Get Query Parameter Packet
        /// </summary>
        /// <returns>Get Query Parameter Packet</returns>
        public string BuildGetQueryFrame()
        {
            return BuildFrame("00", "0D");
        }

        /// <summary>
        /// Build Set Select Parameter Packet
        /// </summary>
        /// <param name="target">Target(3 bit)     S0(000)、S1(001)、S2(010)、S3(011)、SL(100)</param>
        /// <param name="action">Action(3 bit)    Reference to ISO18000-6C</param>
        /// <param name="memBank">Memory bank(2 bit)    RFU(00)、EPC(01)、TID(10)、USR(11)</param>
        /// <param name="pointer">Pointer(32 bit)     Start Address</param>
        /// <param name="len">Length(8 bit)  </param>
        /// <param name="mask">Mask(0-255bit)   Mask Data according to Length</param>
        /// <param name="truncated">Truncate(1 bit)   Disable(0)、Enable(1)</param>
        /// <returns>Set Select Parameter Packet</returns>
        public string BuildSetSelectFrame(int target, int action, int memBank, int pointer, int len, int truncated, string mask)
        {
            string dataField = string.Empty;
            dataField = ((target << 5) | (action << 2) | memBank).ToString("X2");
            dataField = dataField + pointer.ToString("X8") + len.ToString("X2");
            dataField = ((truncated != 128 && truncated != 1) ? (dataField + "00") : (dataField + "80"));
            dataField += mask.Replace(" ", "");
            return BuildFrame("00", "0C", dataField);
        }

        /// <summary>
        /// Build Get Select Parameter Packet
        /// </summary>
        /// <returns>Get Select Parameter Packet</returns>
        public string BuildGetSelectFrame()
        {
            return BuildFrame("00", "0B");
        }

        /// <summary>
        /// Build Set Inventory Mode Frame.
        /// When set to Mode0, RFID Reader will first send Select command, then begin an
        /// Inventory Round. If set to Mode1, it will not. If set to Mode2, it will send Select
        /// before all tag operation except single Inventory.
        /// </summary>
        /// <param name="mode">INVENTORY_MODE0("00")/INVENTORY_MODE1("01")/INVENTORY_MODE2("02")</param>
        /// <returns>Set Inventory Mode Frame</returns>
        public string BuildSetInventoryModeFrame(string mode)
        {
            return BuildFrame("00", "12", mode);
        }

        /// <summary>
        /// Build Read Tag Data Packet.
        /// </summary>
        /// <param name="accessPwd">Access Password. If a tag NOT needs Access, it should be "00 00 00 00".</param>
        /// <param name="memBank">Memory Bank, 0x00-RFU,0x01-EPC,0x02-TID,0x03-User</param>
        /// <param name="sa">Start Address</param>
        /// <param name="dl">Data Length in Words</param>
        /// <returns>Read Tag Data Packet.</returns>
        public string BuildReadDataFrame(string accessPwd, int memBank, int sa, int dl)
        {
            if (accessPwd.Replace(" ", "").Length != 8)
            {
                return "";
            }
            string dataField = accessPwd.Replace(" ", "");
            dataField = dataField + memBank.ToString("X2") + sa.ToString("X4") + dl.ToString("X4");
            return BuildFrame("00", "39", dataField);
        }

        /// <summary>
        /// Build Write Tag Data Packet
        /// </summary>
        /// <param name="accessPwd">Access Password. If a tag NOT needs Access, it should be "00 00 00 00".</param>
        /// <param name="memBank">Memory Bank, 0x00-RFU,0x01-EPC,0x02-TID,0x03-User</param>
        /// <param name="sa">Start Address</param>
        /// <param name="dl">Data Length in word</param>
        /// <param name="dt">Data to Write. It Should Be "dl" Words</param>
        /// <returns>Write Tag Data Packet</returns>
        public string BuildWriteDataFrame(string accessPwd, int memBank, int sa, int dl, string dt)
        {
            if (accessPwd.Replace(" ", "").Length != 8)
            {
                return "";
            }
            string dataField = accessPwd.Replace(" ", "");
            string text = dataField;
            dataField = text + memBank.ToString("X2") + sa.ToString("X4") + dl.ToString("X4") + dt.Replace(" ", "");
            return BuildFrame("00", "49", dataField);
        }

        /// <summary>
        /// Generate the lock payload.
        /// </summary>
        /// <param name="lockOpt">Value from 0 to 3 means 0:unlock, 1:lock, 2:param unlock, 3:perma lock</param>
        /// <param name="memSpace">Value from 0 to 4 means 0:Kill password, 1:Access password, 2:EPC memBank, 3:TID memBank, 4:User memBank</param>
        /// <returns>lock payload</returns>
        public static lock_payload_type genLockPayload(byte lockOpt, byte memSpace)
        {
            lock_payload_type payload = default(lock_payload_type);
            payload.byte0 = 0;
            payload.byte1 = 0;
            payload.byte2 = 0;
            switch (memSpace)
            {
                case 0:
                    switch (lockOpt)
                    {
                        case 0:
                            payload.byte0 |= 8;
                            payload.byte1 |= 0;
                            break;
                        case 1:
                            payload.byte0 |= 8;
                            payload.byte1 |= 2;
                            break;
                        case 2:
                            payload.byte0 |= 12;
                            payload.byte1 |= 1;
                            break;
                        case 3:
                            payload.byte0 |= 12;
                            payload.byte1 |= 3;
                            break;
                    }
                    break;
                case 1:
                    switch (lockOpt)
                    {
                        case 0:
                            payload.byte0 |= 2;
                            payload.byte2 |= 0;
                            break;
                        case 1:
                            payload.byte0 |= 2;
                            payload.byte2 |= 128;
                            break;
                        case 2:
                            payload.byte0 |= 3;
                            payload.byte2 |= 64;
                            break;
                        case 3:
                            payload.byte0 |= 3;
                            payload.byte2 |= 192;
                            break;
                    }
                    break;
                case 2:
                    switch (lockOpt)
                    {
                        case 0:
                            payload.byte1 |= 128;
                            payload.byte2 |= 0;
                            break;
                        case 1:
                            payload.byte1 |= 128;
                            payload.byte2 |= 32;
                            break;
                        case 2:
                            payload.byte1 |= 192;
                            payload.byte2 |= 16;
                            break;
                        case 3:
                            payload.byte1 |= 192;
                            payload.byte2 |= 48;
                            break;
                    }
                    break;
                case 3:
                    switch (lockOpt)
                    {
                        case 0:
                            payload.byte1 |= 32;
                            payload.byte2 |= 0;
                            break;
                        case 1:
                            payload.byte1 |= 32;
                            payload.byte2 |= 8;
                            break;
                        case 2:
                            payload.byte1 |= 48;
                            payload.byte2 |= 4;
                            break;
                        case 3:
                            payload.byte1 |= 48;
                            payload.byte2 |= 12;
                            break;
                    }
                    break;
                case 4:
                    switch (lockOpt)
                    {
                        case 0:
                            payload.byte1 |= 8;
                            payload.byte2 |= 0;
                            break;
                        case 1:
                            payload.byte1 |= 8;
                            payload.byte2 |= 2;
                            break;
                        case 2:
                            payload.byte1 |= 12;
                            payload.byte2 |= 1;
                            break;
                        case 3:
                            payload.byte1 |= 12;
                            payload.byte2 |= 3;
                            break;
                    }
                    break;
            }
            return payload;
        }

        /// <summary>
        /// Build Lock Tag Packet
        /// </summary>
        /// <param name="accessPwd">Access Password. If a tag NOT needs Access, it should be "00 00 00 00".</param>
        /// <param name="ld">Lock Payload.It should be 3 bytes, the first 4 bits are not used</param>
        /// <returns>Lock Tag Packet</returns>
        public string BuildLockFrame(string accessPwd, int ld)
        {
            accessPwd = accessPwd.Replace(" ", "");
            if (accessPwd.Length != 8)
            {
                return "";
            }
            string dataField = accessPwd.Replace(" ", "");
            dataField += ld.ToString("X6");
            return BuildFrame("00", "82", dataField);
        }

        /// <summary>
        /// Build Kill Tag Packet
        /// </summary>
        /// <param name="killPwd">Kill Password. If Kill Password is "00 00 00 00", the Kill Operation Will Be ignored By Tag</param>
        /// <param name="rfu">RFU(000)/Recomm. If you want to kill a tag, just pass 0 by default.</param>
        /// <returns>Kill Tag Packet</returns>
        public string BuildKillFrame(string killPwd, int rfu = 0)
        {
            killPwd = killPwd.Replace(" ", "");
            string dataField = killPwd;
            if (rfu != 0)
            {
                try
                {
                    dataField += rfu.ToString("X2");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Convert RFU Error! " + ex.Message);
                }
            }
            return BuildFrame("00", "65", dataField);
        }

        /// <summary>
        /// Build Set Modem Parameter Packet
        /// </summary>
        /// <param name="mixerGain">mixer gain(0-7)</param>
        /// <param name="IFAmpGain">IF gain(0-7)</param>
        /// <param name="signalThreshold">decode threshold</param>
        /// <returns>Set Modem Parameter Packet</returns>
        public string BuildSetModemParaFrame(int mixerGain, int IFAmpGain, int signalThreshold)
        {
            string dataField = mixerGain.ToString("X2") + IFAmpGain.ToString("X2") + signalThreshold.ToString("X4");
            return BuildFrame("00", "F0", dataField);
        }

        /// <summary>
        /// Build Read Modem Parameter Packet
        /// </summary>
        /// <returns>Read Modem Parameter Packet</returns>
        public string BuildReadModemParaFrame()
        {
            return BuildFrame("00", "F1");
        }

        /// <summary>
        /// Build Scan Jammer Command Packet
        /// </summary>
        /// <returns>Scan Jammer Command Packet</returns>
        public string BuildScanJammerFrame()
        {
            return BuildFrame("00", "F2");
        }

        /// <summary>
        /// Build Scan RSSI Command Packet
        /// </summary>
        /// <returns>Scan RSSI Command Packet</returns>
        public string BuildScanRssiFrame()
        {
            return BuildFrame("00", "F3");
        }

        /// <summary>
        /// Build IO Control Command Packet
        /// </summary>
        /// <param name="optType">operation type. 0x00：set IO dirction;
        /// 0x01: set IO Level;
        /// 0x02: Read IO Level.</param>
        /// <param name="ioPort">the IO which will be handled. IO1 - IO4</param>
        /// <param name="modeOrLevel">if optType=0x00, set IO mode(0x00 for Input mode, 0x01 for Output mode)
        /// if optType=0x01, set IO Level(0x00 for output Low level, 0x01 for output High level</param>
        /// <returns>IO Control Command Packet</returns>
        public string BuildIoControlFrame(byte optType, byte ioPort, byte modeOrLevel)
        {
            string strParam0 = optType.ToString("X2");
            string strParam1 = ioPort.ToString("X2");
            string strParam2 = modeOrLevel.ToString("X2");
            return BuildFrame("00", "1A", strParam0 + strParam1 + strParam2);
        }

        /// <summary>
        /// Build Set Reader Environment Mode Command Packet
        /// </summary>
        /// <param name="mode">Reader environment mode. 0x01 for Dense Reader mode, 0x00 for High Sensitivity mode</param>
        /// <returns>Set Reader Environment Mode Command Packet</returns>
        public string BuildSetReaderEnvModeFrame(byte mode)
        {
            return BuildFrame("00", "F5", mode.ToString("X2"));
        }

        /// <summary>
        /// Build Save Configuration to NV Memory Command Packet
        /// </summary>
        /// <param name="NVenable">0x01 for Enable NV Configuration. The Reader Will Load the Configuration when Next Power-up.
        /// 0x00 for Disable NV Configuration. This Setting Will Erase the Exist Configuration!</param>
        /// <returns>Save Configuration to NV Memory Command Packet</returns>
        public string BuildSaveConfigToNvFrame(byte NVenable)
        {
            return BuildFrame("00", "09", NVenable.ToString("X2"));
        }

        /// <summary>
        /// Build Load Configuration From NV Memory Command Packet
        /// </summary>
        /// <returns>Load Configuration From NV Memory Command Packet</returns>
        public string BuildLoadConfigFromNvFrame()
        {
            return BuildFrame("00", "0A");
        }

        /// <summary>
        /// Build Set Module to Sleep Mode Command Packet
        /// </summary>
        /// <returns>Set Module to Sleep Mode Command Packet</returns>
        public string BuildSetModuleSleepFrame()
        {
            return BuildFrame("00", "17");
        }

        /// <summary>
        /// Build Set Module Sleep Time Command Packet
        /// </summary>
        /// <param name="time">Idle Time In Minutes.
        /// If the module has NO operation after the time, it will go to sleep mode.</param>
        /// <returns>Set Module Sleep Time Command Packet</returns>
        public string BuildSetSleepTimeFrame(byte time)
        {
            return BuildFrame("00", "1D", time.ToString("X2"));
        }

        /// <summary>
        /// Build Insert RF Channel Command Packet
        /// </summary>
        /// <param name="channelNum">the Count of Channels Will Be Inserted</param>
        /// <param name="channelList">List of All the Channel Index</param>
        /// <returns>Insert RF Channel Command Packet</returns>
        public string BuildInsertRfChFrame(int channelNum, byte[] channelList)
        {
            string param = channelNum.ToString("X2");
            if (channelList == null || channelList.Length == 0)
            {
                return "";
            }
            for (int i = 0; i < channelNum; i++)
            {
                param += channelList[i].ToString("X2");
            }
            return BuildFrame("00", "A9", param);
        }

        /// <summary>
        /// Build Change Config Command Packet for NXP G2X Tags 
        /// </summary>
        /// <param name="accessPwd">Access Password.</param>
        /// <param name="ConfigData">16 bits Config data. The bits to be toggled in the configuration register need to be set to '1'.</param>
        /// <returns>Change Config Command Packet</returns>
        public string BuildNXPChangeConfigFrame(string accessPwd, int ConfigData)
        {
            accessPwd = accessPwd.Replace(" ", "");
            if (accessPwd.Length != 8)
            {
                return "";
            }
            string dataField = accessPwd;
            dataField += ConfigData.ToString("X4");
            return BuildFrame("00", "E0", dataField);
        }

        /// <summary>
        /// Build ReadProtect/ResetReadProtect Command Packet for NXP G2X Tags 
        /// </summary>
        /// <param name="accessPwd">Access Password.</param>
        /// <param name="isReset">If it is a Reset ReadProtect command, fill true.</param>
        /// <returns>ReadProtect/ResetReadProtect Command Packet</returns>
        public string BuildNXPReadProtectFrame(string accessPwd, bool isReset)
        {
            accessPwd = accessPwd.Replace(" ", "");
            if (accessPwd.Length != 8)
            {
                return "";
            }
            string dataField = accessPwd;
            dataField += (isReset ? "01" : "00");
            return BuildFrame("00", "E1", dataField);
        }

        /// <summary>
        /// Build Change EAS Command Packet for NXP G2X Tags 
        /// </summary>
        /// <param name="accessPwd">Access Password.</param>
        /// <param name="isSet">If uset want to set PSF bit, fill true.</param>
        /// <returns>Change EAS Command Packet</returns>
        public string BuildNXPChangeEasFrame(string accessPwd, bool isSet)
        {
            accessPwd = accessPwd.Replace(" ", "");
            if (accessPwd.Length != 8)
            {
                return "";
            }
            string dataField = accessPwd;
            dataField += (isSet ? "01" : "00");
            return BuildFrame("00", "E3", dataField);
        }

        /// <summary>
        /// Build EAS Alarm Command Packet for NXP G2X Tags 
        /// </summary>
        /// <returns>EAS Alarm Command Packet</returns>
        public string BuildNXPEasAlarmFrame()
        {
            return BuildFrame("00", "E4");
        }

        /// <summary>
        /// Build QT Command Packet for Monza Tags
        /// </summary>
        /// <param name="accessPwd">Access Password.</param>
        /// <param name="isWrite">false: Build QT Read command; true: QT Wrtie command</param>
        /// <param name="QT_SR">true: set QT_SR to 1, the tag will reduce range if in or about to be in OPEN or SECURED state;
        /// false: set QT_SR to 0, tag does not reduce range</param>
        /// <param name="QT_MEM">true: set QT_MEM to 1, the tag will use Public Memory Map;
        /// false: set QT_MEM to 0, the tag will use Private Memory Map.</param>
        /// <param name="isPersistence">true: write command result to Nonvolatile Memory; false: write to volatile memory.
        /// default true.</param>
        /// <returns>Monza Tag QT Read or QT Write Command Packet</returns>
        public string BuildMonzaQTFrame(string accessPwd, bool isWrite, bool QT_SR, bool QT_MEM, bool isPersistence = true)
        {
            accessPwd = accessPwd.Replace(" ", "");
            if (accessPwd.Length != 8)
            {
                return "";
            }
            string dataField = accessPwd;
            dataField += (isWrite ? "01" : "00");
            dataField += (isPersistence ? "01" : "00");
            dataField += ((QT_SR ? 32768 : 0) | (QT_MEM ? 16384 : 0)).ToString("X4");
            return BuildFrame("00", "E5", dataField);
        }
    }

}
