using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCchip.Reader.API;

namespace ES_F3105U
{
    public partial class Form_EPCC1G26C : UserControl
    {
        DateTime dtLastInventoryRSSIUpdate = DateTime.Now;
        bool bSingleFireRead = false;
        private bool isTimer6C_ReadProcessing = false;

        private static byte[,] para_B = {{43,43,45,49,43,43,45,49},
                                    {43,43,45,49,43,43,45,49},
                                    {43,43,45,49,43,43,45,49},
                                    {53,53,48,43,49,45,43,43},
                                    {47,47,47,47,46,43,43,43}};

        private static int[,] para_C = {{43,43,45,49,43,43,45,49},
                                    {43,43,45,49,43,43,45,49},
                                    {43,43,45,49,43,43,45,49},
                                    {-283,-283,-283,-283,-283,-283,-283,-283},
                                    {-303,-283,-253,-238,-304,-313,-280,-266}};

        public Form_EPCC1G26C()
        {
            InitializeComponent();
            cb6C_MemBank.SelectedIndex = 1;
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

        private static int calculateRssi(int rssiData, byte epcLen)
        {
            byte rssiMode = 0;
            byte hardwareMode = 0;
            int B = 0;
            int C = 0;
            int D = 0;
            int rssiVal = 0;
            float A = 1.0f;
            float rssiTemp = 0.0f;

            if (epcLen <= 0) epcLen = 1;
            rssiMode = (byte)(((rssiData >> 24) & 0x000000E0) >> 5);
            hardwareMode = (byte)(((rssiData >> 24) & 0x0000001E) >> 1);
            rssiData = (rssiData & 0x01ffffff);

            if (rssiMode > 7 || hardwareMode > 4)
            {
                return -90;
            }

            B = para_B[hardwareMode, rssiMode];
            C = para_C[hardwareMode, rssiMode];

            rssiTemp = (rssiData / epcLen) * A;
            rssiVal = (int)((B * Math.Log10(rssiTemp)) + C + D);

            if (rssiVal > 0)
            {
                rssiVal = 0;
            }
            else if (rssiVal < -90)
            {
                rssiVal = -90;
            }

            return rssiVal;
        }

        private async void timer6C_PollRead_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null)
            {
                timer6C_PollRead.Enabled = false;
                return;
            }
            if (bSingleFireRead)    //Only read one, disable subsequent timer
            {
                timer6C_PollRead.Enabled = false;
            }

            if (cb6C_MemBank.SelectedItem == null) return;
            if (isTimer6C_ReadProcessing) return;

            isTimer6C_ReadProcessing = true;

            byte membank = GetSelectedReadMemoryBank();
            uint accessPwd = Convert.ToUInt32(txt6C_AccessPwd.Text, 16);
            uint startAddr = Convert.ToUInt16(txt6C_StartAddr.Text, 16);
            ushort readSize = Convert.ToUInt16(txt6C_RWLen.Text);

            string readDataEPC = "";
            string totalReadData = "";

            FormSharedData.AddListBoxResponse($"timer6C_PollRead -> Start");
            uint curReadIndex = 0;
            while (curReadIndex != readSize)
            {
                ushort toReadSize = (ushort)Math.Min(readSize - curReadIndex, (ushort)20);   //Only do 20 words at a time

                DateTime dtStart = DateTime.Now;

                ReadWriteParsedData result = new ReadWriteParsedData();

                Task<bool> task = Task.Run(() => FormSharedData.AttemptRead_6C(membank, startAddr + curReadIndex, toReadSize, accessPwd, result));
                await task;

                if (task.Result == true)
                {
                    if (readDataEPC == "" && result.StringEPC != null)
                        readDataEPC = result.StringEPC;

                    if (result.StringEPC != readDataEPC)
                        FormSharedData.AddListBoxResponse($"timer6C_PollRead -> Incorrect EPC, expecting {readDataEPC} but got {result.StringEPC}");

                    totalReadData += result.StringData;  //Append
                }
                else
                {
                    FormSharedData.AddListBoxResponse($"timer6C_PollRead -> Abandoning Loop");
                    break;
                }

                curReadIndex += toReadSize;

                //Internal cooldown
                TimeSpan td = DateTime.Now - dtStart;
                if (td.Milliseconds < FormSharedData.minCooldown)
                {
                    Thread.Sleep(FormSharedData.minCooldown - td.Milliseconds);
                }
            }

