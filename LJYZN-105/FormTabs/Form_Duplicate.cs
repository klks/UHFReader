using Microsoft.VisualBasic.ApplicationServices;
using ReaderB;
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
using Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static Utilities.Utilities;

namespace LJYZN_105
{
    public partial class Form_Duplicate : UserControl
    {
        //Used for Wave v2 Code
        private string hassearchcard = "no";
        private string hasreadcard = "no";
        private string hasresearchcard = "no";
        private const string WaveV2Key = "E6FA3C97";

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

        private void txtDup_Write_TID_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
            string tid = txtDup_Write_TID.Text;
            if (!string.IsNullOrEmpty(tid))
            {
                string has_extra = "";
                int iTIDLen = tid.Length / 4;
                if ((tid.Length % 4) != 0)
                {
                    has_extra = "(Incomplete Words)";
                }

                lblDup_WriteTID.Text = String.Format("({0} Bits) ({1} Words) {2}", (iTIDLen * 2) * 8, iTIDLen, has_extra);
            }
        }

        private void btnDup_ReadCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (hassearchcard == "no")
            {
                MessageBox.Show("You must click Search Card button first and then click Stop Search button. Click this Read Card button again after that.", "Wrong Step");
                return;
            }
            if (!ValidateSingleCardSeen()) return;
            hasreadcard = "yes";
            ResetReadUI();  //Cleanup the UI

            if (FormSharedData.Form_6C.ComboBox_EPC2.Items.Count != 1)
            {
                return;
            }

            //Disable button to prevent multiple clicks
            btnDup_ReadCard.Enabled = false;

            CardInfo ci = QueryCardDetails(FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString() ?? "");

            txtDup_Read_EPC.Text = ci.EPC;
            txtDup_Read_CRC.Text = ci.EPC_CRC;
            txtDup_Read_FullEPC.Text = ci.FullEPC;
            txtDup_Read_FullEPCLen.Text = ci.iFullEPCLen.ToString();
            txtDup_Read_PC.Text = ci.PC;

            txtDup_Read_UserData.Text = ci.UserData;
            txtDup_Read_UserDataLen.Text = ci.iUserLen.ToString();

            if (ci.isWavev2Card)
                btnWavev2Flag.Visible = true;

            if (ci.hasLockedUserBlocks)
                btnHasLockedUserBlocks.Visible = true;

            txtDup_Read_AccessPwd.Text = ci.AccessPwd;
            txtDup_Read_KillPwd.Text = ci.KillPwd;
            hasresearchcard = "no";

            txtDup_Read_TID.Text = ci.TID;
            lblDup_ReadTID.Text = String.Format("({0} Bits) ({1} Words)", (ci.iTIDLen * 2) * 8, ci.iTIDLen);
            txtDup_Write_TID.Text = ci.TID;

            //Parse TID Short Tag Info
            if (ci.TID != null)
            {
                uint uTIDShortTag = Convert.ToUInt32(ci.TID.Substring(0, 8), 16);
                txtReadTMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                txtReadMDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                chkReadXTID.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                chkReadAuthChlg.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                chkReadFileOpen.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                LoadICDB();
                DigitsICDB entry = GetShortTagExtendedInfo(txtReadMDID.Text, txtReadTMN.Text);
                if (entry != null)
                {
                    txtDup_Read_STI_Manu.Text = entry.manufacturer;
                    txtDup_Read_STI_Prod.Text = entry.modelName;
                }
                else
                    txtDup_Read_STI_Manu.Text = GetShortTagMDIDName(txtReadMDID.Text);
            }

            //Set Final Flags
            if (ci.FullEPC != null)
            {
                //This is when we can successfully read the EPC
                waveFlagYellow.Visible = true;

                //These are for cards where the EPC length differ
                if (ci.EPC.Length <= 10 && ci.FullEPC.Length >= 24)
                {
                    waveFlagBlue.Visible = true;
                }

                string cardUserData = "";
                if (!string.IsNullOrEmpty(ci.UserData) && ci.UserData.Length > 8)
                {
                    cardUserData = ci.UserData.Substring(0, 8);
                }

                //This are for cards that contain user data
                if (!string.IsNullOrEmpty(cardUserData) && cardUserData != "00000000" && cardUserData != "0000")
                {
                    waveFlagGreen.Visible = true;
                }

                //These are cards that have a different password but arent locked yet
                if (!string.IsNullOrEmpty(ci.AccessPwd) && ci.AccessPwd != FormSharedData.strDefaultKey)
                {
                    waveFlagRed.Visible = true;
                }

                //These are cards locked with a different password
                if (!ci.isWavev2Card && ci.isCardAccessPWDLocked && string.IsNullOrEmpty(ci.AccessPwd))
                {
                    waveFlagPurple.Visible = true;
                }

                //This card has the AFI string set to it
                if (ci.FullEPC.Substring(2, 2) != "00")
                {
                    waveFlagBlack.Visible = true;
                }

                txtDup_Write_EPC.Text = ci.EPC;

                //For some reason, original dev only copies a certain length EPC
                //int num = carddataFullEPC.Text.Length;
                //if (num >= 28)
                //{
                //    num = 28;
                //}
                //towriteFullEPC.Text = carddataFullEPC.Text.Substring(0, num);
                txtDup_Write_FullEPC.Text = txtDup_Read_FullEPC.Text;

                //The original software only copied a fixed length
                int num2 = txtDup_Read_UserData.Text.Length;
                if (num2 >= 8)
                {
                    num2 = 8;
                }
                txtDup_Write_UserData.Text = txtDup_Read_UserData.Text.Substring(0, num2);
                txtDup_Write_AccessPwd.Text = txtDup_Read_AccessPwd.Text;

                //Populate Program Options panel
                int iPCBits = Convert.ToUInt16(ci.PC, 16);
                int iEPCLen = (iPCBits & 0xF800) >> 11;
                txtEPCLength.Text = iEPCLen.ToString();

                cbUMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                cbXPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                cbEPCGA.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                txtAFI.Text = (iPCBits & 0xFF).ToString("X2");

                FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Read card data successfully";
                MessageBox.Show("Card was read successfully", "Read success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDup_ReadCard.Enabled = true;
            }
            else
            {
                MessageBox.Show("Card read attempt failed. Maybe the card is far or moved away from reader. Try repositioning the card correctly on the reader and try again.", "Read failed");
                hasreadcard = "no";
            }
        }


