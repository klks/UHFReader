using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCchip.Reader.API;

namespace ES_F3105U
{
    /// <summary>
    /// Partial MainForm class: Handles parsing of responses from the UHF reader and updates UI/flags accordingly.
    /// </summary>
    partial class MainForm
    {
        // --- Flagging states for command completion ---
        Ref<bool> flag_cmd_reset = new Ref<bool>(false, "flag_cmd_reset");
        Ref<bool> flag_cmd_get_firmware_version = new Ref<bool>(false, "flag_cmd_get_firmware_version");
        Ref<bool> flag_cmd_get_output_power = new Ref<bool>(false, "flag_cmd_get_output_power");
        Ref<bool> flag_cmd_set_output_power = new Ref<bool>(false, "flag_cmd_set_output_power");
        Ref<bool> flag_cmd_get_rf_link_profile = new Ref<bool>(false, "flag_cmd_get_rf_link_profile");
        Ref<bool> flag_cmd_set_rf_link_profile = new Ref<bool>(false, "cmd_set_rf_link_profile");
        Ref<bool> flag_cmd_get_reader_temperature = new Ref<bool>(false, "flag_cmd_get_reader_temperature");
        Ref<bool> flag_cmd_real_time_inventory = new Ref<bool>(false, "flag_cmd_real_time_inventory");
        Ref<bool> flag_cmd_stop_inventory = new Ref<bool>(false, "flag_cmd_stop_inventory");
        Ref<bool> flag_cmd_get_access_epc_match = new Ref<bool>(false, "flag_cmd_get_access_epc_match");
        Ref<bool> flag_cmd_set_access_epc_match = new Ref<bool>(false, "flag_cmd_set_access_epc_match");
        Ref<bool> flag_cmd_read = new Ref<bool>(false, "flag_cmd_read");
        Ref<bool> flag_cmd_write = new Ref<bool>(false, "flag_cmd_write");
        Ref<bool> flag_cmd_get_frequency_region = new Ref<bool>(false, "flag_cmd_get_frequency_region");
        Ref<bool> flag_cmd_reader_para_save = new Ref<bool>(false, "flag_cmd_reader_para_save");
        Ref<bool> flag_cmd_reader_para_reset = new Ref<bool>(false, "flag_cmd_reader_para_reset");
        Ref<bool> flag_cmd_get_tx_time = new Ref<bool>(false, "cmd_get_tx_time");
        Ref<bool> flag_cmd_set_tx_time = new Ref<bool>(false, "cmd_set_tx_time");
        Ref<bool> flag_cmd_get_cw = new Ref<bool>(false, "cmd_get_cw");
        Ref<bool> flag_cmd_set_cw = new Ref<bool>(false, "cmd_set_cw");
        Ref<bool> flag_cmd_kill = new Ref<bool>(false, "cmd_kill");
        Ref<bool> flag_cmd_lock = new Ref<bool>(false, "cmd_lock");

        // --- Reader parameters ---
        string readerVersion = ""; // Firmware version string
        byte readerDBM = 0; // Output power in dBM
        byte readerLinkProfile = 0; // RF link profile
        string readerTemperature = ""; // Reader temperature string
        byte readerRegion; // Frequency region
        byte readerStartFreq; // Start frequency
        byte readerEndFreq; // End frequency
        ushort readerTXOnTime = 0; // TX on time
        ushort readerTXOffTime = 0; // TX off time
        byte readerCWStatus; // CW status

        // --- Inventory queue for EPC data ---
        ConcurrentQueue<byte[]> epcQueue = new ConcurrentQueue<byte[]>();

        // --- Return status code for last command ---
        ErrorCode readerStatusCode = 0;

        // --- Function parameters and buffers ---
        bool isMsgBaseSetAccessEpcMatch_Set = false;
        string readerFilteredEPC = "";
        byte[] readerReadBuffer = Array.Empty<byte>();

        /// <summary>
        /// Adds a message to the response ListBox with a timestamp.
        /// </summary>
        private void AddListBoxResponse(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();
            string fullMsg = $"[{time_now}] {message}";
            lbResponse.Invoke(new MethodInvoker(delegate { lbResponse.Items.Insert(0, fullMsg); }));
        }

