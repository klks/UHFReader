using System;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ReaderB;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Versioning;
using Utilities;

namespace LJYZN_105
{
    [SupportedOSPlatform("windows")]

    public partial class MainForm : Form
    {
        private bool fAppClosed; //在测试模式下响应关闭应用程序
        private byte fComAdr = 0xff; //当前操作的ComAdr
        private int ferrorcode;
        private byte fBaud;
        private double fdminfre;
        private double fdmaxfre;
        private byte Maskadr;
        private byte MaskLen;
        private byte MaskFlag;
        private int fCmdRet = 30; //所有执行指令的返回值
        private int fOpenComIndex; //打开的串口索引号
        private bool fIsInventoryScan;
        private bool fisinventoryscan_6B;
        private byte[] fOperEPC = new byte[36];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[8];
        private int CardNum1 = 0;
        ArrayList list = new ArrayList();
        private bool fTimer_6B_ReadWrite;
        private string fInventory_EPC_List = ""; //Store the query list (if the read data does not change, it will not be refreshed)
        private int frmcomportindex;
        private bool ComOpen = false;
        private string strDefaultKey = "00000000";

        public MainForm()
        {
            InitializeComponent();
        }
        private void RefreshStatus()
        {
            if (!(cbReader_AlreadyOpenCOM.Items.Count != 0))
                tss_COM.Text = "COM Closed";
            else
                tss_COM.Text = " COM" + Convert.ToString(frmcomportindex);
        }
        private string GetReturnCodeDesc(int cmdRet)
        {
            Dictionary<int, string> retDescription = new Dictionary<int, string>
            {
                { 0x00, "Operation Success" },
                { 0x01, "Return before Inventory finished" },
                { 0x02, "The Inventory-scan-time overflow" },
                { 0x03, "More Data" },
                { 0x04, "Reader module MCU is Full" },
                { 0x05, "Access password error" },
                { 0x09, "Kill password error" },
                { 0x0A, "Kill password error, cannot be Zero" },
                { 0x0B, "Tag does not support the command" },
                { 0x0C, "Use the commmand, Access Password Cannot be Zero" },
                { 0x0D, "Tag is protected, cannot set it again" },
                { 0x0E, "Tag is unprotected, no need to reset it" },
                { 0x10, "There is some locked bytes,write fail" },
                { 0x11, "Can not lock it" },
                { 0x12, "Already locked, cannot lock it again" },
                { 0x13, "Parameter Save Fail, can Use Before Power" },
                { 0x14, "Cannot adjust" },
                { 0x15, "Return before Inventory finished" },
                { 0x16, "Inventory-Scan-Time overflow" },
                { 0x17, "More Data" },
                { 0x18, "Reader module MCU is full" },
                { 0x19, "Command not supported or Access Password cannot be zero" },
                { 0x30, "Communication error" },
                { 0x31, "CRC checksummat error" },
                { 0x32, "Return data length error" },
                { 0x33, "Communication busy" },
                { 0x34, "Busy,command is being executed" },
                { 0x35, "ComPort Opened" },
                { 0x36, "ComPort Closed" },
                { 0x37, "Invalid Handle" },
                { 0x38, "Invalid Port" },
                { 0xEE, "Return command error" },
                { 0xF9, "Command Execute Error" },
                { 0xFA, "Get Tag, Poor Communication, Inoperable" },
                { 0xFB, "No Tag Operable" },
                { 0xFC, "Tag Return ErrorCode" },
                { 0xFD, "Command length wrong" },
                { 0xFE, "Illegal command" },
                { 0xFF, "Parameter Error" }
            };
            return retDescription.GetValueOrDefault(cmdRet, "");
        }
        private string GetErrorCodeDesc(int cmdRet)
        {
            Dictionary<int, string> errDescription = new Dictionary<int, string>
            {
                { 0x00, "Other error" },
                { 0x03, "Memory out or pc not support" },
                { 0x04, "Memory locked and unwritable" },
                { 0x0b, "No Power, memory write operation cannot be executed" },
                { 0x0f, "Not Special Error,tag not support special errorcode" }
            };
            return errDescription.GetValueOrDefault(cmdRet, "");
        }

