using ReaderB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJYZN_105
{
    public partial class MainForm : Form
    {
        private void Inventory()
        {
            int i;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            fIsInventoryScan = true;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;

            if (CheckBox_TID.Checked)
            {
                AdrTID = Convert.ToByte(textBox4.Text, 16);
                LenTID = Convert.ToByte(textBox5.Text, 16);
                TIDFlag = 1;
            }

            ListViewItem aListItem = new ListViewItem();
            fCmdRet = StaticClassReaderB.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if ((fCmdRet == 1) | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表已查找结束，
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                fInventory_EPC_List = temps;            //存贮记录
                m = 0;

                if (CardNum == 0)
                {
                    fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    if (sEPC.Length != EPClen * 2)
                        return;
                    isonlistview = false;
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)     //判断是否在Listview列表内
                    {
                        if (sEPC == ListView1_EPC.Items[i].SubItems[1].Text)
                        {
                            aListItem = ListView1_EPC.Items[i];
                            ChangeSubItem(aListItem, 1, sEPC);
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                        aListItem = ListView1_EPC.Items.Add((ListView1_EPC.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        s = sEPC;
                        ChangeSubItem(aListItem, 1, s);
                        s = (sEPC.Length / 2).ToString().PadLeft(2, '0');
                        ChangeSubItem(aListItem, 2, s);
                        if (!CheckBox_TID.Checked)
                        {
                            if (ComboBox_EPC1.Items.IndexOf(sEPC) == -1)
                            {
                                ComboBox_EPC1.Items.Add(sEPC);
                                ComboBox_EPC2.Items.Add(sEPC);
                                ComboBox_EPC3.Items.Add(sEPC);
                                ComboBox_EPC4.Items.Add(sEPC);
                                ComboBox_EPC5.Items.Add(sEPC);
                                ComboBox_EPC6.Items.Add(sEPC);
                            }
                        }

                    }
                }
            }
            if (!CheckBox_TID.Checked)
            {
                if ((ComboBox_EPC1.Items.Count != 0))
                {
                    ComboBox_EPC1.SelectedIndex = 0;
                    ComboBox_EPC2.SelectedIndex = 0;
                    ComboBox_EPC3.SelectedIndex = 0;
                    ComboBox_EPC4.SelectedIndex = 0;
                    ComboBox_EPC5.SelectedIndex = 0;
                    ComboBox_EPC6.SelectedIndex = 0;
                }
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }
        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            Inventory();
        }

        private void Timer_G2_Read_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            fIsInventoryScan = true;
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte EPClength = 0;
            string str;
            byte[] CardData = new byte[320];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (txtDataLen.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.Items.Count == 0)
            {
                fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.SelectedItem == null)
            {
                fIsInventoryScan = false;
                return;
            }
            str = ComboBox_EPC2.SelectedItem.ToString();
            if (str == "")
            {
                // fIsInventoryScan = false;
                //  return;
            }
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (Edit_AccessCode2.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            if (txtDataAddr.Text == "")
            {
                fIsInventoryScan = false;
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                fIsInventoryScan = false;
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, EPC, Mem, WordPtr, Num, fPassWord, Maskadr, MaskLen, MaskFlag, CardData, EPClength, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                byte[] daw = new byte[Num * 2];
                Array.Copy(CardData, daw, Num * 2);
                listBox1.Items.Add(ByteArrayToHexString(daw));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                AddCmdLog("ReadData", "Read", fCmdRet);
            }
            if (ferrorcode != -1)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() +
                   " 'Read' Response ErrorCode=0x" + Convert.ToString(ferrorcode, 2) +
                   " (" + GetErrorCodeDesc(ferrorcode) + ")";
                ferrorcode = -1;
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }
        private void Timer_G2_Alarm_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            fIsInventoryScan = true;
            fCmdRet = StaticClassReaderB.CheckEASAlarm_G2(ref fComAdr, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check EAS Alarm'Command Response=0x00" +
                          "(EAS alarm detected)";
                Label_Alarm.Visible = true;                       //v2.1 add
            }
            else
            {
                Label_Alarm.Visible = false;                       //v2.1 add
                AddCmdLog("CheckEASAlarm_G2", "Check EAS Alarm", fCmdRet);
            }
            fIsInventoryScan = false;
            if (fAppClosed)
                Close();
        }
        private void btnQueryTag_Click(object sender, EventArgs e)
        {
            if (CheckBox_TID.Checked)
            {
                if ((textBox4.Text.Length) != 2 || ((textBox5.Text.Length) != 2))
                {
                    tss_Status.Text = "TID Parameter Incorrect！";
                    return;
                }
            }
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            if (!Timer_Test_.Enabled)
            {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                CheckBox_TID.Enabled = true;
                if (ListView1_EPC.Items.Count != 0)
                {
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
                if (ListView1_EPC.Items.Count == 0)
                {
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
                AddCmdLog("Inventory", "Exit Query", 0);
                Button_QueryTag.Text = "Query Tag";
            }
            else
            {
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                CheckBox_TID.Enabled = false;

                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = false;

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
            }
        }
        private void SpeedButton_Read_G2_Click(object sender, EventArgs e)
        {
            if (txtDataAddr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (txtDataLen.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Edit_AccessCode2.Text == "")
            {
                MessageBox.Show("(PassWord) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            Timer_G2_Read.Enabled = !Timer_G2_Read.Enabled;
            if (Timer_G2_Read.Enabled)
            {
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = false;

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
                Button_QueryTag.Enabled = false;
                Button_DataWrite.Enabled = false;
                Button_BlockWrite.Enabled = false;
                Button_BlockErase.Enabled = false;
                Button_SetProtectState.Enabled = false;
                SpeedButton_Read_G2.Text = "Stop";
            }
            else
            {
                if (ListView1_EPC.Items.Count != 0)
                {
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
                    Button_QueryTag.Enabled = true;
                    Button_SetProtectState.Enabled = true;

                    Button_DataWrite.Enabled = true;
                    Button_BlockWrite.Enabled = true;
                    Button_BlockErase.Enabled = true;
                }
                if (ListView1_EPC.Items.Count == 0)
                {
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
                    Button_SetProtectState.Enabled = false;
                    Button_QueryTag.Enabled = true;
                    Button_DataWrite.Enabled = false;
                    Button_BlockWrite.Enabled = false;
                    Button_BlockErase.Enabled = false;
                    Button_WriteEPC_G2.Enabled = true;
                    Button_SetMultiReadProtect_G2.Enabled = true;
                    Button_RemoveReadProtect_G2.Enabled = true;
                    Button_CheckReadProtected_G2.Enabled = true;
                    Button_CheckEASAlarm_G2.Enabled = true;

                }
                SpeedButton_Read_G2.Text = "Read";
            }
        }
        private void Button_DataWrite_Click(object sender, EventArgs e)
        {
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte WNum = 0;
            byte EPClength = 0;
            byte Writedatalen = 0;
            int WrittenDataNum = 0;
            string s2, str;
            byte[] CardData = new byte[320];
            byte[] writedata = new byte[230];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (txtDataAddr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (txtDataLen.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (Edit_AccessCode2.Text == "")
            {
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text, 16);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            if (Edit_WriteData.Text == "")
                return;
            s2 = Edit_WriteData.Text;
            if (s2.Length % 4 != 0)
            {
                MessageBox.Show("The Number must be in multiples of 4.", "Write");
                return;
            }
            WNum = Convert.ToByte(s2.Length / 4);
            byte[] Writedata = new byte[WNum * 2];
            Writedata = HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            if ((checkBox_pc.Checked) && (C_EPC.Checked))
            {
                WordPtr = 1;
                Writedatalen = Convert.ToByte(Edit_WriteData.Text.Length / 2 + 2);
                Writedata = HexStringToByteArray(textBox_pc.Text + Edit_WriteData.Text);
            }
            fCmdRet = StaticClassReaderB.WriteCard_G2(ref fComAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, fPassWord, Maskadr, MaskLen, MaskFlag, WrittenDataNum, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("Write data", "Write", fCmdRet, ferrorcode);
            if (fCmdRet == 0)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() + "'Write'Command Response=0x00" +
                     "(completely write Data successfully)";
            }
        }
        private void Button_BlockErase_Click(object sender, EventArgs e)
        {
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte EPClength = 0;
            string str;
            byte[] CardData = new byte[320];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (txtDataAddr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (txtDataLen.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (Edit_AccessCode2.Text == "")
                return;
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            if ((Mem == 1) & (WordPtr < 2))
            {
                MessageBox.Show("the length of start Address of erasing EPC area is equal or greater than 0x01!", "Information");
                return;
            }
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            fCmdRet = StaticClassReaderB.EraseCard_G2(ref fComAdr, EPC, Mem, WordPtr, Num, fPassWord, Maskadr, MaskLen, MaskFlag, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("EraseCard", "Erase data", fCmdRet);
            if (fCmdRet == 0)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Block Erase'Command Response=0x00" +
                     "(Block Erase successfully)";
            }
        }
        private void Button_ListClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void BlockWrite_Click(object sender, EventArgs e)
        {
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte WNum = 0;
            byte EPClength = 0;
            byte Writedatalen = 0;
            int WrittenDataNum = 0;
            string s2, str;
            byte[] CardData = new byte[320];
            byte[] writedata = new byte[230];
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (txtDataAddr.Text == "")
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (txtDataLen.Text == "")
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (Edit_AccessCode2.Text == "")
            {
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode2.Text);
            if (Edit_WriteData.Text == "")
                return;
            s2 = Edit_WriteData.Text;
            if (s2.Length % 4 != 0)
            {
                MessageBox.Show("The Number must be 4 times.", "Write");
                return;
            }
            WNum = Convert.ToByte(s2.Length / 4);
            byte[] Writedata = new byte[WNum * 2];
            Writedata = HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            if ((checkBox_pc.Checked) && (C_EPC.Checked))
            {
                WordPtr = 1;
                Writedatalen = Convert.ToByte(Edit_WriteData.Text.Length / 2 + 2);
                Writedata = HexStringToByteArray(textBox_pc.Text + Edit_WriteData.Text);
            }
            fCmdRet = StaticClassReaderB.WriteBlock_G2(ref fComAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, fPassWord, Maskadr, MaskLen, MaskFlag, WrittenDataNum, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("Write Block", "WriteBlock", fCmdRet, ferrorcode);
            if (fCmdRet == 0)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() + "'WriteBlock'Command Response=0x00" +
                     "(completely write Data successfully)";
            }
        }

        private void Button_SetProtectState_Click(object sender, EventArgs e)
        {
            byte select = 0;
            byte setprotect = 0;
            byte EPClength;
            string str;
            byte ENum;

            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }

            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;

            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);

            if (ComboBox_EPC1.Items.Count == 0)
                return;
            if (ComboBox_EPC1.SelectedItem == null)
                return;

            str = ComboBox_EPC1.SelectedItem.ToString() ?? "";
            if (str == "")
                return;

            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);

            if (textBox2.Text.Length != 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }

            fPassWord = HexStringToByteArray(textBox2.Text);
            if ((P_Reserve.Checked) & (DestroyCode.Checked))
                select = 0;
            else if ((P_Reserve.Checked) & (AccessCode.Checked))
                select = 0x01;
            else if (P_EPC.Checked)
                select = 0x02;
            else if (P_TID.Checked)
                select = 0x03;
            else if (P_User.Checked)
                select = 0x04;

            if (P_Reserve.Checked)
            {
                if (NoProect.Checked)
                    setprotect = 0x00;
                else if (Proect.Checked)
                    setprotect = 0x02;
                else if (Always.Checked)
                {
                    setprotect = 0x01;
                    if (MessageBox.Show(this, "Set readable and writeable Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                }
                else if (AlwaysNot.Checked)
                {
                    setprotect = 0x03;
                    if (MessageBox.Show(this, "Set never readable and writeable Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                }
            }
            else
            {
                if (NoProect2.Checked)
                    setprotect = 0x00;
                else if (Proect2.Checked)
                    setprotect = 0x02;
                else if (Always2.Checked)
                {
                    setprotect = 0x01;
                    if (MessageBox.Show(this, "Set writeable Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                }
                else if (AlwaysNot2.Checked)
                {
                    setprotect = 0x03;
                    if (MessageBox.Show(this, "Set never writeable Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                }
            }

            fCmdRet = StaticClassReaderB.SetCardProtect_G2(ref fComAdr, EPC, select, setprotect, fPassWord, Maskadr, MaskLen, MaskFlag, EPClength, ref ferrorcode, frmcomportindex); ;
            AddCmdLog("SetCardProtect", "SetProtect", fCmdRet, ferrorcode);
        }

        private void Button_DestroyCard_Click(object sender, EventArgs e)
        {
            byte EPClength;
            string str;
            byte ENum;
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            tss_Status.Text = DateTime.Now.ToLongTimeString() + "";
            if (MessageBox.Show(this, "Kill the Tag  Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            if (Edit_DestroyCode.Text.Length != 8)
            {
                MessageBox.Show("Kill Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            if (ComboBox_EPC3.Items.Count == 0)
                return;
            if (ComboBox_EPC3.SelectedItem == null)
                return;
            str = ComboBox_EPC3.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            fPassWord = HexStringToByteArray(Edit_DestroyCode.Text);
            fCmdRet = StaticClassReaderB.DestroyCard_G2(ref fComAdr, EPC, fPassWord, Maskadr, MaskLen, MaskFlag, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("DestroyCard", "Kill Tag", fCmdRet);
            if (fCmdRet == 0)
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Kill Tag'Command Response=0x00" +
                          "(Kill successfully)";
        }

        private void Button_WriteEPC_G2_Click(object sender, EventArgs e)
        {
            byte[] WriteEPC = new byte[100];
            byte WriteEPClen;
            byte ENum;
            if (Edit_AccessCode3.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            if ((Edit_WriteEPC.Text.Length % 4) != 0)
            {
                MessageBox.Show("Please input Data in words in hexadecimal form!", "Information");
                return;
            }
            WriteEPClen = Convert.ToByte(Edit_WriteEPC.Text.Length / 2);
            ENum = Convert.ToByte(Edit_WriteEPC.Text.Length / 4);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(Edit_WriteEPC.Text);
            fPassWord = HexStringToByteArray(Edit_AccessCode3.Text);
            fCmdRet = StaticClassReaderB.WriteEPC_G2(ref fComAdr, fPassWord, EPC, WriteEPClen, ref ferrorcode, frmcomportindex);
            AddCmdLog("WriteEPC_G2", "Write EPC", fCmdRet, ferrorcode);
            if (fCmdRet == 0)
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Write EPC'Command Response=0x00" +
                            "(Write EPC successfully)";
        }

        private void Button_SetReadProtect_G2_Click(object sender, EventArgs e)
        {
            byte EPClength;
            byte ENum;
            string str;
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (Edit_AccessCode4.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            if (ComboBox_EPC4.Items.Count == 0)
                return;
            if (ComboBox_EPC4.SelectedItem == null)
                return;
            str = ComboBox_EPC4.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            fPassWord = HexStringToByteArray(Edit_AccessCode4.Text);
            fCmdRet = StaticClassReaderB.SetReadProtect_G2(ref fComAdr, EPC, fPassWord, Maskadr, MaskLen, MaskFlag, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("SetReadProtect_G2", "Set Single Tag Read Protection", fCmdRet);
            if (fCmdRet == 0)
            {
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Set Single Tag Read Protection'Command Response=0x00" +
                        "Set Single Tag Read Protection successfully";
            }
        }
        private void Button_SetMultiReadProtect_G2_Click(object sender, EventArgs e)
        {
            if (Edit_AccessCode4.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode4.Text);
            fCmdRet = StaticClassReaderB.SetMultiReadProtect_G2(ref fComAdr, fPassWord, ref ferrorcode, frmcomportindex);
            AddCmdLog("SetMultiReadProtect_G2", "Set Single Tag Read Protection without EPC", fCmdRet);
            if (fCmdRet == 0)
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Set Single Tag Read Protection without EPC'Command Response=0x00" +
                        "(Set Single Tag Read Protection without EPC successfully)";
        }

        private void Button_RemoveReadProtect_G2_Click(object sender, EventArgs e)
        {
            if (Edit_AccessCode4.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            fPassWord = HexStringToByteArray(Edit_AccessCode4.Text);
            fCmdRet = StaticClassReaderB.RemoveReadProtect_G2(ref fComAdr, fPassWord, ref ferrorcode, frmcomportindex);
            AddCmdLog("RemoveReadProtect_G2", "Reset Single Tag Read Protection", fCmdRet);
            if (fCmdRet == 0)
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Reset Single Tag Read Protection'Command Response=0x00" +
                          "(Reset Single Tag Read Protection successfully)";
        }

        private void Button_CheckReadProtected_G2_Click(object sender, EventArgs e)
        {
            byte readpro = 2;
            fCmdRet = StaticClassReaderB.CheckReadProtected_G2(ref fComAdr, ref readpro, ref ferrorcode, frmcomportindex);
            AddCmdLog("CheckReadProtected_G2", "Detect Single Tag Read Protection", fCmdRet);
            if (fCmdRet == 0)
            {
                if (readpro == 0)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Detect Single Tag Read Protection'Command Response=0x00" +
                        "(Single Tag is unprotected)";
                if (readpro == 1)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Detect Single Tag Read Protection'Command Response=0x01" +
                        "(Single Tag is protected)";
            }
        }

        private void Button_SetEASAlarm_G2_Click(object sender, EventArgs e)
        {
            byte EPClength = 0;
            byte EAS = 0;
            byte ENum;
            string str;
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (Edit_AccessCode5.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            if (ComboBox_EPC5.Items.Count == 0)
                return;
            if (ComboBox_EPC5.SelectedItem == null)
                return;
            str = ComboBox_EPC5.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            fPassWord = HexStringToByteArray(Edit_AccessCode5.Text);
            if (Alarm_G2.Checked)
                EAS = 1;
            else
                EAS = 0;

            fCmdRet = StaticClassReaderB.SetEASAlarm_G2(ref fComAdr, EPC, fPassWord, Maskadr, MaskLen, MaskFlag, EAS, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("SetEASAlarm_G2", "Alarm Setting", fCmdRet);     //v2.1 change
            if (fCmdRet == 0)
            {
                if (Alarm_G2.Checked)                                //v2.1 add
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Alarm Setting'Command Response=0x00" +
                                "(Set EAS Alarm successfully)";
                else
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Alarm Setting'Command Response=0x00" +
                                "(Clear EAS Alarm successfully)";
            }

        }
        private void Button_CheckEASAlarm_G2_Click(object sender, EventArgs e)
        {
            Timer_G2_Alarm.Enabled = !Timer_G2_Alarm.Enabled;
            if (Timer_G2_Alarm.Enabled)
            {
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = false;

                P_Reserve.Enabled = false;
                P_EPC.Enabled = false;
                P_TID.Enabled = false;
                P_User.Enabled = false;
                Button_WriteEPC_G2.Enabled = false;
                Button_SetMultiReadProtect_G2.Enabled = false;
                Button_RemoveReadProtect_G2.Enabled = false;
                Button_CheckReadProtected_G2.Enabled = false;
                Button_QueryTag.Enabled = false;

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
                Button_CheckEASAlarm_G2.Text = "Stop";
            }
            else
            {
                if (ListView1_EPC.Items.Count != 0)
                {
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
                    Button_QueryTag.Enabled = true;
                    Button_SetProtectState.Enabled = true;
                    SpeedButton_Read_G2.Enabled = true;
                    Button_DataWrite.Enabled = true;
                    Button_BlockWrite.Enabled = true;
                    Button_BlockErase.Enabled = true;
                }
                if (ListView1_EPC.Items.Count == 0)
                {
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
                    Button_SetProtectState.Enabled = false;
                    Button_WriteEPC_G2.Enabled = true;
                    Button_SetMultiReadProtect_G2.Enabled = true;
                    Button_RemoveReadProtect_G2.Enabled = true;
                    Button_CheckReadProtected_G2.Enabled = true;
                    Button_QueryTag.Enabled = true;

                }
                Button_CheckEASAlarm_G2.Text = "Check Alarm";
                Label_Alarm.Visible = false;                       //v2.1 add
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check EAS Alarm'over";
            }
        }
        private void Button_LockUserBlock_G2_Click(object sender, EventArgs e)
        {
            byte EPClength = 0;
            byte BlockNum = 0;
            byte ENum;
            string str;
            if ((maskadr_textbox.Text == "") || (maskLen_textBox.Text == ""))
            {
                fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                MaskFlag = 1;
            else
                MaskFlag = 0;
            Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (Edit_AccessCode6.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            if (ComboBox_EPC6.Items.Count == 0)
                return;
            if (ComboBox_EPC6.SelectedItem == null)
                return;
            str = ComboBox_EPC6.SelectedItem.ToString() ?? "";
            if (str == "")
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = new byte[ENum];
            EPC = HexStringToByteArray(str);
            fPassWord = HexStringToByteArray(Edit_AccessCode6.Text);
            BlockNum = Convert.ToByte(ComboBox_BlockNum.SelectedIndex * 2);
            fCmdRet = StaticClassReaderB.LockUserBlock_G2(ref fComAdr, EPC, fPassWord, Maskadr, MaskLen, MaskFlag, BlockNum, EPClength, ref ferrorcode, frmcomportindex);
            AddCmdLog("LockUserBlock_G2", "Lock User Block", fCmdRet);
            if (fCmdRet == 0)
                tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Lock User Block'Command Response=0x00" +
                        "(Lock successfully)";
        }
        private void ComboBox_IntervalTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_IntervalTime.SelectedIndex < 6)
                Timer_Test_.Interval = 100;
            else
                Timer_Test_.Interval = (ComboBox_IntervalTime.SelectedIndex + 4) * 10;
        }

        public void ChangeSubItem1(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 1].Text = "1";
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 1].Text = Convert.ToString(Convert.ToUInt32(ListItem.SubItems[subItemIndex + 1].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 1].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 1].Text = "1";
                }

            }
        }
        private void P_Reserve_CheckedChanged(object sender, EventArgs e)
        {
            if (ListView1_EPC.Items.Count != 0)
            {
                gbLockPassword.Enabled = true;
                gbLockTIDnUSER.Enabled = false;
            }
        }
        private void P_EPC_CheckedChanged(object sender, EventArgs e)
        {
            if (ListView1_EPC.Items.Count != 0)
            {
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = true;
            }
        }
        private void P_TID_CheckedChanged(object sender, EventArgs e)
        {
            if (ListView1_EPC.Items.Count != 0)
            {
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = true;
            }
        }
        private void P_User_CheckedChanged(object sender, EventArgs e)
        {
            if (ListView1_EPC.Items.Count != 0)
            {
                gbLockPassword.Enabled = false;
                gbLockTIDnUSER.Enabled = true;
            }
        }
        private void EPCMask_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                maskadr_textbox.Enabled = true;
                maskLen_textBox.Enabled = true;
            }
            else
            {
                maskadr_textbox.Enabled = false;
                maskLen_textBox.Enabled = false;
            }
        }
        private void ListView1_EPC_DoubleClick(object sender, EventArgs e)
        {
            if (ListView1_EPC.SelectedItems.Count == 1)
            {
                string EPCValue = ListView1_EPC.SelectedItems[0].SubItems[1].Text;
                if (EPCValue != null && EPCValue != "")
                {
                    Clipboard.SetText(EPCValue);
                }
            }
        }

        private void C_EPC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pc.Checked)
            {
                txtDataAddr.Text = "02";
                txtDataAddr.ReadOnly = true;
            }
            else
            {
                txtDataAddr.ReadOnly = false;
            }
            if ((!Timer_Test_.Enabled) & (!Timer_G2_Alarm.Enabled) & (!Timer_G2_Read.Enabled))
            {
                //    Button_DataWrite.Enabled = false;
            }
        }

        private void C_TID_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) & (!Timer_G2_Alarm.Enabled) & (!Timer_G2_Read.Enabled))
            {
                if (ListView1_EPC.Items.Count != 0)
                    Button_DataWrite.Enabled = true;
            }
            txtDataAddr.ReadOnly = false;
        }

        private void C_User_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) & (!Timer_G2_Alarm.Enabled) & (!Timer_G2_Read.Enabled))
            {
                if (ListView1_EPC.Items.Count != 0)
                    Button_DataWrite.Enabled = true;
            }
            txtDataAddr.ReadOnly = false;
        }

        private void C_Reserve_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) & (!Timer_G2_Alarm.Enabled) & (!Timer_G2_Read.Enabled))
            {
                if (ListView1_EPC.Items.Count != 0)
                    Button_DataWrite.Enabled = true;
            }
            txtDataAddr.ReadOnly = false;
        }
        private void checkBox_pc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_pc.Checked)
            {
                if (C_EPC.Checked)
                {
                    txtDataAddr.Text = "02";
                    txtDataAddr.ReadOnly = true;
                }
                int m, n;
                n = Edit_WriteData.Text.Length;
                if ((checkBox_pc.Checked) && (n % 4 == 0) && (C_EPC.Checked))
                {
                    m = n / 4;
                    m = (m & 0x3F) << 3;
                    textBox_pc.Text = Convert.ToString(m, 16).PadLeft(2, '0') + "00";
                }
            }
            else
            {
                txtDataAddr.ReadOnly = false;
            }
        }

        private void Edit_WriteData_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
            int m, n;
            n = Edit_WriteData.Text.Length;
            if ((checkBox_pc.Checked) && (n % 4 == 0) && (C_EPC.Checked))
            {
                m = n / 4;
                m = (m & 0x3F) << 3;
                textBox_pc.Text = Convert.ToString(m, 16).PadLeft(2, '0') + "00";
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var item = listBox1.Items[index];
                if (item != null)
                    Clipboard.SetText(item.ToString() ?? "");
            }
        }
        private void CheckBox_TID_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_TID.Checked)
                gbQueryTIDParams.Enabled = true;
            else
                gbQueryTIDParams.Enabled = false;
        }
        public void ChangeSubItem(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ItemText == "")
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (ListItem.SubItems[subItemIndex + 2].Text == "")
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    }
                    else
                    {
                        ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    }
                }
                else
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                }

            }
            if (subItemIndex == 2)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }
        }

        private void cb6C_IKnowTagLock_CheckedChanged(object sender, EventArgs e)
        {
            gbTagLock.Enabled = !gbTagLock.Enabled;
        }

    }
}
