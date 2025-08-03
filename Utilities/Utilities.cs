using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public class Utilities
    {
        #region Card DB Utils
        public static bool bICDBLoaded = false;
        public static DigitsMDID DigitsMDID_DB = new();
        public static List<DigitsICDB> DigitsDBList = [];

        public static CardInfo CardJson_to_CardInfo(CardJson? cj)
        {
            CardInfo ci = new CardInfo();

            if (cj == null)
            {
                return ci;
            }

            ci.EPC = cj.EPC != null ? cj.EPC : "";
            ci.FullEPC = cj.FullEPC != null ? cj.FullEPC : "";
            ci.TID = cj.TID != null ? cj.TID : "";
            ci.PC = cj.PC != null ? cj.PC : "";
            ci.EPC_CRC = cj.CRC != null ? cj.CRC : "";
            ci.KillPwd = cj.KillKey != null ? cj.KillKey : "";
            ci.AccessPwd = cj.AccessKey != null ? cj.AccessKey : "";
            ci.UserData = cj.UserData != null ? cj.UserData : "";

            if (ci.UserData != null)
                ci.iUserLen = ci.UserData.Length / 4;
            ci.iFullEPCLen = (ci.FullEPC.Length / 4) + 1;   //Plus 1 because we omit the CRC
            ci.iTIDLen = ci.TID.Length / 4;

            //Decode PC flags
            int iPCBits = Convert.ToUInt16(ci.PC, 16);
            ci.bPC_UMI = ((iPCBits & 0x400) == 0x400) ? true : false;
            ci.bPC_XPC = ((iPCBits & 0x200) == 0x200) ? true : false;
            ci.bPC_Toggle = ((iPCBits & 0x100) == 0x100) ? true : false;

            if (ci.KillPwd == null || ci.KillPwd == "")
                ci.isCardKillPWDLocked = true;

            ci.isWavev2Card = cj.isWavev2Card;
            ci.isCardKillPWDLocked = cj.isCardKillPWDLocked;
            ci.isCardAccessPWDLocked = cj.isCardAccessPWDLocked;

            return ci;
        }

        public static void LoadICDB()
        {
            if (!Utilities.bICDBLoaded)
            {
                string inFileList = "Digits'_mdid_list.json";
                if (File.Exists(inFileList))
                {
                    string jsonString = File.ReadAllText(inFileList);

                    //Use regex to remove all non-ascii characters
                    jsonString = Regex.Replace(jsonString, @"[^\x00-\x7F]+", string.Empty);

                    try
                    {
                        DigitsMDID_DB = JsonSerializer.Deserialize<DigitsMDID>(jsonString);

                        if (DigitsMDID_DB != null && DigitsMDID_DB.registeredMaskDesigners != null)
                        {
                            foreach (DigitsMDID_Designers mdid_entry in DigitsMDID_DB.registeredMaskDesigners)
                            {


                                string mdid = mdid_entry.mdid != null ? Convert.ToUInt16(mdid_entry.mdid, 2).ToString("X3") : "";
                                string manufacturer = mdid_entry.manufacturer != null ? mdid_entry.manufacturer : "";
                                string manufacturerUrl = mdid_entry.manufacturerUrl != null ? mdid_entry.manufacturerUrl : "";

                                if (mdid_entry.chips != null)
                                {
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

        public static DigitsICDB? GetShortTagExtendedInfo(string? mdid, string? tmn)
        {
            if (mdid == null || mdid == "")
                return null;

            foreach (DigitsICDB entry in DigitsDBList)
            {
                if (entry.mdid == mdid)
                {
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
        protected static char[] hexArray = "0123456789ABCDEF".ToCharArray();
        public static byte[] StringToBytes(string s)
        {
            if (s == null)
            {
                return null;
            }
            return Encoding.ASCII.GetBytes(s);
        }
        public static string StringToHexString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str.ToCharArray());
            return BytesToHexString(bytes);
        }

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
        public static string BytesToString(byte[] b)
        {
            return (b == null) ? "" : AsciiOctets2String(b);
        }
        public static string ByteToHexString(byte b)
        {
            char[] array = new char[2];
            int num = b & 0xFF;
            array[0] = hexArray[num >> 4];
            array[1] = hexArray[num & 0xF];
            return new string(array);
        }
        private static string AsciiOctets2String(byte[] bytes)
        {
            StringBuilder stringBuilder = new StringBuilder(bytes.Length);
            foreach (char item in bytes.Select((byte b) => (char)b))
            {
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
        public static void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) return;
            e.Handled = ("0123456789ABCDEF\b".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        public static void filterOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) return;
            e.Handled = ("0123456789\b".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        public static void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            TextBox? target = sender as TextBox;
            if (target != null)
            {
                string text = target.Text;
                string filteredText = string.Empty;

                foreach (char c in text)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f'))
                    {
                        filteredText += c;
                    }
                }

                if (text != filteredText)
                {
                    int selectionStart = target.SelectionStart;
                    target.Text = filteredText;
                    target.SelectionStart = selectionStart > 0 ? selectionStart - 1 : 0;
                }
            }
        }

        public static void filterOnlyDigits_TextChanged(object sender, EventArgs e)
        {
            TextBox? target = sender as TextBox;
            if (target != null)
            {
                string text = target.Text;
                string filteredText = string.Empty;

                foreach (char c in text)
                {
                    if (c >= '0' && c <= '9')
                    {
                        filteredText += c;
                    }
                }

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
