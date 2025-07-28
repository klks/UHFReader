using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UCchip.Reader.API;
using static UCchip.Reader.API.UCchipClient;

namespace ES_F3105U
{
    partial class MainForm
    {
        // Lookup table for frequency values (Hz) by index
        Dictionary<byte, int> freq_lookup = new Dictionary<byte, int>()
            { { 0, 865000 }, { 1, 865500 }, { 2, 866000 }, { 3, 866500 }, { 4, 867000 },
              { 5, 867500 }, { 6, 868000 }, { 7, 902000 }, { 8, 902500 }, { 9, 903000 },
              {10, 903500 }, {11, 904000 }, {12, 904500 }, {13, 905000 }, {14, 905500 },
              {15, 906000 }, {16, 906500 }, {17, 907000 }, {18, 907500 }, {19, 908000 },
              {20, 908500 }, {21, 909000 }, {22, 909500 }, {23, 910000 }, {24, 910500 },
              {25, 911000 }, {26, 911500 }, {27, 912000 }, {28, 912500 }, {29, 913000 },
              {30, 913500 }, {31, 914000 }, {32, 914500 }, {33, 915000 }, {34, 915500 },
              {35, 916000 }, {36, 916500 }, {37, 917000 }, {38, 917500 }, {39, 918000 },
              {40, 918500 }, {41, 919000 }, {42, 919500 }, {43, 920000 }, {44, 920500 },
              {45, 921000 }, {46, 921500 }, {47, 922000 }, {48, 922500 }, {49, 923000 },
              {50, 923500 }, {51, 924000 }, {52, 924500 }, {53, 925000 }, {54, 925500 },
              {55, 926000 }, {56, 926500 }, {57, 927000 }, {58, 927500 }, {59, 928000 }
            };
        /// <summary>
        /// Returns the frequency in Hz for a given lookup index.
        /// </summary>
        private int GetFreq(byte freqLookup)
        {
            if (freq_lookup.ContainsKey(freqLookup))
                return freq_lookup[freqLookup];
            return 0;
        }

        /// <summary>
        /// Populates the COM port dropdown with available serial ports.
        /// </summary>
        private void Reader_PopulateComPorts()
        {
            cbReader_COM.Items.Clear();
            var ports = UCchipClient.GetCOMportList();
            foreach (string port in ports)
            {
                cbReader_COM.Items.Add(port);
            }
        }

        /// <summary>
        /// Initializes the reader UI, sets default baud rate.
        /// </summary>
        private void Init_ReaderUI()
        {
            Reader_PopulateComPorts();
            int index = cbReader_ComBaud.FindString("115200");
            if( index != -1)
            {
                cbReader_ComBaud.SelectedIndex = index;
            }
        }

        /// <summary>
        /// Refreshes the list of available COM ports.
        /// </summary>
        private void btnReader_RefreshComPorts_Click(object sender, EventArgs e)
        {
            Reader_PopulateComPorts();
        }

        /// <summary>
        /// Opens the selected COM port and initializes the reader.
        /// </summary>
        private async void btnReader_COMOpen_Click(object sender, EventArgs e)
        {
            // Validate user selection
            if (cbReader_COM.SelectedIndex == -1 || cbReader_ComBaud.SelectedIndex == -1)
                return;

            readerClient = new();

            string COMPort = cbReader_COM.Items[cbReader_COM.SelectedIndex].ToString();
            string baud = cbReader_ComBaud.Items[cbReader_ComBaud.SelectedIndex].ToString();

            try
            {
                // Attempt to open the serial port
                readerClient.OpenSerial(COMPort + ":" + baud, 3000, out status);
                if (status != ErrorCode.OK)
                {
                    // Show error to user
                    MessageBox.Show("Failed to open COM port.");
                    return;
                }

                // Register response and logging handlers
                readerClient.CommandResponseReceived = ResponseParser;

                if (checkEnableSerialLog.Checked)
                    readerClient.SerialPortLog = Logging_SerialPortLogger;

                if (checkEnableAPILog.Checked)
                    readerClient.APILog = Logging_APILogger;

                // Reset the reader and wait for response
                flag_cmd_reset.Value = false;
                status = readerClient.MsgBaseReset();
                if (status != ErrorCode.OK)
                {
                    btnReader_COMOpen.Enabled = true;
                    readerClient.CloseSerial(out status);
                    return;
                }
                // Wait for reset flag or timeout
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_reset));
                await task;
                if (task.Result != ErrorCode.OK)
                {
                    btnReader_COMOpen.Enabled = true;
                    AddListBoxResponse("Reader timeout");
                    readerClient.CloseSerial(out status);
                    return;
                }

                btnReader_COMOpen.Enabled = false;
                btnReader_COMClose.Enabled = true;

