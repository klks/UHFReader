using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class RfidSerialPort : SerialPort
    {
        private const int recv_buff_size = 1024;

        private const int send_buff_size = 512;

        private byte[] sendBuff;

        private byte[] recvBuff;

        private TimeSpan oldRecvTime;

        private EnRecvStage recvStage;

        private int messageLen;

        private byte temp;

        private int left;

        private RfidReader reader;

        public RfidSerialPort(string serialPortName, int baudRate, RfidReader reader)
            : base(serialPortName, baudRate)
        {
            PortName = serialPortName;
            BaudRate = baudRate;
            StopBits = StopBits.One;
            Parity = Parity.None;
            DataBits = 8;
            recvBuff = new byte[1024];
            sendBuff = new byte[512];
            oldRecvTime = new TimeSpan(DateTime.Now.Ticks);
            recvStage = EnRecvStage.EN_STAGE_IDLE;
            this.reader = reader;
            Close();
        }

        public byte CaculateCheckSum(byte[] recv_buff, int recv_len)
        {
            byte b = 0;
            for (int i = 0; i < recv_len; i++)
            {
                b += recv_buff[i];
            }
            return (byte)(~b + 1);
        }

        public void HandleRecv()
        {
            int num = 0;
            while (BytesToRead > 0)
            {
                switch (recvStage)
                {
                    case EnRecvStage.EN_STAGE_IDLE:
                        messageLen = 0;
                        Array.Clear(recvBuff, 0, 20);
                        temp = (byte)ReadByte();
                        if (temp == 82)
                        {
                            recvBuff[messageLen++] = temp;
                            recvStage = EnRecvStage.EN_STAGE_RECEIVE_HEAD;
                        }
                        break;
                    case EnRecvStage.EN_STAGE_RECEIVE_HEAD:
                        temp = (byte)ReadByte();
                        if (temp == 70)
                        {
                            recvBuff[messageLen++] = temp;
                            recvStage = EnRecvStage.EN_STAGE_DATA;
                            left = 4;
                        }
                        else
                        {
                            recvStage = EnRecvStage.EN_STAGE_IDLE;
                        }
                        break;
                    case EnRecvStage.EN_STAGE_DATA:
                        num = Read(recvBuff, messageLen, left);
                        messageLen += num;
                        if (num >= left)
                        {
                            recvStage = EnRecvStage.EN_STAGE_PARAM_LEN;
                            left = 2;
                        }
                        else
                        {
                            left -= num;
                        }
                        break;
                    case EnRecvStage.EN_STAGE_PARAM_LEN:
                        num = Read(recvBuff, messageLen, left);
                        messageLen += num;
                        if (num >= left)
                        {
                            recvStage = EnRecvStage.EN_STAGE_PARAM_DATA;
                            left = recvBuff[messageLen - 2];
                            left <<= 8;
                            left += recvBuff[messageLen - 1];
                        }
                        else
                        {
                            left -= num;
                        }
                        if (left > 256)
                        {
                            left = 0;
                        }
                        break;
                    case EnRecvStage.EN_STAGE_PARAM_DATA:
                        num = Read(recvBuff, messageLen, left);
                        messageLen += num;
                        if (num >= left)
                        {
                            recvStage = EnRecvStage.EN_STAGE_PARAM_CHECKSUM;
                        }
                        else
                        {
                            left -= num;
                        }
                        break;
                    case EnRecvStage.EN_STAGE_PARAM_CHECKSUM:
                        temp = (byte)ReadByte();
                        recvBuff[messageLen++] = temp;
                        if (temp == CaculateCheckSum(recvBuff, messageLen - 1))
                        {
                            recvStage = EnRecvStage.EN_STAGE_COMPLETED;
                            Logger.LogCPH("SerialPort <== ", recvBuff, 0, messageLen);
                            reader.OnRecvCompleted(recvBuff, messageLen);
                        }
                        recvStage = EnRecvStage.EN_STAGE_IDLE;
                        break;
                }
            }
        }
    }
}
