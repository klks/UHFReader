using CPH_F206.RfidSDK;
using CPH_F206.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace CPH_F206.FormTabs
{    
    public partial class TcpServerWindows : Form
    {
        private RfidTcpServer tcpServer;
        private MainForm mainWin;
        private Dictionary<string, ClientListViewItem> tcpClients = new Dictionary<string, ClientListViewItem>();
        private Dictionary<string, TagItem> tagDictionary = new Dictionary<string, TagItem>();

        public TcpServerWindows()
        {
            InitializeComponent();
            ListLocalEthernetInterface();
            skinWaterTextBox_listen_port.Text = "9000";
            tcpServer = new RfidTcpServer();
            tcpServer.ClientConnected += OnNewConnected;
            tcpServer.DataReceived += OnRecvDataFromReader;
            tcpServer.ClientDisconnected += OnDisConnectConnected;
            tcpClients.Clear();
            skinButton_stop.Enabled = false;
        }

        public void SetMainWin(MainForm mainwin)
        {
            mainWin = mainwin;
        }

        public void ListLocalEthernetInterface()
        {
            skinComboBox_pc_interface.Items.Clear();
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                for (int i = 0; i < hostEntry.AddressList.Length; i++)
                {
                    if (AddressFamily.InterNetwork == hostEntry.AddressList[i].AddressFamily)
                    {
                        skinComboBox_pc_interface.Items.Add(hostEntry.AddressList[i].ToString());
                    }
                }
                skinComboBox_pc_interface.SelectedIndex = skinComboBox_pc_interface.Items.Count - 1;
            }
            catch (Exception)
            {
            }
        }

        public void AddConnectedRecord(AsyncSocketEventArgs client)
        {
            Socket clientSocket = client._state.ClientSocket;
            ClientListViewItem value = null;
            string key = (clientSocket.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" + (clientSocket.RemoteEndPoint as IPEndPoint).Port;
            try
            {
                tcpClients.TryGetValue(key, out value);
            }
            catch (Exception)
            {
            }
            if (value == null)
            {
                ListViewItem listViewItem = new ListViewItem();
                value = new ClientListViewItem();
                value.item = listViewItem;
                listViewItem.SubItems.Add((clientSocket.RemoteEndPoint as IPEndPoint).Address.ToString());
                listViewItem.SubItems.Add((clientSocket.RemoteEndPoint as IPEndPoint).Port.ToString());
                listViewItem.SubItems.Add(DateTime.Now.ToLongTimeString());
                skinListView_ip_list.Items.Add(listViewItem);
                tcpClients.Add(key, value);
            }
        }

        public void OnNewConnected(object sender, EventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                mainWin.AddResultItem("A new connect is arrive.", MessageType.Normal);
                AsyncSocketEventArgs client = (AsyncSocketEventArgs)e;
                AddConnectedRecord(client);
            });
        }

        public void HandleDisconnect(AsyncSocketEventArgs client)
        {
            Socket clientSocket = client._state.ClientSocket;
            ClientListViewItem value = null;
            string text = (clientSocket.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" + (clientSocket.RemoteEndPoint as IPEndPoint).Port;
            try
            {
                tcpClients.TryGetValue(text, out value);
            }
            catch (Exception)
            {
            }
            if (value != null)
            {
                mainWin.AddResultItem(text + " disconnect.", MessageType.Normal);
                skinListView_ip_list.Items.Remove(value.item);
                tcpClients.Remove(text);
            }
        }

        public void OnDisConnectConnected(object sender, EventArgs e)
        {
            Invoke((EventHandler)delegate
            {
                AsyncSocketEventArgs client = (AsyncSocketEventArgs)e;
                HandleDisconnect(client);
            });
        }

        private void skinButton_listen_Click(object sender, EventArgs e)
        {
            if (skinWaterTextBox_listen_port.Text.Length == 0)
            {
                mainWin.AddResultItem("Please input listen port.", MessageType.Error);
                return;
            }
            skinListView_ip_list.Items.Clear();
            skinListView_tags.Items.Clear();
            ushort result = 0;
            ushort.TryParse(skinWaterTextBox_listen_port.Text, out result);
            tcpServer.SetServerAddress(skinComboBox_pc_interface.SelectedItem.ToString(), result, 128);
            try
            {
                tcpServer.Start();
            }
            catch (Exception ex)
            {
                mainWin.AddResultItem(ex.ToString(), MessageType.Error);
                return;
            }
            skinButton_stop.Enabled = true;
            skinButton_listen.Enabled = false;
            mainWin.AddResultItem("Start Listen.....", MessageType.Normal);
        }

        private void DisplayOneTag(string text, byte rssi, string readerIp)
        {
            TagItem value = null;
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.ForeColor = Color.BurlyWood;
            string key = readerIp + ":" + text;
            try
            {
                tagDictionary.TryGetValue(key, out value);
            }
            catch (ArgumentNullException)
            {
            }
            if (value != null)
            {
                value.mReadTimes++;
                value.viewItem.SubItems[3].Text = rssi.ToString("X2");
                value.viewItem.SubItems[4].Text = value.mReadTimes.ToString();
                return;
            }
            value = new TagItem();
            listViewItem.Text = DateTime.Now.ToLongTimeString();
            listViewItem.SubItems.Add(readerIp);
            listViewItem.SubItems.Add(text);
            listViewItem.SubItems.Add(rssi.ToString("X2"));
            listViewItem.SubItems.Add("1");
            value.viewItem = listViewItem;
            value.mReadTimes = 1;
            value.viewItem = skinListView_tags.Items.Add(listViewItem);
            tagDictionary.Add(key, value);
            skinListView_tags.Items[skinListView_tags.Items.Count - 1].EnsureVisible();
        }

        public void InsertOneTagRecord(byte[] message, int messageLen, string readerAddress)
        {
            int i = 0;
            int num = 0;
            byte rssi = 0;
            int num2 = 0;
            byte b = 0;
            byte b2 = 0;
            string text = "";
            if (message[8] != 80)
            {
                return;
            }
            num = 10;
            for (; i < message[9]; i += b2 + 2)
            {
                b2 = message[num + i + 1];
                if (message[num + i] == 1)
                {
                    num2 = num + i + 2;
                    b = message[num + i + 1];
                }
                else if (message[num + i] == 5)
                {
                    rssi = message[num + i + 2];
                }
            }
            if (num2 != 0)
            {
                for (i = 0; i < b; i++)
                {
                    text += message[num2 + i].ToString("X2");
                }
                DisplayOneTag(text, rssi, readerAddress);
            }
        }

        public void HandleHearBeats(AsyncSocketEventArgs arg)
        {
            Socket clientSocket = arg._state.ClientSocket;
            ClientListViewItem value = null;
            string key = (clientSocket.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" + (clientSocket.RemoteEndPoint as IPEndPoint).Port;
            try
            {
                tcpClients.TryGetValue(key, out value);
            }
            catch (Exception)
            {
            }
            if (value != null)
            {
                value.item.SubItems[3].Text = DateTime.Now.ToLongTimeString();
            }
        }

        public void HandleRecvData(AsyncSocketEventArgs arg)
        {
            byte[] recvBuffer = arg._state._recvBuffer;
            int messageLen = arg._state._messageLen;
            if (recvBuffer[2] == 2 && 128 == recvBuffer[5])
            {
                string readerAddress = (arg._state.ClientSocket.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" + (arg._state.ClientSocket.RemoteEndPoint as IPEndPoint).Port;
                InsertOneTagRecord(recvBuffer, messageLen, readerAddress);
            }
            else if (recvBuffer[2] == 2 && 144 == recvBuffer[5])
            {
                Invoke((EventHandler)delegate
                {
                    HandleHearBeats(arg);
                });
            }
        }

        public void OnRecvDataFromReader(object sender, EventArgs e)
        {
            try
            {
                Invoke((EventHandler)delegate
                {
                    AsyncSocketEventArgs arg = (AsyncSocketEventArgs)e;
                    HandleRecvData(arg);
                });
            }
            catch (Exception)
            {
            }
        }

        private void skinButton_stop_Click(object sender, EventArgs e)
        {
            tcpServer.Stop();
            skinButton_listen.Enabled = true;
            skinButton_stop.Enabled = false;
            mainWin.AddResultItem("The Server stop working.", MessageType.Normal);
        }

        private void TcpServerWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            tcpServer.Stop();
        }
    }
}
