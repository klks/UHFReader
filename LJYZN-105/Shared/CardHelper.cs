using ReaderB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using static Utilities.Utilities;

namespace LJYZN_105
{
    public enum MonzaQT
    {
        PAGE_PRIVATE = 0,
        PAGE_PUBLIC = 1,
        RANGE_REDUCE = 2
    }

    public partial class MainForm : Form
    {
        private bool ValidateSingleCardSeen()
        {
            if (ComboBox_EPC2.Items.Count == 0)
            {
                MessageBox.Show("No card found in Search. Please put a card on the reader and do Search Card again.", "Write Failed");
                return false;
            }
            if (ComboBox_EPC2.Items.Count > 1)
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
            if (strSearchEPC == null || strSearchEPC == "")
                return false;

            //Set Mask
            MaskFlag = 0;
            Maskadr = Convert.ToByte("00", 16);
            MaskLen = Convert.ToByte("00", 16);

            byte[] arrEPCHexBytes = HexStringToByteArray(strSearchEPC);
            byte iEPCLenBytes = Convert.ToByte(strSearchEPC.Length / 2);
            byte readSize = 2;
            byte[] retArray = new byte[320];
            byte wordPtr = Convert.ToByte("02", 16);
            byte[] arrTemp;

            fPassWord = HexStringToByteArray(strCardKey); //Set wave key
            fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
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
            return isAccessKeyCorrect(strSearchEPC, strWavev2Key);
        }

        public CardInfo QueryCardDetails(string strSearchEPC)
        {
            CardInfo ci = new CardInfo();

            //Set Mask
            MaskFlag = 0;
            Maskadr = Convert.ToByte("00", 16);
            MaskLen = Convert.ToByte("00", 16);

            //Set default password
            fPassWord = HexStringToByteArray(strDefaultKey);

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
            ferrorcode = -1;
            i = 3;
            int ctrBadRead = 0;

            while(ferrorcode == -1)
            {
                readSize = (byte) i;
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("00", 16);
                fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.EPC, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
                if (fCmdRet == 0)
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

            if (ci.FullEPC != null && ci.FullEPC != "")
                ci.iFullEPCLen = (ci.FullEPC.Length / 4) + 1;   //+1 for CRC which isnt included

            //Decode PC flags
            int iPCBits = Convert.ToUInt16(ci.PC, 16);
            ci.bPC_UMI = ((iPCBits & 0x400) == 0x400) ? true : false;
            ci.bPC_XPC = ((iPCBits & 0x200) == 0x200) ? true : false;
            ci.bPC_Toggle = ((iPCBits & 0x100) == 0x100) ? true : false;

            //Read User Data
            ferrorcode = -1;
            i = 1;
            while (ferrorcode == -1)
            {
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("0", 16);
                fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.User, wordPtr, (byte)i, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
                if (fCmdRet == 0)
                {
                    arrTemp = new byte[i * 2];
                    Array.Copy(retArray, arrTemp, i * 2);
                    ci.UserData = ByteArrayToHexString(arrTemp);
                }
                if (ferrorcode != -1 && ferrorcode != (int)TagErrCode.ERR_MEM_OVERRUN)
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
            fPassWord = HexStringToByteArray(strDefaultKey);
            fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                arrTemp = new byte[readSize * 2];
                Array.Copy(retArray, arrTemp, readSize * 2);
                ci.KillPwd = ByteArrayToHexString(arrTemp);
            }
            if (ferrorcode == 4)
            {
                ci.isCardKillPWDLocked = true;
            }

            //Read card Access Password
            Array.Clear(retArray, 0, 320);
            readSize = 2;
            wordPtr = Convert.ToByte("02", 16);
            fPassWord = HexStringToByteArray(strDefaultKey);
            fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
            if (fCmdRet == 0)
            {
                arrTemp = new byte[readSize * 2];
                Array.Copy(retArray, arrTemp, readSize * 2);
                ci.AccessPwd = ByteArrayToHexString(arrTemp);
            }
            if (ferrorcode == 4)
            {
                ci.isCardAccessPWDLocked = true;
            }

            //Is this a Wave v2 Card?
            if (ci.isCardAccessPWDLocked)
            {
                readSize = 2;
                Array.Clear(retArray, 0, 320);
                wordPtr = Convert.ToByte("02", 16);
                fPassWord = HexStringToByteArray(strWavev2Key);
                fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.Reserved, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
                if (fCmdRet == 0)
                {
                    arrTemp = new byte[readSize * 2];
                    Array.Copy(retArray, arrTemp, readSize * 2);
                    if (ByteArrayToHexString(arrTemp) == strWavev2Key)
                    {
                        ci.isWavev2Card = true;
                    }
                }
            }

            //Populate TID
            ferrorcode = -1;
            readSize = 2;
            wordPtr = Convert.ToByte("00", 16);
            while (ferrorcode == -1)
            {

                Array.Clear(retArray, 0, 320);
                fPassWord = HexStringToByteArray(strDefaultKey);
                fCmdRet = StaticClassReaderB.ReadCard_G2(ref fComAdr, arrEPCHexBytes, (byte)MemBank.TID, wordPtr, readSize, fPassWord, Maskadr, MaskLen, MaskFlag, retArray, iEPCLenBytes, ref ferrorcode, frmcomportindex);
                if (fCmdRet == 0)
                {
                    arrTemp = new byte[readSize * 2];
                    Array.Copy(retArray, arrTemp, readSize * 2);
                    ci.TID = ByteArrayToHexString(arrTemp);
                }
                readSize += 1;
            }

            if( ci.TID != null && ci.TID != "")
                ci.iTIDLen = ci.TID.Length / 4;

            return ci;
        }
    }
}
