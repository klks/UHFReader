using CPH_F206.RfidSDK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CPH_F206.FormTabs
{
    public partial class ScanWindow : Form
    {
        private bool start;

        private ScanReaderImpl rfidNotifyImpl;

        private RfidReader reader;

        private System.Timers.Timer scanTimer;

        private System.Timers.Timer ResetTimer;

        private string[] transport_type = new string[4] { "RS232/RS485", "Wiegand", "RJ45", "SYRIS485" };

        private bool endThread;

        private Dictionary<string, string> hashMap = new Dictionary<string, string>();

        private MainForm mainWin;

        public ScanWindow(MainForm mainwin)
        {
            InitializeComponent();
            mainWin = mainwin;
            rfidNotifyImpl = new ScanReaderImpl();
            rfidNotifyImpl.SetScanWind(this);
            ListLocalEthernetInterface();
            skinProgressIndicator_scan_flag.Visible = false;
            skinProgressIndicator_scan_flag.Style = ProgressBarStyle.Marquee;
            scanTimer = new System.Timers.Timer(1500.0);
            scanTimer.Elapsed += theout;
            scanTimer.AutoReset = true;
            ResetTimer = new System.Timers.Timer(1500.0);
            ResetTimer.Elapsed += ResetAllReader;
            ResetTimer.AutoReset = true;
            skinWaterTextBox_port.Text = "6000";
            EnableButton();
        }

        public void EnableButton()
        {
            skinButton_scan.Enabled = true;
            skinButton_stop.Enabled = false;
            skinButton_all_reset.Enabled = true;
        }

        public void UnableButton()
        {
            skinButton_scan.Enabled = false;
            skinButton_stop.Enabled = true;
            skinButton_all_reset.Enabled = false;
        }

        public void theout(object source, ElapsedEventArgs e)
        {
            reader.QueryTransferParam();
        }

        public void ResetAllReader(object source, ElapsedEventArgs e)
        {
            reader.ResetReader();
        }

        public void ListLocalEthernetInterface()
        {
            skinComboBox_interface.Items.Clear();
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                for (int i = 0; i < hostEntry.AddressList.Length; i++)
                {
                    if (AddressFamily.InterNetwork == hostEntry.AddressList[i].AddressFamily)
                    {
                        skinComboBox_interface.Items.Add(hostEntry.AddressList[i].ToString());
                    }
                }
                skinComboBox_interface.SelectedIndex = skinComboBox_interface.Items.Count - 1;
            }
            catch (Exception)
            {
            }
        }

        public void AddOneRecord(byte[] ip, ushort port, byte[] mac, byte type, ushort local_port)
        {
            ListViewItem listViewItem = new ListViewItem();
            StringBuilder stringBuilder = new StringBuilder();
            listViewItem.Text = "";
            int num = 0;
            stringBuilder.Clear();
            for (num = 0; num < 4; num++)
            {
                stringBuilder.Append(ip[num].ToString());
            }
            for (num = 0; num < 6; num++)
            {
                stringBuilder.Append(mac[num].ToString("X2"));
            }
            if (hashMap.ContainsKey(stringBuilder.ToString()))
            {
                return;
            }
            hashMap.Add(stringBuilder.ToString(), "");
            stringBuilder.Clear();
            for (num = 0; num < 4; num++)
            {
                stringBuilder.Append(ip[num].ToString());
                if (num != 3)
                {
                    stringBuilder.Append(".");
                }
            }
            listViewItem.SubItems.Add(stringBuilder.ToString());
            stringBuilder.Clear();
            for (num = 0; num < 6; num++)
            {
                stringBuilder.Append(mac[num].ToString("X2"));
                if (num != 5)
                {
                    stringBuilder.Append(":");
                }
            }
            listViewItem.SubItems.Add(stringBuilder.ToString());
            listViewItem.SubItems.Add(port.ToString());
            if (type < 8)
            {
                listViewItem.SubItems.Add(transport_type[type]);
            }
            else
            {
                listViewItem.SubItems.Add("unkonw:" + type);
            }
            listViewItem.SubItems.Add(local_port.ToString());
            skinListView_devices.Items.Add(listViewItem);
            skinListView_devices.Items[skinListView_devices.Items.Count - 1].EnsureVisible();
        }

        private void skinButton_scan_Click(object sender, EventArgs e)
        {
            string selectedText = skinComboBox_interface.SelectedText;
            ushort localPort = 6000;
            if (skinWaterTextBox_port.Text.Length != 0)
            {
                skinListView_devices.Items.Clear();
                hashMap.Clear();
                ushort readerPort = ushort.Parse(skinWaterTextBox_port.Text);
                selectedText = skinComboBox_interface.SelectedItem.ToString();
                reader = RfidReaderManager.Instance().CreateReaderInNet(selectedText, localPort, "255.255.255.255", readerPort, TransportType.UDP, rfidNotifyImpl);
                if (reader != null)
                {
                    skinProgressIndicator_scan_flag.Visible = true;
                    start = true;
                    scanTimer.Start();
                    UnableButton();
                }
            }
        }

        public void ScanThread()
        {
            while (!endThread)
            {
                if (start)
                {
                    reader.HandleRecvData();
                }
            }
        }

        private void skinButton_stop_Click(object sender, EventArgs e)
        {
            scanTimer.Stop();
            ResetTimer.Stop();
            start = false;
            skinProgressIndicator_scan_flag.Visible = false;
            start = false;
            RfidReaderManager.Instance().ReleaseRfidReader(reader);
            reader = null;
            EnableButton();
        }

        public void OnRecvQueryTransferParamRep(RfidTransmissionParam transParam)
        {
            AddOneRecord(transParam.local_ip, transParam.local_port, transParam.mac_addr, transParam.ucTransferLink, transParam.remote_port);
        }

        public void OnRecvResetParam()
        {
            scanTimer.Stop();
            ResetTimer.Stop();
            start = false;
            skinProgressIndicator_scan_flag.Visible = false;
            start = false;
            RfidReaderManager.Instance().ReleaseRfidReader(reader);
            reader = null;
            EnableButton();
            MessageBox.Show("You have reset a reader's parameter.");
        }

        private void ScanWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            endThread = true;
            scanTimer.Stop();
            if (reader != null)
            {
                RfidReaderManager.Instance().ReleaseRfidReader(reader);
                reader = null;
            }
        }

        private void skinButton_set_Click(object sender, EventArgs e)
        {
            if (skinListView_devices.SelectedItems.Count != 0 && skinListView_devices.SelectedItems.Count <= 1 && mainWin != null)
            {
                RfidReaderManager.Instance().ReleaseRfidReader(reader);
                reader = null;
                mainWin.SetNetInfo(skinListView_devices.SelectedItems[0].SubItems[1].Text, skinListView_devices.SelectedItems[0].SubItems[3].Text, skinListView_devices.SelectedItems[0].SubItems[5].Text, skinListView_devices.SelectedItems[0].SubItems[4].Text);
                Close();
            }
        }

        private void skinButton_all_reset_Click(object sender, EventArgs e)
        {
            string selectedText = skinComboBox_interface.SelectedText;
            ushort localPort = 6000;
            if (skinWaterTextBox_port.Text.Length != 0)
            {
                skinListView_devices.Items.Clear();
                hashMap.Clear();
                ushort readerPort = ushort.Parse(skinWaterTextBox_port.Text);
                selectedText = skinComboBox_interface.SelectedItem.ToString();
                reader = RfidReaderManager.Instance().CreateReaderInNet(selectedText, localPort, "255.255.255.255", readerPort, TransportType.UDP, rfidNotifyImpl);
                if (reader != null)
                {
                    skinProgressIndicator_scan_flag.Visible = true;
                    start = true;
                    ResetTimer.Start();
                    UnableButton();
                }
            }
        }
    }
}
