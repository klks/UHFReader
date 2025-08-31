using FM_5XX.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FM_5XX.Shared.ReaderService.Module;

namespace FM_5XX.FormTabs
{
    public partial class Form_Reader : UserControl
    {
        public Form_Reader()
        {
            InitializeComponent();
            Reader_PopulateComPorts();
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

        private async void btnReader_COMOpen_Click(object sender, EventArgs e)
        {
            if (cbReader_COM.SelectedIndex != -1)
            {
                FormSharedData.readerClient = new();

                string COMPort = cbReader_COM.Items[cbReader_COM.SelectedIndex].ToString();
                bool bRet = FormSharedData.readerClient.Open(COMPort, 38400, Parity.None, 8, StopBits.One);
                if (bRet)
                {
                    btnReader_COMOpen.Enabled = false;
                    btnReader_COMClose.Enabled = true;

                    FormSharedData.readerClient.CombineDataReceiveEvent += FormSharedData.DoReceiveDataWork;
                    FormSharedData.readerClient.RawDataReceiveEvent += FormSharedData.DoRawReceiveDataWork;
                    FormSharedData.readerClient.SerialPortLog = FormSharedData.DoSerialPortLoggerWork;

                    FormSharedData.AddStatusMessage("COM port open");

                    await Task.Delay(250);
                    btnGetVersion_Click(sender, e);
                    await Task.Delay(250);
                    btnRFFreqRefresh_Click(sender, e);
                    await Task.Delay(250);

                    FormSharedData.IsReceiveDataWork = false;
                }
                else
                {
                    FormSharedData.AddStatusMessage("COM port open failed!");
                    MessageBox.Show("Failed to open COM port");
                    btnReader_COMOpen.Enabled = true;
                    btnReader_COMClose.Enabled = false;
                }
            }
        }
        private void btnReader_COMClose_Click(object sender, EventArgs e)
        {
            btnReader_COMOpen.Enabled = true;
            btnReader_COMClose.Enabled = false;
            if (FormSharedData.readerClient != null)
                FormSharedData.readerClient.Dispose();
            FormSharedData.readerClient = null;
            FormSharedData.AddStatusMessage("COM port closed");
        }
        private void btnGetVersion_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
            FormSharedData.IsReceiveDataWork = true;
            FormSharedData.readerClient.Send(FormSharedData.readerClient.Command_V(), ReaderService.Module.CommandType.Normal);
            byte[] b = FormSharedData.readerClient.Receive();
            if (b != null)
            {
                string s = FormSharedData.readerClient.RemoveCRLF(Utilities.Utilities.BytesToString(b));
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
                FormSharedData.VersionFW = ReaderService.Module.Check(FormSharedData.readerClient.HexStringToInt(s.Substring(1, 4)));

                cbPowerLevel.Items.Clear();
                foreach (ReaderService.PowerItem power in ReaderService.DataRepository.GetPowerGroups(FormSharedData.VersionFW))
                {
                    cbPowerLevel.Items.Add(power.LocationName.ToString());
                }
                FormSharedData.AddStatusMessage("GetVersion Called");
            }
        }
        private async void btnRFFreqRefresh_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            byte[]? ReceiveData_ModeChannel = null;
            byte[]? ReceiveData_FreqOffset = null;

            FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
            FormSharedData.IsReceiveDataWork = true;
            switch (FormSharedData.VersionFW)
            {
                case ReaderService.Module.Version.FI_R300A_C1:
                case ReaderService.Module.Version.FI_R300T_D1:
                    FormSharedData.readerClient.Send(FormSharedData.readerClient.Command_AA("FF04008702"), ReaderService.Module.CommandType.AA);
                    ReceiveData_ModeChannel = FormSharedData.readerClient.Receive();

                    await Task.Delay(250);
                    FormSharedData.readerClient.Send(FormSharedData.readerClient.Command_AA("FF04008903"), ReaderService.Module.CommandType.AA);
                    ReceiveData_FreqOffset = FormSharedData.readerClient.Receive();
                    break;
                case ReaderService.Module.Version.FI_R300A_C2:
                case ReaderService.Module.Version.FI_R300T_D2:
                case ReaderService.Module.Version.FI_R300S:
                    FormSharedData.readerClient.Send(FormSharedData.readerClient.ReadModeandChannel(), ReaderService.Module.CommandType.Normal);
                    byte[] bs = FormSharedData.readerClient.Receive();
                    ReceiveData_ModeChannel = FormSharedData.readerClient.HexStringToBytes(FormSharedData.readerClient.RemoveCRLF(Utilities.Utilities.BytesToString(bs)));

                    await Task.Delay(250);
                    FormSharedData.readerClient.Send(FormSharedData.readerClient.ReadFrequencyOffset(), ReaderService.Module.CommandType.Normal);
                    bs = FormSharedData.readerClient.Receive();
                    ReceiveData_FreqOffset = FormSharedData.readerClient.HexStringToBytes(FormSharedData.readerClient.RemoveCRLF(Utilities.Utilities.BytesToString(bs)));
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
            FormSharedData.AddStatusMessage("RFFreqRefresh Called");
        }
        private void btnGetPowerLevel_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
            FormSharedData.IsReceiveDataWork = true;
            FormSharedData.readerClient.Send(FormSharedData.readerClient.ReadPower(), ReaderService.Module.CommandType.Normal);
            byte[] b = FormSharedData.readerClient.Receive();
            if (b == null || b[1] != 0x4E)
            {
                MessageBox.Show("Failed to get power level");
                return;
            }
            byte[] b2 = new byte[] { b[2], b[3] };
            string str = System.Text.Encoding.ASCII.GetString(b2);
            int powerLevel = Convert.ToInt32(str, 16);
            cbPowerLevel.SelectedIndex = (cbPowerLevel.Items.Count - 1) - powerLevel;
            FormSharedData.AddStatusMessage("GetPowerLevel Called");
        }
        private void btnSavePowerLevel_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            if (cbPowerLevel.SelectedIndex != -1)
            {
                FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
                FormSharedData.IsReceiveDataWork = true;
                int powerLevel = (cbPowerLevel.Items.Count - 1) - cbPowerLevel.SelectedIndex;
                string str = FormSharedData.readerClient.MakesUpZero(Utilities.Utilities.ByteToHexString((byte)powerLevel), 2);
                FormSharedData.readerClient.Send(FormSharedData.readerClient.SetPower(str), ReaderService.Module.CommandType.Normal);
                FormSharedData.AddStatusMessage("SavePowerLevel Called");
            }
        }
        private void btnRFFreqSave_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            if (cbFreqSel.SelectedIndex != -1)
            {
                FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
                FormSharedData.IsReceiveDataWork = true;

                string sel_text = cbFreqSel.SelectedItem.ToString();
                if (sel_text == "hopping")
                {
                    FormSharedData.readerClient.Send(
                        FormSharedData.readerClient.Command_J(0x30, "00"),
                        ReaderService.Module.CommandType.Normal);
                }
                else
                {
                    int idx = cbFreqSel.SelectedIndex + 1;
                    string str = FormSharedData.readerClient.MakesUpZero(Utilities.Utilities.ByteToHexString((byte)idx), 2);
                    FormSharedData.readerClient.Send(
                        FormSharedData.readerClient.Command_J((rbBBM_RX.Checked) ? (byte)0x32 : (byte)0x31, str),
                        ReaderService.Module.CommandType.Normal);
                }

            }
        }
        private async void btnSaveRFBand_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

            int selIdx = cbRFBand.SelectedIndex;
            if (selIdx != -1 && selIdx != 0)
            {
                FormSharedData.DoProcess = FormSharedData.CommandStates.INFO;
                FormSharedData.IsReceiveDataWork = true;
                ReaderService.Module.CommandType t = ReaderService.Module.CommandType.Normal;

                FormSharedData.readerClient.Send(FormSharedData.readerClient.Command_J(0x30, "00"));  //Switch to hopping frequency
                await Task.Delay(16);
                switch (selIdx)
                {
                    case 1:
                        FormSharedData.readerClient.Send(FormSharedData.readerClient.SetRegulation(ReaderService.Module.Regulation.US), t);
                        break;
                    case 2:
                        FormSharedData.readerClient.Send(FormSharedData.readerClient.SetRegulation(ReaderService.Module.Regulation.TW), t);
                        break;
                    case 3:
                        FormSharedData.readerClient.Send(FormSharedData.readerClient.SetRegulation(ReaderService.Module.Regulation.CN), t);
                        break;
                    case 4:
                        FormSharedData.readerClient.Send(FormSharedData.readerClient.SetRegulation(ReaderService.Module.Regulation.CN2), t);
                        break;
                    case 5:
                        FormSharedData.readerClient.Send(FormSharedData.readerClient.SetRegulation(ReaderService.Module.Regulation.EU), t);
                        break;
                }
                FormSharedData.AddStatusMessage("SaveRFBand Called");
            }

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
    }
}
