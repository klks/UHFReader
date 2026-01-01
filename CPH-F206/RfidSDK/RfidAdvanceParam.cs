using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class RfidAdvanceParam
    {
        public byte ucDevType;

        public byte ucRegion;

        public byte ucChannelIndex;

        public byte ucFreqHoppingFlag;

        public byte ucCWFlag;

        public byte sel_flag;

        public byte session;

        public byte target;

        public byte QValue;

        public byte rssiValue;

        public byte freqsLength;

        public byte[] arrFreqs = new byte[64];

        public RfidAdvanceParam()
        {
            freqsLength = 0;
            Array.Clear(arrFreqs, 0, arrFreqs.Length);
        }

        public void SetParamFromMessage(byte[] message, ushort offset, ushort paramLen)
        {
            ushort num = offset;
            ucDevType = message[offset++];
            ucRegion = message[offset++];
            ucChannelIndex = message[offset++];
            ucFreqHoppingFlag = message[offset++];
            ucCWFlag += message[offset++];
            sel_flag = message[offset++];
            session = message[offset++];
            target = message[offset++];
            QValue = message[offset++];
            rssiValue = message[offset++];
            if (offset - num < paramLen)
            {
                freqsLength = message[offset++];
                if (freqsLength > 0 && freqsLength <= 64)
                {
                    Array.Copy(message, offset, arrFreqs, 0, freqsLength);
                    return;
                }
                freqsLength = 0;
                Array.Clear(arrFreqs, 0, arrFreqs.Length);
            }
        }

        public byte[] GetMessageDataFromParam(ref ushort byteMsgLen)
        {
            byte[] array = new byte[256];
            ushort num = 0;
            array[num++] = 0;
            array[num++] = ucRegion;
            array[num++] = ucChannelIndex;
            array[num++] = ucFreqHoppingFlag;
            array[num++] = ucCWFlag;
            array[num++] = sel_flag;
            array[num++] = session;
            array[num++] = target;
            array[num++] = QValue;
            array[num++] = rssiValue;
            array[num++] = freqsLength;
            if (freqsLength > 0 && freqsLength <= 64)
            {
                Array.Copy(arrFreqs, 0, array, num, freqsLength);
                num += freqsLength;
            }
            else
            {
                num = num;
            }
            byteMsgLen = num;
            return array;
        }
    }
}
