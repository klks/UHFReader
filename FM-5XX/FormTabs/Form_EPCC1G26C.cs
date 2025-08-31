using FM_5XX.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FM_5XX.Shared.FormSharedData;

namespace FM_5XX.FormTabs
{
    public partial class Form_EPCC1G26C : UserControl
    {
        private string Inventory_TID_Address = "0";
        private string Inventory_TID_Length = "6";
        public Form_EPCC1G26C()
        {
            InitializeComponent();
            FormSharedData.lbSerialLog = lbSerialLog;
            cb6C_MemBank.SelectedIndex = 1;
        }
        private void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_KeyPress(sender, e);
        }
        private void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
        }
        private void btnInventoryEPC_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null || FormSharedData.IsReceiveDataWork) return;

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
        private void InventoryEPCControls_Enable(bool bEnable)
        {
            if (FormSharedData.Form_Reader != null)
            {
                FormSharedData.Form_Reader.gbVersionInfo.Enabled = bEnable;
                FormSharedData.Form_Reader.gbRFInfo.Enabled = bEnable;
            }
            btnInventoryTID.Enabled = bEnable;
            btn6C_Read.Enabled = bEnable;
            btn6C_Write.Enabled = bEnable;
            btnSetProtectState.Enabled = bEnable;
            btn6C_KillTag.Enabled = bEnable;
            btnSerialSend.Enabled = bEnable;
        }
        private void InventoryTIDControls_Enable(bool bEnable)
        {
            if (FormSharedData.Form_Reader != null)
            {
                FormSharedData.Form_Reader.gbVersionInfo.Enabled = bEnable;
                FormSharedData.Form_Reader.gbRFInfo.Enabled = bEnable;
            }
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
        private void btnLogClearSerial_Click_1(object sender, EventArgs e)
        {
            lbSerialLog.Items.Clear();
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
