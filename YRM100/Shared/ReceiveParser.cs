using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace YRM100.Shared
{
    public class ReceiveParser
    {
        private static bool frameBeginFlag = false;
        private static bool frameEndFlag = true;
        private static long frameLength;
        private static long strNum;
        private static string[] strBuff = new string[4096];
        private ModuleType device_mt;

        /// <summary>
        /// When a valid Packet Got, this event will be sent
        /// </summary>
        public event EventHandler<StrArrEventArgs> PacketReceived;

        public ReceiveParser(ModuleType mt)
        {
            device_mt = mt;
        }

        /// <summary>
        /// Try to Parse a Valid Packet from Serial Port Received Data
        /// It Will Send PacketReceived event When Got a Packet.
        /// </summary>
        /// <param name="sender">usually is a SerialPort.DataReceived</param>
        /// <param name="e">SerialDataReceivedEventArgs</param>
        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Sp.GetInstance().Closing || !Sp.GetInstance().IsOpen())
            {
                return;
            }

            string frame_start = "AA";
            string frame_end = "DD";
            if (device_mt == ModuleType.YRM100)
            {
                frame_start = "BB";
                frame_end = "7E";
            }

            int n = Sp.GetInstance().ComDevice.BytesToRead;
            try
            {
                Sp.GetInstance().Listening = true;
                byte[] DataCom = new byte[n];
                Sp.GetInstance().ComDevice.Read(DataCom, 0, n);
                string[] DataRX = new string[DataCom.Length];
                for (int i = 0; i < DataCom.Length; i++)
                {
                    DataRX[i] = DataCom[i].ToString("X2").ToUpper();
                }
                if (n == 0)
                {
                    return;
                }
                for (int j = 0; j < n; j++)
                {
                    if (frameBeginFlag)
                    {
                        strBuff[strNum] = DataRX[j];
                        if (strNum == 4)
                        {
                            frameLength = Convert.ToInt32(strBuff[4], 16);
                            if (frameLength > 3072)
                            {
                                frameBeginFlag = false;
                                continue;
                            }
                        }
                        else if (strNum == frameLength + 6 && strBuff[strNum] == frame_end)
                        {
                            int checksum = 0;
                            for (int i = 1; i < strNum - 1; i++)
                            {
                                checksum += Convert.ToInt32(strBuff[i], 16);
                            }
                            checksum %= 256;
                            if (checksum != Convert.ToInt32(strBuff[strNum - 1], 16))
                            {
                                Console.WriteLine("ERROR FRAME, checksum is not right!");
                                frameBeginFlag = false;
                                frameEndFlag = true;
                                continue;
                            }
                            frameBeginFlag = false;
                            frameEndFlag = true;
                            if (this.PacketReceived != null)
                            {
                                string[] packet = new string[strNum + 1];
                                for (int i = 0; i <= strNum; i++)
                                {
                                    packet[i] = strBuff[i];
                                }
                                this.PacketReceived(this, new StrArrEventArgs(packet));
                            }
                        }
                        else if (strNum == frameLength + 6 && strBuff[strNum] != frame_end)
                        {
                            Console.WriteLine("ERROR FRAME, cannot get FRAME_END when extends frameLength");
                            frameBeginFlag = false;
                            frameEndFlag = true;
                            continue;
                        }
                        strNum++;
                    }
                    else if (DataRX[j] == frame_start && !frameBeginFlag)
                    {
                        strNum = 0L;
                        strBuff[strNum] = DataRX[j];
                        frameBeginFlag = true;
                        frameEndFlag = false;
                        strNum = 1L;
                    }
                }
            }
            finally
            {
                Sp.GetInstance().Listening = false;
            }
        }
    }
}
