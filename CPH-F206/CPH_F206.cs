using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206
{
    public enum Connect_Status
    {
        Status_Idl,
        Status_Connecting,
        Status_Connected
    }

    public enum MessageType
    {
        Normal,
        Error
    }
    public enum ReaderParamID
    {
        WifiConnection = 48,
        WifiAPinfo = 50,
        WifiStaInfo = 51,
        WifiHCRecv = 54,
        WifiHCConn = 55,
        WifiHCIP = 56
    }

    public enum TransportType
    {
        SerialPort,
        UDP,
        TcpClient,
        TcpServerClient,
        USB_HID
    }
    public enum EnRecvStage
    {
        EN_STAGE_IDLE,
        EN_STAGE_RECEIVE_HEAD,
        EN_STAGE_DATA,
        EN_STAGE_PARAM_LEN,
        EN_STAGE_PARAM_DATA,
        EN_STAGE_PARAM_CHECKSUM,
        EN_STAGE_COMPLETED
    }

    internal enum Frame_Code
    {
        FRAME_CODE_RESET = 16,
        FRAME_CODE_SET_DEFAULT_PARAM = 18,
        FRAME_CODE_START_INVENTORY = 33,
        FRAME_CODE_INVENTORY_ONCE = 34,
        FRAME_CODE_STOP_INVENTORY = 35,
        FRAME_CODE_GET_DATA = 36,
        FRAME_CODE_WRITE_TAG = 48,
        FRAME_CODE_READ_BLOCK = 49,
        FRAME_CODE_WRITE_WIEGAND_NUMBER = 50,
        FRAME_CODE_LOCK_TAG = 51,
        FRAME_CODE_WRITE_EPC = 53,
        FRAME_CODE_QUERY_EXT_PARAM = 62,
        FRAME_CODE_SET_EXT_PARAM = 63,
        FRAME_CODE_QUERY_DEVICE_INFO = 64,
        FRAME_CODE_SET_WORKING_PARAM = 65,
        FRAME_CODE_QUERY_WORKING_PARAM = 66,
        FRAME_CODE_QUERY_TRANSPORT_PARAM = 67,
        FRAME_CODE_SET_TRANSPORT_PARAM = 68,
        FRAME_CODE_QUERY_ADVANCE_PARAM = 69,
        FRAME_CODE_SET_ADVANCE_PARAM = 70,
        FRAME_CODE_SET_SIGNLE_PARAM = 72,
        FRAME_CODE_QUERY_SINGLE_PARAM = 73,
        FRAME_CODE_QUERY_RTC_TIME = 74,
        FRAME_CODE_SET_RTC_TIME = 75,
        FRAME_CODE_RELAY_OP = 76,
        FRAME_CODE_AUDIO_PLAY = 77,
        FRAME_CODE_VERIFY_TAG = 78,
        EN_FRAME_CODE_SET_USB_DATA = 80,
        EN_FRAME_CODE_QUERY_USB_DATA = 81,
        EN_FRAME_CODE_SET_DATA_FLAG = 82,
        EN_FRAME_CODE_QUERY_DATA_FLAG = 83,
        EN_FRAME_CODE_SET_MODBUS_PARAM = 84,
        EN_FRAME_CODE_QUERY_MODBUS_PARAM = 85,
        FRAME_CODE_UPLOAD_RECORD_STATUS = 114,
        FRAME_CODE_SET_PARAM = 117,
        FRAME_CODE_QUERY_PARAM = 118,
        FRAME_CODE_NOTIFY_TAG = 128,
        FRAME_CODE_PREPARE_UPDATE = 244
    }
}
