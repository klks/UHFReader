using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class CardJson
    {
        public string? TID { get; set; }
        public string? EPC { get; set; }
        public string? FullEPC { get; set; }
        public string? UserData { get; set; }
        public string? AccessKey { get; set; }
        public string? KillKey { get; set; }
        public string? CRC { get; set; }
        public string? PC { get; set; }
        public bool isCardAccessPWDLocked { get; set; }
        public bool isCardKillPWDLocked { get; set; }
        public bool isWavev2Card { get; set; }

    }
}
