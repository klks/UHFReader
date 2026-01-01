using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class RfidTcpServer : IDisposable
    {
        private int _maxClient;

        private int _clientCount;

        private Socket _serverSock;

        private List<AsyncSocketState> _clients;

        private bool disposed;

        public bool IsRunning { get; private set; }

        public IPAddress Address { get; private set; }

        public int Port { get; private set; }

        public Encoding Encoding { get; set; }

        public event EventHandler<AsyncSocketEventArgs> ClientConnected;

        public event EventHandler<AsyncSocketEventArgs> ClientDisconnected;

        public event EventHandler<AsyncSocketEventArgs> DataReceived;

        public event EventHandler<AsyncSocketEventArgs> PrepareSend;

        public event EventHandler<AsyncSocketEventArgs> CompletedSend;

        public event EventHandler<AsyncSocketEventArgs> NetError;

        public event EventHandler<AsyncSocketEventArgs> OtherException;

        public RfidTcpServer()
        {
        }

        public RfidTcpServer(IPAddress localIPAddress, int listenPort, int maxClient)
        {
            Address = localIPAddress;
            Port = listenPort;
            Encoding = Encoding.Default;
            _maxClient = maxClient;
            _clients = new List<AsyncSocketState>();
            _serverSock = new Socket(localIPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool SetServerAddress(string localIP, int listenPort, int maxClient)
        {
            if (IPAddress.TryParse(localIP, out var address))
            {
                Address = address;
                Port = listenPort;
                Encoding = Encoding.Default;
                _maxClient = maxClient;
                _clients = new List<AsyncSocketState>();
                _serverSock = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                return true;
            }
            return false;
        }

        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                _serverSock.Bind(new IPEndPoint(Address, Port));
                _serverSock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                _serverSock.Listen(128);
                _serverSock.BeginAccept(HandleAcceptConnected, _serverSock);
            }
        }

        public void Stop()
        {
            if (!IsRunning)
            {
                return;
            }
            IsRunning = false;
            lock (_clients)
            {
                AsyncSocketState[] array = _clients.ToArray();
                foreach (AsyncSocketState asyncSocketState in array)
                {
                    asyncSocketState.ClientSocket.Shutdown(SocketShutdown.Both);
                    asyncSocketState.ClientSocket.Disconnect(reuseSocket: false);
                    _clients.Remove(asyncSocketState);
                }
                _serverSock.Close();
            }
        }

        private void HandleEndAccept(IAsyncResult ar)
        {
        }

        private void HandleAcceptConnected(IAsyncResult ar)
        {
            if (!IsRunning)
            {
                return;
            }
            Socket socket = (Socket)ar.AsyncState;
            Socket socket2 = socket.EndAccept(ar);
            if (_clientCount >= _maxClient)
            {
                RaiseOtherException(null);
            }
            else
            {
                AsyncSocketState asyncSocketState = new AsyncSocketState(socket2);
                lock (_clients)
                {
                    _clients.Add(asyncSocketState);
                    _clientCount++;
                    RaiseClientConnected(asyncSocketState);
                }
                socket2.BeginReceive(asyncSocketState.RecvDataBuffer, 0, asyncSocketState.RecvDataBuffer.Length, SocketFlags.None, HandleDataReceived, asyncSocketState);
            }
            socket.BeginAccept(HandleAcceptConnected, ar.AsyncState);
        }

        private void HandleDataReceived(IAsyncResult ar)
        {
            int num = 0;
            if (!IsRunning)
            {
                return;
            }
            AsyncSocketState asyncSocketState = (AsyncSocketState)ar.AsyncState;
            Socket clientSocket = asyncSocketState.ClientSocket;
            try
            {
                num = clientSocket.EndReceive(ar);
            }
            catch (SocketException)
            {
                num = 0;
            }
            if (num == 0)
            {
                lock (_clients)
                {
                    RaiseClientDisconnected(asyncSocketState);
                    _clients.Remove(asyncSocketState);
                    Close(asyncSocketState);
                    return;
                }
            }
            RaiseDataReceived(asyncSocketState);
            try
            {
                clientSocket.BeginReceive(asyncSocketState.RecvDataBuffer, 0, asyncSocketState.RecvDataBuffer.Length, SocketFlags.None, HandleDataReceived, asyncSocketState);
            }
            catch (Exception)
            {
            }
        }

        public void Send(AsyncSocketState state, byte[] data)
        {
            RaisePrepareSend(state);
            Send(state.ClientSocket, data);
        }

        public void Send(Socket client, byte[] data)
        {
            if (!IsRunning)
            {
                throw new InvalidProgramException("This TCP Scoket server has not been started.");
            }
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            client.BeginSend(data, 0, data.Length, SocketFlags.None, SendDataEnd, client);
        }

        private void SendDataEnd(IAsyncResult ar)
        {
            ((Socket)ar.AsyncState).EndSend(ar);
            RaiseCompletedSend(null);
        }

        private void RaiseClientConnected(AsyncSocketState state)
        {
            if (this.ClientConnected != null)
            {
                this.ClientConnected(this, new AsyncSocketEventArgs(state));
            }
        }

        private void RaiseClientDisconnected(AsyncSocketState client)
        {
            if (this.ClientDisconnected != null)
            {
                this.ClientDisconnected(this, new AsyncSocketEventArgs(client));
            }
        }

        public byte CaculateCheckSum(byte[] recv_buff, int recv_len)
        {
            byte b = 0;
            for (int i = 0; i < recv_len; i++)
            {
                b += recv_buff[i];
            }
            return (byte)(~b + 1);
        }

        private void RaiseDataReceived(AsyncSocketState state)
        {
            if (this.DataReceived != null)
            {
                this.DataReceived(this, new AsyncSocketEventArgs(state));
            }
        }

        private void RaisePrepareSend(AsyncSocketState state)
        {
            if (this.PrepareSend != null)
            {
                this.PrepareSend(this, new AsyncSocketEventArgs(state));
            }
        }

        private void RaiseCompletedSend(AsyncSocketState state)
        {
            if (this.CompletedSend != null)
            {
                this.CompletedSend(this, new AsyncSocketEventArgs(state));
            }
        }

        private void RaiseNetError(AsyncSocketState state)
        {
            if (this.NetError != null)
            {
                this.NetError(this, new AsyncSocketEventArgs(state));
            }
        }

        private void RaiseOtherException(AsyncSocketState state, string descrip)
        {
            if (this.OtherException != null)
            {
                this.OtherException(this, new AsyncSocketEventArgs(descrip, state));
            }
        }

        private void RaiseOtherException(AsyncSocketState state)
        {
            RaiseOtherException(state, "");
        }

        public void Close(AsyncSocketState state)
        {
            if (state != null)
            {
                state.Datagram = null;
                state.RecvDataBuffer = null;
                _clients.Remove(state);
                _clientCount--;
                state.Close();
            }
        }

        public void CloseAllClient()
        {
            foreach (AsyncSocketState client in _clients)
            {
                Close(client);
            }
            _clientCount = 0;
            _clients.Clear();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                try
                {
                    Stop();
                    if (_serverSock != null)
                    {
                        _serverSock = null;
                    }
                }
                catch (SocketException)
                {
                    RaiseOtherException(null);
                }
            }
            disposed = true;
        }
    }
}
