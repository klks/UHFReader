using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace UCchip.Reader.API
{
    public class UCchipClient : IDisposable
    {
        #region message output

        /// <summary>
        /// Subscribe to com information, including input and output
        /// </summary>
        /// <param name="message"></param>
        public delegate void DelegateSerialPortLog(string message);
        public DelegateSerialPortLog? SerialPortLog;

        /// <summary>
        /// Subscribe to com information, including input and output
        /// </summary>
        /// <param name="message"></param>
        public delegate void DelegateAPILog(string message);
        public DelegateAPILog? APILog;

        /// <summary>
        /// Split, buffer returned one command at a time
        /// </summary>
        /// <param name="buffer"></param>
        public delegate void DelegateSerialPortReceivedResponce(byte[] buffer);
        public DelegateSerialPortReceivedResponce? CommandResponseReceived;

        // Entrust, upgrade the lower computer software and return status and other information
        public delegate void GetUpgrageCallback(long DataLength, long DataCount);

        private async void WriteAPILog(string message)
        {
            if (APILog != null)
                APILog(message);
        }

        private async void WriteSerialLog(string message)
        {
            if (SerialPortLog != null)
                SerialPortLog(message);
        }

        // start a timer
        System.Timers.Timer Upgradetimer = new System.Timers.Timer(5000);

        private void SendOutCommandResponse(byte[] cmdResponse)
        {
            if (CommandResponseReceived != null)
                CommandResponseReceived(cmdResponse);

            int bufLen = cmdResponse.Length;
            if(bufLen < 5)
            {
                return;
            }
            int dataLen = bufLen - 5;
            int index = 0;

            var commandContent = new CommandContent();
            index++;                                                    //head
            index++;                                                    //len
            commandContent.Address = cmdResponse[index++];              //addr
            commandContent.Command = cmdResponse[index++];              //cmd
            if(dataLen > 0)                                             //data
            {
                commandContent.Data = cmdResponse.Skip(index).Take(dataLen).ToArray();
            }
            else
            {
                commandContent.Data = Array.Empty<byte>();
            }
            index += dataLen;
            index++;                                                    //crc

            ResponseUnpacket(commandContent.Command, commandContent.Data);

            WriteAPILog("[SendOutCommandResponse] index: " + index);
        }

        private void ResponseUnpacket(byte cmd, byte[] data)
        {
            uint index = 0;
            int packetnum = 0;
            byte temp = 0;

            WriteAPILog("[ResponseUnpacket] Parsed data: " + ToHexString(data));

            if(ReponseCommand == (int)cmd)
            {
                ResponseFlag = true;
                Upgradetimer.Stop();
                WriteAPILog("[ResponseUnpacket] Reply received.");
            }

            switch (cmd)
            {
                case (byte)(Commands.cmd_reader_app_upgrade):
                    temp = data[index++];
                    packetnum = temp * 256 * 256 * 256;
                    temp = data[index++];
                    packetnum += temp * 256 * 256;
                    temp = data[index++];
                    packetnum += temp * 256;
                    temp = data[index++];
                    packetnum += temp;

                    temp = data[index++];
                    if(packetnum == parameter.packetcount)
                    {
                        parameter.gradestatus = 0x01;
                        if (temp == 0x00)
                        {
                            WriteAPILog("[ResponseUnpacket] The instructions received for the upgrade are correct -- 8088.");
                        }
                        else if (temp == 0x01)
                        {
                            WriteAPILog("[ResponseUnpacket] The upgrade is complete.");
                        }
                    }
                    else
                    {
                        WriteAPILog("[ResponseUnpacket] Error response -- 8088.");
                        parameter.gradestatus = 0x02;
                    }
                    break;
                case (byte)(Commands.cmd_baseband_firmware_upgrade):
                    temp = data[index++];
                    packetnum = temp * 256 * 256 * 256;
                    temp = data[index++];
                    packetnum += temp * 256 * 256;
                    temp = data[index++];
                    packetnum += temp * 256;
                    temp = data[index++];
                    packetnum += temp;

                    temp = data[index++];
                    if (packetnum == parameter.packetcount)
                    {
                        parameter.gradestatus = 0x01;
                        if (temp == 0x00)
                        {
                            WriteAPILog("[ResponseUnpacket] The instructions received for the upgrade are correct -- 8688.");
                        }
                        else if (temp == 0x01)
                        {
                            WriteAPILog("[ResponseUnpacket] Upgrade completed.");
                        }
                    }
                    else
                    {
                        WriteAPILog("[ResponseUnpacket] Error response -- 8688.");
                        parameter.gradestatus = 0x02;
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region port open and close
        public static List<string> GetCOMportList()
        {
            try
            {
                return System.IO.Ports.SerialPort.GetPortNames().ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        public string PortName { get; set; }
        public int Rate { get; set; }
        public int Timeout { get; set; }
        public int ReponseCommand { get; set; }
        public bool ResponseFlag = true;

        private System.IO.Ports.SerialPort? InternalPortInstance { get; set; }

        /*
            Open serial port
            portRate: serial port number and baud rate (com0:115200)
            timeoutMS:
            status: output status (find error code table)
            Example: OpenSerial("COM15" + ":115200", 3000, out status);
       */
        public bool OpenSerial(string portRate, int timeoutMS, out ErrorCode status)
        {
            if (ChannelSelect == 0)
            {
                if (string.IsNullOrEmpty(portRate))
                {
                    status = ErrorCode.ParameterError;
                    return false;
                }

                //("COM16:115200")
                var paramArrary = portRate.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (paramArrary.Length != 2)
                {
                    status = ErrorCode.ParameterError;
                    return false;
                }

                PortName = paramArrary[0];
                int intRate;
                if (!int.TryParse(paramArrary[1], out intRate))
                {
                    status = ErrorCode.ParameterError;
                    return false;
                }
                Rate = intRate;

                status = ErrorCode.OK;

                Timeout = timeoutMS;

                if (!OpenPort())
                {
                    status = ErrorCode.SystemError;
                    return false;
                }
                return true;

            }
            status = ErrorCode.SystemError;
            return false;
        }

        private bool OpenPort()
        {
            if (InternalPortInstance != null)
            {
                try
                {
                    if (InternalPortInstance.IsOpen)
                    {
                        InternalPortInstance.Close();
                    }
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                InternalPortInstance = new System.IO.Ports.SerialPort();
                InternalPortInstance.PortName = PortName;
                InternalPortInstance.BaudRate = Rate;
                InternalPortInstance.ReadTimeout = Timeout;
                InternalPortInstance.WriteTimeout = Timeout;

                try
                {
                    InternalPortInstance.DiscardInBuffer();
                }
                catch {}

                try
                {
                    InternalPortInstance.DiscardOutBuffer();
                }
                catch { }
                

                InternalPortInstance.DataReceived += InternalPortInstance_DataReceived;
            }

            try
            {
                InternalPortInstance.Open();
            }
            catch
            {
                return false;
            }

            if (!InternalPortInstance.IsOpen)
            {
                return false;
            }
            else
            {
                ChannelSelect = 1;
                return true;
            }

        }

        /*
            Close serial port
            status: output status (find error code table)
       */
        public bool CloseSerial(out ErrorCode status)
        {
            ChannelSelect = 0;

            if (InternalPortInstance == null)
            {
                status = ErrorCode.OK;
                return true;
            }

            InternalPortInstance.DataReceived -= InternalPortInstance_DataReceived;

            try
            {
                InternalPortInstance.Close();
            }
            catch
            {
                status = ErrorCode.SystemError;
                return false;
            }

            if (InternalPortInstance.IsOpen)
            {
                status = ErrorCode.SystemError;
                return false;
            }

            InternalPortInstance = null;

            status = ErrorCode.OK;
            return true;
        }

        #endregion

        private void GetDataFromPort()
        {

        }
        /*
            Encapsulate data packets according to serial communication protocol
            cmd: command word (query command word table)
            address: communication address (0x00)
            data: data segment, refer to the serial port protocol ({ 0x01, 0x02, 0x03 })
            Example: SendCommand(cmd_set_beep_mode, 0x00, { 0x01 })
       */
        public ErrorCode SendCommand(Commands cmd, byte address = 0x00, byte[]? data = null)
        {
            var commandContent = new CommandContent();
            commandContent.Data = data == null ? new byte[] {  } : data;
            commandContent.Command = (byte)cmd;
            commandContent.Address = address;

            return WriteData(commandContent.GetCommandBytes());
        }

        public void InitResponseTimer()
        {
            if (!parameter.TimerInit)
            {
                Upgradetimer.Elapsed += new System.Timers.ElapsedEventHandler(TimeroutEvent);
                Upgradetimer.AutoReset = false;  // Not executed periodically
                Upgradetimer.Enabled = true;     // Execute timer event
                parameter.TimerInit = true;
            }
        }

        /*
            Reader reset
            Example: 
       */
        public ErrorCode MsgBaseReset()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_reset;

                commandContent.Command = (byte)Commands.cmd_reset;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseReset] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader serial port baud rate
            baudrate: baud rate number
            Example: MsgBaseSetUartBoudrate(0x09)
       */
        public ErrorCode MsgBaseSetUartBoudrate(byte baudrate)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_uart_baudrate;

                commandContent.Command = (byte)Commands.cmd_set_uart_baudrate;
                commandContent.Address = 0x00;

                commandContent.Data = new byte[1] { baudrate };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetUartBoudrate] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //0x72 -- Get the firmware version of the reader
        public ErrorCode MsgBaseGetFirmwareVer()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_firmware_version;

                commandContent.Command = (byte)Commands.cmd_get_firmware_version;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetFirmwareVer] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader/writer communication address
            address: communication address (0x00)
            Example: MsgBaseSetReaderAddress(0x01);
       */
        public ErrorCode MsgBaseSetReaderAddress(byte address)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_reader_address;

                commandContent.Command = (byte)Commands.cmd_set_reader_address;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { address };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetReaderAddress] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the working antenna of the reader
            address: communication address (0x00)
            Example: MsgBaseSetWorkAntenna(0x00); -- Antenna 1~Antenna 8 -》 0x01~0x08
       */
        public ErrorCode MsgBaseSetWorkAntenna(byte antennaid)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_work_antenna;

                commandContent.Command = (byte)Commands.cmd_set_work_antenna;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { antennaid };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetWorkAntenna] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Get the reader working antenna
       */
        public ErrorCode MsgBaseGetWorkAntenna()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_work_antenna;

                commandContent.Command = (byte)Commands.cmd_get_work_antenna;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetWorkAntenna] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader's RF transmission power -- Single antenna
            rfpower: Transmit power (0x21)
            Example: MsgBaseSetOutputPower(0x21); -- 0~33(0~0x21)dbm
       */
        public ErrorCode MsgBaseSetOutputPower(byte rfpower)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_output_power;

                commandContent.Command = (byte)Commands.cmd_set_output_power;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { rfpower };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetOutputPower] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader's RF transmission power -- 4 antennas
            ant1power: Transmit power (0x21)
            ant2power: Transmit power (0x21)
            ant3power: Transmit power (0x21)
            ant4power: Transmit power (0x21)
            Example: MsgBaseSet4AntPower(33,31,32,33); -- 0~33(0~0x21)dbm
       */
        public ErrorCode MsgBaseSet4AntPower(byte ant1power, byte ant2power, byte ant3power, byte ant4power)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_4_ant_power;

                commandContent.Command = (byte)Commands.cmd_set_4_ant_power;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[4] { ant1power, ant2power, ant3power, ant4power };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSet4AntPower] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader's RF transmission power -- 8 antennas
            ant1power: Transmit power (0x21)
            ant2power: Transmit power (0x21)
            ant3power: Transmit power (0x21)
            ant4power: Transmit power (0x21)
            ant5power: Transmit power (0x21)
            ant6power: Transmit power (0x21)
            ant7power: Transmit power (0x21)
            ant8power: Transmit power (0x21)
            Example: MsgBaseSet8AntPower(33,33,33,31,21,33,33,20); -- 0~33(0~0x21)dbm
       */
        public ErrorCode MsgBaseSet8AntPower(byte ant1power, byte ant2power, byte ant3power, byte ant4power, byte ant5power, byte ant6power, byte ant7power, byte ant8power)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_4_ant_power;

                commandContent.Command = (byte)Commands.cmd_set_4_ant_power;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[8] { ant1power, ant2power, ant3power, ant4power, ant5power, ant6power, ant7power, ant8power };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSet8AntPower] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Get reader transmit power
       */
        public ErrorCode MsgBaseGetOutputPower()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_output_power;

                commandContent.Command = (byte)Commands.cmd_get_output_power;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetOutputPower] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader operating frequency range
            region: standard (0x01:fcc)
            startFreq: starting frequency point (check the frequency point number table)
            endFreq: end frequency point (check the frequency point number table)
            Example: MsgBaseSetFreqRegion(1, 0x07, 0x3b); -- system definition
       */
        public ErrorCode MsgBaseSetFreqRegion(byte region, byte startFreq, byte endFreq)
        {
            if ((region < 0x01) || (region > 0x03))
                return ErrorCode.RREC_UNSUPPORTED;

            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_frequency_region;

                commandContent.Command = (byte)Commands.cmd_set_frequency_region;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[3] { region, startFreq, endFreq };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetFreqRegion] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the reader operating frequency range
            FreqSpace: Frequency interval (250kHz)
            FreqQuantity: Number of frequency points
            StartFreq: starting frequency point (915000kHz)
            Example: MsgBaseSetFreqRegion(250, 2, 915000); -- User-defined
       */
        public ErrorCode MsgBaseSetFreqRegion(ushort FreqSpace, byte FreqQuantity, uint StartFreq)
        {
            byte index = 0;
            byte[] data = new byte[7];
            var commandContent = new CommandContent();

            if(FreqQuantity <= 0)
            {
                return ErrorCode.RREC_UNSUPPORTED;
            }

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_frequency_region;

                data[index++] = 0x04;
                data[index++] = (byte)(FreqSpace / 256);
                data[index++] = (byte)FreqSpace;
                data[index++] = FreqQuantity;
                data[index++] = (byte)(StartFreq / 256 / 256);
                data[index++] = (byte)(StartFreq / 256);
                data[index++] = (byte)StartFreq;

                commandContent.Command = (byte)Commands.cmd_set_frequency_region;
                commandContent.Address = 0x00;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetFreqRegion] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Get the working frequency range of the reader
       */
        public ErrorCode MsgBaseGetFreqRegion()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_frequency_region;

                commandContent.Command = (byte)Commands.cmd_get_frequency_region;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetFreqRegion] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set whether the buzzer works
            mode: 0: not working, 1: working
            Example: MsgBaseSetBeepMode(1);
       */
        public ErrorCode MsgBaseSetBeepMode(byte mode)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_beep_mode;

                commandContent.Command = (byte)Commands.cmd_set_beep_mode;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { mode };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetBeepMode] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set reader temperature
            Example: MsgBaseGetReaderTemp();
       */
        public ErrorCode MsgBaseGetReaderTemp()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_reader_temperature;

                commandContent.Command = (byte)Commands.cmd_get_reader_temperature;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetReaderTemp] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set the temporary power of bee reader/writer
            rfpower: power
            Example: MsgBaseSetTemporaryOutputPower(20-33);
       */
        public ErrorCode MsgBaseSetTemporaryOutputPower(byte rfpower)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_temporary_output_power;

                commandContent.Command = (byte)Commands.cmd_set_temporary_output_power;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { rfpower };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetTemporaryOutputPower] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set reader bandwidth
            profile: bandwidth number
            Example: MsgBaseSetRfLinkProfile(0xd0-0xd3);
       */
        public ErrorCode MsgBaseSetRfLinkProfile(byte profile)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_rf_link_profile;

                commandContent.Command = (byte)Commands.cmd_set_rf_link_profile;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { profile };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetRfLinkProfile] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Get reader bandwidth
            Example: MsgBaseGetRfLinkProfile();
       */
        public ErrorCode MsgBaseGetRfLinkProfile()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_rf_link_profile;

                commandContent.Command = (byte)Commands.cmd_get_rf_link_profile;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetRfLinkProfile] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Check if the antenna is connected
            Example: MsgBaseCheckAnt();
       */
        public ErrorCode MsgBaseCheckAnt()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_check_ant;

                commandContent.Command = (byte)Commands.cmd_check_ant;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseCheckAnt] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cache inventory
            ant: working antenna
            Example: MsgBaseInventory();
       */
        public ErrorCode MsgBaseInventory(uint ant = 1)
        {
            byte[] data = System.BitConverter.GetBytes(ant);
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_inventory;

                commandContent.Command = (byte)Commands.cmd_inventory;
                commandContent.Address = 0x00;
                //Convert to big endian mode
                Array.Reverse(data);
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseInventory] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            read
            membank: read area
            wordaddr: address offset
            wordcnt: read word length
            password: access address
            Example:
       */
        public ErrorCode MsgBaseRead(byte membank, uint wordaddr, ushort wordcnt, uint password)
        {
            byte index = 0;
            byte[] data = new byte[11];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_read;

                commandContent.Command = (byte)Commands.cmd_read;
                commandContent.Address = 0x00;

                data[index++] = membank;
                data[index++] = (byte)(wordaddr / 256 / 256 / 256);
                data[index++] = (byte)(wordaddr / 256 / 256);
                data[index++] = (byte)(wordaddr / 256);
                data[index++] = (byte)wordaddr;
                data[index++] = (byte)(wordcnt / 256);
                data[index++] = (byte)wordcnt;
                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseRead] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Write
            password: access address
            membank: read area
            wordaddr: address offset
            wordcnt: read word length
            Data: data
            Example:
       */
        public ErrorCode MsgBaseWrite(uint password, byte membank, uint wordaddr, ushort wordcnt, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_write;

                commandContent.Command = (byte)Commands.cmd_write;
                commandContent.Address = 0x00;

                data.Add((byte)(password / 256 / 256 / 256));
                data.Add((byte)(password / 256 / 256));
                data.Add((byte)(password / 256));
                data.Add((byte)password);
                data.Add(membank);
                data.Add((byte)(wordaddr / 256 / 256 / 256));
                data.Add((byte)(wordaddr / 256 / 256));
                data.Add((byte)(wordaddr / 256));
                data.Add((byte)wordaddr);
                data.Add((byte)(wordcnt / 256));
                data.Add((byte)wordcnt);
                data.AddRange(Data);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseWrite] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Lock tag
            password: access address
            membank: read area
            locktype: lock type
            Example:
       */
        public ErrorCode MsgBaseLock(uint password, byte membank, byte locktype)
        {
            byte index = 0;
            byte[] data = new byte[6];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_lock;

                commandContent.Command = (byte)Commands.cmd_lock;
                commandContent.Address = 0x00;

                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;
                data[index++] = membank;
                data[index++] = locktype;

                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseLock] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            inactivation tag
            password: access address
            Example:
       */
        public ErrorCode MsgBaseKill(uint password)
        {
            byte index = 0;
            byte[] data = new byte[4];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_kill;

                commandContent.Command = (byte)Commands.cmd_kill;
                commandContent.Address = 0x00;

                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;

                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseKill] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Set matching epc number
            mode: 0: valid, 1: clear matching
            epclen: epc length
            epc: epc number
            Example:
       */
        public ErrorCode MsgBaseSetAccessEpcMatch(byte mode, byte epclen, byte[] epc)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_access_epc_match;

                commandContent.Command = (byte)Commands.cmd_set_access_epc_match;
                commandContent.Address = 0x00;

                data.Add(mode);
                data.Add(epclen);
                data.AddRange(epc);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetAccessEpcMatch] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Get the matching epc number
            Example：
       */
        public ErrorCode MsgBaseGetAccessEpcMatch()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_access_epc_match;

                commandContent.Command = (byte)Commands.cmd_get_access_epc_match;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetAccessEpcMatch] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            Multi-antenna polling inventory
        */
        public ErrorCode MsgBaseFastSwitchAntInventory(byte ant_num, byte[] ant_data, byte interval, byte session, byte flag, byte repeat)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_fast_switch_ant_inventory;

                commandContent.Command = (byte)Commands.cmd_fast_switch_ant_inventory;
                commandContent.Address = 0x00;

                data.Add(ant_num);
                data.AddRange(ant_data);
                data.Add(interval);
                data.Add(session);
                data.Add(flag);
                data.Add(repeat);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseFastSwitchAntInventory] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x89
            Start real-time inventory
        */
        public ErrorCode MsgStartInventory(byte ant = 1)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_real_time_inventory;

                commandContent.Command = (byte)Commands.cmd_real_time_inventory;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { ant };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgStartInventory] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x8a
            User-defined inventory
        */
        public ErrorCode MsgBaseCustomInventory(byte ant, byte inven_num, byte match_mode, byte match_num)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_custom_inventory;

                commandContent.Command = (byte)Commands.cmd_custom_inventory;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[4] { ant, inven_num, match_mode, match_num };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseCustomInventory] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x8b
            User-defined inventory
        */
        public ErrorCode MsgBaseCustmizedSessionTargetInventoty(byte session, byte target)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_customized_session_target_invent;

                commandContent.Command = (byte)Commands.cmd_customized_session_target_invent;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[2] { session, target };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseCustmizedSessionTargetInventoty] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x8c
            Stop inventory
        */
        public ErrorCode MsgBaseStopInventory()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_stop_inventory;

                commandContent.Command = (byte)Commands.cmd_stop_inventory;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseStopInventory] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x90
            Get the tags cached to inventory
        */
        public ErrorCode MsgBaseGetInventoryBuffer()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_inventory_buffer;

                commandContent.Command = (byte)Commands.cmd_get_inventory_buffer;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetInventoryBuffer] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x91
            Get and clear cache inventory
        */
        public ErrorCode MsgBaseGetAndResetInventoryBuffer()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_and_reset_inventory_buffer;

                commandContent.Command = (byte)Commands.cmd_get_and_reset_inventory_buffer;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetAndResetInventoryBuffer] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x92
            Get the number of tags in the cache
        */
        public ErrorCode MsgBaseInventoryBufferTagCount()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_inventory_buffer_tag_count;

                commandContent.Command = (byte)Commands.cmd_get_inventory_buffer_tag_count;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseInventoryBufferTagCount] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x93
            Clear cache
        */
        public ErrorCode MsgBaseResetInventoryBuffer()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_reset_inventory_buffer;

                commandContent.Command = (byte)Commands.cmd_reset_inventory_buffer;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseResetInventoryBuffer] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x95
            sm7 encrypted write
        */
        public ErrorCode MsgBaseSM7Write(uint password, ushort wordcnt, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_sm7_write;

                commandContent.Command = (byte)Commands.cmd_sm7_write;
                commandContent.Address = 0x00;

                data.Add((byte)(password / 256 / 256 / 256));
                data.Add((byte)(password / 256 / 256));
                data.Add((byte)(password / 256));
                data.Add((byte)password);
                data.Add((byte)(wordcnt / 256));
                data.Add((byte)wordcnt);
                data.AddRange(Data);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSM7Write] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x96
            sm7 decryption reading
        */
        public ErrorCode MsgBaseSM7Read(byte read_len)
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_sm7_read;

                commandContent.Command = (byte)Commands.cmd_sm7_read;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[1] { read_len };

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSM7Read] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x97
            Update sm7 key
        */
        public ErrorCode MsgBaseSM7PKUpdate(byte[] password)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_sm7_pk_update;

                commandContent.Command = (byte)Commands.cmd_sm7_pk_update;
                commandContent.Address = 0x00;

                data.AddRange(password);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSM7PKUpdate] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x42
            Fudan micro national standard encrypted communication writing
        */
        public ErrorCode MsgBaseSRCWrite(uint password, byte membank, ushort wordaddr, ushort wordcnt, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_seu_write;

                commandContent.Command = (byte)Commands.cmd_gb_seu_write;
                commandContent.Address = 0x00;

                data.Add((byte)(password / 256 / 256 / 256));
                data.Add((byte)(password / 256 / 256));
                data.Add((byte)(password / 256));
                data.Add((byte)password);
                data.Add(membank);
                data.Add((byte)(wordaddr / 256));
                data.Add((byte)wordaddr);
                data.Add((byte)(wordcnt / 256));
                data.Add((byte)wordcnt);
                data.AddRange(Data);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSRCWrite] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
            cmd = 0x43
            Fudan micro national standard encrypted reading
        */
        public ErrorCode MsgBaseSECRead(byte membank, ushort wordaddr, ushort wordcnt, uint password)
        {
            byte index = 0;
            byte[] data = new byte[9];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_seu_read;

                commandContent.Command = (byte)Commands.cmd_gb_seu_read;
                commandContent.Address = 0x00;

                data[index++] = membank;
                data[index++] = (byte)(wordaddr / 256);
                data[index++] = (byte)wordaddr;
                data[index++] = (byte)(wordcnt / 256);
                data[index++] = (byte)wordcnt;
                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSECRead] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //0x44
       
        public ErrorCode MsgBaseGBRealTimeInventory()
        {
            return ErrorCode.RREC_FAIL;
        }

        /*
           cmd = 0x45
           GB read
       */
        public ErrorCode MsgBaseGBRead(byte membank, ushort wordaddr, ushort wordcnt, uint password)
        {
            byte index = 0;
            byte[] data = new byte[9];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_read;

                commandContent.Command = (byte)Commands.cmd_gb_read;
                commandContent.Address = 0x00;

                data[index++] = membank;
                data[index++] = (byte)(wordaddr / 256);
                data[index++] = (byte)wordaddr;
                data[index++] = (byte)(wordcnt / 256);
                data[index++] = (byte)wordcnt;
                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGBRead] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x46
           GB write
       */
        public ErrorCode MsgBaseGBWrite(uint password, byte membank, ushort wordaddr, ushort wordcnt, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_write;

                commandContent.Command = (byte)Commands.cmd_gb_write;
                commandContent.Address = 0x00;

                data.Add((byte)(password / 256 / 256 / 256));
                data.Add((byte)(password / 256 / 256));
                data.Add((byte)(password / 256));
                data.Add((byte)password);
                data.Add(membank);
                data.Add((byte)(wordaddr / 256));
                data.Add((byte)wordaddr);
                data.Add((byte)(wordcnt / 256));
                data.Add((byte)wordcnt);
                data.AddRange(Data);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGBWrite] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x47
           GB locked
       */
        public ErrorCode MsgBaseGBLock(uint password, byte membank, byte locktype)
        {
            byte index = 0;
            byte[] data = new byte[6];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_lock;

                commandContent.Command = (byte)Commands.cmd_gb_lock;
                commandContent.Address = 0x00;

                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;
                data[index++] = membank;
                data[index++] = locktype;

                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGBLock] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x49
           GB inactivation
       */
        public ErrorCode MsgBaseGBKill(uint password)
        {
            byte index = 0;
            byte[] data = new byte[6];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_kill;

                commandContent.Command = (byte)Commands.cmd_gb_kill;
                commandContent.Address = 0x00;

                data[index++] = (byte)(password / 256 / 256 / 256);
                data[index++] = (byte)(password / 256 / 256);
                data[index++] = (byte)(password / 256);
                data[index++] = (byte)password;

                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGBKill] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x98
           Fudan Micro GB two-way authentication
       */
        public ErrorCode MsgBaseGBMulSeuAuth(byte[] password)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_gb_mul_seu_auth;

                commandContent.Command = (byte)Commands.cmd_gb_mul_seu_auth;
                commandContent.Address = 0x00;

                data.AddRange(password);

                commandContent.Data = data.ToArray();

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGBMulSeuAuth] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x4a
           Save parameters
       */
        public ErrorCode MsgBaseReaderParaSave()
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_reader_para_save;

                commandContent.Command = (byte)Commands.cmd_reader_para_save;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseReaderParaSave] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        /*
           cmd = 0x4b
           Factory reset
       */
        public ErrorCode MsgBaseReaderParaReset()
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_reader_para_reset;

                commandContent.Command = (byte)Commands.cmd_reader_para_reset;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseReaderParaReset] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //0x4c
        public ErrorCode MsgBaseReaderAppUpgrade(uint packetserialnumber, byte status, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            commandContent.Command = (byte)Commands.cmd_reader_app_upgrade;
            commandContent.Address = 0x00;

            data.Add((byte)(packetserialnumber / 256 / 256 / 256));
            data.Add((byte)(packetserialnumber / 256 / 256));
            data.Add((byte)(packetserialnumber / 256));
            data.Add((byte)packetserialnumber);

            data.Add(status);
            data.Add((byte)(Data.Length));
            data.AddRange(Data);

            commandContent.Data = data.ToArray();

            return WriteData(commandContent.GetCommandBytes());
        }

        //0x4d
        public ErrorCode MsgBasebandFirmwareUpgrade(uint packetserialnumber, byte status, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            commandContent.Command = (byte)Commands.cmd_baseband_firmware_upgrade;
            commandContent.Address = 0x00;

            data.Add((byte)(packetserialnumber / 256 / 256 / 256));
            data.Add((byte)(packetserialnumber / 256 / 256));
            data.Add((byte)(packetserialnumber / 256));
            data.Add((byte)packetserialnumber);

            data.Add(status);
            data.Add((byte)(Data.Length));
            data.AddRange(Data);

            commandContent.Data = data.ToArray();

            return WriteData(commandContent.GetCommandBytes());
        }

        //Application upgrade interface
        public ErrorCode MsgBaseAppUpgrade(string filepath, GetUpgrageCallback UpgrageCallback)
        {
            int sendlength = 0;
            long dataindex = 0;
            long filelength = 0;
            byte[] filedata = new byte[parameter.AppUpgradeDataLen];
            byte upgradecount = 0;
            byte status = 0x00;

            parameter.packetcount = 0;
            parameter.GradeResult = 0x00;

            if (!File.Exists(filepath))
            {
                WriteAPILog("[MsgBaseAppUpgrade] File path does not exist.");
                return ErrorCode.ParameterError;
            }

            if (!parameter.TimerInit)
            {
                Upgradetimer.Elapsed += new System.Timers.ElapsedEventHandler(TimeroutEvent);
                Upgradetimer.AutoReset = false;  // Not executed periodically
                Upgradetimer.Enabled = true;     // Execute timer event
                parameter.TimerInit = true;
            }
            using (FileStream fs = File.OpenRead(filepath))
            {
                // Start timer
                Upgradetimer.Start();

                //Get file length
                filelength = fs.Length;//209320byte
                WriteAPILog("[MsgBaseAppUpgrade] File length:" + filelength);

                while (filelength > dataindex)
                {
                    sendlength = ((int)(filelength - dataindex) > parameter.AppUpgradeDataLen) ? parameter.AppUpgradeDataLen : (int)(filelength - dataindex);
                    if(filelength > (dataindex + sendlength))
                    {
                        status = 0x00;
                    }
                    else
                    {
                        //the last package
                        status = 0x01;
                    }

                    WriteAPILog("[MsgBaseAppUpgrade] len:" + sendlength);
                    WriteAPILog("[MsgBaseAppUpgrade] count:" + parameter.packetcount);
                    fs.Read(filedata, 0, sendlength);

                    byte[] senddata = filedata.Skip(0).Take(sendlength).ToArray();

                    do
                    {
                        parameter.gradestatus = 0x00;
                        MsgBaseReaderAppUpgrade(parameter.packetcount, status, senddata);
                        while (parameter.gradestatus == 0x00)                                //Waiting for upgrade results
                        {
                            if (parameter.GradeResult == 0x01)
                            {
                                Upgradetimer.Stop();
                                return ErrorCode.ParameterError;
                            }
                        }
                        upgradecount += 1;
                        if(upgradecount >= 3)
                        {
                            Upgradetimer.Stop();
                            return ErrorCode.ParameterError;
                        }

                    }
                    while (parameter.gradestatus == 0x02);                                  //Upgrade failed. Repeat the upgrade command.

                    upgradecount = 0;
                    parameter.gradestatus = 0x00;                                           //Update upgrade status
                    parameter.packetcount += 1;                                             //Updated upgrade package
                    dataindex += sendlength;
                    WriteAPILog("[MsgBaseAppUpgrade] The current app package has been upgraded successfully.");

                    UpgrageCallback(filelength, dataindex);

                    // Restart timer
                    Upgradetimer.Stop();
                    Upgradetimer.Start();
                }
            }

            // off timer
            Upgradetimer.Stop();

            WriteAPILog("[MsgBaseAppUpgrade] Upgrade completed...");
            //Upgrade completed
            parameter.gradestatus = 0x00;
            parameter.packetcount = 0;

            return ErrorCode.OK;
        }

        //Application upgrade interface
        public ErrorCode MsgBasebandUpgrade(string filepath, GetUpgrageCallback UpgrageCallback)
        {
            int sendlength = 0;
            long dataindex = 0;
            long filelength = 0;
            byte[] filedata = new byte[parameter.AppUpgradeDataLen];
            byte upgradecount = 0;
            byte status = 0x00;
            byte timeoutflag = 0;

            if (parameter.GradeResult == 0x01)
            {
                WriteAPILog("[MsgBasebandUpgrade] Download timed out, please download again.");
                timeoutflag = 1;
            }

            parameter.packetcount = 0;
            parameter.GradeResult = 0x00;

            if (!File.Exists(filepath))
            {
                WriteAPILog("[MsgBasebandUpgrade] File path does not exist.");
                return ErrorCode.ParameterError;
            }

            if (!parameter.TimerInit)
            {
                Upgradetimer.Elapsed += new System.Timers.ElapsedEventHandler(TimeroutEvent);
                Upgradetimer.AutoReset = false;  // Not executed periodically
                Upgradetimer.Enabled = true;     // Execute timer event
                parameter.TimerInit = true;
            }
            using (FileStream fs = File.OpenRead(filepath))
            {
                //Start timer
                Upgradetimer.Start();

                //Get file length
                filelength = fs.Length;//byte
                WriteAPILog("[MsgBasebandUpgrade] File length:" + filelength);

                while (filelength > dataindex)
                {
                    sendlength = ((int)(filelength - dataindex) > parameter.AppUpgradeDataLen) ? parameter.AppUpgradeDataLen : (int)(filelength - dataindex);
                    if (filelength > (dataindex + sendlength))
                    {
                        status = 0x00;
                    }
                    else
                    {
                        //the last package
                        status = 0x01;
                    }

                    WriteAPILog("[MsgBasebandUpgrade] len:" + sendlength);
                    WriteAPILog("[MsgBasebandUpgrade] count:" + parameter.packetcount);
                    fs.Read(filedata, 0, sendlength);
                    if(timeoutflag == 1)
                    {
                        WriteAPILog("[MsgBasebandUpgrade] len:" + sendlength);
                        WriteAPILog("[MsgBasebandUpgrade] count:" + parameter.packetcount);
                        fs.Read(filedata, 0, sendlength);
                        timeoutflag = 0;
                    }

                    byte[] senddata = filedata.Skip(0).Take(sendlength).ToArray();

                    do
                    {
                        parameter.gradestatus = 0x00;
                        MsgBasebandFirmwareUpgrade(parameter.packetcount, status, senddata);
                        while (parameter.gradestatus == 0x00)                                //Waiting for upgrade results
                        {
                            if(parameter.GradeResult == 0x01)
                            {
                                Upgradetimer.Stop();
                                return ErrorCode.ParameterError;
                            }
                        }
                        upgradecount += 1;
                        if (upgradecount >= 3)
                        {
                            Upgradetimer.Stop();
                            return ErrorCode.ParameterError;
                        }

                    }
                    while (parameter.gradestatus == 0x02);                                  //Upgrade failed. Repeat the upgrade command.

                    upgradecount = 0;
                    parameter.gradestatus = 0x00;                                           //Update upgrade status
                    parameter.packetcount += 1;                                             //Updated upgrade package
                    dataindex += sendlength;
                    WriteAPILog("[MsgBasebandUpgrade] The current baseband package has been upgraded successfully.");

                    UpgrageCallback(filelength, dataindex);

                    // Restart timer
                    Upgradetimer.Stop();
                    Upgradetimer.Start();
                }
            }

            // off timer
            Upgradetimer.Stop();

            WriteAPILog("[MsgBasebandUpgrade] Upgrade completed");
            //Upgrade completed
            parameter.gradestatus = 0x00;
            parameter.packetcount = 0;

            return ErrorCode.OK;
        }

        //Get GPIO status
        public ErrorCode MsgBaseGetGPIOSTatus()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_gpio_status;

                commandContent.Command = (byte)Commands.cmd_get_gpio_status;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetGPIOSTatus] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Set GPIO status
        public ErrorCode MsgBaseSetGPIOSTatus(byte gpioName, byte status)
        {
            byte index = 0;
            byte[] data = new byte[2];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_gpio_status;

                data[index++] = gpioName;
                data[index++] = status;

                commandContent.Command = (byte)Commands.cmd_set_gpio_status;
                commandContent.Address = 0x00;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetGPIOSTatus] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Get multi-label status
        public ErrorCode MsgBaseMulTagModeStatus()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_mulTag_mode_status;

                commandContent.Command = (byte)Commands.cmd_get_mulTag_mode_status;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseMulTagModeStatus] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Set multi-label status
        public ErrorCode MsgBaseSetMulTagModeStatus(byte status)
        {
            byte index = 0;
            byte[] data = new byte[7];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_mulTag_mode_status;

                data[index++] = status;

                commandContent.Command = (byte)Commands.cmd_set_mulTag_mode_status;
                commandContent.Address = 0x00;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetMulTagModeStatus] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Two-way authentication
        public ErrorCode MsgBaseBidirectionalAuthentication(uint packetserialnumber, byte status, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            commandContent.Command = (byte)Commands.cmd_bidirectional_authentication;
            commandContent.Address = 0x00;

            data.Add((byte)(Data.Length));
            data.AddRange(Data);

            commandContent.Data = data.ToArray();

            return WriteData(commandContent.GetCommandBytes());
        }

        //Set tx duty cycle
        public ErrorCode MsgBaseSetTxTime(ushort txOnTime, ushort txOffTime)
        {
            byte index = 0;
            byte[] data = new byte[4];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_tx_time;

                commandContent.Command = (byte)Commands.cmd_set_tx_time;
                commandContent.Address = 0x00;

                data[index++] = (byte)(txOnTime / 256);
                data[index++] = (byte)txOnTime;
                data[index++] = (byte)(txOffTime / 256);
                data[index++] = (byte)txOffTime;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetTxTime] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Get tx duty cycle
        public ErrorCode MsgBaseGetTxTime()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_tx_time;

                commandContent.Command = (byte)Commands.cmd_get_tx_time;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetTxTime] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Set session and target
        public ErrorCode MsgBaseSetSessionTarget(byte session, byte target)
        {
            byte index = 0;
            byte[] data = new byte[2];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_session_target;

                commandContent.Command = (byte)Commands.cmd_set_session_target;
                commandContent.Address = 0x00;

                data[index++] = session;
                data[index++] = target;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetSessionTarget] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Get session and target
        public ErrorCode MsgBaseGetSessionTarget()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_session_target;

                commandContent.Command = (byte)Commands.cmd_get_session_target;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetSessionTarget] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Set CW wave
        public ErrorCode MsgBaseSetCW(byte cwSwitch)
        {
            byte index = 0;
            byte[] data = new byte[1];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_cw;

                commandContent.Command = (byte)Commands.cmd_set_cw;
                commandContent.Address = 0x00;

                data[index++] = cwSwitch;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetCW] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Get CW waves
        public ErrorCode MsgBaseGetCW()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_cw;

                commandContent.Command = (byte)Commands.cmd_get_cw;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetCW] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Set heartbeat and reporting cycle
        public ErrorCode MsgBaseSetKeepalive(byte enable, short reportTime)
        {
            byte index = 0;
            byte[] data = new byte[3];
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_set_keepalive;

                commandContent.Command = (byte)Commands.cmd_set_keepalive;
                commandContent.Address = 0x00;

                data[index++] = enable;
                data[index++] = (byte)(reportTime / 256);
                data[index++] = (byte)reportTime;
                commandContent.Data = data;

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseSetKeepalive] Sending failed");
                return ErrorCode.RREC_FAIL;
            }
        }

        //Get and set the heartbeat and reporting cycle
        public ErrorCode MsgBaseGetKeepalive()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_keepalive;

                commandContent.Command = (byte)Commands.cmd_get_keepalive;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetKeepalive] Sending failed.");
                return ErrorCode.RREC_FAIL;
            }
        }

        //SetSelect
        public ErrorCode MsgBaseSetSelect(byte enable, byte selParam, int pointer, byte maskLen, byte trucation, byte[] Data)
        {
            List<byte> data = new List<byte>();
            var commandContent = new CommandContent();

            commandContent.Command = (byte)Commands.cmd_set_select;
            commandContent.Address = 0x00;

            data.Add(enable);
            data.Add(selParam);
            data.Add((byte)(pointer / 256 / 256 / 256));
            data.Add((byte)(pointer / 256 / 256));
            data.Add((byte)(pointer / 256));
            data.Add((byte)pointer);
            data.Add(maskLen);
            data.Add(trucation);
            data.AddRange(Data);

            commandContent.Data = data.ToArray();

            return WriteData(commandContent.GetCommandBytes());
        }

        //GetSelect
        public ErrorCode MsgBaseGetSelect()
        {
            var commandContent = new CommandContent();

            InitResponseTimer();

            if (ResponseFlag)
            {
                ResponseFlag = false;
                Upgradetimer.Start();
                ReponseCommand = (int)Commands.cmd_get_select;

                commandContent.Command = (byte)Commands.cmd_get_select;
                commandContent.Address = 0x00;
                commandContent.Data = new byte[0];

                return WriteData(commandContent.GetCommandBytes());
            }
            else
            {
                WriteAPILog("[MsgBaseGetSelect] Sending failed.");
                return ErrorCode.RREC_FAIL;
            }
        }

        private void TimeroutEvent(object sender, EventArgs e)
        {
            // Turn timer off
            Upgradetimer.Stop();

            // Timeout to enable next transmission
            ResponseFlag = true;

            // Download failed
            parameter.GradeResult = 0x01;

            WriteAPILog("[TimeroutEvent] Timeout for receiving response data...");
        }

        private ErrorCode WriteData(byte[] content)
        {
            WriteSerialLog("WriteData:" + ToHexString(content));

            try
            {
                if (InternalPortInstance != null)
                    InternalPortInstance.Write(content, 0, content.Length);
                else
                    return ErrorCode.SystemError;

            }
            catch (InvalidOperationException e)
            {
                WriteSerialLog("WriteData: Exception " + e.Message);
                return ErrorCode.SystemError;
            }
            catch (Exception e)
            {
                WriteSerialLog("WriteData: Unknown Exception " + e.Message);
                return ErrorCode.SystemError;
            }

            return ErrorCode.OK;
        }

        public void Dispose()
        {
            if (InternalPortInstance != null)
            {
                var status = ErrorCode.OK;
                CloseSerial(out status);
            }
            Upgradetimer.Stop();
        }

        private Queue<byte> recevicedBufferCache = new Queue<byte>();
        private static byte[] TcpBuffer = new byte[1024];
        private int currentExpectedLength = 0;
        private List<byte> currentResponse = new List<byte>();
        private static int ChannelSelect = 0;                                                      // Data transmission channel, 0-no channel is opened, 1-serial port, 2-network port

        private void InternalPortInstance_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int receivedByteLength = InternalPortInstance.BytesToRead;
            byte[] buffer = new byte[receivedByteLength];
            InternalPortInstance.Read(buffer, 0, receivedByteLength);

            lock (recevicedBufferCache)
            {
                for (int i = 0; i < receivedByteLength; i++)
                {
                    recevicedBufferCache.Enqueue(buffer[i]);
                }
            }

            SplitQueueData();
        }

        private void SplitQueueData()
        {
            if (recevicedBufferCache.Count == 0)
            {
                return;
            }

            lock (recevicedBufferCache)
            {
                while (recevicedBufferCache.Count > 0)
                {

                    var currentByte = recevicedBufferCache.Dequeue();

                    // This is a new return header
                    if (currentResponse.Count == 0)
                    {
                        if (currentByte == CommandContent.Head)
                        {
                            currentResponse.Add(currentByte);
                            continue;
                        }
                    }

                    // Only the 0xA0 header is received, then the next one should be length
                    if (currentResponse.Count == 1)
                    {
                        currentResponse.Add(currentByte);
                        currentExpectedLength = currentByte;

                        continue;
                    }

                    // 0xA0 header and length received
                    if (currentResponse.Count >= 2)
                    {
                        currentResponse.Add(currentByte);
                        currentExpectedLength -= 1;

                        // If the byte expected at this time is 0, then it is a return result after receiving it completely.
                        if (currentExpectedLength == 0)
                        {
                            var cmdResponse = currentResponse.ToArray();
                            WriteSerialLog("Receive:" + ToHexString(cmdResponse));
                            SendOutCommandResponse(cmdResponse);

                            currentResponse = new List<byte>();
                            currentExpectedLength = 0;
                        }

                        continue;
                    }
                }
            }
        }

        #region byte<->string

        /// <summary>
        /// byte[]转16进制string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(' ' + bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
        /// <summary>
        /// 16进制字符串转byte[]
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] GetBytesFromString(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
            {
                hexString += " ";
            }
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }

        #endregion
    }

    public class parameter
    {
        public static int AppUpgradeDataLen = 200;                   // The length of the data segment of the upgrade package
        public static ErrorCode errorCode = ErrorCode.OK;
        public static uint packetcount = 0;                         // Count of packets sent during upgrade
        public static byte gradestatus = 0x00;                      // Indicates the current status during the upgrade process: 0x00-waiting for response, 0x01-upgrade successful, 0x02-upgrade failed
        public static int GradeResult = 0x00;                       // Upgrade results
        public static bool TimerInit = false;                       // Whether the timer is initialized
    }
}
