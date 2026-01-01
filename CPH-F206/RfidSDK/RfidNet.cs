using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class RfidNet : Socket
    {
        private const int recv_buff_size = 1024;

        private const int send_buff_size = 512;

        private byte[] sendBuff;

        private byte[] recvBuff;

        private TimeSpan oldRecvTime;

        private EnRecvStage recvStage;

        private int messageLen;

        private int left;

        private RfidReader reader;

        public RfidNet(RfidReader reader, AddressFamily addressFamily, SocketType type, ProtocolType protoType)
            : base(addressFamily, type, protoType)
        {
            recvBuff = new byte[1024];
            sendBuff = new byte[512];
            oldRecvTime = new TimeSpan(DateTime.Now.Ticks);
            recvStage = EnRecvStage.EN_STAGE_IDLE;
            this.reader = reader;
        }

        public RfidNet(AddressFamily addressFamily, SocketType type, ProtocolType protoType)
            : base(addressFamily, type, protoType)
        {
            recvBuff = new byte[1024];
            sendBuff = new byte[512];
            oldRecvTime = new TimeSpan(DateTime.Now.Ticks);
            recvStage = EnRecvStage.EN_STAGE_IDLE;
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

        public byte CaculateCheckSum(byte[] recv_buff, int startOffset, int recv_len)
        {
            byte b = 0;
            for (int i = 0; i < recv_len; i++)
            {
                b += recv_buff[i + startOffset];
            }
            return (byte)(~b + 1);
        }

        public void HandleRecv()
        {
            int num = 0;
            while (Poll(200, SelectMode.SelectRead))
            {
                if (ProtocolType == ProtocolType.Udp)
                {
                    messageLen = Receive(recvBuff, 0, 1024, SocketFlags.None);
                    if (recvBuff[messageLen - 1] == CaculateCheckSum(recvBuff, messageLen - 1))
                    {
                        Logger.LogCPH("UDP <== ", recvBuff, 0, messageLen);
                        reader.OnRecvCompleted(recvBuff, messageLen);
                    }
                    return;
                }
                try
                {
                    switch (recvStage)
                    {
                        case EnRecvStage.EN_STAGE_IDLE:
                            messageLen = 0;
                            Receive(recvBuff, messageLen, 1, SocketFlags.None);
                            if (recvBuff[messageLen] == 82)
                            {
                                messageLen++;
                                recvStage = EnRecvStage.EN_STAGE_RECEIVE_HEAD;
                            }
                            break;
                        case EnRecvStage.EN_STAGE_RECEIVE_HEAD:
                            Receive(recvBuff, messageLen, 1, SocketFlags.None);
                            if (recvBuff[messageLen] == 70)
                            {
                                messageLen++;
                                recvStage = EnRecvStage.EN_STAGE_DATA;
                                left = 4;
                            }
                            else
                            {
                                recvStage = EnRecvStage.EN_STAGE_IDLE;
                            }
                            break;
                        case EnRecvStage.EN_STAGE_DATA:
                            num = Receive(recvBuff, messageLen, left, SocketFlags.None);
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
                            num = Receive(recvBuff, messageLen, left, SocketFlags.None);
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
                            if (left > 61440)
                            {
                                left = 0;
                            }
                            break;
                        case EnRecvStage.EN_STAGE_PARAM_DATA:
                            num = Receive(recvBuff, messageLen, left, SocketFlags.None);
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
                            Receive(recvBuff, messageLen, 1, SocketFlags.None);
                            messageLen++;
                            if (recvBuff[messageLen - 1] == CaculateCheckSum(recvBuff, messageLen - 1))
                            {
                                recvStage = EnRecvStage.EN_STAGE_COMPLETED;
                            }
                            else
                            {
                                recvStage = EnRecvStage.EN_STAGE_IDLE;
                            }
                            break;
                    }
                    if (EnRecvStage.EN_STAGE_COMPLETED == recvStage)
                    {
                        Logger.LogCPH("TCP Client <== ", recvBuff, 0, messageLen);
                        reader.OnRecvCompleted(recvBuff, messageLen);
                        recvStage = EnRecvStage.EN_STAGE_IDLE;
                        break;
                    }
                }
                catch (Exception)
                {
                    recvStage = EnRecvStage.EN_STAGE_IDLE;
                }
            }
            num = 0;
        }
    }
}
