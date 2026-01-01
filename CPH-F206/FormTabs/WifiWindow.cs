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
    public partial class WifiWindow : Form
    {
        private RfidReader reader;
        private MainForm mParentDlg;

        public WifiWindow()
        {
            InitializeComponent();
            skinComboBox_conn_ipmode.SelectedIndex = 0;
            skinComboBox_conn_protocol.Items.Add("TCP Server");
            skinComboBox_conn_protocol.Items.Add("TCP Client");
            skinComboBox_conn_protocol.Items.Add("UDP Server");
            skinComboBox_conn_protocol.Items.Add("UDP");
            skinComboBox_conn_protocol.SelectedIndex = 0;
            for (int i = 1; i <= 13; i++)
            {
                skinComboBox_AP_Channel.Items.Add(i.ToString());
            }
            skinComboBox_AP_Encrypt.Items.Add("Open");
            skinComboBox_AP_Encrypt.Items.Add("WPA_PSK");
            skinComboBox_AP_Encrypt.Items.Add("WPA2_PSK");
            skinComboBox_AP_Encrypt.Items.Add("WPA_WPA2_PSK");
            skinComboBox_AP_Encrypt.SelectedIndex = 3;
            skinComboBox_sta_ip_mode.Items.Add("DHCP");
            skinComboBox_sta_ip_mode.Items.Add("Manually set static address");
            skinComboBox_sta_ip_mode.SelectedIndex = 0;
        }
        public void SetReader(RfidReader reader)
        {
            this.reader = reader;
        }

        public void SetParentDlg(MainForm dlg)
        {
            mParentDlg = dlg;
        }

        private void skinButton_Conn_Query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
            }
            else
            {
                reader.QueryParam(ReaderParamID.WifiConnection);
            }
        }

        private void skinButton_Conn_Set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
                return;
            }
            CWifiConnInfo cWifiConnInfo = new CWifiConnInfo();
            cWifiConnInfo.protocolRole = (byte)skinComboBox_conn_protocol.SelectedIndex;
            cWifiConnInfo.ipMode = (byte)skinComboBox_conn_ipmode.SelectedIndex;
            string[] array = skinTextBox_Conn_IP.Text.Trim().Split('.');
            if (array.Length != 4)
            {
                mParentDlg.AddResultItem("IP address format error", MessageType.Error);
                return;
            }
            cWifiConnInfo.ipAddr[0] = Convert.ToByte(array[0]);
            cWifiConnInfo.ipAddr[1] = Convert.ToByte(array[1]);
            cWifiConnInfo.ipAddr[2] = Convert.ToByte(array[2]);
            cWifiConnInfo.ipAddr[3] = Convert.ToByte(array[3]);
            cWifiConnInfo.port = Convert.ToUInt16(skinTextBox_Conn_Port.Text.Trim());
            cWifiConnInfo.localPort = Convert.ToUInt16(skinTextBox_net_local_port.Text.Trim());
            reader.setWifiConn(cWifiConnInfo);
        }

        private void skinButton_AP_Query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
            }
            else
            {
                reader.QueryParam(ReaderParamID.WifiAPinfo);
            }
        }

        private void skinButton_AP_Set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
                return;
            }
            CWifiAPInfo cWifiAPInfo = new CWifiAPInfo();
            cWifiAPInfo.bEnable = skinCheckBox_AP_Enable.Checked;
            cWifiAPInfo.ssid = skinTextBox_AP_SSID.Text.Trim();
            cWifiAPInfo.password = skinTextBox_AP_Passwd.Text.Trim();
            cWifiAPInfo.channelid = (byte)(skinComboBox_AP_Channel.SelectedIndex + 1);
            cWifiAPInfo.encryptType = (byte)skinComboBox_AP_Encrypt.SelectedIndex;
            reader.setWifiAP(cWifiAPInfo);
        }

        private void skinButton_sta_query_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
            }
            else
            {
                reader.QueryParam(ReaderParamID.WifiStaInfo);
            }
        }

        private void skinButton_sta_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
                return;
            }
            string[] array = null;
            CWifiStaInfo cWifiStaInfo = new CWifiStaInfo();
            cWifiStaInfo.bEnable = skinCheckBox_sta_enable.Checked;
            cWifiStaInfo.ssid = skinTextBox_sta_ssid.Text.Trim();
            cWifiStaInfo.password = skinTextBox_sta_passwd.Text.Trim();
            string text = skinTextBox_sta_baseid.Text.Trim();
            if (skinComboBox_sta_ip_mode.SelectedIndex == 0)
            {
                cWifiStaInfo.dhcpMode = 1;
            }
            else
            {
                cWifiStaInfo.dhcpMode = 0;
            }
            if (cWifiStaInfo.password.Length < 8)
            {
                mParentDlg.AddResultItem("Password must be at least 8 characters long", MessageType.Error);
                return;
            }
            if (text.Length > 0)
            {
                array = text.Split(':');
                if (array.Length != 6)
                {
                    mParentDlg.AddResultItem("Baseid address format is incorrect.", MessageType.Error);
                    return;
                }
                for (int i = 0; i < 6; i++)
                {
                    cWifiStaInfo.bassid[i] = Convert.ToByte(array[i], 16);
                }
            }
            string text2 = skinTextBox_sta_ip.Text.Trim();
            if (text2.Length > 0)
            {
                array = text2.Split('.');
                if (array.Length != 4)
                {
                    mParentDlg.AddResultItem("IP address format error", MessageType.Error);
                    return;
                }
                for (int j = 0; j < 4; j++)
                {
                    cWifiStaInfo.ipAddr[j] = Convert.ToByte(array[j]);
                }
            }
            text2 = skinTextBox_sta_ip_netmask.Text.Trim();
            if (text2.Length > 0)
            {
                array = text2.Split('.');
                if (array.Length != 4)
                {
                    mParentDlg.AddResultItem("Subnet mask format error", MessageType.Error);
                    return;
                }
                for (int k = 0; k < 4; k++)
                {
                    cWifiStaInfo.netmask[k] = Convert.ToByte(array[k]);
                }
            }
            text2 = skinTextBox_sta_ip_gateway.Text.Trim();
            if (text2.Length > 0)
            {
                array = text2.Split('.');
                if (array.Length != 4)
                {
                    mParentDlg.AddResultItem("Gateway address format error", MessageType.Error);
                    return;
                }
                for (int l = 0; l < 4; l++)
                {
                    cWifiStaInfo.gateway[l] = Convert.ToByte(array[l]);
                }
            }
            reader.setWifiSta(cWifiStaInfo);
        }

        private void skinButton_sta_scan_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                mParentDlg.AddResultItem("Please open the communication port before proceeding.", MessageType.Error);
            }
        }

        internal void OnRecvQueryWifiConn(object reader, CWifiConnInfo wifiConn)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (wifiConn.protocolRole < skinComboBox_conn_protocol.Items.Count)
            {
                skinComboBox_conn_protocol.SelectedIndex = wifiConn.protocolRole;
            }
            else
            {
                skinComboBox_conn_protocol.SelectedIndex = -1;
            }
            if (wifiConn.ipMode < skinComboBox_conn_ipmode.Items.Count)
            {
                skinComboBox_conn_ipmode.SelectedIndex = wifiConn.ipMode;
            }
            else
            {
                skinComboBox_conn_ipmode.SelectedIndex = -1;
            }
            stringBuilder.Clear();
            stringBuilder.AppendFormat("{0:d}.{1:d}.{2:d}.{3:d}", wifiConn.ipAddr[0], wifiConn.ipAddr[1], wifiConn.ipAddr[2], wifiConn.ipAddr[3]);
            skinTextBox_Conn_IP.Text = stringBuilder.ToString();
            skinTextBox_Conn_Port.Text = wifiConn.port.ToString();
            skinTextBox_net_local_port.Text = wifiConn.localPort.ToString();
            mParentDlg.AddResultItem("Successfully queried WIFI connection parameters", MessageType.Normal);
        }

        internal void OnRecvQueryWifiAPInfo(RfidReader reader, CWifiAPInfo wifiAPInfo)
        {
            if (wifiAPInfo.bEnable)
            {
                skinCheckBox_AP_Enable.Checked = true;
            }
            else
            {
                skinCheckBox_AP_Enable.Checked = false;
            }
            skinTextBox_AP_SSID.Text = wifiAPInfo.ssid;
            skinTextBox_AP_Passwd.Text = wifiAPInfo.password;
            if (wifiAPInfo.channelid == 0)
            {
                skinComboBox_AP_Channel.SelectedIndex = -1;
            }
            else if (wifiAPInfo.channelid - 1 < skinComboBox_AP_Channel.Items.Count)
            {
                skinComboBox_AP_Channel.SelectedIndex = wifiAPInfo.channelid - 1;
            }
            else
            {
                skinComboBox_AP_Channel.SelectedIndex = -1;
            }
            if (wifiAPInfo.encryptType < skinComboBox_AP_Encrypt.Items.Count)
            {
                skinComboBox_AP_Encrypt.SelectedIndex = wifiAPInfo.encryptType;
            }
            else
            {
                skinComboBox_AP_Encrypt.SelectedIndex = -1;
            }
            mParentDlg.AddResultItem("Successfully queried WIFI AP parameters", MessageType.Normal);
        }

        internal void OnRecvQueryWifiStaInfo(RfidReader reader, CWifiStaInfo wifiStaInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (wifiStaInfo.bEnable)
            {
                skinCheckBox_sta_enable.Checked = true;
            }
            else
            {
                skinCheckBox_sta_enable.Checked = false;
            }
            skinTextBox_sta_ssid.Text = wifiStaInfo.ssid;
            skinTextBox_sta_passwd.Text = wifiStaInfo.password;
            if (wifiStaInfo.dhcpMode != 0)
            {
                skinComboBox_sta_ip_mode.SelectedIndex = 0;
            }
            else
            {
                skinComboBox_sta_ip_mode.SelectedIndex = 1;
            }
            stringBuilder.Clear();
            if (wifiStaInfo.ipMode == 0)
            {
                stringBuilder.Clear();
                stringBuilder.AppendFormat("{0:X2}:{1:X2}:{2:X2}:{3:X2}:{4:X2}:{5:X2}", wifiStaInfo.bassid[0], wifiStaInfo.bassid[1], wifiStaInfo.bassid[2], wifiStaInfo.bassid[3], wifiStaInfo.bassid[4], wifiStaInfo.bassid[5]);
                skinTextBox_sta_baseid.Text = stringBuilder.ToString();
                stringBuilder.Clear();
                stringBuilder.AppendFormat("{0:d}.{1:d}.{2:d}.{3:d}", wifiStaInfo.ipAddr[0], wifiStaInfo.ipAddr[1], wifiStaInfo.ipAddr[2], wifiStaInfo.ipAddr[3]);
                skinTextBox_sta_ip.Text = stringBuilder.ToString();
                stringBuilder.Clear();
                stringBuilder.AppendFormat("{0:d}.{1:d}.{2:d}.{3:d}", wifiStaInfo.netmask[0], wifiStaInfo.netmask[1], wifiStaInfo.netmask[2], wifiStaInfo.netmask[3]);
                skinTextBox_sta_ip_netmask.Text = stringBuilder.ToString();
                stringBuilder.Clear();
                stringBuilder.AppendFormat("{0:d}.{1:d}.{2:d}.{3:d}", wifiStaInfo.gateway[0], wifiStaInfo.gateway[1], wifiStaInfo.gateway[2], wifiStaInfo.gateway[3]);
                skinTextBox_sta_ip_gateway.Text = stringBuilder.ToString();
            }
            mParentDlg.AddResultItem("Successfully queried WIFI STA parameters", MessageType.Normal);
        }
    }
}
