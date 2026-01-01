using System.Text;

namespace CPH_F206.RfidSDK
{
    

    public abstract class RfidReader
    {
        protected Transport transport;

        public abstract void OnRecvCompleted(byte[] messageData, int messageLen);
        public abstract void HandleRecvData();

        public void SetSerialParam(string serialPortName, int baudRate)
        {
            transport.SetSerialPortParam(serialPortName, baudRate);
        }

        public void SetEthernetParam(string localIP, ushort localPort, string remoteIP, ushort remotePort, TransportType type)
        {
            transport.SetIPParam(localIP, localPort, remoteIP, remotePort, type);
        }

        public bool RequestResource()
        {
            return transport.RequestResource();
        }

        public void ReleaseResource()
        {
            transport.ReleaseResource();
        }

        protected void FillCmdHeader(byte[] buff, byte frameCode)
        {
            int num = 0;
            buff[num++] = 82;
            buff[num++] = 70;
            buff[num++] = 0;
            buff[num++] = 0;
            buff[num++] = 0;
            buff[num++] = frameCode;
        }

        protected byte CaculateCheckSum(byte[] recv_buff, int recv_len)
        {
            byte b = 0;
            for (int i = 0; i < recv_len; i++)
            {
                b += recv_buff[i];
            }
            return (byte)(~b + 1);
        }

