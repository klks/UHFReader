using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Utilities
{
    public class DigitsICDB
    {
        public string? mdid { get; set; }
        public string? manufacturer { get; set; }
        public string? manufacturerUrl { get; set; }
        public string? tmn { get; set; }
        public string? modelName { get; set; }
        public string? productUrl { get; set; }
        public string? note { get; set; }
    }
    public class DigitsMDID
    {
        public string? name { get; set; }
        public string? publisher { get; set; }
        public string? version { get; set; }
        public string? sourceUrl { get; set; }
        public string? email { get; set; }
        public List<DigitsMDID_Designers>? registeredMaskDesigners { get; set; }
    }

    public class DigitsMDID_Designers
    {
        public string? mdid { get; set; }
        public string? manufacturer { get; set; }
        public string? manufacturerUrl { get; set; }
        public List<DigitsMDID_Chips>? chips { get; set; }
    }

    public class DigitsMDID_Chips
    {
        public string? tmnHex { get; set; }
        public string? tmnBinary { get; set; }
        public string? modelName { get; set; }
        public string? productUrl { get; set; }
        public string? note { get; set; }
    }
}