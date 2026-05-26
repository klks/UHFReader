using Microsoft.VisualBasic.ApplicationServices;
using ReaderB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Utilities;

namespace LJYZN_105
{
    public partial class Form_Reader : UserControl
    {
        public Form_Reader()
        {
            InitializeComponent();
        }

        #region textbox filter methods
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
        #endregion

        private void Form_Reader_Load(object sender, EventArgs e)
        {
            int i = 0;
            cbReader_COM.Items.Clear();
            cbReader_COM.Items.Add(" AUTO");
            for (i = 1; i < 50; i++)
                cbReader_COM.Items.Add(" COM" + Convert.ToString(i));
            cbReader_COM.SelectedIndex = 0;

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

            ComboBox_PowerDbm.SelectedIndex = 13;
            rbReader_FreqBand_User.Checked = true;

            cbReader_ComBaud.SelectedIndex = 3;

            progressBar1.Visible = false;

            RefreshStatus();
        }

        public void RefreshStatus()
        {
            if (!(cbReader_AlreadyOpenCOM.Items.Count != 0))
                FormSharedData.tss_Status.Text = "COM Closed";
            else
                FormSharedData.tss_Status.Text = " COM" + Convert.ToString(FormSharedData.frmcomportindex);
        }

        public void ClearLastInfo()
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

