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
using System.Xml.Serialization;
using Utilities;

namespace LJYZN_105
{
    public partial class Form_EPCC1G26C : UserControl
    {
        public Form_EPCC1G26C()
        {
            InitializeComponent();

            int i = 40;
            while (i <= 300)
            {
                ComboBox_IntervalTime.Items.Add(Convert.ToString(i) + "ms");
                i = i + 10;
            }
            ComboBox_IntervalTime.SelectedIndex = 1;

            for (i = 0; i < 7; i++)
                ComboBox_BlockNum.Items.Add(Convert.ToString(i * 2) + " and " + Convert.ToString(i * 2 + 1));
            ComboBox_BlockNum.SelectedIndex = 0;
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

        private void Inventory()
        {
            int i;
            uint cardNumUInt = 0;
            int CardNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[5000];
            int CardIndex;
            string temps;
            string s, sEPC;
            bool isonlistview;
            FormSharedData.fIsInventoryScan = true;
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
            FormSharedData.cmdRet = (int)StaticClassReaderB.Inventory_G2(
                            ref FormSharedData.comAdr, AdrTID, LenTID, TIDFlag,
                            EPC, ref Totallen, ref cardNumUInt, FormSharedData.frmcomportindex
                            );
            CardNum = (int)cardNumUInt;

            if ((FormSharedData.cmdRet == 1) || (FormSharedData.cmdRet == 2) || (FormSharedData.cmdRet == 3) ||
                (FormSharedData.cmdRet == 4) || (FormSharedData.cmdRet == 0xFB))// Inventory scan complete
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = Utilities.Utilities.ByteArrayToHexString(daw);
                FormSharedData.fInventory_EPC_List = temps;            // Store inventory record
                m = 0;

                if (CardNum == 0)
                {
                    FormSharedData.fIsInventoryScan = false;
                    return;
                }
                for (CardIndex = 0; CardIndex < CardNum; CardIndex++)
                {
                    EPClen = daw[m];
                    if (m * 2 + 2 + EPClen * 2 > temps.Length)
                        return;
                    sEPC = temps.Substring(m * 2 + 2, EPClen * 2);
                    m = m + EPClen + 1;
                    isonlistview = false;
                    for (i = 0; i < ListView1_EPC.Items.Count; i++)     // Check whether the tag is already in the ListView list
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
            FormSharedData.fIsInventoryScan = false;
        }
        private void Timer_Test__Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fIsInventoryScan)
                return;
            Inventory();
        }

        private void Timer_G2_Read_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fIsInventoryScan)
                return;
            FormSharedData.fIsInventoryScan = true;
            byte WordPtr, ENum;
            byte Num = 0;
            byte Mem = 0;
            byte EPClength = 0;
            string str;
            byte[] CardData = new byte[320];
            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (string.IsNullOrEmpty(txtDataLen.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.Items.Count == 0)
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (ComboBox_EPC2.SelectedItem == null)
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            str = ComboBox_EPC2.SelectedItem.ToString();
            if (string.IsNullOrEmpty(str))
            {
                 //FormSharedData.fIsInventoryScan = false;
                 //return;
            }
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (string.IsNullOrEmpty(Edit_AccessCode2.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (string.IsNullOrEmpty(txtDataAddr.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode2.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(
                    ref FormSharedData.comAdr, EPC, Mem, WordPtr, Num, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    CardData, EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }

            if (FormSharedData.cmdRet == 0)
            {
                byte[] daw = new byte[Num * 2];
                Array.Copy(CardData, daw, Num * 2);
                listBox1.Items.Add(Utilities.Utilities.ByteArrayToHexString(daw));
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                FormSharedData.MainForm.AddCmdLog("ReadData", "Read", FormSharedData.cmdRet);
            }
            if (FormSharedData.ferrorcode != -1)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() +
                   " 'Read' Response ErrorCode=0x" + Convert.ToString(FormSharedData.ferrorcode, 2) +
                   " (" + FormSharedData.MainForm.GetErrorCodeDesc(FormSharedData.ferrorcode) + ")";
                FormSharedData.ferrorcode = -1;
            }
            FormSharedData.fIsInventoryScan = false;
        }
        private void Timer_G2_Alarm_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fIsInventoryScan)
                return;
            FormSharedData.fIsInventoryScan = true;
            {
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.CheckEASAlarm_G2(
                    ref FormSharedData.comAdr, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet == 0)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check EAS Alarm'Command Response=0x00" +
                          "(EAS alarm detected)";
                Label_Alarm.Visible = true;                       //v2.1 add
            }
            else
            {
                Label_Alarm.Visible = false;                       //v2.1 add
                FormSharedData.MainForm.AddCmdLog("CheckEASAlarm_G2", "Check EAS Alarm", FormSharedData.cmdRet);
            }
            FormSharedData.fIsInventoryScan = false;
        }
        private void btnQueryTag_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForInventory6C()) return;

