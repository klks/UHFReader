namespace ES_F3105U
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            TabSheet_READER = new TabPage();
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
            TabSheet_6C = new TabPage();
            groupBox_TagLocking = new GroupBox();
            label30 = new Label();
            txt6C_LockEPCTag = new TextBox();
            btnSetProtectState = new Button();
            groupBox12 = new GroupBox();
            P_User = new RadioButton();
            P_TID = new RadioButton();
            P_EPC = new RadioButton();
            P_Reserve = new RadioButton();
            txt6C_LockEPCAccessPwd = new TextBox();
            label8 = new Label();
            gbLockPassword = new GroupBox();
            AlwaysNot = new RadioButton();
            Always = new RadioButton();
            Proect = new RadioButton();
            NoProect = new RadioButton();
            groupBox13 = new GroupBox();
            AccessCode = new RadioButton();
            DestroyCode = new RadioButton();
            gbLockTIDnUSER = new GroupBox();
            AlwaysNot2 = new RadioButton();
            Always2 = new RadioButton();
            Proect2 = new RadioButton();
            NoProect2 = new RadioButton();
            label35 = new Label();
            cb6C_IKnowTagLock = new CheckBox();
            cb6C_IKnowTagKill = new CheckBox();
            groupBox_TagKill = new GroupBox();
            label16 = new Label();
            btn6C_KillTag = new Button();
            txt6C_KillEPC = new TextBox();
            txt6C_KillPwd = new TextBox();
            label15 = new Label();
            gbTagRW = new GroupBox();
            btn6C_FindLength = new Button();
            cbReader_PollReading = new CheckBox();
            txtReader_WriteData = new TextBox();
            label13 = new Label();
            txt6C_RWLen = new TextBox();
            label12 = new Label();
            btn6C_Clear = new Button();
            btn6C_Write = new Button();
            btn6C_Read = new Button();
            label11 = new Label();
            cb6C_MemBank = new ComboBox();
            txt6C_StartAddr = new TextBox();
            label10 = new Label();
            label9 = new Label();
            txt6C_AccessPwd = new TextBox();
            label7 = new Label();
            txt6C_RWEPC = new TextBox();
            groupBox6 = new GroupBox();
            btn6C_QueryReaderFilter = new Button();
            label14 = new Label();
            btn6C_Inventory = new Button();
            lvInventory = new ListView();
            lvInvCol_Number = new ColumnHeader();
            lvInvCol_PC = new ColumnHeader();
            lvInvCol_EPC = new ColumnHeader();
            lvInvCol_Len = new ColumnHeader();
            lvInvCol_Count = new ColumnHeader();
            lvInvCol_RSSI = new ColumnHeader();
            lvInvCol_Freq = new ColumnHeader();
            lb6C_RWResults = new ListBox();
            groupBox2 = new GroupBox();
            cbDisable_Write_MsgBaseSetAccessEpcMatch = new CheckBox();
            TabSheet_DUP = new TabPage();
            groupDuplicateUI = new GroupBox();
            groupBox11 = new GroupBox();
            lblDup_WriteTID = new Label();
            txtDup_Write_EPC = new TextBox();
            txtDup_Write_FullEPC = new TextBox();
            btnDup_WriteTID = new Button();
            txtDup_Write_UserData = new TextBox();
            txtDup_Write_AccessPwd = new TextBox();
            btnDup_WriteClear = new Button();
            txtDup_Write_TID = new TextBox();
            txtDup_Write_KillPwd = new TextBox();
            btnDup_WriteEPC = new Button();
            btnDup_WriteUser = new Button();
            btnDup_WriteRFU = new Button();
            groupBox9 = new GroupBox();
            btnDup_ReadClear = new Button();
            btnDup_SaveReadData = new Button();
            btnDup_LoadReadData = new Button();
            lblDup_ReadTID = new Label();
            txtDup_Read_EPC = new TextBox();
            txtDup_Read_FullEPC = new TextBox();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            label41 = new Label();
            txtDup_Read_UserData = new TextBox();
            txtDup_Read_AccessPwd = new TextBox();
            txtDup_Read_TID = new TextBox();
            txtDup_Read_CRC = new TextBox();
            label50 = new Label();
            label51 = new Label();
            txtDup_Read_PC = new TextBox();
            label56 = new Label();
            label49 = new Label();
            txtDup_Read_UserDataLen = new TextBox();
            txtDup_Read_KillPwd = new TextBox();
            label61 = new Label();
            txtDup_Read_FullEPCLen = new TextBox();
            groupBox28 = new GroupBox();
            label48 = new Label();
            txtDup_AFI = new TextBox();
            cbDup_EPCGA = new CheckBox();
            cbDup_XPC = new CheckBox();
            cbDup_UMI = new CheckBox();
            txtDup_EPCLength = new TextBox();
            label46 = new Label();
            groupBox29 = new GroupBox();
            txtDup_Read_STI_Prod = new TextBox();
            txtDup_Read_STI_Manu = new TextBox();
            label57 = new Label();
            txtDup_ReadTMN = new TextBox();
            chkDup_ReadFileOpen = new CheckBox();
            chkDup_ReadAuthChlg = new CheckBox();
            chkDup_ReadXTID = new CheckBox();
            label58 = new Label();
            txtDup_ReadMDID = new TextBox();
            btnDup_ReadTID = new Button();
            btnDup_ReadEPC = new Button();
            btnDup_ReadUser = new Button();
            btnDup_ReadRFU = new Button();
            groupBox10 = new GroupBox();
            label19 = new Label();
            txtDup_Validate_FullEPC = new TextBox();
            label24 = new Label();
            label25 = new Label();
            label23 = new Label();
            btnDup_ValidateClear = new Button();
            txtDup_Validate_UserData = new TextBox();
            btnDup_ValidateTID = new Button();
            txtDup_Validate_AccessPwd = new TextBox();
            btnDup_ValidateRFU = new Button();
            txtDup_Validate_TID = new TextBox();
            btnDup_ValidateUser = new Button();
            txtDup_Validate_CRC = new TextBox();
            btnDup_ValidateEPC = new Button();
            label22 = new Label();
            label21 = new Label();
            label18 = new Label();
            txtDup_Validate_PC = new TextBox();
            txtDup_Validate_KillPwd = new TextBox();
            label20 = new Label();
            TabSheet_LOG = new TabPage();
            groupBox5 = new GroupBox();
            lbSerialLog = new ListBox();
            btnLogClearSerial = new Button();
            groupBox4 = new GroupBox();
            lbAPILog = new ListBox();
            btnLogClearAPI = new Button();
            lbResponse = new ListBox();
            timerInventory = new System.Windows.Forms.Timer(components);
            timer6C_PollRead = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            TabSheet_READER.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox1.SuspendLayout();
            TabSheet_6C.SuspendLayout();
            groupBox_TagLocking.SuspendLayout();
            groupBox12.SuspendLayout();
            gbLockPassword.SuspendLayout();
            groupBox13.SuspendLayout();
            gbLockTIDnUSER.SuspendLayout();
            groupBox_TagKill.SuspendLayout();
            gbTagRW.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox2.SuspendLayout();
            TabSheet_DUP.SuspendLayout();
            groupDuplicateUI.SuspendLayout();
            groupBox11.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox28.SuspendLayout();
            groupBox29.SuspendLayout();
            groupBox10.SuspendLayout();
            TabSheet_LOG.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabSheet_READER);
            tabControl1.Controls.Add(TabSheet_6C);
            tabControl1.Controls.Add(TabSheet_DUP);
            tabControl1.Controls.Add(TabSheet_LOG);
            tabControl1.Location = new Point(2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(983, 831);
            tabControl1.TabIndex = 0;
            // 
            // TabSheet_READER
            // 
            TabSheet_READER.Controls.Add(groupBox3);
            TabSheet_READER.Controls.Add(groupBox1);
            TabSheet_READER.Location = new Point(4, 24);
            TabSheet_READER.Name = "TabSheet_READER";
            TabSheet_READER.Padding = new Padding(3);
            TabSheet_READER.Size = new Size(975, 803);
            TabSheet_READER.TabIndex = 1;
            TabSheet_READER.Text = "Reader Parameter";
            TabSheet_READER.UseVisualStyleBackColor = true;
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
            groupBox3.Location = new Point(212, 9);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(754, 282);
            groupBox3.TabIndex = 2;
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
            txtReader_RFOFFTime.KeyPress += filterOnlyDigits_KeyPress;
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
            txtReader_RFONTime.KeyPress += filterOnlyDigits_KeyPress;
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
            txtReader_TXPower.KeyPress += filterOnlyDigits_KeyPress;
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
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 158);
            groupBox1.TabIndex = 0;
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
            // TabSheet_6C
            // 
            TabSheet_6C.Controls.Add(groupBox_TagLocking);
            TabSheet_6C.Controls.Add(label35);
            TabSheet_6C.Controls.Add(cb6C_IKnowTagLock);
            TabSheet_6C.Controls.Add(cb6C_IKnowTagKill);
            TabSheet_6C.Controls.Add(groupBox_TagKill);
            TabSheet_6C.Controls.Add(gbTagRW);
            TabSheet_6C.Controls.Add(groupBox6);
            TabSheet_6C.Controls.Add(lb6C_RWResults);
            TabSheet_6C.Controls.Add(groupBox2);
            TabSheet_6C.Location = new Point(4, 24);
            TabSheet_6C.Name = "TabSheet_6C";
            TabSheet_6C.Size = new Size(975, 803);
            TabSheet_6C.TabIndex = 2;
            TabSheet_6C.Text = "EPC C1-G2 / 6C";
            TabSheet_6C.UseVisualStyleBackColor = true;
            // 
            // groupBox_TagLocking
            // 
            groupBox_TagLocking.Controls.Add(label30);
            groupBox_TagLocking.Controls.Add(txt6C_LockEPCTag);
            groupBox_TagLocking.Controls.Add(btnSetProtectState);
            groupBox_TagLocking.Controls.Add(groupBox12);
            groupBox_TagLocking.Controls.Add(txt6C_LockEPCAccessPwd);
            groupBox_TagLocking.Controls.Add(label8);
            groupBox_TagLocking.Controls.Add(gbLockPassword);
            groupBox_TagLocking.Controls.Add(gbLockTIDnUSER);
            groupBox_TagLocking.Enabled = false;
            groupBox_TagLocking.Location = new Point(395, 320);
            groupBox_TagLocking.Name = "groupBox_TagLocking";
            groupBox_TagLocking.Size = new Size(565, 270);
            groupBox_TagLocking.TabIndex = 24;
            groupBox_TagLocking.TabStop = false;
            groupBox_TagLocking.Text = "Tag Locking";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(262, 27);
            label30.Name = "label30";
            label30.Size = new Size(50, 15);
            label30.TabIndex = 17;
            label30.Text = "Tag EPC";
            // 
            // txt6C_LockEPCTag
            // 
            txt6C_LockEPCTag.Location = new Point(317, 23);
            txt6C_LockEPCTag.Name = "txt6C_LockEPCTag";
            txt6C_LockEPCTag.ReadOnly = true;
            txt6C_LockEPCTag.Size = new Size(240, 23);
            txt6C_LockEPCTag.TabIndex = 16;
            // 
            // btnSetProtectState
            // 
            btnSetProtectState.Location = new Point(442, 230);
            btnSetProtectState.Margin = new Padding(4, 3, 4, 3);
            btnSetProtectState.Name = "btnSetProtectState";
            btnSetProtectState.Size = new Size(115, 29);
            btnSetProtectState.TabIndex = 15;
            btnSetProtectState.Text = "Set Protect";
            btnSetProtectState.UseVisualStyleBackColor = true;
            btnSetProtectState.Click += Button_SetProtectState_Click;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(P_User);
            groupBox12.Controls.Add(P_TID);
            groupBox12.Controls.Add(P_EPC);
            groupBox12.Controls.Add(P_Reserve);
            groupBox12.Location = new Point(7, 14);
            groupBox12.Margin = new Padding(4, 3, 4, 3);
            groupBox12.Name = "groupBox12";
            groupBox12.Padding = new Padding(4, 3, 4, 3);
            groupBox12.Size = new Size(251, 39);
            groupBox12.TabIndex = 11;
            groupBox12.TabStop = false;
            // 
            // P_User
            // 
            P_User.AutoSize = true;
            P_User.Location = new Point(191, 14);
            P_User.Margin = new Padding(4, 3, 4, 3);
            P_User.Name = "P_User";
            P_User.Size = new Size(48, 19);
            P_User.TabIndex = 3;
            P_User.Text = "User";
            P_User.UseVisualStyleBackColor = true;
            // 
            // P_TID
            // 
            P_TID.AutoSize = true;
            P_TID.Location = new Point(141, 14);
            P_TID.Margin = new Padding(4, 3, 4, 3);
            P_TID.Name = "P_TID";
            P_TID.Size = new Size(43, 19);
            P_TID.TabIndex = 2;
            P_TID.Text = "TID";
            P_TID.UseVisualStyleBackColor = true;
            // 
            // P_EPC
            // 
            P_EPC.AutoSize = true;
            P_EPC.Checked = true;
            P_EPC.Location = new Point(87, 14);
            P_EPC.Margin = new Padding(4, 3, 4, 3);
            P_EPC.Name = "P_EPC";
            P_EPC.Size = new Size(46, 19);
            P_EPC.TabIndex = 1;
            P_EPC.TabStop = true;
            P_EPC.Text = "EPC";
            P_EPC.UseVisualStyleBackColor = true;
            // 
            // P_Reserve
            // 
            P_Reserve.AutoSize = true;
            P_Reserve.Location = new Point(7, 14);
            P_Reserve.Margin = new Padding(4, 3, 4, 3);
            P_Reserve.Name = "P_Reserve";
            P_Reserve.Size = new Size(78, 19);
            P_Reserve.TabIndex = 0;
            P_Reserve.Text = "RESERVED";
            P_Reserve.UseVisualStyleBackColor = true;
            // 
            // txt6C_LockEPCAccessPwd
            // 
            txt6C_LockEPCAccessPwd.Location = new Point(304, 235);
            txt6C_LockEPCAccessPwd.Margin = new Padding(4, 3, 4, 3);
            txt6C_LockEPCAccessPwd.MaxLength = 8;
            txt6C_LockEPCAccessPwd.Name = "txt6C_LockEPCAccessPwd";
            txt6C_LockEPCAccessPwd.Size = new Size(116, 23);
            txt6C_LockEPCAccessPwd.TabIndex = 14;
            txt6C_LockEPCAccessPwd.Text = "00000000";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(301, 214);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(139, 15);
            label8.TabIndex = 13;
            label8.Text = "Access Password (8 Hex):";
            // 
            // gbLockPassword
            // 
            gbLockPassword.Controls.Add(AlwaysNot);
            gbLockPassword.Controls.Add(Always);
            gbLockPassword.Controls.Add(Proect);
            gbLockPassword.Controls.Add(NoProect);
            gbLockPassword.Controls.Add(groupBox13);
            gbLockPassword.Location = new Point(7, 59);
            gbLockPassword.Margin = new Padding(4, 3, 4, 3);
            gbLockPassword.Name = "gbLockPassword";
            gbLockPassword.Padding = new Padding(4, 3, 4, 3);
            gbLockPassword.Size = new Size(289, 204);
            gbLockPassword.TabIndex = 10;
            gbLockPassword.TabStop = false;
            gbLockPassword.Text = "Lock of [RESERVED] Password";
            // 
            // AlwaysNot
            // 
            AlwaysNot.AutoSize = true;
            AlwaysNot.Location = new Point(9, 161);
            AlwaysNot.Margin = new Padding(4, 3, 4, 3);
            AlwaysNot.Name = "AlwaysNot";
            AlwaysNot.Size = new Size(178, 19);
            AlwaysNot.TabIndex = 4;
            AlwaysNot.Text = "Never readable and writeable";
            AlwaysNot.UseVisualStyleBackColor = true;
            // 
            // Always
            // 
            Always.AutoSize = true;
            Always.Location = new Point(9, 127);
            Always.Margin = new Padding(4, 3, 4, 3);
            Always.Name = "Always";
            Always.Size = new Size(214, 19);
            Always.TabIndex = 3;
            Always.Text = "Permanently readable and writeable";
            Always.UseVisualStyleBackColor = true;
            // 
            // Proect
            // 
            Proect.AutoSize = true;
            Proect.Location = new Point(9, 95);
            Proect.Margin = new Padding(4, 3, 4, 3);
            Proect.Name = "Proect";
            Proect.Size = new Size(268, 19);
            Proect.TabIndex = 2;
            Proect.Text = "Readable and writeable from the secured state";
            Proect.UseVisualStyleBackColor = true;
            // 
            // NoProect
            // 
            NoProect.AutoSize = true;
            NoProect.Checked = true;
            NoProect.Location = new Point(9, 60);
            NoProect.Margin = new Padding(4, 3, 4, 3);
            NoProect.Name = "NoProect";
            NoProect.Size = new Size(229, 19);
            NoProect.TabIndex = 1;
            NoProect.TabStop = true;
            NoProect.Text = "Readable and  writeable from any state";
            NoProect.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(AccessCode);
            groupBox13.Controls.Add(DestroyCode);
            groupBox13.Location = new Point(6, 15);
            groupBox13.Margin = new Padding(4, 3, 4, 3);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new Padding(4, 3, 4, 3);
            groupBox13.Size = new Size(276, 39);
            groupBox13.TabIndex = 0;
            groupBox13.TabStop = false;
            // 
            // AccessCode
            // 
            AccessCode.AutoSize = true;
            AccessCode.Checked = true;
            AccessCode.Location = new Point(128, 15);
            AccessCode.Margin = new Padding(4, 3, 4, 3);
            AccessCode.Name = "AccessCode";
            AccessCode.Size = new Size(114, 19);
            AccessCode.TabIndex = 1;
            AccessCode.TabStop = true;
            AccessCode.Text = "Access Password";
            AccessCode.UseVisualStyleBackColor = true;
            // 
            // DestroyCode
            // 
            DestroyCode.AutoSize = true;
            DestroyCode.Location = new Point(9, 15);
            DestroyCode.Margin = new Padding(4, 3, 4, 3);
            DestroyCode.Name = "DestroyCode";
            DestroyCode.Size = new Size(94, 19);
            DestroyCode.TabIndex = 0;
            DestroyCode.Text = "Kill Password";
            DestroyCode.UseVisualStyleBackColor = true;
            // 
            // gbLockTIDnUSER
            // 
            gbLockTIDnUSER.Controls.Add(AlwaysNot2);
            gbLockTIDnUSER.Controls.Add(Always2);
            gbLockTIDnUSER.Controls.Add(Proect2);
            gbLockTIDnUSER.Controls.Add(NoProect2);
            gbLockTIDnUSER.Location = new Point(304, 59);
            gbLockTIDnUSER.Margin = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Name = "gbLockTIDnUSER";
            gbLockTIDnUSER.Padding = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Size = new Size(253, 150);
            gbLockTIDnUSER.TabIndex = 12;
            gbLockTIDnUSER.TabStop = false;
            gbLockTIDnUSER.Text = "Lock of [EPC, TID, USER] Bank";
            // 
            // AlwaysNot2
            // 
            AlwaysNot2.AutoSize = true;
            AlwaysNot2.Location = new Point(8, 121);
            AlwaysNot2.Margin = new Padding(4, 3, 4, 3);
            AlwaysNot2.Name = "AlwaysNot2";
            AlwaysNot2.Size = new Size(107, 19);
            AlwaysNot2.TabIndex = 3;
            AlwaysNot2.Text = "Never writeable";
            AlwaysNot2.UseVisualStyleBackColor = true;
            // 
            // Always2
            // 
            Always2.AutoSize = true;
            Always2.Location = new Point(8, 89);
            Always2.Margin = new Padding(4, 3, 4, 3);
            Always2.Name = "Always2";
            Always2.Size = new Size(143, 19);
            Always2.TabIndex = 2;
            Always2.Text = "Permanently writeable";
            Always2.UseVisualStyleBackColor = true;
            // 
            // Proect2
            // 
            Proect2.AutoSize = true;
            Proect2.Location = new Point(8, 57);
            Proect2.Margin = new Padding(4, 3, 4, 3);
            Proect2.Name = "Proect2";
            Proect2.Size = new Size(196, 19);
            Proect2.TabIndex = 1;
            Proect2.Text = "Writeable from the secured state";
            Proect2.UseVisualStyleBackColor = true;
            // 
            // NoProect2
            // 
            NoProect2.AutoSize = true;
            NoProect2.Checked = true;
            NoProect2.Location = new Point(8, 24);
            NoProect2.Margin = new Padding(4, 3, 4, 3);
            NoProect2.Name = "NoProect2";
            NoProect2.Size = new Size(154, 19);
            NoProect2.TabIndex = 0;
            NoProect2.TabStop = true;
            NoProect2.Text = "Writeable from any state";
            NoProect2.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(87, 578);
            label35.Name = "label35";
            label35.Size = new Size(227, 15);
            label35.TabIndex = 23;
            label35.Text = "* Double-Clicking copies line to clipboard";
            // 
            // cb6C_IKnowTagLock
            // 
            cb6C_IKnowTagLock.AutoSize = true;
            cb6C_IKnowTagLock.Location = new Point(396, 304);
            cb6C_IKnowTagLock.Name = "cb6C_IKnowTagLock";
            cb6C_IKnowTagLock.Size = new Size(144, 19);
            cb6C_IKnowTagLock.TabIndex = 4;
            cb6C_IKnowTagLock.Text = "I know what I'm doing";
            cb6C_IKnowTagLock.UseVisualStyleBackColor = true;
            cb6C_IKnowTagLock.CheckedChanged += cbIKnowTagLock_CheckedChanged;
            // 
            // cb6C_IKnowTagKill
            // 
            cb6C_IKnowTagKill.AutoSize = true;
            cb6C_IKnowTagKill.Location = new Point(709, 10);
            cb6C_IKnowTagKill.Name = "cb6C_IKnowTagKill";
            cb6C_IKnowTagKill.Size = new Size(144, 19);
            cb6C_IKnowTagKill.TabIndex = 3;
            cb6C_IKnowTagKill.Text = "I know what I'm doing";
            cb6C_IKnowTagKill.UseVisualStyleBackColor = true;
            cb6C_IKnowTagKill.CheckedChanged += cbIKnowTagKill_CheckedChanged;
            // 
            // groupBox_TagKill
            // 
            groupBox_TagKill.Controls.Add(label16);
            groupBox_TagKill.Controls.Add(btn6C_KillTag);
            groupBox_TagKill.Controls.Add(txt6C_KillEPC);
            groupBox_TagKill.Controls.Add(txt6C_KillPwd);
            groupBox_TagKill.Controls.Add(label15);
            groupBox_TagKill.Enabled = false;
            groupBox_TagKill.Location = new Point(706, 27);
            groupBox_TagKill.Name = "groupBox_TagKill";
            groupBox_TagKill.Size = new Size(260, 90);
            groupBox_TagKill.TabIndex = 2;
            groupBox_TagKill.TabStop = false;
            groupBox_TagKill.Text = "Tag Kill";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(65, 54);
            label16.Name = "label16";
            label16.Size = new Size(35, 15);
            label16.TabIndex = 23;
            label16.Text = "(Hex)";
            // 
            // btn6C_KillTag
            // 
            btn6C_KillTag.Location = new Point(179, 51);
            btn6C_KillTag.Name = "btn6C_KillTag";
            btn6C_KillTag.Size = new Size(75, 30);
            btn6C_KillTag.TabIndex = 21;
            btn6C_KillTag.Text = "Kill";
            btn6C_KillTag.UseVisualStyleBackColor = true;
            btn6C_KillTag.Click += btn6C_KillTag_Click;
            // 
            // txt6C_KillEPC
            // 
            txt6C_KillEPC.Location = new Point(6, 22);
            txt6C_KillEPC.Name = "txt6C_KillEPC";
            txt6C_KillEPC.ReadOnly = true;
            txt6C_KillEPC.Size = new Size(248, 23);
            txt6C_KillEPC.TabIndex = 0;
            // 
            // txt6C_KillPwd
            // 
            txt6C_KillPwd.CharacterCasing = CharacterCasing.Upper;
            txt6C_KillPwd.Location = new Point(107, 54);
            txt6C_KillPwd.MaxLength = 8;
            txt6C_KillPwd.Name = "txt6C_KillPwd";
            txt6C_KillPwd.Size = new Size(68, 23);
            txt6C_KillPwd.TabIndex = 21;
            txt6C_KillPwd.Text = "00000000";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(23, 53);
            label15.Name = "label15";
            label15.Size = new Size(57, 30);
            label15.TabIndex = 22;
            label15.Text = "Access\r\nPassword";
            // 
            // gbTagRW
            // 
            gbTagRW.Controls.Add(btn6C_FindLength);
            gbTagRW.Controls.Add(cbReader_PollReading);
            gbTagRW.Controls.Add(txtReader_WriteData);
            gbTagRW.Controls.Add(label13);
            gbTagRW.Controls.Add(txt6C_RWLen);
            gbTagRW.Controls.Add(label12);
            gbTagRW.Controls.Add(btn6C_Clear);
            gbTagRW.Controls.Add(btn6C_Write);
            gbTagRW.Controls.Add(btn6C_Read);
            gbTagRW.Controls.Add(label11);
            gbTagRW.Controls.Add(cb6C_MemBank);
            gbTagRW.Controls.Add(txt6C_StartAddr);
            gbTagRW.Controls.Add(label10);
            gbTagRW.Controls.Add(label9);
            gbTagRW.Controls.Add(txt6C_AccessPwd);
            gbTagRW.Controls.Add(label7);
            gbTagRW.Controls.Add(txt6C_RWEPC);
            gbTagRW.Location = new Point(6, 296);
            gbTagRW.Name = "gbTagRW";
            gbTagRW.Size = new Size(378, 232);
            gbTagRW.TabIndex = 1;
            gbTagRW.TabStop = false;
            gbTagRW.Text = "Tag Read/Write";
            // 
            // btn6C_FindLength
            // 
            btn6C_FindLength.Location = new Point(228, 138);
            btn6C_FindLength.Name = "btn6C_FindLength";
            btn6C_FindLength.Size = new Size(80, 23);
            btn6C_FindLength.TabIndex = 21;
            btn6C_FindLength.Text = "Find Length";
            btn6C_FindLength.UseVisualStyleBackColor = true;
            btn6C_FindLength.Click += btn6C_FindLength_Click;
            // 
            // cbReader_PollReading
            // 
            cbReader_PollReading.AutoSize = true;
            cbReader_PollReading.Location = new Point(16, 201);
            cbReader_PollReading.Name = "cbReader_PollReading";
            cbReader_PollReading.Size = new Size(92, 19);
            cbReader_PollReading.TabIndex = 9;
            cbReader_PollReading.Text = "Poll Reading";
            cbReader_PollReading.UseVisualStyleBackColor = true;
            // 
            // txtReader_WriteData
            // 
            txtReader_WriteData.CharacterCasing = CharacterCasing.Upper;
            txtReader_WriteData.Location = new Point(70, 167);
            txtReader_WriteData.Name = "txtReader_WriteData";
            txtReader_WriteData.Size = new Size(298, 23);
            txtReader_WriteData.TabIndex = 20;
            txtReader_WriteData.TextChanged += txtReader_WriteData_TextChanged;
            txtReader_WriteData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(2, 170);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 19;
            label13.Text = "Write (Hex)";
            // 
            // txt6C_RWLen
            // 
            txt6C_RWLen.Location = new Point(152, 138);
            txt6C_RWLen.MaxLength = 4;
            txt6C_RWLen.Name = "txt6C_RWLen";
            txt6C_RWLen.Size = new Size(70, 23);
            txt6C_RWLen.TabIndex = 18;
            txt6C_RWLen.Text = "1";
            txt6C_RWLen.TextChanged += filterOnlyDigits_TextChanged;
            txt6C_RWLen.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 141);
            label12.Name = "label12";
            label12.Size = new Size(135, 15);
            label12.TabIndex = 17;
            label12.Text = "R/W Length (Word/Dec)";
            // 
            // btn6C_Clear
            // 
            btn6C_Clear.Location = new Point(292, 195);
            btn6C_Clear.Name = "btn6C_Clear";
            btn6C_Clear.Size = new Size(75, 30);
            btn6C_Clear.TabIndex = 16;
            btn6C_Clear.Text = "Clear";
            btn6C_Clear.UseVisualStyleBackColor = true;
            btn6C_Clear.Click += btn6C_Clear_Click;
            // 
            // btn6C_Write
            // 
            btn6C_Write.Enabled = false;
            btn6C_Write.Location = new Point(211, 195);
            btn6C_Write.Name = "btn6C_Write";
            btn6C_Write.Size = new Size(75, 30);
            btn6C_Write.TabIndex = 15;
            btn6C_Write.Text = "Write";
            btn6C_Write.UseVisualStyleBackColor = true;
            btn6C_Write.Click += btn6C_Write_Click;
            // 
            // btn6C_Read
            // 
            btn6C_Read.Location = new Point(130, 195);
            btn6C_Read.Name = "btn6C_Read";
            btn6C_Read.Size = new Size(75, 30);
            btn6C_Read.TabIndex = 14;
            btn6C_Read.Text = "Read";
            btn6C_Read.UseVisualStyleBackColor = true;
            btn6C_Read.Click += btn6C_Read_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(67, 54);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 13;
            label11.Text = "Memory Bank";
            // 
            // cb6C_MemBank
            // 
            cb6C_MemBank.DropDownStyle = ComboBoxStyle.DropDownList;
            cb6C_MemBank.FormattingEnabled = true;
            cb6C_MemBank.Items.AddRange(new object[] { "RESERVED", "EPC", "TID", "USER" });
            cb6C_MemBank.Location = new Point(152, 50);
            cb6C_MemBank.Name = "cb6C_MemBank";
            cb6C_MemBank.Size = new Size(121, 23);
            cb6C_MemBank.TabIndex = 12;
            // 
            // txt6C_StartAddr
            // 
            txt6C_StartAddr.CharacterCasing = CharacterCasing.Upper;
            txt6C_StartAddr.Location = new Point(152, 109);
            txt6C_StartAddr.MaxLength = 4;
            txt6C_StartAddr.Name = "txt6C_StartAddr";
            txt6C_StartAddr.Size = new Size(70, 23);
            txt6C_StartAddr.TabIndex = 11;
            txt6C_StartAddr.Text = "0";
            txt6C_StartAddr.TextChanged += filterOnlyHex_TextChanged;
            txt6C_StartAddr.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 112);
            label10.Name = "label10";
            label10.Size = new Size(141, 15);
            label10.TabIndex = 10;
            label10.Text = "Start Address (Word/Hex)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 82);
            label9.Name = "label9";
            label9.Size = new Size(127, 15);
            label9.TabIndex = 8;
            label9.Text = "Access Password (Hex)";
            // 
            // txt6C_AccessPwd
            // 
            txt6C_AccessPwd.CharacterCasing = CharacterCasing.Upper;
            txt6C_AccessPwd.Location = new Point(152, 79);
            txt6C_AccessPwd.MaxLength = 8;
            txt6C_AccessPwd.Name = "txt6C_AccessPwd";
            txt6C_AccessPwd.Size = new Size(70, 23);
            txt6C_AccessPwd.TabIndex = 7;
            txt6C_AccessPwd.Text = "00000000";
            txt6C_AccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txt6C_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 23);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 6;
            label7.Text = "Tag EPC";
            // 
            // txt6C_RWEPC
            // 
            txt6C_RWEPC.Location = new Point(61, 19);
            txt6C_RWEPC.Name = "txt6C_RWEPC";
            txt6C_RWEPC.ReadOnly = true;
            txt6C_RWEPC.Size = new Size(307, 23);
            txt6C_RWEPC.TabIndex = 5;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btn6C_QueryReaderFilter);
            groupBox6.Controls.Add(label14);
            groupBox6.Controls.Add(btn6C_Inventory);
            groupBox6.Controls.Add(lvInventory);
            groupBox6.Location = new Point(6, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(694, 287);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "Inventory";
            // 
            // btn6C_QueryReaderFilter
            // 
            btn6C_QueryReaderFilter.Location = new Point(450, 249);
            btn6C_QueryReaderFilter.Name = "btn6C_QueryReaderFilter";
            btn6C_QueryReaderFilter.Size = new Size(130, 32);
            btn6C_QueryReaderFilter.TabIndex = 22;
            btn6C_QueryReaderFilter.Text = "Query Reader Filter";
            btn6C_QueryReaderFilter.UseVisualStyleBackColor = true;
            btn6C_QueryReaderFilter.Click += btn6C_QueryReaderFilter_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 246);
            label14.Name = "label14";
            label14.Size = new Size(150, 15);
            label14.TabIndex = 21;
            label14.Text = "Double-click to select a tag";
            // 
            // btn6C_Inventory
            // 
            btn6C_Inventory.Location = new Point(586, 249);
            btn6C_Inventory.Name = "btn6C_Inventory";
            btn6C_Inventory.Size = new Size(100, 32);
            btn6C_Inventory.TabIndex = 1;
            btn6C_Inventory.Text = "Inventory";
            btn6C_Inventory.UseVisualStyleBackColor = true;
            btn6C_Inventory.Click += btn6C_Inventory_Click;
            // 
            // lvInventory
            // 
            lvInventory.Columns.AddRange(new ColumnHeader[] { lvInvCol_Number, lvInvCol_PC, lvInvCol_EPC, lvInvCol_Len, lvInvCol_Count, lvInvCol_RSSI, lvInvCol_Freq });
            lvInventory.FullRowSelect = true;
            lvInventory.GridLines = true;
            lvInventory.Location = new Point(6, 22);
            lvInventory.MultiSelect = false;
            lvInventory.Name = "lvInventory";
            lvInventory.Size = new Size(680, 221);
            lvInventory.TabIndex = 0;
            lvInventory.UseCompatibleStateImageBehavior = false;
            lvInventory.View = View.Details;
            lvInventory.DoubleClick += lvInventory_DoubleClick;
            // 
            // lvInvCol_Number
            // 
            lvInvCol_Number.Text = "No.";
            lvInvCol_Number.Width = 40;
            // 
            // lvInvCol_PC
            // 
            lvInvCol_PC.Text = "PC";
            // 
            // lvInvCol_EPC
            // 
            lvInvCol_EPC.Text = "EPC";
            lvInvCol_EPC.Width = 230;
            // 
            // lvInvCol_Len
            // 
            lvInvCol_Len.Text = "Length";
            lvInvCol_Len.Width = 80;
            // 
            // lvInvCol_Count
            // 
            lvInvCol_Count.Text = "Count";
            lvInvCol_Count.Width = 80;
            // 
            // lvInvCol_RSSI
            // 
            lvInvCol_RSSI.Text = "RSSI";
            // 
            // lvInvCol_Freq
            // 
            lvInvCol_Freq.Text = "Frequency";
            lvInvCol_Freq.Width = 100;
            // 
            // lb6C_RWResults
            // 
            lb6C_RWResults.FormattingEnabled = true;
            lb6C_RWResults.HorizontalScrollbar = true;
            lb6C_RWResults.ItemHeight = 15;
            lb6C_RWResults.Location = new Point(8, 596);
            lb6C_RWResults.Name = "lb6C_RWResults";
            lb6C_RWResults.ScrollAlwaysVisible = true;
            lb6C_RWResults.Size = new Size(958, 199);
            lb6C_RWResults.TabIndex = 9;
            lb6C_RWResults.MouseDoubleClick += lb6C_RWResults_MouseDoubleClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbDisable_Write_MsgBaseSetAccessEpcMatch);
            groupBox2.Location = new Point(706, 123);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 192);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Advanced Options";
            // 
            // cbDisable_Write_MsgBaseSetAccessEpcMatch
            // 
            cbDisable_Write_MsgBaseSetAccessEpcMatch.AutoSize = true;
            cbDisable_Write_MsgBaseSetAccessEpcMatch.Location = new Point(6, 22);
            cbDisable_Write_MsgBaseSetAccessEpcMatch.Name = "cbDisable_Write_MsgBaseSetAccessEpcMatch";
            cbDisable_Write_MsgBaseSetAccessEpcMatch.Size = new Size(255, 19);
            cbDisable_Write_MsgBaseSetAccessEpcMatch.TabIndex = 10;
            cbDisable_Write_MsgBaseSetAccessEpcMatch.Text = "Disable MsgBaseSetAccessEpcMatch Check";
            cbDisable_Write_MsgBaseSetAccessEpcMatch.UseVisualStyleBackColor = true;
            // 
            // TabSheet_DUP
            // 
            TabSheet_DUP.Controls.Add(groupDuplicateUI);
            TabSheet_DUP.Location = new Point(4, 24);
            TabSheet_DUP.Name = "TabSheet_DUP";
            TabSheet_DUP.Size = new Size(975, 803);
            TabSheet_DUP.TabIndex = 3;
            TabSheet_DUP.Text = "Duplicator";
            TabSheet_DUP.UseVisualStyleBackColor = true;
            // 
            // groupDuplicateUI
            // 
            groupDuplicateUI.Controls.Add(groupBox11);
            groupDuplicateUI.Controls.Add(groupBox9);
            groupDuplicateUI.Controls.Add(groupBox10);
            groupDuplicateUI.Location = new Point(4, 3);
            groupDuplicateUI.Margin = new Padding(4, 3, 4, 3);
            groupDuplicateUI.Name = "groupDuplicateUI";
            groupDuplicateUI.Padding = new Padding(4, 3, 4, 3);
            groupDuplicateUI.Size = new Size(909, 675);
            groupDuplicateUI.TabIndex = 5;
            groupDuplicateUI.TabStop = false;
            groupDuplicateUI.Text = "Card Duplication Information";
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(lblDup_WriteTID);
            groupBox11.Controls.Add(txtDup_Write_EPC);
            groupBox11.Controls.Add(txtDup_Write_FullEPC);
            groupBox11.Controls.Add(btnDup_WriteTID);
            groupBox11.Controls.Add(txtDup_Write_UserData);
            groupBox11.Controls.Add(txtDup_Write_AccessPwd);
            groupBox11.Controls.Add(btnDup_WriteClear);
            groupBox11.Controls.Add(txtDup_Write_TID);
            groupBox11.Controls.Add(txtDup_Write_KillPwd);
            groupBox11.Controls.Add(btnDup_WriteEPC);
            groupBox11.Controls.Add(btnDup_WriteUser);
            groupBox11.Controls.Add(btnDup_WriteRFU);
            groupBox11.Location = new Point(407, 19);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(336, 309);
            groupBox11.TabIndex = 83;
            groupBox11.TabStop = false;
            groupBox11.Text = "Write";
            // 
            // lblDup_WriteTID
            // 
            lblDup_WriteTID.AutoSize = true;
            lblDup_WriteTID.Location = new Point(10, 36);
            lblDup_WriteTID.Margin = new Padding(4, 0, 4, 0);
            lblDup_WriteTID.Name = "lblDup_WriteTID";
            lblDup_WriteTID.Size = new Size(134, 15);
            lblDup_WriteTID.TabIndex = 41;
            lblDup_WriteTID.Text = "(XXX Bits) (XXXX Words)";
            lblDup_WriteTID.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Write_EPC
            // 
            txtDup_Write_EPC.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_EPC.Location = new Point(7, 160);
            txtDup_Write_EPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_EPC.Name = "txtDup_Write_EPC";
            txtDup_Write_EPC.ReadOnly = true;
            txtDup_Write_EPC.Size = new Size(279, 23);
            txtDup_Write_EPC.TabIndex = 11;
            txtDup_Write_EPC.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_EPC.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Write_FullEPC
            // 
            txtDup_Write_FullEPC.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_FullEPC.Location = new Point(7, 189);
            txtDup_Write_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_FullEPC.Name = "txtDup_Write_FullEPC";
            txtDup_Write_FullEPC.Size = new Size(279, 23);
            txtDup_Write_FullEPC.TabIndex = 12;
            txtDup_Write_FullEPC.TextChanged += txtDup_Write_FullEPC_TextChanged;
            txtDup_Write_FullEPC.KeyPress += filterOnlyHex_KeyPress;
            // 
            // btnDup_WriteTID
            // 
            btnDup_WriteTID.Enabled = false;
            btnDup_WriteTID.Image = (Image)resources.GetObject("btnDup_WriteTID.Image");
            btnDup_WriteTID.Location = new Point(296, 97);
            btnDup_WriteTID.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteTID.Name = "btnDup_WriteTID";
            btnDup_WriteTID.Size = new Size(24, 24);
            btnDup_WriteTID.TabIndex = 81;
            btnDup_WriteTID.UseVisualStyleBackColor = true;
            btnDup_WriteTID.Click += btnDup_WriteTID_Click;
            // 
            // txtDup_Write_UserData
            // 
            txtDup_Write_UserData.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_UserData.Location = new Point(7, 218);
            txtDup_Write_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_UserData.Name = "txtDup_Write_UserData";
            txtDup_Write_UserData.Size = new Size(279, 23);
            txtDup_Write_UserData.TabIndex = 13;
            txtDup_Write_UserData.TextChanged += txtDup_Write_UserData_TextChanged;
            txtDup_Write_UserData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Write_AccessPwd
            // 
            txtDup_Write_AccessPwd.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_AccessPwd.Location = new Point(162, 247);
            txtDup_Write_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_AccessPwd.MaxLength = 8;
            txtDup_Write_AccessPwd.Name = "txtDup_Write_AccessPwd";
            txtDup_Write_AccessPwd.Size = new Size(105, 23);
            txtDup_Write_AccessPwd.TabIndex = 14;
            txtDup_Write_AccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // btnDup_WriteClear
            // 
            btnDup_WriteClear.Location = new Point(270, 0);
            btnDup_WriteClear.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteClear.Name = "btnDup_WriteClear";
            btnDup_WriteClear.Size = new Size(59, 23);
            btnDup_WriteClear.TabIndex = 78;
            btnDup_WriteClear.Text = "Clear";
            btnDup_WriteClear.UseVisualStyleBackColor = true;
            btnDup_WriteClear.Click += btnDup_WriteClear_Click;
            // 
            // txtDup_Write_TID
            // 
            txtDup_Write_TID.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_TID.Location = new Point(9, 55);
            txtDup_Write_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_TID.Multiline = true;
            txtDup_Write_TID.Name = "txtDup_Write_TID";
            txtDup_Write_TID.Size = new Size(279, 66);
            txtDup_Write_TID.TabIndex = 39;
            txtDup_Write_TID.TextChanged += txtDup_Write_TID_TextChanged;
            txtDup_Write_TID.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Write_KillPwd
            // 
            txtDup_Write_KillPwd.CharacterCasing = CharacterCasing.Upper;
            txtDup_Write_KillPwd.Location = new Point(28, 247);
            txtDup_Write_KillPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_KillPwd.MaxLength = 8;
            txtDup_Write_KillPwd.Name = "txtDup_Write_KillPwd";
            txtDup_Write_KillPwd.Size = new Size(105, 23);
            txtDup_Write_KillPwd.TabIndex = 50;
            txtDup_Write_KillPwd.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_KillPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // btnDup_WriteEPC
            // 
            btnDup_WriteEPC.Enabled = false;
            btnDup_WriteEPC.Image = (Image)resources.GetObject("btnDup_WriteEPC.Image");
            btnDup_WriteEPC.Location = new Point(299, 189);
            btnDup_WriteEPC.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteEPC.Name = "btnDup_WriteEPC";
            btnDup_WriteEPC.Size = new Size(24, 24);
            btnDup_WriteEPC.TabIndex = 51;
            btnDup_WriteEPC.UseVisualStyleBackColor = true;
            btnDup_WriteEPC.Click += btnDup_WriteEPC_Click;
            // 
            // btnDup_WriteUser
            // 
            btnDup_WriteUser.Enabled = false;
            btnDup_WriteUser.Image = (Image)resources.GetObject("btnDup_WriteUser.Image");
            btnDup_WriteUser.Location = new Point(299, 217);
            btnDup_WriteUser.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteUser.Name = "btnDup_WriteUser";
            btnDup_WriteUser.Size = new Size(24, 24);
            btnDup_WriteUser.TabIndex = 52;
            btnDup_WriteUser.UseVisualStyleBackColor = true;
            btnDup_WriteUser.Click += btnDup_WriteUser_Click;
            // 
            // btnDup_WriteRFU
            // 
            btnDup_WriteRFU.Image = (Image)resources.GetObject("btnDup_WriteRFU.Image");
            btnDup_WriteRFU.Location = new Point(299, 247);
            btnDup_WriteRFU.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteRFU.Name = "btnDup_WriteRFU";
            btnDup_WriteRFU.Size = new Size(24, 24);
            btnDup_WriteRFU.TabIndex = 53;
            btnDup_WriteRFU.UseVisualStyleBackColor = true;
            btnDup_WriteRFU.Click += btnDup_WriteRFU_Click;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(btnDup_ReadClear);
            groupBox9.Controls.Add(btnDup_SaveReadData);
            groupBox9.Controls.Add(btnDup_LoadReadData);
            groupBox9.Controls.Add(lblDup_ReadTID);
            groupBox9.Controls.Add(txtDup_Read_EPC);
            groupBox9.Controls.Add(txtDup_Read_FullEPC);
            groupBox9.Controls.Add(label38);
            groupBox9.Controls.Add(label39);
            groupBox9.Controls.Add(label40);
            groupBox9.Controls.Add(label41);
            groupBox9.Controls.Add(txtDup_Read_UserData);
            groupBox9.Controls.Add(txtDup_Read_AccessPwd);
            groupBox9.Controls.Add(txtDup_Read_TID);
            groupBox9.Controls.Add(txtDup_Read_CRC);
            groupBox9.Controls.Add(label50);
            groupBox9.Controls.Add(label51);
            groupBox9.Controls.Add(txtDup_Read_PC);
            groupBox9.Controls.Add(label56);
            groupBox9.Controls.Add(label49);
            groupBox9.Controls.Add(txtDup_Read_UserDataLen);
            groupBox9.Controls.Add(txtDup_Read_KillPwd);
            groupBox9.Controls.Add(label61);
            groupBox9.Controls.Add(txtDup_Read_FullEPCLen);
            groupBox9.Controls.Add(groupBox28);
            groupBox9.Controls.Add(groupBox29);
            groupBox9.Controls.Add(btnDup_ReadTID);
            groupBox9.Controls.Add(btnDup_ReadEPC);
            groupBox9.Controls.Add(btnDup_ReadUser);
            groupBox9.Controls.Add(btnDup_ReadRFU);
            groupBox9.Location = new Point(7, 19);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(394, 645);
            groupBox9.TabIndex = 82;
            groupBox9.TabStop = false;
            groupBox9.Text = "Read";
            // 
            // btnDup_ReadClear
            // 
            btnDup_ReadClear.Location = new Point(328, 0);
            btnDup_ReadClear.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadClear.Name = "btnDup_ReadClear";
            btnDup_ReadClear.Size = new Size(59, 23);
            btnDup_ReadClear.TabIndex = 77;
            btnDup_ReadClear.Text = "Clear";
            btnDup_ReadClear.UseVisualStyleBackColor = true;
            btnDup_ReadClear.Click += btnDup_ReadClear_Click;
            // 
            // btnDup_SaveReadData
            // 
            btnDup_SaveReadData.Location = new Point(206, 0);
            btnDup_SaveReadData.Margin = new Padding(4, 3, 4, 3);
            btnDup_SaveReadData.Name = "btnDup_SaveReadData";
            btnDup_SaveReadData.Size = new Size(59, 23);
            btnDup_SaveReadData.TabIndex = 36;
            btnDup_SaveReadData.Text = "Save";
            btnDup_SaveReadData.UseVisualStyleBackColor = true;
            btnDup_SaveReadData.Click += btnDup_SaveReadData_Click;
            // 
            // btnDup_LoadReadData
            // 
            btnDup_LoadReadData.Location = new Point(267, 0);
            btnDup_LoadReadData.Margin = new Padding(4, 3, 4, 3);
            btnDup_LoadReadData.Name = "btnDup_LoadReadData";
            btnDup_LoadReadData.Size = new Size(59, 23);
            btnDup_LoadReadData.TabIndex = 37;
            btnDup_LoadReadData.Text = "Load";
            btnDup_LoadReadData.UseVisualStyleBackColor = true;
            btnDup_LoadReadData.Click += btnDup_LoadReadData_Click;
            // 
            // lblDup_ReadTID
            // 
            lblDup_ReadTID.AutoSize = true;
            lblDup_ReadTID.Location = new Point(71, 39);
            lblDup_ReadTID.Margin = new Padding(4, 0, 4, 0);
            lblDup_ReadTID.Name = "lblDup_ReadTID";
            lblDup_ReadTID.Size = new Size(134, 15);
            lblDup_ReadTID.TabIndex = 20;
            lblDup_ReadTID.Text = "(XXX Bits) (XXXX Words)";
            lblDup_ReadTID.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Read_EPC
            // 
            txtDup_Read_EPC.Location = new Point(71, 161);
            txtDup_Read_EPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_EPC.Name = "txtDup_Read_EPC";
            txtDup_Read_EPC.ReadOnly = true;
            txtDup_Read_EPC.Size = new Size(279, 23);
            txtDup_Read_EPC.TabIndex = 1;
            // 
            // txtDup_Read_FullEPC
            // 
            txtDup_Read_FullEPC.Location = new Point(71, 190);
            txtDup_Read_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_FullEPC.Name = "txtDup_Read_FullEPC";
            txtDup_Read_FullEPC.ReadOnly = true;
            txtDup_Read_FullEPC.Size = new Size(231, 23);
            txtDup_Read_FullEPC.TabIndex = 3;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(25, 165);
            label38.Margin = new Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new Size(28, 15);
            label38.TabIndex = 2;
            label38.Text = "EPC";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(10, 195);
            label39.Margin = new Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new Size(50, 15);
            label39.TabIndex = 4;
            label39.Text = "Full EPC";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(4, 223);
            label40.Margin = new Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new Size(57, 15);
            label40.TabIndex = 5;
            label40.Text = "User Data";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(157, 248);
            label41.Margin = new Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new Size(57, 30);
            label41.TabIndex = 6;
            label41.Text = "Access\r\nPassword";
            label41.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDup_Read_UserData
            // 
            txtDup_Read_UserData.Location = new Point(71, 219);
            txtDup_Read_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_UserData.Name = "txtDup_Read_UserData";
            txtDup_Read_UserData.ReadOnly = true;
            txtDup_Read_UserData.Size = new Size(231, 23);
            txtDup_Read_UserData.TabIndex = 9;
            // 
            // txtDup_Read_AccessPwd
            // 
            txtDup_Read_AccessPwd.CharacterCasing = CharacterCasing.Upper;
            txtDup_Read_AccessPwd.Location = new Point(225, 251);
            txtDup_Read_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_AccessPwd.MaxLength = 8;
            txtDup_Read_AccessPwd.Name = "txtDup_Read_AccessPwd";
            txtDup_Read_AccessPwd.Size = new Size(69, 23);
            txtDup_Read_AccessPwd.TabIndex = 10;
            txtDup_Read_AccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Read_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Read_TID
            // 
            txtDup_Read_TID.Location = new Point(71, 58);
            txtDup_Read_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_TID.Multiline = true;
            txtDup_Read_TID.Name = "txtDup_Read_TID";
            txtDup_Read_TID.ReadOnly = true;
            txtDup_Read_TID.Size = new Size(279, 66);
            txtDup_Read_TID.TabIndex = 19;
            txtDup_Read_TID.TextChanged += txtDup_Read_TID_TextChanged;
            // 
            // txtDup_Read_CRC
            // 
            txtDup_Read_CRC.Location = new Point(115, 131);
            txtDup_Read_CRC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_CRC.Name = "txtDup_Read_CRC";
            txtDup_Read_CRC.ReadOnly = true;
            txtDup_Read_CRC.Size = new Size(61, 23);
            txtDup_Read_CRC.TabIndex = 21;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new Point(76, 135);
            label50.Margin = new Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new Size(30, 15);
            label50.TabIndex = 22;
            label50.Text = "CRC";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(205, 135);
            label51.Margin = new Padding(4, 0, 4, 0);
            label51.Name = "label51";
            label51.Size = new Size(22, 15);
            label51.TabIndex = 23;
            label51.Text = "PC";
            // 
            // txtDup_Read_PC
            // 
            txtDup_Read_PC.Location = new Point(231, 131);
            txtDup_Read_PC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_PC.Name = "txtDup_Read_PC";
            txtDup_Read_PC.ReadOnly = true;
            txtDup_Read_PC.Size = new Size(61, 23);
            txtDup_Read_PC.TabIndex = 24;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new Point(25, 135);
            label56.Margin = new Padding(4, 0, 4, 0);
            label56.Name = "label56";
            label56.Size = new Size(28, 15);
            label56.TabIndex = 29;
            label56.Text = "EPC";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(25, 86);
            label49.Margin = new Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new Size(25, 15);
            label49.TabIndex = 30;
            label49.Text = "TID";
            // 
            // txtDup_Read_UserDataLen
            // 
            txtDup_Read_UserDataLen.Location = new Point(310, 219);
            txtDup_Read_UserDataLen.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_UserDataLen.Name = "txtDup_Read_UserDataLen";
            txtDup_Read_UserDataLen.ReadOnly = true;
            txtDup_Read_UserDataLen.Size = new Size(38, 23);
            txtDup_Read_UserDataLen.TabIndex = 24;
            // 
            // txtDup_Read_KillPwd
            // 
            txtDup_Read_KillPwd.CharacterCasing = CharacterCasing.Upper;
            txtDup_Read_KillPwd.Location = new Point(71, 251);
            txtDup_Read_KillPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_KillPwd.MaxLength = 8;
            txtDup_Read_KillPwd.Name = "txtDup_Read_KillPwd";
            txtDup_Read_KillPwd.Size = new Size(69, 23);
            txtDup_Read_KillPwd.TabIndex = 33;
            txtDup_Read_KillPwd.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Read_KillPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new Point(6, 248);
            label61.Margin = new Padding(4, 0, 4, 0);
            label61.Name = "label61";
            label61.Size = new Size(57, 30);
            label61.TabIndex = 34;
            label61.Text = "Kill\r\nPassword";
            label61.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Read_FullEPCLen
            // 
            txtDup_Read_FullEPCLen.Location = new Point(310, 190);
            txtDup_Read_FullEPCLen.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_FullEPCLen.Name = "txtDup_Read_FullEPCLen";
            txtDup_Read_FullEPCLen.ReadOnly = true;
            txtDup_Read_FullEPCLen.Size = new Size(38, 23);
            txtDup_Read_FullEPCLen.TabIndex = 38;
            // 
            // groupBox28
            // 
            groupBox28.Controls.Add(label48);
            groupBox28.Controls.Add(txtDup_AFI);
            groupBox28.Controls.Add(cbDup_EPCGA);
            groupBox28.Controls.Add(cbDup_XPC);
            groupBox28.Controls.Add(cbDup_UMI);
            groupBox28.Controls.Add(txtDup_EPCLength);
            groupBox28.Controls.Add(label46);
            groupBox28.Location = new Point(6, 283);
            groupBox28.Margin = new Padding(4, 3, 4, 3);
            groupBox28.Name = "groupBox28";
            groupBox28.Padding = new Padding(4, 3, 4, 3);
            groupBox28.Size = new Size(302, 173);
            groupBox28.TabIndex = 43;
            groupBox28.TabStop = false;
            groupBox28.Text = "Program Control Flags (PC)";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(20, 133);
            label48.Margin = new Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new Size(28, 30);
            label48.TabIndex = 21;
            label48.Text = "RFU\r\nAFI";
            // 
            // txtDup_AFI
            // 
            txtDup_AFI.Location = new Point(61, 137);
            txtDup_AFI.Margin = new Padding(4, 3, 4, 3);
            txtDup_AFI.Name = "txtDup_AFI";
            txtDup_AFI.ReadOnly = true;
            txtDup_AFI.Size = new Size(124, 23);
            txtDup_AFI.TabIndex = 20;
            // 
            // cbDup_EPCGA
            // 
            cbDup_EPCGA.AutoSize = true;
            cbDup_EPCGA.Enabled = false;
            cbDup_EPCGA.Location = new Point(62, 111);
            cbDup_EPCGA.Margin = new Padding(4, 3, 4, 3);
            cbDup_EPCGA.Name = "cbDup_EPCGA";
            cbDup_EPCGA.Size = new Size(213, 19);
            cbDup_EPCGA.TabIndex = 10;
            cbDup_EPCGA.Text = "EPC Global Application (T / Toggle)";
            cbDup_EPCGA.UseVisualStyleBackColor = true;
            // 
            // cbDup_XPC
            // 
            cbDup_XPC.AutoSize = true;
            cbDup_XPC.Enabled = false;
            cbDup_XPC.Location = new Point(62, 84);
            cbDup_XPC.Margin = new Padding(4, 3, 4, 3);
            cbDup_XPC.Name = "cbDup_XPC";
            cbDup_XPC.Size = new Size(239, 19);
            cbDup_XPC.TabIndex = 9;
            cbDup_XPC.Text = "Extended Protocol Control (XI / XPC W1)";
            cbDup_XPC.UseVisualStyleBackColor = true;
            // 
            // cbDup_UMI
            // 
            cbDup_UMI.AutoSize = true;
            cbDup_UMI.Enabled = false;
            cbDup_UMI.Location = new Point(62, 58);
            cbDup_UMI.Margin = new Padding(4, 3, 4, 3);
            cbDup_UMI.Name = "cbDup_UMI";
            cbDup_UMI.Size = new Size(180, 19);
            cbDup_UMI.TabIndex = 8;
            cbDup_UMI.Text = "User Memory Indicator (UMI)";
            cbDup_UMI.UseVisualStyleBackColor = true;
            // 
            // txtDup_EPCLength
            // 
            txtDup_EPCLength.Location = new Point(61, 28);
            txtDup_EPCLength.Margin = new Padding(4, 3, 4, 3);
            txtDup_EPCLength.Name = "txtDup_EPCLength";
            txtDup_EPCLength.ReadOnly = true;
            txtDup_EPCLength.Size = new Size(33, 23);
            txtDup_EPCLength.TabIndex = 19;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(8, 25);
            label46.Margin = new Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new Size(41, 30);
            label46.TabIndex = 7;
            label46.Text = "EPC\r\nWords";
            // 
            // groupBox29
            // 
            groupBox29.Controls.Add(txtDup_Read_STI_Prod);
            groupBox29.Controls.Add(txtDup_Read_STI_Manu);
            groupBox29.Controls.Add(label57);
            groupBox29.Controls.Add(txtDup_ReadTMN);
            groupBox29.Controls.Add(chkDup_ReadFileOpen);
            groupBox29.Controls.Add(chkDup_ReadAuthChlg);
            groupBox29.Controls.Add(chkDup_ReadXTID);
            groupBox29.Controls.Add(label58);
            groupBox29.Controls.Add(txtDup_ReadMDID);
            groupBox29.Location = new Point(6, 462);
            groupBox29.Margin = new Padding(4, 3, 4, 3);
            groupBox29.Name = "groupBox29";
            groupBox29.Padding = new Padding(4, 3, 4, 3);
            groupBox29.Size = new Size(286, 173);
            groupBox29.TabIndex = 44;
            groupBox29.TabStop = false;
            groupBox29.Text = "Short Tag Info (TID) (Read)";
            // 
            // txtDup_Read_STI_Prod
            // 
            txtDup_Read_STI_Prod.Location = new Point(104, 137);
            txtDup_Read_STI_Prod.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_STI_Prod.Name = "txtDup_Read_STI_Prod";
            txtDup_Read_STI_Prod.ReadOnly = true;
            txtDup_Read_STI_Prod.Size = new Size(174, 23);
            txtDup_Read_STI_Prod.TabIndex = 29;
            // 
            // txtDup_Read_STI_Manu
            // 
            txtDup_Read_STI_Manu.Location = new Point(104, 106);
            txtDup_Read_STI_Manu.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_STI_Manu.Name = "txtDup_Read_STI_Manu";
            txtDup_Read_STI_Manu.ReadOnly = true;
            txtDup_Read_STI_Manu.Size = new Size(174, 23);
            txtDup_Read_STI_Manu.TabIndex = 28;
            // 
            // label57
            // 
            label57.AutoSize = true;
            label57.Location = new Point(21, 142);
            label57.Margin = new Padding(4, 0, 4, 0);
            label57.Name = "label57";
            label57.Size = new Size(34, 15);
            label57.TabIndex = 21;
            label57.Text = "TMN";
            // 
            // txtDup_ReadTMN
            // 
            txtDup_ReadTMN.Location = new Point(61, 137);
            txtDup_ReadTMN.Margin = new Padding(4, 3, 4, 3);
            txtDup_ReadTMN.Name = "txtDup_ReadTMN";
            txtDup_ReadTMN.ReadOnly = true;
            txtDup_ReadTMN.Size = new Size(38, 23);
            txtDup_ReadTMN.TabIndex = 20;
            // 
            // chkDup_ReadFileOpen
            // 
            chkDup_ReadFileOpen.AutoSize = true;
            chkDup_ReadFileOpen.Enabled = false;
            chkDup_ReadFileOpen.Location = new Point(62, 80);
            chkDup_ReadFileOpen.Margin = new Padding(4, 3, 4, 3);
            chkDup_ReadFileOpen.Name = "chkDup_ReadFileOpen";
            chkDup_ReadFileOpen.Size = new Size(93, 19);
            chkDup_ReadFileOpen.TabIndex = 10;
            chkDup_ReadFileOpen.Text = "File Open (F)";
            chkDup_ReadFileOpen.UseVisualStyleBackColor = true;
            // 
            // chkDup_ReadAuthChlg
            // 
            chkDup_ReadAuthChlg.AutoSize = true;
            chkDup_ReadAuthChlg.Enabled = false;
            chkDup_ReadAuthChlg.Location = new Point(62, 53);
            chkDup_ReadAuthChlg.Margin = new Padding(4, 3, 4, 3);
            chkDup_ReadAuthChlg.Name = "chkDup_ReadAuthChlg";
            chkDup_ReadAuthChlg.Size = new Size(175, 19);
            chkDup_ReadAuthChlg.TabIndex = 9;
            chkDup_ReadAuthChlg.Text = "Authenticate / Challenge (S)";
            chkDup_ReadAuthChlg.UseVisualStyleBackColor = true;
            // 
            // chkDup_ReadXTID
            // 
            chkDup_ReadXTID.AutoSize = true;
            chkDup_ReadXTID.Enabled = false;
            chkDup_ReadXTID.Location = new Point(62, 27);
            chkDup_ReadXTID.Margin = new Padding(4, 3, 4, 3);
            chkDup_ReadXTID.Name = "chkDup_ReadXTID";
            chkDup_ReadXTID.Size = new Size(187, 19);
            chkDup_ReadXTID.TabIndex = 8;
            chkDup_ReadXTID.Text = "Extended Tag Identification (X)";
            chkDup_ReadXTID.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Location = new Point(16, 111);
            label58.Margin = new Padding(4, 0, 4, 0);
            label58.Name = "label58";
            label58.Size = new Size(37, 15);
            label58.TabIndex = 7;
            label58.Text = "MDID";
            // 
            // txtDup_ReadMDID
            // 
            txtDup_ReadMDID.Location = new Point(61, 106);
            txtDup_ReadMDID.Margin = new Padding(4, 3, 4, 3);
            txtDup_ReadMDID.Name = "txtDup_ReadMDID";
            txtDup_ReadMDID.ReadOnly = true;
            txtDup_ReadMDID.Size = new Size(38, 23);
            txtDup_ReadMDID.TabIndex = 19;
            // 
            // btnDup_ReadTID
            // 
            btnDup_ReadTID.Image = (Image)resources.GetObject("btnDup_ReadTID.Image");
            btnDup_ReadTID.Location = new Point(358, 101);
            btnDup_ReadTID.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadTID.Name = "btnDup_ReadTID";
            btnDup_ReadTID.Size = new Size(24, 24);
            btnDup_ReadTID.TabIndex = 45;
            btnDup_ReadTID.UseVisualStyleBackColor = true;
            btnDup_ReadTID.Click += btnDup_ReadTID_Click;
            // 
            // btnDup_ReadEPC
            // 
            btnDup_ReadEPC.Image = (Image)resources.GetObject("btnDup_ReadEPC.Image");
            btnDup_ReadEPC.Location = new Point(358, 191);
            btnDup_ReadEPC.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadEPC.Name = "btnDup_ReadEPC";
            btnDup_ReadEPC.Size = new Size(24, 24);
            btnDup_ReadEPC.TabIndex = 46;
            btnDup_ReadEPC.UseVisualStyleBackColor = true;
            btnDup_ReadEPC.Click += btnDup_ReadEPC_Click;
            // 
            // btnDup_ReadUser
            // 
            btnDup_ReadUser.Image = (Image)resources.GetObject("btnDup_ReadUser.Image");
            btnDup_ReadUser.Location = new Point(358, 219);
            btnDup_ReadUser.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadUser.Name = "btnDup_ReadUser";
            btnDup_ReadUser.Size = new Size(24, 24);
            btnDup_ReadUser.TabIndex = 48;
            btnDup_ReadUser.UseVisualStyleBackColor = true;
            btnDup_ReadUser.Click += btnDup_ReadUser_Click;
            // 
            // btnDup_ReadRFU
            // 
            btnDup_ReadRFU.Image = (Image)resources.GetObject("btnDup_ReadRFU.Image");
            btnDup_ReadRFU.Location = new Point(358, 252);
            btnDup_ReadRFU.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadRFU.Name = "btnDup_ReadRFU";
            btnDup_ReadRFU.Size = new Size(24, 24);
            btnDup_ReadRFU.TabIndex = 49;
            btnDup_ReadRFU.UseVisualStyleBackColor = true;
            btnDup_ReadRFU.Click += btnDup_ReadRFU_Click;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label19);
            groupBox10.Controls.Add(txtDup_Validate_FullEPC);
            groupBox10.Controls.Add(label24);
            groupBox10.Controls.Add(label25);
            groupBox10.Controls.Add(label23);
            groupBox10.Controls.Add(btnDup_ValidateClear);
            groupBox10.Controls.Add(txtDup_Validate_UserData);
            groupBox10.Controls.Add(btnDup_ValidateTID);
            groupBox10.Controls.Add(txtDup_Validate_AccessPwd);
            groupBox10.Controls.Add(btnDup_ValidateRFU);
            groupBox10.Controls.Add(txtDup_Validate_TID);
            groupBox10.Controls.Add(btnDup_ValidateUser);
            groupBox10.Controls.Add(txtDup_Validate_CRC);
            groupBox10.Controls.Add(btnDup_ValidateEPC);
            groupBox10.Controls.Add(label22);
            groupBox10.Controls.Add(label21);
            groupBox10.Controls.Add(label18);
            groupBox10.Controls.Add(txtDup_Validate_PC);
            groupBox10.Controls.Add(txtDup_Validate_KillPwd);
            groupBox10.Controls.Add(label20);
            groupBox10.Location = new Point(407, 334);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(397, 240);
            groupBox10.TabIndex = 83;
            groupBox10.TabStop = false;
            groupBox10.Text = "Validate";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(26, 60);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(25, 15);
            label19.TabIndex = 68;
            label19.Text = "TID";
            // 
            // txtDup_Validate_FullEPC
            // 
            txtDup_Validate_FullEPC.Location = new Point(72, 135);
            txtDup_Validate_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_FullEPC.Name = "txtDup_Validate_FullEPC";
            txtDup_Validate_FullEPC.ReadOnly = true;
            txtDup_Validate_FullEPC.Size = new Size(279, 23);
            txtDup_Validate_FullEPC.TabIndex = 56;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(11, 140);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(50, 15);
            label24.TabIndex = 57;
            label24.Text = "Full EPC";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(172, 193);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(57, 30);
            label25.TabIndex = 80;
            label25.Text = "Access\r\nPassword";
            label25.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(5, 168);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(57, 15);
            label23.TabIndex = 58;
            label23.Text = "User Data";
            // 
            // btnDup_ValidateClear
            // 
            btnDup_ValidateClear.Location = new Point(331, 0);
            btnDup_ValidateClear.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateClear.Name = "btnDup_ValidateClear";
            btnDup_ValidateClear.Size = new Size(59, 23);
            btnDup_ValidateClear.TabIndex = 79;
            btnDup_ValidateClear.Text = "Clear";
            btnDup_ValidateClear.UseVisualStyleBackColor = true;
            btnDup_ValidateClear.Click += btnDup_ValidateClear_Click;
            // 
            // txtDup_Validate_UserData
            // 
            txtDup_Validate_UserData.Location = new Point(72, 164);
            txtDup_Validate_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_UserData.Name = "txtDup_Validate_UserData";
            txtDup_Validate_UserData.ReadOnly = true;
            txtDup_Validate_UserData.Size = new Size(279, 23);
            txtDup_Validate_UserData.TabIndex = 59;
            // 
            // btnDup_ValidateTID
            // 
            btnDup_ValidateTID.Image = (Image)resources.GetObject("btnDup_ValidateTID.Image");
            btnDup_ValidateTID.Location = new Point(359, 75);
            btnDup_ValidateTID.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateTID.Name = "btnDup_ValidateTID";
            btnDup_ValidateTID.Size = new Size(24, 24);
            btnDup_ValidateTID.TabIndex = 76;
            btnDup_ValidateTID.UseVisualStyleBackColor = true;
            btnDup_ValidateTID.Click += btnDup_ValidateTID_Click;
            // 
            // txtDup_Validate_AccessPwd
            // 
            txtDup_Validate_AccessPwd.Location = new Point(237, 196);
            txtDup_Validate_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_AccessPwd.Name = "txtDup_Validate_AccessPwd";
            txtDup_Validate_AccessPwd.ReadOnly = true;
            txtDup_Validate_AccessPwd.Size = new Size(69, 23);
            txtDup_Validate_AccessPwd.TabIndex = 60;
            // 
            // btnDup_ValidateRFU
            // 
            btnDup_ValidateRFU.Image = (Image)resources.GetObject("btnDup_ValidateRFU.Image");
            btnDup_ValidateRFU.Location = new Point(359, 196);
            btnDup_ValidateRFU.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateRFU.Name = "btnDup_ValidateRFU";
            btnDup_ValidateRFU.Size = new Size(24, 24);
            btnDup_ValidateRFU.TabIndex = 75;
            btnDup_ValidateRFU.UseVisualStyleBackColor = true;
            btnDup_ValidateRFU.Click += btnDup_ValidateRFU_Click;
            // 
            // txtDup_Validate_TID
            // 
            txtDup_Validate_TID.Location = new Point(72, 32);
            txtDup_Validate_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_TID.Multiline = true;
            txtDup_Validate_TID.Name = "txtDup_Validate_TID";
            txtDup_Validate_TID.ReadOnly = true;
            txtDup_Validate_TID.Size = new Size(279, 66);
            txtDup_Validate_TID.TabIndex = 61;
            // 
            // btnDup_ValidateUser
            // 
            btnDup_ValidateUser.Image = (Image)resources.GetObject("btnDup_ValidateUser.Image");
            btnDup_ValidateUser.Location = new Point(359, 164);
            btnDup_ValidateUser.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateUser.Name = "btnDup_ValidateUser";
            btnDup_ValidateUser.Size = new Size(24, 24);
            btnDup_ValidateUser.TabIndex = 74;
            btnDup_ValidateUser.UseVisualStyleBackColor = true;
            btnDup_ValidateUser.Click += btnDup_ValidateUser_Click;
            // 
            // txtDup_Validate_CRC
            // 
            txtDup_Validate_CRC.Location = new Point(116, 105);
            txtDup_Validate_CRC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_CRC.Name = "txtDup_Validate_CRC";
            txtDup_Validate_CRC.ReadOnly = true;
            txtDup_Validate_CRC.Size = new Size(61, 23);
            txtDup_Validate_CRC.TabIndex = 62;
            // 
            // btnDup_ValidateEPC
            // 
            btnDup_ValidateEPC.Image = (Image)resources.GetObject("btnDup_ValidateEPC.Image");
            btnDup_ValidateEPC.Location = new Point(359, 136);
            btnDup_ValidateEPC.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateEPC.Name = "btnDup_ValidateEPC";
            btnDup_ValidateEPC.Size = new Size(24, 24);
            btnDup_ValidateEPC.TabIndex = 73;
            btnDup_ValidateEPC.UseVisualStyleBackColor = true;
            btnDup_ValidateEPC.Click += btnDup_ValidateEPC_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(77, 109);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(30, 15);
            label22.TabIndex = 63;
            label22.Text = "CRC";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(206, 109);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(22, 15);
            label21.TabIndex = 64;
            label21.Text = "PC";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(7, 193);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(57, 30);
            label18.TabIndex = 70;
            label18.Text = "Kill\r\nPassword";
            label18.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Validate_PC
            // 
            txtDup_Validate_PC.Location = new Point(232, 105);
            txtDup_Validate_PC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_PC.Name = "txtDup_Validate_PC";
            txtDup_Validate_PC.ReadOnly = true;
            txtDup_Validate_PC.Size = new Size(61, 23);
            txtDup_Validate_PC.TabIndex = 65;
            // 
            // txtDup_Validate_KillPwd
            // 
            txtDup_Validate_KillPwd.Location = new Point(72, 196);
            txtDup_Validate_KillPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_KillPwd.Name = "txtDup_Validate_KillPwd";
            txtDup_Validate_KillPwd.ReadOnly = true;
            txtDup_Validate_KillPwd.Size = new Size(69, 23);
            txtDup_Validate_KillPwd.TabIndex = 69;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(26, 109);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(28, 15);
            label20.TabIndex = 67;
            label20.Text = "EPC";
            // 
            // TabSheet_LOG
            // 
            TabSheet_LOG.Controls.Add(groupBox5);
            TabSheet_LOG.Controls.Add(groupBox4);
            TabSheet_LOG.Location = new Point(4, 24);
            TabSheet_LOG.Name = "TabSheet_LOG";
            TabSheet_LOG.Size = new Size(975, 803);
            TabSheet_LOG.TabIndex = 6;
            TabSheet_LOG.Text = "Logging";
            TabSheet_LOG.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbSerialLog);
            groupBox5.Controls.Add(btnLogClearSerial);
            groupBox5.Location = new Point(6, 407);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(966, 390);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Serial Log";
            // 
            // lbSerialLog
            // 
            lbSerialLog.FormattingEnabled = true;
            lbSerialLog.ItemHeight = 15;
            lbSerialLog.Location = new Point(6, 28);
            lbSerialLog.Name = "lbSerialLog";
            lbSerialLog.Size = new Size(954, 349);
            lbSerialLog.TabIndex = 2;
            // 
            // btnLogClearSerial
            // 
            btnLogClearSerial.Location = new Point(891, -1);
            btnLogClearSerial.Name = "btnLogClearSerial";
            btnLogClearSerial.Size = new Size(75, 23);
            btnLogClearSerial.TabIndex = 1;
            btnLogClearSerial.Text = "Clear";
            btnLogClearSerial.UseVisualStyleBackColor = true;
            btnLogClearSerial.Click += btnLogClearSerial_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbAPILog);
            groupBox4.Controls.Add(btnLogClearAPI);
            groupBox4.Location = new Point(6, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(966, 390);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "API Log";
            // 
            // lbAPILog
            // 
            lbAPILog.FormattingEnabled = true;
            lbAPILog.ItemHeight = 15;
            lbAPILog.Location = new Point(6, 27);
            lbAPILog.Name = "lbAPILog";
            lbAPILog.Size = new Size(954, 349);
            lbAPILog.TabIndex = 1;
            // 
            // btnLogClearAPI
            // 
            btnLogClearAPI.Location = new Point(891, 0);
            btnLogClearAPI.Name = "btnLogClearAPI";
            btnLogClearAPI.Size = new Size(75, 23);
            btnLogClearAPI.TabIndex = 0;
            btnLogClearAPI.Text = "Clear";
            btnLogClearAPI.UseVisualStyleBackColor = true;
            btnLogClearAPI.Click += btnLogClearAPI_Click;
            // 
            // lbResponse
            // 
            lbResponse.FormattingEnabled = true;
            lbResponse.ItemHeight = 15;
            lbResponse.Location = new Point(991, 17);
            lbResponse.Name = "lbResponse";
            lbResponse.Size = new Size(479, 814);
            lbResponse.TabIndex = 2;
            // 
            // timerInventory
            // 
            timerInventory.Interval = 50;
            timerInventory.Tick += timerInventory_Tick;
            // 
            // timer6C_PollRead
            // 
            timer6C_PollRead.Interval = 1000;
            timer6C_PollRead.Tick += timer6C_PollRead_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1482, 836);
            Controls.Add(lbResponse);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ES-F3105U / UCM601";
            FormClosed += MainForm_FormClosed;
            tabControl1.ResumeLayout(false);
            TabSheet_READER.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            TabSheet_6C.ResumeLayout(false);
            TabSheet_6C.PerformLayout();
            groupBox_TagLocking.ResumeLayout(false);
            groupBox_TagLocking.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            gbLockPassword.ResumeLayout(false);
            gbLockPassword.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            gbLockTIDnUSER.ResumeLayout(false);
            gbLockTIDnUSER.PerformLayout();
            groupBox_TagKill.ResumeLayout(false);
            groupBox_TagKill.PerformLayout();
            gbTagRW.ResumeLayout(false);
            gbTagRW.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            TabSheet_DUP.ResumeLayout(false);
            groupDuplicateUI.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox28.ResumeLayout(false);
            groupBox28.PerformLayout();
            groupBox29.ResumeLayout(false);
            groupBox29.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            TabSheet_LOG.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TabSheet_READER;
        private TabPage TabSheet_6C;
        private TabPage TabSheet_DUP;
        private Button btnRefreshComPorts;
        private GroupBox groupBox1;
        internal ComboBox cbReader_COM;
        internal Label Label1;
        internal Button btnReader_COMClose;
        internal Button btnReader_COMOpen;
        private ComboBox cbReader_ComBaud;
        private Label label47;
        private GroupBox groupBox3;
        private CheckBox checkEnableSerialLog;
        private CheckBox checkEnableAPILog;
        private TabPage TabSheet_LOG;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private Button btnLogClearSerial;
        private Button btnLogClearAPI;
        private ListBox lbAPILog;
        private ListBox lbSerialLog;
        private ListBox lbResponse;
        private TextBox txtReader_FirmwareVer;
        private Label label2;
        internal Button btnReader_GetFirmware;
        internal Button btnReader_GetTXPower;
        private TextBox txtReader_TXPower;
        private Label label3;
        private ComboBox cbReader_FreqBand;
        internal Button btnReader_GetFreqBand;
        private Label label4;
        private ComboBox cbReader_ReadRFLinkProfile;
        internal Button btnReader_GetRFLinkProfile;
        private Label label5;
        internal Button btnReader_GetTemperature;
        private TextBox txtReader_Temperature;
        private Label label6;
        private GroupBox groupBox6;
        private ListView lvInventory;
        private ColumnHeader lvInvCol_Number;
        private ColumnHeader lvInvCol_EPC;
        private ColumnHeader lvInvCol_Len;
        private ColumnHeader lvInvCol_Count;
        private ColumnHeader lvInvCol_RSSI;
        private ColumnHeader lvInvCol_Freq;
        private Button btn6C_Inventory;
        private System.Windows.Forms.Timer timerInventory;
        private ColumnHeader lvInvCol_PC;
        private GroupBox gbTagRW;
        private GroupBox groupBox_TagKill;
        private CheckBox cb6C_IKnowTagKill;
        private CheckBox cb6C_IKnowTagLock;
        private TextBox txt6C_KillEPC;
        private TextBox txt6C_RWEPC;
        private Label label7;
        private Label label9;
        private TextBox txt6C_AccessPwd;
        private ListBox lb6C_RWResults;
        private Label label11;
        private ComboBox cb6C_MemBank;
        private TextBox txt6C_StartAddr;
        private Label label10;
        private TextBox txtReader_WriteData;
        private Label label13;
        private TextBox txt6C_RWLen;
        private Label label12;
        private Button btn6C_Clear;
        private Button btn6C_Write;
        private Button btn6C_Read;
        private Label label14;
        private System.Windows.Forms.Timer timer6C_PollRead;
        private Button btn6C_QueryReaderFilter;
        private Button btn6C_KillTag;
        private Label label15;
        private TextBox txt6C_KillPwd;
        private Label label16;
        private CheckBox cbReader_PollReading;
        private Button btn6C_FindLength;
        private GroupBox groupDuplicateUI;
        private GroupBox groupBox29;
        private TextBox txtDup_Read_STI_Prod;
        private TextBox txtDup_Read_STI_Manu;
        private Label label57;
        private TextBox txtDup_ReadTMN;
        private CheckBox chkDup_ReadFileOpen;
        private CheckBox chkDup_ReadAuthChlg;
        private CheckBox chkDup_ReadXTID;
        private Label label58;
        private TextBox txtDup_ReadMDID;
        private GroupBox groupBox28;
        private Label label48;
        private TextBox txtDup_AFI;
        private CheckBox cbDup_EPCGA;
        private CheckBox cbDup_XPC;
        private CheckBox cbDup_UMI;
        private TextBox txtDup_EPCLength;
        private Label label46;
        private Label lblDup_WriteTID;
        private TextBox txtDup_Write_TID;
        private TextBox txtDup_Read_FullEPCLen;
        private Button btnDup_LoadReadData;
        private Button btnDup_SaveReadData;
        private Label label61;
        private TextBox txtDup_Read_KillPwd;
        private TextBox txtDup_Read_UserDataLen;
        private Label label49;
        private Label label56;
        private TextBox txtDup_Read_PC;
        private Label label51;
        private Label label50;
        private TextBox txtDup_Read_CRC;
        private Label lblDup_ReadTID;
        private TextBox txtDup_Read_TID;
        private TextBox txtDup_Write_AccessPwd;
        private TextBox txtDup_Read_AccessPwd;
        private TextBox txtDup_Read_UserData;
        private TextBox txtDup_Write_UserData;
        private Label label41;
        private Label label40;
        private Label label39;
        private Label label38;
        private TextBox txtDup_Write_FullEPC;
        private TextBox txtDup_Write_EPC;
        private TextBox txtDup_Read_FullEPC;
        private TextBox txtDup_Read_EPC;
        internal Button btnDup_ReadRFU;
        internal Button btnDup_ReadUser;
        internal Button btnDup_ReadEPC;
        internal Button btnDup_ReadTID;
        private TextBox txtDup_Write_KillPwd;
        internal Button btnDup_WriteRFU;
        internal Button btnDup_WriteUser;
        internal Button btnDup_WriteEPC;
        internal Button btnDup_ValidateTID;
        internal Button btnDup_ValidateRFU;
        internal Button btnDup_ValidateUser;
        internal Button btnDup_ValidateEPC;
        private Label label18;
        private TextBox txtDup_Validate_KillPwd;
        private Label label19;
        private Label label20;
        private TextBox txtDup_Validate_PC;
        private Label label21;
        private Label label22;
        private TextBox txtDup_Validate_CRC;
        private TextBox txtDup_Validate_TID;
        private TextBox txtDup_Validate_AccessPwd;
        private TextBox txtDup_Validate_UserData;
        private Label label23;
        private Label label24;
        private TextBox txtDup_Validate_FullEPC;
        private Button btnDup_ReadClear;
        private Button btnDup_WriteClear;
        private TextBox txtReader_EndFreq;
        private Label label28;
        private TextBox txtReader_StartFreq;
        private Label label27;
        private GroupBox groupBox2;
        private CheckBox cbDisable_Write_MsgBaseSetAccessEpcMatch;
        internal Button btnReader_SetTXPower;
        internal Button btnReader_SaveParameters;
        internal Button btnReader_ResetParameters;
        internal Button btnReader_SaveRFLinkProfile;
        internal Button btnReader_SaveFreqBand;
        private Label label29;
        private Button btnDup_ValidateClear;
        private Label label25;
        internal Button btnDup_WriteTID;
        private GroupBox groupBox7;
        internal Button btnReader_SetCW;
        private ComboBox cbReader_CWStatus;
        internal Button btnReader_GetCW;
        private Label label17;
        private GroupBox groupBox8;
        private TextBox txtReader_RFOFFTime;
        private Label label34;
        internal Button btnReader_GetTXRFTime;
        private TextBox txtReader_RFONTime;
        internal Button btnReader_SaveTXRFTime;
        private Label label33;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private GroupBox groupBox9;
        private Label label26;
        private Label label35;
        private GroupBox groupBox_TagLocking;
        private Button btnSetProtectState;
        private GroupBox groupBox12;
        private RadioButton P_User;
        private RadioButton P_TID;
        private RadioButton P_EPC;
        private RadioButton P_Reserve;
        private TextBox txt6C_LockEPCAccessPwd;
        private Label label8;
        private GroupBox gbLockPassword;
        private RadioButton AlwaysNot;
        private RadioButton Always;
        private RadioButton Proect;
        private RadioButton NoProect;
        private GroupBox groupBox13;
        private RadioButton AccessCode;
        private RadioButton DestroyCode;
        private GroupBox gbLockTIDnUSER;
        private RadioButton AlwaysNot2;
        private RadioButton Always2;
        private RadioButton Proect2;
        private RadioButton NoProect2;
        private Label label30;
        private TextBox txt6C_LockEPCTag;
    }
}
