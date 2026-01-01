using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class RfidExtParam
    {
        public byte ucRelayMode;

        public byte ucRelayTime;

        public byte ucVerifyFlag;

        public ushort usVerifyPwd;

        public RfidExtParam()
        {
            ucRelayMode = 0;
            ucRelayTime = 0;
            ucVerifyFlag = 0;
            usVerifyPwd = 0;
        }

        public void SetParamFromMessage(byte[] array, int offset)
        {
            int num = offset;
            ucRelayMode = array[num++];
            ucRelayTime = array[num++];
            ucVerifyFlag = array[num++];
            usVerifyPwd = array[num++];
            usVerifyPwd <<= 8;
            usVerifyPwd += array[num++];
        }

        public byte[] GetMessageDataFromParam()
        {
            int num = 0;
            byte[] array = new byte[5];
            array[num++] = ucRelayMode;
            array[num++] = ucRelayTime;
            array[num++] = ucVerifyFlag;
            array[num++] = (byte)((uint)(usVerifyPwd >> 8) & 0xFFu);
            array[num++] = (byte)(usVerifyPwd & 0xFFu);
            return array;
        }
    }
}
