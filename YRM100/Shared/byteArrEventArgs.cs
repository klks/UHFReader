using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.Shared
{
    public class byteArrEventArgs : EventArgs
    {
        private readonly byte[] mData;

        public byte[] Data => mData;

        public byteArrEventArgs(byte[] byteArr)
        {
            mData = byteArr;
        }
    }
}
