using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCchip.Reader.API;
using Utilities;

namespace ES_F3105U
{
    public partial class Form_Duplicate : UserControl
    {
        public Form_Duplicate()
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

        public void ResetReadUI()
        {
            lblDup_ReadTID.Text = "(XXX Bits) (XXXX Words)";
            txtDup_Read_TID.Text = "";
            txtDup_Read_CRC.Text = "";
            txtDup_Read_PC.Text = "";
            txtDup_Read_EPC.Text = "";
            txtDup_Read_FullEPC.Text = "";
            txtDup_Read_UserData.Text = "";
            txtDup_Read_UserDataLen.Text = "";
            txtDup_Read_KillPwd.Text = "";
            txtDup_Read_AccessPwd.Text = "";
            txtDup_Read_FullEPCLen.Text = "";

            //Program Control Flags
            txtDup_EPCLength.Text = "";
            cbDup_UMI.Checked = false;
            cbDup_XPC.Checked = false;
            cbDup_EPCGA.Checked = false;
            txtDup_AFI.Text = "";

            //Short Tag Info
            chkDup_ReadXTID.Checked = false;
            chkDup_ReadAuthChlg.Checked = false;
            chkDup_ReadFileOpen.Checked = false;
            txtDup_ReadMDID.Text = "";
            txtDup_ReadTMN.Text = "";
            txtDup_Read_STI_Manu.Text = "";
            txtDup_Read_STI_Prod.Text = "";
        }

        private void DuplicateGroupEnabled(bool bEnable)
        {
            if (bEnable)
            {
                groupDuplicateUI.Enabled = true;
            }
            else
            {
                groupDuplicateUI.Enabled = false;
            }
        }

        private void btnDup_ReadClear_Click(object sender, EventArgs e)
        {
            ResetReadUI();
        }

        private void btnDup_WriteClear_Click(object sender, EventArgs e)
        {
            lblDup_WriteTID.Text = "(XXX Bits) (XXXX Words)";
            txtDup_Write_TID.Text = "";
            txtDup_Write_EPC.Text = "";
            txtDup_Write_FullEPC.Text = "";
            txtDup_Write_UserData.Text = "";
            txtDup_Write_KillPwd.Text = "";
            txtDup_Write_AccessPwd.Text = "";
        }

        private void btnDup_SaveReadData_Click(object sender, EventArgs e)
        {
            var card_data = new Utilities.CardJson
            {
                TID = txtDup_Read_TID.Text,
                EPC = txtDup_Read_EPC.Text,
                CRC = txtDup_Read_CRC.Text,
                PC = txtDup_Read_PC.Text,
                FullEPC = txtDup_Read_FullEPC.Text,
                UserData = txtDup_Read_UserData.Text,
                KillKey = txtDup_Read_KillPwd.Text,
                AccessKey = txtDup_Read_AccessPwd.Text,
                isCardAccessPWDLocked = (txtDup_Read_AccessPwd.Text == null || txtDup_Read_AccessPwd.Text == "") ? true : false,
                isCardKillPWDLocked = (txtDup_Read_KillPwd.Text == null || txtDup_Read_KillPwd.Text == "") ? true : false,
                isWavev2Card = false
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(card_data, options);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string save_name = saveFileDialog.FileName;
                File.WriteAllText(save_name, jsonString);
            }
        }

        private void txtDup_Read_TID_TextChanged(object sender, EventArgs e)
        {
            string tid = txtDup_Read_TID.Text;
            if (tid != null && tid != "")
            {
                string has_extra = "";
                int iTIDLen = tid.Length / 4;
                if ((tid.Length % 4) != 0)
                {
                    has_extra = "(Incomplete Words)";
                }

                lblDup_ReadTID.Text = String.Format("({0} Bits) ({1} Words) {2}", (iTIDLen * 2) * 8, iTIDLen, has_extra);
            }
        }
        private void btnDup_LoadReadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);

