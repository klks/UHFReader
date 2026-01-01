using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class Transport
    {
        private delegate string ConnectSocketDelegate(IPEndPoint ipep, Socket sock);

        private string serialPortName;

        private int baudRate;

        private string localIP;

        private ushort localPort;

        private string remoteIP;

        private ushort remotPort;

        private TransportType transportType;

        private RfidSerialPort serialPort;

        private RfidReader notifyReader;

        private RfidNet readerSocket;

        private IPEndPoint localEnpoint;

        public IPEndPoint remoteEnpoint;

        public Transport(RfidReader notifyReader)
        {
            this.notifyReader = notifyReader;
        }

        public void SetSerialPortParam(string serialPortName, int baudRate)
        {
            this.serialPortName = serialPortName;
            this.baudRate = baudRate;
            transportType = TransportType.SerialPort;
        }

        public void SetIPParam(string localIP, ushort localPort, string remoteIP, ushort remotePort, TransportType type)
        {
            this.localIP = localIP;
            this.localPort = localPort;
            this.remoteIP = remoteIP;
            remotPort = remotePort;
            transportType = type;
            if (!remoteIP.Equals("255.255.255.255"))
            {
                remoteEnpoint = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort);
            }
            else
            {
                remoteEnpoint = new IPEndPoint(IPAddress.Broadcast, remotePort);
            }
            localEnpoint = new IPEndPoint(IPAddress.Parse(localIP), localPort);
        }

        private string ConnectSocket(IPEndPoint ipep, Socket sock)
        {
            string result = "";
            try
            {
                sock.Connect(ipep);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public bool RequestResource()
        {
            if (transportType == TransportType.SerialPort)
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort = null;
                }
                serialPort = new RfidSerialPort(serialPortName, baudRate, notifyReader);
                try
                {
                    serialPort.Open();
                }
                catch (Exception)
                {
                    return false;
                }
                return serialPort.IsOpen;
            }
            if (transportType == TransportType.UDP)
            {
                try
                {
                    readerSocket = new RfidNet(notifyReader, AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    readerSocket.Bind(localEnpoint);
                    readerSocket.SendBufferSize = 512;
                    readerSocket.ReceiveBufferSize = 1024;
                    if (remoteIP.Equals("255.255.255.255"))
                    {
                        readerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
                    }
                }
                catch (Exception)
                {
                    readerSocket.Close();
                    return false;
                }
                return true;
            }
            if (transportType == TransportType.TcpClient)
            {
                try
                {
                    if (readerSocket != null && readerSocket.Connected)
                    {
                        readerSocket.Close();
                    }
                    readerSocket = new RfidNet(notifyReader, AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    localEnpoint.Port = localPort;
                    readerSocket.Bind(localEnpoint);
                    readerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
                    ConnectSocketDelegate connectSocketDelegate = ConnectSocket;
                    IAsyncResult asyncResult = connectSocketDelegate.BeginInvoke(remoteEnpoint, readerSocket, null, null);
                    if (!asyncResult.AsyncWaitHandle.WaitOne(1000, exitContext: false))
                    {
                        readerSocket.Close();
                        return false;
                    }
                    if (!string.IsNullOrEmpty(connectSocketDelegate.EndInvoke(asyncResult)))
                    {
                        readerSocket.Close();
                        ReleaseResource();
                        return false;
                    }
                }
                catch (Exception)
                {
                    readerSocket.Close();
                    return false;
                }
                return true;
            }
            return false;
        }

        public void ReleaseResource()
        {
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort = null;
            }
            if (readerSocket != null)
            {
                if (readerSocket.Connected && transportType == TransportType.TcpClient)
                {
                    readerSocket.Disconnect(reuseSocket: false);
                }
                readerSocket.Shutdown(SocketShutdown.Both);
                readerSocket.Close();
                readerSocket.Dispose();
                readerSocket = null;
            }
        }

        public void SendData(byte[] sendBuffer, int offset, int sendLen)
        {
            if (transportType == TransportType.SerialPort)
            {
                if (serialPort == null)
                {
                    return;
                }
                Logger.LogCPH("SerialPort ==>", sendBuffer, offset, sendLen);
                serialPort.Write(sendBuffer, offset, sendLen);
            }
            if (readerSocket != null)
            {
                if (TransportType.UDP == transportType)
                {
                    Logger.LogCPH("UDP ==>", sendBuffer, offset, sendLen);
                    readerSocket.SendTo(sendBuffer, offset, sendLen, SocketFlags.None, remoteEnpoint);
                }
                else if (TransportType.TcpClient == transportType)
                {
                    Logger.LogCPH("TcpClient ==>", sendBuffer, offset, sendLen);
                    readerSocket.Send(sendBuffer, offset, sendLen, SocketFlags.None);
                }
            }
        }

        public void HandleRecvData()
        {
            if (transportType == TransportType.SerialPort)
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.HandleRecv();
                }
            }
            else if (TransportType.UDP == transportType || TransportType.TcpClient == transportType)
            {
                readerSocket.HandleRecv();
            }
            else
            {
                _ = 4;
                _ = transportType;
            }
        }
    }
}
