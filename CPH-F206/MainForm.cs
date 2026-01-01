using CPH_F206.RfidSDK;
using CPH_F206.FormTabs;
using System.ComponentModel;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206
{
    public partial class MainForm : Form
    {
        private string default_serial_num = "";
        private const string ini_file_name = "Configure.ini";
        public string sys_init_path = "";
        public M100Window m100Windows;
        public WifiWindow mWifiWindows;
        public HCWifiWindow mHCWifiWindows;
        private RfidReader reader;
        private RfidRspNotify rfidNotify;
        private Connect_Status connect_status;

        private TcpServerWindows serverWindows;

        public MainForm()
        {
            InitializeComponent();
        }

        public void ListLocalEthernetInterface()
        {
            skinComboBox_net_local_ip.Items.Clear();
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                for (int i = 0; i < hostEntry.AddressList.Length; i++)
                {
                    if (AddressFamily.InterNetwork == hostEntry.AddressList[i].AddressFamily)
                    {
                        skinComboBox_net_local_ip.Items.Add(hostEntry.AddressList[i].ToString());
                    }
                }
                skinComboBox_net_local_ip.SelectedIndex = skinComboBox_net_local_ip.Items.Count - 1;
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            sys_init_path = Environment.CurrentDirectory + "\\Configure.ini";
            int result = 0;
            skinComboBox_interface.SelectedIndex = 0;
            rfidNotify = new RfidRspNotify(this);
            RfidReaderManager.Instance();
            try
            {
                if (!new FileInfo(sys_init_path).Exists)
                {
                    new StreamWriter(sys_init_path, append: false, Encoding.Default).Close();
                    InitSysIniFile(sys_init_path);
                }
            }
            catch
            {
            }
            string s = CIniFile.ReadIniKeys("configure", "interface", sys_init_path);
            if (int.TryParse(s, out result))
            {
                skinComboBox_interface.SelectedIndex = ((result < skinComboBox_interface.Items.Count) ? result : (skinComboBox_interface.Items.Count - 1));
            }
            else
            {
                skinComboBox_interface.SelectedIndex = 0;
            }
            skinButton_fresh_Click(sender, e);
            s = CIniFile.ReadIniKeys("configure", "net_protocol", sys_init_path);
            if (int.TryParse(s, out result))
            {
                skinComboBox_net_protocol.SelectedIndex = ((result > skinComboBox_interface.Items.Count) ? (skinComboBox_interface.Items.Count - 1) : result);
            }
            else
            {
                skinComboBox_net_protocol.SelectedIndex = 0;
            }
            s = CIniFile.ReadIniKeys("configure", "remoteIP", sys_init_path);
            skinWaterTextBox_remote_ip.Text = s;
            s = CIniFile.ReadIniKeys("configure", "remotePort", sys_init_path);
            skinWaterTextBox_remote_port.Text = s;
            s = CIniFile.ReadIniKeys("configure", "localPort", sys_init_path);
            skinWaterTextBox_local_port.Text = s;
            skinComboBox_baudrate.SelectedIndex = 4;
            ListLocalEthernetInterface();
            if (skinComboBox_net_local_ip.Items.Count != 0)
            {
                s = CIniFile.ReadIniKeys("configure", "net_interface", sys_init_path);
                if (int.TryParse(s, out result))
                {
                    skinComboBox_net_local_ip.SelectedIndex = ((result >= skinComboBox_net_local_ip.Items.Count) ? (skinComboBox_net_local_ip.Items.Count - 1) : result);
                }
                else
                {
                    skinComboBox_net_local_ip.SelectedIndex = 0;
                }
            }
            Logger.Info("=================Program initialize compelete====================");
        }

        private void InitSysIniFile(string ini_file_path)
        {
            CIniFile.WriteIniKeys("app", "app_name", "UHF RFID Demo", ini_file_path);
            CIniFile.WriteIniKeys("configure", "serial_port_num", "0", ini_file_path);
            CIniFile.WriteIniKeys("configure", "interface", "0", ini_file_path);
            CIniFile.WriteIniKeys("configure", "remoteIP", "192.168.1.2", ini_file_path);
            CIniFile.WriteIniKeys("configure", "localPort", "9000", ini_file_path);
            CIniFile.WriteIniKeys("configure", "remotePort", "9000", ini_file_path);
            CIniFile.WriteIniKeys("configure", "serial_port_num", "COM1", ini_file_path);
            CIniFile.WriteIniKeys("configure", "net_protocol", "0", ini_file_path);
            CIniFile.WriteIniKeys("configure", "net_interface", "0", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteHexData", "E2 00 01 02 03 04 05 06 07 08 09 0A", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteWiegandData", "1234", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteAutoInfo", "3", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteFilePath", "", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteFileData", "", ini_file_path);
            CIniFile.WriteIniKeys("INFO", "WriteFileStartLine", "1", ini_file_path);
        }

        private void skinButton_fresh_Click(object sender, EventArgs e)
        {
            int num = 0;
            default_serial_num = CIniFile.ReadIniKeys("configure", "serial_port_num", sys_init_path);
            string[] portNames = SerialPort.GetPortNames();
            skinComboBox_serial_port.Items.Clear();
            if (portNames.Length == 0)
            {
                return;
            }
            for (num = 0; num < portNames.Length; num++)
            {
                skinComboBox_serial_port.Items.Add(portNames[num]);
                if (portNames[num].Equals(default_serial_num))
                {
                    skinComboBox_serial_port.SelectedIndex = num;
                }
            }
        }

        public void AddResultItem(string text, MessageType messageType)
        {
            if (listView_result.Items.Count >= 100)
            {
                listView_result.Items.Clear();
            }
            ListViewItem listViewItem = new ListViewItem();
            string text2 = DateTime.Now.ToLongTimeString();
            listViewItem.Text = text2;
            listViewItem.SubItems.Add(text);
            if (messageType == MessageType.Error)
            {
                listViewItem.ForeColor = Color.Red;
                listViewItem.SubItems[1].ForeColor = Color.Red;
            }
            listView_result.Items.Add(listViewItem);
            listView_result.Items[listView_result.Items.Count - 1].EnsureVisible();
        }

        public void OnRecvWriteTagResult(int result)
        {
            if (result == 0)
            {
                if ((m100Windows.autoIncreseFlag != 0 || m100Windows.autoWriteMode != 0) && m100Windows.GetCurTagPageIndex() == 6)
                {
                    m100Windows.OnRecvAutoWriteHexTag(result);
                }
                else if (m100Windows.mFileWriteMode > 0)
                {
                    m100Windows.OnRecvFileWriteEpc(result);
                }
                else
                {
                    AddResultItem("Tag data was successfully written.", MessageType.Normal);
                }
            }
            else
            {
                AddResultItem("Data write failed [" + result + "].", MessageType.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (skinComboBox_serial_port.SelectedItem != null)
            {
                CIniFile.WriteIniKeys("configure", "serial_port_num", skinComboBox_serial_port.SelectedItem.ToString(), sys_init_path);
            }
            CIniFile.WriteIniKeys("configure", "interface", skinComboBox_interface.SelectedIndex.ToString(), sys_init_path);
            CIniFile.WriteIniKeys("configure", "remoteIP", skinWaterTextBox_remote_ip.Text, sys_init_path);
            CIniFile.WriteIniKeys("configure", "remotePort", skinWaterTextBox_remote_port.Text.ToString(), sys_init_path);
            CIniFile.WriteIniKeys("configure", "localPort", skinWaterTextBox_local_port.Text.ToString(), sys_init_path);
            CIniFile.WriteIniKeys("configure", "net_protocol", skinComboBox_net_protocol.SelectedIndex.ToString(), sys_init_path);
            CIniFile.WriteIniKeys("configure", "net_interface", skinComboBox_net_local_ip.SelectedIndex.ToString(), sys_init_path);
            if (m100Windows != null)
            {
                m100Windows.SaveParam();
                m100Windows.OnClose();
            }
            RfidReaderManager.Instance().DeleteAllReader();
        }

        public void UnableButton()
        {
            skinButton_fresh.Enabled = false;
        }

        public void EnableButton()
        {
            skinButton_fresh.Enabled = true;
        }

        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox_interface.SelectedIndex == 0)
            {
                skinPanel_serialport.Show();
                skinPanel_network.Hide();
                skinPanel_USB_Connect.Hide();
            }
            else if (skinComboBox_interface.SelectedIndex == 1)
            {
                skinPanel_network.Show();
                skinPanel_serialport.Hide();
                skinPanel_USB_Connect.Hide();
            }
            else if (skinComboBox_interface.SelectedIndex == 2)
            {
                skinPanel_USB_Connect.Show();
                skinPanel_serialport.Hide();
                skinPanel_network.Hide();
            }
        }

        public void DisplayM100Window()
        {
            if (m100Windows == null)
            {
                m100Windows = new M100Window();
            }
            if (serverWindows != null)
            {
                serverWindows.Hide();
            }
            if (mWifiWindows != null)
            {
                mWifiWindows.Hide();
            }
            if (mHCWifiWindows != null)
            {
                mHCWifiWindows.Hide();
            }
            m100Windows.TopLevel = false;
            m100Windows.Parent = this;
            m100Windows.SetParentWindow(this);
            skinPictureBox_welcom.Controls.Add(m100Windows);
            m100Windows.SetReader(reader);
            m100Windows.Show();
        }

        public void DisplayWifiWindow()
        {
            if (mHCWifiWindows == null)
            {
                mHCWifiWindows = new HCWifiWindow();
            }
            if (m100Windows != null)
            {
                m100Windows.Hide();
            }
            if (serverWindows != null)
            {
                serverWindows.Hide();
            }
            mHCWifiWindows.SetReader(reader);
            mHCWifiWindows.SetParentDlg(this);
            mHCWifiWindows.TopLevel = false;
            mHCWifiWindows.Parent = this;
            skinPictureBox_welcom.Controls.Add(mHCWifiWindows);
            mHCWifiWindows.SetReader(reader);
            mHCWifiWindows.Show();
        }

        public void DisplayServerWindow()
        {
            if (mHCWifiWindows != null)
            {
                mHCWifiWindows.Hide();
            }
            if (m100Windows != null)
            {
                m100Windows.Hide();
            }
            if (serverWindows == null)
            {
                serverWindows = new TcpServerWindows();
            }
            serverWindows.SetMainWin(this);
            serverWindows.TopLevel = false;
            serverWindows.Parent = this;
            skinPictureBox_welcom.Controls.Add(serverWindows);
            serverWindows.Show();
        }

        public static string GetLocalIP(IPAddress remoteAddress)
        {
            byte[] addressBytes = remoteAddress.GetAddressBytes();
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                for (int i = 0; i < hostEntry.AddressList.Length; i++)
                {
                    num2 = 0;
                    if (hostEntry.AddressList[i].AddressFamily != remoteAddress.AddressFamily)
                    {
                        continue;
                    }
                    byte[] addressBytes2 = hostEntry.AddressList[i].GetAddressBytes();
                    for (int j = 0; j < addressBytes.Length; j++)
                    {
                        if (addressBytes[j] == addressBytes2[j])
                        {
                            num2++;
                        }
                    }
                    if (num2 > num3)
                    {
                        num3 = num2;
                        num = i;
                    }
                }
                return hostEntry.AddressList[num].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void skinButton_connect_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (serverWindows != null)
            {
                serverWindows.Close();
                serverWindows = null;
            }
            if (reader != null)
            {
                RfidReaderManager.Instance().ReleaseRfidReader(reader);
                reader = null;
            }
            if (connect_status != 0)
            {
                connect_status = Connect_Status.Status_Idl;
                skinButton_net_scan.Enabled = true;
                skinButton_tcp_server.Enabled = true;
                skinButton_connect.Text = "Connect";
                if (m100Windows != null)
                {
                    m100Windows.Close();
                    m100Windows = null;
                }
                skinPictureBox_welcom.Visible = true;
                reader = null;
            }
            else if (skinComboBox_interface.SelectedIndex == 0)
            {
                string text = skinComboBox_serial_port.Text;
                if (text == null || text.Length == 0)
                {
                    AddResultItem("you have not select one connect type", MessageType.Error);
                    return;
                }
                if (skinComboBox_baudrate.SelectedItem == null)
                {
                    AddResultItem("please select the baud rate of serial port", MessageType.Error);
                    return;
                }
                connect_status = Connect_Status.Status_Connecting;
                skinButton_connect.Text = "Cancel";
                num = int.Parse(skinComboBox_baudrate.SelectedItem.ToString());
                reader = RfidReaderManager.Instance().CreateReaderInSerialPort(text, num, rfidNotify);
                if (reader != null)
                {
                    reader.QueryDeviceInfo();
                }
                else
                {
                    AddResultItem("Fail to add a pyhsical conncet to reader.", MessageType.Error);
                }
            }
            else if (skinComboBox_interface.SelectedIndex == 1)
            {
                string text2 = skinWaterTextBox_remote_ip.Text;
                ushort readerPort = ushort.Parse(skinWaterTextBox_remote_port.Text);
                ushort result = 0;
                string text3 = null;
                if (skinComboBox_net_local_ip.SelectedIndex >= 0)
                {
                    text3 = skinComboBox_net_local_ip.Items[skinComboBox_net_local_ip.SelectedIndex].ToString();
                }
                if (skinWaterTextBox_local_port.Text.Trim().Length > 0)
                {
                    result = ushort.Parse(skinWaterTextBox_local_port.Text);
                }
                _ = skinComboBox_net_protocol.SelectedIndex;
                if (!IPAddress.TryParse(text2, out var address))
                {
                    AddResultItem("The IP address is error format.", MessageType.Error);
                    return;
                }
                string localIP = GetLocalIP(address);
                reader = new MSerialReader(rfidNotify);
                connect_status = Connect_Status.Status_Connecting;
                TransportType type;
                if (skinComboBox_net_protocol.SelectedIndex == 0)
                {
                    type = TransportType.UDP;
                }
                else
                {
                    if (skinWaterTextBox_local_port.Text.Trim().Length == 0)
                    {
                        result = 0;
                    }
                    else
                    {
                        if (!ushort.TryParse(skinWaterTextBox_local_port.Text.Trim(), out result))
                        {
                            result = 0;
                        }
                        type = TransportType.TcpClient;
                    }
                    type = TransportType.TcpClient;
                }
                localIP = text3;
                reader = RfidReaderManager.Instance().CreateReaderInNet(localIP, result, text2, readerPort, type, rfidNotify);
                if (reader != null)
                {
                    reader.QueryDeviceInfo();
                    skinButton_connect.Text = "Cancel";
                }
                else
                {
                    connect_status = Connect_Status.Status_Idl;
                    AddResultItem("Fail to add a pyhsical conncet to reader.", MessageType.Error);
                }
            }
            else
            {
                _ = skinComboBox_interface.SelectedIndex;
                _ = 2;
            }
        }

        public void SetNetInfo(string device_ip, string port, string local_port, string transport_mode)
        {
            skinWaterTextBox_remote_ip.Text = device_ip;
            skinWaterTextBox_remote_port.Text = port;
            skinWaterTextBox_local_port.Text = local_port;
            if (transport_mode.Equals("UDP"))
            {
                skinComboBox_net_protocol.SelectedIndex = 0;
            }
            else if (transport_mode.Equals("TCP Server"))
            {
                skinComboBox_net_protocol.SelectedIndex = 1;
            }
            else if (transport_mode.Equals("TCP Client"))
            {
                AddResultItem("The reader act as TCP client.Please click TCP Server button and set listen port " + local_port.ToString() + " to receive data.", MessageType.Normal);
            }
            else if (transport_mode.Equals("RS232") || transport_mode.Equals("RS485"))
            {
                AddResultItem("The reader transmits the tag data through the serial port.", MessageType.Normal);
            }
        }

        private void skinButton_net_scan_Click(object sender, EventArgs e)
        {
            ScanWindow scanWindow = new ScanWindow(this);
            scanWindow.Parent = this;
            scanWindow.StartPosition = FormStartPosition.CenterParent;
            scanWindow.FormBorderStyle = FormBorderStyle.FixedDialog;
            scanWindow.MaximizeBox = false;
            scanWindow.MinimizeBox = false;
            scanWindow.ShowInTaskbar = false;
            scanWindow.ShowDialog(this);
        }

        private void skinButton_tcp_server_Click(object sender, EventArgs e)
        {
            DisplayServerWindow();
        }

        public void BackToConnectMode()
        {
            RfidReaderManager.Instance().ReleaseRfidReader(reader);
            reader = null;
            connect_status = Connect_Status.Status_Idl;
            skinButton_net_scan.Enabled = true;
            skinButton_tcp_server.Enabled = true;
            skinButton_connect.Text = "Connect";
            if (m100Windows != null)
            {
                m100Windows.Close();
                m100Windows = null;
            }
            skinPictureBox_welcom.Visible = true;
        }

        public void OnRecvReaderResetRsp(RfidReader reader, byte status)
        {
            if (reader == this.reader)
            {
                if (status == 0)
                {
                    BackToConnectMode();
                    AddResultItem("Success to reset the reader,please reconnect.", MessageType.Normal);
                }
                else
                {
                    AddResultItem("Fail to restore factory settings,please reconnect reader.", MessageType.Error);
                }
            }
        }

        public void OnRecvReaderRestorFactorySettingRsp(RfidReader reader, byte status)
        {
            if (reader == this.reader)
            {
                if (status == 0)
                {
                    BackToConnectMode();
                    AddResultItem("Success to restore factory settings,please reconnect reader.", MessageType.Normal);
                }
                else
                {
                    AddResultItem("Fail to restore factory settings,please reconnect reader.", MessageType.Error);
                }
            }
        }

        public void OnRecvReaderDeviceInfoRsp(byte[] firmware, byte type)
        {
            int num = 0;
            DisplayM100Window();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Clear();
            skinButton_net_scan.Enabled = false;
            skinButton_tcp_server.Enabled = false;
            skinButton_connect.Text = "Disconnect";
            connect_status = Connect_Status.Status_Connected;
            stringBuilder.Append("The reader's firmware version :");
            for (num = 0; num < firmware.Length; num++)
            {
                stringBuilder.Append(firmware[num]);
                if (num != firmware.Length - 1)
                {
                    stringBuilder.Append(".");
                }
                else
                {
                    stringBuilder.Append(",");
                }
            }
            stringBuilder.Append("Type:");
            stringBuilder.Append(type);
            AddResultItem(stringBuilder.ToString(), MessageType.Normal);
        }

        public void OnRecvReaderQueryWorkParamRsp(RfidReader reader, byte status, RfidWorkParam workParam)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (status == 0)
                {
                    m100Windows.OnRecvWorkingParamRep(workParam);
                    AddResultItem("Success to query working parameters.", MessageType.Normal);
                }
                else
                {
                    AddResultItem("Fail to query working parameters.", MessageType.Error);
                }
            }
        }

        public void OnRecvReaderQueryTransmissionRsp(RfidReader reader, byte status, RfidTransmissionParam transParam)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (status == 0)
                {
                    m100Windows.FreshTransmissionParam(transParam);
                    AddResultItem("Success to query transmission parameter.", MessageType.Normal);
                }
                else
                {
                    AddResultItem("Fail to query transmission parameter.", MessageType.Error);
                }
            }
        }

        public void OnRecvReaderQueryAdvanceRsp(RfidReader reader, byte status, RfidAdvanceParam advanceParam)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (status == 0)
                {
                    m100Windows.FreshAdvanceParam(advanceParam);
                    AddResultItem("Success to query advance parameter.", MessageType.Normal);
                }
                else
                {
                    AddResultItem("Fail to query advance parameter.", MessageType.Error);
                }
            }
        }

        public void OnRecvWriteWiegandNumberRsp(RfidReader reader, byte status)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (m100Windows.autoWriteMode != 0 || m100Windows.autoIncreseFlag != 0)
                {
                    m100Windows.OnRecvAutoWriteRsp(status);
                    return;
                }
                if (status == 0)
                {
                    AddResultItem("Success to write Wiegand number.", MessageType.Normal);
                    return;
                }
                string text = string.Format("Fail to write Wiegand number.Status code:" + status.ToString("X2"));
                AddResultItem(text, MessageType.Error);
            }
        }

        public void OnRecvReaderQuerySingleParamRsp(RfidReader reader, TlvValueItem item)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (item == null)
                {
                    AddResultItem("Fail to query advance parameter.", MessageType.Normal);
                }
                else
                {
                    m100Windows.OnRecvQuerySingleParam(item);
                }
            }
        }

        public void OnRecvTagNotify(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
            if (reader == this.reader && m100Windows != null)
            {
                if (tlvItems == null || tlvCount == 0)
                {
                    AddResultItem("Failed to read tag.", MessageType.Error);
                }
                else
                {
                    m100Windows.InsertTagRecord(reader, tlvItems, tlvCount);
                }
            }
        }

        public void OnRecvRecordNotify(RfidReader reader, string time, string tagId)
        {
            if (reader == this.reader && m100Windows != null)
            {
                m100Windows.OnRecvRecordNodtify(reader, time, tagId);
            }
        }

        public void OnRecvReadTagBlockNotify(RfidReader reader, byte result, byte[] data, byte[] epc_data)
        {
            string text = "";
            if (result == 0)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    text += data[i].ToString("X2");
                    text += " ";
                }
                m100Windows.OnOperationResult(text.Trim());
                if (epc_data != null)
                {
                    text = "";
                    for (int j = 0; j < epc_data.Length; j++)
                    {
                        text += epc_data[j].ToString("X2");
                        text += " ";
                    }
                    AddResultItem("EPC:" + text.Trim(), MessageType.Normal);
                }
            }
            else
            {
                AddResultItem("Fail to read the tag's block.", MessageType.Error);
            }
        }

        private void skinComboBox_deviceusb_list_MouseClick(object sender, MouseEventArgs e)
        {
            skinComboBox_deviceusb_list.Items.Clear();
            List<string> deviceList = new List<string>();
            HID.GetHidDeviceList(ref deviceList);
            if (deviceList.Count <= 0)
            {
                return;
            }
            foreach (string item in deviceList)
            {
                skinComboBox_deviceusb_list.Items.Add(item);
            }
        }

        private void skinButton_fun_main_Click(object sender, EventArgs e)
        {
            DisplayM100Window();
        }

        private void skinButton_fun_wifi_Click(object sender, EventArgs e)
        {
            DisplayWifiWindow();
        }
    }
}
