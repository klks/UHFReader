using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRM100.Shared
{
    /// <summary>
    /// It Extends from EventArgs, Data is string[] type
    /// </summary>
    public class StrArrEventArgs : EventArgs
    {
        private readonly string[] mData;

        /// <summary>
        /// StrArrEventArgs Data Property
        /// </summary>
        public string[] Data => mData;

        /// <summary>
        /// Constructor, build a StrArrEventArgs from string[]
        /// </summary>
        /// <param name="strArr">Data</param>
        public StrArrEventArgs(string[] strArr)
        {
            mData = strArr;
        }
    }
}