        private void btnDup_WriteCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (hasreadcard == "no")
            {
                MessageBox.Show("You must Read Card first before attempting to Write Card", "Wrong Step");
                return;
            }
            if (hasresearchcard == "no")
            {
                MessageBox.Show("You must click Search Card button again and then click Stop Search button. Click this Write Card button again after that.", "Wrong Step");
                return;
            }
            if (!ValidateSingleCardSeen()) return;

            //Confirm

            if (MessageBox.Show("Confirm write to card?", "Write Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            btnDup_WriteCard.Enabled = false;

            string txtEPCString = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            byte iEPCLenBytes = Convert.ToByte(txtEPCString.Length / 2); ;
            byte iEPCLenWords = Convert.ToByte(txtEPCString.Length / 4);
            byte[] arrEPCHexBytes = HexStringToByteArray(txtEPCString);
            byte[] retArray = new byte[320];
            int writtenDataNum = 0;
            byte wordPtr = Convert.ToByte("02", 16);


            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);

            //Write EPC w/ Extended parts
            if (string.IsNullOrEmpty(txtDup_Write_FullEPC.Text))
            {
                MessageBox.Show("Write attempt failed. No flag found. Please try again, remember to do Search Card first.", "Write failed");
                btnDup_WriteCard.Enabled = true;
                return;
            }
            string txtJustEPC = txtDup_Write_FullEPC.Text.Substring(4, txtDup_Write_FullEPC.Text.Length - 4);
            byte[] arrJustEPC = HexStringToByteArray(txtJustEPC);
            wordPtr = Convert.ToByte("02", 16);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.EPC, wordPtr, (byte)arrJustEPC.Length,
                                                                    arrJustEPC, ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                    writtenDataNum, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet != 0)
            {
                if (MessageBox.Show("Failed to write Full EPC value. Keep going?", "Write failed", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    btnDup_WriteCard.Enabled = true;
                    return;
                }

            }

            //Write jsut EPC
            arrJustEPC = HexStringToByteArray(txtDup_Write_EPC.Text);
            {
                uint oldEpc = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteEPC_G2(ref FormSharedData.comAdr, ref oldEpc, arrJustEPC, (byte)arrJustEPC.Length,
                                                                    ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet != 0)
            {
                if (MessageBox.Show("Failed to write just EPC. Keep going?", "Write failed", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    btnDup_WriteCard.Enabled = true;
                    return;
                }

            }

            //Write user data
            if (!string.IsNullOrEmpty(txtDup_Write_UserData.Text))
            {
                byte[] userData = HexStringToByteArray(txtDup_Write_UserData.Text);
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("00", 16);

                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.User, wordPtr, (byte)userData.Length, userData,
                                                                        ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                        writtenDataNum, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet != 0)
                {
                    if (MessageBox.Show("Failed to write User Data. Keep going?", "Write failed", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        btnDup_WriteCard.Enabled = true;
                        return;
                    }
                }
            }

            int CardNum = 0;
            int Totallen = 0;
            byte[] array14 = new byte[5000];
            {
                uint cardNumUInt = 0;
                FormSharedData.cmdRet = (int)StaticClassReaderB.Inventory_G2(ref FormSharedData.comAdr, 0, 0, 0, array14, ref Totallen, ref cardNumUInt, FormSharedData.frmcomportindex);
                CardNum = (int)cardNumUInt;
            }
            if ((FormSharedData.cmdRet == 1) || (FormSharedData.cmdRet == 2) ||
                (FormSharedData.cmdRet == 3) || (FormSharedData.cmdRet == 4) ||
                (FormSharedData.cmdRet == 251))
            {
                byte[] array15 = new byte[Totallen];
                Array.Copy(array14, array15, Totallen);
                string text10 = ByteArrayToHexString(array15);
                int num = 0;
                if (CardNum == 0)
                {
                    MessageBox.Show("Write failed. Card is lost during communication. Try again the whole process.", "Write failed");
                    btnDup_WriteCard.Enabled = true;
                    return;
                }
                for (int i = 0; i < CardNum; i++)
                {
                    int num2 = array15[num];
                    string text9 = text10.Substring(num * 2 + 2, num2 * 2);
                    num = num + num2 + 1;
                    if (text9.Length != num2 * 2)
                    {
                        MessageBox.Show("Write failed. Card is hiding during communication. Try again the whole process.", "Write failed");
                        btnDup_WriteCard.Enabled = true;
                        return;
                    }
                }
            }

            if (waveFlagBlack.Visible || txtDup_Write_FullEPC.Text.Substring(2, 2) != "00")
            {
                string strBlackFlagString = "30" + txtDup_Write_FullEPC.Text.Substring(2, 2);
                byte blackDataLen = Convert.ToByte(strBlackFlagString.Length / 2);
                byte[] arrBlackFlagData = new byte[blackDataLen];
                arrBlackFlagData = HexStringToByteArray(strBlackFlagString);

                wordPtr = Convert.ToByte("01", 16);
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.EPC, wordPtr, blackDataLen, arrBlackFlagData,
                                                                        ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                        writtenDataNum, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet != 0)
                {
                    if (MessageBox.Show("Failed to write AFI. Keep going?", "Write failed", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        btnDup_WriteCard.Enabled = true;
                        return;
                    }
                }
            }
            MessageBox.Show("Card was written successfully", "Write success");
            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Wrote card data successfully";
            btnDup_WriteCard.Enabled = true;
        }


        private void btnDup_ValidateCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            btnDup_ValidateCard.Enabled = false;

            int CardNum = 0;
            int Totallen = 0;
            byte[] array = new byte[5000];
            string txtEPCString = "";
            {
                uint cardNumUInt = 0;
                FormSharedData.cmdRet = (int)StaticClassReaderB.Inventory_G2(ref FormSharedData.comAdr, 0, 0, 0, array, ref Totallen, ref cardNumUInt, FormSharedData.frmcomportindex);
                CardNum = (int)cardNumUInt;
            }
            if ((FormSharedData.cmdRet == 1) || (FormSharedData.cmdRet == 2) ||
                (FormSharedData.cmdRet == 3) || (FormSharedData.cmdRet == 4) ||
                (FormSharedData.cmdRet == 251))
            {
                byte[] array2 = new byte[Totallen];
                Array.Copy(array, array2, Totallen);
                string text2 = ByteArrayToHexString(array2);
                int num = 0;
                if (CardNum == 0)
                {
                    MessageBox.Show("Validation failed. Card is lost during communication. Try again the whole process.", "Validation failed");
                    btnDup_ValidateCard.Enabled = true;
                    return;
                }
                for (int i = 0; i < CardNum; i++)
                {
                    int num2 = array2[num];
                    txtEPCString = text2.Substring(num * 2 + 2, num2 * 2);
                    num = num + num2 + 1;
                    if (txtEPCString.Length != num2 * 2)
                    {
                        MessageBox.Show("Validation failed. Card is hiding during communication. Try again the whole process.", "Validation failed");
                        btnDup_ValidateCard.Enabled = true;
                        return;
                    }
                }
            }

            //Clear all fields
            txtDup_Validate_FullEPC.Text = "";
            txtDup_Validate_UserData.Text = "";
            txtDup_Validate_AccessPwd.Text = "";
            txtDup_Validate_CRC.Text = "";
            txtDup_Validate_PC.Text = "";
            txtDup_Validate_EPC.Text = "";
            lblDup_ValidateTID.Text = "";
            txtDup_Validate_AccessPwd.Text = "";
            txtDup_Validate_UserDataLen.Text = "";

            if (FormSharedData.Form_6C.ComboBox_EPC2.Items.Count != 1)
            {
                return;
            }

            CardInfo ci = QueryCardDetails(txtEPCString);

            //Set fields
            lblDup_ValidateTID.Text = String.Format("({0} Bits) ({1} Words)", (ci.iTIDLen * 2) * 8, ci.iTIDLen);
            txtDup_Validate_TID.Text = ci.TID;
            txtDup_Validate_CRC.Text = ci.EPC_CRC;
            txtDup_Validate_PC.Text = ci.PC;
            txtDup_Validate_EPC.Text = ci.EPC;
            txtDup_Validate_FullEPC.Text = ci.FullEPC;
            txtDup_Validate_UserData.Text = ci.UserData;
            txtDup_Validate_UserDataLen.Text = ci.iUserLen.ToString();
            txtDup_Validate_AccessPwd.Text = ci.AccessPwd;

            hasresearchcard = "no";
            if (!string.IsNullOrEmpty(ci.FullEPC))
            {
                try
                {
                    if (waveFlagYellow.Visible && txtDup_Write_EPC.Text != txtDup_Validate_EPC.Text.Substring(0, txtDup_Write_EPC.Text.Length))
                    {
                        MessageBox.Show("Failed to validate this card. EPC does not match", "Validation failed");
                    }
                    else if (waveFlagBlue.Visible && txtDup_Write_FullEPC.Text.Length >= 8 && txtDup_Validate_FullEPC.Text.Length >= 8 &&
                             txtDup_Write_FullEPC.Text.Substring(8, txtDup_Write_FullEPC.Text.Length - 8) != txtDup_Validate_FullEPC.Text.Substring(8, txtDup_Write_FullEPC.Text.Length - 8))
                    {
                        MessageBox.Show("Failed to validate this card. Blue Flag error. Try to write the card again. Start the process again for clean start.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (waveFlagGreen.Visible && txtDup_Write_UserData.Text != txtDup_Validate_UserData.Text.Substring(0, txtDup_Write_UserData.Text.Length))
                    {
                        MessageBox.Show("Failed to validate this card. User Data does not match. Try to write the card again. Start the process again for clean start.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (waveFlagBlack.Visible && txtDup_Write_FullEPC.Text.Substring(6, 2) != txtDup_Validate_FullEPC.Text.Substring(6, 2))
                    {
                        MessageBox.Show("Failed to validate this card. AFI code does not match", "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (waveFlagRed.Visible)
                        {
                            if (txtDup_Write_AccessPwd.Text == txtDup_Validate_AccessPwd.Text)
                            {
                                MessageBox.Show("Card was Validated successfully INCLUDING Access Password", "Validation success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Card was Validated successfully but WITHOUT Access Password", "Validation success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Card was validated successfully", "Validation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Validated card data successfully";
                        }
                        if (txtDup_Write_FullEPC.Text.Substring(0, 6) != txtDup_Validate_FullEPC.Text.Substring(0, 6))
                        {
                            MessageBox.Show("WARNING: Not all fields were successfully copied over\n\nSave the cards and use the Compare Cards function to see where the mismatch is at", "Cards are not identical");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Card failed validation, one of the fields did not copy over.\nCheck if card types are similar.", "Validation failed");
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Validated card data failed";
                }
            }
            else
            {
                MessageBox.Show("Card validate attempt failed. Maybe the card is far or moved away from reader. Try repositioning the card correctly on the reader and try again.", "Validation failed");
                hasreadcard = "no";
            }
            btnDup_ValidateCard.Enabled = true;
        }


        private void btnCreateWaveCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            if (MessageBox.Show("Are you sure you want to create a Wave v2 card?", "Confirm?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                btnDup_CreateWaveCard.Enabled = true;
                return;
            }

            btnDup_CreateWaveCard.Enabled = false;
            string strEPC = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();

            //Check if this is already a wave card
            if (isWavev2Card(strEPC))
            {
                MessageBox.Show("This is already a wave card!", "Create Failed");
                btnDup_CreateWaveCard.Enabled = true;
                return;
            }

            //Check if card is locked
            if (!isAccessKeyCorrect(strEPC, FormSharedData.strDefaultKey))
            {
                MessageBox.Show("Failed to access card with default key!", "Create Failed");
                btnDup_CreateWaveCard.Enabled = true;
                return;
            }

            //Set wave flags
            //Set Mask
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            byte[] arrEPCHexBytes = HexStringToByteArray(strEPC);
            byte iEPCLenBytes = Convert.ToByte(strEPC.Length / 2);
            byte[] arrTemp;

            //Write the wave key
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);
            arrTemp = HexStringToByteArray(WaveV2Key); //Set wave key
            byte wordPtr = 2;
            byte writeLen = 4;
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, writeLen, arrTemp,
                                                                    ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, 0,
                                                                    iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }

            //Set protection (Readable and writeable from the secured state)
            FormSharedData.fPassWord = HexStringToByteArray(WaveV2Key); //Set wave key
            byte select = 1;
            byte setprotect = 2;
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetCardProtect_G2(ref FormSharedData.comAdr, arrEPCHexBytes, select, setprotect, ref pwd,
                                                                        FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, iEPCLenBytes,
                                                                        ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }

            MessageBox.Show("This card will now identify as a Wave v2 Card", "Create Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Wave create success!";

            btnDup_CreateWaveCard.Enabled = true;
        }


        private void btnResetWaveCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            if (MessageBox.Show("Are you sure you want to reset this Wave card?", "Confirm?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            btnDup_ResetWaveCard.Enabled = false;
            string strWaveEPC = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();

            //Check if card has an access key
            if (isWavev2Card(strWaveEPC))
            {
                //Set Mask
                FormSharedData.MaskFlag = 0;
                FormSharedData.Maskadr = Convert.ToByte("00", 16);
                FormSharedData.MaskLen = Convert.ToByte("00", 16);

                byte[] arrEPCHexBytes = HexStringToByteArray(strWaveEPC);
                byte iEPCLenBytes = Convert.ToByte(strWaveEPC.Length / 2);
                byte[] arrTemp;

                //Set No protection (Readable and  writeable from any state)
                FormSharedData.fPassWord = HexStringToByteArray(WaveV2Key); //Set wave key
                byte select = 1;
                byte setprotect = 0;
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.SetCardProtect_G2(ref FormSharedData.comAdr, arrEPCHexBytes, select, setprotect, ref pwd,
                                                                            FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, iEPCLenBytes,
                                                                            ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }

                //Reset access key to 00000000
                FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey); //Set wave key
                arrTemp = HexStringToByteArray(FormSharedData.strDefaultKey);
                byte wordPtr = 2;
                byte writeLen = 4;
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, writeLen, arrTemp,
                                                                        ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                        0, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet == 0)
                {
                    MessageBox.Show("This card has been reset to an original state\nThe Wave v2 key has been removed", "Reset Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Wave v2 card reset success!";
                }
            }
            else
            {
                MessageBox.Show("This is either not a wave card or you need to re-run the search again", "Reset Failed");
            }
            btnDup_ResetWaveCard.Enabled = true;
        }

        private void btnSaveReadData_Click(object sender, EventArgs e)
        {
            var card_data = new CardJson
            {
                TID = txtDup_Read_TID.Text,
                EPC = txtDup_Read_EPC.Text,
                CRC = txtDup_Read_CRC.Text,
                PC = txtDup_Read_PC.Text,
                FullEPC = txtDup_Read_FullEPC.Text,
                UserData = txtDup_Read_UserData.Text,
                KillKey = txtDup_Read_KillPwd.Text,
                AccessKey = txtDup_Read_AccessPwd.Text,
                isCardAccessPWDLocked = string.IsNullOrEmpty(txtDup_Read_AccessPwd.Text),
                isCardKillPWDLocked = string.IsNullOrEmpty(txtDup_Read_KillPwd.Text),
                isWavev2Card = btnWavev2Flag.Visible == true ? true : false
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

        private void btnLoadReadData_Click(object sender, EventArgs e)
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
                        CardJson card_data = JsonSerializer.Deserialize<CardJson>(jsonString);
                        CardInfo ci = CardJson_to_CardInfo(card_data);

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

                            //This is when we can successfully read the EPC
                            waveFlagYellow.Visible = true;

                            if (ci.isWavev2Card == true)
                            {
                                btnWavev2Flag.Visible = true;
                            }
                            //These are for cards where the EPC length differ
                            if (ci.EPC.Length <= 10 && ci.FullEPC.Length >= 24)
                            {
                                waveFlagBlue.Visible = true;
                            }

                            string cardUserData = "";
                            if (!string.IsNullOrEmpty(ci.UserData) && ci.UserData.Length > 8)
                            {
                                cardUserData = ci.UserData.Substring(0, 8);
                            }

                            //This are for cards that contain user data
                            if (!string.IsNullOrEmpty(cardUserData) && cardUserData != "00000000" && cardUserData != "0000")
                            {
                                waveFlagGreen.Visible = true;
                            }

                            //These are cards that have a different password but arent locked yet
                            if (!string.IsNullOrEmpty(ci.AccessPwd) && ci.AccessPwd != FormSharedData.strDefaultKey)
                            {
                                waveFlagRed.Visible = true;
                            }

                            //These are cards locked with a different password
                            if (!ci.isWavev2Card && ci.isCardAccessPWDLocked && string.IsNullOrEmpty(ci.AccessPwd))
                            {
                                waveFlagPurple.Visible = true;
                            }

                            //Card likely has some PC bits set
                            if (ci.FullEPC.Substring(2, 2) != "00")
                            {
                                waveFlagBlack.Visible = true;
                            }

                            txtDup_Write_TID.Text = ci.TID;
                            txtDup_Write_EPC.Text = ci.EPC;

                            //For some reason, original dev only copies a certain length EPC
                            //int num = carddataFullEPC.Text.Length;
                            //if (num >= 28)
                            //{
                            //    num = 28;
                            //}
                            //towriteFullEPC.Text = carddataFullEPC.Text.Substring(0, num);
                            txtDup_Write_FullEPC.Text = txtDup_Read_FullEPC.Text;

                            //The original software only copied a fixed length
                            int num2 = txtDup_Read_UserData.Text.Length;
                            if (num2 >= 8)
                            {
                                num2 = 8;
                            }
                            txtDup_Write_UserData.Text = txtDup_Read_UserData.Text.Substring(0, num2);
                            txtDup_Write_AccessPwd.Text = txtDup_Read_AccessPwd.Text;

                            //Parse TID Short Tag Info
                            if (ci.TID != null)
                            {
                                uint uTIDShortTag = Convert.ToUInt32(ci.TID.Substring(0, 8), 16);
                                txtReadTMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                                txtReadMDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                                chkReadXTID.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                                chkReadAuthChlg.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                                chkReadFileOpen.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                                LoadICDB();
                                DigitsICDB entry = GetShortTagExtendedInfo(txtReadMDID.Text, txtReadTMN.Text);
                                if (entry != null)
                                {
                                    txtDup_Read_STI_Manu.Text = entry.manufacturer;
                                    txtDup_Read_STI_Prod.Text = entry.modelName;
                                }
                            }

                            //Populate Program Options panel
                            int iPCBits = Convert.ToUInt16(ci.PC, 16);
                            int iEPCLen = (iPCBits & 0xF800) >> 11;
                            txtEPCLength.Text = iEPCLen.ToString();

                            cbUMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                            cbXPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                            cbEPCGA.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                            txtAFI.Text = (iPCBits & 0xFF).ToString("X2");

                            hasreadcard = "yes";

                            FormSharedData.tss_Status.Text = DateTime.Now.ToLongTimeString() + " Loaded card data successfully";
                            MessageBox.Show("Card was read successfully loaded", "Load success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnDup_ReadCard.Enabled = true;
                        }
                    }
                    catch { }
                    ;
                }
            }
        }


        private void btnDup_WriteTID_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            //Confirm
            if (MessageBox.Show("Confirm write TID to card?", "Write TID Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            btnDup_WriteTID.Enabled = false;

            string txtEPCString = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            byte iEPCLenBytes = Convert.ToByte(txtEPCString.Length / 2); ;
            byte iEPCLenWords = Convert.ToByte(txtEPCString.Length / 4);
            byte[] arrEPCHexBytes = HexStringToByteArray(txtEPCString);
            int writtenDataNum = 0;

            //fPassWord = HexStringToByteArray(strDefaultKey);
            FormSharedData.fPassWord = HexStringToByteArray(txtDup_Write_TID_PWD.Text);

            byte[] tidData = HexStringToByteArray(txtDup_Write_TID.Text);
            byte wordPtr = Convert.ToByte("00", 16);

            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.WriteCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.TID, wordPtr, (byte)tidData.Length, tidData,
                                                                    ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                    writtenDataNum, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet != 0 || FormSharedData.ferrorcode != -1)
            {
                FormSharedData.MainForm.AddCmdLog("TID Write", "TID Write Failed", FormSharedData.cmdRet, FormSharedData.ferrorcode);
                MessageBox.Show("TID Write failed.", "Write failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("TID Write Success!", "Write success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnDup_WriteTID.Enabled = true;
        }

        private void btnDup_MonzaQTQuery_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            btnDup_MonzaQTQuery.Enabled = false;
            //Set Mask
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            //Set default password
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);

            string strSearchEPC = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(strSearchEPC))
            {
                byte[] arrEPCHexBytes = HexStringToByteArray(strSearchEPC);
                byte iEPCLenBytes = Convert.ToByte(strSearchEPC.Length / 2);

                uint qtPwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint qtErrCode = uint.MaxValue;
                byte[] paramOut = new byte[4];
                FormSharedData.cmdRet = (int)StaticClassReaderB.GetMonza4QTWorkParamter_G2(ref FormSharedData.comAdr, arrEPCHexBytes, iEPCLenBytes, ref qtPwd,
                                                                                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, paramOut,
                                                                                    ref qtErrCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = qtErrCode == uint.MaxValue ? -1 : (int)qtErrCode;
                byte QTControl = paramOut[0];
                if (FormSharedData.cmdRet == 0 && FormSharedData.ferrorcode == -1)
                {
                    if ((QTControl & (byte)MonzaQT.PAGE_PUBLIC) == (byte)MonzaQT.PAGE_PUBLIC)
                        cbDup_MonzaQT_Profile.SelectedIndex = 1;
                    else
                        cbDup_MonzaQT_Profile.SelectedIndex = 0;

                    if ((QTControl & (byte)MonzaQT.RANGE_REDUCE) == (byte)MonzaQT.RANGE_REDUCE)
                        cbDup_MonzaQT_Distance.SelectedIndex = 1;
                    else
                        cbDup_MonzaQT_Distance.SelectedIndex = 0;

                    //StaticClassReaderB.SetMonza4QTWorkParamter_G2(ref comAdr, arrEPCHexBytes, iEPCLenBytes, fPassWord, Maskadr, MaskLen, MaskFlag, QTControl, ref ferrorcode, frmcomportindex);
                }
                else
                    FormSharedData.MainForm.AddCmdLog("MonzaQT Query Failed", "MonzaQT Command failed", FormSharedData.cmdRet, FormSharedData.ferrorcode);
            }

            btnDup_MonzaQTQuery.Enabled = true;
        }

        private void btnDup_MonzaQTWrite_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReady()) return;

            if (!ValidateSingleCardSeen()) return;
            //Confirm
            if (MessageBox.Show("Confirm write QT to card?\nThis could lock you out.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            btnDup_MonzaQTWrite.Enabled = false;
            //Set Mask
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            //Set default password
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);

            string strSearchEPC = FormSharedData.Form_6C.ComboBox_EPC2.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(strSearchEPC))
            {
                byte[] arrEPCHexBytes = HexStringToByteArray(strSearchEPC);
                byte iEPCLenBytes = Convert.ToByte(strSearchEPC.Length / 2);

                byte QTControl = 0;

                if (cbDup_MonzaQT_Profile.SelectedIndex == 1)
                    QTControl |= (byte)MonzaQT.PAGE_PUBLIC;

                if (cbDup_MonzaQT_Distance.SelectedIndex == 1)
                    QTControl |= (byte)MonzaQT.RANGE_REDUCE;

                uint qtPwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint qtErrCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.SetMonza4QTWorkParamter_G2(ref FormSharedData.comAdr, arrEPCHexBytes, iEPCLenBytes, ref qtPwd,
                                                                                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, QTControl,
                                                                                    ref qtErrCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = qtErrCode == uint.MaxValue ? -1 : (int)qtErrCode;
                if (FormSharedData.cmdRet == 0 && FormSharedData.ferrorcode == -1)
                    FormSharedData.MainForm.AddCmdLog("MonzaQT Write Success", "MonzaQT command successful", FormSharedData.cmdRet);
                else
                    FormSharedData.MainForm.AddCmdLog("MonzaQT Write Failed", "MonzaQT command failed", FormSharedData.cmdRet, FormSharedData.ferrorcode);
            }

            btnDup_MonzaQTWrite.Enabled = true;
        }
        private void btnWaveSearchCard_Click(object sender, EventArgs e)
        {
            if (!FormSharedData.IsReadyForInventory6C()) return;

            hassearchcard = "yes";
            if (hasreadcard == "yes")
            {
                hasresearchcard = "yes";
            }
            btnDup_ReadCard.Enabled = false;
            btnDup_WriteCard.Enabled = false;
            btnDup_ValidateCard.Enabled = false;
            if (FormSharedData.Form_6C.CheckBox_TID.Checked && (FormSharedData.Form_6C.textBox4.Text.Length != 2 || FormSharedData.Form_6C.textBox5.Text.Length != 2))
            {
                FormSharedData.tss_Status.Text = "TID query parameter error!";
                return;
            }
            FormSharedData.Form_6C.Timer_Test_.Enabled = !FormSharedData.Form_6C.Timer_Test_.Enabled;
            if (!FormSharedData.Form_6C.Timer_Test_.Enabled)
            {
                FormSharedData.bIsInventoryRunning_6C = false;
                
                btnDup_SearchCard.Text = "Search Card";
                btnDup_ReadCard.Enabled = true;
                btnDup_WriteCard.Enabled = true;
                btnDup_ValidateCard.Enabled = true;
            }
            else
            {
                FormSharedData.bIsInventoryRunning_6C = true;

                FormSharedData.Form_6C.ListView1_EPC.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC1.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC2.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC3.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC4.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC5.Items.Clear();
                FormSharedData.Form_6C.ComboBox_EPC6.Items.Clear();

                btnDup_SearchCard.Text = "Stop Search";
            }
        }
        private bool ValidateSingleCardSeen()
        {
            if (FormSharedData.Form_6C.ComboBox_EPC2.Items.Count == 0)
            {
                MessageBox.Show("No card found in Search. Please put a card on the reader and do Search Card again.", "Write Failed");
                return false;
            }
            if (FormSharedData.Form_6C.ComboBox_EPC2.Items.Count > 1)
            {
                MessageBox.Show("Multiple cards detected nearby reader. Please clear area from other cards and then do Search Card again.", "Write Failed");
                return false;
            }
            return true;
        }
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

            //Card Flags
            waveFlagYellow.Visible = false;
            waveFlagBlue.Visible = false;
            waveFlagGreen.Visible = false;
            waveFlagPurple.Visible = false;
            waveFlagBlack.Visible = false;
            waveFlagRed.Visible = false;
            btnWavev2Flag.Visible = false;
            btnHasLockedUserBlocks.Visible = false;

            //Program Control Flags
            txtEPCLength.Text = "";
            cbUMI.Checked = false;
            cbXPC.Checked = false;
            cbEPCGA.Checked = false;
            txtAFI.Text = "";

            //Short Tag Info
            chkReadXTID.Checked = false;
            chkReadAuthChlg.Checked = false;
            chkReadFileOpen.Checked = false;
            txtReadMDID.Text = "";
            txtReadTMN.Text = "";
            txtDup_Read_STI_Manu.Text = "";
            txtDup_Read_STI_Prod.Text = "";
        }
        public bool isAccessKeyCorrect(string? strSearchEPC, string strCardKey)
        {
            if (string.IsNullOrEmpty(strSearchEPC))
                return false;

            //Set Mask
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            byte[] arrEPCHexBytes = HexStringToByteArray(strSearchEPC);
            byte iEPCLenBytes = Convert.ToByte(strSearchEPC.Length / 2);
            byte readSize = 2;
            byte[] retArray = new byte[320];
            byte wordPtr = Convert.ToByte("02", 16);
            byte[] arrTemp;

            FormSharedData.fPassWord = HexStringToByteArray(strCardKey); //Set wave key
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize,
                                                                    ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                    retArray, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet == 0)
            {
                arrTemp = new byte[readSize * 2];
                Array.Copy(retArray, arrTemp, readSize * 2);
                if (ByteArrayToHexString(arrTemp) == strCardKey)
                {
                    return true;
                }
            }

            return false;
        }
        public bool isWavev2Card(string? strSearchEPC)
        {
            return isAccessKeyCorrect(strSearchEPC, WaveV2Key);
        }
        public CardInfo QueryCardDetails(string strSearchEPC)
        {
            CardInfo ci = new CardInfo();

            //Set Mask
            FormSharedData.MaskFlag = 0;
            FormSharedData.Maskadr = Convert.ToByte("00", 16);
            FormSharedData.MaskLen = Convert.ToByte("00", 16);

            //Set default password
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);

            //Get the EPC queried by the tool
            ci.EPC = strSearchEPC;
            ci.iEPCLen = ci.EPC.Length / 4;

            //Do some calculations to use for later
            byte iEPCLenBytes = Convert.ToByte(ci.EPC.Length / 2);
            byte iEPCLenWords = Convert.ToByte(ci.EPC.Length / 4);
            byte[] arrEPCHexBytes = HexStringToByteArray(ci.EPC);
            byte[] retArray = new byte[320];
            byte readSize = 0;
            byte[] arrTemp;
            byte wordPtr = 0;
            int i;

            //Read the CRC, PC, EPC, and FullEPC
            FormSharedData.ferrorcode = -1;
            i = 3;
            int ctrBadRead = 0;

            while (FormSharedData.ferrorcode == -1)
            {
                readSize = (byte)i;
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("00", 16);
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.EPC, wordPtr, readSize, ref pwd,
                                                                    FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, retArray, iEPCLenBytes,
                                                                    ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet == 0)
                {
                    arrTemp = new byte[readSize * 2];
                    Array.Copy(retArray, arrTemp, readSize * 2);

                    try
                    {
                        ci.EPC_CRC = ByteArrayToHexString(arrTemp.Take(2).ToArray());
                        ci.PC = ByteArrayToHexString(arrTemp.Skip(2).Take(2).ToArray());
                        ci.FullEPC = ByteArrayToHexString(arrTemp.Skip(2).ToArray());
                    }
                    catch { }
                    i += 1;
                    ctrBadRead = 0; //Reset if we successfuly read
                }
                else
                {
                    if (ctrBadRead == 20)
                        break;
                    ctrBadRead += 1;
                }

            }

            if (!string.IsNullOrEmpty(ci.FullEPC))
                ci.iFullEPCLen = (ci.FullEPC.Length / 4) + 1;   //+1 for CRC which isnt included

            //Decode PC flags
            int iPCBits = Convert.ToUInt16(ci.PC, 16);
            ci.bPC_UMI = ((iPCBits & 0x400) == 0x400) ? true : false;
            ci.bPC_XPC = ((iPCBits & 0x200) == 0x200) ? true : false;
            ci.bPC_Toggle = ((iPCBits & 0x100) == 0x100) ? true : false;

            //Read User Data
            FormSharedData.ferrorcode = -1;
            i = 1;
            while (FormSharedData.ferrorcode == -1)
            {
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("0", 16);
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.User, wordPtr, (byte)i,
                                                                    ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                    retArray, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet == 0)
                {
                    arrTemp = new byte[i * 2];
                    Array.Copy(retArray, arrTemp, i * 2);
                    ci.UserData = ByteArrayToHexString(arrTemp);
                }
                if (FormSharedData.ferrorcode != -1 && FormSharedData.ferrorcode != (int)TagErrCode.ERR_MEM_OVERRUN)
                {
                    if (ci.arrUserBlocksLocked == null)
                        ci.arrUserBlocksLocked = new List<int> { 0 };

                    ci.arrUserBlocksLocked.Add(i);
                    ci.hasLockedUserBlocks = true;
                }
                if (i > 50) break;  //This must be a 1k or 2k card
                i += 1;
            }
            if (ci.UserData != null)
                ci.iUserLen = ci.UserData.Length / 4;

            //Read card Kill Password
            Array.Clear(retArray, 0, 320);
            readSize = 2;
            wordPtr = Convert.ToByte("00", 16);
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize,
                                                                ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                retArray, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet == 0)
            {
                arrTemp = new byte[readSize * 2];
                Array.Copy(retArray, arrTemp, readSize * 2);
                ci.KillPwd = ByteArrayToHexString(arrTemp);
            }
            if (FormSharedData.ferrorcode == 4)
            {
                ci.isCardKillPWDLocked = true;
            }

            //Read card Access Password
            Array.Clear(retArray, 0, 320);
            readSize = 2;
            wordPtr = Convert.ToByte("02", 16);
            FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);
            {
                uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                uint errCode = uint.MaxValue;
                FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize,
                                                                ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag, retArray,
                                                                iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
            }
            if (FormSharedData.cmdRet == 0)
            {
                arrTemp = new byte[readSize * 2];
                Array.Copy(retArray, arrTemp, readSize * 2);
                ci.AccessPwd = ByteArrayToHexString(arrTemp);
            }
            if (FormSharedData.ferrorcode == 4)
            {
                ci.isCardAccessPWDLocked = true;
            }

