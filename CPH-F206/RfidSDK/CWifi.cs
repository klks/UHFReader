using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class CUserHttpParam
    {
        public byte protocolRole;

        public byte addrType;

        public string addr;

        public ushort port;

        public ushort heartbeatInterval;
    }

    public class CUserWifi
    {
        public string apName;

        public string apPwd;

        public string staName;

        public string staPwd;
    }

    public class CUserWifiIP
    {
        public byte connectStatus;

        public byte dhcpMode;

        public byte[] arrIP = new byte[4];

        public byte[] arrMask = new byte[4];

        public byte[] arrGateWay = new byte[4];

        public byte[] arrMac = new byte[6];
    }

    public class CWifiAPInfo
    {
        public bool bEnable;

        public byte channelid;

        public byte encryptType;

        public string ssid;

        public string password;

        public byte[] baseid = new byte[64];
    }

    public class CWifiConnInfo
    {
        public byte protocolRole;

        public ushort port;

        public ushort localPort;

        public byte ipMode;

        public byte[] ipAddr = new byte[64];
    }

    public class CWifiStaInfo
    {
        public bool bEnable;

        public byte dhcpMode;

        public byte ipMode;

        public string ssid;

        public string password;

        public byte[] bassid = new byte[64];

        public byte[] ipAddr = new byte[64];

        public byte[] netmask = new byte[64];

        public byte[] gateway = new byte[64];

        public CWifiStaInfo()
        {
            bEnable = false;
            dhcpMode = 1;
            ipMode = 0;
            ssid = "";
            password = "";
            Array.Clear(bassid, 0, 64);
            Array.Clear(ipAddr, 0, 64);
            Array.Clear(netmask, 0, 64);
            Array.Clear(gateway, 0, 64);
        }
    }
}
