using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class RfidWorkParam
    {
        public byte ucParamVersion;

        public byte ucRFPower;

        public byte ucScanInterval;

        public byte ucAutoTrigoffTime;

        public byte ucWorkMode;

        public byte ucInventoryArea;

        public byte ucInventoryAddress;

        public byte ucInventoryLength;

        public byte ucFilterTime;

        public byte ucBeepOnFlag;

        public byte ucIsEnableRecord;

        public ushort usAntennaFlag;

        public ushort usDeviceAddr;

        public void SetParamFromMessage(byte[] message, int offset)
        {
            ucParamVersion = message[offset++];
            ucRFPower = message[offset++];
            ucScanInterval = message[offset++];
            ucWorkMode = message[offset++];
            ucInventoryArea = message[offset++];
            ucInventoryAddress = message[offset++];
            ucInventoryLength = message[offset++];
            ucFilterTime = message[offset++];
            usDeviceAddr = message[offset++];
            usDeviceAddr <<= 8;
            usDeviceAddr += message[offset++];
            ucBeepOnFlag = message[offset++];
            ucIsEnableRecord = message[offset++];
            ucAutoTrigoffTime = message[offset++];
            usAntennaFlag = message[offset++];
            usAntennaFlag <<= 8;
            usAntennaFlag += message[offset++];
        }

        public byte[] GetMessageDataFromParam()
        {
            byte[] array = new byte[15];
            int num = 0;
            array[num++] = 5;
            array[num++] = ucRFPower;
            array[num++] = ucScanInterval;
            array[num++] = ucWorkMode;
            array[num++] = ucInventoryArea;
            array[num++] = ucInventoryAddress;
            array[num++] = ucInventoryLength;
            array[num++] = ucFilterTime;
            array[num++] = (byte)(usDeviceAddr >> 8);
            array[num++] = (byte)(usDeviceAddr & 0xFFu);
            array[num++] = ucBeepOnFlag;
            array[num++] = ucIsEnableRecord;
            array[num++] = ucAutoTrigoffTime;
            array[num++] = (byte)(usAntennaFlag >> 8);
            array[num++] = (byte)(usAntennaFlag & 0xFFu);
            return array;
        }
    }
}
