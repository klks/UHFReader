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
using static Utilities.Utilities;
using static Utilities.CardJson;
using static Utilities.DigitsICDB;
using static Utilities.DigitsMDID;
using static Utilities.DigitsMDID_Chips;

namespace Utilities
{
    public partial class CardCompare : Form
    {
        public CardCompare()
        {
            InitializeComponent();
        }

        private void FormCompareResetUI(int resetSide)
        {
            if (resetSide == 1)
            {
                gbCard1.Text = "Card 1 ()";
                lblCmp_Card1_TID.Text = "(XXX Bits) (XXXX Words)";
                txtCmp_Card1_TID.Text = "";
                txtCmp_Card1_CRC.Text = "";
                txtCmp_Card1_PC.Text = "";
                txtCmp_Card1_EPC.Text = "";
                txtCmp_Card1_FullEPC.Text = "";
                txtCmp_Card1_EPCLen.Text = "";
                txtCmp_Card1_UserData.Text = "";
                txtCmp_Card1_UserDataLen.Text = "";
                txtCmp_Card1_KillPwd.Text = "";
                txtCmp_Card1_AccessPwd.Text = "";

                //Program Control Flags
                txtCmp_Card1_PC_EPCLen.Text = "";
                cbCmp_Card1_PC_UMI.Checked = false;
                cbCmp_Card1_PC_XPC.Checked = false;
                cbCmp_Card1_PC_T.Checked = false;
                txtCmp_Card1_PC_AFI.Text = "";

                //Short Tag Info
                cbCmp_Card1_STI_X.Checked = false;
                cbCmp_Card1_STI_S.Checked = false;
                cbCmp_Card1_STI_F.Checked = false;
                txtCmp_Card1_STI_MDID.Text = "";
                txtCmp_Card1_STI_TMN.Text = "";
                txtCmp_Card1_STI_Manu.Text = "";
                txtCmp_Card1_STI_Prod.Text = "";
            }
            else if (resetSide == 2)
            {
                gbCard2.Text = "Card 2 ()";
                lblCmp_Card2_TID.Text = "(XXX Bits) (XXXX Words)";
                txtCmp_Card2_TID.Text = "";
                txtCmp_Card2_CRC.Text = "";
                txtCmp_Card2_PC.Text = "";
                txtCmp_Card2_EPC.Text = "";
                txtCmp_Card2_FullEPC.Text = "";
                txtCmp_Card2_EPCLen.Text = "";
                txtCmp_Card2_UserData.Text = "";
                txtCmp_Card2_UserDataLen.Text = "";
                txtCmp_Card2_KillPwd.Text = "";
                txtCmp_Card2_AccessPwd.Text = "";

                //Program Control Flags
                txtCmp_Card2_PC_EPCLen.Text = "";
                cbCmp_Card2_PC_UMI.Checked = false;
                cbCmp_Card2_PC_XPC.Checked = false;
                cbCmp_Card2_PC_T.Checked = false;
                txtCmp_Card2_PC_AFI.Text = "";

                //Short Tag Info
                cbCmp_Card2_STI_X.Checked = false;
                cbCmp_Card2_STI_S.Checked = false;
                cbCmp_Card2_STI_F.Checked = false;
                txtCmp_Card2_STI_MDID.Text = "";
                txtCmp_Card2_STI_TMN.Text = "";
                txtCmp_Card2_STI_Manu.Text = "";
                txtCmp_Card2_STI_Prod.Text = "";
            }

            //Reset any salmons
            txtCmp_Card2_TID.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_CRC.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_PC.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_EPC.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_FullEPC.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_EPCLen.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_UserData.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_UserDataLen.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_KillPwd.BackColor = System.Drawing.SystemColors.Control;
            txtCmp_Card2_AccessPwd.BackColor = System.Drawing.SystemColors.Control;
        }

