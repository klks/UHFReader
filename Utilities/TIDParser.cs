using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Utilities;
using static Utilities.CardJson;
using static Utilities.DigitsICDB;
using static Utilities.DigitsMDID;
using static Utilities.DigitsMDID_Chips;

namespace Utilities
{
    public partial class TIDParser : Form
    {
        /// <summary>
        /// Initializes the TIDParser form and its components.
        /// </summary>
        public TIDParser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the TextChanged event for the TID input textbox.
        /// Filters input to allow only hexadecimal characters, parses the TID value,
        /// extracts short tag information, and updates related UI fields.
        /// </summary>
        private void txtTID_TextChanged(object sender, EventArgs e)
        {
            // Filter input to allow only hexadecimal characters
            filterOnlyHex_TextChanged(sender, e);

            string? TIDValue = txtTID.Text.Trim().ToUpper();

            // Parse TID Short Tag Info if input is at least 8 hex characters
            if (TIDValue != null && TIDValue.Length >= 8)
            {
                // Convert the first 8 hex digits to a 32-bit unsigned integer
                uint uTIDShortTag = Convert.ToUInt32(TIDValue.Substring(0, 8), 16);

                // Extract TMN (Terminal Manufacturer Number) from the lowest 12 bits
                txtSTI_TMN.Text = (uTIDShortTag & 0xFFF).ToString("X3");

                // Extract MDID (Manufacturer Device ID) from bits 12-20
                txtSTI_MDID.Text = ((uTIDShortTag & 0x1F_F000) >> 12).ToString("X3");

                // Extract feature flags from specific bits
                cbSTI_X.Checked = ((uTIDShortTag & 0x80_0000) == 0x80_0000) ? true : false;
                cbSTI_S.Checked = ((uTIDShortTag & 0x40_0000) == 0x40_0000) ? true : false;
                cbSTI_F.Checked = ((uTIDShortTag & 0x20_0000) == 0x20_0000) ? true : false;

                // Load the ICDB database and attempt to get extended info for the short tag
                LoadICDB();
                DigitsICDB? entry = GetShortTagExtendedInfo(txtSTI_MDID.Text, txtSTI_TMN.Text);
                if (entry != null)
                {
                    // If found, display manufacturer and model name
                    txtSTI_Manu.Text = entry.manufacturer;
                    txtSTI_Prod.Text = entry.modelName;
                }
                else
                {
                    // Fallback: display manufacturer name based on MDID only
                    txtSTI_Manu.Text = GetShortTagMDIDName(txtSTI_MDID.Text);
                }
            }
        }

        /// <summary>
        /// Restricts key input to hexadecimal characters in relevant textboxes.
        /// </summary>
        private void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.filterOnlyHex_KeyPress(sender, e);
        }
    }
}
