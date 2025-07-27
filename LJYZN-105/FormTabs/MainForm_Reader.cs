using ReaderB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace LJYZN_105
{
    public partial class MainForm : Form
    {
        private void btnReader_OpenPort_Click(object sender, EventArgs e)
        {
            int port = 0;
            int openresult, i;
            openresult = 30;
            string temp;
            Cursor = Cursors.WaitCursor;
            if (txtReader_CmdComAddr.Text == "")
                txtReader_CmdComAddr.Text = "FF";
            fComAdr = Convert.ToByte(txtReader_CmdComAddr.Text, 16); // $FF;
            try
            {
                if (cbReader_COM.SelectedIndex == 0)//Auto
                {
                    fBaud = Convert.ToByte(cbReader_ComBaud.SelectedIndex);
                    if (fBaud > 2)
                    {
                        fBaud = Convert.ToByte(fBaud + 2);
                    }
                    openresult = StaticClassReaderB.AutoOpenComPort(ref port, ref fComAdr, fBaud, ref frmcomportindex);
                    fOpenComIndex = frmcomportindex;
                    if (openresult == 0)
                    {
                        ComOpen = true;
                        // Button3_Click(sender, e); //自动执行读取写卡器信息
                        if (fBaud > 3)
                        {
                            cbReader_SetBaud.SelectedIndex = Convert.ToInt32(fBaud - 2);
                        }
                        else
                        {
                            cbReader_SetBaud.SelectedIndex = Convert.ToInt32(fBaud);
                        }
                        btnReader_GetReaderInfo_Click(sender, e); //自动执行读取写卡器信息
                        if ((fCmdRet == 0x35) | (fCmdRet == 0x30))
                        {
                            MessageBox.Show("Serial Communication Error or Occupied", "Information");
                            StaticClassReaderB.CloseSpecComPort(frmcomportindex);
                            ComOpen = false;
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
                        fBaud = Convert.ToByte(i);
                        if (fBaud == 3)
                            continue;
                        openresult = StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                        fOpenComIndex = frmcomportindex;
                        if (openresult == 0x35)
                        {
                            MessageBox.Show("COM Opened", "Information");
                            return;
                        }
                        if (openresult == 0)
                        {
                            ComOpen = true;
                            btnReader_GetReaderInfo_Click(sender, e); //自动执行读取写卡器信息
                            if (fBaud > 3)
                            {
                                cbReader_SetBaud.SelectedIndex = Convert.ToInt32(fBaud - 2);
                            }
                            else
                            {
                                cbReader_SetBaud.SelectedIndex = Convert.ToInt32(fBaud);
                            }
                            if ((fCmdRet == 0x35) || (fCmdRet == 0x30))
                            {
                                ComOpen = false;
                                MessageBox.Show("Serial Communication Error or Occupied", "Information");
                                StaticClassReaderB.CloseSpecComPort(frmcomportindex);
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

            if ((fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30))
            {
                cbReader_AlreadyOpenCOM.Items.Add("COM" + Convert.ToString(fOpenComIndex));
                cbReader_AlreadyOpenCOM.SelectedIndex = cbReader_AlreadyOpenCOM.SelectedIndex + 1;
                btnReader_GetReaderInfo.Enabled = true;
                btnReader_SetParameter.Enabled = true;
                btnReader_SetDefaultParameter.Enabled = true;
                Button_QueryTag.Enabled = true;
                Button_WriteEPC_G2.Enabled = true;
                Button_SetMultiReadProtect_G2.Enabled = true;
                Button_RemoveReadProtect_G2.Enabled = true;
                Button_CheckReadProtected_G2.Enabled = true;
                Button_CheckEASAlarm_G2.Enabled = true;
                SpeedButton_Query_6B.Enabled = true;

                ComOpen = true;
            }
            if ((fOpenComIndex == -1) && (openresult == 0x30))
                MessageBox.Show("Serial Communication Error", "Information");

            if ((cbReader_AlreadyOpenCOM.Items.Count != 0) & (fOpenComIndex != -1) & (openresult != 0X35) & (openresult != 0X30) & (fCmdRet == 0))
            {
                fComAdr = Convert.ToByte(Edit_ComAdr.Text, 16);
                temp = cbReader_AlreadyOpenCOM.SelectedItem.ToString();
                frmcomportindex = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
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
                    fCmdRet = StaticClassReaderB.CloseSpecComPort(port);
                    if (fCmdRet == 0)
                    {
                        cbReader_AlreadyOpenCOM.Items.RemoveAt(0);
                        if (cbReader_AlreadyOpenCOM.Items.Count != 0)
                        {
                            temp = cbReader_AlreadyOpenCOM.SelectedItem.ToString();
                            port = Convert.ToInt32(temp.Substring(3, temp.Length - 3));
                            StaticClassReaderB.CloseSpecComPort(port);
                            fComAdr = 0xFF;
                            StaticClassReaderB.OpenComPort(port, ref fComAdr, fBaud, ref frmcomportindex);
                            fOpenComIndex = frmcomportindex;
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
                fOpenComIndex = -1;
                cbReader_AlreadyOpenCOM.Items.Clear();
                cbReader_AlreadyOpenCOM.Refresh();
                RefreshStatus();
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

                DestroyCode.Enabled = false;
                AccessCode.Enabled = false;
                NoProect.Enabled = false;
                Proect.Enabled = false;
                Always.Enabled = false;
                AlwaysNot.Enabled = false;
                NoProect2.Enabled = false;
                Proect2.Enabled = false;
                Always2.Enabled = false;
                AlwaysNot2.Enabled = false;

                P_Reserve.Enabled = false;
                P_EPC.Enabled = false;
                P_TID.Enabled = false;
                P_User.Enabled = false;
                Alarm_G2.Enabled = false;
                NoAlarm_G2.Enabled = false;

                Same_6B.Enabled = false;
                Different_6B.Enabled = false;
                Less_6B.Enabled = false;
                Greater_6B.Enabled = false;


                DestroyCode.Enabled = false;
                AccessCode.Enabled = false;
                NoProect.Enabled = false;
                Proect.Enabled = false;
                Always.Enabled = false;
                AlwaysNot.Enabled = false;
                NoProect2.Enabled = false;
                Proect2.Enabled = false;
                Always2.Enabled = false;
                AlwaysNot2.Enabled = false;
                P_Reserve.Enabled = false;
                P_EPC.Enabled = false;
                P_TID.Enabled = false;
                P_User.Enabled = false;
                Button_WriteEPC_G2.Enabled = false;
                Button_SetMultiReadProtect_G2.Enabled = false;
                Button_RemoveReadProtect_G2.Enabled = false;
                Button_CheckReadProtected_G2.Enabled = false;
                Button_CheckEASAlarm_G2.Enabled = false;

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
                Button_SetProtectState.Enabled = false;
                ListView1_EPC.Items.Clear();
                ComboBox_EPC1.Items.Clear();
                ComboBox_EPC2.Items.Clear();
                ComboBox_EPC3.Items.Clear();
                ComboBox_EPC4.Items.Clear();
                ComboBox_EPC5.Items.Clear();
                ComboBox_EPC6.Items.Clear();
                Button_QueryTag.Text = "Stop";
                checkBox1.Enabled = false;

                SpeedButton_Read_6B.Enabled = false;
                SpeedButton_Write_6B.Enabled = false;
                SpeedButton_Perm_Wr_Prot_6B.Enabled = false;
                SpeedButton_Check_6B.Enabled = false;
                lv6B_Tags.Items.Clear();
                ComOpen = false;
            }
        }

        private void btnReader_GetReaderInfo_Click(object sender, EventArgs e)
        {
            byte[] TrType = new byte[2];
            byte[] VersionInfo = new byte[2];
            byte ReaderType = 0;
            byte ScanTime = 0;
            byte dmaxfre = 0;
            byte dminfre = 0;
            byte powerdBm = 0;
            byte FreBand = 0;
            Edit_Version.Text = "";
            Edit_ComAdr.Text = "";
            Edit_scantime.Text = "";
            Edit_Type.Text = "";
            ISO180006B.Checked = false;
            EPCC1G2.Checked = false;
            Edit_powerdBm.Text = "";
            Edit_dminfre.Text = "";
            Edit_dmaxfre.Text = "";
            fCmdRet = StaticClassReaderB.GetReaderInformation(ref fComAdr, VersionInfo, ref ReaderType, TrType, ref dmaxfre, ref dminfre, ref powerdBm, ref ScanTime, frmcomportindex);
            if (fCmdRet == 0)
            {
                Edit_Version.Text = Convert.ToString(VersionInfo[0], 10).PadLeft(2, '0') + "." + Convert.ToString(VersionInfo[1], 10).PadLeft(2, '0');

                if (powerdBm > 13)
                    ComboBox_PowerDbm.SelectedIndex = 13;
                else
                    ComboBox_PowerDbm.SelectedIndex = powerdBm;
                Edit_ComAdr.Text = Convert.ToString(fComAdr, 16).PadLeft(2, '0');
                Edit_NewComAdr.Text = Convert.ToString(fComAdr, 16).PadLeft(2, '0');
                Edit_scantime.Text = Convert.ToString(ScanTime, 10).PadLeft(2, '0') + "*100ms";
                ComboBox_scantime.SelectedIndex = ScanTime - 3;
                Edit_powerdBm.Text = Convert.ToString(powerdBm, 10).PadLeft(2, '0');

                FreBand = Convert.ToByte(((dmaxfre & 0xc0) >> 4) | (dminfre >> 6));
                switch (FreBand)
                {
                    case 0:
                        {
                            rbReader_FreqBand_User.Checked = true;
                            fdminfre = 902.6 + (dminfre & 0x3F) * 0.4;
                            fdmaxfre = 902.6 + (dmaxfre & 0x3F) * 0.4;
                        }
                        break;
                    case 1:
                        {
                            rbReader_FreqBand_Chinese.Checked = true;
                            fdminfre = 920.125 + (dminfre & 0x3F) * 0.25;
                            fdmaxfre = 920.125 + (dmaxfre & 0x3F) * 0.25;
                        }
                        break;
                    case 2:
                        {
                            rbReader_FreqBand_US.Checked = true;
                            fdminfre = 902.75 + (dminfre & 0x3F) * 0.5;
                            fdmaxfre = 902.75 + (dmaxfre & 0x3F) * 0.5;
                        }
                        break;
                    case 3:
                        {
                            rbReader_FreqBand_Korean.Checked = true;
                            fdminfre = 917.1 + (dminfre & 0x3F) * 0.2;
                            fdmaxfre = 917.1 + (dmaxfre & 0x3F) * 0.2;
                        }
                        break;
                    case 4:
                        {
                            rbReader_FreqBand_Europe.Checked = true;
                            fdminfre = 865.1 + (dminfre & 0x3F) * 0.2;
                            fdmaxfre = 865.1 + (dmaxfre & 0x3F) * 0.2;
                        }
                        break;
                }
                Edit_dminfre.Text = Convert.ToString(fdminfre) + "MHz";
                Edit_dmaxfre.Text = Convert.ToString(fdmaxfre) + "MHz";
                if (fdmaxfre != fdminfre)
                    CheckBox_SameFre.Checked = false;
                ComboBox_dminfre.SelectedIndex = dminfre & 0x3F;
                ComboBox_dmaxfre.SelectedIndex = dmaxfre & 0x3F;
                //   if (ReaderType == 0x08)
                Edit_Type.Text = "UHFReader09";
                if ((TrType[0] & 0x02) == 0x02) //第二个字节低第四位代表支持的协议“ISO/IEC 15693”
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
            AddCmdLog("GetReaderInformation", "GetReaderInformation", fCmdRet);
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
            fBaud = Convert.ToByte(cbReader_SetBaud.SelectedIndex);
            if (fBaud > 2)
                fBaud = Convert.ToByte(fBaud + 2);
            scantime = Convert.ToByte(ComboBox_scantime.SelectedIndex + 3);
            setinfo = "Write";
            progressBar1.Value = 10;
            fCmdRet = StaticClassReaderB.WriteComAdr(ref fComAdr, ref aNewComAdr, frmcomportindex);
            if (fCmdRet == 0x13)
                fComAdr = aNewComAdr;
            if (fCmdRet == 0)
            {
                fComAdr = aNewComAdr;
                returninfo = returninfo + setinfo + "Address Successfully";
            }
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + setinfo + "Address Response Command Error";
            else
            {
                returninfo = returninfo + setinfo + "Address Fail";
                returninfoDlg = returninfoDlg + setinfo + "Address Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 25;
            fCmdRet = StaticClassReaderB.SetPowerDbm(ref fComAdr, powerDbm, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Power Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Power Response Command Error";
            else
            {
                returninfo = returninfo + ",Power Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Power Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 40;
            fCmdRet = StaticClassReaderB.Writedfre(ref fComAdr, ref dmaxfre, ref dminfre, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Frequency Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Frequency Response Command Error";
            else
            {
                returninfo = returninfo + ",Frequency Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Frequency Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 55;
            fCmdRet = StaticClassReaderB.Writebaud(ref fComAdr, ref fBaud, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Baud Rate Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Baud Rate Response Command Error";
            else
            {
                returninfo = returninfo + ",Baud Rate Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Baud Rate Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 70;
            fCmdRet = StaticClassReaderB.WriteScanTime(ref fComAdr, ref scantime, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",InventoryScanTime Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",InventoryScanTime Response Command Error";
            else
            {
                returninfo = returninfo + ",InventoryScanTime Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "InventoryScanTime Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 100;
            btnReader_GetReaderInfo_Click(sender, e);
            progressBar1.Visible = false;
            tss_Status.Text = DateTime.Now.ToLongTimeString() + returninfo;
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
            fBaud = 5;
            scantime = 10;
            setinfo = " Recovery ";
            cbReader_SetBaud.SelectedIndex = 3;
            progressBar1.Value = 10;
            fCmdRet = StaticClassReaderB.WriteComAdr(ref fComAdr, ref aNewComAdr, frmcomportindex);
            if (fCmdRet == 0x13)
                fComAdr = aNewComAdr;
            if (fCmdRet == 0)
            {
                fComAdr = aNewComAdr;
                returninfo = returninfo + setinfo + "Address Successfully";
            }
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + setinfo + "Address Response Command Error";
            else
            {
                returninfo = returninfo + setinfo + "Address Fail";
                returninfoDlg = returninfoDlg + setinfo + "Address Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 25;
            fCmdRet = StaticClassReaderB.SetPowerDbm(ref fComAdr, powerDbm, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Power Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Power Response Command Error";
            else
            {
                returninfo = returninfo + ",Power Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Power Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 40;
            fCmdRet = StaticClassReaderB.Writedfre(ref fComAdr, ref dmaxfre, ref dminfre, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Frequency Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Frequency Response Command Error";
            else
            {
                returninfo = returninfo + ",Frequency Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Frequency Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 55;
            fCmdRet = StaticClassReaderB.Writebaud(ref fComAdr, ref fBaud, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",Baud Rate Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",Baud Rate Response Command Error";
            else
            {
                returninfo = returninfo + ",Baud Rate Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "Baud Rate Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 70;
            fCmdRet = StaticClassReaderB.WriteScanTime(ref fComAdr, ref scantime, frmcomportindex);
            if (fCmdRet == 0)
                returninfo = returninfo + ",InventoryScanTime Success";
            else if (fCmdRet == 0xEE)
                returninfo = returninfo + ",InventoryScanTime Response Command Error";
            else
            {
                returninfo = returninfo + ",InventoryScanTime Fail";
                returninfoDlg = returninfoDlg + " " + setinfo + "InventoryScanTime Fail Command Response=0x"
                     + Convert.ToString(fCmdRet) + "(" + GetReturnCodeDesc(fCmdRet) + ")";
            }

            progressBar1.Value = 100;
            btnReader_GetReaderInfo_Click(sender, e);
            progressBar1.Visible = false;
            tss_Status.Text = DateTime.Now.ToLongTimeString() + returninfo;
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