            if (CheckBox_TID.Checked)
            {
                if ((textBox4.Text.Length) != 2 || ((textBox5.Text.Length) != 2))
                {
                    FormSharedData.tss_Status.Text = "TID Parameter Incorrect！";
                    return;
                }
            }
            Timer_Test_.Enabled = !Timer_Test_.Enabled;
            if (!Timer_Test_.Enabled)
            {
                FormSharedData.bIsInventoryRunning_6C = false;
                FormSharedData.MainForm.AddCmdLog("Inventory", "Exit Query", 0);
                Button_QueryTag.Text = "Query Tag";
            }
            else
            {
                ListView1_EPC.Items.Clear();
                ComboBox_EPC1.Items.Clear();
                ComboBox_EPC2.Items.Clear();
                ComboBox_EPC3.Items.Clear();
                ComboBox_EPC4.Items.Clear();
                ComboBox_EPC5.Items.Clear();
                ComboBox_EPC6.Items.Clear();
                FormSharedData.bIsInventoryRunning_6C = true;
                Button_QueryTag.Text = "Stop";
            }
        }
        private void SpeedButton_Read_G2_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForRead()) return;

            if (string.IsNullOrEmpty(txtDataAddr.Text))
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (string.IsNullOrEmpty(txtDataLen.Text))
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (string.IsNullOrEmpty(Edit_AccessCode2.Text))
            {
                MessageBox.Show("(PassWord) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            Timer_G2_Read.Enabled = !Timer_G2_Read.Enabled;
            if (Timer_G2_Read.Enabled)
            {
                FormSharedData.bIsReadInventoryRunning = true;
                SpeedButton_Read_G2.Text = "Stop";
            }
            else
            {
                FormSharedData.bIsReadInventoryRunning = false;
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

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (string.IsNullOrEmpty(txtDataAddr.Text))
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (string.IsNullOrEmpty(txtDataLen.Text))
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (string.IsNullOrEmpty(Edit_AccessCode2.Text))
            {
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode2.Text);
            if (string.IsNullOrEmpty(Edit_WriteData.Text))
                return;
            s2 = Edit_WriteData.Text;
            if (s2.Length % 4 != 0)
            {
                MessageBox.Show("The Number must be in multiples of 4.", "Write");
                return;
            }
            WNum = Convert.ToByte(s2.Length / 4);
            byte[] Writedata = Utilities.Utilities.HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            if (checkBox_pc.Checked && C_EPC.Checked)
            {
                WordPtr = 1;
                Writedatalen = Convert.ToByte(Edit_WriteData.Text.Length / 2 + 2);
                Writedata = Utilities.Utilities.HexStringToByteArray(textBox_pc.Text + Edit_WriteData.Text);
            }
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(
                    ref FormSharedData.comAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    WrittenDataNum, EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }

            FormSharedData.MainForm.AddCmdLog("Write data", "Write", FormSharedData.cmdRet, FormSharedData.ferrorcode);
            if (FormSharedData.cmdRet == 0)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + "'Write'Command Response=0x00" +
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

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (string.IsNullOrEmpty(txtDataAddr.Text))
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (string.IsNullOrEmpty(txtDataLen.Text))
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (string.IsNullOrEmpty(Edit_AccessCode2.Text))
                return;
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            if ((Mem == 1) && (WordPtr < 2))
            {
                MessageBox.Show("the length of start Address of erasing EPC area is equal or greater than 0x01!", "Information");
                return;
            }
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode2.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.EraseCard_G2(
                    ref FormSharedData.comAdr, EPC, Mem, WordPtr, Num, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("EraseCard", "Erase data", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Block Erase'Command Response=0x00" +
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

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            if (ComboBox_EPC2.Items.Count == 0)
                return;
            if (ComboBox_EPC2.SelectedItem == null)
                return;
            str = ComboBox_EPC2.SelectedItem.ToString() ?? "";
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(ENum * 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            if (C_Reserve.Checked)
                Mem = 0;
            if (C_EPC.Checked)
                Mem = 1;
            if (C_TID.Checked)
                Mem = 2;
            if (C_User.Checked)
                Mem = 3;
            if (string.IsNullOrEmpty(txtDataAddr.Text))
            {
                MessageBox.Show("Address of Tag Data is NULL", "Information");
                return;
            }
            if (string.IsNullOrEmpty(txtDataLen.Text))
            {
                MessageBox.Show("Length of Data(Read/Block Erase) is NULL", "Information");
                return;
            }
            if (Convert.ToInt32(txtDataAddr.Text, 16) + Convert.ToInt32(txtDataLen.Text) > 120)
                return;
            if (string.IsNullOrEmpty(Edit_AccessCode2.Text))
            {
                return;
            }
            WordPtr = Convert.ToByte(txtDataAddr.Text, 16);
            Num = Convert.ToByte(txtDataLen.Text);
            if (Edit_AccessCode2.Text.Length != 8)
            {
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode2.Text);
            if (string.IsNullOrEmpty(Edit_WriteData.Text))
                return;
            s2 = Edit_WriteData.Text;
            if (s2.Length % 4 != 0)
            {
                MessageBox.Show("The Number must be 4 times.", "Write");
                return;
            }
            WNum = Convert.ToByte(s2.Length / 4);
            byte[] Writedata = Utilities.Utilities.HexStringToByteArray(s2);
            Writedatalen = Convert.ToByte(WNum * 2);
            if (checkBox_pc.Checked && C_EPC.Checked)
            {
                WordPtr = 1;
                Writedatalen = Convert.ToByte(Edit_WriteData.Text.Length / 2 + 2);
                Writedata = Utilities.Utilities.HexStringToByteArray(textBox_pc.Text + Edit_WriteData.Text);
            }
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteBlock_G2(
                    ref FormSharedData.comAdr, EPC, Mem, WordPtr, Writedatalen, Writedata, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    WrittenDataNum, EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("Write Block", "WriteBlock", FormSharedData.cmdRet, FormSharedData.ferrorcode);
            if (FormSharedData.cmdRet == 0)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + "'WriteBlock'Command Response=0x00" +
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

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }

            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;

            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);

            if (ComboBox_EPC1.Items.Count == 0)
                return;
            if (ComboBox_EPC1.SelectedItem == null)
                return;

            str = ComboBox_EPC1.SelectedItem.ToString() ?? "";
            if (string.IsNullOrEmpty(str))
                return;

            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);

            if (textBox2.Text.Length != 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }

            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(textBox2.Text);
            if ((P_Reserve.Checked) && (DestroyCode.Checked))
                select = 0;
            else if ((P_Reserve.Checked) && (AccessCode.Checked))
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

            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetCardProtect_G2(
                    ref FormSharedData.comAdr, EPC, select, setprotect, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("SetCardProtect", "SetProtect", FormSharedData.cmdRet, FormSharedData.ferrorcode);
        }

        private void Button_DestroyCard_Click(object sender, EventArgs e)
        {
            byte EPClength;
            string str;
            byte ENum;

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + "";
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
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_DestroyCode.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.DestroyCard_G2(
                    ref FormSharedData.comAdr, EPC, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("DestroyCard", "Kill Tag", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Kill Tag'Command Response=0x00" +
                          "(Kill successfully)";
        }

        private void Button_WriteEPC_G2_Click(object sender, EventArgs e)
        {
            byte[] WriteEPC = new byte[100];
            byte WriteEPClen;
            byte ENum;
            if (!FormSharedData.IsReady()) return;

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
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(Edit_WriteEPC.Text);
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode3.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteEPC_G2(
                    ref FormSharedData.comAdr, ref pwd, EPC, WriteEPClen,
                    ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("WriteEPC_G2", "Write EPC", FormSharedData.cmdRet, FormSharedData.ferrorcode);
            if (FormSharedData.cmdRet == 0)
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Write EPC'Command Response=0x00" +
                            "(Write EPC successfully)";
        }

        private void Button_SetReadProtect_G2_Click(object sender, EventArgs e)
        {
            byte EPClength;
            byte ENum;
            string str;

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
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
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode4.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetReadProtect_G2(
                    ref FormSharedData.comAdr, EPC, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("SetReadProtect_G2", "Set Single Tag Read Protection", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
            {
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Set Single Tag Read Protection'Command Response=0x00" +
                        "Set Single Tag Read Protection successfully";
            }
        }
        private void Button_SetMultiReadProtect_G2_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (Edit_AccessCode4.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode4.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetMultiReadProtect_G2(
                    ref FormSharedData.comAdr, ref pwd, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("SetMultiReadProtect_G2", "Set Single Tag Read Protection without EPC", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Set Single Tag Read Protection without EPC'Command Response=0x00" +
                        "(Set Single Tag Read Protection without EPC successfully)";
        }

        private void Button_RemoveReadProtect_G2_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (Edit_AccessCode4.Text.Length < 8)
            {
                MessageBox.Show("Access Password Less Than 8 digit!Please input again!", "Information");
                return;
            }
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode4.Text);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.RemoveReadProtect_G2(
                    ref FormSharedData.comAdr, ref pwd, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("RemoveReadProtect_G2", "Reset Single Tag Read Protection", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Reset Single Tag Read Protection'Command Response=0x00" +
                          "(Reset Single Tag Read Protection successfully)";
        }

        private void Button_CheckReadProtected_G2_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            byte readpro = 2;
            {
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.CheckReadProtected_G2(
                    ref FormSharedData.comAdr, ref readpro, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("CheckReadProtected_G2", "Detect Single Tag Read Protection", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
            {
                if (readpro == 0)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Detect Single Tag Read Protection'Command Response=0x00" +
                        "(Single Tag is unprotected)";
                if (readpro == 1)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Detect Single Tag Read Protection'Command Response=0x01" +
                        "(Single Tag is protected)";
            }
        }

        private void Button_SetEASAlarm_G2_Click(object sender, EventArgs e)
        {
            byte EPClength = 0;
            byte EAS = 0;
            byte ENum;
            string str;

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
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
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode5.Text);
            if (Alarm_G2.Checked)
                EAS = 1;
            else
                EAS = 0;

            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetEASAlarm_G2(
                    ref FormSharedData.comAdr, EPC, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    EAS, EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("SetEASAlarm_G2", "Alarm Setting", FormSharedData.cmdRet);     //v2.1 change
            if (FormSharedData.cmdRet == 0)
            {
                if (Alarm_G2.Checked)                                //v2.1 add
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Alarm Setting'Command Response=0x00" +
                                "(Set EAS Alarm successfully)";
                else
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Alarm Setting'Command Response=0x00" +
                                "(Clear EAS Alarm successfully)";
            }

        }
        private void Button_CheckEASAlarm_G2_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            Timer_G2_Alarm.Enabled = !Timer_G2_Alarm.Enabled;
            if (Timer_G2_Alarm.Enabled)
            {
                Button_CheckEASAlarm_G2.Text = "Stop";
            }
            else
            {
                Button_CheckEASAlarm_G2.Text = "Check Alarm";
                Label_Alarm.Visible = false;                       //v2.1 add
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check EAS Alarm'over";
            }
        }
        private void Button_LockUserBlock_G2_Click(object sender, EventArgs e)
        {
            byte EPClength = 0;
            byte BlockNum = 0;
            byte ENum;
            string str;

            if (!FormSharedData.IsReady()) return;

            if (string.IsNullOrEmpty(maskadr_textbox.Text) || string.IsNullOrEmpty(maskLen_textBox.Text))
            {
                FormSharedData.fIsInventoryScan = false;
                return;
            }
            if (checkBox1.Checked)
                FormSharedData.MaskFlag = 1;
            else
                FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte(maskadr_textbox.Text, 16);
            FormSharedData.MaskLen = Convert.ToByte(maskLen_textBox.Text, 16);
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
            if (string.IsNullOrEmpty(str))
                return;
            ENum = Convert.ToByte(str.Length / 4);
            EPClength = Convert.ToByte(str.Length / 2);
            byte[] EPC = Utilities.Utilities.HexStringToByteArray(str);
            FormSharedData.fPassWord = Utilities.Utilities.HexStringToByteArray(Edit_AccessCode6.Text);
            BlockNum = Convert.ToByte(ComboBox_BlockNum.SelectedIndex * 2);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.LockUserBlock_G2(
                    ref FormSharedData.comAdr, EPC, ref pwd,
                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                    BlockNum, EPClength, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("LockUserBlock_G2", "Lock User Block", FormSharedData.cmdRet);
            if (FormSharedData.cmdRet == 0)
                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Lock User Block'Command Response=0x00" +
                        "(Lock successfully)";
        }
        private void ComboBox_IntervalTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            Timer_Test_.Interval = (ComboBox_IntervalTime.SelectedIndex + 4) * 10;
        }

        public void ChangeSubItem1(ListViewItem ListItem, int subItemIndex, string ItemText)
        {
            if (subItemIndex == 1)
            {
                if (ListItem.SubItems.Count < 3) return;
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
                if (!string.IsNullOrEmpty(EPCValue))
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
            if ((!Timer_Test_.Enabled) && (!Timer_G2_Alarm.Enabled) && (!Timer_G2_Read.Enabled))
            {
                //    Button_DataWrite.Enabled = false;
            }
        }

        private void C_TID_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) && (!Timer_G2_Alarm.Enabled) && (!Timer_G2_Read.Enabled))
            {
                if (ListView1_EPC.Items.Count != 0)
                    Button_DataWrite.Enabled = true;
            }
            txtDataAddr.ReadOnly = false;
        }

        private void C_User_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) && (!Timer_G2_Alarm.Enabled) && (!Timer_G2_Read.Enabled))
            {
                if (ListView1_EPC.Items.Count != 0)
                    Button_DataWrite.Enabled = true;
            }
            txtDataAddr.ReadOnly = false;
        }

        private void C_Reserve_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_Test_.Enabled) && (!Timer_G2_Alarm.Enabled) && (!Timer_G2_Read.Enabled))
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
                if (checkBox_pc.Checked && n % 4 == 0 && C_EPC.Checked)
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
            if (checkBox_pc.Checked && n % 4 == 0 && C_EPC.Checked)
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
                if (ListItem.SubItems.Count < 4) return;
                if (string.IsNullOrEmpty(ItemText))
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    if (string.IsNullOrEmpty(ListItem.SubItems[subItemIndex + 2].Text))
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
                if (ListItem.SubItems.Count < 3) return;
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                }
            }
        }
        private void cb6C_IKnowTagLock_CheckedChanged(object sender, EventArgs e)
        {
            gbTagLock.Enabled = cb6C_IKnowTagLock.Checked;
        }

        private void cb6C_IKnowTagKill_CheckedChanged(object sender, EventArgs e)
        {
            gbKillTag.Enabled = cb6C_IKnowTagKill.Checked;
        }
    }
}
