using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCchip.Reader.API;

namespace ES_F3105U
{
    public enum MemBank : byte
    {
        RESERVED,
        EPC,
        TID,
        USER
    }

    public class Ref<T>
    {
        private readonly object _lockObject = new object();
        public Ref() { }
        public Ref(T value, string flagName)
        {
            lock (_lockObject)
            {
                FlagName = flagName;
                Value = value;
            }
        }
        public string FlagName { get; set; }
        public T Value { get; set; }
    }

    public class ReadWriteParsedData
    {
        public ReadWriteParsedData() { }
        public ErrorCode waitFlagStatus { get; set; }
        public ErrorCode readerStatusCode { get; set; }
        public uint TagCount { get; set; }
        public byte DataLen { get; set; }
        public uint PC { get; set; }
        public uint LenEPC { get; set; }
        public byte[]? RawEPC { get; set; }
        public string? StringEPC { get; set; }
        public uint CRC { get; set; }
        public byte[]? RawData { get; set; }
        public string? StringData { get; set; }
        public uint ReadLen { get; set; }
        public int AntID { get; set; }
        public int ReadCount { get; set; }
        public int ErrCode { get; set; }
    }
}
