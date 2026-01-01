using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public class RfidTransmissionParam
    {
        public byte ucParamVersion;

        public byte ucBaudRate;

        public byte ucTransferLink;

        public byte ucTransferProtocol;

        public byte ucWiegandProtocol;

        public byte ucWiegandPulseWidth;

        public byte ucWiegandPulsePeriod;

        public byte ucWiegandInterval;

        public byte ucWiegandPosition;

        public byte ucWiegandDirection;

        public byte[] mac_addr;

        public byte[] local_ip;

        public ushort local_port;

        public byte[] sub_mask_addr;

        public byte[] gateway;

        public byte[] remote_ip_addr;

        public ushort remote_port;

        public byte config_ip_mode;

        public byte heartBeates;

        public char[] syris_module_sn;

        public char syris_module_id;

        public RfidTransmissionParam()
        {
            mac_addr = new byte[6];
            local_ip = new byte[4];
            sub_mask_addr = new byte[4];
            gateway = new byte[4];
            remote_ip_addr = new byte[4];
            syris_module_sn = new char[9];
        }

        public void SetParamFromMessage(byte[] array, int offset)
        {
            int num = offset;
            ucParamVersion = array[num++];
            ucBaudRate = array[num++];
            ucTransferLink = array[num++];
            ucTransferProtocol = array[num++];
            ucWiegandProtocol = array[num++];
            ucWiegandPulseWidth = array[num++];
            ucWiegandPulsePeriod = array[num++];
            ucWiegandInterval = array[num++];
            ucWiegandPosition = array[num++];
            ucWiegandDirection = array[num++];
            Array.Copy(array, num, mac_addr, 0, 6);
            num += 6;
            Array.Copy(array, num, local_ip, 0, 4);
            num += 4;
            local_port = array[num++];
            local_port <<= 8;
            local_port += array[num++];
            Array.Copy(array, num, sub_mask_addr, 0, 4);
            num += 4;
            Array.Copy(array, num, gateway, 0, 4);
            num += 4;
            Array.Copy(array, num, remote_ip_addr, 0, 4);
            num += 4;
            remote_port = array[num++];
            remote_port <<= 8;
            remote_port += array[num++];
            config_ip_mode = array[num++];
            heartBeates = array[num++];
            for (int i = 0; i < 8; i++)
            {
                syris_module_sn[i] = (char)array[num++];
            }
            syris_module_sn[8] = '\0';
            syris_module_id = (char)array[num++];
        }

        public byte[] GetMessageDataFromParam()
        {
            int num = 0;
            byte[] array = new byte[64];
            byte[] array2 = null;
            array[num++] = 5;
            array[num++] = ucBaudRate;
            array[num++] = ucTransferLink;
            array[num++] = ucTransferProtocol;
            array[num++] = ucWiegandProtocol;
            array[num++] = ucWiegandPulseWidth;
            array[num++] = ucWiegandPulsePeriod;
            array[num++] = ucWiegandInterval;
            array[num++] = ucWiegandPosition;
            array[num++] = ucWiegandDirection;
            Array.Copy(mac_addr, 0, array, num, 6);
            num += 6;
            Array.Copy(local_ip, 0, array, num, 4);
            num += 4;
            array[num++] = (byte)((uint)(local_port >> 8) & 0xFFu);
            array[num++] = (byte)(local_port & 0xFFu);
            Array.Copy(sub_mask_addr, 0, array, num, 4);
            num += 4;
            Array.Copy(gateway, 0, array, num, 4);
            num += 4;
            Array.Copy(remote_ip_addr, 0, array, num, 4);
            num += 4;
            array[num++] = (byte)((uint)(remote_port >> 8) & 0xFFu);
            array[num++] = (byte)(remote_port & 0xFFu);
            array[num++] = config_ip_mode;
            array[num++] = heartBeates;
            for (int i = 0; i < 8; i++)
            {
                array[num++] = (byte)syris_module_sn[i];
            }
            array[num++] = (byte)syris_module_id;
            array2 = new byte[num];
            Array.Copy(array, 0, array2, 0, num);
            return array2;
        }
    }
}
