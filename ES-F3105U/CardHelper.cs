using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCchip.Reader.API;

namespace ES_F3105U
{
    public enum MemBank : byte
    {
        RESERVED,
        EPC,
        TID,
        USER
    }

    public class Ref<T>
    {
        private readonly object _lockObject = new object();
        public Ref() { }
        public Ref(T value, string flagName)
        {
            lock (_lockObject)
            {
                FlagName = flagName;
                Value = value;
            }
        }
        public string FlagName { get; set; }
        public T Value { get; set; }
    }
    public class ReadWriteParsedData
    {
        public ReadWriteParsedData() { }
        public ErrorCode waitFlagStatus { get; set; }
        public ErrorCode readerStatusCode { get; set; }
        public uint TagCount { get; set; }
        public byte DataLen { get; set; }
        public uint PC { get; set; }
        public uint LenEPC { get; set; }
        public byte[]? RawEPC { get; set; }
        public string? StringEPC { get; set; }
        public uint CRC { get; set; }
        public byte[]? RawData { get; set; }
        public string? StringData { get; set; }
        public uint ReadLen { get; set; }
        public int AntID { get; set; }
        public int ReadCount { get; set; }
        public int ErrCode { get; set; }
    }

    partial class MainForm
    {
        private static byte[,] para_B = {{43,43,45,49,43,43,45,49},
                                            {43,43,45,49,43,43,45,49},
                                            {43,43,45,49,43,43,45,49},
                                            {53,53,48,43,49,45,43,43},
                                            {47,47,47,47,46,43,43,43}};

        private static int[,] para_C = {{43,43,45,49,43,43,45,49},
                                           {43,43,45,49,43,43,45,49},
                                           {43,43,45,49,43,43,45,49},
                                           {-283,-283,-283,-283,-283,-283,-283,-283},
                                           {-303,-283,-253,-238,-304,-313,-280,-266}};

        private static int calculateRssi(int rssiData, byte epcLen)
        {
            byte rssiMode = 0;
            byte hardwareMode = 0;
            int B = 0;
            int C = 0;
            int D = 0;
            int rssiVal = 0;
            float A = 1.0f;
            float rssiTemp = 0.0f;

            if (epcLen <= 0) epcLen = 1;
            rssiMode = (byte)(((rssiData >> 24) & 0x000000E0) >> 5);
            hardwareMode = (byte)(((rssiData >> 24) & 0x0000001E) >> 1);
            rssiData = (rssiData & 0x01ffffff);

            if (rssiMode > 7 || hardwareMode > 4)
            {
                return -90;
            }

            B = para_B[hardwareMode, rssiMode];
            C = para_C[hardwareMode, rssiMode];

            rssiTemp = (rssiData / epcLen) * A;
            rssiVal = (int)((B * Math.Log10(rssiTemp)) + C + D);

            if (rssiVal > 0)
            {
                rssiVal = 0;
            }
            else if (rssiVal < -90)
            {
                rssiVal = -90;
            }

            return rssiVal;
        }

        private async Task<bool> AttemptRead_6C(byte membank, uint wordaddr, ushort wordcnt, uint password, ReadWriteParsedData parsed_data)
        {
            if (parsed_data == null ||
                readerClient == null) return false;

            flag_cmd_read.Value = false;
            readerClient.MsgBaseRead(membank, wordaddr, wordcnt, password);
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_read));
            await task;

            parsed_data.waitFlagStatus = task.Result;
            parsed_data.readerStatusCode = readerStatusCode;

            if (task.Result != ErrorCode.OK || readerStatusCode != (int)ErrorCode.OK)
            {
                if (task.Result == ErrorCode.Timeout)   //Propogate the timeout
                {
                    parsed_data.readerStatusCode = ErrorCode.Timeout;
                }
                    
                return false;
            }
                
            //Parse the results
            uint index = 0;

            //TagCount
            uint tagCount = BitConverter.ToUInt16(readerReadBuffer.Take(2).Reverse().ToArray());
            parsed_data.TagCount = tagCount;
            index += 2;

            //RawData len
            byte dataLen = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.DataLen = dataLen;
            index++;

