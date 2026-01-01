using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class CIniFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, nint lpReturnedString, uint nSize, string lpFileName);

        public static string IniFiles(string ini_file_path, ref bool file_create_flag)
        {
            file_create_flag = false;
            FileInfo fileInfo = new FileInfo(ini_file_path);
            if (!fileInfo.Exists)
            {
                StreamWriter streamWriter = new StreamWriter(ini_file_path, append: false, Encoding.Default);
                try
                {
                    streamWriter.Write("#Downloader configure file");
                    streamWriter.Close();
                    file_create_flag = true;
                }
                catch
                {
                    throw new ApplicationException("The ini file does not exist.");
                }
            }
            return fileInfo.FullName;
        }

        private static string ReadString(string section, string key, string def, string filePath)
        {
            StringBuilder stringBuilder = new StringBuilder(128);
            stringBuilder.Clear();
            try
            {
                GetPrivateProfileString(section, key, def, stringBuilder, 128, filePath);
            }
            catch
            {
            }
            return stringBuilder.ToString();
        }

        public static long ReadNum(string section, string key, string def, string filePath)
        {
            StringBuilder stringBuilder = new StringBuilder(128);
            stringBuilder.Clear();
            try
            {
                GetPrivateProfileString(section, key, def, stringBuilder, 128, filePath);
            }
            catch
            {
            }
            return long.Parse(stringBuilder.ToString());
        }

        public static string[] ReadIniAllKeys(string section, string filePath)
        {
            uint num = 32767u;
            string[] result = new string[0];
            nint intPtr = Marshal.AllocCoTaskMem((int)(num * 2));
            uint privateProfileSection = GetPrivateProfileSection(section, intPtr, num, filePath);
            if (privateProfileSection != num - 2 || privateProfileSection == 0)
            {
                result = Marshal.PtrToStringAuto(intPtr, (int)privateProfileSection).Split(new char[1], StringSplitOptions.RemoveEmptyEntries);
            }
            Marshal.FreeCoTaskMem(intPtr);
            return result;
        }

        public static string ReadIniKeys(string section, string keys, string filePath)
        {
            return ReadString(section, keys, "", filePath);
        }

        public static void WriteIniKeys(string section, string key, string value, string filePath)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }
    }
}
