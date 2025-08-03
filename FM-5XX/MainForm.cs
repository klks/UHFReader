using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FM_5XX
{
    public partial class MainForm : Form
    {
        [DllImport("psapi.dll")]
        private static extern int EmptyWorkingSet(IntPtr hwProc);

        private enum CommandStates
        {
            DEFAULT,
            INFO,
            EPC,
            TID,
            SELECT,
            PASSWORD,
            MULTI,
            READ,
            WRITE,
            LOCK,
            KILL,
            B02_MULTIREAD,
            B02_MULTIREAD_Q,
            B02_MULTI,
            B02_MULTI_Q,
            INV_EPC,
            INV_TID,
        }

        private ReaderService.Module.Version VersionFW;
        ReaderService? readerClient = null;
        private CommandStates DoProcess;
        private bool IsReceiveDataWork = false;
        private byte[] ReceiveData;
        private string Inventory_TID_Address = "0";
        private string Inventory_TID_Length = "6";

        public MainForm()
        {
            InitializeComponent();
            Init_ReaderUI();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (readerClient != null)
                readerClient.Dispose();
            readerClient = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void Reader_PopulateComPorts()
        {
            cbReader_COM.Items.Clear();
            var ports = ReaderService.GetCOMportList();
            foreach (string port in ports)
            {
                cbReader_COM.Items.Add(port);
            }
        }
        private void Init_ReaderUI()
        {
            Reader_PopulateComPorts();
            cb6C_MemBank.SelectedIndex = 1;
        }
        public void ClearMemory()
        {
            Process currentProcess = Process.GetCurrentProcess();
            try
            {
                EmptyWorkingSet(currentProcess.Handle);
            }
            catch
            {
            }
        }
        private void AddEPCToUI(string epcString)
        {
            if (epcString == "" || epcString.Length == 1) return;

            lvInventoryEPC.Invoke(new MethodInvoker(delegate
            {
                bool is_on_list = false;

                for (int i = 0; i < lvInventoryEPC.Items.Count; i++)
                {
                    if (epcString == lvInventoryEPC.Items[i].SubItems[2].Text)
                    {
                        //Update count
                        string strCount = lvInventoryEPC.Items[i].SubItems[4].Text;
                        lvInventoryEPC.Items[i].SubItems[4].Text = (int.Parse(strCount) + 1).ToString();
                        lvInventoryEPC.EnsureVisible(i);
                        is_on_list = true;
                    }
                }
                if (!is_on_list)
                {
                    ListViewItem item = lvInventoryEPC.Items.Add((lvInventoryEPC.Items.Count + 1).ToString());

                    string PCString = epcString.Substring(0, 4);
                    item.SubItems.Add(PCString);                                // 1 - PC
                    item.SubItems.Add(epcString);                               // 2 - EPC
                    item.SubItems.Add((epcString.Length / 2).ToString());       // 3 - EPC Length
                    item.SubItems.Add("1");                                     // 4 - Count
                    lvInventoryEPC.EnsureVisible(lvInventoryEPC.Items.Count - 1);
                }
            }));
        }
        private void AddTIDToUI(string tidString)
        {
            if (tidString == "" || tidString.Length == 1) return;

            lvInventoryTID.Invoke(new MethodInvoker(delegate
            {
                bool is_on_list = false;

                for (int i = 0; i < lvInventoryTID.Items.Count; i++)
                {
                    if (tidString == lvInventoryTID.Items[i].SubItems[1].Text)
                    {
                        //Update count
                        string strCount = lvInventoryTID.Items[i].SubItems[3].Text;
                        lvInventoryTID.Items[i].SubItems[3].Text = (int.Parse(strCount) + 1).ToString();
                        lvInventoryTID.EnsureVisible(i);
                        is_on_list = true;
                    }
                }
                if (!is_on_list)
                {
                    ListViewItem item = lvInventoryTID.Items.Add((lvInventoryTID.Items.Count + 1).ToString());

                    item.SubItems.Add(tidString);                               // 1 - TID
                    item.SubItems.Add((tidString.Length / 2).ToString());       // 2 - TID Length
                    item.SubItems.Add("1");                                     // 3 - Count
                    lvInventoryTID.EnsureVisible(lvInventoryTID.Items.Count - 1);
                }
            }));
        }
        private void DoReceiveDataWork(object sender, ReaderService.CombineDataReceiveArgument e)
        {
            string s_crlf = e.Data;
            switch (DoProcess)
            {
                case CommandStates.EPC:
                    if (s_crlf.IndexOf("U") != -1)
                    {
                        //OnB01ButtonReadEPCClick(null, null);
                        break;
                    }
                    IsReceiveDataWork = false;
                    // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //B01TextBoxEPC.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'Q');
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.TID:
                    if (s_crlf.IndexOf("U") != -1)
                    {
                        //OnB01ButtonTIDClick(null, null);
                        break;
                    }
                    IsReceiveDataWork = false;
                    //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //B01TextBoxTID.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.SELECT:
                    IsReceiveDataWork = false;
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.PASSWORD:
                    IsReceiveDataWork = false;
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.MULTI:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                    }

                    break;
                case CommandStates.READ:
                    // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    //{
                    //B01TextBoxRead.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                    //ErrorCodeCheck(CommandStates.READ, (s_crlf.IndexOf('R') != -1) ? "" : B01TextBoxRead.Text);
                    //});
                    //DisplayInfoMsg("RX", s_crlf);
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.WRITE:
                    //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    //{
                    //ErrorCodeCheck(CommandStates.WRITE, ReaderService.RemoveCRLF(s_crlf));
                    //});
                    //DisplayInfoMsg("RX", s_crlf);
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.LOCK:
                    // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //     ErrorCodeCheck(CommandStates.KILL, ReaderService.RemoveCRLF(s_crlf));
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.KILL:
                    //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //     ErrorCodeCheck(CommandStates.KILL, ReaderService.RemoveCRLF(s_crlf));
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.B02_MULTI:
                case CommandStates.B02_MULTI_Q:
                    if (s_crlf.Equals("\nU\r\n") || s_crlf.Equals("\nX\r\n"))
                    {
                        IsReceiveDataWork = false;
                        if (s_crlf.Equals("\nX\r\n"))
                        {
                            // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                            // {
                            //     ErrorCodeCheck(CommandStates.B02_MULTI_Q, "X");
                            // });
                        }
                    }
                    //B02DisplayInfoMsg("RX", s_crlf);
                    //B02DisplayStatisticsMsg(ReaderService.DeleteCRLFandHandler(s_crlf, 'U'));
                    break;
                case CommandStates.B02_MULTIREAD:
                case CommandStates.B02_MULTIREAD_Q:
                    if (s_crlf.Equals("\nU\r\n") || s_crlf.Equals("\nX\r\n"))
                    {
                        IsReceiveDataWork = false;
                        if (s_crlf.Equals("\nX\r\n"))
                        {
                            //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                            // {
                            //     ErrorCodeCheck(CommandStates.B02_MULTIREAD_Q, "X");
                            // });
                        }
                    }
                    //B02DisplayInfoMsg("RX", s_crlf);
                    //B02DisplayStatisticsMsg(ReaderService.DeleteCRLFandHandler(s_crlf, 'U'));
                    break;
                case CommandStates.INV_EPC:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                        string epc = ReaderService.DeleteCRLFandHandler(s_crlf, 'U');
                        AddEPCToUI(epc);
                    }
                    break;
                case CommandStates.INV_TID:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                        string tid = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                        AddTIDToUI(tid);
                    }
                    break;
                case CommandStates.DEFAULT:
                case CommandStates.INFO:
                    IsReceiveDataWork = false;
                    break;
                default:
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
            }
            ClearMemory();
        }
        private void DoRawReceiveDataWork(object sender, ReaderService.RawDataReceiveArgument e)
        {
        }
        private async void btnReader_COMOpen_Click(object sender, EventArgs e)
        {
            if (cbReader_COM.SelectedIndex != -1)
            {
                readerClient = new();

                string COMPort = cbReader_COM.Items[cbReader_COM.SelectedIndex].ToString();
                bool bRet = readerClient.Open(COMPort, 38400, Parity.None, 8, StopBits.One);
                if (bRet)
                {
                    btnReader_COMOpen.Enabled = false;
                    btnReader_COMClose.Enabled = true;

                    readerClient.CombineDataReceiveEvent += DoReceiveDataWork;
                    readerClient.RawDataReceiveEvent += DoRawReceiveDataWork;
                    readerClient.SerialPortLog = DoSerialPortLoggerWork;

                    AddStatusMessage("COM port open");

                    await Task.Delay(250);
                    btnGetVersion_Click(sender, e);
                    await Task.Delay(250);
                    btnRFFreqRefresh_Click(sender, e);
                    await Task.Delay(250);

                    IsReceiveDataWork = false;
                }
                else
                {
                    AddStatusMessage("COM port open failed!");
                    MessageBox.Show("Failed to open COM port");
                    btnReader_COMOpen.Enabled = true;
                    btnReader_COMClose.Enabled = false;
                }
            }
        }
        private void AddStatusMessage(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();

            lbStatusMessage.Invoke(new MethodInvoker(delegate
            {
                lbStatusMessage.Items.Add($"[{time_now}] {message}");
                lbStatusMessage.SelectedIndex = lbStatusMessage.Items.Count - 1;
            }));
        }
        private void DoSerialPortLoggerWork(string message, string send_direction)
        {
            string time_now = DateTime.Now.ToLongTimeString();

            lbSerialLog.Invoke(new MethodInvoker(delegate
            {
                lbSerialLog.Items.Add($"[{time_now}][{send_direction}] {message}");
                lbSerialLog.SelectedIndex = lbSerialLog.Items.Count - 1;
            }));

        }
        private void btnReader_COMClose_Click(object sender, EventArgs e)
        {
            btnReader_COMOpen.Enabled = true;
            btnReader_COMClose.Enabled = false;
            if (readerClient != null)
                readerClient.Dispose();
            readerClient = null;
            AddStatusMessage("COM port closed");
        }
        private void InventoryEPCControls_Enable(bool bEnable)
        {
            gbVersionInfo.Enabled = bEnable;
            gbRFInfo.Enabled = bEnable;
            btnInventoryTID.Enabled = bEnable;
            btn6C_Read.Enabled = bEnable;
            btn6C_Write.Enabled = bEnable;
            btnSetProtectState.Enabled = bEnable;
            btn6C_KillTag.Enabled = bEnable;
            btnSerialSend.Enabled = bEnable;
        }
        private void btnInventoryEPC_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            if (btnInventoryEPC.Text == "Stop")
            {
                btnInventoryEPC.Text = "Inventory EPC";
                if (timer_InventoryEPC.Enabled == true)
                    timer_InventoryEPC.Enabled = false;

                //Enable Controls
                InventoryEPCControls_Enable(true);
            }
            else
            {
                btnInventoryEPC.Text = "Stop";
                if (timer_InventoryEPC.Enabled == false)
                    timer_InventoryEPC.Enabled = true;

                //Clear fields
                lvInventoryEPC.Items.Clear();

                //Disable Controls
                InventoryEPCControls_Enable(false);
            }
        }
        private void InventoryTIDControls_Enable(bool bEnable)
        {
            gbVersionInfo.Enabled = bEnable;
            gbRFInfo.Enabled = bEnable;
            btnInventoryEPC.Enabled = bEnable;
            btn6C_Read.Enabled = bEnable;
            btn6C_Write.Enabled = bEnable;
            btnSetProtectState.Enabled = bEnable;
            btn6C_KillTag.Enabled = bEnable;
            btnSerialSend.Enabled = bEnable;
            txtInvTID_Address.Enabled = bEnable;
            txtInvTID_Length.Enabled = bEnable;
        }
        private void btnInventoryTID_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            if (btnInventoryTID.Text == "Stop")
            {
                btnInventoryTID.Text = "Inventory TID";
                if (timer_InventoryTID.Enabled == true)
                    timer_InventoryTID.Enabled = false;

                //Enable Controls
                InventoryTIDControls_Enable(true);
            }
            else
            {
                btnInventoryTID.Text = "Stop";

                //Read Values
                if (txtInvTID_Address.Text.Length > 0)
                    Inventory_TID_Address = txtInvTID_Address.Text;

                if (txtInvTID_Length.Text.Length > 0)
                    Inventory_TID_Length = txtInvTID_Length.Text;

                //Clear fields
                lvInventoryTID.Items.Clear();

                //Disable Controls
                InventoryTIDControls_Enable(false);

                if (timer_InventoryTID.Enabled == false)
                    timer_InventoryTID.Enabled = true;
            }
        }
        private void btnSerialSend_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            if (textSerialInput.Text.Length > 0)
            {
                string s = textSerialInput.Text;
                if (s.Length > 0)
                {
                    DoProcess = CommandStates.INFO;
                    IsReceiveDataWork = true;
                    readerClient.Send(s);
                }
                AddStatusMessage("SerialSend Called");
            }
        }
        private void PopulateFrequencies(int rf_band)
        {
            ObservableCollection<string> items = new ObservableCollection<string>();

            switch (rf_band)
            {
                case 1:
                    for (int i = 0; i < 50; i++)
                    {
                        double j = 903.24 + i * 0.48;
                        items.Add(string.Format("{0}MHz", j.ToString("###.00")));
                    }
                    items.Add("hopping");
                    break;
                case 2:
                    for (int i = 0; i < 13; i++)
                    {
                        double j = 922.84 + i * 0.36;
                        items.Add(string.Format("{0}MHz", j.ToString("###.00")));
                    }
                    items.Add("hopping");
                    break;
                case 3:
                    for (int i = 0; i < 20; i++)
                    {
                        double j = 920.125 + i * 0.25;
                        items.Add(string.Format("{0}MHz", j.ToString("###.000")));
                    }
                    items.Add("hopping");
                    break;
                case 4:
                    for (int i = 0; i < 20; i++)
                    {
                        double j = 840.125 + i * 0.25;
                        items.Add(string.Format("{0}MHz", j.ToString("###.000")));
                    }
                    items.Add("hopping");
                    break;
                case 5:
                    for (int i = 0; i < 4; i++)
                    {
                        double j = 865.7 + i * 0.6;
                        items.Add(string.Format("{0}MHz", j.ToString("###.00")));
                    }
                    items.Add("hopping");
                    break;
            }
            cbFreqSel.DataSource = items;
        }
        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            DoProcess = CommandStates.INFO;
            IsReceiveDataWork = true;
            readerClient.Send(readerClient.Command_V(), ReaderService.Module.CommandType.Normal);
            byte[] b = readerClient.Receive();
            if (b != null)
            {
                string s = readerClient.RemoveCRLF(readerClient.BytesToString(b));
                string[] s_split = s.Split(",");
                if (s_split.Length == 4)
                {
                    textSWVer.Text = s_split[0];
                    textReaderID.Text = s_split[1];
                    textHWVer.Text = s_split[2];

                    int rf_band = Convert.ToInt16(s_split[3]);
                    if (rf_band >= 1 && rf_band <= 5)
                    {
                        cbRFBand.SelectedIndex = rf_band;
                        PopulateFrequencies(rf_band);
                    }
                    else
                    {
                        cbRFBand.SelectedIndex = 0;
                    }
                }
                VersionFW = ReaderService.Module.Check(readerClient.HexStringToInt(s.Substring(1, 4)));

                cbPowerLevel.Items.Clear();
                foreach (ReaderService.PowerItem power in ReaderService.DataRepository.GetPowerGroups(VersionFW))
                {
                    cbPowerLevel.Items.Add(power.LocationName.ToString());
                }
                AddStatusMessage("GetVersion Called");
            }
        }

        private bool isTimer6C_EPCReadProcessing = false;
        private void timer_InventoryEPC_Tick(object sender, EventArgs e)
        {
            if (readerClient == null)
            {
                timer_InventoryEPC.Enabled = false;
                return;
            }
            if (isTimer6C_EPCReadProcessing) return;

            isTimer6C_EPCReadProcessing = true;
            DoProcess = CommandStates.INV_EPC;
            readerClient.Send(readerClient.Command_U(), ReaderService.Module.CommandType.Normal);
            isTimer6C_EPCReadProcessing = false;
        }

        private bool isTimer6C_TIDReadProcessing = false;
        private void timer_InventoryTID_Tick(object sender, EventArgs e)
        {
            if (readerClient == null)
            {
                timer_InventoryEPC.Enabled = false;
                return;
            }
            if (isTimer6C_TIDReadProcessing) return;
            isTimer6C_TIDReadProcessing = true;

            DoProcess = CommandStates.INV_TID;
            readerClient.Send(readerClient.Command_R("2", Inventory_TID_Address, Inventory_TID_Length), ReaderService.Module.CommandType.Normal);

            isTimer6C_TIDReadProcessing = false;
        }
        private void cb6C_IKnowTagKill_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_TagKill.Enabled = !groupBox_TagKill.Enabled;
        }
        private void cb6C_IKnowTagLock_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_TagLocking.Enabled = !groupBox_TagLocking.Enabled;
        }
        private void P_Reserve_CheckedChanged(object sender, EventArgs e)
        {
            gbLockPassword.Enabled = true;
            gbLockTIDnUSER.Enabled = false;
        }
        private void P_EPC_TID_USER_CheckedChanged(object sender, EventArgs e)
        {
            gbLockPassword.Enabled = false;
            gbLockTIDnUSER.Enabled = true;
        }
        private void btn6C_Read_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            //IsReceiveDataWork = true;
            //Check if access password is not 00000000
        }
        private void btn6C_Write_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            //IsReceiveDataWork = true;
            //Check if access password is not 00000000
        }
        private async void btnSaveRFBand_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            int selIdx = cbRFBand.SelectedIndex;
            if (selIdx != -1 && selIdx != 0)
            {
                DoProcess = CommandStates.INFO;
                IsReceiveDataWork = true;
                ReaderService.Module.CommandType t = ReaderService.Module.CommandType.Normal;

                readerClient.Send(readerClient.Command_J(0x30, "00"));  //Switch to hopping frequency
                await Task.Delay(16);
                switch (selIdx)
                {
                    case 1:
                        readerClient.Send(readerClient.SetRegulation(ReaderService.Module.Regulation.US), t);
                        break;
                    case 2:
                        readerClient.Send(readerClient.SetRegulation(ReaderService.Module.Regulation.TW), t);
                        break;
                    case 3:
                        readerClient.Send(readerClient.SetRegulation(ReaderService.Module.Regulation.CN), t);
                        break;
                    case 4:
                        readerClient.Send(readerClient.SetRegulation(ReaderService.Module.Regulation.CN2), t);
                        break;
                    case 5:
                        readerClient.Send(readerClient.SetRegulation(ReaderService.Module.Regulation.EU), t);
                        break;
                }
                AddStatusMessage("SaveRFBand Called");
            }

        }
        private async void btnRFFreqRefresh_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            byte[]? ReceiveData_ModeChannel = null;
            byte[]? ReceiveData_FreqOffset = null;

            DoProcess = CommandStates.INFO;
            IsReceiveDataWork = true;
            switch (this.VersionFW)
            {
                case ReaderService.Module.Version.FI_R300A_C1:
                case ReaderService.Module.Version.FI_R300T_D1:
                    readerClient.Send(readerClient.Command_AA("FF04008702"), ReaderService.Module.CommandType.AA);
                    ReceiveData_ModeChannel = readerClient.Receive();

                    await Task.Delay(250);
                    readerClient.Send(readerClient.Command_AA("FF04008903"), ReaderService.Module.CommandType.AA);
                    ReceiveData_FreqOffset = readerClient.Receive();
                    break;
                case ReaderService.Module.Version.FI_R300A_C2:
                case ReaderService.Module.Version.FI_R300T_D2:
                case ReaderService.Module.Version.FI_R300S:
                    readerClient.Send(readerClient.ReadModeandChannel(), ReaderService.Module.CommandType.Normal);
                    byte[] bs = readerClient.Receive();
                    ReceiveData_ModeChannel = readerClient.HexStringToBytes(readerClient.RemoveCRLF(readerClient.BytesToString(bs)));

                    await Task.Delay(250);
                    readerClient.Send(readerClient.ReadFrequencyOffset(), ReaderService.Module.CommandType.Normal);
                    bs = readerClient.Receive();
                    ReceiveData_FreqOffset = readerClient.HexStringToBytes(readerClient.RemoveCRLF(readerClient.BytesToString(bs)));
                    break;
            }
            if (ReceiveData_ModeChannel != null)
            {
                if (ReceiveData_ModeChannel[0] == 0xFF || ReceiveData_ModeChannel[0] == 0x00)
                {
                    cbFreqSel.SelectedIndex = cbFreqSel.Items.Count - 1;
                    rbBBM_Carry.Checked = false;
                    rbBBM_RX.Checked = false;
                }
                else
                {
                    int selIdx = cbRFBand.SelectedIndex;
                    if (selIdx != -1 && selIdx != 0)
                    {
                        int i = (ReceiveData_ModeChannel[1] > 0) ? ReceiveData_ModeChannel[1] - 1 : ReceiveData_ModeChannel[1];
                        string s = null;
                        double j;
                        switch (selIdx)
                        {
                            case 1:
                                j = 903.24 + i * 0.48;
                                s = string.Format("{0}MHz", j.ToString("###.00"));
                                break;
                            case 2:
                                j = 922.84 + i * 0.36;
                                s = string.Format("{0}MHz", j.ToString("###.00"));
                                break;
                            case 3:
                                j = 920.125 + i * 0.25;
                                s = string.Format("{0}MHz", j.ToString("###.000"));
                                break;
                            case 4:
                                j = 840.125 + i * 0.25;
                                s = string.Format("{0}MHz", j.ToString("###.000"));
                                break;
                            case 5:
                                j = 865.7 + i * 0.6;
                                s = string.Format("{0}MHz", j.ToString("###.00"));
                                break;
                        }
                        if (s != null)
                        {
                            int f_sel = cbFreqSel.FindStringExact(s);
                            if (f_sel != -1)
                            {
                                cbFreqSel.SelectedIndex = f_sel;
                            }
                        }
                    }
                    if (ReceiveData_ModeChannel[0] == 0x01)
                    {
                        rbBBM_Carry.Checked = true;
                        rbBBM_RX.Checked = false;
                    }
                    else if (ReceiveData_ModeChannel[0] == 0x02)
                    {
                        rbBBM_Carry.Checked = false;
                        rbBBM_RX.Checked = true;
                    }
                }
            }
            if (ReceiveData_FreqOffset != null)
            {
                if (ReceiveData_FreqOffset[0] > 0x01)
                {
                    lbFreqOffset.Text = "N/A";
                }
                else
                {
                    string strSymbol = (ReceiveData_FreqOffset[0] == 0x00) ? "-" : "+";
                    int ii = ((ReceiveData_FreqOffset[1] << 8) & 0xFF00) + (ReceiveData_FreqOffset[2] & 0xFF);
                    double db = (double)ii * (double)30.5;
                    lbFreqOffset.Text = string.Format("{0}{1}Hz", strSymbol, db.ToString());
                }
            }
            AddStatusMessage("RFFreqRefresh Called");
        }
        private void btnGetPowerLevel_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            DoProcess = CommandStates.INFO;
            IsReceiveDataWork = true;
            readerClient.Send(readerClient.ReadPower(), ReaderService.Module.CommandType.Normal);
            byte[] b = readerClient.Receive();
            if (b == null || b[1] != 0x4E)
            {
                MessageBox.Show("Failed to get power level");
                return;
            }
            byte[] b2 = new byte[] { b[2], b[3] };
            string str = System.Text.Encoding.ASCII.GetString(b2);
            int powerLevel = Convert.ToInt32(str, 16);
            cbPowerLevel.SelectedIndex = (cbPowerLevel.Items.Count - 1) - powerLevel;
            AddStatusMessage("GetPowerLevel Called");
        }
        private void btnSavePowerLevel_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            if (cbPowerLevel.SelectedIndex != -1)
            {
                DoProcess = CommandStates.INFO;
                IsReceiveDataWork = true;
                int powerLevel = (cbPowerLevel.Items.Count - 1) - cbPowerLevel.SelectedIndex;
                string str = readerClient.MakesUpZero(readerClient.ByteToHexString((byte)powerLevel), 2);
                readerClient.Send(readerClient.SetPower(str), ReaderService.Module.CommandType.Normal);
                AddStatusMessage("SavePowerLevel Called");
            }
        }
        private void btnLogClearStatus_Click(object sender, EventArgs e)
        {
            lbStatusMessage.Items.Clear();
        }
        private void cbRFBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rf_band = cbRFBand.SelectedIndex;
            if (rf_band >= 1 && rf_band <= 5)
            {
                cbRFBand.SelectedIndex = rf_band;
                PopulateFrequencies(rf_band);
            }
        }
        private void btnRFFreqSave_Click(object sender, EventArgs e)
        {
            if (readerClient == null || IsReceiveDataWork) return;

            if (cbFreqSel.SelectedIndex != -1)
            {
                DoProcess = CommandStates.INFO;
                IsReceiveDataWork = true;

                string sel_text = cbFreqSel.SelectedItem.ToString();
                if (sel_text == "hopping")
                {
                    readerClient.Send(
                        readerClient.Command_J(0x30, "00"),
                        ReaderService.Module.CommandType.Normal);
                }
                else
                {
                    int idx = cbFreqSel.SelectedIndex + 1;
                    string str = readerClient.MakesUpZero(readerClient.ByteToHexString((byte)idx), 2);
                    readerClient.Send(
                        readerClient.Command_J((rbBBM_RX.Checked) ? (byte)0x32 : (byte)0x31, str),
                        ReaderService.Module.CommandType.Normal);
                }

            }
        }
        private void btnLogClearSerial_Click_1(object sender, EventArgs e)
        {
            lbSerialLog.Items.Clear();
        }
        private void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_KeyPress(sender, e);
        }
        private void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
        }

        private void lvInventoryEPC_DoubleClick(object sender, EventArgs e)
        {
            if (lvInventoryEPC.SelectedItems.Count == 1)
            {
                string EPCValue = lvInventoryEPC.SelectedItems[0].SubItems[2].Text;
                if (EPCValue != null && EPCValue != "")
                {
                    Clipboard.SetText(EPCValue);
                }
            }
        }

        private void lvInventoryTID_DoubleClick(object sender, EventArgs e)
        {
            if (lvInventoryTID.SelectedItems.Count == 1)
            {
                string TIDValue = lvInventoryTID.SelectedItems[0].SubItems[1].Text;
                if (TIDValue != null && TIDValue != "")
                {
                    Clipboard.SetText(TIDValue);
                }
            }
        }
    }
}