                    try
                    {
                        Utilities.CardJson card_data = JsonSerializer.Deserialize<Utilities.CardJson>(jsonString);
                        Utilities.CardInfo ci = Utilities.Utilities.CardJson_to_CardInfo(card_data);

                        ResetReadUI();
                        if (ci.FullEPC != null)
                        {
                            txtDup_Read_TID.Text = card_data.TID;
                            txtDup_Read_EPC.Text = card_data.EPC;
                            txtDup_Read_CRC.Text = card_data.CRC;
                            txtDup_Read_PC.Text = card_data.PC;
                            txtDup_Read_FullEPC.Text = card_data.FullEPC;
                            txtDup_Read_FullEPCLen.Text = ci.iFullEPCLen.ToString();
                            txtDup_Read_UserData.Text = card_data.UserData;
                            txtDup_Read_KillPwd.Text = card_data.KillKey;
                            txtDup_Read_AccessPwd.Text = card_data.AccessKey;
                            txtDup_Read_UserDataLen.Text = ci.iUserLen.ToString();
                            lblDup_ReadTID.Text = String.Format("({0} Bits) ({1} Words)", (ci.iTIDLen * 2) * 8, ci.iTIDLen);

                            string cardUserData = "";
                            if (ci.UserData != null && ci.UserData != "" && ci.UserData.Length > 8)
                            {
                                cardUserData = ci.UserData.Substring(0, 8);
                            }

                            //Copy of fields to the write tab
                            txtDup_Write_TID.Text = ci.TID;
                            txtDup_Write_EPC.Text = ci.EPC;
                            txtDup_Write_FullEPC.Text = txtDup_Read_FullEPC.Text;

                            //Only copy 8, this field can be large
                            int num2 = txtDup_Read_UserData.Text.Length;
                            if (num2 >= 8)
                            {
                                num2 = 8;
                            }
                            txtDup_Write_UserData.Text = txtDup_Read_UserData.Text.Substring(0, num2);
                            txtDup_Write_AccessPwd.Text = txtDup_Read_AccessPwd.Text;
                            txtDup_Write_KillPwd.Text = txtDup_Read_KillPwd.Text;

                            //Parse TID Short Tag Info
                            if (ci.TID != null)
                            {
                                uint uTIDShortTag = Convert.ToUInt32(ci.TID.Substring(0, 8), 16);
                                txtDup_ReadTMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                                txtDup_ReadMDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                                chkDup_ReadXTID.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                                chkDup_ReadAuthChlg.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                                chkDup_ReadFileOpen.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                                Utilities.Utilities.LoadICDB();
                                DigitsICDB? entry = Utilities.Utilities.GetShortTagExtendedInfo(txtDup_ReadMDID.Text, txtDup_ReadTMN.Text);
                                if (entry != null)
                                {
                                    txtDup_Read_STI_Manu.Text = entry.manufacturer;
                                    txtDup_Read_STI_Prod.Text = entry.modelName;
                                }
                                else
                                    txtDup_Read_STI_Manu.Text = Utilities.Utilities.GetShortTagMDIDName(txtDup_ReadMDID.Text);

                            }

                            //Populate Program Options panel
                            int iPCBits = Convert.ToUInt16(ci.PC, 16);
                            int iEPCLen = (iPCBits & 0xF800) >> 11;
                            txtDup_EPCLength.Text = iEPCLen.ToString();

                            cbDup_UMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                            cbDup_XPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                            cbDup_EPCGA.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                            txtDup_AFI.Text = (iPCBits & 0xFF).ToString("X2");
                        }
                    }
                    catch { }
                    ;
                }
            }
        }
        private async Task<bool> bDupReadWriteSanityCheck()
        {
            if (FormSharedData.readerClient == null) return false;

            if (FormSharedData.bIsInventoryRunning)
            {
                MessageBox.Show("Please stop inventory first before proceeding", "Inventory Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return false;
            }

            if (FormSharedData.Option_Disable_Write_MsgBaseSetAccessEpcMatch == true ||
                FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set == true)
            {
                Task<bool> task_bRet = Task.Run(() => FormSharedData.ClearEPCMatchFilter());
                await task_bRet;
                await Task.Delay(250);  //Slow down the next request
                return task_bRet.Result;
            }
            return true;
        }

        private async Task<string> GetFullDataString(byte membank)
        {
            uint accessPwd = 0;
            if (txtDup_Read_AccessPwd.Text != "")
                accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

            string strFullData = "";
            string latchEPC = "";
            uint readIndex = 0;
            ushort chunkSize = 1;

            // Phase 1: Exponential doubling — read in growing chunks to minimise round-trips
            // and home in on the bank boundary quickly (O(log n) reads).
            while (true)
            {
                // Drain: wait minCooldown so any late response from the previous command
                // arrives and sets the flag, then AttemptRead_6C's ResetFlag clears it.
                await Task.Delay(FormSharedData.minCooldown);

                ReadWriteParsedData result = new ReadWriteParsedData();
                Task<bool> task_read = Task.Run(() => FormSharedData.AttemptRead_6C(membank, readIndex, chunkSize, accessPwd, result));
                await task_read;

                if (task_read.Result == true)
                {
                    if (latchEPC == "" || FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set == false)
                    {
                        await Task.Delay(250);
                        latchEPC = result.StringEPC;

                        FormSharedData.responseParser.ResetFlag("flag_cmd_set_access_epc_match");
                        FormSharedData.readerClient.MsgBaseSetAccessEpcMatch(0, (byte)result.RawEPC.Length, result.RawEPC);
                        Task<ErrorCode> task_set = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_set_access_epc_match"));
                        await task_set;
                        if (task_set.Result == ErrorCode.OK)
                            FormSharedData.responseParser.isMsgBaseSetAccessEpcMatch_Set = true;
                        await Task.Delay(250);
                    }

                    if (latchEPC != result.StringEPC)
                    {
                        MessageBox.Show("Multiple tags were detected when trying to read, please make sure only 1 card is nearby", "Read Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return "";
                    }

                    strFullData += result.StringData;
                    readIndex += chunkSize;
                    chunkSize = (ushort)Math.Min(chunkSize * 2, 256);
                }
                else if (result.readerStatusCode == ErrorCode.PARAM_WORDCNT_TOO_LONG)
                {
                    break;  // Bank ends somewhere in [readIndex, readIndex + chunkSize - 1]
                }
                else
                {
                    if (result.readerStatusCode != ErrorCode.OK)
                    {
                        MessageBox.Show("Not all bytes were able to be read, check error code returned on the right", "Read Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                    return strFullData;
                }
            }

            // Phase 2: Binary search — find the exact number of readable words starting at
            // readIndex.  Invariant: answer ∈ [bsLo, bsHi].
            int bsLo = 0;
            int bsHi = chunkSize - 1;
            string bsLastData = "";

            while (bsLo < bsHi)
            {
                int mid = (bsLo + bsHi + 1) / 2;   // ceiling avoids infinite loop when bsLo + 1 == bsHi

                // Drain: same as Phase 1.
                await Task.Delay(FormSharedData.minCooldown);

                ReadWriteParsedData result = new ReadWriteParsedData();
                Task<bool> task_read = Task.Run(() => FormSharedData.AttemptRead_6C(membank, readIndex, (ushort)mid, accessPwd, result));
                await task_read;

                if (task_read.Result == true)
                {
                    if (latchEPC != "" && latchEPC != result.StringEPC)
                    {
                        MessageBox.Show("Multiple tags were detected when trying to read, please make sure only 1 card is nearby", "Read Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        return "";
                    }
                    bsLo = mid;
                    bsLastData = result.StringData;     // tracks the last full successful read
                }
                else if (result.readerStatusCode == ErrorCode.PARAM_WORDCNT_TOO_LONG)
                {
                    bsHi = mid - 1;
                }
                else
                {
                    if (result.readerStatusCode != ErrorCode.OK)
                    {
                        MessageBox.Show("Not all bytes were able to be read, check error code returned on the right", "Read Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                    return strFullData;
                }
            }

            if (bsLo > 0)
                strFullData += bsLastData;

            return strFullData;
        }

        private async void btnDup_ReadTID_Click(object sender, EventArgs e)
        {

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            txtDup_Read_TID.Text = "";
            txtDup_ReadTMN.Text = "";
            txtDup_ReadMDID.Text = "";
            chkDup_ReadXTID.Checked = false;
            chkDup_ReadAuthChlg.Checked = false;
            chkDup_ReadFileOpen.Checked = false;
            txtDup_Read_STI_Manu.Text = "";
            txtDup_Read_STI_Prod.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.TID));      //TID
            await task_data;

            if (task_data.Result != "")
            {
                string strTID = task_data.Result;
                txtDup_Read_TID.Text = strTID;
                txtDup_Write_TID.Text = strTID;

                //Figure out MDID and TMN
                if (strTID.Length > 8)
                {
                    uint uTIDShortTag = Convert.ToUInt32(strTID.Substring(0, 8), 16);
                    txtDup_ReadTMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                    txtDup_ReadMDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                    chkDup_ReadXTID.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                    chkDup_ReadAuthChlg.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                    chkDup_ReadFileOpen.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                    Utilities.Utilities.LoadICDB();
                    DigitsICDB? entry = Utilities.Utilities.GetShortTagExtendedInfo(txtDup_ReadMDID.Text, txtDup_ReadTMN.Text);
                    if (entry != null)
                    {
                        txtDup_Read_STI_Manu.Text = entry.manufacturer;
                        txtDup_Read_STI_Prod.Text = entry.modelName;
                    }
                    else
                        txtDup_Read_STI_Manu.Text = Utilities.Utilities.GetShortTagMDIDName(txtDup_ReadMDID.Text);
                }
            }

            Validate_All_Fields();
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ReadEPC_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            //Reset controls
            txtDup_Read_CRC.Text = "";
            txtDup_Read_PC.Text = "";
            txtDup_EPCLength.Text = "";
            cbDup_UMI.Checked = false;
            cbDup_XPC.Checked = false;
            cbDup_EPCGA.Checked = false;
            txtDup_AFI.Text = "";
            txtDup_Read_EPC.Text = "";
            txtDup_Read_FullEPC.Text = "";
            txtDup_Read_FullEPCLen.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.EPC));      //EPC
            await task_data;

            if (task_data.Result != "")
            {
                string strFullEPC = task_data.Result;
                if (strFullEPC.Length > 8)
                {
                    txtDup_Read_CRC.Text = strFullEPC.Substring(0, 4);  //CRC
                    string strPC = strFullEPC.Substring(4, 4);  //PC
                    txtDup_Read_PC.Text = strPC;

                    //Calculate EPC length from PC
                    int iPCBits = Convert.ToUInt16(strPC, 16);
                    int iEPCLen = (iPCBits & 0xF800) >> 11;
                    txtDup_EPCLength.Text = iEPCLen.ToString();

                    cbDup_UMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                    cbDup_XPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                    cbDup_EPCGA.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                    txtDup_AFI.Text = (iPCBits & 0xFF).ToString("X2");

                    if (strFullEPC.Length >= ((iEPCLen * 4) + 8))  //Bounds check incase its a partial read
                    {
                        txtDup_Read_EPC.Text = strFullEPC.Substring(8, iEPCLen * 4);
                        txtDup_Write_EPC.Text = txtDup_Read_EPC.Text;
                    }
                    else
                    {
                        txtDup_Read_EPC.Text = "";
                        txtDup_Write_EPC.Text = "";
                    }

                    txtDup_Read_FullEPC.Text = strFullEPC.Substring(4);
                    txtDup_Write_FullEPC.Text = txtDup_Read_FullEPC.Text;
                    txtDup_Read_FullEPCLen.Text = ((txtDup_Write_FullEPC.TextLength / 4) + 1).ToString();    //Add 1 for CRC that isnt included
                }
            }

            Validate_All_Fields();
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ReadUser_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);
            txtDup_Read_UserData.Text = "";


            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.USER));      //USER
            await task_data;

            if (task_data.Result != "")
            {
                string strUserData = task_data.Result;
                txtDup_Read_UserData.Text = strUserData;
                txtDup_Write_UserData.Text = strUserData;
                if (strUserData.Length != 0)
                    txtDup_Read_UserDataLen.Text = (strUserData.Length / 4).ToString();
            }

            Validate_All_Fields();
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ReadRFU_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            txtDup_Read_AccessPwd.Text = "";
            txtDup_Write_AccessPwd.Text = "";
            txtDup_Read_KillPwd.Text = "";
            txtDup_Write_KillPwd.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.RESERVED));      //RFU
            await task_data;

            if (task_data.Result != "")
            {
                string strReserved = task_data.Result;
                if (strReserved.Length >= 8)
                {
                    string killPwd = strReserved.Substring(0, 8);
                    txtDup_Read_KillPwd.Text = killPwd;
                    txtDup_Write_KillPwd.Text = killPwd;
                    if (strReserved.Length >= 16)
                    {
                        string accessPwd = strReserved.Substring(8, 8);
                        txtDup_Read_AccessPwd.Text = accessPwd;
                        txtDup_Write_AccessPwd.Text = accessPwd;
                    }
                }
            }

            Validate_All_Fields();
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_WriteTID_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to write TID data?", "Confirm...", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            string writeData = txtDup_Write_TID.Text;
            byte membank = (byte)MemBank.TID;

            if (writeData != null && writeData != "" && (writeData.Length % 4) == 0)
            {
                btnDup_WriteTID.Enabled = false;
                uint accessPwd = 0;
                byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(writeData);
                uint startAddr = 0;
                if (txtDup_Read_AccessPwd.Text != "")
                    accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

                await FormSharedData.AttemptWrite_6C_Buffer(membank, accessPwd, startAddr, bWriteData);
                btnDup_WriteTID.Enabled = true;
            }
        }

        private async void btnDup_WriteEPC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to write EPC data?", "Confirm...", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            string writeData = txtDup_Write_FullEPC.Text;
            byte membank = (byte)MemBank.EPC;

            if (writeData != null && writeData != "" && (writeData.Length % 4) == 0)
            {
                btnDup_WriteEPC.Enabled = false;
                uint accessPwd = 0;
                byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(writeData);
                uint startAddr = 1;     //Skip CRC field
                if (txtDup_Read_AccessPwd.Text != "")
                    accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

                await FormSharedData.AttemptWrite_6C_Buffer(membank, accessPwd, startAddr, bWriteData);
                btnDup_WriteEPC.Enabled = true;
            }
        }

        private async void btnDup_WriteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to write USER data?", "Confirm...", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            string writeData = txtDup_Write_UserData.Text;
            byte membank = (byte)MemBank.USER;

            if (writeData != null && writeData != "" && (writeData.Length % 4) == 0)
            {
                btnDup_WriteEPC.Enabled = false;
                uint accessPwd = 0;
                byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(writeData);
                uint startAddr = 0;
                if (txtDup_Read_AccessPwd.Text != "")
                    accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

                await FormSharedData.AttemptWrite_6C_Buffer(membank, accessPwd, startAddr, bWriteData);
                btnDup_WriteEPC.Enabled = true;
            }

        }

        private async void btnDup_WriteRFU_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to write RFU data?", "Confirm...", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            byte membank = (byte)MemBank.RESERVED;

            btnDup_WriteRFU.Enabled = false;

            string killPwd = txtDup_Write_KillPwd.Text;
            if (killPwd != null && killPwd != "")
            {
                if (killPwd.Length != 8)
                {
                    MessageBox.Show("Kill password must be 8 chars", "Length Mismatch",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                else
                {
                    uint w_accessPwd = 0;
                    byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(killPwd);
                    uint startAddr = 0;
                    if (txtDup_Read_AccessPwd.Text != "")
                        w_accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

                    await FormSharedData.AttemptWrite_6C_Buffer(membank, w_accessPwd, startAddr, bWriteData);
                }
            }

            string accessPwd = txtDup_Write_AccessPwd.Text;
            if (accessPwd != null && accessPwd != "")
            {
                if (accessPwd.Length != 8)
                {
                    MessageBox.Show("Access password must be 8 chars", "Length Mismatch",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                else
                {
                    uint w_accessPwd = 0;
                    byte[] bWriteData = Utilities.Utilities.HexStringToByteArray(accessPwd);
                    uint startAddr = 2;
                    if (txtDup_Read_AccessPwd.Text != "")
                        w_accessPwd = Convert.ToUInt32(txtDup_Read_AccessPwd.Text, 16);

                    await FormSharedData.AttemptWrite_6C_Buffer(membank, w_accessPwd, startAddr, bWriteData);
                }
            }

            btnDup_WriteRFU.Enabled = true;

        }

        private void btnDup_ValidateClear_Click(object sender, EventArgs e)
        {
            txtDup_Validate_TID.Text = "";
            txtDup_Validate_CRC.Text = "";
            txtDup_Validate_PC.Text = "";
            txtDup_Validate_FullEPC.Text = "";
            txtDup_Validate_UserData.Text = "";
            txtDup_Validate_KillPwd.Text = "";
            txtDup_Validate_AccessPwd.Text = "";

            txtDup_Validate_TID.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_CRC.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_PC.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_FullEPC.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_UserData.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_KillPwd.BackColor = System.Drawing.SystemColors.Control;
            txtDup_Validate_AccessPwd.BackColor = System.Drawing.SystemColors.Control;
        }

        private async void btnDup_ValidateTID_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);
            txtDup_Validate_TID.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.TID));      //TID
            await task_data;

            if (task_data.Result != "")
            {
                string strTID = task_data.Result;
                txtDup_Validate_TID.Text = strTID;
                Validate_All_Fields();
            }

            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ValidateEPC_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            txtDup_Validate_CRC.Text = "";
            txtDup_Validate_PC.Text = "";
            txtDup_Validate_FullEPC.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.EPC));      //EPC
            await task_data;

            if (task_data.Result != "")
            {
                string strFullEPC = task_data.Result;
                if (strFullEPC.Length > 8)
                {
                    string strCRC = strFullEPC.Substring(0, 4);  //CRC
                    txtDup_Validate_CRC.Text = strCRC;

                    string strPC = strFullEPC.Substring(4, 4);  //PC
                    txtDup_Validate_PC.Text = strPC;

                    strFullEPC = strFullEPC.Substring(4);
                    txtDup_Validate_FullEPC.Text = strFullEPC;

                    Validate_All_Fields();
                }
            }
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ValidateUser_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            txtDup_Validate_UserData.Text = "";
            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.USER));      //USER
            await task_data;

            if (task_data.Result != "")
            {
                string strUserData = task_data.Result;
                txtDup_Validate_UserData.Text = strUserData;
                Validate_All_Fields();
            }
            DuplicateGroupEnabled(true);
        }

        private async void btnDup_ValidateRFU_Click(object sender, EventArgs e)
        {
            //Do some sanity checking
            Task<bool> task_validate = Task.Run(() => bDupReadWriteSanityCheck());
            await task_validate;
            if (task_validate.Result == false) return;

            DuplicateGroupEnabled(false);

            txtDup_Validate_AccessPwd.Text = "";
            txtDup_Validate_KillPwd.Text = "";

            Task<string> task_data = Task.Run(() => GetFullDataString((byte)MemBank.RESERVED));      //RFU
            await task_data;

            if (task_data.Result != "")
            {
                string strReserved = task_data.Result;
                if (strReserved.Length >= 8)
                {
                    string killPwd = strReserved.Substring(0, 8);
                    txtDup_Validate_KillPwd.Text = killPwd;
                    if (strReserved.Length >= 16)
                    {
                        string accessPwd = strReserved.Substring(8, 8);
                        txtDup_Validate_AccessPwd.Text = accessPwd;
                    }
                    Validate_All_Fields();
                }
            }

            DuplicateGroupEnabled(true);
        }

        private void Validate_All_Fields()
        {
            //Validate TID
            if (txtDup_Validate_TID.Text != txtDup_Read_TID.Text)
                txtDup_Validate_TID.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_TID.BackColor = System.Drawing.SystemColors.Control;

            //Validate CRC
            if (txtDup_Validate_CRC.Text != txtDup_Read_CRC.Text)
                txtDup_Validate_CRC.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_CRC.BackColor = System.Drawing.SystemColors.Control;

            //Validate PC
            if (txtDup_Validate_PC.Text != txtDup_Read_PC.Text)
                txtDup_Validate_PC.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_PC.BackColor = System.Drawing.SystemColors.Control;

            //Validate FullEPC
            if (txtDup_Validate_FullEPC.Text != txtDup_Read_FullEPC.Text)
                txtDup_Validate_FullEPC.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_FullEPC.BackColor = System.Drawing.SystemColors.Control;

            //Validate USER data
            if (txtDup_Validate_UserData.Text != txtDup_Read_UserData.Text)
                txtDup_Validate_UserData.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_UserData.BackColor = System.Drawing.SystemColors.Control;

            //Validate Kill Password
            if (txtDup_Validate_KillPwd.Text != txtDup_Read_KillPwd.Text)
                txtDup_Validate_KillPwd.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_KillPwd.BackColor = System.Drawing.SystemColors.Control;

            //Validate Access Password
            if (txtDup_Validate_AccessPwd.Text != txtDup_Read_AccessPwd.Text)
                txtDup_Validate_AccessPwd.BackColor = System.Drawing.Color.Salmon;
            else
                txtDup_Validate_AccessPwd.BackColor = System.Drawing.SystemColors.Control;
        }
        private void txtDup_Write_UserData_TextChanged(object sender, EventArgs e)
        {
            filterOnlyHex_TextChanged(sender, e);

            string str_data = txtDup_Write_UserData.Text;
            if (str_data != null && str_data != "")
            {
                if ((str_data.Length % 4) == 0)
                {
                    btnDup_WriteUser.Enabled = true;
                }
                else
                {
                    btnDup_WriteUser.Enabled = false;
                }
            }
        }

        private void txtDup_Write_FullEPC_TextChanged(object sender, EventArgs e)
        {
            filterOnlyHex_TextChanged(sender, e);

            string str_data = txtDup_Write_FullEPC.Text;
            if (str_data != null && str_data != "")
            {
                if ((str_data.Length % 4) == 0)
                {
                    btnDup_WriteEPC.Enabled = true;
                }
                else
                {
                    btnDup_WriteEPC.Enabled = false;
                }
            }
        }

        private void txtDup_Write_TID_TextChanged(object sender, EventArgs e)
        {
            filterOnlyHex_TextChanged(sender, e);

            string tid = txtDup_Write_TID.Text;
            if (tid != null && tid != "")
            {
                string has_extra = "";
                int iTIDLen = tid.Length / 4;
                if ((tid.Length % 4) != 0)
                {
                    has_extra = "(Incomplete Words)";
                }

                lblDup_WriteTID.Text = String.Format("({0} Bits) ({1} Words) {2}", (iTIDLen * 2) * 8, iTIDLen, has_extra);

                if (has_extra == "" && iTIDLen != 0)
                    btnDup_WriteTID.Enabled = true;
                else
                    btnDup_WriteTID.Enabled = false;
            }
        }

        private async void btnEPCMatchQuery_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            FormSharedData.responseParser.ResetFlag("flag_cmd_get_access_epc_match");
            FormSharedData.readerClient.MsgBaseGetAccessEpcMatch();
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_get_access_epc_match"));
            await task;

            txtEPCMatchFilter.Text = FormSharedData.responseParser.readerFilteredEPC;
        }

        private async void btnEPCMatchClear_Click(object sender, EventArgs e)
        {
            if (FormSharedData.readerClient == null) return;

            Task<bool> task_bRet = Task.Run(() => FormSharedData.ClearEPCMatchFilter());
            await task_bRet;

            FormSharedData.responseParser.ResetFlag("flag_cmd_get_access_epc_match");
            FormSharedData.readerClient.MsgBaseGetAccessEpcMatch();
            Task<ErrorCode> task = Task.Run(() => FormSharedData.responseParser.WaitForFlag("flag_cmd_get_access_epc_match"));
            await task;

            txtEPCMatchFilter.Text = FormSharedData.responseParser.readerFilteredEPC;
        }
    }
}
