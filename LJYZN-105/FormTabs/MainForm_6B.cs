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
        private void Timer_Test_6B_Tick(object sender, EventArgs e)
        {
            if (fisinventoryscan_6B)
                return;
            fisinventoryscan_6B = true;
            Inventory_6B();
            fisinventoryscan_6B = false;
        }
        private void Timer_6B_Read_Tick(object sender, EventArgs e)
        {
            if (fTimer_6B_ReadWrite)
                return;
            fTimer_6B_ReadWrite = true;
            Read_6B();
            fTimer_6B_ReadWrite = false;
        }
        private void Timer_6B_Write_Tick(object sender, EventArgs e)
        {
            if (fTimer_6B_ReadWrite)
                return;
            fTimer_6B_ReadWrite = true;
            Write_6B();
            fTimer_6B_ReadWrite = false;
        }
        private void SpeedButton_Read_6B_Click(object sender, EventArgs e)
        {
            if ((Edit_StartAddress_6B.Text == "") | (Edit_Len_6B.Text == ""))
            {
                MessageBox.Show("Start address or length is empty!Please input!", "Information");
                return;
            }
            Timer_6B_Read.Enabled = !Timer_6B_Read.Enabled;
            if (!Timer_6B_Read.Enabled)
            {
                AddCmdLog("Read", "Exit Read", 0);
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
            ID_6B = HexStringToByteArray(temp);
            if (Edit_StartAddress_6B.Text == "")
                return;
            StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text, 16);
            if (Edit_Len_6B.Text == "")
                return;
            Num = Convert.ToByte(Edit_Len_6B.Text);
            fCmdRet = StaticClassReaderB.ReadCard_6B(ref fComAdr, ID_6B, StartAddress, Num, CardData, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                byte[] data = new byte[Num];
                Array.Copy(CardData, data, Num);
                temps = ByteArrayToHexString(data);
                lb6B_list2.Items.Add(temps);
            }
            if (fAppClosed)
                Close();
        }
        private void SpeedButton_Write_6B_Click(object sender, EventArgs e)
        {
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
                AddCmdLog("Write", "Exit Query", 0);
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
            ID_6B = HexStringToByteArray(temp);
            if (Edit_StartAddress_6B.Text == "")
                return;
            StartAddress = Convert.ToByte(Edit_StartAddress_6B.Text);
            if ((Edit_WriteData_6B.Text == "") | (Edit_WriteData_6B.Text.Length % 2) != 0)
                return;
            Writedatalen = Convert.ToByte(Edit_WriteData_6B.Text.Length / 2);
            byte[] Writedata = new byte[Writedatalen];
            Writedata = HexStringToByteArray(Edit_WriteData_6B.Text);
            fCmdRet = StaticClassReaderB.WriteCard_6B(ref fComAdr, ID_6B, StartAddress, Writedata, Writedatalen, ref writtenbyte, ref ferrorcode, frmcomportindex);
            AddCmdLog("WriteCard", "Write", fCmdRet);
            if (fAppClosed)
                Close();
        }
        private void SpeedButton_Query_6B_Click(object sender, EventArgs e)
        {
            Timer_Test_6B.Enabled = !Timer_Test_6B.Enabled;
            if (!Timer_Test_6B.Enabled)
            {
                if (lv6B_Tags.Items.Count != 0)
                {
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
                if (lv6B_Tags.Items.Count == 0)
                {
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
                AddCmdLog("Inventory", "Exit Query", 0);
                SpeedButton_Query_6B.Text = "Query ";
            }
            else
            {
                SpeedButton_Read_6B.Enabled = false;
                SpeedButton_Write_6B.Enabled = false;
                SpeedButton_Perm_Wr_Prot_6B.Enabled = false;
                SpeedButton_Check_6B.Enabled = false;
                Same_6B.Enabled = false;
                Different_6B.Enabled = false;
                Less_6B.Enabled = false;
                Greater_6B.Enabled = false;
                lv6B_Tags.Items.Clear();
                ComboBox_ID1_6B.Items.Clear();
                CardNum1 = 0;
                list.Clear();
                SpeedButton_Query_6B.Text = "Stop";
            }
        }
        private void SpeedButton_PermWriteProtect_6B_Click(object sender, EventArgs e)
        {
            byte Address;
            string temps;
            byte[] ID_6B = new byte[8];
            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temps = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temps == "")
                return;
            ID_6B = HexStringToByteArray(temps);
            if (Edit_StartAddress_6B.Text == "")
                return;
            Address = Convert.ToByte(Edit_StartAddress_6B.Text);
            if (MessageBox.Show(this, "permanently Lock the address Confirmed?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            fCmdRet = StaticClassReaderB.LockByte_6B(ref fComAdr, ID_6B, Address, ref ferrorcode, frmcomportindex);
            AddCmdLog("LockByte_6B", "Lock", fCmdRet);
        }
        private void SpeedButton_Check_6B_Click(object sender, EventArgs e)
        {
            byte Address, ReLockState = 2;
            string temps;
            byte[] ID_6B = new byte[8];
            if (ComboBox_ID1_6B.Items.Count == 0)
                return;
            if (ComboBox_ID1_6B.SelectedItem == null)
                return;
            temps = ComboBox_ID1_6B.SelectedItem.ToString() ?? "";
            if (temps == "")
                return;
            ID_6B = HexStringToByteArray(temps);
            if (Edit_StartAddress_6B.Text == "")
                return;
            Address = Convert.ToByte(Edit_StartAddress_6B.Text);
            fCmdRet = StaticClassReaderB.CheckLock_6B(ref fComAdr, ID_6B, Address, ref ReLockState, ref ferrorcode, frmcomportindex);
            AddCmdLog("CheckLock_6B", "Check Lock", fCmdRet);
            if (fCmdRet == 0)
            {
                if (ReLockState == 0)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check Lock'Command Response=0x00" +
                         "(The Byte is unlocked)";
                if (ReLockState == 1)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Check Lock'Command Response=0x01" +
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
                fCmdRet = StaticClassReaderB.Inventory_6B(ref fComAdr, ID_6B, frmcomportindex);
                if (fCmdRet == 0)
                {
                    byte[] daw = new byte[8];
                    Array.Copy(ID_6B, daw, 8);
                    temps = ByteArrayToHexString(daw);
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
                        // CardNum1 = Convert.ToByte(ListView_ID_6B.Items.Count+1);
                        aListItem = lv6B_Tags.Items[CardNum1 - 1];
                        s = temps;
                        ChangeSubItem1(aListItem, 1, s);
                        if (ComboBox_EPC1.Items.IndexOf(s) == -1)
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
                daw = HexStringToByteArray(ss);
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
                fCmdRet = StaticClassReaderB.inventory2_6B(ref fComAdr, Condition, StartAddress, mask, daw, ID2_6B, ref CardNum, frmcomportindex);
                if ((fCmdRet == 0x15) | (fCmdRet == 0x16) | (fCmdRet == 0x17) | (fCmdRet == 0x18) | (fCmdRet == 0xFB))
                {
                    byte[] daw1 = new byte[CardNum * 8];
                    Array.Copy(ID2_6B, daw1, CardNum * 8);
                    temps = ByteArrayToHexString(daw1);
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
                            // CardNum1 = Convert.ToByte(ListView_ID_6B.Items.Count+1);
                            aListItem = lv6B_Tags.Items[i];
                            s = sID;
                            ChangeSubItem1(aListItem, 1, s);
                            if (ComboBox_EPC1.Items.IndexOf(s) == -1)
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
                    if (fCmdRet != 0)
                        AddCmdLog("Inventory", "Query tag", fCmdRet);
                }
                else if (fCmdRet == 0XFB) //说明还未将所有卡读取完
                {

                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xFB" +
                           "(No Tag Operable)";
                }
                else if (fCmdRet == 0)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0x00" +
                           "(Find a Tag)";
                else
                    AddCmdLog("Inventory", "Query Tag", fCmdRet);
                if (fCmdRet == 0xEE)
                    tss_Status.Text = DateTime.Now.ToLongTimeString() + " 'Query Tag'Command Response=0xee" +
                                "(Response Command Error)";
            }
            if (fAppClosed)
                Close();
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