            //Show results
            if (totalReadData != "")
            {
                string outStr = $"[{readDataEPC}][{totalReadData.Length / 4}] {totalReadData}";
                lb6C_RWResults.Items.Insert(0, outStr);
            }

            if (bSingleFireRead)    //Enable controls again
            {
                btn6C_Read.Invoke(new MethodInvoker(delegate { btn6C_Read.Enabled = true; }));
            }
            FormSharedData.AddListBoxResponse($"timer6C_PollRead -> End");
            isTimer6C_ReadProcessing = false;
        }

        private void timerInventory_Tick(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null)
            {
                timerInventory.Enabled = false;
                return;
            }

            if (!FormSharedData.responseParser.epcQueue.IsEmpty)
            {
                if (FormSharedData.responseParser.epcQueue.TryDequeue(out byte[] epcData))
                {
                    int epcLen = epcData.Length - 10;
                    string PCString = UCchipClient.ToHexString(epcData.Skip(1).Take(2).ToArray());
                    string epcString = UCchipClient.ToHexString(epcData.Skip(3).Take(epcLen).ToArray());
                    epcString = epcString.Replace(" ", "");

                    byte[] bRSSI = epcData.Skip(3 + epcLen).Take(4).ToArray();
                    byte[] bFreq = epcData.Skip(3 + 4 + epcLen).ToArray();

                    int iRSSI = bRSSI[0] << 24 | bRSSI[1] << 16 | bRSSI[2] << 8 | bRSSI[3];
                    iRSSI = calculateRssi(iRSSI, (byte)epcLen);

                    int iFreq = bFreq[0] << 16 | bFreq[1] << 8 | bFreq[2];

                    bool is_on_list = false;

                    for (int i = 0; i < lvInventory.Items.Count; i++)
                    {
                        if (epcString == lvInventory.Items[i].SubItems[2].Text)
                        {
                            //Update count
                            string strCount = lvInventory.Items[i].SubItems[4].Text;
                            lvInventory.Items[i].SubItems[4].Text = (int.Parse(strCount) + 1).ToString();

                            if ((DateTime.Now - dtLastInventoryRSSIUpdate).TotalMilliseconds > 100)
                            {
                                //Update rssi
                                lvInventory.Items[i].SubItems[5].Text = iRSSI.ToString() + " dBM";

                                //Update freq
                                lvInventory.Items[i].SubItems[6].Text = iFreq.ToString("N0") + " Hz";
                                dtLastInventoryRSSIUpdate = DateTime.Now;
                            }

                            is_on_list = true;
                        }
                    }
                    if (!is_on_list)
                    {
                        ListViewItem item = lvInventory.Items.Add((lvInventory.Items.Count + 1).ToString());

                        item.SubItems.Add(PCString);                                // 1 - PC
                        item.SubItems.Add(epcString);                               // 2 - EPC
                        item.SubItems.Add((epcString.Length / 2).ToString());       // 3 - EPC Length
                        item.SubItems.Add("1");                                     // 4 - Count
                        item.SubItems.Add(iRSSI.ToString() + " dBM");               // 5 - RSSI
                        item.SubItems.Add(iFreq.ToString("N0") + " Hz");            // 6 - Frequency
                    }
                }
            }
        }

        private async void btnInventory_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            btn6C_Inventory.Enabled = false;
            FormSharedData.responseParser.epcQueue.Clear();   //Flush the queue

            if (btn6C_Inventory.Text == "Inventory")
            {
                //Reset UI fields
                lvInventory.Items.Clear();
                txt6C_KillEPC.Text = "";
                txt6C_RWEPC.Text = "";
                txt6C_LockEPCTag.Text = "";

                FormSharedData.responseParser.ResetFlag("flag_cmd_real_time_inventory");
                FormSharedData.readerClient.MsgStartInventory();
                Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_real_time_inventory"));
                await task;

                if (task.Result == ErrorCode.OK)
                {
                    btn6C_Inventory.Text = "Stop";
                    timerInventory.Enabled = true;
                    FormSharedData.bIsInventoryRunning = true;
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    FormSharedData.responseParser.ResetFlag("flag_cmd_stop_inventory");
                    FormSharedData.readerClient.MsgBaseStopInventory();
                    Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_stop_inventory", 1500));
                    await task;

                    if (task.Result == ErrorCode.OK)
                    {
                        timerInventory.Enabled = false;
                        btn6C_Inventory.Text = "Inventory";
                        FormSharedData.bIsInventoryRunning = false;
                        break;
                    }
                }

            }
            btn6C_Inventory.Enabled = true;
        }

        private void cbIKnowTagKill_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_TagKill.Enabled = !groupBox_TagKill.Enabled;
        }

        private void cbIKnowTagLock_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_TagLocking.Enabled = !groupBox_TagLocking.Enabled;
        }

        private async void lvInventory_DoubleClick(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            if (FormSharedData.bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            if (lvInventory.Items.Count > 0)
            {
                string selEPC = lvInventory.SelectedItems[0].SubItems[2].Text;
                txt6C_KillEPC.Text = selEPC;
                txt6C_RWEPC.Text = selEPC;
                txt6C_LockEPCTag.Text = selEPC;

                byte[] bEPCArr = Utilities.Utilities.HexStringToByteArray(selEPC);

                FormSharedData.responseParser.ResetFlag("flag_cmd_set_access_epc_match");
                FormSharedData.readerClient.MsgBaseSetAccessEpcMatch(0, (byte)bEPCArr.Length, bEPCArr);
                Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_set_access_epc_match"));
                await task;

                if (task.Result == ErrorCode.OK)
                    FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lb6C_RWResults.Items.Clear();
        }

        private async Task<bool> b6CReadWriteSanityCheck()
        {
            if (FormSharedData.readerClient == null) return false;

            if (FormSharedData.bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }

            string strAccessPwd = "";
            string strStartAddr = "";
            string strRWLen = "";

            txt6C_AccessPwd.Invoke(new MethodInvoker(delegate { strAccessPwd = txt6C_AccessPwd.Text; }));
            txt6C_StartAddr.Invoke(new MethodInvoker(delegate { strStartAddr = txt6C_StartAddr.Text; }));
            txt6C_RWLen.Invoke(new MethodInvoker(delegate { strRWLen = txt6C_RWLen.Text; }));

            if (strAccessPwd == "" ||
                strStartAddr == "" ||
                strRWLen == "")
            {
                MessageBox.Show("Please check values for reading/writing", "RW Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }

            int AccessPwdLen = 0;
            txt6C_AccessPwd.Invoke(new MethodInvoker(delegate { AccessPwdLen = txt6C_AccessPwd.TextLength; }));

            if (AccessPwdLen != 8)
            {
                MessageBox.Show("Access Password must be 8 hex chars!", "RW Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }

            if (FormSharedData.Option_Disable_Write_MsgBaseSetAccessEpcMatch == false)
            {
                //Verify the filter in the reader against what we selected
                FormSharedData.responseParser.ResetFlag("flag_cmd_get_access_epc_match");
                FormSharedData.readerClient.MsgBaseGetAccessEpcMatch();
                Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_get_access_epc_match"));
                await task;

                if (task.Result == ErrorCode.Timeout)
                {
                    MessageBox.Show("Failed to validate EPC, try again!", "Match Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }

                string strSelectedEPC = txt6C_RWEPC.Text;
                if (FormSharedData.responseParser.readerFilteredEPC == "" || strSelectedEPC == "")
                {
                    MessageBox.Show("Please select an EPC from the inventory again, empty EPC filtered", "Selection Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }

                //Truncate to the length of the returned filter
                string m1 = strSelectedEPC;
                string m2 = FormSharedData.responseParser.readerFilteredEPC;

                if (m1.Length != m2.Length)
                {
                    int minLen = Math.Min(m1.Length, m2.Length);
                    m1 = m1.Substring(0, minLen);
                    m2 = m2.Substring(0, minLen);
                }

                if (m1 != m2)
                {
                    MessageBox.Show("Please select an EPC from the inventory again, EPC selected do not match", "Selection Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return false;
                }
            }


            return true;
        }
        private async void btnRead_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;
            if (FormSharedData.bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            if (btn6C_Read.Text == "Read")
            {
                //Do some sanity checking
                Task<bool> task_validate = Task.Run(() => b6CReadWriteSanityCheck());
                await task_validate;
                if (task_validate.Result == false) return;

                if (cbReader_PollReading.Checked != true)
                {
                    btn6C_Read.Enabled = false;
                    bSingleFireRead = true;
                }
                else
                {
                    //Disable controls
                    cb6C_MemBank.Enabled = false;
                    txt6C_AccessPwd.Enabled = false;
                    txt6C_StartAddr.Enabled = false;
                    txt6C_RWLen.Enabled = false;
                    txtReader_WriteData.Enabled = true;
                    btn6C_Read.Text = "Stop";
                    bSingleFireRead = false;
                }

                //Start the read operation
                timer6C_PollRead.Enabled = true;
            }
            else
            {
                //Enable controls again
                cb6C_MemBank.Enabled = true;
                txt6C_AccessPwd.Enabled = true;
                txt6C_StartAddr.Enabled = true;
                txt6C_RWLen.Enabled = true;
                if (txtReader_WriteData.Text.Length != 0 &&
                    txtReader_WriteData.Text.Length % 4 == 0)
                    btn6C_Write.Enabled = true;

                timer6C_PollRead.Enabled = false;
                btn6C_Read.Text = "Read";
            }
        }

        private async void btnWrite_Click(object sender, EventArgs e)
        {
            //Do we have anything to write and is it in multiples of 4?
            if (txtReader_WriteData.Text == "" || txtReader_WriteData.TextLength % 4 != 0) return;

            //Do we need to disable filters?
            Task<bool> task_filter = Task.Run(() => WideOpenFilterCheck());
            await task_filter;
            if (task_filter.Result == false) return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => b6CReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            btn6C_Write.Enabled = false;

            byte membank = GetSelectedReadMemoryBank();
            uint accessPwd = Convert.ToUInt32(txt6C_AccessPwd.Text, 16);
            uint startAddr = Convert.ToUInt16(txt6C_StartAddr.Text, 16);
            byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(txtReader_WriteData.Text);

            //AddListBoxResponse($"btn6C_Write_Click -> Start");
            await FormSharedData.AttemptWrite_6C_Buffer(membank, accessPwd, startAddr, bWriteData);
            btn6C_Write.Enabled = true;
        }

        private async void btnQueryReaderFilter_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            FormSharedData.responseParser.ResetFlag("flag_cmd_get_access_epc_match");
            FormSharedData.readerClient.MsgBaseGetAccessEpcMatch();
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_get_access_epc_match"));
            await task;
        }

        private void txtWriteData_TextChanged(object sender, EventArgs e)
        {
            filterOnlyHex_TextChanged(sender, e);
            if (txtReader_WriteData.Text.Length > 0 &&
                txtReader_WriteData.Text.Length % 4 == 0)
            {
                btn6C_Write.Enabled = true;
                txt6C_RWLen.Text = (txtReader_WriteData.Text.Length / 4).ToString();
            }
            else
                btn6C_Write.Enabled = false;
        }

        private void lbRWResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lb6C_RWResults.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var item = lb6C_RWResults.Items[index];
                if (item != null)
                    Clipboard.SetText(item.ToString());
            }
        }

        private byte GetSelectedReadMemoryBank()
        {
            byte membank = 1;

            string? selBankText = cb6C_MemBank.SelectedItem.ToString();
            if (selBankText == null) return membank;

            if (selBankText == "RESERVED")
                membank = (byte)MemBank.RESERVED;
            else if (selBankText == "EPC")
                membank = (byte)MemBank.EPC;
            else if (selBankText == "TID")
                membank = (byte)MemBank.TID;
            else if (selBankText == "USER")
                membank = (byte)MemBank.USER;

            return membank;
        }

        private async void btnFindLength_Click(object sender, EventArgs e)
        {

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => b6CReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            btn6C_FindLength.Enabled = false;
            gbTagRW.Enabled = false;

            uint startWord = 0;
            txt6C_StartAddr.Text = "0";

            byte membank = GetSelectedReadMemoryBank();
            uint accessPwd = Convert.ToUInt32(txt6C_AccessPwd.Text, 16);
            uint confirmed = 0;     // words confirmed valid above startWord
            ushort chunkSize = 1;
            bool foundBoundary = false;
            int dbg_readCount = 0;

            // Phase 1: Exponential doubling — home in on the bank boundary quickly
            while (true)
            {
                // Drain: wait minCooldown so any late response from the previous command
                // arrives and sets the flag, then reset to clear it before sending the next command.
                await Task.Delay(FormSharedData.minCooldown);
                FormSharedData.responseParser.ResetFlag("flag_cmd_read");

                FormSharedData.readerClient.MsgBaseRead(membank, startWord + confirmed, chunkSize, accessPwd);
                Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_read"));
                await task;
                dbg_readCount++;

                if (task.Result == ErrorCode.OK && FormSharedData.responseParser.readerStatusCode == ErrorCode.OK)
                {
                    confirmed += chunkSize;
                    chunkSize = (ushort)Math.Min(chunkSize * 2, 256);
                }
                else if (task.Result == ErrorCode.OK && FormSharedData.responseParser.readerStatusCode == ErrorCode.PARAM_WORDCNT_TOO_LONG)
                {
                    foundBoundary = true;
                    break;
                }
                else
                {
                    break;
                }
            }

            // Phase 2: Binary search for the exact word count within the failed chunk
            int bsLo = 0;
            int bsHi = chunkSize - 1;

            if (foundBoundary)
            {
                while (bsLo < bsHi)
                {
                    int mid = (bsLo + bsHi + 1) / 2;

                    // Drain: same as Phase 1 — let any late previous response arrive, then reset.
                    await Task.Delay(FormSharedData.minCooldown);
                    FormSharedData.responseParser.ResetFlag("flag_cmd_read");

                    FormSharedData.readerClient.MsgBaseRead(membank, startWord + confirmed, (ushort)mid, accessPwd);
                    Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_read"));
                    await task;
                    dbg_readCount++;

                    if (task.Result == ErrorCode.OK && FormSharedData.responseParser.readerStatusCode == ErrorCode.OK)
                    {
                        bsLo = mid;
                    }
                    else if (task.Result == ErrorCode.OK && FormSharedData.responseParser.readerStatusCode == ErrorCode.PARAM_WORDCNT_TOO_LONG)
                    {
                        bsHi = mid - 1;
                    }
                    else if (task.Result == ErrorCode.OK)
                    {
                        bsHi = mid - 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            uint finalLength = startWord + confirmed + (uint)bsLo;
            txt6C_RWLen.Text = finalLength.ToString();

            gbTagRW.Enabled = true;
            btn6C_FindLength.Enabled = true;
        }

        private async void btnKillTag_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            if (txt6C_KillPwd.Text.Length != 8)
            {
                MessageBox.Show("Kill Password must be 8 hex chars!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            if (txt6C_KillPwd.Text == "00000000")
            {
                MessageBox.Show("Kill Password cannot be all zeroes", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }
            uint killPwd = Convert.ToUInt32(txt6C_KillPwd.Text, 16);

            //Do we need to disable filters?
            Task<bool> task_filter = Task.Run(() => WideOpenFilterCheck());
            await task_filter;
            if (task_filter.Result == false) return;

            FormSharedData.responseParser.ResetFlag("flag_cmd_kill");
            FormSharedData.readerClient.MsgBaseKill(killPwd);
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_kill"));
            await task;
        }

        private async void btnSetProtectState_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            //Do we need to disable filters?
            Task<bool> task_filter = Task.Run(() => WideOpenFilterCheck());
            await task_filter;
            if (task_filter.Result == false) return;

            //TODO more code
        }

        private async Task<bool> WideOpenFilterCheck()
        {
            if (FormSharedData.readerClient == null) return false;

            //Disable filters if required
            if (FormSharedData.Option_Disable_Write_MsgBaseSetAccessEpcMatch == true &&
                FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set == true)
            {
                Task<bool> task_bRet = Task.Run(() => FormSharedData.ClearEPCMatchFilter());
                await task_bRet;

                if (task_bRet.Result == false)
                    MessageBox.Show("Failed to clear MsgBaseSetAccessEpcMatch", "Write Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return task_bRet.Result;
            }
            return true;
        }

        private void P_Reserve_CheckedChanged(object sender, EventArgs e)
        {
            gbLockPassword.Enabled = true;
            gbLockTIDnUSER.Enabled = false;
        }

        private void P_TagLock_CheckedChanged(object sender, EventArgs e)
        {
            gbLockPassword.Enabled = false;
            gbLockTIDnUSER.Enabled = true;
        }

        private void cbDisable_Write_MsgBaseSetAccessEpcMatch_CheckedChanged(object sender, EventArgs e)
        {
            FormSharedData.Option_Disable_Write_MsgBaseSetAccessEpcMatch = cbDisable_Write_MsgBaseSetAccessEpcMatch.Checked;
        }
    }
}
