using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    /// <summary>
    /// Utility class providing common functions for card database operations, string conversion, and UI input filtering.
    /// </summary>
    public class Utilities
    {
        #region Card DB Utils
        // Database loading state
        public static bool bICDBLoaded = false;
        
        // Main database objects
        public static DigitsMDID DigitsMDID_DB = new();
        public static List<DigitsICDB> DigitsDBList = [];

        /// <summary>
        /// Converts a CardJson object to a CardInfo struct with all relevant fields populated.
        /// </summary>
        /// <param name="cj">CardJson object to convert</param>
        /// <returns>CardInfo struct with populated fields</returns>
        public static CardInfo CardJson_to_CardInfo(CardJson? cj)
        {
            CardInfo ci = new CardInfo();

            if (cj == null)
            {
                return ci;
            }

            // Copy basic card data fields
            ci.EPC = cj.EPC != null ? cj.EPC : "";
            ci.FullEPC = cj.FullEPC != null ? cj.FullEPC : "";
            ci.TID = cj.TID != null ? cj.TID : "";
            ci.PC = cj.PC != null ? cj.PC : "";
            ci.EPC_CRC = cj.CRC != null ? cj.CRC : "";
            ci.KillPwd = cj.KillKey != null ? cj.KillKey : "";
            ci.AccessPwd = cj.AccessKey != null ? cj.AccessKey : "";
            ci.UserData = cj.UserData != null ? cj.UserData : "";

            // Calculate length fields based on hex string lengths
            if (ci.UserData != null)
                ci.iUserLen = ci.UserData.Length / 4;
            ci.iFullEPCLen = (ci.FullEPC.Length / 4) + 1;   //Plus 1 because we omit the CRC
            ci.iTIDLen = ci.TID.Length / 4;

            // Decode PC (Program Control) flags
            int iPCBits = Convert.ToUInt16(ci.PC, 16);
            ci.bPC_UMI = ((iPCBits & 0x400) == 0x400) ? true : false;  // User Memory Indicator
            ci.bPC_XPC = ((iPCBits & 0x200) == 0x200) ? true : false;  // Extended PC
            ci.bPC_Toggle = ((iPCBits & 0x100) == 0x100) ? true : false;  // Toggle bit

            // Set kill password lock status
            if (ci.KillPwd == null || ci.KillPwd == "")
                ci.isCardKillPWDLocked = true;

            // Copy lock and card type flags
            ci.isWavev2Card = cj.isWavev2Card;
            ci.isCardKillPWDLocked = cj.isCardKillPWDLocked;
            ci.isCardAccessPWDLocked = cj.isCardAccessPWDLocked;

            return ci;
        }

        /// <summary>
        /// Loads the ICDB (Integrated Circuit Database) from the JSON file if not already loaded.
        /// Parses manufacturer and chip information into the DigitsDBList.
        /// </summary>
        public static void LoadICDB()
        {
            if (!Utilities.bICDBLoaded)
            {
                string inFileList = "Digits'_mdid_list.json";
                if (File.Exists(inFileList))
                {
                    string jsonString = File.ReadAllText(inFileList);

                    // Use regex to remove all non-ascii characters for JSON parsing compatibility
                    jsonString = Regex.Replace(jsonString, @"[^\x00-\x7F]+", string.Empty);

                    try
                    {
                        DigitsMDID_DB = JsonSerializer.Deserialize<DigitsMDID>(jsonString);

                        if (DigitsMDID_DB != null && DigitsMDID_DB.registeredMaskDesigners != null)
                        {
                            foreach (DigitsMDID_Designers mdid_entry in DigitsMDID_DB.registeredMaskDesigners)
                            {
                                // Convert binary MDID to hex format
                                string mdid = mdid_entry.mdid != null ? Convert.ToUInt16(mdid_entry.mdid, 2).ToString("X3") : "";
                                string manufacturer = mdid_entry.manufacturer != null ? mdid_entry.manufacturer : "";
                                string manufacturerUrl = mdid_entry.manufacturerUrl != null ? mdid_entry.manufacturerUrl : "";

                                if (mdid_entry.chips != null)
                                {
                                    // Create database entries for each chip from this manufacturer
                                    foreach (DigitsMDID_Chips mdid_chip in mdid_entry.chips)
                                    {
                                        DigitsICDB dbEntry = new();
                                        dbEntry.mdid = mdid;
                                        dbEntry.manufacturer = manufacturer;
                                        dbEntry.manufacturerUrl = manufacturerUrl;

                                        dbEntry.modelName = mdid_chip.modelName != null ? mdid_chip.modelName : "";
                                        dbEntry.note = mdid_chip.note != null ? mdid_chip.note : "";
                                        dbEntry.tmn = mdid_chip.tmnHex != null ? mdid_chip.tmnHex : "";
                                        dbEntry.productUrl = mdid_chip.productUrl != null ? mdid_chip.productUrl : "";
                                        DigitsDBList.Add(dbEntry);
                                    }
                                }
                                else
                                {
                                    // Create a basic entry for manufacturers without specific chip data
                                    DigitsICDB dbEntry = new();
                                    dbEntry.mdid = mdid;
                                    dbEntry.manufacturer = manufacturer;
                                    dbEntry.manufacturerUrl = manufacturerUrl;
                                    dbEntry.modelName = "";
                                    dbEntry.note = "";
                                    dbEntry.tmn = "";
                                    DigitsDBList.Add(dbEntry);
                                }
                            }
                        }
                    }
                    catch
                    {
                        return;
                    }

                    Utilities.bICDBLoaded = true;
                    return;
                }
            }
        }

        /// <summary>
        /// Gets the manufacturer name for a given MDID (Manufacturer Device ID).
        /// </summary>
        /// <param name="mdid">MDID to look up</param>
        /// <returns>Manufacturer name or empty string if not found</returns>
        public static string GetShortTagMDIDName(string? mdid)
        {
            if (mdid == null || mdid == "") return "";

            foreach (DigitsICDB entry in DigitsDBList)
            {
                if (entry.mdid == mdid)
                {
                    if (entry.manufacturer != null)
                        return entry.manufacturer;
                    break;
                }
            }

            return "";
        }

        /// <summary>
        /// Gets extended information for a chip based on MDID and optional TMN.
        /// </summary>
        /// <param name="mdid">MDID to look up</param>
        /// <param name="tmn">Optional TMN (Terminal Manufacturer Number) for more specific matching</param>
        /// <returns>DigitsICDB entry or null if not found</returns>
        public static DigitsICDB? GetShortTagExtendedInfo(string? mdid, string? tmn)
        {
            if (mdid == null || mdid == "")
                return null;

            foreach (DigitsICDB entry in DigitsDBList)
            {
                if (entry.mdid == mdid)
                {
                    // If TMN is not provided or matches, return this entry
                    if (tmn == null || tmn == "" || entry.tmn == tmn)
                    {
                        return entry;
                    }
                }
            }
            return null;
        }
        #endregion

        #region String Helpers
        // Hex character array for fast conversion
        protected static char[] hexArray = "0123456789ABCDEF".ToCharArray();
        
        /// <summary>
        /// Converts a string to byte array using ASCII encoding.
        /// </summary>
        public static byte[] StringToBytes(string s)
        {
            if (s == null)
            {
                return null;
            }
            return Encoding.ASCII.GetBytes(s);
        }
        
        /// <summary>
        /// Converts a string to its hexadecimal representation.
        /// </summary>
        public static string StringToHexString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str.ToCharArray());
            return BytesToHexString(bytes);
        }

        /// <summary>
        /// Converts a byte array to its hexadecimal string representation.
        /// </summary>
        public static string BytesToHexString(byte[] b)
        {
            if (b == null)
            {
                return "null";
            }
            char[] array = new char[b.Length * 2];
            for (int i = 0; i < b.Length; i++)
            {
                int num = b[i] & 0xFF;
                array[i * 2] = hexArray[num >> 4];
                array[i * 2 + 1] = hexArray[num & 0xF];
            }
            return new string(array);
        }
        
        /// <summary>
        /// Converts a byte array to a readable ASCII string with control character substitution.
        /// </summary>
        public static string BytesToString(byte[] b)
        {
            return (b == null) ? "" : AsciiOctets2String(b);
        }
        
        /// <summary>
        /// Converts a single byte to its hexadecimal string representation.
        /// </summary>
        public static string ByteToHexString(byte b)
        {
            char[] array = new char[2];
            int num = b & 0xFF;
            array[0] = hexArray[num >> 4];
            array[1] = hexArray[num & 0xF];
            return new string(array);
        }
        
        /// <summary>
        /// Converts ASCII bytes to a string, replacing control characters with readable representations.
        /// </summary>
        private static string AsciiOctets2String(byte[] bytes)
        {
            StringBuilder stringBuilder = new StringBuilder(bytes.Length);
            foreach (char item in bytes.Select((byte b) => (char)b))
            {
                // Handle control characters with readable names
                switch (item)
                {
                    case '\0':
                        stringBuilder.Append("<NUL>");
                        continue;
                    case '\u0001':
                        stringBuilder.Append("<SOH>");
                        continue;
                    case '\u0002':
                        stringBuilder.Append("<STX>");
                        continue;
                    case '\u0003':
                        stringBuilder.Append("<ETX>");
                        continue;
                    case '\u0004':
                        stringBuilder.Append("<EOT>");
                        continue;
                    case '\u0005':
                        stringBuilder.Append("<ENQ>");
                        continue;
                    case '\u0006':
                        stringBuilder.Append("<ACK>");
                        continue;
                    case '\a':
                        stringBuilder.Append("<BEL>");
                        continue;
                    case '\b':
                        stringBuilder.Append("<BS>");
                        continue;
                    case '\t':
                        stringBuilder.Append("<HT>");
                        continue;
                    case '\v':
                        stringBuilder.Append("<VT>");
                        continue;
                    case '\f':
                        stringBuilder.Append("<FF>");
                        continue;
                    case '\u000e':
                        stringBuilder.Append("<SO>");
                        continue;
                    case '\u000f':
                        stringBuilder.Append("<SI>");
                        continue;
                    case '\u0010':
                        stringBuilder.Append("<DLE>");
                        continue;
                    case '\u0011':
                        stringBuilder.Append("<DC1>");
                        continue;
                    case '\u0012':
                        stringBuilder.Append("<DC2>");
                        continue;
                    case '\u0013':
                        stringBuilder.Append("<DC3>");
                        continue;
                    case '\u0014':
                        stringBuilder.Append("<DC4>");
                        continue;
                    case '\u0015':
                        stringBuilder.Append("<NAK>");
                        continue;
                    case '\u0016':
                        stringBuilder.Append("<SYN>");
                        continue;
                    case '\u0017':
                        stringBuilder.Append("<ETB>");
                        continue;
                    case '\u0018':
                        stringBuilder.Append("<CAN>");
                        continue;
                    case '\u0019':
                        stringBuilder.Append("<EM>");
                        continue;
                    case '\u001a':
                        stringBuilder.Append("<SUB>");
                        continue;
                    case '\u001b':
                        stringBuilder.Append("<ESC>");
                        continue;
                    case '\u001c':
                        stringBuilder.Append("<FS>");
                        continue;
                    case '\u001d':
                        stringBuilder.Append("<GS>");
                        continue;
                    case '\u001e':
                        stringBuilder.Append("<RS>");
                        continue;
                    case '\u001f':
                        stringBuilder.Append("<US>");
                        continue;
                    case '\u007f':
                        stringBuilder.Append("<DEL>");
                        continue;
                }
                // Handle high-bit characters with Unicode escape sequences
                if (item > '\u007f')
                {
                    stringBuilder.AppendFormat("\\u{0:X4}", (ushort)item);
                }
                else
                {
                    stringBuilder.Append(item);
                }
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region UI Filters
        /// <summary>
        /// KeyPress event handler that allows only hexadecimal characters (0-9, A-F) and backspace.
        /// Control key combinations are allowed.
        /// </summary>
        public static void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) return;
            e.Handled = ("0123456789ABCDEF\b".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        /// <summary>
        /// KeyPress event handler that allows only numeric digits (0-9) and backspace.
        /// Control key combinations are allowed.
        /// </summary>
        public static void filterOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) return;
            e.Handled = ("0123456789\b".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        /// <summary>
        /// TextChanged event handler that filters TextBox content to only hexadecimal characters.
        /// Maintains cursor position after filtering.
        /// </summary>
        public static void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            TextBox? target = sender as TextBox;
            if (target != null)
            {
                string text = target.Text;
                string filteredText = string.Empty;

                // Filter out non-hex characters
                foreach (char c in text)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))
                    {
                        filteredText += c;
                    }
                }

                // Update text and preserve cursor position if filtering occurred
                if (text != filteredText)
                {
                    int selectionStart = target.SelectionStart;
                    target.Text = filteredText;
                    target.SelectionStart = selectionStart > 0 ? selectionStart - 1 : 0;
                }
            }
        }

        /// <summary>
        /// TextChanged event handler that filters TextBox content to only numeric digits.
        /// Maintains cursor position after filtering.
        /// </summary>
        public static void filterOnlyDigits_TextChanged(object sender, EventArgs e)
        {
            TextBox? target = sender as TextBox;
            if (target != null)
            {
                string text = target.Text;
                string filteredText = string.Empty;

                // Filter out non-digit characters
                foreach (char c in text)
                {
                    if (c >= '0' && c <= '9')
                    {
                        filteredText += c;
                    }
                }

                // Update text and preserve cursor position if filtering occurred
                if (text != filteredText)
                {
                    int selectionStart = target.SelectionStart;
                    target.Text = filteredText;
                    target.SelectionStart = selectionStart > 0 ? selectionStart - 1 : 0;
                }
            }
        }
        #endregion
    }
}
