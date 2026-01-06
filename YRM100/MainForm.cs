using System;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using YRM100.BarChart;
using YRM100.Shared;

namespace YRM100
{
    public partial class MainForm : Form
    {
        private bool bAutoSend;
        private int LoopNum_cnt;
        private bool change_q_1st = true;
        private bool change_q_message = true;
        public ReceiveParser rp;
        private DataTable basic_table = new DataTable();
        private DataTable advanced_table = new DataTable();
        private DataSet ds_basic;
        private DataSet ds_advanced;
        private string pc = string.Empty;
        private string epc = string.Empty;
        private string crc = string.Empty;
        private string rssi = string.Empty;
        private string ant = string.Empty;
        private int FailEPCNum;
        private int SucessEPCNum;
        private double errnum;
        private double db_errEPCNum;
        private double db_LoopNum_cnt;
        private string per = "0.000";
        private string timeFormat = "yyyy/MM/dd HH:mm:ss.ff";
        private static string[] strBuff = new string[4096];
        private int rowIndex;
        private int initDataTableLen = 1;
        private static int[] mixerGainTable = new int[7] { 0, 3, 6, 9, 12, 15, 16 };
        private static int[] IFAmpGainTable = new int[8] { 12, 18, 21, 24, 27, 30, 36, 40 };
        private string curRegion = "01";
        private string hardwareVersion;
        private bool checkingReaderAvailable;
        private bool readerConnected;
        private int lastRecCnt;
        private Commands CommandModule = new Commands(ModuleType.YRM100);

        public MainForm()
        {
            InitializeComponent();
            setTip();
            cbxRegion.SelectedIndex = 0;
            cbxChannel.SelectedIndex = 0;
            cbxBaudRate.SelectedIndex = 2;
            cbxDR.SelectedIndex = 0;
            cbxM.SelectedIndex = 0;
            cbxTRext.SelectedIndex = 1;
            cbxSel.SelectedIndex = 0;
            cbxSession.SelectedIndex = 0;
            cbxTarget.SelectedIndex = 0;
            cbxQBasic.SelectedIndex = 4;
            cbxQAdv.SelectedIndex = 4;
            cbxMemBank.SelectedIndex = 3;
            cbxSelTarget.SelectedIndex = 0;
            cbxAction.SelectedIndex = 0;
            cbxSelMemBank.SelectedIndex = 1;
            cbxPaPower.SelectedIndex = 0;
            cbxMixerGain.SelectedIndex = 3;
            cbxIFAmpGain.SelectedIndex = 6;
            cbxMode.SelectedIndex = 0;
            cbxIO.SelectedIndex = 0;
            cbxIoLevel.SelectedIndex = 0;
            cbxIoDircetion.SelectedIndex = 0;
            cbxLockKillAction.SelectedIndex = 0;
            cbxLockAccessAction.SelectedIndex = 0;
            cbxLockEPCAction.SelectedIndex = 0;
            cbxLockTIDAction.SelectedIndex = 0;
            cbxLockUserAction.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] portNames = Sp.GetInstance().GetPortNames();
            string[] array = portNames;
            foreach (string item in array)
            {
                cbxPort.Items.Add(item);
            }
            if (cbxPort.Items.Count > 0)
            {
                cbxPort.SelectedIndex = 0;
                btnConn.Enabled = true;
            }
            cbxBaudRate.SelectedIndex = 2;
            rp = new ReceiveParser();
            Sp.GetInstance().ComDevice.DataReceived += rp.DataReceived;
            rp.PacketReceived += rp_PaketReceived;
            Sp.GetInstance().DataSent += ComDataSent;
            dgvEpcBasic.DataBindingComplete += dgvEpcBasic_DataBindingComplete;
            dgv_epc2.DataBindingComplete += dgv_epc2_DataBindingComplete;
            change_q_1st = false;
            ds_basic = new DataSet();
            ds_advanced = new DataSet();
            basic_table = BasicGetEPCHead();
            advanced_table = AdvancedGetEPCHead();
            ds_basic.Tables.Add(basic_table);
            ds_advanced.Tables.Add(advanced_table);
            DataView defaultView = ds_basic.Tables[0].DefaultView;
            DataView defaultView2 = ds_advanced.Tables[0].DefaultView;
            dgvEpcBasic.DataSource = defaultView;
            dgv_epc2.DataSource = defaultView2;
            Basic_DGV_ColumnsWidth(dgvEpcBasic);
            Advanced_DGV_ColumnsWidth(dgv_epc2);
            btnInvtBasic.Focus();
            adjustUIcomponents("M100");
        }

        public void SetWorkingMode_YPDR200()
        {
            CommandModule = new Commands(ModuleType.YPD_R200);
            this.Text = "UHF_RFIDReader_Demo_V6.6 - YPD-R200";
        }

        public void SetWorkingMode_YRM100()
        {
            this.Text = "UHF_RFIDReader_Demo_V6.6 - YRM100";
            //CommandModule = new Commands(ModuleType.YRM100);
            //Hide certain UI components not applicable to YRM100
        }

        private void ComDataSent(object sender, byteArrEventArgs e)
        {
            txtCOMTxCnt.Text = (Convert.ToInt32(txtCOMTxCnt.Text) + e.Data.Length).ToString();
            txtCOMTxCnt_adv.Text = txtCOMTxCnt.Text;
        }