        private byte[] HexStringToByteArray(string? s)
        {
            if (s == null || s == "")
                return [];

            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
        private void AddCmdLog(string CMD, string cmdStr, int cmdRet)
        {
            try
            {
                tss_Status.Text = "";
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " " + cmdStr + ": " + GetReturnCodeDesc(cmdRet);
            }
            finally { }
        }
        private void AddCmdLog(string CMD, string cmdStr, int cmdRet, int errocode)
        {
            try
            {
                tss_Status.Text = "";

                if (cmdRet == 0xFC)
                {
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " " +
                                        cmdStr + " : " +
                                        GetReturnCodeDesc(cmdRet) + " " + "0x" + Convert.ToString(errocode, 16).PadLeft(2, '0') +
                                        " (" + GetErrorCodeDesc(ferrorcode) + ")"; ;
                }
                else
                {
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " " +
                                        cmdStr + " : " +
                                        GetReturnCodeDesc(cmdRet) + " " + "0x" + Convert.ToString(errocode, 16).PadLeft(2, '0');
                }

            }
            finally { }
        }
        private void ClearLastInfo()
        {
            cbReader_AlreadyOpenCOM.Refresh();
            RefreshStatus();
            Edit_Type.Text = "";
            Edit_Version.Text = "";
            ISO180006B.Checked = false;
            EPCC1G2.Checked = false;
            Edit_ComAdr.Text = "";
            Edit_powerdBm.Text = "";
            Edit_scantime.Text = "";
            Edit_dminfre.Text = "";
            Edit_dmaxfre.Text = "";
            //  PageControl1.TabIndex = 0;
        }
        private void InitComList()
        {
            int i = 0;
            cbReader_COM.Items.Clear();
            cbReader_COM.Items.Add(" AUTO");
            for (i = 1; i < 13; i++)
                cbReader_COM.Items.Add(" COM" + Convert.ToString(i));
            cbReader_COM.SelectedIndex = 0;
            RefreshStatus();
        }
        private void InitReaderList()
        {
            int i = 0;
            // ComboBox_PowerDbm.SelectedIndex = 0;
            cbReader_SetBaud.SelectedIndex = 3;
            for (i = 0; i < 63; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(902.6 + i * 0.4) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(902.6 + i * 0.4) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 62;
            ComboBox_dminfre.SelectedIndex = 0;
            for (i = 0x03; i <= 0xff; i++)
                ComboBox_scantime.Items.Add(Convert.ToString(i) + "*100ms");
            ComboBox_scantime.SelectedIndex = 7;
            i = 40;
            while (i <= 300)
            {
                ComboBox_IntervalTime.Items.Add(Convert.ToString(i) + "ms");
                i = i + 10;
            }
            ComboBox_IntervalTime.SelectedIndex = 1;
            for (i = 0; i < 7; i++)
                ComboBox_BlockNum.Items.Add(Convert.ToString(i * 2) + " and " + Convert.ToString(i * 2 + 1));
            ComboBox_BlockNum.SelectedIndex = 0;
            i = 40;
            while (i <= 300)
            {
                ComboBox_IntervalTime_6B.Items.Add(Convert.ToString(i) + "ms");
                i = i + 10;
            }
            ComboBox_IntervalTime_6B.SelectedIndex = 1;

            ComboBox_PowerDbm.SelectedIndex = 13;
            rbReader_FreqBand_User.Checked = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            fOpenComIndex = -1;
            fComAdr = 0;
            ferrorcode = -1;
            fBaud = 5;
            InitComList();
            InitReaderList();
            NoAlarm_G2.Checked = true;

            Byone_6B.Checked = true;
            Different_6B.Checked = true;

            P_EPC.Checked = true;
            C_EPC.Checked = true;
            DestroyCode.Checked = true;
            NoProect.Checked = true;
            NoProect2.Checked = true;
            fAppClosed = false;
            fIsInventoryScan = false;
            fisinventoryscan_6B = false;
            fTimer_6B_ReadWrite = false;
            Label_Alarm.Visible = false;
            Timer_Test_.Enabled = false;
            Timer_G2_Read.Enabled = false;
            Timer_G2_Alarm.Enabled = false;

            btnReader_GetReaderInfo.Enabled = false;
            btnReader_SetParameter.Enabled = false;
            btnReader_SetDefaultParameter.Enabled = false;
            Button_QueryTag.Enabled = false;
            Button_DestroyCard.Enabled = false;
            Button_WriteEPC_G2.Enabled = false;
            Button_SetReadProtect_G2.Enabled = false;
            Button_SetMultiReadProtect_G2.Enabled = false;
            Button_RemoveReadProtect_G2.Enabled = false;
            Button_CheckReadProtected_G2.Enabled = false;
            Button_SetEASAlarm_G2.Enabled = false;
            Button_CheckEASAlarm_G2.Enabled = false;
            Button_LockUserBlock_G2.Enabled = false;
            SpeedButton_Read_G2.Enabled = false;
            Button_DataWrite.Enabled = false;
            Button_BlockWrite.Enabled = false;
            Button_BlockErase.Enabled = false;
            Button_SetProtectState.Enabled = false;
            SpeedButton_Query_6B.Enabled = false;
            SpeedButton_Read_6B.Enabled = false;
            SpeedButton_Write_6B.Enabled = false;
            SpeedButton_Perm_Wr_Prot_6B.Enabled = false;
            SpeedButton_Check_6B.Enabled = false;

            gbLockPassword.Enabled = false;
            gbLockTIDnUSER.Enabled = false;

            P_Reserve.Enabled = false;
            P_EPC.Enabled = false;
            P_TID.Enabled = false;
            P_User.Enabled = false;
            Same_6B.Enabled = false;
            Different_6B.Enabled = false;
            Less_6B.Enabled = false;
            Greater_6B.Enabled = false;
            cbReader_ComBaud.SelectedIndex = 3;
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timer_Test_.Enabled = false;
            Timer_G2_Read.Enabled = false;
            Timer_G2_Alarm.Enabled = false;
            fAppClosed = true;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            Timer_G2_Alarm.Enabled = false;
            Timer_G2_Read.Enabled = false;
            Timer_Test_.Enabled = false;
            SpeedButton_Read_G2.Text = "Read";
            Button_QueryTag.Text = "Query Tag";
            Button_CheckEASAlarm_G2.Text = "Check Alarm";
            if ((ListView1_EPC.Items.Count != 0) && (ComOpen))
            {
                Button_QueryTag.Enabled = true;
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = true;

                P_Reserve.Enabled = true;
                P_EPC.Enabled = true;
                P_TID.Enabled = true;
                P_User.Enabled = true;
                Button_DestroyCard.Enabled = true;
                Button_SetReadProtect_G2.Enabled = true;
                Button_SetEASAlarm_G2.Enabled = true;
                Alarm_G2.Enabled = true;
                NoAlarm_G2.Enabled = true;
                Button_LockUserBlock_G2.Enabled = true;
                Button_WriteEPC_G2.Enabled = true;
                Button_SetMultiReadProtect_G2.Enabled = true;
                Button_RemoveReadProtect_G2.Enabled = true;
                Button_CheckReadProtected_G2.Enabled = true;
                Button_CheckEASAlarm_G2.Enabled = true;
                SpeedButton_Read_G2.Enabled = true;
                Button_SetProtectState.Enabled = true;
                Button_DataWrite.Enabled = true;
                Button_BlockWrite.Enabled = true;
                Button_BlockErase.Enabled = true;
                checkBox1.Enabled = true;
            }
            if ((ListView1_EPC.Items.Count == 0) && (ComOpen))
            {
                Button_QueryTag.Enabled = true;
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = false;

                P_Reserve.Enabled = false;
                P_EPC.Enabled = false;
                P_TID.Enabled = false;
                P_User.Enabled = false;
                Button_DestroyCard.Enabled = false;
                Button_SetReadProtect_G2.Enabled = false;
                Button_SetEASAlarm_G2.Enabled = false;
                Alarm_G2.Enabled = false;
                NoAlarm_G2.Enabled = false;
                Button_LockUserBlock_G2.Enabled = false;
                SpeedButton_Read_G2.Enabled = false;
                Button_DataWrite.Enabled = false;
                Button_BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;
                Button_WriteEPC_G2.Enabled = true;
                Button_SetMultiReadProtect_G2.Enabled = true;
                Button_RemoveReadProtect_G2.Enabled = true;
                Button_CheckReadProtected_G2.Enabled = true;
                Button_CheckEASAlarm_G2.Enabled = true;
                Button_SetProtectState.Enabled = false;
                checkBox1.Enabled = false;
            }

            Timer_Test_6B.Enabled = false;
            Timer_6B_Read.Enabled = false;
            Timer_6B_Write.Enabled = false;
            SpeedButton_Query_6B.Text = "Query";
            SpeedButton_Read_6B.Text = "Read";
            SpeedButton_Write_6B.Text = "Write";
            if ((lv6B_Tags.Items.Count != 0) && (ComOpen))
            {
                SpeedButton_Query_6B.Enabled = true;
                SpeedButton_Read_6B.Enabled = true;
                SpeedButton_Write_6B.Enabled = true;
                SpeedButton_Perm_Wr_Prot_6B.Enabled = true;
                SpeedButton_Check_6B.Enabled = true;
                if (Bycondition_6B.Checked)
                {
                    Same_6B.Enabled = true;
                    Different_6B.Enabled = true;
                    Less_6B.Enabled = true;
                    Greater_6B.Enabled = true;
                }
            }
            if ((lv6B_Tags.Items.Count == 0) && (ComOpen))
            {
                SpeedButton_Query_6B.Enabled = true;
                SpeedButton_Read_6B.Enabled = false;
                SpeedButton_Write_6B.Enabled = false;
                SpeedButton_Perm_Wr_Prot_6B.Enabled = false;
                SpeedButton_Check_6B.Enabled = false;
                if (Bycondition_6B.Checked)
                {
                    Same_6B.Enabled = true;
                    Different_6B.Enabled = true;
                    Less_6B.Enabled = true;
                    Greater_6B.Enabled = true;
                }
            }

        }
        private void ComboBox_COM_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbReader_ComBaud.Items.Clear();
            if (cbReader_COM.SelectedIndex == 0)
            {
                cbReader_ComBaud.Items.AddRange(new object[] { "9600bps", "19200bps", "38400bps", "57600bps", "115200bps" });
                cbReader_ComBaud.SelectedIndex = 3;
            }
            else
            {
                cbReader_ComBaud.Items.Add("Auto");
                cbReader_ComBaud.SelectedIndex = 0;
            }
        }
        private void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_KeyPress(sender, e);
        }

        private void filterOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyDigits_KeyPress(sender, e);
        }

        private void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
        }

        private void filterOnlyDigits_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyDigits_TextChanged(sender, e);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fOpenComIndex != -1)
            {
                StaticClassReaderB.CloseComPort();
            }
        }
    }
}