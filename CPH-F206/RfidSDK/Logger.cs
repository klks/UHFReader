using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CPH_F206.RfidSDK
{
    internal class Logger
    {
        private enum CPHCode
        {
            ECPH_RESET = 16,
            ECPH_DEFAULT_PARAM = 18,
            ECPH_START_INVENTORY = 33,
            ECPH_INVENTORY_ONCE = 34,
            ECPH_STOP_INVENTORY = 35,
            ECPH_GET_DATA = 36,
            ECPH_WRITE_TAG = 48,
            ECPH_READ_BLOCK = 49,
            ECPH_WRITE_WIEGAND_NUMBER = 50,
            ECPH_LOCK_TAG = 51,
            ECPH_WRITE_EPC = 53,
            ECPH_QUERY_EXT_PARAM = 62,
            ECPH_SET_EXT_PARAM = 63,
            ECPH_QUERY_DEVICE_INFO = 64,
            ECPH_SET_WORKING_PARAM = 65,
            ECPH_QUERY_WORKING_PARAM = 66,
            ECPH_QUERY_TRANSPORT_PARAM = 67,
            ECPH_SET_TRANSPORT_PARAM = 68,
            ECPH_QUERY_ADVANCE_PARAM = 69,
            ECPH_SET_ADVANCE_PARAM = 70,
            ECPH_SET_SIGNLE_PARAM = 72,
            ECPH_QUERY_SINGLE_PARAM = 73,
            ECPH_QUERY_RTC_TIME = 74,
            ECPH_SET_RTC_TIME = 75,
            ECPH_RELAY_OP = 76,
            ECPH_AUDIO_PLAY = 77,
            ECPH_VERIFY_TAG = 78,
            ECPH_SET_USB_DATA = 80,
            ECPH_QUERY_USB_DATA = 81,
            ECPH_SET_DATA_FLAG = 82,
            ECPH_QUERY_DATA_FLAG = 83,
            ECPH_SET_MODBUS_PARAM = 84,
            ECPH_QUERY_MODBUS_PARAM = 85,
            ECPH_UPLOAD_RECORD_STATUS = 114,
            ECPH_NOTIFY_TAG = 128,
            ECPH_PREPARE_UPDATE = 244
        }

        private static ILog log;

        static Logger()
        {
            log = LogManager.GetLogger("DefaultLog");
        }

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Debug(string message)
        {
            log.Debug(message);
        }

        public static void LogHex(string strPort, byte[] datas, int offset, int length)
        {
            string text = "[" + DateTime.Now.ToString("HH:mm:ss") + "]:";
            int num = 0;
            if (strPort.Trim().Length > 0)
            {
                text = text + strPort + " ";
            }
            for (num = 0; num < length; num++)
            {
                text = text + datas[offset + num].ToString("X2") + " ";
            }
            text += Environment.NewLine;
            log.Debug(text);
        }

        public static void LogCPH(string strPort, byte[] datas, int offset, int length)
        {
            string text = "Unresolved";
            if (datas[2] <= 1)
            {
                switch (datas[5])
                {
                    case 16:
                        text = "Restart";
                        break;
                    case 18:
                        text = "Factory reset";
                        break;
                    case 33:
                        text = "Start searching";
                        break;
                    case 34:
                        text = "Search once";
                        break;
                    case 35:
                        text = "Stop searching";
                        break;
                    case 36:
                        text = "Get tag data";
                        break;
                    case 48:
                        text = "Write tags";
                        break;
                    case 49:
                        text = "Tag reading module";
                        break;
                    case 50:
                        text = "Writing Wiegand";
                        break;
                    case 51:
                        text = "Locked tag";
                        break;
                    case 53:
                        text = "Write EPC";
                        break;
                    case 62:
                        text = "Query extended parameters";
                        break;
                    case 63:
                        text = "Set extended parameters";
                        break;
                    case 64:
                        text = "Query device information";
                        break;
                    case 65:
                        text = "Set operating parameters";
                        break;
                    case 66:
                        text = "Query working parameters";
                        break;
                    case 67:
                        text = "Query transmission parameters";
                        break;
                    case 68:
                        text = "Set transmission parameters";
                        break;
                    case 69:
                        text = "Query advanced parameters";
                        break;
                    case 70:
                        text = "Set advanced parameters";
                        break;
                    case 72:
                        text = "Set a single parameter";
                        break;
                    case 73:
                        text = "Query a single parameter";
                        break;
                    case 74:
                        text = "Query RTC time";
                        break;
                    case 75:
                        text = "Set RTC time";
                        break;
                    case 76:
                        text = "Relay operation";
                        break;
                    case 77:
                        text = "Audio playback";
                        break;
                    case 78:
                        text = "Verification Label";
                        break;
                    case 80:
                        text = "Set USB parameters";
                        break;
                    case 81:
                        text = "Query USB parameters";
                        break;
                    case 82:
                        text = "Set data flags";
                        break;
                    case 83:
                        text = "Query data flags";
                        break;
                    case 84:
                        text = "Set Modbus parameters";
                        break;
                    case 85:
                        text = "Query Modbus parameters";
                        break;
                    case 114:
                        text = "Upload record data status";
                        break;
                    case 128:
                        text = "Upload record tags";
                        break;
                    case 244:
                        text = "Upgrade handshake";
                        break;
                }
            }
            else if (datas[2] == 2)
            {
                switch (datas[5])
                {
                    case 128:
                        text = "Upload tag data";
                        break;
                    case 129:
                        text = "Upload tag data 2";
                        break;
                    case 130:
                        text = "Upload tag data 3";
                        break;
                    case 144:
                        text = "Heartbeat Pack";
                        break;
                }
            }
            string text2 = "[" + DateTime.Now.ToString("HH:mm:ss") + "][" + text + "]:";
            int num = 0;
            if (strPort.Trim().Length > 0)
            {
                text2 = text2 + strPort + " ";
            }
            for (num = 0; num < length; num++)
            {
                text2 = text2 + datas[offset + num].ToString("X2") + " ";
            }
            log.Info(text2);
        }

        public static void LogStr(string strPort, byte[] datas, int offset, int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (strPort.Trim().Length > 0)
            {
                stringBuilder.Append(strPort + " ");
            }
            stringBuilder.Append(Encoding.ASCII.GetString(datas, 0, length));
            log.Info(stringBuilder.ToString());
        }
    }
}
