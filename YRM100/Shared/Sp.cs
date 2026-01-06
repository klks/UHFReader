using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.Sockets;

namespace YRM100.Shared
{

    public class Sp
    {
        public SerialPort ComDevice = new SerialPort();

        private static readonly Sp instance = new Sp();

        private int communicatBaudrate = 115200;

        public bool Listening;

        public bool Closing;

        public TcpClient mTcpClient = new TcpClient();

        public NetworkStream serverStream;

        private bool bConnected;

        public int CommunicatType;

        public const int DefaultBufferSize = 16384;

        private byte[] _recvDataBuffer = new byte[16384];

        public event EventHandler<byteArrEventArgs> DataSent;

        public event EventHandler<byteArrEventArgs> DataReceived;

        private Sp()
        {
            ComDevice.PortName = "COM1";
            ComDevice.BaudRate = 9600;
            ComDevice.Parity = Parity.None;
            ComDevice.DataBits = 8;
            ComDevice.StopBits = StopBits.One;
            ComDevice.NewLine = "/r/n";
        }

        public static Sp GetInstance()
        {
            return instance;
        }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public void Config(string port, int baudrate, Parity p, int databits, StopBits s)
        {
            ComDevice.PortName = port;
            ComDevice.BaudRate = baudrate;
            ComDevice.Parity = p;
            ComDevice.DataBits = 8;
            ComDevice.StopBits = s;
        }

        public bool Open()
        {
            if (ComDevice.IsOpen)
            {
                return true;
            }
            try
            {
                ComDevice.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open Port Fail, " + ex.Message);
                return false;
            }
            Console.WriteLine("Port Opened, ");
            return true;
        }

        public bool Close()
        {
            Closing = true;
            if (!ComDevice.IsOpen)
            {
                Closing = false;
                return true;
            }
            try
            {
                while (Listening)
                {
                    Application.DoEvents();
                }
                ComDevice.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Close Port Fail, " + ex.Message);
                Closing = false;
                return false;
            }
            Closing = false;
            Console.WriteLine("Closed Port, ");
            return true;
        }

        public bool IsOpen()
        {
            if (CommunicatType == 1)
            {
                if (mTcpClient != null && mTcpClient.Connected)
                {
                    return true;
                }
                return false;
            }
            return ComDevice.IsOpen;
        }

        public void SetCommunicatBaudRate(int baudrate)
        {
            communicatBaudrate = baudrate;
        }

        public int GetCommunicateBaudRate()
        {
            return communicatBaudrate;
        }

        private void ComDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        }

