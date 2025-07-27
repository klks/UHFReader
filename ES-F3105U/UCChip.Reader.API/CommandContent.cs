using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCchip.Reader.API
{
    public class CommandContent
    {
        public const byte Head = 0xA0;

        public byte Length { get;private set; }

        public byte Address { get; set; }

        public byte Command { get; set; }

        public byte[]? Data { get; set; }

        public byte CheckSum { get; private set; }

        public byte[] GetCommandBytes()
        {
            List<byte> bytes = new List<byte>();
            if (Data != null)
            {
                Length = (byte)(1 + 1 + Data.Length + 1);
                
                bytes.Add(Head);
                bytes.Add(Length);
                bytes.Add(Address);
                bytes.Add((byte)Command);
                bytes.AddRange(Data);

                CheckSum = GetCheckSum(bytes);

                bytes.Add(CheckSum);
            }
            return bytes.ToArray();

        }

        public static Byte GetCheckSum(IList<byte> bytes)
        {
            Byte checksum = 0x00;

            foreach (byte bt in bytes)
            {
                checksum += bt;
            }

            checksum = (byte)~checksum;
            checksum += 1;

            return checksum;
        }

        public static byte GetCheckSum(byte[] buffer, byte length)
        {
            byte checksum = 0x00;
            for (int i = 0; i < length; i++)
            {
                checksum += buffer[i];
            }

            checksum = (byte)((byte)~checksum + (byte)1);

            return checksum;
        }
    }
}
