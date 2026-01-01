using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class AsyncSocketEventArgs : EventArgs
    {
        public string _msg;

        public AsyncSocketState _state;

        public bool IsHandled { get; set; }

        public AsyncSocketEventArgs(string msg)
        {
            _msg = msg;
            IsHandled = false;
        }

        public AsyncSocketEventArgs(AsyncSocketState state)
        {
            _state = state;
            IsHandled = false;
        }

        public AsyncSocketEventArgs(string msg, AsyncSocketState state)
        {
            _msg = msg;
            _state = state;
            IsHandled = false;
        }
    }
}