        private void btnReader_OpenPort_Click(object sender, EventArgs e)
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            if (txtReader_CmdComAddr.Text == "")
                txtReader_CmdComAddr.Text = "FF";
            FormSharedData.fComAdr = Convert.ToByte(txtReader_CmdComAddr.Text, 16); // $FF;
            try
            {
                if (cbReader_COM.SelectedIndex == 0)//Auto
                {
                    FormSharedData.fBaud = Convert.ToByte(cbReader_ComBaud.SelectedIndex);
                    if (FormSharedData.fBaud > 2)
                    {
                        FormSharedData.fBaud = Convert.ToByte(FormSharedData.fBaud + 2);
                    }
                    openresult = (int)StaticClassReaderB.AutoOpenComPort(ref port, ref FormSharedData.fComAdr, FormSharedData.fBaud, ref FormSharedData.frmcomportindex);
                    FormSharedData.fOpenComIndex = FormSharedData.frmcomportindex;
                    if (openresult == 0)
                    {
                        FormSharedData.ComOpen = true;
                        // Button3_Click(sender, e); //自动执行读取写卡器信息
                        if (FormSharedData.fBaud > 3)
                        {
                            cbReader_SetBaud.SelectedIndex = Convert.ToInt32(FormSharedData.fBaud - 2);
                        }
                        else
                        {
                            cbReader_SetBaud.SelectedIndex = Convert.ToInt32(FormSharedData.fBaud);
                        }
                        btnReader_GetReaderInfo_Click(sender, e); //自动执行读取写卡器信息
                        if ((FormSharedData.fCmdRet == 0x35) | (FormSharedData.fCmdRet == 0x30))
                        {
                            MessageBox.Show("Serial Communication Error or Occupied", "Information");
                            StaticClassReaderB.CloseSpecComPort(FormSharedData.frmcomportindex);
                            FormSharedData.ComOpen = false;
                        }
                    }
                }
                else
                {
                    temp = cbReader_COM.SelectedItem.ToString();
                    temp = temp.Trim();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    for (i = 6; i >= 0; i--)
                    {
                        FormSharedData.fBaud = Convert.ToByte(i);
                        if (FormSharedData.fBaud == 3)
                            continue;
                        uint ph = 0;
                        openresult = (int)StaticClassReaderB.OpenComPort(port, ref FormSharedData.fComAdr, FormSharedData.fBaud, ref ph);
                        FormSharedData.frmcomportindex = (int)ph;
                        FormSharedData.fOpenComIndex = FormSharedData.frmcomportindex;
                        if (openresult == 0x35)
                        {
                            MessageBox.Show("COM Opened", "Information");
                            return;
                        }
                        if (openresult == 0)
                        {
                            FormSharedData.ComOpen = true;
                            btnReader_GetReaderInfo_Click(sender, e); //自动执行读取写卡器信息
                            if (FormSharedData.fBaud > 3)
                            {
                                cbReader_SetBaud.SelectedIndex = Convert.ToInt32(FormSharedData.fBaud - 2);
                            }
                            else
                            {
                                cbReader_SetBaud.SelectedIndex = Convert.ToInt32(FormSharedData.fBaud);
                            }
                            if ((FormSharedData.fCmdRet == 0x35) || (FormSharedData.fCmdRet == 0x30))
                            {
                                FormSharedData.ComOpen = false;
                                MessageBox.Show("Serial Communication Error or Occupied", "Information");
                                StaticClassReaderB.CloseSpecComPort(FormSharedData.frmcomportindex);
                                return;
                            }
                            RefreshStatus();
                            break;
                        }

                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if ((FormSharedData.fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                cbReader_AlreadyOpenCOM.Items.Add("COM" + Convert.ToString(FormSharedData.fOpenComIndex));
                cbReader_AlreadyOpenCOM.SelectedIndex = cbReader_AlreadyOpenCOM.SelectedIndex + 1;
                btnReader_GetReaderInfo.Enabled = true;
                btnReader_SetParameter.Enabled = true;
                btnReader_SetDefaultParameter.Enabled = true;
                FormSharedData.ComOpen = true;
            }
            if ((FormSharedData.fOpenComIndex == -1) && (openresult == 0x30))
                MessageBox.Show("Serial Communication Error", "Information");

            if ((cbReader_AlreadyOpenCOM.Items.Count != 0) & (FormSharedData.fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30) & (FormSharedData.fCmdRet == 0))
            {
                FormSharedData.fComAdr = Convert.ToByte(Edit_ComAdr.Text, 16);
                temp = cbReader_AlreadyOpenCOM.SelectedItem.ToString();
                FormSharedData.frmcomportindex = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
            }
            RefreshStatus();
        }

        private void btnReader_ClosePort_Click(object sender, EventArgs e)
        {
            int port;
            //string SelectCom ;
            string temp;
            ClearLastInfo();
            try
            {
                if (cbReader_AlreadyOpenCOM.SelectedIndex < 0)
                {
                    MessageBox.Show("Please Choose COM Port to close", "Information");
                }
                else
                {
                    temp = cbReader_AlreadyOpenCOM.SelectedItem.ToString();
                    port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                    FormSharedData.fCmdRet = (int)StaticClassReaderB.CloseSpecComPort(port);
                    if (FormSharedData.fCmdRet == 0)
                    {
                        cbReader_AlreadyOpenCOM.Items.RemoveAt(0);
                        if (cbReader_AlreadyOpenCOM.Items.Count != 0)
                        {
                            temp = cbReader_AlreadyOpenCOM.SelectedItem.ToString();
                            port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                            StaticClassReaderB.CloseSpecComPort(port);
                            FormSharedData.fComAdr = 0xFF;
                            uint ph2 = 0;
                            StaticClassReaderB.OpenComPort(port, ref FormSharedData.fComAdr, FormSharedData.fBaud, ref ph2);
                            FormSharedData.frmcomportindex = (int)ph2;
                            FormSharedData.fOpenComIndex = FormSharedData.frmcomportindex;
                            RefreshStatus();
                            btnReader_GetReaderInfo_Click(sender, e); //自动执行读取写卡器信息
                        }
                    }
                    else
                        MessageBox.Show("Serial Communication Error", "Information");
                }
            }
            finally
            {

            }
            if (cbReader_AlreadyOpenCOM.Items.Count != 0)
                cbReader_AlreadyOpenCOM.SelectedIndex = 0;
            else
            {
                FormSharedData.fOpenComIndex = -1;
                cbReader_AlreadyOpenCOM.Items.Clear();
                cbReader_AlreadyOpenCOM.Refresh();
                RefreshStatus();
                btnReader_GetReaderInfo.Enabled = false;
                btnReader_SetParameter.Enabled = false;
                btnReader_SetDefaultParameter.Enabled = false;
                FormSharedData.Form_6C.ListView1_EPC.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC1.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC2.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC3.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC4.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC5.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC6.Items.Clear();
                FormSharedData.Form_6C.Button_QueryTag.Text = "Stop";
                FormSharedData.Form_6B.lv6B_Tags.Items.Clear();
                FormSharedData.ComOpen = false;
            }
        }

        private void btnReader_GetReaderInfo_Click(object sender, EventArgs e)
        {
            ushort fwVersion = 0;
            ushort trType = 0;
            byte readerType = 0;
            byte inventScanTime = 0;
            byte rfPower = 0;
            byte beepEnable = 0;
            byte antennaConf = 0;
            Edit_Version.Text = "";
            Edit_ComAdr.Text = "";
            Edit_scantime.Text = "";
            Edit_Type.Text = "";
            ISO180006B.Checked = false;
            EPCC1G2.Checked = false;
            Edit_powerdBm.Text = "";
            Edit_dminfre.Text = "";
            Edit_dmaxfre.Text = "";
            FormSharedData.fCmdRet = (int)StaticClassReaderB.GetReaderInformation(
                ref FormSharedData.fComAdr, ref fwVersion, ref readerType, ref trType,
                ref inventScanTime, ref rfPower, ref beepEnable, ref antennaConf,
                FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
            {
                Edit_Version.Text = Convert.ToString(fwVersion & 0xFF, 10).PadLeft(2, '0') + "." + Convert.ToString(fwVersion >> 8, 10).PadLeft(2, '0');

                if (rfPower > 13)
                    ComboBox_PowerDbm.SelectedIndex = 13;
                else
                    ComboBox_PowerDbm.SelectedIndex = rfPower;
                Edit_ComAdr.Text = Convert.ToString(FormSharedData.fComAdr, 16).PadLeft(2, '0');
                Edit_NewComAdr.Text = Convert.ToString(FormSharedData.fComAdr, 16).PadLeft(2, '0');
                Edit_scantime.Text = Convert.ToString(inventScanTime, 10).PadLeft(2, '0') + "*100ms";
                ComboBox_scantime.SelectedIndex = inventScanTime - 3;
                Edit_powerdBm.Text = Convert.ToString(rfPower, 10).PadLeft(2, '0');
                // Note: frequency band bytes (dmaxfre/dminfre) are not returned by the
                // new pure-C# implementation; frequency display reflects the last written value.
                Edit_dminfre.Text = Convert.ToString(FormSharedData.fdminfre) + "MHz";
                Edit_dmaxfre.Text = Convert.ToString(FormSharedData.fdmaxfre) + "MHz";
                Edit_Type.Text = "UHFReader09";
                if ((trType & 0x02) == 0x02)
                {
                    ISO180006B.Checked = true;
                    EPCC1G2.Checked = true;
                }
                else
                {
                    ISO180006B.Checked = false;
                    EPCC1G2.Checked = false;
                }
            }
            FormSharedData.MainForm.AddCmdLog("GetReaderInformation", "GetReaderInformation", FormSharedData.fCmdRet);
        }

        private void btnReader_SetParameter_Click(object sender, EventArgs e)
        {
            byte aNewComAdr, powerDbm, dminfre, dmaxfre, scantime, band = 0;
            string returninfo = "";
            string returninfoDlg = "";
            string setinfo;
            if (rbReader_FreqBand_User.Checked)
                band = 0;
            if (rbReader_FreqBand_Chinese.Checked)
                band = 1;
            if (rbReader_FreqBand_US.Checked)
                band = 2;
            if (rbReader_FreqBand_Korean.Checked)
                band = 3;
            if (rbReader_FreqBand_Europe.Checked)
                band = 4;
            if (Edit_NewComAdr.Text == "")
                return;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            dminfre = Convert.ToByte(((band & 3) << 6) | (ComboBox_dminfre.SelectedIndex & 0x3F));
            dmaxfre = Convert.ToByte(((band & 0x0c) << 4) | (ComboBox_dmaxfre.SelectedIndex & 0x3F));
            aNewComAdr = Convert.ToByte(Edit_NewComAdr.Text);
            powerDbm = Convert.ToByte(ComboBox_PowerDbm.SelectedIndex);
            FormSharedData.fBaud = Convert.ToByte(cbReader_SetBaud.SelectedIndex);
            if (FormSharedData.fBaud > 2)
                FormSharedData.fBaud = Convert.ToByte(FormSharedData.fBaud + 2);
            scantime = Convert.ToByte(ComboBox_scantime.SelectedIndex + 3);
            setinfo = "Write";
            progressBar1.Value = 10;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.WriteComAdr(ref FormSharedData.fComAdr, ref aNewComAdr, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0x13)
                FormSharedData.fComAdr = aNewComAdr;
            if (FormSharedData.fCmdRet == 0)
            {
                FormSharedData.fComAdr = aNewComAdr;
                returninfo = returninfo + setinfo + "Address Successfully";
            }
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + setinfo + "Address Response Command Error";
            else
            {
                returninfo = returninfo + setinfo + "Address Fail";
                returninfoDlg = returninfoDlg + setinfo + "Address Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 25;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.SetPowerDbm(ref FormSharedData.fComAdr, powerDbm, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Power Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Power Response Command Error";
            else
            {
                returninfo = returninfo + ",Power Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Power Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 40;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.Writedfre(ref FormSharedData.fComAdr, ref dmaxfre, ref dminfre, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Frequency Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Frequency Response Command Error";
            else
            {
                returninfo = returninfo + ",Frequency Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Frequency Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 55;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.Writebaud(ref FormSharedData.fComAdr, ref FormSharedData.fBaud, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Baud Rate Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Baud Rate Response Command Error";
            else
            {
                returninfo = returninfo + ",Baud Rate Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Baud Rate Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 70;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.WriteScanTime(ref FormSharedData.fComAdr, ref scantime, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",InventoryScanTime Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",InventoryScanTime Response Command Error";
            else
            {
                returninfo = returninfo + ",InventoryScanTime Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "InventoryScanTime Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 100;
            btnReader_GetReaderInfo_Click(sender, e);
            progressBar1.Visible = false;
            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + returninfo;
            if (returninfoDlg != "")
                MessageBox.Show(returninfoDlg, "Information");

        }
        private void btnReader_SetDefaultParameter_Click(object sender, EventArgs e)
        {
            byte aNewComAdr, powerDbm, dminfre, dmaxfre, scantime;
            string returninfo = "";
            string returninfoDlg = "";
            string setinfo;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            dminfre = 0;
            dmaxfre = 62;
            aNewComAdr = 0x00;
            powerDbm = 13;
            FormSharedData.fBaud = 5;
            scantime = 10;
            setinfo = " Recovery ";
            cbReader_SetBaud.SelectedIndex = 3;
            progressBar1.Value = 10;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.WriteComAdr(ref FormSharedData.fComAdr, ref aNewComAdr, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0x13)
                FormSharedData.fComAdr = aNewComAdr;
            if (FormSharedData.fCmdRet == 0)
            {
                FormSharedData.fComAdr = aNewComAdr;
                returninfo = returninfo + setinfo + "Address Successfully";
            }
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + setinfo + "Address Response Command Error";
            else
            {
                returninfo = returninfo + setinfo + "Address Fail";
                returninfoDlg = returninfoDlg + setinfo + "Address Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 25;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.SetPowerDbm(ref FormSharedData.fComAdr, powerDbm, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Power Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Power Response Command Error";
            else
            {
                returninfo = returninfo + ",Power Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Power Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 40;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.Writedfre(ref FormSharedData.fComAdr, ref dmaxfre, ref dminfre, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Frequency Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Frequency Response Command Error";
            else
            {
                returninfo = returninfo + ",Frequency Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Frequency Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 55;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.Writebaud(ref FormSharedData.fComAdr, ref FormSharedData.fBaud, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",Baud Rate Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",Baud Rate Response Command Error";
            else
            {
                returninfo = returninfo + ",Baud Rate Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Baud Rate Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 70;
            FormSharedData.fCmdRet = (int)StaticClassReaderB.WriteScanTime(ref FormSharedData.fComAdr, ref scantime, FormSharedData.frmcomportindex);
            if (FormSharedData.fCmdRet == 0)
                returninfo = returninfo + ",InventoryScanTime Success";
            else if (FormSharedData.fCmdRet == 0xEE)
                returninfo = returninfo + ",InventoryScanTime Response Command Error";
            else
            {
                returninfo = returninfo + ",InventoryScanTime Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "InventoryScanTime Fail Command Response=0x"
                     + Convert.ToString(FormSharedData.fCmdRet) + "(" + FormSharedData.MainForm.GetReturnCodeDesc(FormSharedData.fCmdRet) + ")";
            }

            progressBar1.Value = 100;
            btnReader_GetReaderInfo_Click(sender, e);
            progressBar1.Visible = false;
            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + returninfo;
            if (returninfoDlg != "")
                MessageBox.Show(returninfoDlg, "Information");

        }
        private void radioButton_band1_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            for (i = 0; i < 63; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(902.6 + i * 0.4) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(902.6 + i * 0.4) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 62;
            ComboBox_dminfre.SelectedIndex = 0;
        }
        private void radioButton_band2_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            for (i = 0; i < 20; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(920.125 + i * 0.25) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(920.125 + i * 0.25) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 19;
            ComboBox_dminfre.SelectedIndex = 0;
        }
        private void radioButton_band3_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            for (i = 0; i < 50; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(902.75 + i * 0.5) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(902.75 + i * 0.5) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 49;
            ComboBox_dminfre.SelectedIndex = 0;
        }
        private void radioButton_band4_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            for (i = 0; i < 32; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(917.1 + i * 0.2) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(917.1 + i * 0.2) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 31;
            ComboBox_dminfre.SelectedIndex = 0;
        }
        private void radioButton_band5_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            for (i = 0; i < 15; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(865.1 + i * 0.2) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(865.1 + i * 0.2) + " MHz");
            }
            ComboBox_dmaxfre.SelectedIndex = 14;
            ComboBox_dminfre.SelectedIndex = 0;
        }
        private void CheckBox_SameFre_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_SameFre.Checked)
                ComboBox_dmaxfre.SelectedIndex = ComboBox_dminfre.SelectedIndex;
        }
        private void ComboBox_dfreSelect(object sender, EventArgs e)
        {
            if (CheckBox_SameFre.Checked)
            {
                ComboBox_dminfre.SelectedIndex = ComboBox_dmaxfre.SelectedIndex;
            }
            else if (ComboBox_dminfre.SelectedIndex > ComboBox_dmaxfre.SelectedIndex)
            {
                ComboBox_dminfre.SelectedIndex = ComboBox_dmaxfre.SelectedIndex;
                MessageBox.Show("Min.Frequency is equal or lesser than Max.Frequency", "Error Information");
            }
        }
    }
}
