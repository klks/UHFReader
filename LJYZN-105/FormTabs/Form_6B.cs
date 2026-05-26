using ReaderB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static Utilities.Utilities;

namespace LJYZN_105
{
    public partial class Form_6B : UserControl
    {
        ArrayList list = new ArrayList();
        private int CardNum1 = 0;

        public Form_6B()
        {
            InitializeComponent();

            int i = 40;
            while (i <= 300)
            {
                ComboBox_IntervalTime_6B.Items.Add(Convert.ToString(i) + "ms");
                i = i + 10;
            }
            ComboBox_IntervalTime_6B.SelectedIndex = 1;
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

        private void Timer_Test_6B_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fisinventoryscan_6B)
                return;
            FormSharedData.fisinventoryscan_6B = true;
            Inventory_6B();
            FormSharedData.fisinventoryscan_6B = false;
        }
        private void Timer_6B_Read_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fTimer_6B_ReadWrite)
                return;
            FormSharedData.fTimer_6B_ReadWrite = true;
            Read_6B();
            FormSharedData.fTimer_6B_ReadWrite = false;
        }
        private void Timer_6B_Write_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.fTimer_6B_ReadWrite)
                return;
            FormSharedData.fTimer_6B_ReadWrite = true;
            Write_6B();
            FormSharedData.fTimer_6B_ReadWrite = false;
        }
        private void SpeedButton_Read_6B_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForRead()) return;

            if ((Edit_StartAddress_6B.Text == "") | (Edit_Len_6B.Text == ""))
            {
                MessageBox.Show("Start address or length is empty!Please input!", "Information");
                return;
            }
            Timer_6B_Read.Enabled = !Timer_6B_Read.Enabled;
            if (!Timer_6B_Read.Enabled)
            {
                FormSharedData.MainForm.AddCmdLog("Read", "Exit Read", 0);
                SpeedButton_Read_6B.Text = "Read ";
                SpeedButton_Query_6B.Enabled = true;
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
            else
            {
                SpeedButton_Query_6B.Enabled = false;
                SpeedButton_Write_6B.Enabled = false;
                SpeedButton_Perm_Wr_Prot_6B.Enabled = false;
                SpeedButton_Check_6B.Enabled = false;
                if (Bycondition_6B.Checked)
                {
                    Same_6B.Enabled = false;
                    Different_6B.Enabled = false;
                    Less_6B.Enabled = false;
                    Greater_6B.Enabled = false;
                }
                SpeedButton_Read_6B.Text = "Stop";
            }
        }
        private void Read_6B()
        {
            string temp, temps;
            byte[] CardData = new byte[320];
            byte[] ID_6B = new byte[8];
            byte Num, StartAddress;
            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temp = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temp == "")
                return;
            ID_6B = Utilities.Utilities.HexStringToByteArray(temp);
            if (Edit_StartAddress_6B.Text == "")
                return;
            StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text, 16);
            if (Edit_Len_6B.Text == "")
                return;
            Num = Convert.ToByte(Edit_Len_6B.Text);
            {
                ulong tagId6B = BitConverter.ToUInt64(ID_6B, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.ReadCard_6B(
                    ref FormSharedData.fComAdr, ref tagId6B, StartAddress, Num, CardData,
                    ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.fCmdRet == 0)
            {
                byte[] data = new byte[Num];
                Array.Copy(CardData, data, Num);
                temps = Utilities.Utilities.ByteArrayToHexString(data);
                lb6B_list2.Items.Add(temps);
            }
        }
        private void SpeedButton_Write_6B_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForRead()) return;

            if ((Edit_WriteData_6B.Text == "") | ((Edit_WriteData_6B.Text.Length % 2) != 0))
            {
                MessageBox.Show("Please input in bytes in hexadecimal form!", "Information");
                return;
            }
            if ((Edit_StartAddress_6B.Text == "") | (Edit_Len_6B.Text == ""))
            {
                MessageBox.Show("Start address or length is empty!Please input!", "Information");
                return;
            }
            Timer_6B_Write.Enabled = !Timer_6B_Write.Enabled;
            if (!Timer_6B_Write.Enabled)
            {
                FormSharedData.MainForm.AddCmdLog("Write", "Exit Query", 0);
                SpeedButton_Write_6B.Text = "Write ";
            }
            else
            {
                SpeedButton_Write_6B.Text = "Stop";
            }
        }
        private void Write_6B()
        {
            string temp;
            byte[] CardData = new byte[320];
            byte[] ID_6B = new byte[8];
            byte StartAddress;
            byte Writedatalen;
            int writtenbyte = 0;
            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temp = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temp == "")
                return;
            ID_6B = Utilities.Utilities.HexStringToByteArray(temp);
            if (Edit_StartAddress_6B.Text == "")
                return;
            StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text);
            if ((Edit_WriteData_6B.Text == "") | (Edit_WriteData_6B.Text.Length % 2) != 0)
                return;
            Writedatalen = Convert.ToByte(Edit_WriteData_6B.Text.Length / 2);
            byte[] Writedata = new byte[Writedatalen];
            Writedata = Utilities.Utilities.HexStringToByteArray(Edit_WriteData_6B.Text);
            {
                ulong tagId6B = BitConverter.ToUInt64(ID_6B, 0);
                byte writtenCount = 0;
                uint errCode = uint.MaxValue;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.WriteCard_6B(
                    ref FormSharedData.fComAdr, ref tagId6B, StartAddress, Writedata, Writedatalen,
                    ref writtenCount, ref errCode, FormSharedData.frmcomportindex);
                writtenbyte = writtenCount;
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("WriteCard", "Write", FormSharedData.fCmdRet);
        }
        private void SpeedButton_Query_6B_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForInventory6B()) return;

            Timer_Test_6B.Enabled = !Timer_Test_6B.Enabled;
            if (!Timer_Test_6B.Enabled)
            {
                FormSharedData.MainForm.AddCmdLog("Inventory", "Exit Query", 0);
                SpeedButton_Query_6B.Text = "Query ";
                FormSharedData.bIsInventoryRunning_6B = false;
            }
            else
            {
                lv6B_Tags.Items.Clear();
                ComboBox_ID1_6B.Items.Clear();
                CardNum1 = 0;
                list.Clear();
                SpeedButton_Query_6B.Text = "Stop";
                FormSharedData.bIsInventoryRunning_6B = true;
            }
        }
        private void SpeedButton_PermWriteProtect_6B_Click(object sender, EventArgs e)
        {
            byte Address;
            string temps;
            byte[] ID_6B = new byte[8];

            if (!FormSharedData.IsReadyForRead()) return;

            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temps = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temps == "")
                return;
            ID_6B = Utilities.Utilities.HexStringToByteArray(temps);
            if (Edit_StartAddress_6B.Text == "")
                return;
            Address = Convert.ToByte(Edit_StartAddress_6B.Text);
            if (MessageBox.Show(this, "permanently Lock the address Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            {
                ulong tagId6B = BitConverter.ToUInt64(ID_6B, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.LockByte_6B(
                    ref FormSharedData.fComAdr, ref tagId6B, Address,
                    ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("LockByte_6B", "Lock", FormSharedData.fCmdRet);
        }
        private void SpeedButton_Check_6B_Click(object sender, EventArgs e)
        {
            byte Address, ReLockState = 2;
            string temps;
            byte[] ID_6B = new byte[8];

            if (!FormSharedData.IsReadyForRead()) return;

            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temps = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temps == "")
                return;
            ID_6B = Utilities.Utilities.HexStringToByteArray(temps);
            if (Edit_StartAddress_6B.Text == "")
                return;
            Address = Convert.ToByte(Edit_StartAddress_6B.Text);
            {
                ulong tagId6B = BitConverter.ToUInt64(ID_6B, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.CheckLock_6B(
                    ref FormSharedData.fComAdr, ref tagId6B, Address, ref ReLockState,
                    ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            FormSharedData.MainForm.AddCmdLog("CheckLock_6B", "Check Lock", FormSharedData.fCmdRet);
            if (FormSharedData.fCmdRet == 0)
            {
                if (ReLockState == 0)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check Lock'Command Response=0x00" +
                         "(The Byte is unlocked)";
                if (ReLockState == 1)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check Lock'Command Response=0x01" +
                       "(The Byte is locked)";

            }
        }
        private void SpeedButton_Clear_6B_Click(object sender, EventArgs e)
        {
            lb6B_list2.Items.Clear();
        }
        private void Inventory_6B()
        {
            int CardNum = 0;
            byte[] ID_6B = new byte[2000];
            byte[] ID2_6B = new byte[5000];
            bool isonlistview;
            string temps;
            string s, ss, sID;
            ListViewItem aListItem = new ListViewItem();
            int i, j;
            byte Condition = 0;
            byte StartAddress;
            byte mask = 0;
            byte[] ConditionContent = new byte[300];
            byte Contentlen;
            if (Byone_6B.Checked)
            {
                ulong tagId6B = 0;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.Inventory_6B(ref FormSharedData.fComAdr, ref tagId6B, FormSharedData.frmcomportindex);
                if (FormSharedData.fCmdRet == 0)
                {
                    byte[] daw = BitConverter.GetBytes(tagId6B);
                    temps = Utilities.Utilities.ByteArrayToHexString(daw);
                    if (!list.Contains(temps))
                    {
                        CardNum1 = CardNum1 + 1;
                        list.Add(temps);
                    }
                    while (lv6B_Tags.Items.Count < CardNum1)
                    {
                        aListItem = lv6B_Tags.Items.Add((lv6B_Tags.Items.Count + 1).ToString());
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                        aListItem.SubItems.Add("");
                    }
                    isonlistview = false;
                    for (i = 0; i < CardNum1; i++)     //判断是否在Listview列表内
                    {
                        if (temps == lv6B_Tags.Items[i].SubItems[1].Text)
                        {
                            aListItem = lv6B_Tags.Items[i];
                            ChangeSubItem1(aListItem, 1, temps);
                            isonlistview = true;
                        }
                    }
                    if (!isonlistview)
                    {
                        aListItem = lv6B_Tags.Items[CardNum1 - 1];
                        s = temps;
                        FormSharedData.Form_6C.ChangeSubItem1(aListItem, 1, s);
                        if (FormSharedData.Form_6C.ComboBox_EPC1.Items.IndexOf(s) == -1)
                        {
                            ComboBox_ID1_6B.Items.Add(temps);
                        }

                    }
                }

                if (ComboBox_ID1_6B.Items.Count != 0)
                    ComboBox_ID1_6B.SelectedIndex = 0;
            }
            if (Bycondition_6B.Checked)
            {
                if (Same_6B.Checked)
                    Condition = 0;
                else if (Different_6B.Checked)
                    Condition = 1;
                else if (Greater_6B.Checked)
                    Condition = 2;
                else if (Less_6B.Checked)
                    Condition = 3;
                if (Edit_ConditionContent_6B.Text == "")
                    return;
                ss = Edit_ConditionContent_6B.Text;
                Contentlen = Convert.ToByte((Edit_ConditionContent_6B.Text).Length);
                for (i = 0; i < 16 - Contentlen; i++)
                    ss = ss + "0";
                int Nlen = (ss.Length) / 2;
                byte[] daw = new byte[Nlen];
                daw = Utilities.Utilities.HexStringToByteArray(ss);
                switch (Contentlen / 2)
                {
                    case 1:
                        mask = 0x80;
                        break;
                    case 2:
                        mask = 0xC0;
                        break;
                    case 3:
                        mask = 0xE0;
                        break;
                    case 4:
                        mask = 0XF0;
                        break;
                    case 5:
                        mask = 0XF8;
                        break;
                    case 6:
                        mask = 0XFC;
                        break;
                    case 7:
                        mask = 0XFE;
                        break;
                    case 8:
                        mask = 0XFF;
                        break;
                }
                if (Edit_Query_StartAddress_6B.Text == "")
                    return;
                StartAddress = Convert.ToByte(Edit_Query_StartAddress_6B.Text);
                ulong condContent = BitConverter.ToUInt64(daw, 0);
                uint cardNumUInt2 = 0;
                FormSharedData.fCmdRet = (int)StaticClassReaderB.inventory2_6B(ref FormSharedData.fComAdr, Condition, StartAddress, mask, ref condContent, ID2_6B,
                                                                            ref cardNumUInt2, FormSharedData.frmcomportindex);
                CardNum = (int)cardNumUInt2;
                if ((FormSharedData.fCmdRet == 0x15) | (FormSharedData.fCmdRet == 0x16) |
                    (FormSharedData.fCmdRet == 0x17) | (FormSharedData.fCmdRet == 0x18) |
                    (FormSharedData.fCmdRet == 0xFB))
                {
                    byte[] daw1 = new byte[CardNum * 8];
                    Array.Copy(ID2_6B, daw1, CardNum * 8);
                    temps = Utilities.Utilities.ByteArrayToHexString(daw1);
                    for (i = 0; i < CardNum; i++)
                    {
                        sID = temps.Substring(16 * i, 16);
                        if ((sID.Length) != 16)
                            return;
                        if (CardNum == 0)
                            return;
                        while (lv6B_Tags.Items.Count < CardNum)
                        {
                            aListItem = lv6B_Tags.Items.Add((lv6B_Tags.Items.Count + 1).ToString());
                            aListItem.SubItems.Add("");
                            aListItem.SubItems.Add("");
                            aListItem.SubItems.Add("");
                        }
                        isonlistview = false;
                        for (j = 0; j < lv6B_Tags.Items.Count; j++)     //判断是否在Listview列表内
                        {
                            if (sID == lv6B_Tags.Items[j].SubItems[1].Text)
                            {
                                aListItem = lv6B_Tags.Items[j];
                                ChangeSubItem1(aListItem, 1, sID);
                                isonlistview = true;
                            }
                        }
                        if (!isonlistview)
                        {
                            aListItem = lv6B_Tags.Items[i];
                            s = sID;
                            ChangeSubItem1(aListItem, 1, s);
                            if (FormSharedData.Form_6C.ComboBox_EPC1.Items.IndexOf(s) == -1)
                            {
                                ComboBox_ID1_6B.Items.Add(sID);
                            }
                        }
                    }
                    if (ComboBox_ID1_6B.Items.Count != 0)
                        ComboBox_ID1_6B.SelectedIndex = 0;
                }
            }
            if (Timer_Test_6B.Enabled)
            {
                if (Bycondition_6B.Checked)
                {
                    if (FormSharedData.fCmdRet != 0)
                        FormSharedData.MainForm.AddCmdLog("Inventory", "Query tag", FormSharedData.fCmdRet);
                }
                else if (FormSharedData.fCmdRet == 0XFB) //说明还未将所有卡读取完
                {

                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xFB" +
                           "(No Tag Operable)";
                }
                else if (FormSharedData.fCmdRet == 0)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0x00" +
                           "(Find a Tag)";
                else
                    FormSharedData.MainForm.AddCmdLog("Inventory", "Query Tag", FormSharedData.fCmdRet);
                if (FormSharedData.fCmdRet == 0xEE)
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xee" +
                                "(Response Command Error)";
            }
        }
        private void Byone_6B_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_6B_Read.Enabled) & (!Timer_6B_Write.Enabled) & (!Timer_Test_6B.Enabled))
            {
                Same_6B.Enabled = false;
                Different_6B.Enabled = false;
                Less_6B.Enabled = false;
                Greater_6B.Enabled = false;
            }
        }

        private void Bycondition_6B_CheckedChanged(object sender, EventArgs e)
        {
            if ((!Timer_6B_Read.Enabled) & (!Timer_6B_Write.Enabled) & (!Timer_Test_6B.Enabled))
            {
                Same_6B.Enabled = true;
                Different_6B.Enabled = true;
                Less_6B.Enabled = true;
                Greater_6B.Enabled = true;
            }
        }
    }
}
