using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Utilities.Utilities;

namespace FM_5XX.Shared
{
    public class ReaderService : IDisposable
    {
        public class PowerItem
        {
            public string LocationName { get; set; }
            public string LocationValue { get; set; }
        }

        public class DataRepository
        {
            public static List<PowerItem> GetPowerGroups(Module.Version v)
            {
                var __list = new List<PowerItem>();
                int i;

                switch (v)
                {
                    case Module.Version.FI_R300T_D1:
                    case Module.Version.FI_R300T_D2:
                        for (i = 27; i >= 0; i--)
                            __list.Add(new PowerItem() { LocationName = string.Format("{0} dBm", i - 2), LocationValue = i.ToString("X2") });
                        break;
                    default:
                    case Module.Version.FI_R300A_C1:
                    case Module.Version.FI_R300A_C2:
                        for (i = 20; i >= 0; i--)
                            __list.Add(new PowerItem() { LocationName = string.Format("{0} dBm", i - 2), LocationValue = i.ToString("X2") });
                        break;
                    case Module.Version.FI_R300S:
                        for (i = 27; i >= 0; i--)
                            __list.Add(new PowerItem() { LocationName = string.Format("{0} dBm", i), LocationValue = i.ToString("X2") });
                        break;
                }
                return __list;
            }

            public static List<string> GetStepGroups()
            {
                var __list = new List<string>();

                __list.Add("1");
                __list.Add("2");
                __list.Add("3");
                __list.Add("4");
                __list.Add("5");
                __list.Add("6");
                __list.Add("7");
                __list.Add("8");
                __list.Add("9");
                __list.Add("10");
                __list.Add("20");
                __list.Add("50");
                __list.Add("100");
                return __list;
            }
        }

        public class Module
        {
            public enum CommandType
            {
                Normal,
                AA
            }
            public enum Regulation
            {
                [Description("01")]
                US = 1,
                [Description("02")]
                TW,
                [Description("03")]
                CN,
                [Description("04")]
                CN2,
                [Description("05")]
                EU
            }
            public enum Version
            {
                FI_R3008,
                FI_R300A_C1,
                FI_R300A_C2,
                FI_R300T_D1,
                FI_R300T_D2,
                FI_R300S,
                FI_RXXXX
            }

            public static Version Check(int ver)
            {
                switch (ver & 0xF000)
                {
                    case 0:
                        return Version.FI_R3008;
                    case 49152:
                        if ((ver & 0xF00) == 256)
                        {
                            return Version.FI_R300A_C1;
                        }
                        return Version.FI_R300A_C2;
                    case 53248:
                        if ((ver & 0xF00) == 256)
                        {
                            return Version.FI_R300T_D1;
                        }
                        return Version.FI_R300T_D2;
                    case 20480:
                        return Version.FI_R300S;
                    default:
                        return Version.FI_RXXXX;
                }
            }
        }
        public class CombineDataReceiveArgument : EventArgs
        {
            private string data;

            public int Length => data.Length;

            public string Data => data;

            public CombineDataReceiveArgument(string s)
            {
                data = s;
            }
        }

        public class RawDataReceiveArgument : EventArgs
        {
            private byte[] data;

            public int Length => data.Length;

            public byte[] Data => data;

            public RawDataReceiveArgument(byte[] b)
            {
                data = b;
            }
        }

        public delegate void CombineDataHandler(object sender, CombineDataReceiveArgument e);
        public delegate void RawDataHandler(object sender, RawDataReceiveArgument e);

        public delegate void DelegateSerialPortLog(string message, string send_direction);
        public DelegateSerialPortLog? SerialPortLog;

        private Thread? ReceiveThread = null;
        private bool IsReceiveEnd = false;
        private string ReceiveBuffer = "";
        private string? SubPacket = null;
        private byte[]? SubReceiveBuffer;
        private Module.CommandType CommandType = Module.CommandType.Normal;
        private SerialPort SerialPort_;
        private StringBuilder DataBuilder;
        public event RawDataHandler RawDataReceiveEvent;
        public event CombineDataHandler CombineDataReceiveEvent;

        public void Dispose()
        {
            Close();
        }

        public ReaderService()
        {
            SerialPort_ = new SerialPort();
            if (DataBuilder == null)
            {
                DataBuilder = new StringBuilder();
            }
        }

