using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public struct CardInfo
    {
        public string TID;
        public string EPC;
        public string FullEPC;
        public string AccessPwd;
        public string KillPwd;
        public string UserData;
        public string PC;
        public string EPC_CRC;

        public int iTIDLen;
        public int iEPCLen;
        public int iFullEPCLen;
        public int iUserLen;

        public bool isCardAccessPWDLocked;
        public bool isCardKillPWDLocked;
        public bool isWavev2Card;

        public bool hasLockedUserBlocks;
        public List<int> arrUserBlocksLocked;

        //PC Flags
        public bool bPC_UMI;
        public bool bPC_XPC;
        public bool bPC_Toggle;
    }
}
