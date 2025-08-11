using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCchip.Reader.API;

namespace ES_F3105U
{
    public static class FormSharedData
    {
        //Global variables
        public static UCchipClient? readerClient = null;
        public static ErrorCode status;
        public static int minCooldown = 500;
        public static ResponseParserClass responseParser = new ResponseParserClass();
        public static ListBox? lbResponse = null;
        public static bool Option_Disable_Write_MsgBaseSetAccessEpcMatch = false;
        public static bool bIsInventoryRunning = false;

        public delegate void DelegateSerialPortLog(string message);
        public static DelegateSerialPortLog? SerialPortLog = null;

        public delegate void DelegateAPILog(string message);
        public static DelegateAPILog? APILog = null;

        /// <summary>
        /// Adds a message to the response ListBox with a timestamp.
        /// </summary>
        public static void AddListBoxResponse(string message)
        {
            if (lbResponse != null)
            {
                string time_now = DateTime.Now.ToLongTimeString();
                string fullMsg = $"[{time_now}] {message}";
                lbResponse.Invoke(new MethodInvoker(delegate { lbResponse.Items.Insert(0, fullMsg); }));
            }
        }

        public static async Task<bool> ClearEPCMatchFilter()
        {
            if (FormSharedData.readerClient == null) return false;

            //Clear any filters
            FormSharedData.responseParser.ResetFlag("flag_cmd_set_access_epc_match");
            FormSharedData.readerClient.MsgBaseSetAccessEpcMatch(1, 0, []);
            Task<ErrorCode> task_clear = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_set_access_epc_match"));
            await task_clear;
            if (task_clear.Result != ErrorCode.OK)
                return false;
            FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set = false;
            return true;
        }

        public static async Task<bool> AttemptRead_6C(byte membank, uint wordaddr, ushort wordcnt, uint password, ReadWriteParsedData parsed_data)
        {
            if (parsed_data == null ||
                FormSharedData.readerClient == null) return false;

            FormSharedData.responseParser.ResetFlag("flag_cmd_read");
            FormSharedData.readerClient.MsgBaseRead(membank, wordaddr, wordcnt, password);
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_read"));
            await task;

            parsed_data.waitFlagStatus = task.Result;
            parsed_data.readerStatusCode = FormSharedData.responseParser.readerStatusCode;

            if (task.Result != ErrorCode.OK || FormSharedData.responseParser.readerStatusCode != (int)ErrorCode.OK)
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
            uint tagCount = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Take(2).Reverse().ToArray());
            parsed_data.TagCount = tagCount;
            index += 2;

            //RawData len
            byte dataLen = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.DataLen = dataLen;
            index++;

            //PC
            uint PC = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.PC = PC;
            index += 2;

            //Figure out how long the EPC length is from PC
            uint lenEPC = (PC >> 11) * 2; //This is number of words, we want this in bytes
            parsed_data.LenEPC = lenEPC;

            byte[] EPC = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take((int)lenEPC).ToArray();

            if (parsed_data.RawEPC == null)
                parsed_data.RawEPC = new byte[lenEPC];

            Array.Copy(EPC, 0, parsed_data.RawEPC, 0, lenEPC);
            index += lenEPC;

            string strEPC = Utilities.Utilities.ByteArrayToHexString(EPC);
            parsed_data.StringEPC = strEPC;

            //CRC
            uint CRC = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.CRC = CRC;
            index += 2;

            //Data
            //Calculate how many bytes of data was returned
            uint dataReadLen = (uint)dataLen - 2 - lenEPC - 2;    //DataLen - PC - LenEPC - CRC
            byte[] readBytes = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take((int)dataReadLen).ToArray();

            if (parsed_data.RawData == null)
                parsed_data.RawData = new byte[dataReadLen];
            Array.Copy(readBytes, 0, parsed_data.RawData, 0, dataReadLen);
            parsed_data.StringData = Utilities.Utilities.ByteArrayToHexString(readBytes);
            index += dataReadLen;

            //ReadLen
            uint readLen = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.ReadLen = readLen;
            index += 2;

            int antID = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.AntID = antID;
            index++;

            int readCount = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.ReadCount = readCount;
            index++;

            return true;
        }
        public static async Task<bool> AttemptWrite_6C_Buffer(byte membank, uint accessPwd, uint startAddr, byte[] writeData)
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
                        string parsedReturn = FormSharedData.responseParser.GetErrorCodeString((byte)result.ErrCode);
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
                if (td.Milliseconds < FormSharedData.minCooldown)
                {
                    Thread.Sleep(FormSharedData.minCooldown - td.Milliseconds);
                }
            }
            return true;
        }

        public static async Task<bool> AttemptWrite_6C(byte membank, uint wordaddr, ushort wordcnt, uint password, byte[] Data, ReadWriteParsedData parsed_data)
        {
            if (parsed_data == null ||
                FormSharedData.readerClient == null) return false;

            FormSharedData.responseParser.ResetFlag("flag_cmd_write");
            FormSharedData.readerClient.MsgBaseWrite(password, membank, wordaddr, wordcnt, Data);
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_write"));
            await task;

            parsed_data.waitFlagStatus = task.Result;
            if (task.Result != ErrorCode.OK || FormSharedData.responseParser.readerStatusCode != (int)ErrorCode.OK)
                return false;


            //Read out parsed data
            uint index = 0;

            //TagCount
            uint tagCount = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Take(2).Reverse().ToArray());
            parsed_data.TagCount = tagCount;
            index += 2;

            //RawData len
            byte dataLen = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.DataLen = dataLen;
            index++;

            //PC
            uint PC = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.PC = PC;
            index += 2;

            //Figure out how long the EPC length is from PC
            uint lenEPC = (PC >> 11) * 2; //This is number of words, we want this in bytes
            parsed_data.LenEPC = lenEPC;

            byte[] EPC = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take((int)lenEPC).ToArray();

            if (parsed_data.RawEPC == null)
                parsed_data.RawEPC = new byte[lenEPC];

            Array.Copy(EPC, 0, parsed_data.RawEPC, 0, lenEPC);
            index += lenEPC;

            string strEPC = Utilities.Utilities.ByteArrayToHexString(EPC);
            parsed_data.StringEPC = strEPC;

            //CRC
            uint CRC = BitConverter.ToUInt16(FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(2).Reverse().ToArray());
            parsed_data.CRC = CRC;
            index += 2;

            int errCode = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.ErrCode = errCode;
            index++;

            int antID = FormSharedData.responseParser.readerReadBuffer.Skip((int)index).Take(1).ToArray()[0];
            parsed_data.AntID = antID;
            index++;

            return true;
        }
    }
}