        /// <summary>
        /// Parses a response from the reader and dispatches to the appropriate handler.
        /// </summary>
        /// <param name="cmdResponse">Raw response bytes from the reader.</param>
        private void ResponseParser(byte[] cmdResponse)
        {
            int bufLen = cmdResponse.Length;
            if (bufLen < 5)
            {
                return; // Ignore invalid responses
            }
            int dataLen = bufLen - 5;
            int index = 0;
            int responseLen = 0;

            var commandContent = new CommandContent();
            index++;                                                    //head
            responseLen = cmdResponse[index++];                         //len
            commandContent.Address = cmdResponse[index++];              //addr
            commandContent.Command = cmdResponse[index++];              //cmd
            if (dataLen > 0)                                            //data
            {
                commandContent.Data = cmdResponse.Skip(index).Take(dataLen).ToArray();
            }
            else
            {
                commandContent.Data = Array.Empty<byte>();
            }
            index += dataLen;
            index++;                                                    //crc

            // Dispatch to command-specific handler
            switch (commandContent.Command)
            {
                case (byte)(Commands.cmd_temperature_warning):
                    // Device overheating warning
                    AddListBoxResponse($"cmd_temperature_warning, Device is overheating, please check reader");
                    break;
                case (byte)(Commands.cmd_reset):
                    parse_cmd_reset(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_firmware_version):
                    parse_cmd_get_firmware_version(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_output_power):
                    parse_cmd_get_output_power(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_rf_link_profile):
                    parse_cmd_get_rf_link_profile(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_reader_temperature):
                    parse_cmd_get_reader_temperature(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_real_time_inventory):
                    if (responseLen == 4)
                        parse_cmd_real_time_inventory_status(commandContent.Data);
                    else
                        epcQueue.Enqueue(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_stop_inventory):
                    parse_cmd_stop_inventory(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_set_access_epc_match):
                    parse_cmd_set_access_epc_match(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_access_epc_match):
                    parse_cmd_get_access_epc_match(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_read):
                    parse_cmd_read(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_write):
                    parse_cmd_write(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_frequency_region):
                    parse_cmd_get_frequency_region(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_reader_para_save):
                    parse_cmd_reader_para_save(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_reader_para_reset):
                    parse_cmd_reader_para_reset(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_set_output_power):
                    parse_cmd_set_output_power(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_set_rf_link_profile):
                    parse_cmd_set_rf_link_profile(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_get_tx_time):
                    parse_cmd_get_tx_time(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_set_tx_time):
                    parse_cmd_set_tx_time(commandContent.Data);
                    break;
                case (byte)(Commands.cmd_kill):
                    parse_cmd_kill(commandContent.Data);
                    break;
                default:
                    AddListBoxResponse($"Unimplemented command 0x{commandContent.Command:X2}");
                    break;
            }
        }

        /// <summary>
        /// Returns a human-readable string for a given error code.
        /// </summary>
        private string GetErrorCodeString(byte errCode)
        {
            string retString = string.Empty;
            // Map error code to description
            return errCode switch
            {
                0x10 => "Operation sucessful",
                0x11 => "Operation failed",
                0x12 => "Custom inventory complete",
                0x13 => "Fast switch antenna inventory complete",
                0x20 => "MCU reset failed",
                0x21 => "Open CW failed",
                0x22 => "Antenna not connected",
                0x23 => "Write flash failed",
                0x24 => "Read flash failed",
                0x25 => "Set output power failed",
                0x31 => "Tag inventory failed",
                0x32 => "Tag read failed",
                0x33 => "Tag write failed",
                0x34 => "Tag lock failed",
                0x35 => "Tag kill failed",
                0x36 => "No tags detected",
                0x37 => "Inventory OK, Access failed",
                0x40 => "Access or password failed",
                0x41 => "Invalid parameter",
                0x42 => "Invalid parameter, word count too long",
                0x43 => "Invalid parameter, memory bank out of range",
                0x44 => "Invalid parameter, lock region out of range",
                0x45 => "Invalid parameter, lock action out of range",
                0x46 => "Invalid parameter, address invalid",
                0x47 => "Invalid parameter, antenna id out of range",
                0x48 => "Invalid parameter, output power out of range",
                0x49 => "Invalid parameter, frequency region out of range",
                0x4a => "Invalid parameter, baud rate out of range",
                0x4c => "Invalid parameter, EPC match length too long",
                0x4d => "Invalid parameter, EPC match length incorrect",
                0x4e => "Invalid parameter, epc match mode incorrect",
                0x4f => "Invalid parameter, frequency range incorrect",
                0x50 => "Failed to get RN16 from tag",
                0x53 => "RF chip failed to respond",
                0x54 => "Failed to achieve desired output power",
                0x55 => "Copyright authentication failed",
                0x56 => "Spectrum regulation error",
                0x57 => "Output power too low",
                0x58 => "GB SM7 two-way verification failed",
                0x59 => "GB SM7 two-way verification success",
                0x60 => "GB tag, insufficient power",
                0x61 => "GB tag, permission error",
                0x62 => "GB tag, memory over limit",
                0x63 => "GB tag, memory locked",
                0x64 => "GB tag, password error",
                0x65 => "GB authentication error",
                0x66 => "GB, unknown error",
                _ => $"Unknown err code 0x{errCode:X2}"
            };
        }
        #region command handler parsers

