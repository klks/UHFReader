using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCchip.Reader.API;

namespace ES_F3105U
{
    partial class MainForm
    {
        DateTime dtLastInventoryRSSIUpdate = DateTime.Now;
        bool bIsInventoryRunning = false;
        bool bSingleFireRead = false;

        private void Init_6CUI()
        {
            cb6C_MemBank.SelectedIndex = 1;
        }

        private bool isTimer6C_ReadProcessing = false;
        private async void timer6C_PollRead_Tick(object sender, EventArgs e)
        {
            if (readerClient == null)
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

            AddListBoxResponse($"timer6C_PollRead -> Start");
            uint curReadIndex = 0;
            while(curReadIndex != readSize)   
            {
                ushort toReadSize = (ushort)Math.Min(readSize - curReadIndex, (ushort)20);   //Only do 20 words at a time

                DateTime dtStart = DateTime.Now;

                ReadWriteParsedData result = new ReadWriteParsedData();

                Task<bool> task = Task.Run(() => AttemptRead_6C(membank, startAddr + curReadIndex, toReadSize, accessPwd, result));
                await task;

                if (task.Result == true)
                {
                    if (readDataEPC == "" && result.StringEPC != null)
                        readDataEPC = result.StringEPC;

                    if (result.StringEPC != readDataEPC)
                        AddListBoxResponse($"timer6C_PollRead -> Incorrect EPC, expecting {readDataEPC} but got {result.StringEPC}");

                    totalReadData += result.StringData;  //Append
                }
                else
                {
                    AddListBoxResponse($"timer6C_PollRead -> Abandoning Loop");
                    break;
                }

                curReadIndex += toReadSize;

                //Internal cooldown
                TimeSpan td = DateTime.Now - dtStart;
                if (td.Milliseconds < minCooldown)
                {
                    Thread.Sleep(minCooldown - td.Milliseconds);
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
            AddListBoxResponse($"timer6C_PollRead -> End");
            isTimer6C_ReadProcessing = false;
        }

        private void timerInventory_Tick(object sender, EventArgs e)
        {
            if (readerClient == null)
            {
                timerInventory.Enabled = false;
                return;
            }

            if (!epcQueue.IsEmpty)
            {
                if (epcQueue.TryDequeue(out byte[] epcData))
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

        private async void btn6C_Inventory_Click(object sender, EventArgs e)
        {
           if (readerClient == null) return;

            btn6C_Inventory.Enabled = false;
            epcQueue.Clear();   //Flush the queue

            if (btn6C_Inventory.Text == "Inventory")
            {
                //Reset UI fields
                lvInventory.Items.Clear();
                txt6C_KillEPC.Text = "";
                txt6C_RWEPC.Text = "";
                txt6C_LockEPCTag.Text = "";

                flag_cmd_real_time_inventory.Value = false;
                readerClient.MsgStartInventory();
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_real_time_inventory));
                await task;

                if (task.Result == ErrorCode.OK)
                {
                    btn6C_Inventory.Text = "Stop";
                    timerInventory.Enabled = true;
                    bIsInventoryRunning = true;
                }
            }
            else
            {
                for (int i=0; i<5; i++)
                {
                    flag_cmd_stop_inventory.Value = false;
                    readerClient.MsgBaseStopInventory();
                    Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_stop_inventory, 1500));
                    await task;

                    if (task.Result == ErrorCode.OK)
                    {
                        timerInventory.Enabled = false;
                        btn6C_Inventory.Text = "Inventory";
                        bIsInventoryRunning = false;
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
            if (readerClient == null) return;

            if (bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lvInventory.Items.Count > 0)
            {
                string selEPC = lvInventory.SelectedItems[0].SubItems[2].Text;
                txt6C_KillEPC.Text = selEPC;
                txt6C_RWEPC.Text = selEPC;
                txt6C_LockEPCTag.Text = selEPC;

                byte[] bEPCArr = HexStringToByteArray(selEPC);

                flag_cmd_set_access_epc_match.Value = false;
                readerClient.MsgBaseSetAccessEpcMatch(0, (byte)bEPCArr.Length, bEPCArr);
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_set_access_epc_match));
                await task;

                if (task.Result == ErrorCode.OK)
                    isMsgBaseSetAccessEpcMatch_Set = true;
            }
        }

        private void btn6C_Clear_Click(object sender, EventArgs e)
        {
            lb6C_RWResults.Items.Clear();
        }

        private async Task<bool> b6CReadWriteSanityCheck()
        {
            if (readerClient == null) return false;

            if (bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Please check values for reading/writing", "RW Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int AccessPwdLen = 0;
            txt6C_AccessPwd.Invoke(new MethodInvoker(delegate { AccessPwdLen = txt6C_AccessPwd.TextLength; }));
            
            if (AccessPwdLen != 8)
            {
                MessageBox.Show("Access Password must be 8 hex chars!", "RW Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cbDisable_Write_MsgBaseSetAccessEpcMatch.Checked == false)
            {
                //Verify the filter in the reader against what we selected
                flag_cmd_get_access_epc_match.Value = false;
                readerClient.MsgBaseGetAccessEpcMatch();
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_access_epc_match));
                await task;

                if (task.Result == ErrorCode.Timeout)
                {
                    MessageBox.Show("Failed to validate EPC, try again!", "Match Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string strSelectedEPC = txt6C_RWEPC.Text;
                if (readerFilteredEPC == "" || strSelectedEPC == "")
                {
                    MessageBox.Show("Please select an EPC from the inventory again, empty EPC filtered", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                //Truncate to the length of the returned filter
                string m1 = strSelectedEPC;
                string m2 = readerFilteredEPC;

                if (m1.Length != m2.Length)
                {
                    int minLen = Math.Min(m1.Length, m2.Length);
                    m1 = m1.Substring(0, minLen);
                    m2 = m2.Substring(0, minLen);
                }

                if (m1 != m2)
                {
                    MessageBox.Show("Please select an EPC from the inventory again, EPC selected do not match", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }    
            

            return true;
        }
        private async void btn6C_Read_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;
            if (bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private async void btn6C_Write_Click(object sender, EventArgs e)
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
            byte[] bWriteData = HexStringToByteArray(txtReader_WriteData.Text);

            //AddListBoxResponse($"btn6C_Write_Click -> Start");
            await AttemptWrite_6C_Buffer(membank, accessPwd, startAddr, bWriteData);
            btn6C_Write.Enabled = true;
        }

        private async void btn6C_QueryReaderFilter_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            flag_cmd_get_access_epc_match.Value = false;
            readerClient.MsgBaseGetAccessEpcMatch();
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_access_epc_match));
            await task;
        }

        private void txtReader_WriteData_TextChanged(object sender, EventArgs e)
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

        private void lb6C_RWResults_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private async void btn6C_FindLength_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Length search can take some time, are you sure?", "Find Length Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => b6CReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            btn6C_FindLength.Enabled = false;
            gbTagRW.Enabled = false;

            uint iTotalWords = 0;
            if (MessageBox.Show("Start from beginning?", "Find Length Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                if (txt6C_RWLen.Text != null && txt6C_RWLen.TextLength > 0)
                {
                    iTotalWords = Convert.ToUInt16(txt6C_RWLen.Text);
                }
            }
            else
            {
                txt6C_StartAddr.Text = "0";
                txt6C_RWLen.Text = "1";
            }

            byte membank = GetSelectedReadMemoryBank();
            uint accessPwd = Convert.ToUInt32(txt6C_AccessPwd.Text, 16);            
            ushort readSize = 1;

            while(true)
            {
                DateTime dtStart = DateTime.Now;
                flag_cmd_read.Value = false;
                readerClient.MsgBaseRead(membank, iTotalWords, readSize, accessPwd);
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_read));
                await task;

                if (task.Result != ErrorCode.OK || readerStatusCode != (int)ErrorCode.OK) break;
                iTotalWords++;

                //Internal cooldown
                TimeSpan td = DateTime.Now - dtStart;
                if (td.Milliseconds < minCooldown)
                {
                    Thread.Sleep(minCooldown - td.Milliseconds);
                }
            }
            txt6C_RWLen.Text = iTotalWords.ToString();

            gbTagRW.Enabled = true;
            btn6C_FindLength.Enabled = true;
        }

        private async void btn6C_KillTag_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            if (txt6C_KillPwd.Text.Length != 8)
            {
                MessageBox.Show("Kill Password must be 8 hex chars!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt6C_KillPwd.Text == "00000000")
            {
                MessageBox.Show("Kill Password cannot be all zeroes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            uint killPwd = Convert.ToUInt32(txt6C_KillPwd.Text, 16);

            //Do we need to disable filters?
            Task<bool> task_filter = Task.Run(() => WideOpenFilterCheck());
            await task_filter;
            if (task_filter.Result == false) return;

            flag_cmd_kill.Value = false;
            readerClient.MsgBaseKill(killPwd);
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_kill));
            await task;
        }

        private async void Button_SetProtectState_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            //Do we need to disable filters?
            Task<bool> task_filter = Task.Run(() => WideOpenFilterCheck());
            await task_filter;
            if (task_filter.Result == false) return;

            //TODO more code
        }

        private async Task<bool> WideOpenFilterCheck()
        {
            if (readerClient == null) return false;

            //Disable filters if required
            if (cbDisable_Write_MsgBaseSetAccessEpcMatch.Checked == true && isMsgBaseSetAccessEpcMatch_Set == true)
            {
                //Clear any filters
                flag_cmd_set_access_epc_match.Value = false;
                readerClient.MsgBaseSetAccessEpcMatch(1, 0, []);
                Task<ErrorCode> task_clear = Task.Run(() => WaitForFlag(flag_cmd_set_access_epc_match));
                await task_clear;
                if (task_clear.Result == ErrorCode.OK)
                    isMsgBaseSetAccessEpcMatch_Set = false;
                else
                {
                    MessageBox.Show("Failed to clear MsgBaseSetAccessEpcMatch", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
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
    }
}
