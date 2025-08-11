namespace ES_F3105U
{
    partial class Form_Reader
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Reader));
            groupBox3 = new GroupBox();
            groupBox7 = new GroupBox();
            label26 = new Label();
            txtReader_RFOFFTime = new TextBox();
            label34 = new Label();
            btnReader_GetTXRFTime = new Button();
            txtReader_RFONTime = new TextBox();
            btnReader_SaveTXRFTime = new Button();
            label33 = new Label();
            groupBox8 = new GroupBox();
            label4 = new Label();
            btnReader_GetFreqBand = new Button();
            cbReader_FreqBand = new ComboBox();
            label27 = new Label();
            txtReader_StartFreq = new TextBox();
            label28 = new Label();
            txtReader_EndFreq = new TextBox();
            btnReader_SaveFreqBand = new Button();
            btnReader_SetCW = new Button();
            cbReader_CWStatus = new ComboBox();
            btnReader_GetCW = new Button();
            label17 = new Label();
            label29 = new Label();
            btnReader_SaveRFLinkProfile = new Button();
            btnReader_ResetParameters = new Button();
            btnReader_SaveParameters = new Button();
            btnReader_SetTXPower = new Button();
            btnReader_GetTemperature = new Button();
            txtReader_Temperature = new TextBox();
            label6 = new Label();
            cbReader_ReadRFLinkProfile = new ComboBox();
            btnReader_GetRFLinkProfile = new Button();
            label5 = new Label();
            btnReader_GetTXPower = new Button();
            txtReader_TXPower = new TextBox();
            label3 = new Label();
            btnReader_GetFirmware = new Button();
            txtReader_FirmwareVer = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            checkEnableSerialLog = new CheckBox();
            checkEnableAPILog = new CheckBox();
            btnReader_COMClose = new Button();
            btnReader_COMOpen = new Button();
            cbReader_ComBaud = new ComboBox();
            btnRefreshComPorts = new Button();
            label47 = new Label();
            cbReader_COM = new ComboBox();
            Label1 = new Label();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox7);
            groupBox3.Controls.Add(groupBox8);
            groupBox3.Controls.Add(btnReader_SetCW);
            groupBox3.Controls.Add(cbReader_CWStatus);
            groupBox3.Controls.Add(btnReader_GetCW);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label29);
            groupBox3.Controls.Add(btnReader_SaveRFLinkProfile);
            groupBox3.Controls.Add(btnReader_ResetParameters);
            groupBox3.Controls.Add(btnReader_SaveParameters);
            groupBox3.Controls.Add(btnReader_SetTXPower);
            groupBox3.Controls.Add(btnReader_GetTemperature);
            groupBox3.Controls.Add(txtReader_Temperature);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cbReader_ReadRFLinkProfile);
            groupBox3.Controls.Add(btnReader_GetRFLinkProfile);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(btnReader_GetTXPower);
            groupBox3.Controls.Add(txtReader_TXPower);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(btnReader_GetFirmware);
            groupBox3.Controls.Add(txtReader_FirmwareVer);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(211, 9);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(754, 282);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Reader Information";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label26);
            groupBox7.Controls.Add(txtReader_RFOFFTime);
            groupBox7.Controls.Add(label34);
            groupBox7.Controls.Add(btnReader_GetTXRFTime);
            groupBox7.Controls.Add(txtReader_RFONTime);
            groupBox7.Controls.Add(btnReader_SaveTXRFTime);
            groupBox7.Controls.Add(label33);
            groupBox7.Location = new Point(160, 77);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(143, 101);
            groupBox7.TabIndex = 3;
            groupBox7.TabStop = false;
            groupBox7.Text = "TX RF Time";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(6, 82);
            label26.Name = "label26";
            label26.Size = new Size(132, 15);
            label26.TabIndex = 63;
            label26.Text = "Time in ms, 0 to disable";
            // 
            // txtReader_RFOFFTime
            // 
            txtReader_RFOFFTime.Location = new Point(78, 55);
            txtReader_RFOFFTime.MaxLength = 5;
            txtReader_RFOFFTime.Name = "txtReader_RFOFFTime";
            txtReader_RFOFFTime.Size = new Size(56, 23);
            txtReader_RFOFFTime.TabIndex = 65;
            txtReader_RFOFFTime.TextChanged += txtReader_RF_ONOFF_Time_TextChanged;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(1, 58);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(74, 15);
            label34.TabIndex = 66;
            label34.Text = "RF OFF Time";
            // 
            // btnReader_GetTXRFTime
            // 
            btnReader_GetTXRFTime.Image = (Image)resources.GetObject("btnReader_GetTXRFTime.Image");
            btnReader_GetTXRFTime.Location = new Point(82, -2);
            btnReader_GetTXRFTime.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetTXRFTime.Name = "btnReader_GetTXRFTime";
            btnReader_GetTXRFTime.Size = new Size(24, 24);
            btnReader_GetTXRFTime.TabIndex = 57;
            btnReader_GetTXRFTime.UseVisualStyleBackColor = true;
            btnReader_GetTXRFTime.Click += btnReader_GetTXRFTime_Click;
            // 
            // txtReader_RFONTime
            // 
            txtReader_RFONTime.Location = new Point(78, 28);
            txtReader_RFONTime.MaxLength = 5;
            txtReader_RFONTime.Name = "txtReader_RFONTime";
            txtReader_RFONTime.Size = new Size(56, 23);
            txtReader_RFONTime.TabIndex = 63;
            txtReader_RFONTime.TextChanged += txtReader_RF_ONOFF_Time_TextChanged;
            // 
            // btnReader_SaveTXRFTime
            // 
            btnReader_SaveTXRFTime.Image = (Image)resources.GetObject("btnReader_SaveTXRFTime.Image");
            btnReader_SaveTXRFTime.Location = new Point(110, -2);
            btnReader_SaveTXRFTime.Margin = new Padding(4, 3, 4, 3);
            btnReader_SaveTXRFTime.Name = "btnReader_SaveTXRFTime";
            btnReader_SaveTXRFTime.Size = new Size(24, 24);
            btnReader_SaveTXRFTime.TabIndex = 58;
            btnReader_SaveTXRFTime.UseVisualStyleBackColor = true;
            btnReader_SaveTXRFTime.Click += btnReader_SaveTXRFTime_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(1, 31);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(71, 15);
            label33.TabIndex = 64;
            label33.Text = "RF ON Time";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label4);
            groupBox8.Controls.Add(btnReader_GetFreqBand);
            groupBox8.Controls.Add(cbReader_FreqBand);
            groupBox8.Controls.Add(label27);
            groupBox8.Controls.Add(txtReader_StartFreq);
            groupBox8.Controls.Add(label28);
            groupBox8.Controls.Add(txtReader_EndFreq);
            groupBox8.Controls.Add(btnReader_SaveFreqBand);
            groupBox8.Location = new Point(8, 77);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(146, 171);
            groupBox8.TabIndex = 4;
            groupBox8.TabStop = false;
            groupBox8.Text = "Frequency";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 25);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 22;
            label4.Text = "Frequency Band";
            // 
            // btnReader_GetFreqBand
            // 
            btnReader_GetFreqBand.Image = (Image)resources.GetObject("btnReader_GetFreqBand.Image");
            btnReader_GetFreqBand.Location = new Point(87, -2);
            btnReader_GetFreqBand.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetFreqBand.Name = "btnReader_GetFreqBand";
            btnReader_GetFreqBand.Size = new Size(24, 24);
            btnReader_GetFreqBand.TabIndex = 21;
            btnReader_GetFreqBand.UseVisualStyleBackColor = true;
            btnReader_GetFreqBand.Click += btnReader_GetFreqBand_Click;
            // 
            // cbReader_FreqBand
            // 
            cbReader_FreqBand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_FreqBand.FormattingEnabled = true;
            cbReader_FreqBand.Items.AddRange(new object[] { "FCC", "ETSI", "CHN", "CUSTOM" });
            cbReader_FreqBand.Location = new Point(7, 44);
            cbReader_FreqBand.Name = "cbReader_FreqBand";
            cbReader_FreqBand.Size = new Size(132, 23);
            cbReader_FreqBand.TabIndex = 23;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(7, 72);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(89, 15);
            label27.TabIndex = 31;
            label27.Text = "Start Frequency";
            // 
            // txtReader_StartFreq
            // 
            txtReader_StartFreq.Location = new Point(7, 90);
            txtReader_StartFreq.Name = "txtReader_StartFreq";
            txtReader_StartFreq.ReadOnly = true;
            txtReader_StartFreq.Size = new Size(132, 23);
            txtReader_StartFreq.TabIndex = 30;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(7, 119);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(85, 15);
            label28.TabIndex = 33;
            label28.Text = "End Frequency";
            // 
            // txtReader_EndFreq
            // 
            txtReader_EndFreq.Location = new Point(7, 137);
            txtReader_EndFreq.Name = "txtReader_EndFreq";
            txtReader_EndFreq.ReadOnly = true;
            txtReader_EndFreq.Size = new Size(132, 23);
            txtReader_EndFreq.TabIndex = 32;
            // 
            // btnReader_SaveFreqBand
            // 
            btnReader_SaveFreqBand.Image = (Image)resources.GetObject("btnReader_SaveFreqBand.Image");
            btnReader_SaveFreqBand.Location = new Point(115, -2);
            btnReader_SaveFreqBand.Margin = new Padding(4, 3, 4, 3);
            btnReader_SaveFreqBand.Name = "btnReader_SaveFreqBand";
            btnReader_SaveFreqBand.Size = new Size(24, 24);
            btnReader_SaveFreqBand.TabIndex = 56;
            btnReader_SaveFreqBand.UseVisualStyleBackColor = true;
            btnReader_SaveFreqBand.Click += btnReader_SaveFreqBand_Click;
            // 
            // btnReader_SetCW
            // 
            btnReader_SetCW.Image = (Image)resources.GetObject("btnReader_SetCW.Image");
            btnReader_SetCW.Location = new Point(435, 42);
            btnReader_SetCW.Margin = new Padding(4, 3, 4, 3);
            btnReader_SetCW.Name = "btnReader_SetCW";
            btnReader_SetCW.Size = new Size(24, 24);
            btnReader_SetCW.TabIndex = 62;
            btnReader_SetCW.UseVisualStyleBackColor = true;
            btnReader_SetCW.Click += btnReader_SetCW_Click;
            // 
            // cbReader_CWStatus
            // 
            cbReader_CWStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_CWStatus.FormattingEnabled = true;
            cbReader_CWStatus.Items.AddRange(new object[] { "ON", "OFF" });
            cbReader_CWStatus.Location = new Point(341, 42);
            cbReader_CWStatus.Name = "cbReader_CWStatus";
            cbReader_CWStatus.Size = new Size(64, 23);
            cbReader_CWStatus.TabIndex = 61;
            // 
            // btnReader_GetCW
            // 
            btnReader_GetCW.Image = (Image)resources.GetObject("btnReader_GetCW.Image");
            btnReader_GetCW.Location = new Point(408, 42);
            btnReader_GetCW.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetCW.Name = "btnReader_GetCW";
            btnReader_GetCW.Size = new Size(24, 24);
            btnReader_GetCW.TabIndex = 59;
            btnReader_GetCW.UseVisualStyleBackColor = true;
            btnReader_GetCW.Click += btnReader_GetCW_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(341, 24);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(61, 15);
            label17.TabIndex = 60;
            label17.Text = "CW Status";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(6, 254);
            label29.Name = "label29";
            label29.Size = new Size(287, 15);
            label29.TabIndex = 22;
            label29.Text = "* To make changes permanent, click Save Parameters";
            // 
            // btnReader_SaveRFLinkProfile
            // 
            btnReader_SaveRFLinkProfile.Image = (Image)resources.GetObject("btnReader_SaveRFLinkProfile.Image");
            btnReader_SaveRFLinkProfile.Location = new Point(689, 41);
            btnReader_SaveRFLinkProfile.Margin = new Padding(4, 3, 4, 3);
            btnReader_SaveRFLinkProfile.Name = "btnReader_SaveRFLinkProfile";
            btnReader_SaveRFLinkProfile.Size = new Size(24, 24);
            btnReader_SaveRFLinkProfile.TabIndex = 57;
            btnReader_SaveRFLinkProfile.UseVisualStyleBackColor = true;
            btnReader_SaveRFLinkProfile.Click += btnReader_SaveRFLinkProfile_Click;
            // 
            // btnReader_ResetParameters
            // 
            btnReader_ResetParameters.Location = new Point(615, 185);
            btnReader_ResetParameters.Margin = new Padding(4, 3, 4, 3);
            btnReader_ResetParameters.Name = "btnReader_ResetParameters";
            btnReader_ResetParameters.Size = new Size(132, 39);
            btnReader_ResetParameters.TabIndex = 55;
            btnReader_ResetParameters.Text = "Reset Parameters";
            btnReader_ResetParameters.UseVisualStyleBackColor = true;
            btnReader_ResetParameters.Click += btnReader_ResetParameters_Click;
            // 
            // btnReader_SaveParameters
            // 
            btnReader_SaveParameters.Location = new Point(615, 230);
            btnReader_SaveParameters.Margin = new Padding(4, 3, 4, 3);
            btnReader_SaveParameters.Name = "btnReader_SaveParameters";
            btnReader_SaveParameters.Size = new Size(132, 39);
            btnReader_SaveParameters.TabIndex = 17;
            btnReader_SaveParameters.Text = "Save Parameters";
            btnReader_SaveParameters.UseVisualStyleBackColor = true;
            btnReader_SaveParameters.Click += btnReader_SaveParameters_Click;
            // 
            // btnReader_SetTXPower
            // 
            btnReader_SetTXPower.Image = (Image)resources.GetObject("btnReader_SetTXPower.Image");
            btnReader_SetTXPower.Location = new Point(212, 42);
            btnReader_SetTXPower.Margin = new Padding(4, 3, 4, 3);
            btnReader_SetTXPower.Name = "btnReader_SetTXPower";
            btnReader_SetTXPower.Size = new Size(24, 24);
            btnReader_SetTXPower.TabIndex = 54;
            btnReader_SetTXPower.UseVisualStyleBackColor = true;
            btnReader_SetTXPower.Click += btnReader_SetTXPower_Click;
            // 
            // btnReader_GetTemperature
            // 
            btnReader_GetTemperature.Image = (Image)resources.GetObject("btnReader_GetTemperature.Image");
            btnReader_GetTemperature.Location = new Point(310, 42);
            btnReader_GetTemperature.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetTemperature.Name = "btnReader_GetTemperature";
            btnReader_GetTemperature.Size = new Size(24, 24);
            btnReader_GetTemperature.TabIndex = 28;
            btnReader_GetTemperature.UseVisualStyleBackColor = true;
            btnReader_GetTemperature.Click += btnReader_GetTemperature_Click;
            // 
            // txtReader_Temperature
            // 
            txtReader_Temperature.Location = new Point(243, 42);
            txtReader_Temperature.Name = "txtReader_Temperature";
            txtReader_Temperature.ReadOnly = true;
            txtReader_Temperature.Size = new Size(60, 23);
            txtReader_Temperature.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(243, 24);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 29;
            label6.Text = "Temperature";
            // 
            // cbReader_ReadRFLinkProfile
            // 
            cbReader_ReadRFLinkProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_ReadRFLinkProfile.FormattingEnabled = true;
            cbReader_ReadRFLinkProfile.Items.AddRange(new object[] { "0xD0 Miller 40KHz tari 25us", "0xD1 FM0 200KHz tari 6.25us", "0xD2 FM0 200KHz tari 12.5us", "0xD3 FM0 200KHz tari 25us", "0xD4 Miller4 200KHz tari 6.25us", "0xD5 Miller4 200KHz tari 12.5us", "0xD6 Miller4 200KHz tari 25us", "0xD7 Miller_4 250KHz tari 6.25us", "0xD8 FM0 640KHz tari 6.25us", "0xD9 FM0 40KHz tari 25us", "0xDA GB FM0 64KHz", "0xDB GB Miller 128KHz", "0xDC GB FM0 128KHz" });
            cbReader_ReadRFLinkProfile.Location = new Point(466, 42);
            cbReader_ReadRFLinkProfile.Name = "cbReader_ReadRFLinkProfile";
            cbReader_ReadRFLinkProfile.Size = new Size(188, 23);
            cbReader_ReadRFLinkProfile.TabIndex = 26;
            // 
            // btnReader_GetRFLinkProfile
            // 
            btnReader_GetRFLinkProfile.Image = (Image)resources.GetObject("btnReader_GetRFLinkProfile.Image");
            btnReader_GetRFLinkProfile.Location = new Point(661, 41);
            btnReader_GetRFLinkProfile.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetRFLinkProfile.Name = "btnReader_GetRFLinkProfile";
            btnReader_GetRFLinkProfile.Size = new Size(24, 24);
            btnReader_GetRFLinkProfile.TabIndex = 24;
            btnReader_GetRFLinkProfile.UseVisualStyleBackColor = true;
            btnReader_GetRFLinkProfile.Click += btnReader_GetRFLinkProfile_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(466, 23);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 25;
            label5.Text = "RF Link Profile";
            // 
            // btnReader_GetTXPower
            // 
            btnReader_GetTXPower.Image = (Image)resources.GetObject("btnReader_GetTXPower.Image");
            btnReader_GetTXPower.Location = new Point(184, 42);
            btnReader_GetTXPower.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetTXPower.Name = "btnReader_GetTXPower";
            btnReader_GetTXPower.Size = new Size(24, 24);
            btnReader_GetTXPower.TabIndex = 19;
            btnReader_GetTXPower.UseVisualStyleBackColor = true;
            btnReader_GetTXPower.Click += btnReader_GetTXPower_Click;
            // 
            // txtReader_TXPower
            // 
            txtReader_TXPower.Location = new Point(139, 42);
            txtReader_TXPower.MaxLength = 2;
            txtReader_TXPower.Name = "txtReader_TXPower";
            txtReader_TXPower.Size = new Size(38, 23);
            txtReader_TXPower.TabIndex = 18;
            txtReader_TXPower.TextChanged += txtReader_TXPower_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 20;
            label3.Text = "TX Power";
            // 
            // btnReader_GetFirmware
            // 
            btnReader_GetFirmware.Image = (Image)resources.GetObject("btnReader_GetFirmware.Image");
            btnReader_GetFirmware.Location = new Point(108, 43);
            btnReader_GetFirmware.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetFirmware.Name = "btnReader_GetFirmware";
            btnReader_GetFirmware.Size = new Size(24, 24);
            btnReader_GetFirmware.TabIndex = 6;
            btnReader_GetFirmware.UseVisualStyleBackColor = true;
            btnReader_GetFirmware.Click += btnReader_GetFirmware_Click;
            // 
            // txtReader_FirmwareVer
            // 
            txtReader_FirmwareVer.Location = new Point(7, 43);
            txtReader_FirmwareVer.Name = "txtReader_FirmwareVer";
            txtReader_FirmwareVer.ReadOnly = true;
            txtReader_FirmwareVer.Size = new Size(97, 23);
            txtReader_FirmwareVer.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 17;
            label2.Text = "Firmware Version";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkEnableSerialLog);
            groupBox1.Controls.Add(checkEnableAPILog);
            groupBox1.Controls.Add(btnReader_COMClose);
            groupBox1.Controls.Add(btnReader_COMOpen);
            groupBox1.Controls.Add(cbReader_ComBaud);
            groupBox1.Controls.Add(btnRefreshComPorts);
            groupBox1.Controls.Add(label47);
            groupBox1.Controls.Add(cbReader_COM);
            groupBox1.Controls.Add(Label1);
            groupBox1.Location = new Point(5, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 158);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Communications";
            // 
            // checkEnableSerialLog
            // 
            checkEnableSerialLog.AutoSize = true;
            checkEnableSerialLog.Checked = true;
            checkEnableSerialLog.CheckState = CheckState.Checked;
            checkEnableSerialLog.Location = new Point(7, 132);
            checkEnableSerialLog.Name = "checkEnableSerialLog";
            checkEnableSerialLog.Size = new Size(139, 19);
            checkEnableSerialLog.TabIndex = 16;
            checkEnableSerialLog.Text = "Enable Serial Logging";
            checkEnableSerialLog.UseVisualStyleBackColor = true;
            // 
            // checkEnableAPILog
            // 
            checkEnableAPILog.AutoSize = true;
            checkEnableAPILog.Checked = true;
            checkEnableAPILog.CheckState = CheckState.Checked;
            checkEnableAPILog.Location = new Point(7, 113);
            checkEnableAPILog.Name = "checkEnableAPILog";
            checkEnableAPILog.Size = new Size(129, 19);
            checkEnableAPILog.TabIndex = 3;
            checkEnableAPILog.Text = "Enable API Logging";
            checkEnableAPILog.UseVisualStyleBackColor = true;
            // 
            // btnReader_COMClose
            // 
            btnReader_COMClose.Enabled = false;
            btnReader_COMClose.Location = new Point(104, 78);
            btnReader_COMClose.Margin = new Padding(4, 3, 4, 3);
            btnReader_COMClose.Name = "btnReader_COMClose";
            btnReader_COMClose.Size = new Size(89, 29);
            btnReader_COMClose.TabIndex = 15;
            btnReader_COMClose.Text = "Close";
            btnReader_COMClose.UseVisualStyleBackColor = true;
            btnReader_COMClose.Click += btnReader_COMClose_Click;
            // 
            // btnReader_COMOpen
            // 
            btnReader_COMOpen.Location = new Point(7, 78);
            btnReader_COMOpen.Margin = new Padding(4, 3, 4, 3);
            btnReader_COMOpen.Name = "btnReader_COMOpen";
            btnReader_COMOpen.Size = new Size(89, 29);
            btnReader_COMOpen.TabIndex = 5;
            btnReader_COMOpen.Text = "Open";
            btnReader_COMOpen.UseVisualStyleBackColor = true;
            btnReader_COMOpen.Click += btnReader_COMOpen_Click;
            // 
            // cbReader_ComBaud
            // 
            cbReader_ComBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_ComBaud.FormattingEnabled = true;
            cbReader_ComBaud.Items.AddRange(new object[] { "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "76800", "115200", "128000", "230400", "256000", "460800" });
            cbReader_ComBaud.Location = new Point(77, 49);
            cbReader_ComBaud.Margin = new Padding(4, 3, 4, 3);
            cbReader_ComBaud.Name = "cbReader_ComBaud";
            cbReader_ComBaud.Size = new Size(116, 23);
            cbReader_ComBaud.TabIndex = 14;
            // 
            // btnRefreshComPorts
            // 
            btnRefreshComPorts.Image = (Image)resources.GetObject("btnRefreshComPorts.Image");
            btnRefreshComPorts.Location = new Point(168, 20);
            btnRefreshComPorts.Name = "btnRefreshComPorts";
            btnRefreshComPorts.Size = new Size(25, 23);
            btnRefreshComPorts.TabIndex = 1;
            btnRefreshComPorts.UseVisualStyleBackColor = true;
            btnRefreshComPorts.Click += btnReader_RefreshComPorts_Click;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(7, 53);
            label47.Margin = new Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new Size(63, 15);
            label47.TabIndex = 13;
            label47.Text = "Baud Rate:";
            // 
            // cbReader_COM
            // 
            cbReader_COM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_COM.FormattingEnabled = true;
            cbReader_COM.Location = new Point(77, 19);
            cbReader_COM.Margin = new Padding(4, 3, 4, 3);
            cbReader_COM.Name = "cbReader_COM";
            cbReader_COM.Size = new Size(82, 23);
            cbReader_COM.TabIndex = 3;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 23);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(66, 15);
            Label1.TabIndex = 2;
            Label1.Text = "COM Port：";
            // 
            // Form_Reader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form_Reader";
            Size = new Size(970, 296);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private GroupBox groupBox7;
        private Label label26;
        private TextBox txtReader_RFOFFTime;
        private Label label34;
        internal Button btnReader_GetTXRFTime;
        private TextBox txtReader_RFONTime;
        internal Button btnReader_SaveTXRFTime;
        private Label label33;
        private GroupBox groupBox8;
        private Label label4;
        internal Button btnReader_GetFreqBand;
        private ComboBox cbReader_FreqBand;
        private Label label27;
        private TextBox txtReader_StartFreq;
        private Label label28;
        private TextBox txtReader_EndFreq;
        internal Button btnReader_SaveFreqBand;
        internal Button btnReader_SetCW;
        private ComboBox cbReader_CWStatus;
        internal Button btnReader_GetCW;
        private Label label17;
        private Label label29;
        internal Button btnReader_SaveRFLinkProfile;
        internal Button btnReader_ResetParameters;
        internal Button btnReader_SaveParameters;
        internal Button btnReader_SetTXPower;
        internal Button btnReader_GetTemperature;
        private TextBox txtReader_Temperature;
        private Label label6;
        private ComboBox cbReader_ReadRFLinkProfile;
        internal Button btnReader_GetRFLinkProfile;
        private Label label5;
        internal Button btnReader_GetTXPower;
        private TextBox txtReader_TXPower;
        private Label label3;
        internal Button btnReader_GetFirmware;
        private TextBox txtReader_FirmwareVer;
        private Label label2;
        private GroupBox groupBox1;
        private CheckBox checkEnableSerialLog;
        private CheckBox checkEnableAPILog;
        internal Button btnReader_COMClose;
        internal Button btnReader_COMOpen;
        private ComboBox cbReader_ComBaud;
        private Button btnRefreshComPorts;
        private Label label47;
        internal ComboBox cbReader_COM;
        internal Label Label1;
    }
}