        public void QueryDeviceInfo()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 64);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void StartInventory()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 33);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void StopInventory()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 35);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryWorkingParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 66);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetDefaultParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 18);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void InventoryOnce()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 34);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void GetEpcData()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 36);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void ResetReader()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 16);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetWorkingParam(RfidWorkParam workParam)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            byte[] messageDataFromParam = workParam.GetMessageDataFromParam();
            FillCmdHeader(array, 65);
            array[num++] = (byte)(messageDataFromParam.Length >> 8);
            array[num++] = (byte)(messageDataFromParam.Length + 2);
            array[num++] = 35;
            array[num++] = (byte)messageDataFromParam.Length;
            for (int i = 0; i < messageDataFromParam.Length; i++)
            {
                array[num++] = messageDataFromParam[i];
            }
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryTransferParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 67);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetTransferParam(RfidTransmissionParam transParam)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            byte[] messageDataFromParam = transParam.GetMessageDataFromParam();
            FillCmdHeader(array, 68);
            array[num++] = (byte)(messageDataFromParam.Length >> 8);
            array[num++] = (byte)(messageDataFromParam.Length + 2);
            array[num++] = 36;
            array[num++] = (byte)messageDataFromParam.Length;
            for (int i = 0; i < messageDataFromParam.Length; i++)
            {
                array[num++] = messageDataFromParam[i];
            }
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryAdvanceParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 69);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryExtParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 62);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetExtParam(RfidExtParam extParam)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            byte[] messageDataFromParam = extParam.GetMessageDataFromParam();
            FillCmdHeader(array, 63);
            array[num++] = (byte)(messageDataFromParam.Length >> 8);
            array[num++] = (byte)(messageDataFromParam.Length + 2);
            array[num++] = 41;
            array[num++] = (byte)messageDataFromParam.Length;
            for (int i = 0; i < messageDataFromParam.Length; i++)
            {
                array[num++] = messageDataFromParam[i];
            }
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetAdvanceParam(RfidAdvanceParam advanceParam)
        {
            int num = 6;
            byte b = 0;
            ushort byteMsgLen = 0;
            byte[] array = new byte[512];
            byte[] messageDataFromParam = advanceParam.GetMessageDataFromParam(ref byteMsgLen);
            FillCmdHeader(array, 70);
            array[num++] = (byte)(byteMsgLen >> 8);
            array[num++] = (byte)(byteMsgLen + 2);
            array[num++] = 37;
            array[num++] = (byte)byteMsgLen;
            for (int i = 0; i < byteMsgLen; i++)
            {
                array[num++] = messageDataFromParam[i];
            }
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetSingleParam(byte parameterType, byte[] parameterValue)
        {
            if (parameterValue != null)
            {
                _ = parameterValue.Length;
                int num = 6;
                byte b = 0;
                byte[] array = new byte[64];
                FillCmdHeader(array, 72);
                array[num++] = 0;
                array[num++] = 0;
                array[num++] = 38;
                array[num++] = (byte)(1 + parameterValue.Length);
                array[num++] = parameterType;
                for (int i = 0; i < parameterValue.Length; i++)
                {
                    array[num++] = parameterValue[i];
                }
                array[7] = (byte)(num - 8);
                b = CaculateCheckSum(array, num);
                array[num++] = b;
                transport.SendData(array, 0, num);
            }
        }

        public void SetUsbInfo(byte interfaceType, byte usbProto, byte enterFlag)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            byte[] array2 = new byte[2];
            FillCmdHeader(array, 80);
            array[num++] = (byte)(array2.Length >> 8);
            array[num++] = (byte)array2.Length;
            array[num++] = interfaceType;
            array[num++] = usbProto;
            array[num++] = enterFlag;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryUsbInfoParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 81);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QUeryDatainfoFlag()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 83);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetDataInfoFlag(ushort dataFlag, byte ddataFormat)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            byte[] array2 = new byte[3];
            FillCmdHeader(array, 82);
            array[num++] = (byte)(array2.Length >> 8);
            array[num++] = (byte)((uint)array2.Length & 0xFFu);
            array[num++] = (byte)(dataFlag >> 8);
            array[num++] = (byte)(dataFlag & 0xFFu);
            array[num++] = ddataFormat;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QuerySingleParam(byte parameterType)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 73);
            array[num++] = 0;
            array[num++] = 3;
            array[num++] = 38;
            array[num++] = 1;
            array[num++] = parameterType;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void WriteTag(byte membank, ushort startAddress, byte length, byte[] writenContent, byte[] password)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            if (length * 2 > writenContent.Length)
            {
                return;
            }
            FillCmdHeader(array, 48);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            array[num++] = (byte)(9 + length * 2);
            if (password == null)
            {
                for (int i = 0; i < 4; i++)
                {
                    array[num++] = 0;
                }
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    array[num++] = password[j];
                }
            }
            array[num++] = 1;
            array[num++] = membank;
            array[num++] = (byte)(startAddress >> 8);
            array[num++] = (byte)(startAddress & 0xFFu);
            array[num++] = length;
            for (int k = 0; k < length * 2; k++)
            {
                array[num++] = writenContent[k];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void WriteEpc(byte membank, ushort startAddress, byte length, byte[] writenContent, byte[] password)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            if (length * 2 > writenContent.Length)
            {
                return;
            }
            FillCmdHeader(array, 53);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            array[num++] = (byte)(9 + length * 2);
            if (password == null)
            {
                for (int i = 0; i < 4; i++)
                {
                    array[num++] = 0;
                }
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    array[num++] = password[j];
                }
            }
            array[num++] = 1;
            array[num++] = membank;
            array[num++] = (byte)(startAddress >> 8);
            array[num++] = (byte)(startAddress & 0xFFu);
            array[num++] = length;
            for (int k = 0; k < length * 2; k++)
            {
                array[num++] = writenContent[k];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void UploadRecord()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 114);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryTime()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[16];
            FillCmdHeader(array, 74);
            array[num++] = 0;
            array[num++] = 0;
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetTime(int year, int month, int day, int hour, int min, int sec)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[32];
            FillCmdHeader(array, 75);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 6;
            array[num++] = 7;
            array[num++] = (byte)(year >> 8);
            array[num++] = (byte)((uint)year & 0xFFu);
            array[num++] = (byte)month;
            array[num++] = (byte)day;
            array[num++] = (byte)hour;
            array[num++] = (byte)min;
            array[num++] = (byte)sec;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void WiegandWriteTag(uint wiegand_number, byte[] password)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            byte[] array2 = new byte[4];
            byte b2 = 2;
            FillCmdHeader(array, 50);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            array[num++] = (byte)(8 + b2 * 2);
            if (password == null)
            {
                for (int i = 0; i < 4; i++)
                {
                    array[num++] = 0;
                }
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    array[num++] = password[j];
                }
            }
            array2[0] = (byte)(wiegand_number >> 24);
            array2[1] = (byte)(wiegand_number >> 16);
            array2[2] = (byte)(wiegand_number >> 8);
            array2[3] = (byte)(wiegand_number & 0xFFu);
            array[num++] = 1;
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = b2;
            for (int k = 0; k < b2 * 2; k++)
            {
                array[num++] = array2[k];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void ReadTag(byte membank, ushort startAddress, byte length, byte[] password)
        {
            int num = 6;
            byte b = 0;
            int num2 = 0;
            byte[] array = new byte[128];
            FillCmdHeader(array, 49);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            num2 = num;
            array[num++] = 0;
            for (int i = 0; i < 4; i++)
            {
                array[num++] = password[i];
            }
            array[num++] = 0;
            array[num++] = membank;
            array[num++] = (byte)(startAddress >> 8);
            array[num++] = (byte)(startAddress & 0xFFu);
            array[num++] = length;
            array[num2] = (byte)(num - 10);
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void LockTag(byte membank, byte[] password)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            FillCmdHeader(array, 51);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            array[num++] = 9;
            for (int i = 0; i < 4; i++)
            {
                array[num++] = password[i];
            }
            array[num++] = 2;
            array[num++] = membank;
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 0;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void KillTag(byte[] password, byte[] killpassword)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[128];
            FillCmdHeader(array, 52);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 8;
            array[num++] = 8;
            for (int i = 0; i < 4; i++)
            {
                array[num++] = password[i];
            }
            array[num++] = 3;
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = killpassword[0];
            array[num++] = killpassword[1];
            array[num++] = killpassword[2];
            array[num++] = killpassword[3];
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void AudioPlay(string audio_text)
        {
            int num = 6;
            int num2 = 0;
            byte b = 0;
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(audio_text);
            byte[] array = new byte[128];
            FillCmdHeader(array, 77);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 40;
            array[num++] = (byte)(bytes.Length + 1);
            array[num++] = 1;
            for (num2 = 0; num2 < bytes.Length; num2++)
            {
                array[num++] = bytes[num2];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void AudioSetOfflineContext(string audio_text)
        {
            int num = 6;
            int num2 = 0;
            byte b = 0;
            byte[] bytes = Encoding.GetEncoding("GBK").GetBytes(audio_text);
            byte[] array = new byte[128];
            FillCmdHeader(array, 77);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 40;
            array[num++] = (byte)(bytes.Length + 1);
            array[num++] = 2;
            for (num2 = 0; num2 < bytes.Length; num2++)
            {
                array[num++] = bytes[num2];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void RelayOperation(byte relay_no, byte op_type, byte op_time)
        {
            int num = 6;
            int num2 = 0;
            byte b = 0;
            byte[] array = new byte[128];
            FillCmdHeader(array, 76);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 39;
            num2 = num;
            array[num++] = 0;
            if ((relay_no & (true ? 1u : 0u)) != 0)
            {
                array[num++] = 1;
                array[num++] = op_type;
                array[num++] = op_time;
            }
            if ((relay_no & 2u) != 0)
            {
                array[num++] = 2;
                array[num++] = op_type;
                array[num++] = op_time;
            }
            array[num2] = (byte)(num - num2 - 1);
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void AddVerifyToTag()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 78);
            array[num++] = 0;
            array[num++] = 0;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryModebusParam()
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 85);
            array[num++] = 0;
            array[num++] = 0;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void SetModbusParam(byte tagNum, byte unionsize, byte startAddr, byte clearFlag, byte modbusproto)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 84);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = tagNum;
            array[num++] = unionsize;
            array[num++] = startAddr;
            array[num++] = clearFlag;
            array[num++] = modbusproto;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void QueryParam(ReaderParamID paramId)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 118);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = (byte)paramId;
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void setWifiConn(CWifiConnInfo wifiInfo)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 48;
            array[num++] = wifiInfo.protocolRole;
            array[num++] = (byte)(wifiInfo.port >> 8);
            array[num++] = (byte)(wifiInfo.port & 0xFFu);
            array[num++] = (byte)(wifiInfo.localPort >> 8);
            array[num++] = (byte)(wifiInfo.localPort & 0xFFu);
            if (wifiInfo.ipMode == 0)
            {
                array[num++] = wifiInfo.ipMode;
                array[num++] = 1;
                array[num++] = 4;
                Array.Copy(wifiInfo.ipAddr, 0, array, num, 4);
                num += 4;
            }
            else
            {
                array[num++] = wifiInfo.ipMode;
                array[num++] = 1;
                array[num++] = 16;
                Array.Copy(wifiInfo.ipAddr, 0, array, num, 16);
                num += 16;
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void setWifiAP(CWifiAPInfo wifiAPInfo)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 50;
            array[num++] = wifiAPInfo.bEnable ? (byte)1 : (byte)0;
            array[num++] = wifiAPInfo.channelid;
            array[num++] = wifiAPInfo.encryptType;
            array[num++] = 1;
            byte[] bytes = Encoding.GetEncoding("ASCII").GetBytes(wifiAPInfo.ssid.Trim());
            array[num++] = (byte)bytes.Length;
            for (int i = 0; i < bytes.Length; i++)
            {
                array[num++] = bytes[i];
            }
            array[num++] = 2;
            byte[] bytes2 = Encoding.GetEncoding("ASCII").GetBytes(wifiAPInfo.password.Trim());
            array[num++] = (byte)bytes2.Length;
            for (int j = 0; j < bytes2.Length; j++)
            {
                array[num++] = bytes2[j];
            }
            for (int k = 0; k < 6; k++)
            {
                b |= wifiAPInfo.baseid[k];
            }
            if (b > 0)
            {
                array[num++] = 3;
                array[num++] = 6;
                for (int l = 0; l < 6; l++)
                {
                    array[num++] = wifiAPInfo.baseid[l];
                }
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void setWifiSta(CWifiStaInfo wifiStaInfo)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[64];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 51;
            if (wifiStaInfo.bEnable)
            {
                array[num++] = 1;
            }
            else
            {
                array[num++] = 0;
            }
            if (wifiStaInfo.dhcpMode == 0)
            {
                array[num++] = 0;
            }
            else
            {
                array[num++] = 1;
            }
            array[num++] = 1;
            byte[] bytes = Encoding.GetEncoding("ASCII").GetBytes(wifiStaInfo.ssid.Trim());
            array[num++] = (byte)bytes.Length;
            for (int i = 0; i < bytes.Length; i++)
            {
                array[num++] = bytes[i];
            }
            array[num++] = 2;
            byte[] bytes2 = Encoding.GetEncoding("ASCII").GetBytes(wifiStaInfo.password.Trim());
            array[num++] = (byte)bytes2.Length;
            for (int j = 0; j < bytes2.Length; j++)
            {
                array[num++] = bytes2[j];
            }
            for (int k = 0; k < 6; k++)
            {
                b |= wifiStaInfo.bassid[k];
            }
            if (b > 0)
            {
                array[num++] = 3;
                array[num++] = 6;
                for (int l = 0; l < 6; l++)
                {
                    array[num++] = wifiStaInfo.bassid[l];
                }
            }
            if (1 == wifiStaInfo.dhcpMode)
            {
                array[num++] = 4;
                array[num++] = 4;
                for (int m = 0; m < 4; m++)
                {
                    array[num++] = wifiStaInfo.ipAddr[m];
                }
                array[num++] = 5;
                array[num++] = 4;
                for (int n = 0; n < 4; n++)
                {
                    array[num++] = wifiStaInfo.netmask[n];
                }
                array[num++] = 6;
                array[num++] = 4;
                for (int num2 = 0; num2 < 4; num2++)
                {
                    array[num++] = wifiStaInfo.gateway[num2];
                }
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void HCWifiQueryHttpParam()
        {
            QueryParam(ReaderParamID.WifiHCRecv);
        }

        public void HCWifiSetHttpParam(CUserHttpParam param)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[512];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 54;
            array[num++] = param.protocolRole;
            array[num++] = (byte)(param.heartbeatInterval >> 8);
            array[num++] = (byte)(param.heartbeatInterval & 0xFFu);
            array[num++] = param.addrType;
            array[num++] = (byte)(param.port >> 8);
            array[num++] = (byte)(param.port & 0xFFu);
            if (param.addr.Trim().Length == 0)
            {
                return;
            }
            if (param.addrType == 0)
            {
                array[num++] = 4;
                string[] array2 = param.addr.Trim().Split('.');
                if (array2.Length != 4)
                {
                    return;
                }
                for (b = 0; b < 4; b++)
                {
                    if (!byte.TryParse(array2[b], out array[num++]))
                    {
                        return;
                    }
                }
            }
            else if (param.addrType == 1)
            {
                array[num++] = 0;
            }
            else if (param.addrType == 2)
            {
                array[num++] = (byte)param.addr.Trim().Length;
                Array.Copy(Encoding.ASCII.GetBytes(param.addr.Trim()), 0, array, num, array[num - 1]);
                num += array[num - 1];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void HCWifiQueryConn()
        {
            QueryParam(ReaderParamID.WifiHCConn);
        }

        public void HCWifiQueryIP()
        {
            QueryParam(ReaderParamID.WifiHCIP);
        }

        public void HCWifiSetConnParam(CUserWifi param)
        {
            int num = 6;
            byte b = 0;
            byte[] array = new byte[512];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 55;
            if (param.apName.Trim().Length == 0)
            {
                array[num++] = 0;
            }
            else
            {
                array[num++] = (byte)param.apName.Trim().Length;
                Array.Copy(Encoding.ASCII.GetBytes(param.apName.Trim()), 0, array, num, array[num - 1]);
                num += array[num - 1];
            }
            if (param.apPwd.Trim().Length == 0)
            {
                array[num++] = 0;
            }
            else
            {
                array[num++] = (byte)param.apPwd.Trim().Length;
                Array.Copy(Encoding.ASCII.GetBytes(param.apPwd.Trim()), 0, array, num, array[num - 1]);
                num += array[num - 1];
            }
            if (param.staName.Trim().Length == 0)
            {
                array[num++] = 0;
            }
            else
            {
                array[num++] = (byte)param.staName.Trim().Length;
                Array.Copy(Encoding.ASCII.GetBytes(param.staName.Trim()), 0, array, num, array[num - 1]);
                num += array[num - 1];
            }
            if (param.staPwd.Trim().Length == 0)
            {
                array[num++] = 0;
            }
            else
            {
                array[num++] = (byte)param.staPwd.Trim().Length;
                Array.Copy(Encoding.ASCII.GetBytes(param.staPwd.Trim()), 0, array, num, array[num - 1]);
                num += array[num - 1];
            }
            array[7] = (byte)(num - 8);
            b = CaculateCheckSum(array, num);
            array[num++] = b;
            transport.SendData(array, 0, num);
        }

        public void HCWifiSetIPParam(CUserWifiIP param)
        {
            int num = 6;
            byte b = 0;
            byte b2 = 0;
            byte[] array = new byte[512];
            FillCmdHeader(array, 117);
            array[num++] = 0;
            array[num++] = 0;
            array[num++] = 56;
            array[num++] = param.dhcpMode;
            array[num++] = 4;
            for (b = 0; b < 4; b++)
            {
                array[num++] = (byte)(param.arrIP[b] & 0xFFu);
            }
            array[num++] = 4;
            for (b = 0; b < 4; b++)
            {
                array[num++] = (byte)(param.arrMask[b] & 0xFFu);
            }
            array[num++] = 4;
            for (b = 0; b < 4; b++)
            {
                array[num++] = (byte)(param.arrGateWay[b] & 0xFFu);
            }
            array[7] = (byte)(num - 8);
            b2 = CaculateCheckSum(array, num);
            array[num++] = b2;
            transport.SendData(array, 0, num);
        }
    }
}