            //Is this a Wave v2 Card?
            if (ci.isCardAccessPWDLocked)
            {
                readSize = 2;
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("02", 16);
                FormSharedData.fPassWord = HexStringToByteArray(WaveV2Key);
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize,
                                                                    ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                    retArray, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet == 0)
                {
                    arrTemp = new byte[readSize * 2];
                    Array.Copy(retArray, arrTemp, readSize * 2);
                    if (ByteArrayToHexString(arrTemp) == WaveV2Key)
                    {
                        ci.isWavev2Card = true;
                    }
                }
            }

            //Populate TID
            FormSharedData.ferrorcode = -1;
            readSize = 2;
            wordPtr = Convert.ToByte("00", 16);
            while (FormSharedData.ferrorcode == -1)
            {

                Array.Clear(retArray, 0, 320);
                FormSharedData.fPassWord = HexStringToByteArray(FormSharedData.strDefaultKey);
                {
                    uint pwd = BitConverter.ToUInt32(FormSharedData.fPassWord, 0);
                    uint errCode = uint.MaxValue;
                    FormSharedData.cmdRet = (int)StaticClassReaderB.ReadCard_G2(ref FormSharedData.comAdr, arrEPCHexBytes, (byte)MemBank.TID, wordPtr, readSize,
                                                                        ref pwd, FormSharedData.Maskadr, FormSharedData.MaskLen, FormSharedData.MaskFlag,
                                                                        retArray, iEPCLenBytes, ref errCode, FormSharedData.frmcomportindex);
                    FormSharedData.ferrorcode = errCode == uint.MaxValue ? -1 : (int)errCode;
                }
                if (FormSharedData.cmdRet == 0)
                {
                    arrTemp = new byte[readSize * 2];
                    Array.Copy(retArray, arrTemp, readSize * 2);
                    ci.TID = ByteArrayToHexString(arrTemp);
                }
                readSize += 1;
            }

            if (!string.IsNullOrEmpty(ci.TID))
                ci.iTIDLen = ci.TID.Length / 4;

            return ci;
        }
    }
}