        public int Send(string hexText)
        {
            if (hexText.Length > 0)
            {
                if ((CommunicatType == 0 && ComDevice.IsOpen) || (CommunicatType == 1 && mTcpClient.Connected))
                {
                    byte[] array = null;
                    string text = hexText;
                    try
                    {
                        text = text.Replace(" ", "");
                        if (text.Length % 2 == 1)
                        {
                            text = text.Remove(text.Length - 1, 1);
                        }
                        List<string> list = new List<string>();
                        for (int i = 0; i < text.Length; i += 2)
                        {
                            list.Add(text.Substring(i, 2));
                        }
                        array = new byte[list.Count];
                        for (int j = 0; j < array.Length; j++)
                        {
                            array[j] = (byte)Convert.ToInt32(list[j], 16);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please Use HEX words!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return 0;
                    }
                    if (CommunicatType == 1)
                    {
                        try
                        {
                            tcBeginSend(array);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            bConnected = false;
                        }
                    }
                    else
                    {
                        ComDevice.Write(array, 0, array.Length);
                    }
                    if (this.DataSent != null)
                    {
                        this.DataSent(this, new byteArrEventArgs(array));
                    }
                    return array.Length;
                }
                MessageBox.Show("Please Connect Serial Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            MessageBox.Show("Please Write Send Data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return 0;
        }

        public void DownLoadFW(string fileName)
        {
            if (ComDevice.IsOpen)
            {
                Send("FE");
                Thread.Sleep(10);
                switch (communicatBaudrate)
                {
                    case 115200:
                        Send("B5");
                        break;
                    case 57600:
                        Send("B4");
                        break;
                    case 38400:
                        Send("B3");
                        break;
                    case 28800:
                        Send("B2");
                        break;
                    case 19200:
                        Send("B1");
                        break;
                    case 9600:
                        Send("B0");
                        break;
                    default:
                        Send("B5");
                        break;
                }
                Thread.Sleep(10);
                ComDevice.DiscardInBuffer();
                ComDevice.DiscardOutBuffer();
                Closing = true;
                while (Listening)
                {
                    Application.DoEvents();
                }
                ComDevice.Close();
                Closing = false;
                ComDevice.BaudRate = communicatBaudrate;
                ComDevice.Open();
                Send("DB");
                Thread.Sleep(10);
                Send("FD");
                Thread.Sleep(10);
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                byte[] array = new byte[(int)fileStream.Length];
                binaryReader.Read(array, 0, array.Length);
                ComDevice.Write(array, 0, array.Length);
                Send("D3 D3 D3 D3 D3 D3");
                Thread.Sleep(10);
                binaryReader.Close();
                fileStream.Close();
            }
            else
            {
                MessageBox.Show("Please Open COM Port First!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected virtual void tcConnectAsync(string ip, int ipport)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.BeginConnect(ip, ipport, tcConnected, tcpClient);
        }

        protected virtual void tcConnected(IAsyncResult iar)
        {
            try
            {
                mTcpClient = (TcpClient)iar.AsyncState;
                mTcpClient.EndConnect(iar);
                serverStream = mTcpClient.GetStream();
                serverStream.BeginRead(_recvDataBuffer, 0, 16384, tcRecvData, serverStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                bConnected = false;
                return;
            }
            bConnected = true;
        }

        protected virtual void tcBeginSend(byte[] datagram)
        {
            if (datagram.Length != 0)
            {
                if (!bConnected)
                {
                    throw new ApplicationException("No connection to the server, unable to send data.");
                }
                if (serverStream.CanWrite)
                {
                    serverStream.BeginWrite(datagram, 0, datagram.Length, tcSendDataEnd, serverStream);
                }
            }
        }

        protected virtual void tcSendDataEnd(IAsyncResult iar)
        {
            NetworkStream networkStream = (NetworkStream)iar.AsyncState;
            if (networkStream.CanWrite)
            {
                networkStream.EndWrite(iar);
            }
        }

        protected virtual void tcRecvData(IAsyncResult iar)
        {
            try
            {
                NetworkStream networkStream = (NetworkStream)iar.AsyncState;
                if (networkStream.CanRead)
                {
                    int num = networkStream.EndRead(iar);
                    if (num == 0)
                    {
                        if (mTcpClient != null)
                        {
                            if (serverStream != null)
                            {
                                serverStream.Close();
                            }
                            mTcpClient.Close();
                        }
                        bConnected = false;
                        Console.WriteLine("The remote host compulsory closing connection!");
                        return;
                    }
                    byte[] array = new byte[num];
                    for (int i = 0; i < num; i++)
                    {
                        array[i] = _recvDataBuffer[i];
                    }
                    if (this.DataReceived != null)
                    {
                        this.DataReceived(this, new byteArrEventArgs(array));
                    }
                }
                if (serverStream.CanRead)
                {
                    serverStream.BeginRead(_recvDataBuffer, 0, 16384, tcRecvData, serverStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                if (mTcpClient != null)
                {
                    if (serverStream != null)
                    {
                        serverStream.Close();
                    }
                    mTcpClient.Close();
                }
                bConnected = false;
            }
        }

        public bool Connect(string hostname, int baudorport)
        {
            if (mTcpClient != null && mTcpClient.Connected)
            {
                return true;
            }
            bConnected = false;
            try
            {
                tcConnectAsync(hostname, baudorport);
                int num = 100;
                while (num-- > 0 && !bConnected)
                {
                    Thread.Sleep(20);
                }
                CommunicatType = 1;
                if (!bConnected)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect IP Fail, " + ex.Message);
                return false;
            }
            Console.WriteLine("IP Connected, ");
            return true;
        }

        public bool Disconnect()
        {
            Closing = true;
            if (!mTcpClient.Connected)
            {
                Closing = false;
                return true;
            }
            try
            {
                while (Listening)
                {
                    Application.DoEvents();
                }
                if (mTcpClient != null)
                {
                    if (serverStream != null)
                    {
                        serverStream.Close();
                    }
                    mTcpClient.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Disconnect IP Fail, " + ex.Message);
                Closing = false;
                return false;
            }
            Closing = false;
            Console.WriteLine("Disconnect IP, ");
            return true;
        }
    }
}