        private void CompareFields()
        {
            //Reset Card2 fields
            if (txtCmp_Card2_TID.Text != "")
            {
                if (txtCmp_Card1_TID.Text != txtCmp_Card2_TID.Text)
                    txtCmp_Card2_TID.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_CRC.Text != txtCmp_Card2_CRC.Text)
                    txtCmp_Card2_CRC.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_PC.Text != txtCmp_Card2_PC.Text)
                    txtCmp_Card2_PC.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_EPC.Text != txtCmp_Card2_EPC.Text)
                    txtCmp_Card2_EPC.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_FullEPC.Text != txtCmp_Card2_FullEPC.Text)
                    txtCmp_Card2_FullEPC.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_EPCLen.Text != txtCmp_Card2_EPCLen.Text)
                    txtCmp_Card2_EPCLen.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_UserData.Text != txtCmp_Card2_UserData.Text)
                    txtCmp_Card2_UserData.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_UserDataLen.Text != txtCmp_Card2_UserDataLen.Text)
                    txtCmp_Card2_UserDataLen.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_KillPwd.Text != txtCmp_Card2_KillPwd.Text)
                    txtCmp_Card2_KillPwd.BackColor = System.Drawing.Color.Salmon;

                if (txtCmp_Card1_AccessPwd.Text != txtCmp_Card2_AccessPwd.Text)
                    txtCmp_Card2_AccessPwd.BackColor = System.Drawing.Color.Salmon;

            }
        }
        private void btnCmpCard1Load_Click(object sender, EventArgs e)
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
                        CardInfo ci = Utilities.CardJson_to_CardInfo(card_data);
                        FormCompareResetUI(1);

                        if (ci.FullEPC != null)
                        {
                            gbCard1.Text = "Card1 (" + openFileDialog.SafeFileName + ")";
                            lblCmp_Card1_TID.Text = String.Format("({0} Bits) ({1} Words)", (ci.iTIDLen * 2) * 8, ci.iTIDLen);
                            txtCmp_Card1_TID.Text = ci.TID;
                            txtCmp_Card1_CRC.Text = ci.EPC_CRC;
                            txtCmp_Card1_PC.Text = ci.PC;
                            txtCmp_Card1_EPC.Text = ci.EPC;
                            txtCmp_Card1_FullEPC.Text = ci.FullEPC;
                            txtCmp_Card1_EPCLen.Text = ci.iFullEPCLen.ToString();
                            txtCmp_Card1_UserData.Text = ci.UserData;
                            txtCmp_Card1_UserDataLen.Text = ci.iUserLen.ToString();
                            txtCmp_Card1_KillPwd.Text = ci.KillPwd;
                            txtCmp_Card1_AccessPwd.Text = ci.AccessPwd;

                            //Populate Program Options panel
                            if (ci.PC != null)
                            {
                                int iPCBits = Convert.ToUInt16(ci.PC, 16);
                                int iEPCLen = (iPCBits & 0xF800) >> 11;
                                txtCmp_Card1_PC_EPCLen.Text = iEPCLen.ToString();

                                cbCmp_Card1_PC_UMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                                cbCmp_Card1_PC_XPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                                cbCmp_Card1_PC_T.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                                txtCmp_Card1_PC_AFI.Text = (iPCBits & 0xFF).ToString("X2");
                            }

                            //Parse TID Short Tag Info
                            if (ci.TID != null)
                            {
                                uint uTIDShortTag = Convert.ToUInt32(ci.TID.Substring(0, 8), 16);
                                txtCmp_Card1_STI_TMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                                txtCmp_Card1_STI_MDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                                cbCmp_Card1_STI_X.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                                cbCmp_Card1_STI_S.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                                cbCmp_Card1_STI_F.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                                LoadICDB();
                                DigitsICDB? entry = GetShortTagExtendedInfo(txtCmp_Card1_STI_MDID.Text, txtCmp_Card1_STI_TMN.Text);
                                if (entry != null)
                                {
                                    txtCmp_Card1_STI_Manu.Text = entry.manufacturer;
                                    txtCmp_Card1_STI_Prod.Text = entry.modelName;
                                }
                                else
                                    txtCmp_Card1_STI_Manu.Text = GetShortTagMDIDName(txtCmp_Card1_STI_MDID.Text);
                            }
                            CompareFields();
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnCmpCard2Load_Click(object sender, EventArgs e)
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
                        FormCompareResetUI(2);
                        if (ci.FullEPC != null)
                        {
                            gbCard2.Text = "Card2 (" + openFileDialog.SafeFileName + ")";
                            lblCmp_Card2_TID.Text = String.Format("({0} Bits) ({1} Words)", (ci.iTIDLen * 2) * 8, ci.iTIDLen);
                            txtCmp_Card2_TID.Text = ci.TID;
                            txtCmp_Card2_CRC.Text = ci.EPC_CRC;
                            txtCmp_Card2_PC.Text = ci.PC;
                            txtCmp_Card2_EPC.Text = ci.EPC;
                            txtCmp_Card2_FullEPC.Text = ci.FullEPC;
                            txtCmp_Card2_EPCLen.Text = ci.iFullEPCLen.ToString();
                            txtCmp_Card2_UserData.Text = ci.UserData;
                            txtCmp_Card2_UserDataLen.Text = ci.iUserLen.ToString();
                            txtCmp_Card2_KillPwd.Text = ci.KillPwd;
                            txtCmp_Card2_AccessPwd.Text = ci.AccessPwd;

                            //Populate Program Options panel
                            if (ci.PC != null)
                            {
                                int iPCBits = Convert.ToUInt16(ci.PC, 16);
                                int iEPCLen = (iPCBits & 0xF800) >> 11;
                                txtCmp_Card2_PC_EPCLen.Text = iEPCLen.ToString();

                                cbCmp_Card2_PC_UMI.Checked = ((iPCBits & 0x400) == 0x400) ? true : false;
                                cbCmp_Card2_PC_XPC.Checked = ((iPCBits & 0x200) == 0x200) ? true : false;
                                cbCmp_Card2_PC_T.Checked = ((iPCBits & 0x100) == 0x100) ? true : false;
                                txtCmp_Card2_PC_AFI.Text = (iPCBits & 0xFF).ToString("X2");
                            }

                            //Parse TID Short Tag Info
                            if (ci.TID != null)
                            {
                                uint uTIDShortTag = Convert.ToUInt32(ci.TID.Substring(0, 8), 16);
                                txtCmp_Card2_STI_TMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");
                                txtCmp_Card2_STI_MDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");
                                cbCmp_Card2_STI_X.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                                cbCmp_Card2_STI_S.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                                cbCmp_Card2_STI_F.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                                LoadICDB();
                                DigitsICDB? entry = GetShortTagExtendedInfo(txtCmp_Card2_STI_MDID.Text, txtCmp_Card2_STI_TMN.Text);
                                if (entry != null)
                                {
                                    txtCmp_Card2_STI_Manu.Text = entry.manufacturer;
                                    txtCmp_Card2_STI_Prod.Text = entry.modelName;
                                }
                                else
                                    txtCmp_Card2_STI_Manu.Text = GetShortTagMDIDName(txtCmp_Card2_STI_MDID.Text);
                            }
                            CompareFields();
                        }
                    }
                    catch { }
                }
            }
        }

        private void txtCMP_WG_Input_TextChanged(object sender, EventArgs e)
        {
            if (txtCMP_WG_Input.Text == null || txtCMP_WG_Input.Text == "")
                return;

            var input = Convert.ToUInt32(txtCMP_WG_Input.Text, 16);
            var lower = input & 0xFFFF;
            var upper = (input & 0xFFFF0000) >> 16;
            var upper_lower = upper & 0xFF;
            var first_6 = input & 0xFFFFFF;

            txtCMP_WG_Out1.Text = upper.ToString("D5") + "," + lower.ToString("D5");
            txtCMP_WG_Out2.Text = "0" + upper_lower.ToString() + "0" + lower.ToString("D5");
            txtCMP_WG_Out3.Text = first_6.ToString();
            txtCMP_WG_Out4.Text = input.ToString("D10");
        }
    }
}