            //PC
            uint PC = BitConverter.ToUInt16(readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.PC = PC;
            index += 2;

            //Figure out how long the EPC length is from PC
            uint lenEPC = (PC >> 11) * 2; //This is number of words, we want this in bytes
            parsed_data.LenEPC = lenEPC;

            byte[] EPC = readerReadBuffer.Skip((int)index).Take((int)lenEPC).ToArray();

            if (parsed_data.RawEPC == null)
                parsed_data.RawEPC = new byte[lenEPC];

            Array.Copy(EPC, 0, parsed_data.RawEPC, 0, lenEPC);
            index += lenEPC;

            string strEPC = ByteArrayToHexString(EPC);
            parsed_data.StringEPC = strEPC;

            //CRC
            uint CRC = BitConverter.ToUInt16(readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.CRC = CRC;
            index += 2;

            //Data
            //Calculate how many bytes of data was returned
            uint dataReadLen = (uint)dataLen - 2 - lenEPC - 2;    //DataLen - PC - LenEPC - CRC
            byte[] readBytes = readerReadBuffer.Skip((int)index).Take((int)dataReadLen).ToArray();

            if (parsed_data.RawData == null)
                parsed_data.RawData = new byte[dataReadLen];
            Array.Copy(readBytes, 0, parsed_data.RawData, 0, dataReadLen);
            parsed_data.StringData = ByteArrayToHexString(readBytes);
            index += dataReadLen;

            //ReadLen
            uint readLen = BitConverter.ToUInt16(readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.ReadLen = readLen;
            index += 2;

            int antID = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.AntID = antID;
            index++;

            int readCount = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.ReadCount = readCount;
            index++;

            return true;
        }
        private async Task<bool> AttemptWrite_6C_Buffer(byte membank, uint accessPwd, uint startAddr, byte[] writeData)
        {
            int writeChunkSize = 8 * 2;
            string readDataEPC = "";

            for (var i = 0; i < writeData.Length / writeChunkSize + 1; i++)
            {

                byte[] bWriteChunk = writeData.Skip(i * writeChunkSize).Take(writeChunkSize).ToArray();
                if (bWriteChunk == null || bWriteChunk.Length == 0) continue;

                ReadWriteParsedData result = new ReadWriteParsedData();

                DateTime dtStart = DateTime.Now;

                uint wordWriteChunkSize = (uint)(i * writeChunkSize);
                if (wordWriteChunkSize > 0) wordWriteChunkSize = wordWriteChunkSize / 2;    //Convert to word count
                uint nextWriteAddr = startAddr + wordWriteChunkSize;  // startAddr + Convert byte to word count

                ushort currentChunkSize = (ushort)(bWriteChunk.Length / 2);   //Convert byte to word count

                Task<bool> task = Task.Run(() => AttemptWrite_6C(membank, nextWriteAddr, currentChunkSize, accessPwd, bWriteChunk, result));
                await task;

                if (task.Result == true)
                {
                    if (readDataEPC == "" && result.StringEPC != null)  //Latch EPC
                        readDataEPC = result.StringEPC;

                    if (result.StringEPC != readDataEPC)
                    {
                        AddListBoxResponse($"AttemptWrite_6C_Buffer -> Incorrect EPC, expecting {readDataEPC} but got {result.StringEPC}");
                        return false;
                    }

                    if (result.ErrCode != (int)ErrorCode.RREC_SUCCESS)
                    {
                        string parsedReturn = GetErrorCodeString((byte)result.ErrCode);
                        AddListBoxResponse($"AttemptWrite_6C_Buffer -> Write Error code returned, {parsedReturn}");
                        return false;
                    }
                }
                else
                {
                    //AddListBoxResponse($"AttemptWrite_6C_Buffer -> Abandoning Loop");
                    return false;
                }

                //Internal cooldown
                TimeSpan td = DateTime.Now - dtStart;
                if (td.Milliseconds < minCooldown)
                {
                    Thread.Sleep(minCooldown - td.Milliseconds);
                }
            }
            return true;
        }

        private async Task<bool> AttemptWrite_6C(byte membank, uint wordaddr, ushort wordcnt, uint password, byte[] Data, ReadWriteParsedData parsed_data)
        {
            if (parsed_data == null ||
                readerClient == null) return false;

            flag_cmd_write.Value = false;
            readerClient.MsgBaseWrite(password, membank, wordaddr, wordcnt, Data);
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_write));
            await task;

            parsed_data.waitFlagStatus = task.Result;
            if (task.Result != ErrorCode.OK || readerStatusCode != (int)ErrorCode.OK)
                return false;


            //Read out parsed data
            uint index = 0;

            //TagCount
            uint tagCount = BitConverter.ToUInt16(readerReadBuffer.Take(2).Reverse().ToArray());
            parsed_data.TagCount = tagCount;
            index += 2;

            //RawData len
            byte dataLen = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.DataLen = dataLen;
            index++;

            //PC
            uint PC = BitConverter.ToUInt16(readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.PC = PC;
            index += 2;

            //Figure out how long the EPC length is from PC
            uint lenEPC = (PC >> 11) * 2; //This is number of words, we want this in bytes
            parsed_data.LenEPC = lenEPC;

            byte[] EPC = readerReadBuffer.Skip((int)index).Take((int)lenEPC).ToArray();

            if (parsed_data.RawEPC == null)
                parsed_data.RawEPC = new byte[lenEPC];

            Array.Copy(EPC, 0, parsed_data.RawEPC, 0, lenEPC);
            index += lenEPC;

            string strEPC = ByteArrayToHexString(EPC);
            parsed_data.StringEPC = strEPC;

            //CRC
            uint CRC = BitConverter.ToUInt16(readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.CRC = CRC;
            index += 2;

            int errCode = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.ErrCode = errCode;
            index++;

            int antID = readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.AntID = antID;
            index++;

            return true;
        }
    }
}
