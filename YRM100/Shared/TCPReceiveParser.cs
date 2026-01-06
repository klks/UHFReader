using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.Shared
{
    public class TCPReceiveParser
    {
        private static bool frameBeginFlag = false;

        private static bool frameEndFlag = true;

        private static long frameLength;

        private static long strNum;

        private static string[] strBuff = new string[4096];

        public event EventHandler<StrArrEventArgs> PacketReceived;

        public void DataReceived(object sender, byteArrEventArgs e)
        {
            if (Sp.GetInstance().Closing || !Sp.GetInstance().IsOpen())
            {
                return;
            }
            int num = e.Data.Length;
            try
            {
                Sp.GetInstance().Listening = true;
                byte[] array = new byte[num];
                Array.Copy(e.Data, array, num);
                string[] array2 = new string[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array2[i] = array[i].ToString("X2").ToUpper();
                }
                if (num == 0)
                {
                    return;
                }
                for (int j = 0; j < num; j++)
                {
                    if (frameBeginFlag)
                    {
                        strBuff[strNum] = array2[j];
                        if (strNum == 4)
                        {
                            frameLength = 256 * Convert.ToInt32(strBuff[3], 16) + Convert.ToInt32(strBuff[4], 16);
                            if (frameLength > 3072)
                            {
                                frameBeginFlag = false;
                                continue;
                            }
                        }
                        else if (strNum == frameLength + 6 && strBuff[strNum] == "7E")
                        {
                            int num2 = 0;
                            for (int k = 1; k < strNum - 1; k++)
                            {
                                num2 += Convert.ToInt32(strBuff[k], 16);
                            }
                            num2 %= 256;
                            if (num2 != Convert.ToInt32(strBuff[strNum - 1], 16))
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
                                string[] array3 = new string[strNum + 1];
                                for (int l = 0; l <= strNum; l++)
                                {
                                    array3[l] = strBuff[l];
                                }
                                this.PacketReceived(this, new StrArrEventArgs(array3));
                            }
                        }
                        else if (strNum == frameLength + 6 && strBuff[strNum] != "7E")
                        {
                            Console.WriteLine("ERROR FRAME, cannot get FRAME_END when extends frameLength");
                            frameBeginFlag = false;
                            frameEndFlag = true;
                            continue;
                        }
                        strNum++;
                    }
                    else if (array2[j] == "BB" && !frameBeginFlag)
                    {
                        strNum = 0L;
                        strBuff[strNum] = array2[j];
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
