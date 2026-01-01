using CPH_F206.RfidSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.FormTabs
{
    internal class RfidRspNotify : RfidReaderRspNotify
    {
        private MainForm mainWindows;

        public RfidRspNotify(MainForm winForm)
        {
            mainWindows = winForm;
        }

        void RfidReaderRspNotify.OnRecvResetRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReaderResetRsp(reader, result);
                });
            }
            else
            {
                mainWindows.OnRecvReaderResetRsp(reader, result);
            }
        }

        void RfidReaderRspNotify.OnRecvSetFactorySettingRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReaderRestorFactorySettingRsp(reader, result);
                });
            }
            else
            {
                mainWindows.OnRecvReaderRestorFactorySettingRsp(reader, result);
            }
        }

        void RfidReaderRspNotify.OnRecvStartInventoryRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Start to inventory tags.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Fail to inventory tags.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Start to inventory tags.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Fail to inventory tags.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvStopInventoryRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Stop to inventory tags.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Stop to inventory tags.", MessageType.Normal);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Stop to inventory tags.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Stop to inventory tags.", MessageType.Normal);
            }
        }

        void RfidReaderRspNotify.OnRecvDeviceInfoRsp(RfidReader reader, byte[] firmwareVersion, byte deviceType)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReaderDeviceInfoRsp(firmwareVersion, deviceType);
                });
            }
            else
            {
                mainWindows.OnRecvReaderDeviceInfoRsp(firmwareVersion, deviceType);
            }
        }

        void RfidReaderRspNotify.OnRecvSetWorkParamRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Working parameters set successfully.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Failed to set working parameters.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Working parameters set successfully.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Fail to set working parameters.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryWorkParamRsp(RfidReader reader, byte result, RfidWorkParam workParam)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReaderQueryWorkParamRsp(reader, result, workParam);
                });
            }
            else
            {
                mainWindows.OnRecvReaderQueryWorkParamRsp(reader, result, workParam);
            }
        }

        void RfidReaderRspNotify.OnRecvSetTransmissionParamRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Success to set transmission parameters.", MessageType.Normal);
                        mainWindows.BackToConnectMode();
                    }
                    else
                    {
                        mainWindows.AddResultItem("Fail to stop transmission parameters.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Success to set transmission parameters.", MessageType.Normal);
                mainWindows.BackToConnectMode();
            }
            else
            {
                mainWindows.AddResultItem("Fail to stop transmission parameters.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryTransmissionParamRsp(RfidReader reader, byte result, RfidTransmissionParam transmissiomParam)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                mainWindows.OnRecvReaderQueryTransmissionRsp(reader, result, transmissiomParam);
            });
        }

        void RfidReaderRspNotify.OnRecvSetAdvanceParamRsp(RfidReader reader, byte result)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                if (result == 0)
                {
                    mainWindows.AddResultItem("Success to set advance parameters.", MessageType.Normal);
                }
                else
                {
                    mainWindows.AddResultItem("Fail to stop advance parameters.", MessageType.Error);
                }
            });
        }

        void RfidReaderRspNotify.OnRecvQueryAdvanceParamRsp(RfidReader reader, byte result, RfidAdvanceParam advanceParam)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                mainWindows.OnRecvReaderQueryAdvanceRsp(reader, result, advanceParam);
            });
        }

        void RfidReaderRspNotify.OnRecvWriteWiegandNumberRsp(RfidReader reader, byte result)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                mainWindows.OnRecvWriteWiegandNumberRsp(reader, result);
            });
        }

        void RfidReaderRspNotify.OnRecvLockResult(RfidReader reader, byte result)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                if (result == 0)
                {
                    mainWindows.AddResultItem("Tag successfully locked.", MessageType.Normal);
                }
                else
                {
                    mainWindows.AddResultItem("Tag locking failed.", MessageType.Error);
                }
            });
        }

        void RfidReaderRspNotify.OnRecvTagNotify(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
            mainWindows.Invoke((EventHandler)delegate
            {
                mainWindows.OnRecvTagNotify(reader, tlvItems, tlvCount);
            });
        }

        void RfidReaderRspNotify.OnRecvHeartBeats(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
        }

        void RfidReaderRspNotify.OnRecvSettingSingleParam(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Parameters set successfully.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Parameter setting failed.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Parameters set successfully.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Parameter setting failed.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQuerySingleParam(RfidReader reader, TlvValueItem item)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReaderQuerySingleParamRsp(reader, item);
                });
            }
            else
            {
                mainWindows.OnRecvReaderQuerySingleParamRsp(reader, item);
            }
        }

        public void OnRecvWriteTagRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvWriteTagResult(result);
                });
            }
            else
            {
                mainWindows.OnRecvWriteTagResult(result);
            }
        }

        void RfidReaderRspNotify.OnRecvReadBlockRsp(RfidReader reader, byte result, byte[] read_data, byte[] epc_data)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvReadTagBlockNotify(reader, result, read_data, epc_data);
                });
            }
            else
            {
                mainWindows.OnRecvReadTagBlockNotify(reader, result, read_data, epc_data);
            }
        }

        void RfidReaderRspNotify.OnRecvRecordNotify(RfidReader reader, string time, string tagId)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvRecordNotify(reader, time, tagId);
                });
            }
            else
            {
                mainWindows.OnRecvRecordNotify(reader, time, tagId);
            }
        }

        void RfidReaderRspNotify.OnRecvRecordStatusRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvRecordStatusRsp(reader, result);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvRecordStatusRsp(reader, result);
            }
        }

        void RfidReaderRspNotify.OnRecvSetRtcTimeStatusRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvSetRtcTimeRsp(reader, result);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvSetRtcTimeRsp(reader, result);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryRtcTimeRsp(int year, int month, int day, int hour, int min, int sec)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvQueryRtcTimeRsp(year, month, day, hour, min, sec);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvQueryRtcTimeRsp(year, month, day, hour, min, sec);
            }
        }

        void RfidReaderRspNotify.OnRecvWriteTagRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.OnRecvWriteTagResult(result);
                });
            }
            else
            {
                mainWindows.OnRecvWriteTagResult(result);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryExtParamRsp(RfidReader reader, byte result, RfidExtParam extParam)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvQueryExtParam(result, extParam);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvQueryExtParam(result, extParam);
            }
        }

        void RfidReaderRspNotify.OnRecvSetExtParam(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Successfully set extended function parameters", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Failed to set extended function parameters:" + result, MessageType.Normal);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Successfully set extended function parameters", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Failed to set extended function parameters:" + result, MessageType.Normal);
            }
        }

        void RfidReaderRspNotify.OnRecvAudioPlayRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Voice operation successful", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Voice operation failed:" + result, MessageType.Normal);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Voice operation successful", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Voice operation failed:" + result, MessageType.Normal);
            }
        }

        void RfidReaderRspNotify.OnRecvRelayOpRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Relay operation successful", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Relay operation failed:" + result, MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Relay operation successful", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Relay operation failed:" + result, MessageType.Error);
            }
        }

        public void OnRecvVerifyTagRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Tag verification information added successfully", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Adding verification information to the tag failed:" + result, MessageType.Normal);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Tag verification information added successfully", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Adding verification information to the tag failed:" + result, MessageType.Normal);
            }
        }

        void RfidReaderRspNotify.OnRecvSetUsbInfoRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("USB parameters successfully configured.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Setting USB parameters failed.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("USB parameters successfully configured.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Setting USB parameters failed.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryUsbInfoRsp(RfidReader reader, byte interfaceType, byte usbProto, byte enterflag)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvQueryUsbData(interfaceType, usbProto, enterflag);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvQueryUsbData(interfaceType, usbProto, enterflag);
            }
        }

        void RfidReaderRspNotify.OnRecvSetDataFlagRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Successfully set the data transmission parameters.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Failed to set data transfer parameters.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Successfully set the data transmission parameters.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Failed to set data transfer parameters.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryDataFlagRsp(RfidReader reader, ushort dataFlag, byte dataFormate)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvQueryDataFlag(dataFlag, dataFormate);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvQueryDataFlag(dataFlag, dataFormate);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryModbusParam(RfidReader reader, byte tagNum, byte unionSize, byte addr, byte clearFlag, int modbusProto)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvQueryModbusParam(tagNum, unionSize, addr, clearFlag, modbusProto);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvQueryModbusParam(tagNum, unionSize, addr, clearFlag, modbusProto);
            }
        }

        void RfidReaderRspNotify.OnRecvSetModbusParamRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Modbus parameters successfully set.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Setting Modbus parameters failed.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Modbus parameters successfully set.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Setting Modbus parameters failed.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvTagData(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    mainWindows.m100Windows.OnRecvIdentify(reader, tlvItems, tlvCount);
                });
            }
            else
            {
                mainWindows.m100Windows.OnRecvIdentify(reader, tlvItems, tlvCount);
            }
        }

        public void OnRecvSetParamRsp(RfidReader reader, byte result)
        {
            if (mainWindows.InvokeRequired)
            {
                mainWindows.BeginInvoke((EventHandler)delegate
                {
                    if (result == 0)
                    {
                        mainWindows.AddResultItem("Parameters set successfully.", MessageType.Normal);
                    }
                    else
                    {
                        mainWindows.AddResultItem("Parameter setting failed.", MessageType.Error);
                    }
                });
            }
            else if (result == 0)
            {
                mainWindows.AddResultItem("Parameters set successfully.", MessageType.Normal);
            }
            else
            {
                mainWindows.AddResultItem("Parameter setting failed.", MessageType.Error);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryWifiConnRsp(RfidReader reader, CWifiConnInfo wifiConn)
        {
            WifiWindow tempW = mainWindows.mWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnRecvQueryWifiConn(reader, wifiConn);
                });
            }
            else
            {
                tempW.OnRecvQueryWifiConn(reader, wifiConn);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryWifiAPInfo(RfidReader reader, CWifiAPInfo wifiAPInfo)
        {
            WifiWindow tempW = mainWindows.mWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnRecvQueryWifiAPInfo(reader, wifiAPInfo);
                });
            }
            else
            {
                tempW.OnRecvQueryWifiAPInfo(reader, wifiAPInfo);
            }
        }

        void RfidReaderRspNotify.OnRecvQueryWifiStaInfo(RfidReader reader, CWifiStaInfo wifiStaInfo)
        {
            WifiWindow tempW = mainWindows.mWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnRecvQueryWifiStaInfo(reader, wifiStaInfo);
                });
            }
            else
            {
                tempW.OnRecvQueryWifiStaInfo(reader, wifiStaInfo);
            }
        }

        public void OnRecvQueryUserHttpParam(RfidReader reader, CUserHttpParam param)
        {
            HCWifiWindow tempW = mainWindows.mHCWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnQueryHttpParam(reader, param);
                });
            }
            else
            {
                tempW.OnQueryHttpParam(reader, param);
            }
        }

        public void OnRecvQueryUserWifiParam(RfidReader reader, CUserWifi param)
        {
            HCWifiWindow tempW = mainWindows.mHCWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnQueryWifiConn(reader, param);
                });
            }
            else
            {
                tempW.OnQueryWifiConn(reader, param);
            }
        }

        public void OnRecvQueryWifiStaStatusInfo(RfidReader reader, CUserWifiIP wifiStaInfo)
        {
            HCWifiWindow tempW = mainWindows.mHCWifiWindows;
            if (tempW.InvokeRequired)
            {
                tempW.BeginInvoke((EventHandler)delegate
                {
                    tempW.OnQueryWifiStaStatus(reader, wifiStaInfo);
                });
            }
            else
            {
                tempW.OnQueryWifiStaStatus(reader, wifiStaInfo);
            }
        }
    }
}