        /// <summary>
        /// Handles response for cmd_reader_para_save command (0x4a).
        /// </summary>
        private void parse_cmd_reader_para_save(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_reader_para_save -> {parsedReturn}");
            flag_cmd_reader_para_save.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_reader_para_reset command (0x4b).
        /// </summary>
        private void parse_cmd_reader_para_reset(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_reader_para_reset -> {parsedReturn}");
            flag_cmd_reader_para_reset.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_tx_time command (0x5c).
        /// </summary>
        private void parse_cmd_get_tx_time(byte[] data)
        {
            if(data.Length == 4)
            {
                readerTXOnTime = (ushort)(data[0] << 8 | data[1]);
                readerTXOffTime = (ushort)(data[2] << 8 | data[3]);
                AddListBoxResponse($"cmd_get_tx_time -> {readerTXOnTime.ToString()}:{readerTXOffTime.ToString()}");
            }
            else
            {
                AddListBoxResponse($"cmd_get_tx_tim -> Error");
            }
            flag_cmd_get_tx_time.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_set_tx_time command (0x5d).
        /// </summary>
        private void parse_cmd_set_tx_time(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_set_tx_time -> {parsedReturn}");
            flag_cmd_set_tx_time.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_set_rf_link_profile command (0x69).
        /// </summary>
        private void parse_cmd_set_rf_link_profile(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_set_rf_link_profile -> {parsedReturn}");
            flag_cmd_set_rf_link_profile.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_rf_link_profile command (0x6a).
        /// </summary>
        private void parse_cmd_get_rf_link_profile(byte[] data)
        {
            //No error status code returned
            readerLinkProfile = data[0];
            AddListBoxResponse($"cmd_get_rf_link_profile -> {readerDBM}");
            flag_cmd_get_rf_link_profile.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_reset command (0x70).
        /// </summary>
        private void parse_cmd_reset(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_reset -> {parsedReturn}");
            flag_cmd_reset.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_firmware_version command (0x72).
        /// </summary>
        private void parse_cmd_get_firmware_version(byte[] data)
        {
            //No error status code returned
            string readerModel = "";

            readerModel = data[2] switch
            {
                1 => "UCM601",
                2 => "UCM602",
                6 => "UCM606",
                8 => "UCM608",
                _ => $"Unknown 0x{data[3]:X2}",
            };

            readerVersion = $"{readerModel} v{data[0]}.{data[1]}";
            AddListBoxResponse($"cmd_get_firmware_version -> {readerVersion}");
            flag_cmd_get_firmware_version.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_set_output_power command (0x76).
        /// </summary>
        private void parse_cmd_set_output_power(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_set_output_power -> {parsedReturn}");
            flag_cmd_set_output_power.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_output_power command (0x77).
        /// </summary>
        private void parse_cmd_get_output_power(byte[] data)
        {
            //No error status code returned
            //Power range from 0-33 dBM
            readerDBM = data[0];
            AddListBoxResponse($"cmd_get_output_power -> {readerDBM}");
            flag_cmd_get_output_power.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_frequency_region command (0x79).
        /// </summary>
        private void parse_cmd_get_frequency_region(byte[] data)
        {
            //No error status code returned
            readerRegion = data[0];
            readerStartFreq = data[1];
            readerEndFreq = data[2];
            AddListBoxResponse($"cmd_get_frequency_region -> {readerRegion} {readerStartFreq} {readerEndFreq}");
            flag_cmd_get_frequency_region.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_reader_temperature command (0x7b).
        /// </summary>
        private void parse_cmd_get_reader_temperature(byte[] data)
        {
            //No error status code returned
            string ret = "";
            if (data[0] != 0x11)
            {
                if (data[0] != 0)
                    readerTemperature = "+";
                else
                    readerTemperature = "-";

                readerTemperature += $"{data[1]} C";

                ret = readerTemperature;
            }
            else
            {
                ret = "Operation failed";
            }
            AddListBoxResponse($"cmd_get_rf_link_profile -> {ret}");

            flag_cmd_get_reader_temperature.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_read command (0x81).
        /// </summary>
        private void parse_cmd_read(byte[] data)
        {
            if (data.Length == 1)
            {
                readerStatusCode = (ErrorCode)data[0];
                string parsedReturn = GetErrorCodeString(data[0]);
                AddListBoxResponse($"cmd_read -> {parsedReturn}");
            }
            else
            {
                //It is now the callers responsibility to parse the data
                readerReadBuffer = data;
                AddListBoxResponse($"cmd_read -> bytesReturned = {data.Length.ToString()}");
                readerStatusCode = (int)ErrorCode.OK;
            }
            flag_cmd_read.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_write command (0x82).
        /// </summary>
        private void parse_cmd_write(byte[] data)
        {
            if (data.Length == 1)
            {
                readerStatusCode = (ErrorCode)data[0];
                string parsedReturn = GetErrorCodeString(data[0]);
                AddListBoxResponse($"cmd_write -> {parsedReturn}");
            }
            else
            {
                //It is now the callers responsibility to parse the data
                readerReadBuffer = data;
                AddListBoxResponse($"cmd_write -> bytesReturned = {data.Length.ToString()}");
                readerStatusCode = (int)ErrorCode.OK;
            }
            flag_cmd_write.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_kill command (0x84).
        /// </summary>
        private void parse_cmd_kill(byte[] data)
        {
            if (data.Length == 1)   // A one byte response indicates an error
            {
                readerStatusCode = (ErrorCode)data[0];
                string parsedReturn = GetErrorCodeString(data[0]);
                AddListBoxResponse($"cmd_kill -> {parsedReturn}");
            }
            else
            {
                ushort TagCount = (ushort)(data[1] << 8 | data[0]);
                byte DataLen = data[2];
                byte[] LockData = data.Skip(3).Take(DataLen).ToArray();
                string lockDataString = ByteArrayToHexString(LockData);
                AddListBoxResponse($"cmd_kill -> {TagCount} tags killed, Data: {lockDataString}");

                string parsedReturn = GetErrorCodeString(data[3 + DataLen]);
                AddListBoxResponse($"cmd_kill -> {parsedReturn}");
            }
            flag_cmd_kill.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_set_access_epc_match command (0x85).
        /// </summary>
        private void parse_cmd_set_access_epc_match(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_set_access_epc_match -> {parsedReturn}");
            flag_cmd_set_access_epc_match.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_get_access_epc_match command (0x86).
        /// </summary>
        private void parse_cmd_get_access_epc_match(byte[] data)
        {
            string parsedReturn = "No Match";
            //No error status code returned
            byte status = data[0];
            if (status == 0)
            {
                if(data.Length == 1)
                {
                    readerFilteredEPC = "";
                    parsedReturn = "No Match, Filter Wide Open";
                }
                else
                {
                    byte[] epcBytes = data.Skip(2).ToArray();
                    readerFilteredEPC = ByteArrayToHexString(epcBytes);
                    parsedReturn = $"Has Match, {readerFilteredEPC}";
                }
            }
            AddListBoxResponse($"cmd_get_access_epc_match -> {parsedReturn}");
            flag_cmd_get_access_epc_match.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_real_time_inventory command (0x89).
        /// </summary>
        private void parse_cmd_real_time_inventory_status(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_real_time_inventory -> {parsedReturn}");
            flag_cmd_real_time_inventory.Value = true;
        }

        /// <summary>
        /// Handles response for cmd_stop_inventory command (0x8c).
        /// </summary>
        private void parse_cmd_stop_inventory(byte[] data)
        {
            readerStatusCode = (ErrorCode)data[0];
            string parsedReturn = GetErrorCodeString(data[0]);
            AddListBoxResponse($"cmd_stop_inventory -> {parsedReturn}");
            flag_cmd_stop_inventory.Value = true;
        }

        #endregion
    }
}
