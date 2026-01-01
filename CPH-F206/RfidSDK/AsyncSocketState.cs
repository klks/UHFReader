using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class AsyncSocketState
    {
        public byte[] _recvBuffer;

        private string _datagram;

        private Socket _clientSock;

        public EnRecvStage _recvStage { get; set; }

        public int _messageLen { get; set; }

        public byte[] RecvDataBuffer
        {
            get
            {
                return _recvBuffer;
            }
            set
            {
                _recvBuffer = value;
            }
        }

        public string Datagram
        {
            get
            {
                return _datagram;
            }
            set
            {
                _datagram = value;
            }
        }

        public Socket ClientSocket => _clientSock;

        public AsyncSocketState(Socket cliSock)
        {
            _clientSock = cliSock;
            InitBuffer();
        }

        public void InitBuffer()
        {
            if (_recvBuffer == null && _clientSock != null)
            {
                _recvBuffer = new byte[_clientSock.ReceiveBufferSize];
            }
        }

        public void Close()
        {
            _clientSock.Shutdown(SocketShutdown.Both);
            _clientSock.Close();
        }
    }
}