        private async void WriteSerialLog(string message, string send_direction)
        {
            if (SerialPortLog != null)
            {
                message = ShowCRLF(message);
                SerialPortLog(message, send_direction);
            }
        }

        private async void WriteSerialLog(byte[] bs, string send_direction)
        {
            if (SerialPortLog != null)
            {
                string message = Encoding.ASCII.GetString(bs);
                message = ShowCRLF(message);
                SerialPortLog(message, send_direction);
            }
        }

        public static List<string> GetCOMportList()
        {
            try
            {
                return SerialPort.GetPortNames().ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        public ReaderService Action_(string paramAction)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(MakesUpZero(paramAction, 3)));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        public ReaderService Address_(string paramAddress)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(paramAddress));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        
        public ReaderService Bank_(string paramBank)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(paramBank));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        
        private void Clear()
        {
            if (DataBuilder != null)
            {
                DataBuilder.Clear();
            }
        }
        public void Close()
        {
            IsReceiveEnd = true;
            if (ReceiveThread != null)
            {
                ReceiveThread.Join();
            }
            if (SerialPort_.IsOpen)
            {
                SerialPort_.Close();
            }
        }
        private void CombineDataReceive(string s)
        {
            if (CombineDataReceiveEvent != null)
            {
                CombineDataReceiveArgument e = new CombineDataReceiveArgument(s);
                CombineDataReceiveEvent(this, e);
            }
        }
        public ReaderService Comma_()
        {
            lock (DataBuilder)
            {
                DataBuilder.Append(BitConverter.ToString(Encoding.Default.GetBytes(",")));
            }
            return this;
        }
        public ReaderService Command_(byte paramCommand)
        {
            lock (DataBuilder)
            {
                DataBuilder.Append(MakesUpZero(Utilities.Utilities.ByteToHexString(paramCommand), 2));
            }
            return this;
        }
        public ReaderService Command_(byte[] paramCommand)
        {
            lock (DataBuilder)
            {
                DataBuilder.Append(Utilities.Utilities.BytesToHexString(paramCommand));
            }
            return this;
        }
        public ReaderService Command_(string paramCommand)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(paramCommand));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        public byte[] Command_AA(string type, string command, string address, string data)
        {
            DataBuilder.Append(MakesUpZero(type, 2)).Append(MakesUpZero(command, 2)).Append(MakesUpZero(address, 4))
                .Append(MakesUpZero(data, 2));
            byte b = Convert.ToByte((DataBuilder.Length + 2) / 2);
            DataBuilder.Insert(0, MakesUpZero(Utilities.Utilities.ByteToHexString(b), 2));
            byte b2 = CRC8(HexStringToBytes(DataBuilder.ToString()));
            DataBuilder.Append(MakesUpZero(Utilities.Utilities.ByteToHexString(b2), 2));
            DataBuilder.Insert(0, "AA");
            string hex = DataBuilder.ToString();
            Clear();
            return HexStringToBytes(hex);
        }
        public byte[] Command_AA(string data)
        {
            DataBuilder.Append(data);
            byte b = Convert.ToByte((DataBuilder.Length + 2) / 2);
            DataBuilder.Insert(0, MakesUpZero(Utilities.Utilities.ByteToHexString(b), 2));
            b = CRC8(HexStringToBytes(DataBuilder.ToString()));
            DataBuilder.Append(MakesUpZero(Utilities.Utilities.ByteToHexString(b), 2));
            DataBuilder.Insert(0, "AA");
            string hex = DataBuilder.ToString();
            Clear();
            return HexStringToBytes(hex);
        }
        public byte[] Command_J(byte param, string paramData)
        {
            return Command_(74)
                .Command_(param)
                .Data_(paramData)
                .Commit();
        }
        public byte[] Command_K(string paramPassword, byte paramRecom)
        {
            return Command_(75)
                .Password_(paramPassword)
                .Comma_()
                .Recom_(paramRecom)
                .Commit();
        }
        public byte[] Command_L(string paramMask, string paramAction)
        {
            return Command_(76)
                .Mask_(paramMask)
                .Comma_()
                .Action_(paramAction)
                .Commit();
        }
        public byte[] Command_P(string paramPassword)
        {
            return Command_(80).Password_(paramPassword).Commit();
        }
        public byte[] Command_Q()
        {
            return Command_(81).Commit();
        }
        public byte[] Command_R(string paramBank, string paramAddress, string paramLength)
        {
            return Command_(82)
                .Bank_(paramBank)
                .Comma_()
                .Address_(paramAddress)
                .Comma_()
                .Length_(paramLength)
                .Commit();
        }
        public byte[] Command_S()
        {
            return Command_(83).Commit();
        }
        public byte[] Command_T(string paramBank, string paramAddress, string paramLength, string paramData)
        {
            return Command_(84)
                .Bank_(paramBank)
                .Comma_()
                .Address_(paramAddress)
                .Comma_()
                .Length_(paramLength)
                .Comma_()
                .Data_(paramData)
                .Commit();
        }
        public byte[] Command_U()
        {
            return Command_(85).Commit();
        }
        public byte[] Command_U(string q)
        {
            return Command_(85).Command_(q).Commit();
        }
        public byte[] Command_UR(string q, string paramBank, string paramAddress, string paramLength)
        {
            if (q != null)
            {
                return Command_(85)
                    .Command_(q)
                    .Comma_()
                    .Command_(82)
                    .Bank_(paramBank)
                    .Comma_()
                    .Address_(paramAddress)
                    .Comma_()
                    .Length_(paramLength)
                    .Commit();
            }
            return Command_(85)
                .Comma_()
                .Command_(82)
                .Bank_(paramBank)
                .Comma_()
                .Address_(paramAddress)
                .Comma_()
                .Length_(paramLength)
                .Commit();
        }
        public byte[] Command_V()
        {
            return Command_(86).Commit();
        }
        public byte[] Command_W(string paramBank, string paramAddress, string paramLength, string paramData)
        {
            return Command_(87)
                .Bank_(paramBank)
                .Comma_()
                .Address_(paramAddress)
                .Comma_()
                .Length_(paramLength)
                .Comma_()
                .Data_(paramData)
                .Commit();
        }
        public byte[] Commit()
        {
            if (DataBuilder == null)
            {
                throw new ArgumentException("data is null", "DataBuilder");
            }
            byte b = Convert.ToByte((DataBuilder.Length + 2) / 2);
            DataBuilder.Insert(0, MakesUpZero(Utilities.Utilities.ByteToHexString(10), 2)).Append(MakesUpZero(Utilities.Utilities.ByteToHexString(13), 2));
            string hex = DataBuilder.ToString();
            Clear();
            return HexStringToBytes(hex);
        }
        public byte CRC8(byte[] paramBytes)
        {
            int num = 0;
            if (paramBytes == null)
            {
                return 0;
            }
            for (int i = 0; i < paramBytes.Length; i++)
            {
                int num2 = 8;
                num ^= paramBytes[i] & 0xFF;
                do
                {
                    num = (num & 0x80) == 0 ? num << 1 : num << 1 ^ 0x31;
                    num2--;
                }
                while (num2 > 0);
            }
            return (byte)num;
        }
        public int CRC16(byte[] paramBytes)
        {
            int num = 65535;
            int num2 = 4129;
            int num3 = 0;
            int num4 = 0;
            if (paramBytes == null)
            {
                return 0;
            }
            if (paramBytes[0] == 0)
            {
                num3 = 8;
                num4 = 1;
            }
            int i = num3;
            int num5 = num4;
            for (; i < paramBytes.Length * 8; i++)
            {
                if (i % 8 == 0)
                {
                    num ^= paramBytes[num5++] << 8 & 0xFF00;
                }
                if (((uint)num & 0x8000u) != 0)
                {
                    num = num << 1 & 0xFFFE ^ num2;
                    continue;
                }
                num <<= 1;
                num &= 0xFFFE;
            }
            return num & 0xFFFF;
        }
        public ReaderService Data_(byte paramData)
        {
            lock (DataBuilder)
            {
                DataBuilder.Append(Utilities.Utilities.ByteToHexString(paramData));
            }
            return this;
        }
        public ReaderService Data_(string paramData)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(paramData));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }

        public static string DeleteCRLFandHandler(string src, char handler)
        {
            return src.Replace('\n'.ToString(), "").Replace('\r'.ToString(), "").Replace(handler.ToString(), "");
        }
        public static string[] DeleteCRLFandSplit(string src, char split)
        {
            string text = src.Replace('\n'.ToString(), "").Replace('\r'.ToString(), "");
            return text.Split(split);
        }
        private void DoCombine(byte[] data)
        {
            bool flag = true;
            string text = Utilities.Utilities.BytesToString(data);
            if (SubPacket != null && SubPacket.Length > 0)
            {
                text = SubPacket + text;
            }
            do
            {
                int num;
                if ((num = text.IndexOf("\r\n")) != -1)
                {
                    num += 2;
                    lock (ReceiveBuffer)
                    {
                        ReceiveBuffer = text.Substring(0, num);
                        WriteSerialLog(ReceiveBuffer, "RX");
                        CombineDataReceive(ReceiveBuffer);
                    }
                    if (text.Length - 1 == num)
                    {
                        flag = false;
                        SubPacket = text.Substring(num, text.Length - num);
                    }
                    else
                    {
                        text = text.Substring(num, text.Length - num);
                    }
                }
                else
                {
                    SubPacket = text;
                    flag = false;
                }
            }
            while (flag);
        }
        private void DoReceiveWork()
        {
            byte[] array = new byte[256];
            while (!IsReceiveEnd)
            {
                if (SerialPort_.BytesToRead > 0)
                {
                    if (CommandType == Module.CommandType.Normal)
                    {
                        int newSize = SerialPort_.Read(array, 0, array.Length);
                        Array.Resize(ref array, newSize);
                        RawRaiseDataReceive(array);
                        DoCombine(array);
                    }
                    else if (CommandType == Module.CommandType.AA)
                    {
                        Thread.Sleep(64);
                        int newSize = SerialPort_.Read(array, 0, array.Length);
                        Array.Resize(ref array, newSize);
                        lock (ReceiveBuffer)
                        {
                            ReceiveBuffer = Utilities.Utilities.BytesToHexString(array);
                        }
                    }
                    Array.Resize(ref array, 256);
                }
                Thread.Sleep(2);
            }
        }
        public SerialPort GetSerialPort()
        {
            return SerialPort_;
        }
        public byte HexStringToByte(string s)
        {
            int length = s.Length;
            if (length == 2)
            {
                return (byte)((Convert.ToInt32(s[0].ToString(), 16) << 4) + Convert.ToInt32(s[1].ToString(), 16));
            }
            throw new InvalidOperationException();
        }
        public byte[] HexStringToBytes(string hex)
        {
            byte[] result = [];
            try
            {
                if (hex.Length % 2 == 0)
                {
                    result = (from x in Enumerable.Range(0, hex.Length)
                              where x % 2 == 0
                              select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
                }
            }
            catch (Exception)
            {
                result = [];
            }
            return result;
        }
        public int HexStringToInt(string s)
        {
            return int.Parse(s, NumberStyles.HexNumber);
        }
        public void IntegrateData(RawDataReceiveArgument e, List<string> packets)
        {
            byte[] data = e.Data;
            int length = e.Length;
            int num = 65535;
            if (SubReceiveBuffer != null)
            {
                data = new byte[SubReceiveBuffer.Length + e.Length];
                Buffer.BlockCopy(SubReceiveBuffer, 0, data, 0, SubReceiveBuffer.Length);
                Buffer.BlockCopy(e.Data, 0, data, SubReceiveBuffer.Length, e.Length);
                length = data.Length;
                SubReceiveBuffer = null;
            }
            do
            {
                if (data[0] == 10 && data.Length > 1)
                {
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        if (data[i] == 13 && data[i + 1] == 10)
                        {
                            num = i + 2;
                            break;
                        }
                    }
                    if (length >= num)
                    {
                        byte[] array = new byte[num];
                        Buffer.BlockCopy(data, 0, array, 0, num);
                        lock (packets)
                        {
                            packets.Add(ReductionData(array));
                        }
                        length -= num;
                        byte[] array2 = new byte[length];
                        Buffer.BlockCopy(data, num, array2, 0, length);
                        data = array2;
                    }
                    else
                    {
                        SubReceiveBuffer = new byte[length];
                        Buffer.BlockCopy(data, 0, SubReceiveBuffer, 0, length);
                        length = 0;
                    }
                    continue;
                }
                if (data[0] == 170 && data.Length > 1)
                {
                    num = data[1];
                }
                if (length >= num + 2)
                {
                    byte[] array = new byte[num + 1];
                    Buffer.BlockCopy(data, 1, array, 0, num + 1);
                    if (CRC8(array) == 0)
                    {
                        byte[] array3 = new byte[array.Length - 2];
                        Buffer.BlockCopy(array, 1, array3, 0, array3.Length);
                        lock (packets)
                        {
                            packets.Add(ReductionData(array3));
                        }
                    }
                    else
                    {
                        byte[] b = "\n\n"u8.ToArray();
                        lock (packets)
                        {
                            packets.Add(ReductionData(b));
                        }
                    }
                    length -= num + 2;
                    byte[] array2 = new byte[length];
                    Buffer.BlockCopy(data, num + 2, array2, 0, length);
                    data = array2;
                }
                else
                {
                    SubReceiveBuffer = new byte[length];
                    Buffer.BlockCopy(data, 0, SubReceiveBuffer, 0, length);
                    length = 0;
                }
            }
            while (length > 0);
        }
        public bool IsOpen()
        {
            return SerialPort_.IsOpen;
        }
        public ReaderService Length_(string paramLength)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(paramLength));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        public string MakesUpZero(string str, int lenSize)
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < lenSize; i++)
            {
                stringBuilder.Append('0');
            }
            string text = stringBuilder.ToString() + str;
            return text.Substring(text.Length - lenSize);
        }
        public ReaderService Mask_(string paramMask)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(MakesUpZero(paramMask, 3)));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        public bool Open(string port, int baudRate, Parity p, int bits, StopBits s)
        {
            try
            {
                if (!SerialPort_.IsOpen)
                {
                    SerialPort_.PortName = port;
                    SerialPort_.BaudRate = baudRate;
                    SerialPort_.Parity = p;
                    SerialPort_.DataBits = bits;
                    SerialPort_.StopBits = s;
                    SerialPort_.ReadTimeout = 1500;
                    SerialPort_.WriteTimeout = 1500;
                    SerialPort_.Open();
                    IsReceiveEnd = false;
                    ReceiveThread = new Thread(DoReceiveWork);
                    ReceiveThread.IsBackground = true;
                    ReceiveThread.Start();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ReaderService Password_(string paramPassword)
        {
            string text = BitConverter.ToString(Encoding.Default.GetBytes(MakesUpZero(paramPassword, 8)));
            text = text.Replace("-", "");
            lock (DataBuilder)
            {
                DataBuilder.Append(text);
            }
            return this;
        }
        private void RawRaiseDataReceive(byte[] b)
        {
            if (RawDataReceiveEvent != null)
            {
                RawDataReceiveArgument e = new RawDataReceiveArgument(b);
                RawDataReceiveEvent(this, e);
            }
        }
        public byte[] ReadFrequencyOffset()
        {
            return Command_("I4008903").Commit();
        }
        public byte[] ReadModeandChannel()
        {
            return Command_("I4008702").Commit();
        }
        public byte[] ReadPower()
        {
            return Command_("N0,00").Commit();
        }
        public byte[] ReadRegulation()
        {
            return Command_("N4,00").Commit();
        }
        public byte[]? Receive()
        {
            int num = 256;
            bool flag = false;
            byte[]? array = null;
            do
            {
                num--;
                if (num == 0)
                {
                    flag = true;
                }
                lock (ReceiveBuffer)
                {
                    if (ReceiveBuffer != null && ReceiveBuffer.Length > 0)
                    {
                        array = CommandType != Module.CommandType.AA ? Utilities.Utilities.StringToBytes(ReceiveBuffer) : HexStringToBytes(ReceiveBuffer);
                        ReceiveBuffer = "";
                        num = 0;
                    }
                }
                Thread.Sleep(4);
            }
            while (num > 0);
            CommandType = Module.CommandType.Normal;
            return !flag ? array : null;
        }
        public byte[]? Receive(int i)
        {
            if (i < 0 && i > 1000)
            {
                i = 1000;
            }
            bool flag = false;
            byte[]? array = null;
            do
            {
                i--;
                if (i == 0)
                {
                    flag = true;
                }
                if (ReceiveBuffer != null && ReceiveBuffer.Length > 0)
                {
                    array = CommandType != Module.CommandType.AA ? Utilities.Utilities.StringToBytes(ReceiveBuffer) : HexStringToBytes(ReceiveBuffer);
                    ReceiveBuffer = "";
                    i = 0;
                }
                Thread.Sleep(4);
            }
            while (i > 0);
            CommandType = Module.CommandType.Normal;
            return !flag ? array : null;
        }
        public ReaderService Recom_(byte paramRecom)
        {
            lock (DataBuilder)
            {
                DataBuilder.Append(Utilities.Utilities.ByteToHexString(paramRecom));
            }
            return this;
        }
        private string ReductionData(byte[] b)
        {
            int num = 12;
            int num2 = 0;
            if (b[0] == 10)
            {
                DataBuilder.Append(RemoveCRLF(Utilities.Utilities.BytesToString(b)));
            }
            else
            {
                if (b[0] == 10 && b[1] == 10)
                {
                    return "CRC Check Error";
                }
                num2 = b[6] + 7;
                DataBuilder.Append(Utilities.Utilities.BytesToHexString(b));
                DataBuilder.Remove(num2 * 2, 2).Insert(num2 * 2, ",R");
                DataBuilder.Remove(num, 2).Insert(num, " Q");
                DataBuilder.Insert(10, ":").Insert(8, ":").Insert(6, " ")
                    .Insert(4, "/")
                    .Insert(2, "/")
                    .Insert(0, "20");
            }
            string text = DataBuilder.ToString();
            if (b[num2] == 1)
            {
                string s = text.Substring(num2 * 2 + 9, 2);
                switch (Convert.ToChar(HexStringToByte(s)))
                {
                    case 'R':
                        text = text.Remove(num2 * 2 + 9, 2) + " <none>";
                        break;
                    case '0':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Other error>";
                        break;
                    case '3':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Memory overrun>";
                        break;
                    case '4':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Memory locked>";
                        break;
                    case 'B':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Insufficient power>";
                        break;
                    case 'E':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Tag reply error>";
                        break;
                    case 'F':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Non-specific error>";
                        break;
                    case 'X':
                        text = text.Remove(num2 * 2 + 9, 2) + " <Format error>";
                        break;
                }
            }
            Clear();
            return text;
        }
        public string RemoveCRLF(string s)
        {
            s = s.Replace("\r", string.Empty).Replace("\n", string.Empty);
            return s;
        }
        public void Send(string s)
        {
            if (s != null && IsOpen())
            {
                ReceiveBuffer = "";
                byte[] bs = Command_(s).Commit();
                SerialPort_.Write(bs, 0, bs.Length);
                WriteSerialLog(bs, "TX");
            }
        }

        public void Send(byte[] bs)
        {
            if (bs != null && IsOpen())
            {
                ReceiveBuffer = "";
                SerialPort_.Write(bs, 0, bs.Length);
                WriteSerialLog(bs, "TX");
            }
        }
        public void Send(byte[] bs, Module.CommandType t)
        {
            if (bs != null)
            {
                CommandType = t;
                if (IsOpen())
                {
                    ReceiveBuffer = "";
                    SerialPort_.Write(bs, 0, bs.Length);
                    WriteSerialLog(bs, "TX");
                }
            }
        }
        public byte[] SetFrequency(string value)
        {
            return Command_("I60089").Data_(value).Commit();
        }
        public byte[] SetFrequencyAddrH(string value)
        {
            return Command_("I5008A").Data_(value).Commit();
        }
        public byte[] SetFrequencyAddrL(string value)
        {
            return Command_("I5008B").Data_(value).Commit();
        }
        public byte[] SetPower(string value)
        {
            return Command_("N1,").Data_(value).Commit();
        }
        public byte[]? SetRegulation(Module.Regulation value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return null;
            }
            object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: true);
            if (customAttributes != null && customAttributes.Length != 0)
            {
                return Command_("N5,").Data_(((DescriptionAttribute)customAttributes[0]).Description).Commit();
            }
            return null;
        }
        public static string ShowCRLF(string s)
        {
            s = s.Replace("\r", "<CR>").Replace("\n", "<LF>");
            return s;
        }
       
    }
}
