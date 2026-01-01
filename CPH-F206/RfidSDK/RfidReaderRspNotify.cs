using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public interface RfidReaderRspNotify
    {
        void OnRecvResetRsp(RfidReader reader, byte result);

        void OnRecvSetFactorySettingRsp(RfidReader reader, byte result);

        void OnRecvStartInventoryRsp(RfidReader reader, byte result);

        void OnRecvStopInventoryRsp(RfidReader reader, byte result);

        void OnRecvDeviceInfoRsp(RfidReader reader, byte[] firmwareVersion, byte deviceType);

        void OnRecvSetWorkParamRsp(RfidReader reader, byte result);

        void OnRecvQueryWorkParamRsp(RfidReader reader, byte result, RfidWorkParam workParam);

        void OnRecvSetTransmissionParamRsp(RfidReader reader, byte result);

        void OnRecvQueryTransmissionParamRsp(RfidReader reader, byte result, RfidTransmissionParam transmissiomParam);

        void OnRecvSetAdvanceParamRsp(RfidReader reader, byte result);

        void OnRecvQueryAdvanceParamRsp(RfidReader reader, byte result, RfidAdvanceParam advanceParam);

        void OnRecvTagNotify(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount);

        void OnRecvHeartBeats(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount);

        void OnRecvSettingSingleParam(RfidReader reader, byte result);

        void OnRecvQuerySingleParam(RfidReader reader, TlvValueItem item);

        void OnRecvWriteTagRsp(RfidReader reader, byte result);

        void OnRecvRecordNotify(RfidReader reader, string time, string tagId);

        void OnRecvRecordStatusRsp(RfidReader reader, byte result);

        void OnRecvSetRtcTimeStatusRsp(RfidReader reader, byte result);

        void OnRecvQueryRtcTimeRsp(int year, int month, int day, int hour, int min, int sec);

        void OnRecvReadBlockRsp(RfidReader reader, byte result, byte[] read_data, byte[] epc_data);

        void OnRecvWriteWiegandNumberRsp(RfidReader reader, byte result);

        void OnRecvLockResult(RfidReader reader, byte result);

        void OnRecvQueryExtParamRsp(RfidReader reader, byte result, RfidExtParam extParam);

        void OnRecvSetExtParam(RfidReader reader, byte result);

        void OnRecvAudioPlayRsp(RfidReader reader, byte result);

        void OnRecvRelayOpRsp(RfidReader reader, byte result);

        void OnRecvVerifyTagRsp(RfidReader reader, byte result);

        void OnRecvSetUsbInfoRsp(RfidReader reader, byte result);

        void OnRecvQueryUsbInfoRsp(RfidReader reader, byte interfaceType, byte usbProto, byte enterflag);

        void OnRecvSetDataFlagRsp(RfidReader reader, byte result);

        void OnRecvQueryDataFlagRsp(RfidReader reader, ushort dataflag, byte dataformat);

        void OnRecvQueryModbusParam(RfidReader reader, byte tagNum, byte unionSize, byte startaddr, byte clearflag, int modbusProto);

        void OnRecvSetModbusParamRsp(RfidReader reader, byte result);

        void OnRecvTagData(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount);

        void OnRecvSetParamRsp(RfidReader reader, byte result);

        void OnRecvQueryWifiConnRsp(RfidReader reader, CWifiConnInfo wifiConn);

        void OnRecvQueryWifiAPInfo(RfidReader reader, CWifiAPInfo wifiAPInfo);

        void OnRecvQueryWifiStaInfo(RfidReader reader, CWifiStaInfo wifiStaInfo);

        void OnRecvQueryUserHttpParam(RfidReader reader, CUserHttpParam param);

        void OnRecvQueryUserWifiParam(RfidReader reader, CUserWifi param);

        void OnRecvQueryWifiStaStatusInfo(RfidReader reader, CUserWifiIP wifiStaInfo);
    }
}
