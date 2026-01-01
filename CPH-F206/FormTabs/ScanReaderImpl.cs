using CPH_F206.RfidSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.FormTabs
{
    internal class ScanReaderImpl : RfidReaderRspNotify
    {
        private delegate void OnRecvRspDelegate(byte[] message, int messageLen);

        private ScanWindow scanWin;

        public void SetScanWind(ScanWindow win)
        {
            scanWin = win;
        }

        void RfidReaderRspNotify.OnRecvResetRsp(RfidReader reader, byte result)
        {
            if (scanWin == null)
            {
                return;
            }
            if (scanWin.InvokeRequired)
            {
                scanWin.BeginInvoke((EventHandler)delegate
                {
                    scanWin.OnRecvResetParam();
                });
            }
            else
            {
                scanWin.OnRecvResetParam();
            }
        }

        void RfidReaderRspNotify.OnRecvSetFactorySettingRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvStartInventoryRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvStopInventoryRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvDeviceInfoRsp(RfidReader reader, byte[] firmwareVersion, byte deviceType)
        {
        }

        void RfidReaderRspNotify.OnRecvSetWorkParamRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvQueryWorkParamRsp(RfidReader reader, byte result, RfidWorkParam workParam)
        {
        }

        void RfidReaderRspNotify.OnRecvSetTransmissionParamRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvQueryTransmissionParamRsp(RfidReader reader, byte result, RfidTransmissionParam transmissiomParam)
        {
            if (scanWin == null)
            {
                return;
            }
            if (scanWin.InvokeRequired)
            {
                scanWin.BeginInvoke((EventHandler)delegate
                {
                    scanWin.OnRecvQueryTransferParamRep(transmissiomParam);
                });
            }
            else
            {
                scanWin.OnRecvQueryTransferParamRep(transmissiomParam);
            }
        }

        void RfidReaderRspNotify.OnRecvSetAdvanceParamRsp(RfidReader reader, byte result)
        {
        }

        void RfidReaderRspNotify.OnRecvQueryAdvanceParamRsp(RfidReader reader, byte result, RfidAdvanceParam advanceParam)
        {
        }

        void RfidReaderRspNotify.OnRecvTagNotify(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
        }

        void RfidReaderRspNotify.OnRecvHeartBeats(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
        }

        void RfidReaderRspNotify.OnRecvSettingSingleParam(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQuerySingleParam(RfidReader reader, TlvValueItem item)
        {
            throw new NotImplementedException();
        }

        public void OnRecvWriteTagRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvWriteTagRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvReadBlockRsp(RfidReader reader, byte result, byte[] read_data, byte[] epc_data)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvWriteWiegandNumberRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvLockResult(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        public void OnRecvRecordNotify(RfidReader reader, string time, string tagId)
        {
            throw new NotImplementedException();
        }

        public void OnRecvRecordStatusRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        public void OnRecvSetRtcTimeStatusRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        public void OnRecvQueryRtcTimeRsp(int year, int month, int day, int hour, int min, int sec)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvRecordNotify(RfidReader reader, string time, string tagId)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvRecordStatusRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvSetRtcTimeStatusRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryRtcTimeRsp(int year, int month, int day, int hour, int min, int sec)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryExtParamRsp(RfidReader reader, byte result, RfidExtParam extParam)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvSetExtParam(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvAudioPlayRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvRelayOpRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvVerifyTagRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvSetUsbInfoRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryUsbInfoRsp(RfidReader reader, byte interfaceType, byte usbProto, byte enterflag)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvSetDataFlagRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryDataFlagRsp(RfidReader reader, ushort dataflag, byte dataFormat)
        {
            throw new NotImplementedException();
        }

        public void OnRecvQueryModbusParam(RfidReader reader, byte tagNum, byte unionSize, byte startaddr, byte clearflag, int modbusProto)
        {
            throw new NotImplementedException();
        }

        public void OnRecvSetModbusParamRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        public void OnRecvTagData(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvSetParamRsp(RfidReader reader, byte result)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryWifiConnRsp(RfidReader reader, CWifiConnInfo wifiConn)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryWifiAPInfo(RfidReader reader, CWifiAPInfo wifiAPInfo)
        {
            throw new NotImplementedException();
        }

        void RfidReaderRspNotify.OnRecvQueryWifiStaInfo(RfidReader reader, CWifiStaInfo wifiStaInfo)
        {
            throw new NotImplementedException();
        }

        public void OnRecvQueryUserHttpParam(RfidReader reader, CUserHttpParam param)
        {
            throw new NotImplementedException();
        }

        public void OnRecvQueryUserWifiParam(RfidReader reader, CUserWifi param)
        {
            throw new NotImplementedException();
        }

        public void OnRecvQueryWifiStaStatusInfo(RfidReader reader, CUserWifiIP wifiStaInfo)
        {
            throw new NotImplementedException();
        }
    }
}
