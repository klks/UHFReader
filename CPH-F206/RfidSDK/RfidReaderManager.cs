using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    internal class RfidReaderManager
    {
        private static RfidReaderManager _instance;

        private bool end_thread_flag;

        private Thread recv_thread;

        private List<RfidReader> readers = new List<RfidReader>();

        private Mutex listMutex = new Mutex(initiallyOwned: false);

        private RfidReaderManager()
        {
            recv_thread = new Thread(HandleRecvThread);
            recv_thread.IsBackground = true;
            recv_thread.Start();
            readers.Clear();
        }

        public static RfidReaderManager Instance()
        {
            if (_instance == null)
            {
                _instance = new RfidReaderManager();
            }
            return _instance;
        }

        private void HandleRecvThread()
        {
            while (!end_thread_flag)
            {
                try
                {
                    listMutex.WaitOne();
                    RfidReader[] array = readers.ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].HandleRecvData();
                    }
                }
                finally
                {
                    listMutex.ReleaseMutex();
                }
                Thread.Sleep(10);
            }
        }

        private void AddRfidReader(RfidReader reader)
        {
            try
            {
                listMutex.WaitOne();
                readers.Add(reader);
            }
            finally
            {
                listMutex.ReleaseMutex();
            }
        }

        private void DelRfidReader(RfidReader reader)
        {
            try
            {
                listMutex.WaitOne();
                readers.Remove(reader);
            }
            finally
            {
                listMutex.ReleaseMutex();
            }
        }

        public void DeleteAllReader()
        {
            try
            {
                listMutex.WaitOne();
                RfidReader[] array = readers.ToArray();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].ReleaseResource();
                }
                readers.Clear();
            }
            finally
            {
                listMutex.ReleaseMutex();
            }
        }

        public RfidReader CreateReaderInSerialPort(string portName, int baudRate, RfidReaderRspNotify notify)
        {
            RfidReader rfidReader = new MSerialReader(notify);
            rfidReader.SetSerialParam(portName, baudRate);
            if (rfidReader.RequestResource())
            {
                Instance().AddRfidReader(rfidReader);
                return rfidReader;
            }
            return null;
        }

        public RfidReader CreateReaderInNet(string localIP, ushort localPort, string readerIP, ushort readerPort, TransportType type, RfidReaderRspNotify notify)
        {
            RfidReader rfidReader = new MSerialReader(notify);
            rfidReader.SetEthernetParam(localIP, localPort, readerIP, readerPort, type);
            if (rfidReader.RequestResource())
            {
                Instance().AddRfidReader(rfidReader);
                return rfidReader;
            }
            return null;
        }

        public void ReleaseRfidReader(RfidReader reader)
        {
            if (reader != null)
            {
                Instance().DelRfidReader(reader);
                reader.ReleaseResource();
            }
        }
    }
}
