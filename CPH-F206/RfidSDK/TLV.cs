using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal enum Tlv_Attr_Code
    {
        TLV_ATTR_CODE_IDLE = 0,
        TLV_ATTR_CODE_EPC = 1,
        TLV_ATTR_CODE_USER = 2,
        TLV_ATTR_CODE_RESERVE = 3,
        TLV_ATTR_CODE_TID = 4,
        TLV_ATTR_CODE_RSSI = 5,
        TLV_ATTR_CODE_FLUSH_NOW_TIME = 6,
        TLV_ATTR_CODE_STATUS = 7,
        TLV_ATTR_TAG_OPERATION_INFO = 8,
        TLV_ATTR_ANT_NO = 10,
        TLV_ATTR_CODE_TAG_6B = 16,
        TLV_ATTR_FIRMWARE_VERSION = 32,
        TLV_ATTR_DEVICE_TYPE = 33,
        TLV_ATTR_WORKING_PARAM = 35,
        TLV_ATTR_TRANSPORT_PARAM = 36,
        TLV_ATTR_ADVANCE_PARAM = 37,
        TLV_ATTR_SIGNLE_PARAM = 38,
        TLV_ATTR_RELAY = 39,
        TLV_ATTR_AUIDO_TEXT = 40,
        TLV_ATTR_EXT_PARAM = 41,
        TLV_ATTR_CODE_SINGLE_TAG_DATA = 80,
        TLV_ATTR_CODE_DEVICE_NO = 82,
        TLV_ATTR_CODE_TEMPETURE = 112,
        TLV_ATTR_CODE_USER_SN = 240
    }

    public class TlvValueItem
    {
        public byte _tlvType { get; set; }
        public byte _tlvLen { get; set; }
        public byte[] _tlvValue { get; set; }
        public string GetValueString()
        {
            string text = "";
            int num = 0;
            for (num = 0; num < _tlvLen; num++)
            {
                text += $"{_tlvValue[num]:X2} ";
            }
            return text;
        }
    }
}
