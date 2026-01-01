using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class MSerialReader : RfidReader
    {
        private RfidReaderRspNotify _notifyImpl;

        private const int Message_Len_Start_Pos = 6;

        private const int Message_Frame_Code_Pos = 5;

        private const int Message_Attr_Start_Pos = 8;

        public MSerialReader(RfidReaderRspNotify notifyImpl)
        {
            _notifyImpl = notifyImpl;
            transport = new Transport(this);
        }

        private int GetPositionByAttrType(byte[] message, int messageLen, byte attrType)
        {
            int result = -1;
            int num = 0;
            int num2 = 0;
            num = message[6];
            num <<= 8;
            num += message[7];
            for (num2 = 8; num2 < 8 + num; num2 = num2 + message[num2 + 1] + 2)
            {
                if (message[num2] == attrType)
                {
                    result = num2;
                    break;
                }
            }
            return result;
        }

        public void OnRecvInventoryOnce(byte[] message, int messageLen)
        {
            TlvValueItem[] array = new TlvValueItem[6];
            byte b = 0;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num3 = num + num2;
            while (num < num3)
            {
                if (80 == message[num])
                {
                    for (num4 = num + 2; num4 < num + 2 + message[num + 1]; num4 = num4 + message[num4 + 1] + 2)
                    {
                        array[b] = new TlvValueItem();
                        array[b]._tlvType = message[num4];
                        array[b]._tlvLen = message[num4 + 1];
                        array[b]._tlvValue = new byte[message[num4 + 1]];
                        Array.Copy(message, num4 + 2, array[b]._tlvValue, 0, message[num4 + 1]);
                        b++;
                    }
                    _notifyImpl.OnRecvTagNotify(this, array, b);
                    b = 0;
                }
                else if (7 == message[num] && message[num + 2] != 0)
                {
                    _notifyImpl.OnRecvTagNotify(this, null, 0);
                    break;
                }
                num = num + message[num + 1] + 2;
            }
        }

        public void OnRecvGetTagData(byte[] message, int messageLen)
        {
            TlvValueItem[] array = new TlvValueItem[3];
            byte b = 0;
            int num = 0;
            ushort num2 = 0;
            int num3 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num3 = num + num2;
            while (num < num3)
            {
                if (1 == message[num])
                {
                    array[b] = new TlvValueItem();
                    array[b]._tlvType = message[num];
                    array[b]._tlvLen = message[num + 1];
                    array[b]._tlvValue = new byte[message[num + 1]];
                    Array.Copy(message, num + 2, array[b]._tlvValue, 0, message[num + 1]);
                    b++;
                }
                else if (7 == message[num] && message[num + 2] != 0)
                {
                    break;
                }
                num = num + message[num + 1] + 2;
            }
            _notifyImpl.OnRecvTagData(this, array, b);
        }

        public override void OnRecvCompleted(byte[] messageData, int messageLen)
        {
            int num = 0;
            if (_notifyImpl == null)
            {
                return;
            }
            if (messageData[2] == 1)
            {
                switch (messageData[5])
                {
                    case 16:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvResetRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvResetRsp(this, 254);
                        }
                        break;
                    case 18:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetFactorySettingRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetFactorySettingRsp(this, 254);
                        }
                        break;
                    case 33:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvStartInventoryRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvStartInventoryRsp(this, 254);
                        }
                        break;
                    case 35:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvStopInventoryRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvStopInventoryRsp(this, 254);
                        }
                        break;
                    case 36:
                        OnRecvGetTagData(messageData, messageLen);
                        break;
                    case 34:
                        OnRecvInventoryOnce(messageData, messageLen);
                        break;
                    case 62:
                        {
                            RfidExtParam rfidExtParam = new RfidExtParam();
                            num = GetPositionByAttrType(messageData, messageLen, 7);
                            int positionByAttrType = GetPositionByAttrType(messageData, messageLen, 41);
                            if (positionByAttrType > 0)
                            {
                                rfidExtParam.ucRelayMode = messageData[2 + positionByAttrType];
                                rfidExtParam.ucRelayTime = messageData[3 + positionByAttrType];
                                rfidExtParam.ucVerifyFlag = messageData[4 + positionByAttrType];
                                rfidExtParam.usVerifyPwd = messageData[5 + positionByAttrType];
                                rfidExtParam.usVerifyPwd <<= 8;
                                rfidExtParam.usVerifyPwd += messageData[6 + positionByAttrType];
                                _notifyImpl.OnRecvQueryExtParamRsp(this, 0, rfidExtParam);
                            }
                            else
                            {
                                _notifyImpl.OnRecvQueryExtParamRsp(this, 1, null);
                            }
                            break;
                        }
                    case 63:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetExtParam(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetExtParam(this, 254);
                        }
                        break;
                    case 64:
                        {
                            byte[] array = null;
                            num = GetPositionByAttrType(messageData, messageLen, 7);
                            int positionByAttrType2 = GetPositionByAttrType(messageData, messageLen, 32);
                            int positionByAttrType3 = GetPositionByAttrType(messageData, messageLen, 32);
                            if (positionByAttrType2 > 0)
                            {
                                array = new byte[messageData[positionByAttrType2 + 1]];
                                Array.Copy(messageData, positionByAttrType2 + 2, array, 0, messageData[positionByAttrType2 + 1]);
                            }
                            _notifyImpl.OnRecvDeviceInfoRsp(this, array, messageData[positionByAttrType3 + 2]);
                            break;
                        }
                    case 65:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetWorkParamRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetWorkParamRsp(this, 254);
                        }
                        break;
                    case 66:
                        HandleQueryWorkingParamRsp(messageData, messageLen);
                        break;
                    case 68:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetTransmissionParamRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetTransmissionParamRsp(this, 254);
                        }
                        break;
                    case 67:
                        HandleQueryTransmissionParamRsp(messageData, messageLen);
                        break;
                    case 70:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetTransmissionParamRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetTransmissionParamRsp(this, 254);
                        }
                        break;
                    case 69:
                        HandleQueryAdvanceParamRsp(messageData, messageLen);
                        break;
                    case 72:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSettingSingleParam(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSettingSingleParam(this, 254);
                        }
                        break;
                    case 73:
                        HandleRecvQuerySingleParam(messageData, messageLen);
                        break;
                    case 48:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvWriteTagRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvWriteTagRsp(this, 254);
                        }
                        break;
                    case 114:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvRecordStatusRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvRecordStatusRsp(this, 254);
                        }
                        break;
                    case 74:
                        HandleRecvQueryRtcTime(messageData, messageLen);
                        break;
                    case 75:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetRtcTimeStatusRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetRtcTimeStatusRsp(this, 254);
                        }
                        break;
                    case 49:
                        HandleRecvReadBlockResponseByte(messageData, messageLen);
                        break;
                    case 50:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvWriteWiegandNumberRsp(this, messageData[num + 2]);
                        break;
                    case 51:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvLockResult(this, messageData[num + 2]);
                        break;
                    case 53:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvWriteTagRsp(this, messageData[num + 2]);
                        break;
                    case 77:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvAudioPlayRsp(this, messageData[num + 2]);
                        break;
                    case 76:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvRelayOpRsp(this, messageData[num + 2]);
                        break;
                    case 78:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvVerifyTagRsp(this, messageData[num + 2]);
                        break;
                    case 80:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvSetUsbInfoRsp(this, messageData[num + 2]);
                        break;
                    case 81:
                        HandleRecvQueryUsbInfo(messageData, messageLen);
                        break;
                    case 82:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvSetDataFlagRsp(this, messageData[num + 2]);
                        break;
                    case 83:
                        HandleRecvQueryDataFlag(messageData, messageLen);
                        break;
                    case 84:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        _notifyImpl.OnRecvSetModbusParamRsp(this, messageData[num + 2]);
                        break;
                    case 85:
                        HandleRecvQueryModbusParam(messageData, messageLen);
                        break;
                    case 117:
                        num = GetPositionByAttrType(messageData, messageLen, 7);
                        if (num > 0)
                        {
                            _notifyImpl.OnRecvSetParamRsp(this, messageData[num + 2]);
                        }
                        else
                        {
                            _notifyImpl.OnRecvSetParamRsp(this, 254);
                        }
                        break;
                    case 118:
                        HandleRecvQueryParam(messageData, messageLen);
                        break;
                }
            }
            else if (messageData[2] == 2)
            {
                switch (messageData[5])
                {
                    case 128:
                        HandleRecvTagNotify(messageData, messageLen, offlineFlag: false);
                        break;
                    case 129:
                        HandleRecvTagNotify(messageData, messageLen, offlineFlag: true);
                        break;
                    case 130:
                        HandleRecvRecordNotify(messageData, messageLen);
                        break;
                    case 144:
                        HandleHearBeatsNotify(messageData, messageLen);
                        break;
                }
            }
        }

        private void HandleRecvQueryParam(byte[] messageData, int messageLen)
        {
            ushort num = 9;
            uint num2 = 0u;
            uint num3 = 0u;
            byte b = 0;
            num2 = messageData[6];
            num2 <<= 8;
            num2 += messageData[7];
            switch (messageData[8])
            {
                case 48:
                    {
                        CWifiConnInfo cWifiConnInfo = new CWifiConnInfo();
                        cWifiConnInfo.protocolRole = messageData[num++];
                        cWifiConnInfo.port = messageData[num++];
                        cWifiConnInfo.port <<= 8;
                        cWifiConnInfo.port += messageData[num++];
                        cWifiConnInfo.localPort = messageData[num++];
                        cWifiConnInfo.localPort <<= 8;
                        cWifiConnInfo.localPort += messageData[num++];
                        cWifiConnInfo.ipMode = messageData[num++];
                        for (num2 = (uint)(num2 - (num - 8)); num3 < num2; num3 += (uint)(messageData[num + num3 + 1] + 2))
                        {
                            if (messageData[num + num3] == 1)
                            {
                                Array.Copy(messageData, num + num3 + 2, cWifiConnInfo.ipAddr, 0L, messageData[num + num3 + 1]);
                            }
                            else
                            {
                                b = 1;
                            }
                            if (b != 0)
                            {
                                return;
                            }
                        }
                        _notifyImpl.OnRecvQueryWifiConnRsp(this, cWifiConnInfo);
                        break;
                    }
                case 50:
                    {
                        CWifiAPInfo cWifiAPInfo = new CWifiAPInfo();
                        if (messageData[num++] != 0)
                        {
                            cWifiAPInfo.bEnable = true;
                        }
                        else
                        {
                            cWifiAPInfo.bEnable = false;
                        }
                        cWifiAPInfo.channelid = messageData[num++];
                        cWifiAPInfo.encryptType = messageData[num++];
                        for (num2 = (uint)(num2 - (num - 8)); num3 < num2; num3 += (ushort)(messageData[num + num3 + 1] + 2))
                        {
                            switch (messageData[num + num3])
                            {
                                case 1:
                                    cWifiAPInfo.ssid = Encoding.Default.GetString(messageData, (int)(num + num3 + 2), messageData[num + num3 + 1]);
                                    break;
                                case 2:
                                    cWifiAPInfo.password = Encoding.Default.GetString(messageData, (int)(num + num3 + 2), messageData[num + num3 + 1]);
                                    break;
                                case 3:
                                    Array.Copy(messageData, num + num3 + 2, cWifiAPInfo.baseid, 0L, messageData[num + num3 + 1]);
                                    break;
                            }
                        }
                        _notifyImpl.OnRecvQueryWifiAPInfo(this, cWifiAPInfo);
                        break;
                    }
                case 51:
                    {
                        CWifiStaInfo cWifiStaInfo = new CWifiStaInfo();
                        if (messageData[num++] != 0)
                        {
                            cWifiStaInfo.bEnable = true;
                        }
                        else
                        {
                            cWifiStaInfo.bEnable = false;
                        }
                        cWifiStaInfo.dhcpMode = messageData[num++];
                        for (num2 = (uint)(num2 - (num - 8)); num3 < num2; num3 += (ushort)(messageData[num + num3 + 1] + 2))
                        {
                            switch (messageData[num + num3])
                            {
                                case 1:
                                    cWifiStaInfo.ssid = Encoding.Default.GetString(messageData, (int)(num + num3 + 2), messageData[num + num3 + 1]);
                                    break;
                                case 2:
                                    cWifiStaInfo.password = Encoding.Default.GetString(messageData, (int)(num + num3 + 2), messageData[num + num3 + 1]);
                                    break;
                                case 3:
                                    Array.Copy(messageData, num + num3 + 2, cWifiStaInfo.bassid, 0L, messageData[num + num3 + 1]);
                                    break;
                                case 4:
                                    cWifiStaInfo.ipMode = messageData[num + num3 + 2];
                                    Array.Copy(messageData, num + num3 + 3, cWifiStaInfo.ipAddr, 0L, messageData[num + num3 + 1] - 1);
                                    break;
                                case 5:
                                    Array.Copy(messageData, num + num3 + 2, cWifiStaInfo.netmask, 0L, messageData[num + num3 + 1]);
                                    break;
                                case 6:
                                    Array.Copy(messageData, num + num3 + 2, cWifiStaInfo.gateway, 0L, messageData[num + num3 + 1]);
                                    break;
                            }
                        }
                        _notifyImpl.OnRecvQueryWifiStaInfo(this, cWifiStaInfo);
                        break;
                    }
                case 54:
                    {
                        CUserHttpParam cUserHttpParam = new CUserHttpParam();
                        cUserHttpParam.protocolRole = messageData[num++];
                        cUserHttpParam.heartbeatInterval = messageData[num++];
                        cUserHttpParam.heartbeatInterval = (ushort)(cUserHttpParam.port << 8);
                        cUserHttpParam.heartbeatInterval += messageData[num++];
                        cUserHttpParam.addrType = messageData[num++];
                        cUserHttpParam.port = messageData[num++];
                        cUserHttpParam.port <<= 8;
                        cUserHttpParam.port += messageData[num++];
                        if (cUserHttpParam.addrType == 0)
                        {
                            cUserHttpParam.addr = $"{messageData[num + 1]}.{messageData[num + 2]}.{messageData[num + 3]}.{messageData[num + 4]}";
                            num += 5;
                        }
                        else if (cUserHttpParam.addrType == 1)
                        {
                            cUserHttpParam.addr = $"{messageData[num + 1]:X2}:{messageData[num + 2]:X2}:{messageData[num + 3]:X2}:{messageData[num + 4]:X2}:{messageData[num + 5]:X2}:{messageData[num + 6]:X2}:{messageData[num + 7]:X2}:{messageData[num + 8]:X2}";
                            num += 9;
                        }
                        else if (cUserHttpParam.addrType == 2)
                        {
                            cUserHttpParam.addr = Encoding.Default.GetString(messageData, num + 1, messageData[num]);
                            num = (ushort)(num + messageData[num] + 1);
                        }
                        _notifyImpl.OnRecvQueryUserHttpParam(this, cUserHttpParam);
                        break;
                    }
                case 55:
                    {
                        CUserWifi cUserWifi = new CUserWifi();
                        if (messageData[num] == 0)
                        {
                            cUserWifi.apName = "";
                            num++;
                        }
                        else
                        {
                            cUserWifi.apName = Encoding.Default.GetString(messageData, num + 1, messageData[num]);
                            num = (ushort)(num + messageData[num] + 1);
                        }
                        if (messageData[num] == 0)
                        {
                            cUserWifi.apPwd = "";
                            num++;
                        }
                        else
                        {
                            cUserWifi.apPwd = Encoding.Default.GetString(messageData, num + 1, messageData[num]);
                            num = (ushort)(num + messageData[num] + 1);
                        }
                        if (messageData[num] == 0)
                        {
                            cUserWifi.staName = "";
                            num++;
                        }
                        else
                        {
                            cUserWifi.staName = Encoding.Default.GetString(messageData, num + 1, messageData[num]);
                            num = (ushort)(num + messageData[num] + 1);
                        }
                        if (messageData[num] == 0)
                        {
                            cUserWifi.staPwd = "";
                            num++;
                        }
                        else
                        {
                            cUserWifi.staPwd = Encoding.Default.GetString(messageData, num + 1, messageData[num]);
                            num = (ushort)(num + messageData[num] + 1);
                        }
                        _notifyImpl.OnRecvQueryUserWifiParam(this, cUserWifi);
                        break;
                    }
                case 56:
                    {
                        CUserWifiIP cUserWifiIP = new CUserWifiIP();
                        cUserWifiIP.connectStatus = messageData[num++];
                        cUserWifiIP.dhcpMode = messageData[num++];
                        if (messageData[num] != 4)
                        {
                            break;
                        }
                        Array.Copy(messageData, num + 1, cUserWifiIP.arrIP, 0, 4);
                        num += 5;
                        if (messageData[num] != 4)
                        {
                            break;
                        }
                        Array.Copy(messageData, num + 1, cUserWifiIP.arrMask, 0, 4);
                        num += 5;
                        if (messageData[num] == 4)
                        {
                            Array.Copy(messageData, num + 1, cUserWifiIP.arrGateWay, 0, 4);
                            num += 5;
                            if (messageData[num] == 6)
                            {
                                Array.Copy(messageData, num + 1, cUserWifiIP.arrMac, 0, 6);
                                num += 7;
                                _notifyImpl.OnRecvQueryWifiStaStatusInfo(this, cUserWifiIP);
                            }
                        }
                        break;
                    }
                case 49:
                case 52:
                case 53:
                    break;
            }
        }

        private void HandleRecvQueryRtcTime(byte[] message, int messageLen)
        {
            int positionByAttrType = GetPositionByAttrType(message, messageLen, 6);
            int num = 0;
            if (positionByAttrType > 0)
            {
                num = message[positionByAttrType + 2];
                num <<= 8;
                num += message[positionByAttrType + 3];
                _notifyImpl.OnRecvQueryRtcTimeRsp(num, message[positionByAttrType + 4], message[positionByAttrType + 5], message[positionByAttrType + 6], message[positionByAttrType + 7], message[positionByAttrType + 8]);
            }
        }

        public void HandleRecvRecordNotify(byte[] message, int messageLen)
        {
            string text = "";
            string text2 = "";
            int num = message[20];
            int num2 = 0;
            text = text + ((message[10] << 8) + message[11]) + ".";
            text = text + message[12] + ".";
            text = text + message[13] + " ";
            text = text + message[14] + ":";
            text = text + message[15] + ":";
            text = text + message[16] + "   ";
            for (int i = 0; i < num; i++)
            {
                text2 += message[21 + i].ToString("X2");
            }
            _notifyImpl.OnRecvRecordNotify(this, text, text2);
        }

        private void HandleRecvReadBlockResponseByte(byte[] message, int messageLen)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num3 = num + num2;
            byte[] array = null;
            byte[] array2 = null;
            while (num < num3)
            {
                if (8 == message[num])
                {
                    array = new byte[message[num + 6] * 2];
                    Array.Copy(message, num + 7, array, 0, array.Length);
                }
                else if (1 == message[num])
                {
                    array2 = new byte[message[num + 1]];
                    Array.Copy(message, num + 2, array2, 0, array2.Length);
                }
                num = num + message[num + 1] + 2;
            }
            if (array != null)
            {
                _notifyImpl.OnRecvReadBlockRsp(this, 0, array, array2);
            }
            else
            {
                _notifyImpl.OnRecvReadBlockRsp(this, 1, array, array2);
            }
        }

        private void HandleRecvTagNotify(byte[] message, int messageLen, bool offlineFlag)
        {
            TlvValueItem[] array = new TlvValueItem[6];
            byte b = 0;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num3 = num + num2;
            while (num < num3)
            {
                if (80 == message[num])
                {
                    for (num4 = num + 2; num4 < num + 2 + message[num + 1]; num4 = num4 + message[num4 + 1] + 2)
                    {
                        array[b] = new TlvValueItem();
                        array[b]._tlvType = message[num4];
                        array[b]._tlvLen = message[num4 + 1];
                        array[b]._tlvValue = new byte[message[num4 + 1]];
                        Array.Copy(message, num4 + 2, array[b]._tlvValue, 0, message[num4 + 1]);
                        b++;
                    }
                    _notifyImpl.OnRecvTagNotify(this, array, b);
                    b = 0;
                }
                else if (7 == message[num] && message[num + 2] != 0)
                {
                    break;
                }
                num = num + message[num + 1] + 2;
            }
        }

        private void HandleHearBeatsNotify(byte[] message, int messageLen)
        {
            _notifyImpl.OnRecvHeartBeats(this, null, 0);
        }

        private void HandleQueryWorkingParamRsp(byte[] message, int messageLen)
        {
            int positionByAttrType = GetPositionByAttrType(message, messageLen, 7);
            int positionByAttrType2 = GetPositionByAttrType(message, messageLen, 35);
            if (positionByAttrType < 0)
            {
                _notifyImpl.OnRecvQueryWorkParamRsp(this, 254, null);
                return;
            }
            if (message[positionByAttrType + 2] != 0)
            {
                _notifyImpl.OnRecvQueryWorkParamRsp(this, message[positionByAttrType + 2], null);
                return;
            }
            if (positionByAttrType2 < 0)
            {
                _notifyImpl.OnRecvQueryWorkParamRsp(this, 254, null);
                return;
            }
            RfidWorkParam rfidWorkParam = new RfidWorkParam();
            rfidWorkParam.SetParamFromMessage(message, positionByAttrType2 + 2);
            _notifyImpl.OnRecvQueryWorkParamRsp(this, 0, rfidWorkParam);
        }

        private void HandleQueryTransmissionParamRsp(byte[] message, int messageLen)
        {
            int positionByAttrType = GetPositionByAttrType(message, messageLen, 7);
            int positionByAttrType2 = GetPositionByAttrType(message, messageLen, 36);
            if (positionByAttrType < 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, 254, null);
                return;
            }
            if (message[positionByAttrType + 2] != 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, message[positionByAttrType + 2], null);
                return;
            }
            if (positionByAttrType2 < 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, 254, null);
                return;
            }
            RfidTransmissionParam rfidTransmissionParam = new RfidTransmissionParam();
            rfidTransmissionParam.SetParamFromMessage(message, positionByAttrType2 + 2);
            _notifyImpl.OnRecvQueryTransmissionParamRsp(this, 0, rfidTransmissionParam);
        }

        private void HandleQueryAdvanceParamRsp(byte[] message, int messageLen)
        {
            ushort num = 0;
            num = message[6];
            num <<= 8;
            num += message[7];
            int positionByAttrType = GetPositionByAttrType(message, messageLen, 7);
            int positionByAttrType2 = GetPositionByAttrType(message, messageLen, 37);
            if (positionByAttrType < 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, 254, null);
                return;
            }
            if (message[positionByAttrType + 2] != 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, message[positionByAttrType + 2], null);
                return;
            }
            if (positionByAttrType2 < 0)
            {
                _notifyImpl.OnRecvQueryTransmissionParamRsp(this, 254, null);
                return;
            }
            RfidAdvanceParam rfidAdvanceParam = new RfidAdvanceParam();
            rfidAdvanceParam.SetParamFromMessage(message, (ushort)(positionByAttrType2 + 2), num);
            _notifyImpl.OnRecvQueryAdvanceParamRsp(this, 0, rfidAdvanceParam);
        }

        private void HandleRecvQuerySingleParam(byte[] message, int messageLen)
        {
            int positionByAttrType = GetPositionByAttrType(message, messageLen, 7);
            int positionByAttrType2 = GetPositionByAttrType(message, messageLen, 38);
            if (positionByAttrType < 0 || positionByAttrType2 < 0)
            {
                _notifyImpl.OnRecvQuerySingleParam(this, null);
                return;
            }
            if (message[positionByAttrType + 2] != 0)
            {
                _notifyImpl.OnRecvQuerySingleParam(this, null);
                return;
            }
            TlvValueItem tlvValueItem = new TlvValueItem();
            tlvValueItem._tlvType = message[positionByAttrType2 + 2];
            tlvValueItem._tlvLen = message[positionByAttrType2 + 3];
            tlvValueItem._tlvValue = new byte[tlvValueItem._tlvLen];
            for (int i = 0; i < tlvValueItem._tlvLen; i++)
            {
                tlvValueItem._tlvValue[i] = message[positionByAttrType2 + 4 + i];
            }
            _notifyImpl.OnRecvQuerySingleParam(this, tlvValueItem);
        }

        private void HandleRecvQueryUsbInfo(byte[] message, int messageLen)
        {
            int num = 0;
            int num2 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num += 3;
            _notifyImpl.OnRecvQueryUsbInfoRsp(this, message[num], message[num + 1], message[num + 2]);
        }

        private void HandleRecvQueryDataFlag(byte[] message, int messageLen)
        {
            int num = 0;
            int num2 = 0;
            ushort num3 = 0;
            byte b = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num += 3;
            num3 = message[num];
            num3 <<= 8;
            num3 |= message[num + 1];
            b = message[num + 2];
            _notifyImpl.OnRecvQueryDataFlagRsp(this, num3, b);
        }

        private void HandleRecvQueryModbusParam(byte[] message, int messageLen)
        {
            int num = 0;
            int num2 = 0;
            num2 = message[6];
            num2 <<= 8;
            num2 += message[7];
            num = 8;
            num += 3;
            if (num2 >= 8)
            {
                if (message[num + 4] == byte.MaxValue)
                {
                    _notifyImpl.OnRecvQueryModbusParam(this, message[num], message[num + 1], message[num + 2], message[num + 3], -1);
                }
                else
                {
                    _notifyImpl.OnRecvQueryModbusParam(this, message[num], message[num + 1], message[num + 2], message[num + 3], message[num + 4]);
                }
            }
            else
            {
                _notifyImpl.OnRecvQueryModbusParam(this, message[num], message[num + 1], message[num + 2], message[num + 3], -1);
            }
        }

        public override void HandleRecvData()
        {
            transport.HandleRecvData();
        }
    }
}