                // Query firmware and TX power after opening
                await Task.Delay(500);
                btnReader_GetFirmware_Click(sender, e);
                await Task.Delay(500);
                btnReader_GetTXPower_Click(sender, e);
                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                // Log and show error
                AddListBoxResponse($"Error opening COM port: {ex.Message}");
            }
        }

        /// <summary>
        /// Closes the COM port and disposes the reader client.
        /// </summary>
        private void btnReader_COMClose_Click(object sender, EventArgs e)
        {
            btnReader_COMOpen.Enabled = true;
            btnReader_COMClose.Enabled = false;
            if (readerClient !=null)
                readerClient.Dispose();
            readerClient = null;
            parameter.TimerInit = false;
        }

        /// <summary>
        /// Gets the firmware version from the reader and updates the UI.
        /// </summary>
        private async void btnReader_GetFirmware_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetFirmware.Enabled = false;
            flag_cmd_get_firmware_version.Value = false;
            readerClient.MsgBaseGetFirmwareVer();
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_firmware_version));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                txtReader_FirmwareVer.Text = readerVersion;
            }
            btnReader_GetFirmware.Enabled = true;
        }

        /// <summary>
        /// Gets the TX power from the reader and updates the UI.
        /// </summary>
        private async void btnReader_GetTXPower_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetTXPower.Enabled = false;
            flag_cmd_get_output_power.Value = false;
            readerClient.MsgBaseGetOutputPower();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_output_power));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                txtReader_TXPower.Text = readerDBM.ToString();
            }
            btnReader_GetTXPower.Enabled = true;
        }

        /// <summary>
        /// Gets the RF link profile from the reader and updates the UI.
        /// </summary>
        private async void btnReader_GetRFLinkProfile_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetRFLinkProfile.Enabled = false;
            flag_cmd_get_rf_link_profile.Value = false;
            readerClient.MsgBaseGetRfLinkProfile();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_rf_link_profile));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                string strfind = $"0x{readerLinkProfile:X2}";
                int index = cbReader_ReadRFLinkProfile.FindString(strfind);
                if (index != -1)
                {
                    cbReader_ReadRFLinkProfile.SelectedIndex = index;
                }
            }
            btnReader_GetRFLinkProfile.Enabled = true;
        }

        /// <summary>
        /// Gets the reader temperature and updates the UI.
        /// </summary>
        private async void btnReader_GetTemperature_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetTemperature.Enabled = false;
            flag_cmd_get_reader_temperature.Value = false;
            readerClient.MsgBaseGetReaderTemp();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_reader_temperature));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                txtReader_Temperature.Text = readerTemperature;
            }

            btnReader_GetTemperature.Enabled = true;

        }

        /// <summary>
        /// Gets the frequency band and updates the UI with start/end frequencies.
        /// </summary>
        private async void btnReader_GetFreqBand_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetTemperature.Enabled = false;
            flag_cmd_get_frequency_region.Value = false;
            readerClient.MsgBaseGetFreqRegion();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_frequency_region));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                cbReader_FreqBand.SelectedIndex = readerRegion-1;
                txtReader_StartFreq.Text = GetFreq(readerStartFreq).ToString() + " Hz";
                txtReader_EndFreq.Text = GetFreq(readerEndFreq).ToString() + " Hz";
            }

            btnReader_GetTemperature.Enabled = true;

        }

        /// <summary>
        /// Sets the TX power on the reader after user confirmation.
        /// </summary>
        private async void btnReader_SetTXPower_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            if (MessageBox.Show("Are you sure you want to change reader settings?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (txtReader_TXPower.TextLength > 0)
            {
                //Bounds check
                byte bPowerLevel = Convert.ToByte(txtReader_TXPower.Text);
                if (bPowerLevel <= 0)
                    bPowerLevel = 1;
                if (bPowerLevel > 20)
                    bPowerLevel = 20;

                txtReader_TXPower.Text = bPowerLevel.ToString();

                btnReader_SetTXPower.Enabled = false;
                flag_cmd_set_output_power.Value = false;
                readerClient.MsgBaseSetOutputPower(bPowerLevel);

                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_set_output_power));
                await task;
                btnReader_SetTXPower.Enabled = true;
            }
        }

        /// <summary>
        /// Saves the reader parameters to non-volatile memory.
        /// </summary>
        private async void btnReader_SaveParameters_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_SaveParameters.Enabled = false;
            flag_cmd_reader_para_save.Value = false;
            readerClient.MsgBaseReaderParaSave();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_reader_para_save));
            await task;
            btnReader_SaveParameters.Enabled = true;
        }

        /// <summary>
        /// Resets the reader parameters to factory defaults after confirmation.
        /// </summary>
        private async void btnReader_ResetParameters_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;
            if (MessageBox.Show("Are you sure you want to reset reader settings?", "Confirm Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            btnReader_ResetParameters.Enabled = false;
            flag_cmd_reader_para_reset.Value = false;
            readerClient.MsgBaseReaderParaReset();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_reader_para_reset));
            await task;

            btnReader_ResetParameters.Enabled = true;
        }

        /// <summary>
        /// Saves the frequency band settings (not implemented).
        /// </summary>
        private void btnReader_SaveFreqBand_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;
        }

        /// <summary>
        /// Saves the RF link profile after user confirmation.
        /// </summary>
        private async void btnReader_SaveRFLinkProfile_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            if (MessageBox.Show("Are you sure you want to change reader settings?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int selIdx = cbReader_ReadRFLinkProfile.SelectedIndex;
            if(selIdx != -1)
            {
                byte profileID = Convert.ToByte(cbReader_ReadRFLinkProfile.Text.Substring(2, 2), 16);
                btnReader_SaveRFLinkProfile.Enabled = false;

                flag_cmd_set_rf_link_profile.Value = false;
                readerClient.MsgBaseSetRfLinkProfile(profileID);
                Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_set_rf_link_profile));
                await task;

                btnReader_SaveRFLinkProfile.Enabled = true;
            }
        }

        /// <summary>
        /// Validates and bounds the TX power input as the user types.
        /// </summary>
        private void txtReader_TXPower_TextChanged(object sender, EventArgs e)
        {
            filterOnlyDigits_TextChanged(sender, e);

            if (txtReader_TXPower.TextLength > 0)
            {
                byte bPowerLevel = Convert.ToByte(txtReader_TXPower.Text);
                if (bPowerLevel <= 0)
                {
                    txtReader_TXPower.Text = "1";
                }
                if (bPowerLevel > 20)
                {
                    txtReader_TXPower.Text = "20";
                }
            }
            
        }

        /// <summary>
        /// Gets the TX/RF ON/OFF times from the reader and updates the UI.
        /// </summary>
        private async void btnReader_GetTXRFTime_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;

            btnReader_GetTXRFTime.Enabled = false;
            flag_cmd_get_tx_time.Value = false;
            readerClient.MsgBaseGetTxTime();

            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_get_tx_time));
            await task;

            if (task.Result == ErrorCode.OK)
            {
                txtReader_RFONTime.Text = readerTXOnTime.ToString();
                txtReader_RFOFFTime.Text = readerTXOffTime.ToString();
            }

            btnReader_GetTXRFTime.Enabled = true;
        }

        /// <summary>
        /// Saves the TX/RF ON/OFF times to the reader after validation and confirmation.
        /// </summary>
        private async void btnReader_SaveTXRFTime_Click(object sender, EventArgs e)
        {
            if (readerClient == null) return;
            if(txtReader_RFONTime.TextLength == 0)
            {
                MessageBox.Show("Please enter RF ON time");
                return;
            }

            if (txtReader_RFOFFTime.TextLength == 0)
            {
                MessageBox.Show("Please enter RF OFF time");
                return;
            }

            if (MessageBox.Show("Are you sure you want to change reader settings?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            btnReader_SaveTXRFTime.Enabled = false;
            flag_cmd_set_tx_time.Value = false;

            ushort on_time = Convert.ToUInt16(txtReader_RFONTime.Text);
            ushort off_time = Convert.ToUInt16(txtReader_RFOFFTime.Text);

            readerClient.MsgBaseSetTxTime(on_time, off_time);
            Task<ErrorCode> task = Task.Run(() => WaitForFlag(flag_cmd_set_tx_time));
            await task;

            btnReader_SaveTXRFTime.Enabled = true;

        }

        /// <summary>
        /// Validates and bounds the RF ON/OFF time input as the user types.
        /// </summary>
        private void txtReader_RF_ONOFF_Time_TextChanged(object sender, EventArgs e)
        {
            filterOnlyDigits_TextChanged(sender, e);

            TextBox? target = sender as TextBox;
            if (target != null && target.TextLength > 0)
            {
                uint onoff_time = Convert.ToUInt32(target.Text);
                if (onoff_time <= 0)
                {
                    target.Text = "0";
                }
                if (onoff_time >= UInt16.MaxValue)
                {
                    target.Text = UInt16.MaxValue.ToString();
                }
            }
        }

        /// <summary>
        /// Placeholder for getting CW (continuous wave) status (not implemented).
        /// </summary>
        private void btnReader_GetCW_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Placeholder for setting CW (continuous wave) status (not implemented).
        /// </summary>
        private void btnReader_SetCW_Click(object sender, EventArgs e)
        {

        }
    }
}