        private void rp_PaketReceived(object sender, StrArrEventArgs e)
        {
            string[] packetRx = e.Data;
            string strPacket = string.Empty;
            for (int i = 0; i < packetRx.Length; i++)
            {
                strPacket = strPacket + packetRx[i] + " ";
            }
            Invoke((EventHandler)delegate
            {
                txtCOMRxCnt.Text = (Convert.ToInt32(txtCOMRxCnt.Text) + packetRx.Length).ToString();
                txtCOMRxCnt_adv.Text = txtCOMRxCnt.Text;
                int num = txtReceive.Lines.Length;
                if (cbxAutoClear.Checked && num > 9)
                {
                    txtReceive.Text = string.Empty;
                }
                if (cbxRxVisable.Checked)
                {
                    txtReceive.Text = txtReceive.Text + strPacket + "\r\n";
                }
                if (packetRx[1] == "02" && packetRx[2] == "22")
                {
                    SucessEPCNum++;
                    db_errEPCNum = FailEPCNum;
                    db_LoopNum_cnt += 1.0;
                    errnum = db_errEPCNum / db_LoopNum_cnt * 100.0;
                    per = $"{errnum:0.000}";
                    int num2 = Convert.ToInt16(packetRx[5], 16);
                    if (num2 > 127)
                    {
                        num2 = -(-num2 & 0xFF);
                    }
                    num2 -= Convert.ToInt32(tbxCoupling.Text, 10);
                    num2 -= Convert.ToInt32(tbxAntennaGain.Text, 10);
                    rssi = num2.ToString();
                    ant = packetRx[3];
                    int num3 = (Convert.ToInt32(packetRx[6], 16) / 8 + 1) * 2;
                    pc = packetRx[6] + " " + packetRx[7];
                    epc = string.Empty;
                    for (int j = 0; j < num3 - 2; j++)
                    {
                        epc += packetRx[8 + j];
                    }
                    epc = CommandModule.AutoAddSpace(epc);
                    crc = packetRx[6 + num3] + " " + packetRx[7 + num3];
                    GetEPC(pc, epc, crc, rssi, per, ant);
                }
                else if (packetRx[1] == "01")
                {
                    setStatus("", Color.MediumSeaGreen);
                    if (packetRx[2] == "FF")
                    {
                        int errorCode = Convert.ToInt32(packetRx[5], 16);
                        if (packetRx.Length > 9)
                        {
                            txtOperateEpc.Text = "";
                            int num4 = Convert.ToInt32(packetRx[6], 16);
                            for (int k = 0; k < num4; k++)
                            {
                                TextBox textBox = txtOperateEpc;
                                textBox.Text = textBox.Text + packetRx[k + 7] + " ";
                            }
                        }
                        else
                        {
                            txtOperateEpc.Text = "";
                        }
                        if (packetRx[5] == "15")
                        {
                            FailEPCNum++;
                            db_errEPCNum = FailEPCNum;
                            db_LoopNum_cnt += 1.0;
                            errnum = db_errEPCNum / db_LoopNum_cnt * 100.0;
                            per = $"{errnum:0.000}";
                            pbx_Inv_Indicator.Visible = false;
                        }
                        else if (packetRx[5] == "20")
                        {
                            setStatus("FHSS Failed", Color.Red);
                        }
                        else if (packetRx[5] == "16")
                        {
                            setStatus("Access Failed, Please Check the Access Password", Color.Red);
                        }
                        else if (packetRx[5] == "09")
                        {
                            setStatus("No Tag Response, Fail to Read Tag Memory", Color.Red);
                        }
                        else if (packetRx[5].Substring(0, 1) == "A0".Substring(0, 1))
                        {
                            setStatus("Read Failed. Error Code: " + ParseErrCode(errorCode), Color.Red);
                        }
                        else if (packetRx[5] == "10")
                        {
                            setStatus("No Tag Response, Fail to Write Tag Memory", Color.Red);
                        }
                        else if (packetRx[5].Substring(0, 1) == "B0".Substring(0, 1))
                        {
                            setStatus("Write Failed. Error Code: " + ParseErrCode(errorCode), Color.Red);
                        }
                        else if (packetRx[5] == "13")
                        {
                            setStatus("No Tag Response, Lock Operation Failed", Color.Red);
                        }
                        else if (packetRx[5].Substring(0, 1) == "C0".Substring(0, 1))
                        {
                            setStatus("Lock Failed. Error Code: " + ParseErrCode(errorCode), Color.Red);
                        }
                        else if (packetRx[5] == "12")
                        {
                            setStatus("No Tag Response, Kill Operation Failed", Color.Red);
                        }
                        else if (packetRx[5].Substring(0, 1) == "D0".Substring(0, 1))
                        {
                            setStatus("Kill Failed. Error Code: " + ParseErrCode(errorCode), Color.Red);
                        }
                        else if (packetRx[5] == "1A")
                        {
                            setStatus("No Tag Response, NXP Change Config Failed", Color.Red);
                        }
                        else if (packetRx[5] == "1B")
                        {
                            setStatus("No Tag Response, NXP Change EAS Failed", Color.Red);
                        }
                        else if (packetRx[5] == "1C")
                        {
                            setStatus("Tag is not in Secure State, NXP Change EAS Failed", Color.Red);
                        }
                        else if (packetRx[5] == "1D")
                        {
                            txtOperateEpc.Text = "";
                            setStatus("No Tag Response, NXP EAS Alarm Operation Failed", Color.Red);
                        }
                        else if (packetRx[5] == "2A")
                        {
                            setStatus("No Tag Response, NXP ReadProtect Failed", Color.Red);
                        }
                        else if (packetRx[5] == "2B")
                        {
                            setStatus("No Tag Response, NXP Reset ReadProtect Failed", Color.Red);
                        }
                        else if (packetRx[5] == "2E")
                        {
                            setStatus("No Tag Response, QT Command Failed", Color.Red);
                        }
                        else if (packetRx[5].Substring(0, 1) == "E0".Substring(0, 1))
                        {
                            setStatus("Command Executed Failed. Error Code: " + ParseErrCode(errorCode), Color.Red);
                        }
                        else if (packetRx[5] == "0E")
                        {
                            MessageBox.Show("Invalid Parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (packetRx[5] == "17")
                        {
                            MessageBox.Show("Invalid Command!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else if (packetRx[2] == "0E")
                    {
                        MessageBox.Show("Query Parameters has set up", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "0D")
                    {
                        string empty = string.Empty;
                        string[] array = String16toString2(packetRx[5]);
                        string[] array2 = String16toString2(packetRx[6]);
                        int num5 = Convert.ToInt32(array2[6]) * 8 + Convert.ToInt32(array2[5]) * 4 + Convert.ToInt32(array2[4]) * 2 + Convert.ToInt32(array2[3]);
                        string text = string.Empty;
                        if (array[6] + array[5] == "00")
                        {
                            text = "1";
                        }
                        else if (array[6] + array[5] == "01")
                        {
                            text = "2";
                        }
                        else if (array[6] + array[5] == "10")
                        {
                            text = "4";
                        }
                        else if (array[6] + array[5] == "11")
                        {
                            text = "8";
                        }
                        string empty2 = string.Empty;
                        empty2 = ((!(array[4] == "0")) ? "UsePilot" : "NoPilot");
                        string empty3 = string.Empty;
                        empty3 = ((!(array2[7] == "0")) ? "B" : "A");
                        empty = "DR=" + array[7] + ", ";
                        empty = empty + "M=" + text + ", ";
                        empty = empty + "TRext=" + empty2 + ", ";
                        empty = empty + "Sel=" + array[3] + array[2] + ", ";
                        empty = empty + "Session=" + array[1] + array[0] + ", ";
                        empty = empty + "Target=" + empty3 + ", ";
                        empty = empty + "Q=" + num5;
                        MessageBox.Show(empty, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "39")
                    {
                        string text2 = "";
                        txtInvtRWData.Text = "";
                        txtOperateEpc.Text = "";
                        int num6 = Convert.ToInt32(packetRx[4], 16);
                        int num7 = Convert.ToInt32(packetRx[5], 16);
                        for (int l = 0; l < num7; l++)
                        {
                            TextBox textBox2 = txtOperateEpc;
                            textBox2.Text = textBox2.Text + packetRx[l + 6] + " ";
                        }
                        for (int m = 0; m < num6 - num7 - 1; m++)
                        {
                            text2 += packetRx[m + num7 + 6];
                        }
                        txtInvtRWData.Text = CommandModule.AutoAddSpace(text2);
                        setStatus("Read Memory Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "49")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("Write Memory Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "82")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("Lock Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "65")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("Kill Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E0")
                    {
                        int successTagEpc = getSuccessTagEpc(packetRx);
                        string text3 = packetRx[successTagEpc + 6] + packetRx[successTagEpc + 7];
                        setStatus("NXP Tag Change Config Success, Config Word: 0x" + text3, Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E3")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("NXP Tag Change EAS Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E1")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("NXP Tag ReadProtect Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E2")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("NXP Tag Reset ReadProtect Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E4")
                    {
                        setStatus("NXP Tag EAS Alarm Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E5")
                    {
                        int successTagEpc2 = getSuccessTagEpc(packetRx);
                        string text4 = packetRx[successTagEpc2 + 6] + packetRx[successTagEpc2 + 7];
                        int num8 = Convert.ToUInt16(text4, 16);
                        string text5 = (((num8 & 0x8000) == 0) ? "0" : "1");
                        string text6 = (((num8 & 0x4000) == 0) ? "0" : "1");
                        setStatus("QT Read Success, QT Control Word: 0x" + text4 + ", QT_SR=" + text5 + ", QT_MEM=" + text6, Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "E6")
                    {
                        getSuccessTagEpc(packetRx);
                        setStatus("QT Write Success", Color.MediumSeaGreen);
                    }
                    else if (packetRx[2] == "0B")
                    {
                        string empty4 = string.Empty;
                        string[] array3 = String16toString2(packetRx[5]);
                        string text7 = array3[7] + array3[6] + array3[5];
                        string text8 = array3[4] + array3[3] + array3[2];
                        string text9 = array3[1] + array3[0];
                        string text10 = null;
                        text10 = text7 switch
                        {
                            "000" => "S0",
                            "001" => "S1",
                            "010" => "S2",
                            "011" => "S3",
                            "100" => "SL",
                            _ => "RFU",
                        };
                        string text11 = null;
                        text11 = text9 switch
                        {
                            "00" => "RFU",
                            "01" => "EPC",
                            "10" => "TID",
                            _ => "User",
                        };
                        empty4 = "Target=" + text10 + ", Action=" + text8 + ", Memory Bank=" + text11;
                        empty4 = empty4 + ", Pointer=0x" + packetRx[6] + packetRx[7] + packetRx[8] + packetRx[9];
                        empty4 = empty4 + ", Length=0x" + packetRx[10];
                        string text12 = null;
                        text12 = ((!(packetRx[11] == "00")) ? "Enable Truncation" : "Disable Truncation");
                        empty4 = empty4 + ", " + text12;
                        txtGetSelLength.Text = packetRx[10];
                        string text13 = null;
                        int num9 = Convert.ToInt32(packetRx[10], 16) / 8;
                        if (Convert.ToInt32(packetRx[10], 16) - num9 * 8 == 0)
                        {
                            for (int n = 0; n < num9; n++)
                            {
                                text13 += packetRx[12 + n];
                            }
                        }
                        else
                        {
                            for (int num10 = 0; num10 < num9 + 1; num10++)
                            {
                                text13 += packetRx[12 + num10];
                            }
                        }
                        txtGetSelMask.Text = CommandModule.AutoAddSpace(text13);
                        MessageBox.Show(empty4, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "AA")
                    {
                        double num11 = Convert.ToInt32(packetRx[5], 16);
                        switch (curRegion)
                        {
                            case "01":
                                num11 = 920.125 + num11 * 0.25;
                                break;
                            case "04":
                                num11 = 840.125 + num11 * 0.25;
                                break;
                            case "02":
                                num11 = 902.25 + num11 * 0.5;
                                break;
                            case "03":
                                num11 = 865.1 + num11 * 0.2;
                                break;
                            case "06":
                                num11 = 917.1 + num11 * 0.2;
                                break;
                        }
                        MessageBox.Show("Current RF Channel is " + num11 + " MHz", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "B7")
                    {
                        string value = packetRx[5] + packetRx[6];
                        MessageBox.Show("Current Power is " + (double)Convert.ToInt16(value, 16) / 100.0 + "dBm", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "F1")
                    {
                        int num12 = mixerGainTable[Convert.ToInt32(packetRx[5], 16)];
                        int num13 = IFAmpGainTable[Convert.ToInt32(packetRx[6], 16)];
                        string text14 = packetRx[7] + packetRx[8];
                        MessageBox.Show("Mixer Gain is " + num12 + "dB, IF AMP Gain is " + num13 + "dB, Decode Threshold is 0x" + text14 + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (packetRx[2] == "F2")
                    {
                        int num14 = Convert.ToInt16(packetRx[5], 16);
                        int num15 = Convert.ToInt16(packetRx[6], 16);
                        hBarChartJammer.Items.Maximum = 40.0;
                        hBarChartJammer.Items.Minimum = 0.0;
                        hBarChartJammer.Items.Clear();
                        int[] array4 = new int[num15 - num14 + 1];
                        int num16 = -100;
                        int num17 = 20;
                        for (int num18 = 0; num18 < num15 - num14 + 1; num18++)
                        {
                            int num19 = Convert.ToInt16(packetRx[7 + num18], 16);
                            if (num19 > 127)
                            {
                                num19 = -(-num19 & 0xFF);
                            }
                            array4[num18] = num19;
                            if (num19 >= num16)
                            {
                                num16 = num19;
                            }
                            if (num19 <= num17)
                            {
                                num17 = num19;
                            }
                        }
                        int num20 = -num17 + 3;
                        for (int num21 = 0; num21 < num15 - num14 + 1; num21++)
                        {
                            array4[num21] += num20;
                            hBarChartJammer.Items.Add(new HBarItem(array4[num21], num20, (num21 + num14).ToString(), Color.FromArgb(255, 190, 200, 255)));
                        }
                        hBarChartJammer.RedrawChart();
                    }
                    else if (packetRx[2] == "F3")
                    {
                        int num22 = Convert.ToInt16(packetRx[5], 16);
                        int num23 = Convert.ToInt16(packetRx[6], 16);
                        hBarChartRssi.Items.Maximum = 73.0;
                        hBarChartRssi.Items.Minimum = 0.0;
                        hBarChartRssi.Items.Clear();
                        int[] array5 = new int[num23 - num22 + 1];
                        int num24 = -100;
                        int num25 = 20;
                        for (int num26 = 0; num26 < num23 - num22 + 1; num26++)
                        {
                            int num27 = Convert.ToInt16(packetRx[7 + num26], 16);
                            if (num27 > 127)
                            {
                                num27 = -(-num27 & 0xFF);
                            }
                            array5[num26] = num27;
                            if (num27 >= num24)
                            {
                                num24 = num27;
                            }
                            if (num27 <= num25)
                            {
                                num25 = num27;
                            }
                        }
                        int num28 = -num25 + 3;
                        for (int num29 = 0; num29 < num23 - num22 + 1; num29++)
                        {
                            array5[num29] += num28;
                            hBarChartRssi.Items.Add(new HBarItem(array5[num29], num28, (num29 + num22).ToString(), Color.FromArgb(255, 190, 200, 255)));
                        }
                        hBarChartRssi.RedrawChart();
                    }
                    else if (packetRx[2] == "03")
                    {
                        if (checkingReaderAvailable)
                        {
                            if (packetRx[5] == "00")
                            {
                                hardwareVersion = string.Empty;
                                try
                                {
                                    for (int num30 = 0; num30 < Convert.ToInt32(packetRx[4], 16) - 1; num30++)
                                    {
                                        hardwareVersion += (char)Convert.ToInt32(packetRx[6 + num30], 16);
                                    }
                                    txtHardwareVersion.Text = hardwareVersion;
                                    adjustUIcomponents(hardwareVersion);
                                    getFirmwareVersion();
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    hardwareVersion = packetRx[6].Substring(1, 1) + "." + packetRx[7];
                                    txtHardwareVersion.Text = hardwareVersion;
                                    Console.WriteLine(ex.Message);
                                    return;
                                }
                            }
                            if (packetRx[5] == "01")
                            {
                                string text15 = string.Empty;
                                try
                                {
                                    for (int num31 = 0; num31 < Convert.ToInt32(packetRx[4], 16) - 1; num31++)
                                    {
                                        text15 += (char)Convert.ToInt32(packetRx[6 + num31], 16);
                                    }
                                    txtFirmwareVersion.Text = text15;
                                    if ("V704".Equals(text15.Substring(0, 4)) | "V708".Equals(text15.Substring(0, 4)) | "V716".Equals(text15.Substring(0, 4)))
                                    {
                                        getSwitchAnt();
                                    }
                                }
                                catch (Exception ex2)
                                {
                                    txtFirmwareVersion.Text = "";
                                    Console.WriteLine(ex2.Message);
                                }
                            }
                        }
                    }
                    else if (packetRx[2] == "A7")
                    {
                        int num32 = (Convert.ToInt32(packetRx[5], 16) << 8) | Convert.ToInt32(packetRx[6], 16);
                        byte b = (byte)Convert.ToInt32(packetRx[7], 16);
                        AntStayTime.Text = b.ToString("X1");
                        if ((num32 & 1) == 1)
                        {
                            ANT1.Checked = true;
                        }
                        if ((num32 & 2) == 2)
                        {
                            ANT2.Checked = true;
                        }
                        if ((num32 & 4) == 4)
                        {
                            ANT3.Checked = true;
                        }
                        if ((num32 & 8) == 8)
                        {
                            ANT4.Checked = true;
                        }
                        if ((num32 & 0x10) == 16)
                        {
                            ANT5.Checked = true;
                        }
                        if ((num32 & 0x20) == 32)
                        {
                            ANT6.Checked = true;
                        }
                        if ((num32 & 0x40) == 64)
                        {
                            ANT7.Checked = true;
                        }
                        if ((num32 & 0x80) == 128)
                        {
                            ANT8.Checked = true;
                        }
                        if ((num32 & 0x100) == 256)
                        {
                            ANT9.Checked = true;
                        }
                        if ((num32 & 0x200) == 512)
                        {
                            ANT10.Checked = true;
                        }
                        if ((num32 & 0x400) == 1024)
                        {
                            ANT11.Checked = true;
                        }
                        if ((num32 & 0x800) == 2048)
                        {
                            ANT12.Checked = true;
                        }
                        if ((num32 & 0x1000) == 4096)
                        {
                            ANT13.Checked = true;
                        }
                        if ((num32 & 0x2000) == 8192)
                        {
                            ANT14.Checked = true;
                        }
                        if ((num32 & 0x4000) == 16384)
                        {
                            ANT15.Checked = true;
                        }
                        if ((num32 & 0x8000) == 32768)
                        {
                            ANT16.Checked = true;
                        }
                    }
                    else if (packetRx[2] == "1A" && packetRx[5] == "02")
                    {
                        MessageBox.Show("IO" + packetRx[6].Substring(1) + " is " + ((packetRx[7] == "00") ? "Low" : "High"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            });
        }

        private int getSuccessTagEpc(string[] packetRx)
        {
            txtOperateEpc.Text = "";
            if (packetRx.Length < 9)
            {
                return 0;
            }
            int num = Convert.ToInt32(packetRx[5], 16);
            for (int i = 0; i < num; i++)
            {
                TextBox textBox = txtOperateEpc;
                textBox.Text = textBox.Text + packetRx[i + 6] + " ";
            }
            return num;
        }

        private void setStatus(string msg, Color color)
        {
            rtbxStatus.Text = msg;
            rtbxStatus.ForeColor = color;
        }

        private void adjustUIcomponents(string hardwareVersion)
        {
            if (hardwareVersion.Length >= 12 && "V704".Equals(hardwareVersion.Substring(10, 4)))
            {
                ANT1.Visible = true;
                ANT2.Visible = true;
                ANT3.Visible = true;
                ANT4.Visible = true;
                SetAnt.Visible = true;
                AntStayTime.Visible = true;
            }
            else if (hardwareVersion.Length >= 12 && "V708".Equals(hardwareVersion.Substring(10, 4)))
            {
                ANT1.Visible = true;
                ANT2.Visible = true;
                ANT3.Visible = true;
                ANT4.Visible = true;
                ANT5.Visible = true;
                ANT6.Visible = true;
                ANT7.Visible = true;
                ANT8.Visible = true;
                SetAnt.Visible = true;
                AntStayTime.Visible = true;
            }
            else if (hardwareVersion.Length >= 12 && "V716".Equals(hardwareVersion.Substring(10, 4)))
            {
                ANT1.Visible = true;
                ANT2.Visible = true;
                ANT3.Visible = true;
                ANT4.Visible = true;
                ANT5.Visible = true;
                ANT6.Visible = true;
                ANT7.Visible = true;
                ANT8.Visible = true;
                ANT9.Visible = true;
                ANT10.Visible = true;
                ANT11.Visible = true;
                ANT12.Visible = true;
                ANT13.Visible = true;
                ANT14.Visible = true;
                ANT15.Visible = true;
                ANT16.Visible = true;
                SetAnt.Visible = true;
                AntStayTime.Visible = true;
            }
            if (hardwareVersion.Length >= 10 && "UHF 26dBm".Equals(hardwareVersion.Substring(0, 9)))
            {
                cbxPaPower.Items.Clear();
                for (int num = 26; num >= -9; num--)
                {
                    cbxPaPower.Items.Add(num + "dBm");
                }
                cbxPaPower.SelectedIndex = 0;
                cbxMixerGain.SelectedIndex = 2;
                cbxIFAmpGain.SelectedIndex = 6;
                tbxSignalThreshold.Text = "00A0";
                tbxAntennaGain.Text = "3";
                tbxCoupling.Text = "-20";
                gbxIoControl.Visible = false;
            }
            else if (hardwareVersion.Length >= 10 && "UHF 20dBm".Equals(hardwareVersion.Substring(0, 9)))
            {
                cbxPaPower.Items.Clear();
                cbxPaPower.Items.AddRange(new object[6] { "20dBm", "18.5dBm", "17dBm", "15.5dBm", "14dBm", "12.5dBm" });
                cbxPaPower.SelectedIndex = 0;
                cbxMixerGain.SelectedIndex = 3;
                cbxIFAmpGain.SelectedIndex = 6;
                tbxSignalThreshold.Text = "01B0";
                tbxAntennaGain.Text = "1";
                tbxCoupling.Text = "-27";
                gbxIoControl.Visible = false;
            }
            else if (hardwareVersion.Length >= 10 && "UHF 30dBm".Equals(hardwareVersion.Substring(0, 9)))
            {
                cbxPaPower.Items.Clear();
                for (int num2 = 30; num2 >= 19; num2--)
                {
                    cbxPaPower.Items.Add(num2 + "dBm");
                }
                cbxPaPower.SelectedIndex = 0;
                cbxMixerGain.SelectedIndex = 4;
                cbxIFAmpGain.SelectedIndex = 6;
                tbxSignalThreshold.Text = "0120";
                tbxAntennaGain.Text = "3";
                tbxCoupling.Text = "-10";
                cbxQBasic.SelectedIndexChanged -= cbx_q_basic_SelectedIndexChanged;
                cbxQBasic.SelectedIndex = 5;
                cbxQBasic.SelectedIndexChanged += cbx_q_basic_SelectedIndexChanged;
                cbxQAdv.SelectedIndex = 5;
                gbxIoControl.Visible = true;
            }
            else if (hardwareVersion.Length >= 5 && "UHF".Equals(hardwareVersion.Substring(0, 3)))
            {
                cbxPaPower.Items.Clear();
                cbxPaPower.Items.AddRange(new object[8] { "30dBm", "28.5dBm", "27dBm", "25.5dBm", "24dBm", "22.5dBm", "21dBm", "19.5dBm" });
                cbxPaPower.SelectedIndex = 2;
                cbxMixerGain.SelectedIndex = 4;
                cbxIFAmpGain.SelectedIndex = 6;
                tbxSignalThreshold.Text = "0280";
                tbxAntennaGain.Text = "4";
                tbxCoupling.Text = "-10";
                gbxIoControl.Visible = true;
            }
        }

        private void setTip()
        {
            toolTip1.SetToolTip(label1, "Available COM Port");
            toolTip1.SetToolTip(txtReceive, "Double Click To Select ALL");
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (!bAutoSend)
            {
                if (btnConn.Tag.ToString() == "0")
                {
                    Sp.GetInstance().Config(cbxPort.SelectedItem.ToString(), Convert.ToInt32(cbxBaudRate.SelectedItem.ToString()), Parity.None, 8, StopBits.One);
                    if (!Sp.GetInstance().Open())
                    {
                        MessageBox.Show("Open Serial Port Fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    btnConn.Text = "Disconnect";
                    btnConn.Tag = "1";
                    btnConn.BackColor = Color.FromArgb(128, 255, 128);
                    checkReaderAvailable();
                }
                else
                {
                    if (!Sp.GetInstance().Close())
                    {
                        MessageBox.Show("Serial Port Close Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    btnConn.Text = "Connect";
                    btnConn.Tag = "0";
                    btnConn.BackColor = Color.FromArgb(255, 128, 128);
                }
            }
            else
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void checkReaderAvailable()
        {
            if (Sp.GetInstance().IsOpen())
            {
                hardwareVersion = "";
                checkingReaderAvailable = true;
                readerConnected = false;
                Sp.GetInstance().Send(CommandModule.BuildGetModuleInfoFrame("00"));
                timerCheckReader.Enabled = true;
            }
        }

        private void cbx_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDR.SelectedIndex == 1)
            {
                MessageBox.Show("Does Not Support DR = 64/3 In this Version", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxDR.SelectedIndex = 0;
            }
        }

        private void cbx_m_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxM.SelectedIndex == 1 || cbxM.SelectedIndex == 2 || cbxM.SelectedIndex == 3)
            {
                MessageBox.Show("Does Not Support M = 2/4/8 In this Version", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxM.SelectedIndex = 0;
            }
        }

        private void cbx_trext_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTRext.SelectedIndex == 0)
            {
                MessageBox.Show("Does Not Support No Pilot Tone In this Version", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTRext.SelectedIndex = 1;
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (Sp.GetInstance().IsOpen())
            {
                bAutoSend = !bAutoSend;
                if (bAutoSend)
                {
                    timerAutoSend.Interval = Convert.ToInt32(txtSendDelay.Text);
                    timerAutoSend.Enabled = true;
                    txtSend.Text = CommandModule.BuildReadSingleFrame();
                    btnContinue.Text = "Stop";
                    tmrCheckEpc.Enabled = true;
                }
                else
                {
                    timerAutoSend.Interval = Convert.ToInt32(txtSendDelay.Text);
                    timerAutoSend.Enabled = false;
                    btnContinue.Text = "Continue";
                    tmrCheckEpc.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please Connect Serial Port！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void timerAutoSend_Tick(object sender, EventArgs e)
        {
            LoopNum_cnt++;
            try
            {
                if (Sp.GetInstance().Send(txtSend.Text) == 0)
                {
                    bAutoSend = false;
                    timerAutoSend.Enabled = false;
                    btnContinue.Text = "Continue";
                }
            }
            catch (Exception ex)
            {
                bAutoSend = false;
                timerAutoSend.Enabled = false;
                btnContinue.Text = "Continue";
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClearS_Click(object sender, EventArgs e)
        {
            txtSend.Text = "";
        }

        private void btnSetFreq_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtSend.Text = CommandModule.BuildSetRfChannelFrame(cbxChannel.SelectedIndex.ToString("X2"));
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btn_invt_Click(object sender, EventArgs e)
        {
            LoopNum_cnt++;
            txtSend.Text = CommandModule.BuildReadSingleFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void cbx_q_basic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (change_q_1st)
            {
                return;
            }
            if (bAutoSend)
            {
                if (change_q_message)
                {
                    MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    change_q_message = false;
                    cbxQBasic.SelectedIndex = cbxQAdv.SelectedIndex;
                }
                else
                {
                    change_q_message = true;
                }
                return;
            }
            int selectedIndex = cbxDR.SelectedIndex;
            int selectedIndex2 = cbxM.SelectedIndex;
            int selectedIndex3 = cbxTRext.SelectedIndex;
            int selectedIndex4 = cbxSel.SelectedIndex;
            int selectedIndex5 = cbxSession.SelectedIndex;
            int selectedIndex6 = cbxTarget.SelectedIndex;
            int selectedIndex7 = cbxQBasic.SelectedIndex;
            txtSend.Text = CommandModule.BuildSetQueryFrame(selectedIndex, selectedIndex2, selectedIndex3, selectedIndex4, selectedIndex5, selectedIndex6, selectedIndex7);
            Sp.GetInstance().Send(txtSend.Text);
            cbxQAdv.SelectedIndex = selectedIndex7;
        }

        private void btnSetCW_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (btnSetCW.Text == "CW ON")
            {
                txtSend.Text = CommandModule.BuildSetCWFrame("FF");
            }
            else
            {
                txtSend.Text = CommandModule.BuildSetCWFrame("00");
            }
            Sp.GetInstance().Send(txtSend.Text);
            if (btnSetCW.Text == "CW ON")
            {
                btnSetCW.Text = "CW OFF";
            }
            else
            {
                btnSetCW.Text = "CW ON";
            }
        }

        private void btn_clear_rx_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";
        }

        private void btn_clear_basictable_Click(object sender, EventArgs e)
        {
            basic_table.Clear();
            advanced_table.Clear();
            LoopNum_cnt = 0;
            FailEPCNum = 0;
            SucessEPCNum = 0;
            db_LoopNum_cnt = 0.0;
            for (int i = 0; i <= initDataTableLen - 1; i++)
            {
                DataRowCollection rows = basic_table.Rows;
                object[] values = new object[1];
                rows.Add(values);
            }
            basic_table.AcceptChanges();
            for (int j = 0; j <= initDataTableLen - 1; j++)
            {
                DataRowCollection rows2 = advanced_table.Rows;
                object[] values2 = new object[1];
                rows2.Add(values2);
            }
            advanced_table.AcceptChanges();
            rowIndex = 0;
        }

        private void GetEPC(string pc, string epc, string crc, string rssi, string per, string ant)
        {
            dgv_epc2.ClearSelection();
            bool flag = false;
            int num = 0;
            int count;
            if (rowIndex <= initDataTableLen)
            {
                count = rowIndex;
            }
            else
            {
                count = basic_table.Rows.Count;
                count = advanced_table.Rows.Count;
            }
            for (int i = 0; i < count; i++)
            {
                if (basic_table.Rows[i][2].ToString() == epc && basic_table.Rows[i][1].ToString() == pc)
                {
                    num = i;
                    flag = true;
                    break;
                }
            }
            if (count < initDataTableLen)
            {
                if (!flag || count == 0)
                {
                    string value = ((count + 1 >= 10) ? Convert.ToString(count + 1) : ("0" + Convert.ToString(count + 1)));
                    basic_table.Rows[count][0] = value;
                    basic_table.Rows[count][1] = pc;
                    basic_table.Rows[count][2] = epc;
                    basic_table.Rows[count][3] = crc;
                    basic_table.Rows[count][4] = rssi;
                    basic_table.Rows[count][5] = 1;
                    basic_table.Rows[count][6] = "0.000";
                    basic_table.Rows[count][7] = ant;
                    advanced_table.Rows[count][0] = value;
                    advanced_table.Rows[count][1] = pc;
                    advanced_table.Rows[count][2] = epc;
                    advanced_table.Rows[count][3] = crc;
                    advanced_table.Rows[count][4] = 1;
                    advanced_table.Rows[count][5] = ant;
                    rowIndex++;
                }
                else
                {
                    string value = ((num + 1 >= 10) ? Convert.ToString(num + 1) : ("0" + Convert.ToString(num + 1)));
                    basic_table.Rows[num][0] = value;
                    basic_table.Rows[num][4] = rssi;
                    basic_table.Rows[num][5] = Convert.ToInt32(basic_table.Rows[num][5].ToString()) + 1;
                    basic_table.Rows[num][6] = per;
                    basic_table.Rows[num][7] = ant;
                    advanced_table.Rows[num][0] = value;
                    advanced_table.Rows[num][4] = Convert.ToInt32(advanced_table.Rows[num][4].ToString()) + 1;
                    advanced_table.Rows[num][5] = ant;
                }
            }
            else if (!flag || count == 0)
            {
                string value = ((count + 1 >= 10) ? Convert.ToString(count + 1) : ("0" + Convert.ToString(count + 1)));
                basic_table.Rows.Add(value, pc, epc, crc, rssi, "1", "0.000", ant);
                advanced_table.Rows.Add(value, pc, epc, crc, "1", ant);
                rowIndex++;
            }
            else
            {
                string value = ((num + 1 >= 10) ? Convert.ToString(num + 1) : ("0" + Convert.ToString(num + 1)));
                basic_table.Rows[num][0] = value;
                basic_table.Rows[num][4] = rssi;
                basic_table.Rows[num][5] = Convert.ToInt32(basic_table.Rows[num][5].ToString()) + 1;
                basic_table.Rows[num][6] = per;
                basic_table.Rows[num][7] = ant;
                advanced_table.Rows[num][0] = value;
                advanced_table.Rows[num][4] = Convert.ToInt32(advanced_table.Rows[num][4].ToString()) + 1;
                advanced_table.Rows[num][5] = ant;
            }
        }

        private void dgvEpcBasic_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvEpcBasic.ClearSelection();
            pbx_Inv_Indicator.Visible = true;
        }

        private void dgv_epc2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgv_epc2.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dgv_epc2.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
            }
        }

        private DataTable BasicGetEPCHead()
        {
            basic_table.TableName = "EPC";
            basic_table.Columns.Add("No.", typeof(string));
            basic_table.Columns.Add("PC", typeof(string));
            basic_table.Columns.Add("EPC", typeof(string));
            basic_table.Columns.Add("CRC", typeof(string));
            basic_table.Columns.Add("RSSI(dBm)", typeof(string));
            basic_table.Columns.Add("CNT", typeof(string));
            basic_table.Columns.Add("PER(%)", typeof(string));
            basic_table.Columns.Add("ANT", typeof(string));
            for (int i = 0; i <= initDataTableLen - 1; i++)
            {
                DataRowCollection rows = basic_table.Rows;
                object[] values = new object[1];
                rows.Add(values);
            }
            basic_table.AcceptChanges();
            return basic_table;
        }

        private DataTable AdvancedGetEPCHead()
        {
            advanced_table.TableName = "EPC";
            advanced_table.Columns.Add("No.", typeof(string));
            advanced_table.Columns.Add("PC", typeof(string));
            advanced_table.Columns.Add("EPC", typeof(string));
            advanced_table.Columns.Add("CRC", typeof(string));
            advanced_table.Columns.Add("CNT", typeof(string));
            advanced_table.Columns.Add("ANT", typeof(string));
            for (int i = 0; i <= initDataTableLen - 1; i++)
            {
                DataRowCollection rows = advanced_table.Rows;
                object[] values = new object[1];
                rows.Add(values);
            }
            advanced_table.AcceptChanges();
            return advanced_table;
        }

        private void Basic_DGV_ColumnsWidth(DataGridView dataGridView1)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[1].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 290;
            dataGridView1.Columns[2].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 55;
            dataGridView1.Columns[3].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 68;
            dataGridView1.Columns[4].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Width = 65;
            dataGridView1.Columns[5].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].Width = 55;
            dataGridView1.Columns[6].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].Width = 30;
            dataGridView1.Columns[7].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Advanced_DGV_ColumnsWidth(DataGridView dataGridView1)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.Columns[0].Width = 38;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].Width = 40;
            dataGridView1.Columns[1].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].Width = 240;
            dataGridView1.Columns[2].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[3].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Width = 42;
            dataGridView1.Columns[4].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Width = 32;
            dataGridView1.Columns[5].Resizable = DataGridViewTriState.False;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btn_clear_cnt_Click(object sender, EventArgs e)
        {
            txtCOMRxCnt.Text = "0";
            txtCOMTxCnt.Text = "0";
            txtCOMRxCnt_adv.Text = "0";
            txtCOMTxCnt_adv.Text = "0";
        }

        private void btn_clear_cnt_adv_Click(object sender, EventArgs e)
        {
            txtCOMRxCnt.Text = "0";
            txtCOMTxCnt.Text = "0";
            txtCOMRxCnt_adv.Text = "0";
            txtCOMTxCnt_adv.Text = "0";
        }

        private string[] String16toString2(string S)
        {
            string[] array = new string[8];
            int num = Convert.ToInt32(S, 16);
            for (int num2 = 7; num2 >= 0; num2--)
            {
                array[num2] = "0";
                if ((double)num >= Math.Pow(2.0, num2))
                {
                    array[num2] = "1";
                }
                num -= Convert.ToInt32(array[num2]) * Convert.ToInt32(Math.Pow(2.0, num2));
            }
            return array;
        }

        private string StringToString(string S)
        {
            string text = null;
            int num = Convert.ToInt32(S, 16);
            if (num < 16)
            {
                return "0" + S;
            }
            return S;
        }

        private string[] StringArrayToStringArray(string[] S)
        {
            string[] array = new string[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                int num = Convert.ToInt32(S[i], 16);
                if (num < 16)
                {
                    array[i] = "0" + S[i];
                }
                else
                {
                    array[i] = S[i];
                }
            }
            return array;
        }

        private byte[] StringsToBytes(string[] B)
        {
            byte[] array = new byte[B.Length];
            for (int i = 0; i < B.Length; i++)
            {
                array[i] = StringToByte(B[i]);
            }
            return array;
        }

        private byte StringToByte(string Str)
        {
            for (int i = Str.Length; i < 2; i++)
            {
                Str += "0";
            }
            return (byte)Convert.ToInt32(Str, 16);
        }

        private string AutoAddSpace(string Str)
        {
            string text = string.Empty;
            int i;
            for (i = 0; i < Str.Length - 2; i += 2)
            {
                text = text + Str[i] + Str[i + 1] + " ";
            }
            if (Str.Length % 2 == 0 && Str.Length != 0)
            {
                if (Str.Length == i + 1)
                {
                    return text + Str[i];
                }
                return text + Str[i] + Str[i + 1];
            }
            return text + StringToString(Str[i].ToString());
        }

        private void txtReceive_DoubleClick(object sender, EventArgs e)
        {
            txtReceive.SelectAll();
        }

        private void txtSelMask_DoubleClick(object sender, EventArgs e)
        {
            txtSelMask.SelectAll();
        }

        private void txtSend_DoubleClick(object sender, EventArgs e)
        {
            txtSend.SelectAll();
        }

        private void txtInvtReadData_DoubleClick(object sender, EventArgs e)
        {
            txtInvtRWData.SelectAll();
        }

        private void txtGetSelMask_DoubleClick(object sender, EventArgs e)
        {
            txtGetSelMask.SelectAll();
        }

        private void btn_clear_epc2_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";
            basic_table.Clear();
            advanced_table.Clear();
            LoopNum_cnt = 0;
            FailEPCNum = 0;
            SucessEPCNum = 0;
            db_LoopNum_cnt = 0.0;
            for (int i = 0; i <= initDataTableLen - 1; i++)
            {
                DataRowCollection rows = basic_table.Rows;
                object[] values = new object[1];
                rows.Add(values);
            }
            basic_table.AcceptChanges();
            for (int j = 0; j <= initDataTableLen - 1; j++)
            {
                DataRowCollection rows2 = advanced_table.Rows;
                object[] values2 = new object[1];
                rows2.Add(values2);
            }
            advanced_table.AcceptChanges();
            rowIndex = 0;
        }

        public void dataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            int index = dgv_epc2.CurrentRow.Index;
            if (dgv_epc2.Rows[index].Cells[2].Value.ToString() != null)
            {
                txtSelMask.Text = dgv_epc2.Rows[index].Cells[2].Value.ToString();
            }
            txtSelLength.Text = (txtSelMask.Text.Replace(" ", "").Length * 4).ToString("X2");
        }

        private void btn_invt2_Click(object sender, EventArgs e)
        {
            LoopNum_cnt++;
            txtSend.Text = CommandModule.BuildReadSingleFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btn_setquery_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int selectedIndex = cbxDR.SelectedIndex;
            int selectedIndex2 = cbxM.SelectedIndex;
            int selectedIndex3 = cbxTRext.SelectedIndex;
            int selectedIndex4 = cbxSel.SelectedIndex;
            int selectedIndex5 = cbxSession.SelectedIndex;
            int selectedIndex6 = cbxTarget.SelectedIndex;
            int selectedIndex7 = cbxQAdv.SelectedIndex;
            txtSend.Text = CommandModule.BuildSetQueryFrame(selectedIndex, selectedIndex2, selectedIndex3, selectedIndex4, selectedIndex5, selectedIndex6, selectedIndex7);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btn_getquery_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildGetQueryFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btn_invt_multi_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int loopNum = Convert.ToInt32(txtRDMultiNum.Text);
            txtSend.Text = CommandModule.BuildReadMultiFrame(loopNum);
            Sp.GetInstance().Send(txtSend.Text);
            tmrCheckEpc.Enabled = true;
        }

        private void btn_stop_rd_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtSend.Text = CommandModule.BuildStopReadFrame();
            Sp.GetInstance().Send(txtSend.Text);
            tmrCheckEpc.Enabled = false;
        }

        private void select()
        {
            if (Sp.GetInstance().IsOpen())
            {
                int selectedIndex = cbxSelTarget.SelectedIndex;
                int selectedIndex2 = cbxAction.SelectedIndex;
                int selectedIndex3 = cbxSelMemBank.SelectedIndex;
                int pointer = Convert.ToInt32(txtSelPrt3.Text + txtSelPrt2.Text + txtSelPrt1.Text + txtSelPrt0.Text, 16);
                int len = Convert.ToInt32(txtSelLength.Text, 16);
                int truncated = 0;
                Sp.GetInstance().Send(CommandModule.BuildSetSelectFrame(selectedIndex, selectedIndex2, selectedIndex3, pointer, len, truncated, txtSelMask.Text));
                Thread.Sleep(20);
            }
        }

        private void btn_invtread_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = txtRwAccPassWord.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int sa = Convert.ToInt32(txtWordPtr1.Text.Replace(" ", "") + txtWordPtr0.Text.Replace(" ", ""), 16);
            int dl = Convert.ToInt32(txtWordCnt1.Text.Replace(" ", "") + txtWordCnt0.Text.Replace(" ", ""), 16);
            int selectedIndex = cbxMemBank.SelectedIndex;
            select();
            txtSend.Text = CommandModule.BuildReadDataFrame(text, selectedIndex, sa, dl);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private string int2HexString(int a)
        {
            string s = Convert.ToByte(a).ToString("x").ToUpper();
            return StringToString(s);
        }

        private void btnSetSelect_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int selectedIndex = cbxSelTarget.SelectedIndex;
            int selectedIndex2 = cbxAction.SelectedIndex;
            int selectedIndex3 = cbxSelMemBank.SelectedIndex;
            int pointer = Convert.ToInt32(txtSelPrt3.Text + txtSelPrt2.Text + txtSelPrt1.Text + txtSelPrt0.Text, 16);
            int len = Convert.ToInt32(txtSelLength.Text, 16);
            int truncated = 0;
            if (ckxTruncated.Checked)
            {
                truncated = 128;
            }
            txtSend.Text = CommandModule.BuildSetSelectFrame(selectedIndex, selectedIndex2, selectedIndex3, pointer, len, truncated, txtSelMask.Text);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnGetSelect_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildGetSelectFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnInvtWrtie_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = txtRwAccPassWord.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text2 = txtInvtRWData.Text.Replace(" ", "");
            int selectedIndex = cbxMemBank.SelectedIndex;
            int sa = Convert.ToInt32(txtWordPtr1.Text.Replace(" ", "") + txtWordPtr0.Text.Replace(" ", ""), 16);
            int dl = text2.Length / 4;
            if (text2.Length % 4 != 0)
            {
                MessageBox.Show("The Write Data's Length Should Be Integer Multiples Words", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildWriteDataFrame(text, selectedIndex, sa, dl, text2);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            if (textBoxLockAccessPwd.Text.Length != 0)
            {
                if (bAutoSend)
                {
                    MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                select();
                int ld = buildLockPayload();
                txtSend.Text = CommandModule.BuildLockFrame(textBoxLockAccessPwd.Text, ld);
                Sp.GetInstance().Send(txtSend.Text);
            }
        }

        private int buildLockPayload()
        {
            int num = 0;
            if (checkBoxKillPwd.Checked)
            {
                Commands.lock_payload_type lock_payload_type = Commands.genLockPayload((byte)cbxLockKillAction.SelectedIndex, 0);
                num |= (lock_payload_type.byte0 << 16) | (lock_payload_type.byte1 << 8) | lock_payload_type.byte2;
            }
            if (checkBoxAccessPwd.Checked)
            {
                Commands.lock_payload_type lock_payload_type = Commands.genLockPayload((byte)cbxLockAccessAction.SelectedIndex, 1);
                num |= (lock_payload_type.byte0 << 16) | (lock_payload_type.byte1 << 8) | lock_payload_type.byte2;
            }
            if (checkBoxEPC.Checked)
            {
                Commands.lock_payload_type lock_payload_type = Commands.genLockPayload((byte)cbxLockEPCAction.SelectedIndex, 2);
                num |= (lock_payload_type.byte0 << 16) | (lock_payload_type.byte1 << 8) | lock_payload_type.byte2;
            }
            if (checkBoxTID.Checked)
            {
                Commands.lock_payload_type lock_payload_type = Commands.genLockPayload((byte)cbxLockTIDAction.SelectedIndex, 3);
                num |= (lock_payload_type.byte0 << 16) | (lock_payload_type.byte1 << 8) | lock_payload_type.byte2;
            }
            if (checkBoxUser.Checked)
            {
                Commands.lock_payload_type lock_payload_type = Commands.genLockPayload((byte)cbxLockUserAction.SelectedIndex, 4);
                num |= (lock_payload_type.byte0 << 16) | (lock_payload_type.byte1 << 8) | lock_payload_type.byte2;
            }
            return num;
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            if (textBoxKillPwd.Text.Length == 0)
            {
                return;
            }
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = textBoxKillPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Kill password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int num = 0;
            string text2 = textBoxKillRFU.Text.Replace(" ", "");
            if (text2.Length == 0)
            {
                num = 0;
            }
            else
            {
                if (text2.Length != 3)
                {
                    MessageBox.Show("Kill RFU/Recom should be 3 bits!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    num = Convert.ToInt32(text2, 2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Convert Kill RFU fail." + ex.Message);
                    MessageBox.Show("Kill RFU/Recom should be 3 bits!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            select();
            txtSend.Text = CommandModule.BuildKillFrame(text, num);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void inv_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (inv_mode.Checked)
            {
                txtSend.Text = CommandModule.BuildSetInventoryModeFrame("00");
            }
            else
            {
                txtSend.Text = CommandModule.BuildSetInventoryModeFrame("01");
            }
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void ckxTruncated_CheckedChanged(object sender, EventArgs e)
        {
            if (ckxTruncated.Checked)
            {
                int selectedIndex = cbxSelTarget.SelectedIndex;
                int selectedIndex2 = cbxSelMemBank.SelectedIndex;
                if (selectedIndex != 4 || selectedIndex2 != 1)
                {
                    MessageBox.Show("Select Target should be 100 and MemBank should be EPC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ckxTruncated.Checked = false;
                }
            }
        }

        private void btnSetFhss_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (btnSetFhss.Text == "FHSS ON")
            {
                txtSend.Text = CommandModule.BuildSetFhssFrame("FF");
            }
            else
            {
                txtSend.Text = CommandModule.BuildSetFhssFrame("00");
            }
            Sp.GetInstance().Send(txtSend.Text);
            if (btnSetFhss.Text == "FHSS ON")
            {
                btnSetFhss.Text = "FHSS OFF";
            }
            else
            {
                btnSetFhss.Text = "FHSS ON";
            }
        }

        private void btnSetRegion_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string hexText = string.Empty;
            if (cbxRegion.SelectedIndex == 0)
            {
                hexText = CommandModule.BuildSetRegionFrame("01");
                curRegion = "01";
            }
            else if (cbxRegion.SelectedIndex == 1)
            {
                hexText = CommandModule.BuildSetRegionFrame("04");
                curRegion = "04";
            }
            else if (cbxRegion.SelectedIndex == 2)
            {
                hexText = CommandModule.BuildSetRegionFrame("02");
                curRegion = "02";
            }
            else if (cbxRegion.SelectedIndex == 3)
            {
                hexText = CommandModule.BuildSetRegionFrame("03");
                curRegion = "03";
            }
            else if (cbxRegion.SelectedIndex == 4)
            {
                hexText = CommandModule.BuildSetRegionFrame("06");
                curRegion = "06";
            }
            txtSend.Text = hexText;
            Sp.GetInstance().Send(hexText);
            cbxChannel.SelectedIndex = 0;
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxChannel.Items.Clear();
            switch (cbxRegion.SelectedIndex)
            {
                case 0:
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            cbxChannel.Items.Add(920.125 + (double)j * 0.25 + "MHz");
                        }
                        break;
                    }
                case 1:
                    {
                        for (int l = 0; l < 20; l++)
                        {
                            cbxChannel.Items.Add(840.125 + (double)l * 0.25 + "MHz");
                        }
                        break;
                    }
                case 2:
                    {
                        for (int m = 0; m < 52; m++)
                        {
                            cbxChannel.Items.Add(902.25 + (double)m * 0.5 + "MHz");
                        }
                        break;
                    }
                case 3:
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            cbxChannel.Items.Add(865.1 + (double)k * 0.2 + "MHz");
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < 32; i++)
                        {
                            cbxChannel.Items.Add(917.1 + (double)i * 0.2 + "MHz");
                        }
                        break;
                    }
            }
            cbxChannel.SelectedIndex = 0;
        }

        private void btnGetChannel_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtSend.Text = CommandModule.BuildGetRfChannelFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSetPaPower_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int num = 0;
            float num2 = 0f;
            try
            {
                num2 = float.Parse(cbxPaPower.SelectedItem.ToString().Replace("dBm", ""));
                num = (int)(num2 * 100f);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                num = cbxPaPower.SelectedIndex switch
                {
                    5 => 1250,
                    4 => 1400,
                    3 => 1550,
                    2 => 1700,
                    1 => 1850,
                    0 => 2000,
                    _ => 2000,
                };
            }
            txtSend.Text = CommandModule.BuildSetPaPowerFrame((short)num);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnGetPaPower_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtSend.Text = CommandModule.BuildGetPaPowerFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSetModemPara_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            int selectedIndex = cbxMixerGain.SelectedIndex;
            int selectedIndex2 = cbxIFAmpGain.SelectedIndex;
            int signalThreshold = Convert.ToInt32(tbxSignalThreshold.Text, 16);
            txtSend.Text = CommandModule.BuildSetModemParaFrame(selectedIndex, selectedIndex2, signalThreshold);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnGetModemPara_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtSend.Text = CommandModule.BuildReadModemParaFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private string ParseErrCode(int errorCode)
        {
            return (errorCode & 0xF) switch
            {
                0 => "Other Error",
                3 => "Memory Overrun",
                4 => "Memory Locked",
                11 => "Insufficient Power",
                15 => "Non-specific Error",
                _ => "Non-specific Error",
            };
        }

        private void btnScanJammer_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildScanJammerFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void saveAsTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.csv|*.CSV|*.*|(*.*)";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = saveFileDialog.FileName;
            FileInfo fileInfo = new FileInfo(fileName);
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = fileInfo.CreateText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                streamWriter.Write("No.,PC,EPC,CRC,RSSI(dBm),CNT,PER(%),");
                streamWriter.WriteLine();
                for (int i = 0; i < basic_table.Rows.Count; i++)
                {
                    for (int j = 0; j < basic_table.Columns.Count; j++)
                    {
                        streamWriter.Write(basic_table.Rows[i][j].ToString() + ",");
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnScanRssi_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildScanRssiFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void timerCheckReader_Tick(object sender, EventArgs e)
        {
            timerCheckReader.Enabled = false;
            if (hardwareVersion == "")
            {
                MessageBox.Show("Connect Reader Failed, Please Check if Firmware Downloaded!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                readerConnected = false;
            }
            else
            {
                readerConnected = true;
            }
        }

        private void Reset_FW_Click(object sender, EventArgs e)
        {
            txtSend.Text = "AA 00 55 00 00 55 DD";
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void tmrCheckEpc_Tick(object sender, EventArgs e)
        {
            if (lastRecCnt == Convert.ToInt32(txtCOMRxCnt.Text))
            {
                tmrCheckEpc.Enabled = false;
                return;
            }
            lastRecCnt = Convert.ToInt32(txtCOMRxCnt.Text);
            DateTime now = DateTime.Now;
            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
            dateTimeFormatInfo.LongDatePattern = timeFormat;
            int num = 10 * tmrCheckEpc.Interval;
            for (int i = 0; i < dgvEpcBasic.Rows.Count; i++)
            {
                string text = dgvEpcBasic.Rows[i].Cells[7].Value.ToString();
                if (text != null && !"".Equals(text) && DateTime.TryParse(text, out var result))
                {
                    TimeSpan timeSpan = now.Subtract(result);
                    if (timeSpan.TotalMilliseconds > (double)num)
                    {
                        dgvEpcBasic.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        continue;
                    }
                    int num2 = 0xFF & (int)(timeSpan.TotalMilliseconds / (double)num * 255.0);
                    dgvEpcBasic.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255 - num2, 255 - num2);
                }
            }
        }

        private void btnSetIO_Click(object sender, EventArgs e)
        {
            byte optType = 1;
            byte ioPort = (byte)(cbxIO.SelectedIndex + 1);
            byte modeOrLevel = (byte)cbxIoLevel.SelectedIndex;
            txtSend.Text = CommandModule.BuildIoControlFrame(optType, ioPort, modeOrLevel);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSetIoDirection_Click(object sender, EventArgs e)
        {
        }

        private void btnGetIO_Click(object sender, EventArgs e)
        {
            byte optType = 2;
            byte ioPort = (byte)(cbxIO.SelectedIndex + 1);
            byte modeOrLevel = 0;
            txtSend.Text = CommandModule.BuildIoControlFrame(optType, ioPort, modeOrLevel);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSetMode_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildSetReaderEnvModeFrame((byte)cbxMode.SelectedIndex);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSaveConfigToNv_Click(object sender, EventArgs e)
        {
            byte nVenable = (byte)(cbxSaveNvConfig.Checked ? 1 : 0);
            txtSend.Text = CommandModule.BuildSaveConfigToNvFrame(nVenable);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnSetModuleSleep_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildSetModuleSleepFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnInsertRfCh_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtChIndexBegin.Text);
            int num2 = Convert.ToInt32(txtChIndexEnd.Text);
            byte b = (byte)(num2 - num + 1);
            byte[] array = new byte[b];
            for (int i = num; i <= num2; i++)
            {
                array[i - num] = (byte)i;
            }
            txtSend.Text = CommandModule.BuildInsertRfChFrame(b, array);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnChangeConfig_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = tbxNxpCmdAccessPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildNXPChangeConfigFrame(text, Convert.ToInt32(txtConfigData.Text.Replace(" ", ""), 16));
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnChangeEas_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = tbxNxpCmdAccessPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildNXPChangeEasFrame(text, cbxSetEas.Checked);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnEasAlarm_Click(object sender, EventArgs e)
        {
            txtSend.Text = CommandModule.BuildNXPEasAlarmFrame();
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnReadProtect_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = tbxNxpCmdAccessPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildNXPReadProtectFrame(text, cbxReadProtectReset.Checked);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnChangeBaudrate_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(cbxBaudRate.SelectedItem.ToString(), 10) / 100;
            txtSend.Text = CommandModule.BuildFrame("00", "11", num.ToString("X4"));
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void txtOperateEpc_DoubleClick(object sender, EventArgs e)
        {
            txtOperateEpc.SelectAll();
        }

        private void btnMonzaQTRead_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = tbxMonzaQTAccessPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildMonzaQTFrame(text, isWrite: false, cbxMonzaQT_SR.Checked, cbxMonzaQT_MEM.Checked);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void btnMonzaQTWrite_Click(object sender, EventArgs e)
        {
            if (bAutoSend)
            {
                MessageBox.Show("Please Stop Continuous Inventory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string text = tbxMonzaQTAccessPwd.Text.Replace(" ", "");
            if (text.Length != 8)
            {
                MessageBox.Show("Access password should be two words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            select();
            txtSend.Text = CommandModule.BuildMonzaQTFrame(text, isWrite: true, cbxMonzaQT_SR.Checked, cbxMonzaQT_MEM.Checked);
            Sp.GetInstance().Send(txtSend.Text);
        }

        private void getFirmwareVersion()
        {
            Sp.GetInstance().Send(CommandModule.BuildGetModuleInfoFrame("01"));
        }

        private void getSwitchAnt()
        {
            Sp.GetInstance().Send(CommandModule.BuildGetPaAntFrame());
        }

        private void setSwitchAnt(short Ant, byte staytime)
        {
            Sp.GetInstance().Send(CommandModule.BuildSetPaAntFrame(Ant, staytime));
        }

        private void cbxAutoClear_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SetAnt_Click(object sender, EventArgs e)
        {
            short num = 0;
            if (ANT1.Checked)
            {
                num |= 1;
            }
            if (ANT2.Checked)
            {
                num |= 2;
            }
            if (ANT3.Checked)
            {
                num |= 4;
            }
            if (ANT4.Checked)
            {
                num |= 8;
            }
            if (ANT5.Checked)
            {
                num |= 0x10;
            }
            if (ANT6.Checked)
            {
                num |= 0x20;
            }
            if (ANT7.Checked)
            {
                num |= 0x40;
            }
            if (ANT8.Checked)
            {
                num |= 0x80;
            }
            byte staytime = (byte)Convert.ToInt32(AntStayTime.Text);
            setSwitchAnt(num, staytime);
        }
    }
}
