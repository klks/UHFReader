using CPH_F206.RfidSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CPH_F206.FormTabs
{
    public partial class HCWifiWindow : Form
    {
        private RfidReader reader;
        private MainForm mParentDlg;

        public HCWifiWindow()
        {
            InitializeComponent();
            skinComboBox_recv_ip_type.SelectedIndex = 0;
            skinComboBox_recv_protocol.SelectedIndex = 0;
        }

        public void SetParentDlg(MainForm form1)
        {
            mParentDlg = form1;
        }

        public void SetReader(RfidReader reader)
        {
            this.reader = reader;
        }

        private void skinButton_http_query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device first.", MessageType.Error);
            }
            else
            {
                reader.HCWifiQueryHttpParam();
            }
        }

        private void skinButton_http_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device.", MessageType.Error);
                return;
            }
            CUserHttpParam cUserHttpParam = new CUserHttpParam();
            int num = 0;
            cUserHttpParam.port = (ushort)skinNumericUpDown_recv_port.Value;
            cUserHttpParam.addr = skinWaterTextBox_recv_addr.Text.Trim();
            cUserHttpParam.addrType = (byte)skinComboBox_recv_ip_type.SelectedIndex;
            cUserHttpParam.protocolRole = (byte)skinComboBox_recv_protocol.SelectedIndex;
            cUserHttpParam.heartbeatInterval = (ushort)skinNumericUpDown_recv_heartbeat.Value;
            if (skinWaterTextBox_recv_addr.Text.Trim().Length == 0)
            {
                mParentDlg.AddResultItem("Please enter the receiving address.", MessageType.Error);
                return;
            }
            if (cUserHttpParam.addrType == 0)
            {
                string[] array = skinWaterTextBox_recv_addr.Text.Split('.');
                if (array.Length != 4)
                {
                    mParentDlg.AddResultItem("Please enter the correct IPv4 address.", MessageType.Error);
                    return;
                }
                for (num = 0; num < 4; num++)
                {
                    Convert.ToByte(array[num]);
                }
            }
            cUserHttpParam.addr = skinWaterTextBox_recv_addr.Text.Trim();
            reader.HCWifiSetHttpParam(cUserHttpParam);
        }

        private void skinButton_wifi_query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device.", MessageType.Error);
            }
            else
            {
                reader.HCWifiQueryConn();
            }
        }

        private void skinButton_wifi_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device.", MessageType.Error);
                return;
            }
            CUserWifi cUserWifi = new CUserWifi();
            cUserWifi.apName = skinWaterTextBox_wifi_ap_name.Text.Trim();
            cUserWifi.apPwd = skinWaterTextBox_wifi_ap_pwd.Text.Trim();
            cUserWifi.staName = skinComboBox_wifi_sta_name.Text.Trim();
            cUserWifi.staPwd = skinWaterTextBox_wifi_sta_pwd.Text.Trim();
            if (cUserWifi.staName.Length == 0)
            {
                mParentDlg.AddResultItem("Please enter the name of the Wi-Fi network you want to connect to.", MessageType.Error);
            }
            else if (cUserWifi.apPwd.Trim().Length > 0 && cUserWifi.apPwd.Trim().Length < 8)
            {
                mParentDlg.AddResultItem("The Wi-Fi password for the access point must be longer than 8 characters.", MessageType.Error);
            }
            else if (cUserWifi.staPwd.Trim().Length > 0 && cUserWifi.staPwd.Trim().Length < 8)
            {
                mParentDlg.AddResultItem("The Wi-Fi password you want to connect to must be longer than 8 characters.", MessageType.Error);
            }
            else
            {
                reader.HCWifiSetConnParam(cUserWifi);
            }
        }

        public void OnQueryHttpParam(RfidReader reader, CUserHttpParam param)
        {
            if (param == null)
            {
                mParentDlg.AddResultItem("Failed to query HTTP parameters", MessageType.Error);
                return;
            }
            mParentDlg.AddResultItem("Successfully queried HTTP sent parameters", MessageType.Normal);
            skinNumericUpDown_recv_port.Value = param.port;
            skinWaterTextBox_recv_addr.Text = param.addr;
        }

        public void OnQueryWifiConn(RfidReader reader, CUserWifi param)
        {
            if (param == null)
            {
                mParentDlg.AddResultItem("Failed to query WIFI parameters", MessageType.Normal);
                return;
            }
            mParentDlg.AddResultItem("Successfully queried WIFI parameters", MessageType.Normal);
            skinWaterTextBox_wifi_ap_name.Text = param.apName;
            skinWaterTextBox_wifi_ap_pwd.Text = param.apPwd;
            skinWaterTextBox_wifi_sta_pwd.Text = param.staPwd;
            skinComboBox_wifi_sta_name.Text = param.staName;
        }

        private void skinButton_wifi_ip_query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device.", MessageType.Error);
            }
            else
            {
                reader.HCWifiQueryIP();
            }
        }

        private void skinButton_wifi_ip_set_Click(object sender, EventArgs e)
        {
            CUserWifiIP cUserWifiIP = new CUserWifiIP();
            cUserWifiIP.dhcpMode = (byte)skinComboBox_wifi_dhcp.SelectedIndex;
            cUserWifiIP.connectStatus = 0;
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the hardware interface and connect the device.", MessageType.Error);
            }
            else if (!StrToIP(skinTextBox_wifi_IP.Text, cUserWifiIP.arrIP))
            {
                mParentDlg.AddResultItem("Please enter the correct IP address.", MessageType.Error);
            }
            else if (!StrToIP(skinTextBox_wifi_netmask.Text, cUserWifiIP.arrMask))
            {
                mParentDlg.AddResultItem("Please enter the correct subnet mask.", MessageType.Error);
            }
            else if (!StrToIP(skinTextBox_wifi_gateway.Text, cUserWifiIP.arrGateWay))
            {
                mParentDlg.AddResultItem("Please enter the correct gateway address.", MessageType.Error);
            }
            else
            {
                reader.HCWifiSetIPParam(cUserWifiIP);
            }
        }

        public bool StrToIP(string strIP, byte[] arrIP)
        {
            if (string.IsNullOrEmpty(strIP))
            {
                return false;
            }
            string[] array = strIP.Split('.');
            if (array.Length != 4)
            {
                return false;
            }
            for (int i = 0; i < array.Length; i++)
            {
                int num = Convert.ToInt32(array[i]);
                arrIP[i] = (byte)num;
            }
            return true;
        }

        public void OnQueryWifiStaStatus(RfidReader reader, CUserWifiIP param)
        {
            if (param == null)
            {
                mParentDlg.AddResultItem("Querying Wi-Fi address parameters failed", MessageType.Error);
                return;
            }
            mParentDlg.AddResultItem("Successfully queried WIFI address parameters", MessageType.Normal);
            if (param.connectStatus != 0)
            {
                skinLabel_wifi_ip_conn_status.Text = "Connected";
                skinLabel_wifi_ip_conn_status.ForeColor = Color.Green;
            }
            else
            {
                skinLabel_wifi_ip_conn_status.Text = "Not connected";
                skinLabel_wifi_ip_conn_status.ForeColor = Color.Red;
            }
            if (param.dhcpMode == 0)
            {
                skinComboBox_wifi_dhcp.SelectedIndex = 0;
            }
            else
            {
                skinComboBox_wifi_dhcp.SelectedIndex = 1;
            }
            skinTextBox_wifi_IP.Text = $"{param.arrIP[0]}.{param.arrIP[1]}.{param.arrIP[2]}.{param.arrIP[3]}";
            skinTextBox_wifi_netmask.Text = $"{param.arrMask[0]}.{param.arrMask[1]}.{param.arrMask[2]}.{param.arrMask[3]}";
            skinTextBox_wifi_gateway.Text = $"{param.arrGateWay[0]}.{param.arrGateWay[1]}.{param.arrGateWay[2]}.{param.arrGateWay[3]}";
            skinTextBox_wifi_mac.Text = $"{param.arrMac[0]:X2}:{param.arrMac[1]:X2}:{param.arrMac[2]:X2}:{param.arrMac[3]:X2}:{param.arrMac[4]:X2}:{param.arrMac[5]:X2}";
        }

        private void skinComboBox_wifi_dhcp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox_wifi_dhcp.SelectedIndex == 0)
            {
                skinTextBox_wifi_IP.ReadOnly = false;
                skinTextBox_wifi_netmask.ReadOnly = false;
                skinTextBox_wifi_gateway.ReadOnly = false;
            }
            else
            {
                skinTextBox_wifi_IP.ReadOnly = true;
                skinTextBox_wifi_netmask.ReadOnly = true;
                skinTextBox_wifi_gateway.ReadOnly = true;
            }
        }
    }
}
