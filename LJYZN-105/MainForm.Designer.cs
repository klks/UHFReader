namespace LJYZN_105
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            StatusBar1 = new StatusStrip();
            tss_Status = new ToolStripStatusLabel();
            tss_COM = new ToolStripStatusLabel();
            Timer_Test_ = new System.Windows.Forms.Timer(components);
            Timer_G2_Read = new System.Windows.Forms.Timer(components);
            Timer_G2_Alarm = new System.Windows.Forms.Timer(components);
            Timer_Test_6B = new System.Windows.Forms.Timer(components);
            Timer_6B_Read = new System.Windows.Forms.Timer(components);
            Timer_6B_Write = new System.Windows.Forms.Timer(components);
            TabSheet_DUP = new TabPage();
            groupBox36 = new GroupBox();
            btnDup_MonzaQTWrite = new Button();
            btnDup_MonzaQTQuery = new Button();
            cbDup_MonzaQT_Distance = new ComboBox();
            cbDup_MonzaQT_Profile = new ComboBox();
            groupBox29 = new GroupBox();
            txtDup_Read_STI_Prod = new TextBox();
            txtDup_Read_STI_Manu = new TextBox();
            label57 = new Label();
            txtReadTMN = new TextBox();
            chkReadFileOpen = new CheckBox();
            chkReadAuthChlg = new CheckBox();
            chkReadXTID = new CheckBox();
            label58 = new Label();
            txtReadMDID = new TextBox();
            groupBox28 = new GroupBox();
            label48 = new Label();
            txtAFI = new TextBox();
            cbEPCGA = new CheckBox();
            cbXPC = new CheckBox();
            cbUMI = new CheckBox();
            txtEPCLength = new TextBox();
            label46 = new Label();
            groupBox27 = new GroupBox();
            btnDup_ResetWaveCard = new Button();
            btnDup_CreateWaveCard = new Button();
            groupBox26 = new GroupBox();
            txtDup_Write_TID_PWD = new TextBox();
            lblDup_WriteTID = new Label();
            btnDup_WriteTID = new Button();
            txtDup_Write_TID = new TextBox();
            txtDup_Read_FullEPCLen = new TextBox();
            btnLoadReadData = new Button();
            btnSaveReadData = new Button();
            txtDup_Validate_UserDataLen = new TextBox();
            label61 = new Label();
            txtDup_Read_KillPwd = new TextBox();
            txtDup_Read_UserDataLen = new TextBox();
            lblDup_ValidateTID = new Label();
            txtDup_Validate_TID = new TextBox();
            label49 = new Label();
            label56 = new Label();
            txtDup_Validate_PC = new TextBox();
            label52 = new Label();
            label53 = new Label();
            txtDup_Validate_CRC = new TextBox();
            txtDup_Read_PC = new TextBox();
            label51 = new Label();
            label50 = new Label();
            txtDup_Read_CRC = new TextBox();
            lblDup_ReadTID = new Label();
            txtDup_Read_TID = new TextBox();
            txtDup_Validate_AccessPwd = new TextBox();
            txtDup_Write_AccessPwd = new TextBox();
            txtDup_Read_AccessPwd = new TextBox();
            label45 = new Label();
            label42 = new Label();
            txtDup_Read_UserData = new TextBox();
            txtDup_Write_UserData = new TextBox();
            txtDup_Validate_UserData = new TextBox();
            label41 = new Label();
            label40 = new Label();
            label39 = new Label();
            label38 = new Label();
            txtDup_Write_FullEPC = new TextBox();
            txtDup_Write_EPC = new TextBox();
            label37 = new Label();
            txtDup_Validate_EPC = new TextBox();
            txtDup_Read_FullEPC = new TextBox();
            txtDup_Read_EPC = new TextBox();
            txtDup_Validate_FullEPC = new TextBox();
            groupBox23 = new GroupBox();
            btnDup_SearchCard = new Button();
            groupBox25 = new GroupBox();
            btnHasLockedUserBlocks = new Button();
            btnWavev2Flag = new Button();
            waveFlagRed = new Button();
            waveFlagPurple = new Button();
            waveFlagBlack = new Button();
            waveFlagBlue = new Button();
            waveFlagGreen = new Button();
            waveFlagYellow = new Button();
            groupBox24 = new GroupBox();
            btnDup_ValidateCard = new Button();
            btnDup_WriteCard = new Button();
            btnDup_ReadCard = new Button();
            TabSheet_6B = new TabPage();
            groupBox22 = new GroupBox();
            Edit_WriteData_6B = new TextBox();
            label36 = new Label();
            lb6B_list2 = new ListBox();
            SpeedButton_Clear_6B = new Button();
            SpeedButton_Check_6B = new Button();
            SpeedButton_Perm_Wr_Prot_6B = new Button();
            SpeedButton_Write_6B = new Button();
            SpeedButton_Read_6B = new Button();
            Edit_Len_6B = new TextBox();
            label35 = new Label();
            Edit_StartAddress_6B = new TextBox();
            label34 = new Label();
            ComboBox_ID1_6B = new ComboBox();
            groupBox21 = new GroupBox();
            Edit_ConditionContent_6B = new TextBox();
            Edit_Query_StartAddress_6B = new TextBox();
            label33 = new Label();
            label32 = new Label();
            Greater_6B = new RadioButton();
            Less_6B = new RadioButton();
            Different_6B = new RadioButton();
            Same_6B = new RadioButton();
            groupBox20 = new GroupBox();
            SpeedButton_Query_6B = new Button();
            Bycondition_6B = new RadioButton();
            Byone_6B = new RadioButton();
            ComboBox_IntervalTime_6B = new ComboBox();
            label31 = new Label();
            groupBox19 = new GroupBox();
            lv6B_Tags = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            TabSheet_EPCC1G2 = new TabPage();
            cb6C_IKnowTagLock = new CheckBox();
            groupBox31 = new GroupBox();
            maskLen_textBox = new TextBox();
            label44 = new Label();
            maskadr_textbox = new TextBox();
            label43 = new Label();
            checkBox1 = new CheckBox();
            groupBox18 = new GroupBox();
            Button_LockUserBlock_G2 = new Button();
            Edit_AccessCode6 = new TextBox();
            ComboBox_BlockNum = new ComboBox();
            label30 = new Label();
            label29 = new Label();
            ComboBox_EPC6 = new ComboBox();
            groupBox16 = new GroupBox();
            Label_Alarm = new Label();
            Button_CheckEASAlarm_G2 = new Button();
            Button_SetEASAlarm_G2 = new Button();
            groupBox17 = new GroupBox();
            NoAlarm_G2 = new RadioButton();
            Alarm_G2 = new RadioButton();
            Edit_AccessCode5 = new TextBox();
            label28 = new Label();
            ComboBox_EPC5 = new ComboBox();
            groupBox15 = new GroupBox();
            Button_CheckReadProtected_G2 = new Button();
            Button_RemoveReadProtect_G2 = new Button();
            Button_SetMultiReadProtect_G2 = new Button();
            Button_SetReadProtect_G2 = new Button();
            Edit_AccessCode4 = new TextBox();
            label27 = new Label();
            ComboBox_EPC4 = new ComboBox();
            groupBox14 = new GroupBox();
            Button_WriteEPC_G2 = new Button();
            Edit_AccessCode3 = new TextBox();
            label26 = new Label();
            Edit_WriteEPC = new TextBox();
            label25 = new Label();
            groupBox13 = new GroupBox();
            Button_DestroyCard = new Button();
            Edit_DestroyCode = new TextBox();
            label24 = new Label();
            ComboBox_EPC3 = new ComboBox();
            groupBox12 = new GroupBox();
            CheckBox_TID = new CheckBox();
            gbQueryTIDParams = new GroupBox();
            textBox5 = new TextBox();
            label55 = new Label();
            textBox4 = new TextBox();
            label54 = new Label();
            Button_QueryTag = new Button();
            ComboBox_IntervalTime = new ComboBox();
            label23 = new Label();
            gbTagLock = new GroupBox();
            Button_SetProtectState = new Button();
            textBox2 = new TextBox();
            label22 = new Label();
            gbLockTIDnUSER = new GroupBox();
            AlwaysNot2 = new RadioButton();
            Always2 = new RadioButton();
            Proect2 = new RadioButton();
            NoProect2 = new RadioButton();
            groupBox10 = new GroupBox();
            P_User = new RadioButton();
            P_TID = new RadioButton();
            P_EPC = new RadioButton();
            P_Reserve = new RadioButton();
            ComboBox_EPC1 = new ComboBox();
            groupBox5 = new GroupBox();
            textBox_pc = new TextBox();
            checkBox_pc = new CheckBox();
            Button_BlockWrite = new Button();
            ComboBox_EPC2 = new ComboBox();
            Button_ListClear = new Button();
            Button_BlockErase = new Button();
            Button_DataWrite = new Button();
            SpeedButton_Read_G2 = new Button();
            Edit_WriteData = new TextBox();
            Edit_AccessCode2 = new TextBox();
            txtDataLen = new TextBox();
            txtDataAddr = new TextBox();
            listBox1 = new ListBox();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            groupBox6 = new GroupBox();
            C_User = new RadioButton();
            C_TID = new RadioButton();
            C_EPC = new RadioButton();
            C_Reserve = new RadioButton();
            groupBox4 = new GroupBox();
            ListView1_EPC = new ListView();
            listViewCol_Number = new ColumnHeader();
            listViewCol_ID = new ColumnHeader();
            listViewCol_Length = new ColumnHeader();
            listViewCol_Times = new ColumnHeader();
            TabSheet_CMD = new TabPage();
            groupBox3 = new GroupBox();
            groupBox30 = new GroupBox();
            rbReader_FreqBand_Europe = new RadioButton();
            rbReader_FreqBand_Korean = new RadioButton();
            rbReader_FreqBand_US = new RadioButton();
            rbReader_FreqBand_Chinese = new RadioButton();
            rbReader_FreqBand_User = new RadioButton();
            btnReader_SetDefaultParameter = new Button();
            btnReader_SetParameter = new Button();
            ComboBox_scantime = new ComboBox();
            cbReader_SetBaud = new ComboBox();
            CheckBox_SameFre = new CheckBox();
            label17 = new Label();
            label16 = new Label();
            ComboBox_dmaxfre = new ComboBox();
            ComboBox_dminfre = new ComboBox();
            ComboBox_PowerDbm = new ComboBox();
            Edit_NewComAdr = new TextBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            progressBar1 = new ProgressBar();
            groupBox2 = new GroupBox();
            btnReader_GetReaderInfo = new Button();
            Edit_scantime = new TextBox();
            EPCC1G2 = new CheckBox();
            ISO180006B = new CheckBox();
            label11 = new Label();
            label10 = new Label();
            Edit_dmaxfre = new TextBox();
            Edit_powerdBm = new TextBox();
            Edit_Version = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            Edit_dminfre = new TextBox();
            Edit_ComAdr = new TextBox();
            Edit_Type = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            GroupBox1 = new GroupBox();
            cbReader_ComBaud = new ComboBox();
            label47 = new Label();
            cbReader_AlreadyOpenCOM = new ComboBox();
            label3 = new Label();
            btnReader_ClosePort = new Button();
            btnReader_OpenPort = new Button();
            txtReader_CmdComAddr = new TextBox();
            Label2 = new Label();
            cbReader_COM = new ComboBox();
            Label1 = new Label();
            tabControl1 = new TabControl();
            groupBox9 = new GroupBox();
            DestroyCode = new RadioButton();
            AccessCode = new RadioButton();
            NoProect = new RadioButton();
            Proect = new RadioButton();
            Always = new RadioButton();
            AlwaysNot = new RadioButton();
            gbLockPassword = new GroupBox();
            StatusBar1.SuspendLayout();
            TabSheet_DUP.SuspendLayout();
            groupBox36.SuspendLayout();
            groupBox29.SuspendLayout();
            groupBox28.SuspendLayout();
            groupBox27.SuspendLayout();
            groupBox26.SuspendLayout();
            groupBox23.SuspendLayout();
            groupBox25.SuspendLayout();
            groupBox24.SuspendLayout();
            TabSheet_6B.SuspendLayout();
            groupBox22.SuspendLayout();
            groupBox21.SuspendLayout();
            groupBox20.SuspendLayout();
            groupBox19.SuspendLayout();
            TabSheet_EPCC1G2.SuspendLayout();
            groupBox31.SuspendLayout();
            groupBox18.SuspendLayout();
            groupBox16.SuspendLayout();
            groupBox17.SuspendLayout();
            groupBox15.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox12.SuspendLayout();
            gbQueryTIDParams.SuspendLayout();
            gbTagLock.SuspendLayout();
            gbLockTIDnUSER.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            TabSheet_CMD.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox30.SuspendLayout();
            groupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            groupBox9.SuspendLayout();
            gbLockPassword.SuspendLayout();
            SuspendLayout();
            // 
            // StatusBar1
            // 
            StatusBar1.Items.AddRange(new ToolStripItem[] { tss_Status, tss_COM });
            StatusBar1.Location = new Point(0, 817);
            StatusBar1.Name = "StatusBar1";
            StatusBar1.Padding = new Padding(1, 0, 16, 0);
            StatusBar1.Size = new Size(966, 22);
            StatusBar1.TabIndex = 0;
            // 
            // tss_Status
            // 
            tss_Status.Name = "tss_Status";
            tss_Status.Size = new Size(914, 17);
            tss_Status.Spring = true;
            tss_Status.Text = "Status";
            tss_Status.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tss_COM
            // 
            tss_COM.Name = "tss_COM";
            tss_COM.Size = new Size(35, 17);
            tss_COM.Text = "COM";
            // 
            // Timer_Test_
            // 
            Timer_Test_.Tick += Timer_Test__Tick;
            // 
            // Timer_G2_Read
            // 
            Timer_G2_Read.Interval = 200;
            Timer_G2_Read.Tick += Timer_G2_Read_Tick;
            // 
            // Timer_G2_Alarm
            // 
            Timer_G2_Alarm.Tick += Timer_G2_Alarm_Tick;
            // 
            // Timer_Test_6B
            // 
            Timer_Test_6B.Tick += Timer_Test_6B_Tick;
            // 
            // Timer_6B_Read
            // 
            Timer_6B_Read.Tick += Timer_6B_Read_Tick;
            // 
            // Timer_6B_Write
            // 
            Timer_6B_Write.Tick += Timer_6B_Write_Tick;
            // 
            // TabSheet_DUP
            // 
            TabSheet_DUP.Controls.Add(groupBox36);
            TabSheet_DUP.Controls.Add(groupBox29);
            TabSheet_DUP.Controls.Add(groupBox28);
            TabSheet_DUP.Controls.Add(groupBox27);
            TabSheet_DUP.Controls.Add(groupBox26);
            TabSheet_DUP.Controls.Add(groupBox23);
            TabSheet_DUP.Controls.Add(groupBox25);
            TabSheet_DUP.Controls.Add(groupBox24);
            TabSheet_DUP.Location = new Point(4, 24);
            TabSheet_DUP.Margin = new Padding(4, 3, 4, 3);
            TabSheet_DUP.Name = "TabSheet_DUP";
            TabSheet_DUP.Padding = new Padding(4, 3, 4, 3);
            TabSheet_DUP.Size = new Size(954, 784);
            TabSheet_DUP.TabIndex = 4;
            TabSheet_DUP.Text = "Duplicator";
            TabSheet_DUP.UseVisualStyleBackColor = true;
            // 
            // groupBox36
            // 
            groupBox36.Controls.Add(btnDup_MonzaQTWrite);
            groupBox36.Controls.Add(btnDup_MonzaQTQuery);
            groupBox36.Controls.Add(cbDup_MonzaQT_Distance);
            groupBox36.Controls.Add(cbDup_MonzaQT_Profile);
            groupBox36.Location = new Point(609, 577);
            groupBox36.Name = "groupBox36";
            groupBox36.Size = new Size(181, 115);
            groupBox36.TabIndex = 23;
            groupBox36.TabStop = false;
            groupBox36.Text = "Impinj Monza QT";
            // 
            // btnDup_MonzaQTWrite
            // 
            btnDup_MonzaQTWrite.Location = new Point(93, 83);
            btnDup_MonzaQTWrite.Name = "btnDup_MonzaQTWrite";
            btnDup_MonzaQTWrite.Size = new Size(82, 23);
            btnDup_MonzaQTWrite.TabIndex = 35;
            btnDup_MonzaQTWrite.Text = "Write";
            btnDup_MonzaQTWrite.UseVisualStyleBackColor = true;
            btnDup_MonzaQTWrite.Click += btnDup_MonzaQTWrite_Click;
            // 
            // btnDup_MonzaQTQuery
            // 
            btnDup_MonzaQTQuery.Location = new Point(8, 83);
            btnDup_MonzaQTQuery.Name = "btnDup_MonzaQTQuery";
            btnDup_MonzaQTQuery.Size = new Size(82, 23);
            btnDup_MonzaQTQuery.TabIndex = 34;
            btnDup_MonzaQTQuery.Text = "Query";
            btnDup_MonzaQTQuery.UseVisualStyleBackColor = true;
            btnDup_MonzaQTQuery.Click += btnDup_MonzaQTQuery_Click;
            // 
            // cbDup_MonzaQT_Distance
            // 
            cbDup_MonzaQT_Distance.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDup_MonzaQT_Distance.FormattingEnabled = true;
            cbDup_MonzaQT_Distance.Items.AddRange(new object[] { "Range Protection Disabled", "Range Protection Enabled" });
            cbDup_MonzaQT_Distance.Location = new Point(8, 54);
            cbDup_MonzaQT_Distance.Name = "cbDup_MonzaQT_Distance";
            cbDup_MonzaQT_Distance.Size = new Size(167, 23);
            cbDup_MonzaQT_Distance.TabIndex = 33;
            // 
            // cbDup_MonzaQT_Profile
            // 
            cbDup_MonzaQT_Profile.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDup_MonzaQT_Profile.FormattingEnabled = true;
            cbDup_MonzaQT_Profile.Items.AddRange(new object[] { "Private Data Profile", "Public Data Profile" });
            cbDup_MonzaQT_Profile.Location = new Point(8, 24);
            cbDup_MonzaQT_Profile.Name = "cbDup_MonzaQT_Profile";
            cbDup_MonzaQT_Profile.Size = new Size(167, 23);
            cbDup_MonzaQT_Profile.TabIndex = 32;
            // 
            // groupBox29
            // 
            groupBox29.Controls.Add(txtDup_Read_STI_Prod);
            groupBox29.Controls.Add(txtDup_Read_STI_Manu);
            groupBox29.Controls.Add(label57);
            groupBox29.Controls.Add(txtReadTMN);
            groupBox29.Controls.Add(chkReadFileOpen);
            groupBox29.Controls.Add(chkReadAuthChlg);
            groupBox29.Controls.Add(chkReadXTID);
            groupBox29.Controls.Add(label58);
            groupBox29.Controls.Add(txtReadMDID);
            groupBox29.Location = new Point(316, 577);
            groupBox29.Margin = new Padding(4, 3, 4, 3);
            groupBox29.Name = "groupBox29";
            groupBox29.Padding = new Padding(4, 3, 4, 3);
            groupBox29.Size = new Size(286, 173);
            groupBox29.TabIndex = 22;
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
            label57.Location = new Point(20, 142);
            label57.Margin = new Padding(4, 0, 4, 0);
            label57.Name = "label57";
            label57.Size = new Size(34, 15);
            label57.TabIndex = 21;
            label57.Text = "TMN";
            // 
            // txtReadTMN
            // 
            txtReadTMN.Location = new Point(61, 137);
            txtReadTMN.Margin = new Padding(4, 3, 4, 3);
            txtReadTMN.Name = "txtReadTMN";
            txtReadTMN.ReadOnly = true;
            txtReadTMN.Size = new Size(38, 23);
            txtReadTMN.TabIndex = 20;
            // 
            // chkReadFileOpen
            // 
            chkReadFileOpen.AutoSize = true;
            chkReadFileOpen.Enabled = false;
            chkReadFileOpen.Location = new Point(61, 80);
            chkReadFileOpen.Margin = new Padding(4, 3, 4, 3);
            chkReadFileOpen.Name = "chkReadFileOpen";
            chkReadFileOpen.Size = new Size(93, 19);
            chkReadFileOpen.TabIndex = 10;
            chkReadFileOpen.Text = "File Open (F)";
            chkReadFileOpen.UseVisualStyleBackColor = true;
            // 
            // chkReadAuthChlg
            // 
            chkReadAuthChlg.AutoSize = true;
            chkReadAuthChlg.Enabled = false;
            chkReadAuthChlg.Location = new Point(61, 53);
            chkReadAuthChlg.Margin = new Padding(4, 3, 4, 3);
            chkReadAuthChlg.Name = "chkReadAuthChlg";
            chkReadAuthChlg.Size = new Size(175, 19);
            chkReadAuthChlg.TabIndex = 9;
            chkReadAuthChlg.Text = "Authenticate / Challenge (S)";
            chkReadAuthChlg.UseVisualStyleBackColor = true;
            // 
            // chkReadXTID
            // 
            chkReadXTID.AutoSize = true;
            chkReadXTID.Enabled = false;
            chkReadXTID.Location = new Point(61, 27);
            chkReadXTID.Margin = new Padding(4, 3, 4, 3);
            chkReadXTID.Name = "chkReadXTID";
            chkReadXTID.Size = new Size(187, 19);
            chkReadXTID.TabIndex = 8;
            chkReadXTID.Text = "Extended Tag Identification (X)";
            chkReadXTID.UseVisualStyleBackColor = true;
            // 
            // label58
            // 
            label58.AutoSize = true;
            label58.Location = new Point(15, 111);
            label58.Margin = new Padding(4, 0, 4, 0);
            label58.Name = "label58";
            label58.Size = new Size(37, 15);
            label58.TabIndex = 7;
            label58.Text = "MDID";
            // 
            // txtReadMDID
            // 
            txtReadMDID.Location = new Point(61, 106);
            txtReadMDID.Margin = new Padding(4, 3, 4, 3);
            txtReadMDID.Name = "txtReadMDID";
            txtReadMDID.ReadOnly = true;
            txtReadMDID.Size = new Size(38, 23);
            txtReadMDID.TabIndex = 19;
            // 
            // groupBox28
            // 
            groupBox28.Controls.Add(label48);
            groupBox28.Controls.Add(txtAFI);
            groupBox28.Controls.Add(cbEPCGA);
            groupBox28.Controls.Add(cbXPC);
            groupBox28.Controls.Add(cbUMI);
            groupBox28.Controls.Add(txtEPCLength);
            groupBox28.Controls.Add(label46);
            groupBox28.Location = new Point(7, 577);
            groupBox28.Margin = new Padding(4, 3, 4, 3);
            groupBox28.Name = "groupBox28";
            groupBox28.Padding = new Padding(4, 3, 4, 3);
            groupBox28.Size = new Size(302, 173);
            groupBox28.TabIndex = 6;
            groupBox28.TabStop = false;
            groupBox28.Text = "Program Control Flags (PC)";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(19, 133);
            label48.Margin = new Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new Size(28, 30);
            label48.TabIndex = 21;
            label48.Text = "RFU\r\nAFI";
            // 
            // txtAFI
            // 
            txtAFI.Location = new Point(61, 137);
            txtAFI.Margin = new Padding(4, 3, 4, 3);
            txtAFI.Name = "txtAFI";
            txtAFI.ReadOnly = true;
            txtAFI.Size = new Size(124, 23);
            txtAFI.TabIndex = 20;
            // 
            // cbEPCGA
            // 
            cbEPCGA.AutoSize = true;
            cbEPCGA.Enabled = false;
            cbEPCGA.Location = new Point(61, 111);
            cbEPCGA.Margin = new Padding(4, 3, 4, 3);
            cbEPCGA.Name = "cbEPCGA";
            cbEPCGA.Size = new Size(213, 19);
            cbEPCGA.TabIndex = 10;
            cbEPCGA.Text = "EPC Global Application (T / Toggle)";
            cbEPCGA.UseVisualStyleBackColor = true;
            // 
            // cbXPC
            // 
            cbXPC.AutoSize = true;
            cbXPC.Enabled = false;
            cbXPC.Location = new Point(61, 84);
            cbXPC.Margin = new Padding(4, 3, 4, 3);
            cbXPC.Name = "cbXPC";
            cbXPC.Size = new Size(239, 19);
            cbXPC.TabIndex = 9;
            cbXPC.Text = "Extended Protocol Control (XI / XPC W1)";
            cbXPC.UseVisualStyleBackColor = true;
            // 
            // cbUMI
            // 
            cbUMI.AutoSize = true;
            cbUMI.Enabled = false;
            cbUMI.Location = new Point(61, 58);
            cbUMI.Margin = new Padding(4, 3, 4, 3);
            cbUMI.Name = "cbUMI";
            cbUMI.Size = new Size(180, 19);
            cbUMI.TabIndex = 8;
            cbUMI.Text = "User Memory Indicator (UMI)";
            cbUMI.UseVisualStyleBackColor = true;
            // 
            // txtEPCLength
            // 
            txtEPCLength.Location = new Point(61, 28);
            txtEPCLength.Margin = new Padding(4, 3, 4, 3);
            txtEPCLength.Name = "txtEPCLength";
            txtEPCLength.ReadOnly = true;
            txtEPCLength.Size = new Size(33, 23);
            txtEPCLength.TabIndex = 19;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(7, 25);
            label46.Margin = new Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new Size(41, 30);
            label46.TabIndex = 7;
            label46.Text = "EPC\r\nWords";
            // 
            // groupBox27
            // 
            groupBox27.Controls.Add(btnDup_ResetWaveCard);
            groupBox27.Controls.Add(btnDup_CreateWaveCard);
            groupBox27.Location = new Point(4, 147);
            groupBox27.Margin = new Padding(4, 3, 4, 3);
            groupBox27.Name = "groupBox27";
            groupBox27.Padding = new Padding(4, 3, 4, 3);
            groupBox27.Size = new Size(306, 133);
            groupBox27.TabIndex = 5;
            groupBox27.TabStop = false;
            groupBox27.Text = "Wave Card Operations";
            // 
            // btnDup_ResetWaveCard
            // 
            btnDup_ResetWaveCard.Location = new Point(74, 78);
            btnDup_ResetWaveCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_ResetWaveCard.Name = "btnDup_ResetWaveCard";
            btnDup_ResetWaveCard.Size = new Size(141, 33);
            btnDup_ResetWaveCard.TabIndex = 1;
            btnDup_ResetWaveCard.Text = "Reset Wave v2 Card";
            btnDup_ResetWaveCard.UseVisualStyleBackColor = true;
            btnDup_ResetWaveCard.Click += btnResetWaveCard_Click;
            // 
            // btnDup_CreateWaveCard
            // 
            btnDup_CreateWaveCard.Location = new Point(74, 38);
            btnDup_CreateWaveCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_CreateWaveCard.Name = "btnDup_CreateWaveCard";
            btnDup_CreateWaveCard.Size = new Size(141, 33);
            btnDup_CreateWaveCard.TabIndex = 0;
            btnDup_CreateWaveCard.Text = "Create Wave v2 Card";
            btnDup_CreateWaveCard.UseVisualStyleBackColor = true;
            btnDup_CreateWaveCard.Click += btnCreateWaveCard_Click;
            // 
            // groupBox26
            // 
            groupBox26.Controls.Add(txtDup_Write_TID_PWD);
            groupBox26.Controls.Add(lblDup_WriteTID);
            groupBox26.Controls.Add(btnDup_WriteTID);
            groupBox26.Controls.Add(txtDup_Write_TID);
            groupBox26.Controls.Add(txtDup_Read_FullEPCLen);
            groupBox26.Controls.Add(btnLoadReadData);
            groupBox26.Controls.Add(btnSaveReadData);
            groupBox26.Controls.Add(txtDup_Validate_UserDataLen);
            groupBox26.Controls.Add(label61);
            groupBox26.Controls.Add(txtDup_Read_KillPwd);
            groupBox26.Controls.Add(txtDup_Read_UserDataLen);
            groupBox26.Controls.Add(lblDup_ValidateTID);
            groupBox26.Controls.Add(txtDup_Validate_TID);
            groupBox26.Controls.Add(label49);
            groupBox26.Controls.Add(label56);
            groupBox26.Controls.Add(txtDup_Validate_PC);
            groupBox26.Controls.Add(label52);
            groupBox26.Controls.Add(label53);
            groupBox26.Controls.Add(txtDup_Validate_CRC);
            groupBox26.Controls.Add(txtDup_Read_PC);
            groupBox26.Controls.Add(label51);
            groupBox26.Controls.Add(label50);
            groupBox26.Controls.Add(txtDup_Read_CRC);
            groupBox26.Controls.Add(lblDup_ReadTID);
            groupBox26.Controls.Add(txtDup_Read_TID);
            groupBox26.Controls.Add(txtDup_Validate_AccessPwd);
            groupBox26.Controls.Add(txtDup_Write_AccessPwd);
            groupBox26.Controls.Add(txtDup_Read_AccessPwd);
            groupBox26.Controls.Add(label45);
            groupBox26.Controls.Add(label42);
            groupBox26.Controls.Add(txtDup_Read_UserData);
            groupBox26.Controls.Add(txtDup_Write_UserData);
            groupBox26.Controls.Add(txtDup_Validate_UserData);
            groupBox26.Controls.Add(label41);
            groupBox26.Controls.Add(label40);
            groupBox26.Controls.Add(label39);
            groupBox26.Controls.Add(label38);
            groupBox26.Controls.Add(txtDup_Write_FullEPC);
            groupBox26.Controls.Add(txtDup_Write_EPC);
            groupBox26.Controls.Add(label37);
            groupBox26.Controls.Add(txtDup_Validate_EPC);
            groupBox26.Controls.Add(txtDup_Read_FullEPC);
            groupBox26.Controls.Add(txtDup_Read_EPC);
            groupBox26.Controls.Add(txtDup_Validate_FullEPC);
            groupBox26.Location = new Point(7, 284);
            groupBox26.Margin = new Padding(4, 3, 4, 3);
            groupBox26.Name = "groupBox26";
            groupBox26.Padding = new Padding(4, 3, 4, 3);
            groupBox26.Size = new Size(938, 287);
            groupBox26.TabIndex = 4;
            groupBox26.TabStop = false;
            groupBox26.Text = "Debug Information";
            // 
            // txtDup_Write_TID_PWD
            // 
            txtDup_Write_TID_PWD.Location = new Point(418, 129);
            txtDup_Write_TID_PWD.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_TID_PWD.MaxLength = 8;
            txtDup_Write_TID_PWD.Name = "txtDup_Write_TID_PWD";
            txtDup_Write_TID_PWD.Size = new Size(72, 23);
            txtDup_Write_TID_PWD.TabIndex = 42;
            txtDup_Write_TID_PWD.Text = "00000000";
            txtDup_Write_TID_PWD.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_TID_PWD.KeyPress += filterOnlyHex_KeyPress;
            // 
            // lblDup_WriteTID
            // 
            lblDup_WriteTID.AutoSize = true;
            lblDup_WriteTID.Location = new Point(361, 36);
            lblDup_WriteTID.Margin = new Padding(4, 0, 4, 0);
            lblDup_WriteTID.Name = "lblDup_WriteTID";
            lblDup_WriteTID.Size = new Size(134, 15);
            lblDup_WriteTID.TabIndex = 41;
            lblDup_WriteTID.Text = "(XXX Bits) (XXXX Words)";
            lblDup_WriteTID.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnDup_WriteTID
            // 
            btnDup_WriteTID.Location = new Point(505, 129);
            btnDup_WriteTID.Name = "btnDup_WriteTID";
            btnDup_WriteTID.Size = new Size(75, 23);
            btnDup_WriteTID.TabIndex = 40;
            btnDup_WriteTID.Text = "Write TID";
            btnDup_WriteTID.UseVisualStyleBackColor = true;
            btnDup_WriteTID.Click += btnDup_WriteTID_Click;
            // 
            // txtDup_Write_TID
            // 
            txtDup_Write_TID.Location = new Point(361, 55);
            txtDup_Write_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_TID.Multiline = true;
            txtDup_Write_TID.Name = "txtDup_Write_TID";
            txtDup_Write_TID.Size = new Size(279, 66);
            txtDup_Write_TID.TabIndex = 39;
            txtDup_Write_TID.TextChanged += txtDup_Write_TID_TextChanged;
            txtDup_Write_TID.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Read_FullEPCLen
            // 
            txtDup_Read_FullEPCLen.Location = new Point(309, 189);
            txtDup_Read_FullEPCLen.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_FullEPCLen.Name = "txtDup_Read_FullEPCLen";
            txtDup_Read_FullEPCLen.ReadOnly = true;
            txtDup_Read_FullEPCLen.Size = new Size(38, 23);
            txtDup_Read_FullEPCLen.TabIndex = 38;
            // 
            // btnLoadReadData
            // 
            btnLoadReadData.Location = new Point(290, 17);
            btnLoadReadData.Margin = new Padding(4, 3, 4, 3);
            btnLoadReadData.Name = "btnLoadReadData";
            btnLoadReadData.Size = new Size(59, 23);
            btnLoadReadData.TabIndex = 37;
            btnLoadReadData.Text = "Load";
            btnLoadReadData.UseVisualStyleBackColor = true;
            btnLoadReadData.Click += btnLoadReadData_Click;
            // 
            // btnSaveReadData
            // 
            btnSaveReadData.Location = new Point(229, 17);
            btnSaveReadData.Margin = new Padding(4, 3, 4, 3);
            btnSaveReadData.Name = "btnSaveReadData";
            btnSaveReadData.Size = new Size(59, 23);
            btnSaveReadData.TabIndex = 36;
            btnSaveReadData.Text = "Save";
            btnSaveReadData.UseVisualStyleBackColor = true;
            btnSaveReadData.Click += btnSaveReadData_Click;
            // 
            // txtDup_Validate_UserDataLen
            // 
            txtDup_Validate_UserDataLen.Location = new Point(889, 218);
            txtDup_Validate_UserDataLen.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_UserDataLen.Name = "txtDup_Validate_UserDataLen";
            txtDup_Validate_UserDataLen.ReadOnly = true;
            txtDup_Validate_UserDataLen.Size = new Size(38, 23);
            txtDup_Validate_UserDataLen.TabIndex = 35;
            // 
            // label61
            // 
            label61.AutoSize = true;
            label61.Location = new Point(4, 247);
            label61.Margin = new Padding(4, 0, 4, 0);
            label61.Name = "label61";
            label61.Size = new Size(57, 30);
            label61.TabIndex = 34;
            label61.Text = "Kill\r\nPassword";
            label61.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Read_KillPwd
            // 
            txtDup_Read_KillPwd.Location = new Point(70, 250);
            txtDup_Read_KillPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_KillPwd.Name = "txtDup_Read_KillPwd";
            txtDup_Read_KillPwd.ReadOnly = true;
            txtDup_Read_KillPwd.Size = new Size(69, 23);
            txtDup_Read_KillPwd.TabIndex = 33;
            // 
            // txtDup_Read_UserDataLen
            // 
            txtDup_Read_UserDataLen.Location = new Point(309, 218);
            txtDup_Read_UserDataLen.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_UserDataLen.Name = "txtDup_Read_UserDataLen";
            txtDup_Read_UserDataLen.ReadOnly = true;
            txtDup_Read_UserDataLen.Size = new Size(38, 23);
            txtDup_Read_UserDataLen.TabIndex = 24;
            // 
            // lblDup_ValidateTID
            // 
            lblDup_ValidateTID.AutoSize = true;
            lblDup_ValidateTID.Location = new Point(649, 38);
            lblDup_ValidateTID.Margin = new Padding(4, 0, 4, 0);
            lblDup_ValidateTID.Name = "lblDup_ValidateTID";
            lblDup_ValidateTID.Size = new Size(134, 15);
            lblDup_ValidateTID.TabIndex = 32;
            lblDup_ValidateTID.Text = "(XXX Bits) (XXXX Words)";
            lblDup_ValidateTID.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Validate_TID
            // 
            txtDup_Validate_TID.Location = new Point(648, 55);
            txtDup_Validate_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_TID.Multiline = true;
            txtDup_Validate_TID.Name = "txtDup_Validate_TID";
            txtDup_Validate_TID.ReadOnly = true;
            txtDup_Validate_TID.Size = new Size(279, 66);
            txtDup_Validate_TID.TabIndex = 31;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(23, 85);
            label49.Margin = new Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new Size(25, 15);
            label49.TabIndex = 30;
            label49.Text = "TID";
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new Point(23, 134);
            label56.Margin = new Padding(4, 0, 4, 0);
            label56.Name = "label56";
            label56.Size = new Size(28, 15);
            label56.TabIndex = 29;
            label56.Text = "EPC";
            // 
            // txtDup_Validate_PC
            // 
            txtDup_Validate_PC.Location = new Point(806, 129);
            txtDup_Validate_PC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_PC.Name = "txtDup_Validate_PC";
            txtDup_Validate_PC.ReadOnly = true;
            txtDup_Validate_PC.Size = new Size(61, 23);
            txtDup_Validate_PC.TabIndex = 28;
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new Point(779, 133);
            label52.Margin = new Padding(4, 0, 4, 0);
            label52.Name = "label52";
            label52.Size = new Size(22, 15);
            label52.TabIndex = 27;
            label52.Text = "PC";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new Point(650, 133);
            label53.Margin = new Padding(4, 0, 4, 0);
            label53.Name = "label53";
            label53.Size = new Size(30, 15);
            label53.TabIndex = 26;
            label53.Text = "CRC";
            // 
            // txtDup_Validate_CRC
            // 
            txtDup_Validate_CRC.Location = new Point(691, 129);
            txtDup_Validate_CRC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_CRC.Name = "txtDup_Validate_CRC";
            txtDup_Validate_CRC.ReadOnly = true;
            txtDup_Validate_CRC.Size = new Size(61, 23);
            txtDup_Validate_CRC.TabIndex = 25;
            // 
            // txtDup_Read_PC
            // 
            txtDup_Read_PC.Location = new Point(230, 130);
            txtDup_Read_PC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_PC.Name = "txtDup_Read_PC";
            txtDup_Read_PC.ReadOnly = true;
            txtDup_Read_PC.Size = new Size(61, 23);
            txtDup_Read_PC.TabIndex = 24;
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(203, 134);
            label51.Margin = new Padding(4, 0, 4, 0);
            label51.Name = "label51";
            label51.Size = new Size(22, 15);
            label51.TabIndex = 23;
            label51.Text = "PC";
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new Point(74, 134);
            label50.Margin = new Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new Size(30, 15);
            label50.TabIndex = 22;
            label50.Text = "CRC";
            // 
            // txtDup_Read_CRC
            // 
            txtDup_Read_CRC.Location = new Point(114, 130);
            txtDup_Read_CRC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_CRC.Name = "txtDup_Read_CRC";
            txtDup_Read_CRC.ReadOnly = true;
            txtDup_Read_CRC.Size = new Size(61, 23);
            txtDup_Read_CRC.TabIndex = 21;
            // 
            // lblDup_ReadTID
            // 
            lblDup_ReadTID.AutoSize = true;
            lblDup_ReadTID.Location = new Point(69, 38);
            lblDup_ReadTID.Margin = new Padding(4, 0, 4, 0);
            lblDup_ReadTID.Name = "lblDup_ReadTID";
            lblDup_ReadTID.Size = new Size(134, 15);
            lblDup_ReadTID.TabIndex = 20;
            lblDup_ReadTID.Text = "(XXX Bits) (XXXX Words)";
            lblDup_ReadTID.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtDup_Read_TID
            // 
            txtDup_Read_TID.Location = new Point(70, 57);
            txtDup_Read_TID.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_TID.Multiline = true;
            txtDup_Read_TID.Name = "txtDup_Read_TID";
            txtDup_Read_TID.ReadOnly = true;
            txtDup_Read_TID.Size = new Size(279, 66);
            txtDup_Read_TID.TabIndex = 19;
            // 
            // txtDup_Validate_AccessPwd
            // 
            txtDup_Validate_AccessPwd.Location = new Point(648, 247);
            txtDup_Validate_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_AccessPwd.Name = "txtDup_Validate_AccessPwd";
            txtDup_Validate_AccessPwd.ReadOnly = true;
            txtDup_Validate_AccessPwd.Size = new Size(279, 23);
            txtDup_Validate_AccessPwd.TabIndex = 18;
            // 
            // txtDup_Write_AccessPwd
            // 
            txtDup_Write_AccessPwd.Location = new Point(359, 247);
            txtDup_Write_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_AccessPwd.MaxLength = 8;
            txtDup_Write_AccessPwd.Name = "txtDup_Write_AccessPwd";
            txtDup_Write_AccessPwd.Size = new Size(279, 23);
            txtDup_Write_AccessPwd.TabIndex = 14;
            txtDup_Write_AccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Read_AccessPwd
            // 
            txtDup_Read_AccessPwd.Location = new Point(224, 250);
            txtDup_Read_AccessPwd.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_AccessPwd.Name = "txtDup_Read_AccessPwd";
            txtDup_Read_AccessPwd.ReadOnly = true;
            txtDup_Read_AccessPwd.Size = new Size(69, 23);
            txtDup_Read_AccessPwd.TabIndex = 10;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(751, 18);
            label45.Margin = new Padding(4, 0, 4, 0);
            label45.Name = "label45";
            label45.Size = new Size(48, 15);
            label45.TabIndex = 8;
            label45.Text = "Validate";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(489, 21);
            label42.Margin = new Padding(4, 0, 4, 0);
            label42.Name = "label42";
            label42.Size = new Size(35, 15);
            label42.TabIndex = 7;
            label42.Text = "Write";
            // 
            // txtDup_Read_UserData
            // 
            txtDup_Read_UserData.Location = new Point(70, 218);
            txtDup_Read_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_UserData.Name = "txtDup_Read_UserData";
            txtDup_Read_UserData.ReadOnly = true;
            txtDup_Read_UserData.Size = new Size(231, 23);
            txtDup_Read_UserData.TabIndex = 9;
            // 
            // txtDup_Write_UserData
            // 
            txtDup_Write_UserData.Location = new Point(359, 218);
            txtDup_Write_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_UserData.Name = "txtDup_Write_UserData";
            txtDup_Write_UserData.Size = new Size(279, 23);
            txtDup_Write_UserData.TabIndex = 13;
            txtDup_Write_UserData.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_UserData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Validate_UserData
            // 
            txtDup_Validate_UserData.Location = new Point(648, 218);
            txtDup_Validate_UserData.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_UserData.Name = "txtDup_Validate_UserData";
            txtDup_Validate_UserData.ReadOnly = true;
            txtDup_Validate_UserData.Size = new Size(234, 23);
            txtDup_Validate_UserData.TabIndex = 17;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(155, 247);
            label41.Margin = new Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new Size(57, 30);
            label41.TabIndex = 6;
            label41.Text = "Access\r\nPassword";
            label41.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(2, 222);
            label40.Margin = new Padding(4, 0, 4, 0);
            label40.Name = "label40";
            label40.Size = new Size(57, 15);
            label40.TabIndex = 5;
            label40.Text = "User Data";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(8, 194);
            label39.Margin = new Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new Size(50, 15);
            label39.TabIndex = 4;
            label39.Text = "Full EPC";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(23, 164);
            label38.Margin = new Padding(4, 0, 4, 0);
            label38.Name = "label38";
            label38.Size = new Size(28, 15);
            label38.TabIndex = 2;
            label38.Text = "EPC";
            // 
            // txtDup_Write_FullEPC
            // 
            txtDup_Write_FullEPC.Location = new Point(359, 189);
            txtDup_Write_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_FullEPC.Name = "txtDup_Write_FullEPC";
            txtDup_Write_FullEPC.Size = new Size(279, 23);
            txtDup_Write_FullEPC.TabIndex = 12;
            txtDup_Write_FullEPC.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_FullEPC.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDup_Write_EPC
            // 
            txtDup_Write_EPC.Location = new Point(359, 160);
            txtDup_Write_EPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Write_EPC.Name = "txtDup_Write_EPC";
            txtDup_Write_EPC.Size = new Size(279, 23);
            txtDup_Write_EPC.TabIndex = 11;
            txtDup_Write_EPC.TextChanged += filterOnlyHex_TextChanged;
            txtDup_Write_EPC.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(190, 21);
            label37.Margin = new Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new Size(33, 15);
            label37.TabIndex = 0;
            label37.Text = "Read";
            // 
            // txtDup_Validate_EPC
            // 
            txtDup_Validate_EPC.Location = new Point(648, 160);
            txtDup_Validate_EPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_EPC.Name = "txtDup_Validate_EPC";
            txtDup_Validate_EPC.ReadOnly = true;
            txtDup_Validate_EPC.Size = new Size(279, 23);
            txtDup_Validate_EPC.TabIndex = 15;
            // 
            // txtDup_Read_FullEPC
            // 
            txtDup_Read_FullEPC.Location = new Point(70, 189);
            txtDup_Read_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_FullEPC.Name = "txtDup_Read_FullEPC";
            txtDup_Read_FullEPC.ReadOnly = true;
            txtDup_Read_FullEPC.Size = new Size(231, 23);
            txtDup_Read_FullEPC.TabIndex = 3;
            // 
            // txtDup_Read_EPC
            // 
            txtDup_Read_EPC.Location = new Point(70, 160);
            txtDup_Read_EPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Read_EPC.Name = "txtDup_Read_EPC";
            txtDup_Read_EPC.ReadOnly = true;
            txtDup_Read_EPC.Size = new Size(279, 23);
            txtDup_Read_EPC.TabIndex = 1;
            // 
            // txtDup_Validate_FullEPC
            // 
            txtDup_Validate_FullEPC.Location = new Point(648, 189);
            txtDup_Validate_FullEPC.Margin = new Padding(4, 3, 4, 3);
            txtDup_Validate_FullEPC.Name = "txtDup_Validate_FullEPC";
            txtDup_Validate_FullEPC.ReadOnly = true;
            txtDup_Validate_FullEPC.Size = new Size(279, 23);
            txtDup_Validate_FullEPC.TabIndex = 16;
            // 
            // groupBox23
            // 
            groupBox23.Controls.Add(btnDup_SearchCard);
            groupBox23.Location = new Point(4, 7);
            groupBox23.Margin = new Padding(4, 3, 4, 3);
            groupBox23.Name = "groupBox23";
            groupBox23.Padding = new Padding(4, 3, 4, 3);
            groupBox23.Size = new Size(306, 133);
            groupBox23.TabIndex = 4;
            groupBox23.TabStop = false;
            groupBox23.Text = "Search For Card";
            // 
            // btnDup_SearchCard
            // 
            btnDup_SearchCard.Location = new Point(42, 45);
            btnDup_SearchCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_SearchCard.Name = "btnDup_SearchCard";
            btnDup_SearchCard.Size = new Size(219, 51);
            btnDup_SearchCard.TabIndex = 0;
            btnDup_SearchCard.Text = "Search Card";
            btnDup_SearchCard.UseVisualStyleBackColor = true;
            btnDup_SearchCard.Click += btnWaveSearchCard_Click;
            // 
            // groupBox25
            // 
            groupBox25.Controls.Add(btnHasLockedUserBlocks);
            groupBox25.Controls.Add(btnWavev2Flag);
            groupBox25.Controls.Add(waveFlagRed);
            groupBox25.Controls.Add(waveFlagPurple);
            groupBox25.Controls.Add(waveFlagBlack);
            groupBox25.Controls.Add(waveFlagBlue);
            groupBox25.Controls.Add(waveFlagGreen);
            groupBox25.Controls.Add(waveFlagYellow);
            groupBox25.Location = new Point(639, 7);
            groupBox25.Margin = new Padding(4, 3, 4, 3);
            groupBox25.Name = "groupBox25";
            groupBox25.Padding = new Padding(4, 3, 4, 3);
            groupBox25.Size = new Size(306, 270);
            groupBox25.TabIndex = 3;
            groupBox25.TabStop = false;
            groupBox25.Text = "Card Flags";
            // 
            // btnHasLockedUserBlocks
            // 
            btnHasLockedUserBlocks.BackColor = Color.Crimson;
            btnHasLockedUserBlocks.ForeColor = Color.White;
            btnHasLockedUserBlocks.Location = new Point(9, 142);
            btnHasLockedUserBlocks.Margin = new Padding(4, 3, 4, 3);
            btnHasLockedUserBlocks.Name = "btnHasLockedUserBlocks";
            btnHasLockedUserBlocks.Size = new Size(286, 33);
            btnHasLockedUserBlocks.TabIndex = 12;
            btnHasLockedUserBlocks.Text = "Has Locked User Blocks";
            btnHasLockedUserBlocks.UseVisualStyleBackColor = false;
            btnHasLockedUserBlocks.Visible = false;
            // 
            // btnWavev2Flag
            // 
            btnWavev2Flag.BackColor = Color.DeepSkyBlue;
            btnWavev2Flag.Location = new Point(156, 103);
            btnWavev2Flag.Margin = new Padding(4, 3, 4, 3);
            btnWavev2Flag.Name = "btnWavev2Flag";
            btnWavev2Flag.Size = new Size(139, 33);
            btnWavev2Flag.TabIndex = 11;
            btnWavev2Flag.Text = "WAVE V2";
            btnWavev2Flag.UseVisualStyleBackColor = false;
            btnWavev2Flag.Visible = false;
            // 
            // waveFlagRed
            // 
            waveFlagRed.BackColor = Color.Red;
            waveFlagRed.Location = new Point(10, 218);
            waveFlagRed.Margin = new Padding(4, 3, 4, 3);
            waveFlagRed.Name = "waveFlagRed";
            waveFlagRed.Size = new Size(286, 33);
            waveFlagRed.TabIndex = 9;
            waveFlagRed.Text = "RED (Card Lock Required)";
            waveFlagRed.UseVisualStyleBackColor = false;
            waveFlagRed.Visible = false;
            // 
            // waveFlagPurple
            // 
            waveFlagPurple.BackColor = Color.Purple;
            waveFlagPurple.ForeColor = Color.White;
            waveFlagPurple.Location = new Point(9, 180);
            waveFlagPurple.Margin = new Padding(4, 3, 4, 3);
            waveFlagPurple.Name = "waveFlagPurple";
            waveFlagPurple.Size = new Size(286, 33);
            waveFlagPurple.TabIndex = 8;
            waveFlagPurple.Text = "MEM LOCK (maybe wont work)";
            waveFlagPurple.UseVisualStyleBackColor = false;
            waveFlagPurple.Visible = false;
            // 
            // waveFlagBlack
            // 
            waveFlagBlack.BackColor = Color.Black;
            waveFlagBlack.ForeColor = Color.White;
            waveFlagBlack.Location = new Point(156, 62);
            waveFlagBlack.Margin = new Padding(4, 3, 4, 3);
            waveFlagBlack.Name = "waveFlagBlack";
            waveFlagBlack.Size = new Size(139, 33);
            waveFlagBlack.TabIndex = 6;
            waveFlagBlack.Text = "AFI";
            waveFlagBlack.UseVisualStyleBackColor = false;
            waveFlagBlack.Visible = false;
            // 
            // waveFlagBlue
            // 
            waveFlagBlue.BackColor = Color.Blue;
            waveFlagBlue.ForeColor = Color.White;
            waveFlagBlue.Location = new Point(156, 22);
            waveFlagBlue.Margin = new Padding(4, 3, 4, 3);
            waveFlagBlue.Name = "waveFlagBlue";
            waveFlagBlue.Size = new Size(139, 33);
            waveFlagBlue.TabIndex = 5;
            waveFlagBlue.Text = "BLUE";
            waveFlagBlue.UseVisualStyleBackColor = false;
            waveFlagBlue.Visible = false;
            // 
            // waveFlagGreen
            // 
            waveFlagGreen.BackColor = Color.Lime;
            waveFlagGreen.Location = new Point(10, 62);
            waveFlagGreen.Margin = new Padding(4, 3, 4, 3);
            waveFlagGreen.Name = "waveFlagGreen";
            waveFlagGreen.Size = new Size(139, 33);
            waveFlagGreen.TabIndex = 4;
            waveFlagGreen.Text = "USER DATA";
            waveFlagGreen.UseVisualStyleBackColor = false;
            waveFlagGreen.Visible = false;
            // 
            // waveFlagYellow
            // 
            waveFlagYellow.BackColor = Color.Yellow;
            waveFlagYellow.Location = new Point(9, 22);
            waveFlagYellow.Margin = new Padding(4, 3, 4, 3);
            waveFlagYellow.Name = "waveFlagYellow";
            waveFlagYellow.Size = new Size(139, 33);
            waveFlagYellow.TabIndex = 3;
            waveFlagYellow.Text = "EPC";
            waveFlagYellow.UseVisualStyleBackColor = false;
            waveFlagYellow.Visible = false;
            // 
            // groupBox24
            // 
            groupBox24.Controls.Add(btnDup_ValidateCard);
            groupBox24.Controls.Add(btnDup_WriteCard);
            groupBox24.Controls.Add(btnDup_ReadCard);
            groupBox24.Location = new Point(322, 7);
            groupBox24.Margin = new Padding(4, 3, 4, 3);
            groupBox24.Name = "groupBox24";
            groupBox24.Padding = new Padding(4, 3, 4, 3);
            groupBox24.Size = new Size(306, 270);
            groupBox24.TabIndex = 1;
            groupBox24.TabStop = false;
            groupBox24.Text = "Card Operations";
            // 
            // btnDup_ValidateCard
            // 
            btnDup_ValidateCard.Location = new Point(42, 189);
            btnDup_ValidateCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_ValidateCard.Name = "btnDup_ValidateCard";
            btnDup_ValidateCard.Size = new Size(219, 51);
            btnDup_ValidateCard.TabIndex = 2;
            btnDup_ValidateCard.Text = "Validate Card";
            btnDup_ValidateCard.UseVisualStyleBackColor = true;
            btnDup_ValidateCard.Click += btnDup_ValidateCard_Click;
            // 
            // btnDup_WriteCard
            // 
            btnDup_WriteCard.Location = new Point(42, 113);
            btnDup_WriteCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_WriteCard.Name = "btnDup_WriteCard";
            btnDup_WriteCard.Size = new Size(219, 51);
            btnDup_WriteCard.TabIndex = 2;
            btnDup_WriteCard.Text = "Write Card";
            btnDup_WriteCard.UseVisualStyleBackColor = true;
            btnDup_WriteCard.Click += btnDup_WriteCard_Click;
            // 
            // btnDup_ReadCard
            // 
            btnDup_ReadCard.Location = new Point(42, 37);
            btnDup_ReadCard.Margin = new Padding(4, 3, 4, 3);
            btnDup_ReadCard.Name = "btnDup_ReadCard";
            btnDup_ReadCard.Size = new Size(219, 51);
            btnDup_ReadCard.TabIndex = 1;
            btnDup_ReadCard.Text = "Read Card";
            btnDup_ReadCard.UseVisualStyleBackColor = true;
            btnDup_ReadCard.Click += btnDup_ReadCard_Click;
            // 
            // TabSheet_6B
            // 
            TabSheet_6B.Controls.Add(groupBox22);
            TabSheet_6B.Controls.Add(groupBox21);
            TabSheet_6B.Controls.Add(groupBox20);
            TabSheet_6B.Controls.Add(groupBox19);
            TabSheet_6B.Location = new Point(4, 24);
            TabSheet_6B.Margin = new Padding(4, 3, 4, 3);
            TabSheet_6B.Name = "TabSheet_6B";
            TabSheet_6B.Size = new Size(954, 784);
            TabSheet_6B.TabIndex = 3;
            TabSheet_6B.Text = "18000-6B";
            TabSheet_6B.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            groupBox22.Controls.Add(Edit_WriteData_6B);
            groupBox22.Controls.Add(label36);
            groupBox22.Controls.Add(lb6B_list2);
            groupBox22.Controls.Add(SpeedButton_Clear_6B);
            groupBox22.Controls.Add(SpeedButton_Check_6B);
            groupBox22.Controls.Add(SpeedButton_Perm_Wr_Prot_6B);
            groupBox22.Controls.Add(SpeedButton_Write_6B);
            groupBox22.Controls.Add(SpeedButton_Read_6B);
            groupBox22.Controls.Add(Edit_Len_6B);
            groupBox22.Controls.Add(label35);
            groupBox22.Controls.Add(Edit_StartAddress_6B);
            groupBox22.Controls.Add(label34);
            groupBox22.Controls.Add(ComboBox_ID1_6B);
            groupBox22.Location = new Point(383, 392);
            groupBox22.Margin = new Padding(4, 3, 4, 3);
            groupBox22.Name = "groupBox22";
            groupBox22.Padding = new Padding(4, 3, 4, 3);
            groupBox22.Size = new Size(567, 385);
            groupBox22.TabIndex = 3;
            groupBox22.TabStop = false;
            groupBox22.Text = "Read and Write Data Block / Permanently Write  Protect Block of  byte";
            // 
            // Edit_WriteData_6B
            // 
            Edit_WriteData_6B.Location = new Point(209, 106);
            Edit_WriteData_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_WriteData_6B.Name = "Edit_WriteData_6B";
            Edit_WriteData_6B.Size = new Size(350, 23);
            Edit_WriteData_6B.TabIndex = 12;
            Edit_WriteData_6B.Text = "0000";
            Edit_WriteData_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_WriteData_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(7, 110);
            label36.Margin = new Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new Size(150, 15);
            label36.TabIndex = 11;
            label36.Text = "Write Data (1-32 Byte/Hex):";
            // 
            // lb6B_list2
            // 
            lb6B_list2.FormattingEnabled = true;
            lb6B_list2.ItemHeight = 15;
            lb6B_list2.Location = new Point(7, 179);
            lb6B_list2.Margin = new Padding(4, 3, 4, 3);
            lb6B_list2.Name = "lb6B_list2";
            lb6B_list2.Size = new Size(552, 199);
            lb6B_list2.TabIndex = 10;
            // 
            // SpeedButton_Clear_6B
            // 
            SpeedButton_Clear_6B.Location = new Point(500, 143);
            SpeedButton_Clear_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Clear_6B.Name = "SpeedButton_Clear_6B";
            SpeedButton_Clear_6B.Size = new Size(59, 29);
            SpeedButton_Clear_6B.TabIndex = 9;
            SpeedButton_Clear_6B.Text = "Clear";
            SpeedButton_Clear_6B.UseVisualStyleBackColor = true;
            SpeedButton_Clear_6B.Click += SpeedButton_Clear_6B_Click;
            // 
            // SpeedButton_Check_6B
            // 
            SpeedButton_Check_6B.Location = new Point(406, 143);
            SpeedButton_Check_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Check_6B.Name = "SpeedButton_Check_6B";
            SpeedButton_Check_6B.Size = new Size(88, 29);
            SpeedButton_Check_6B.TabIndex = 8;
            SpeedButton_Check_6B.Text = "Check Protect";
            SpeedButton_Check_6B.UseVisualStyleBackColor = true;
            SpeedButton_Check_6B.Click += SpeedButton_Check_6B_Click;
            // 
            // SpeedButton_Perm_Wr_Prot_6B
            // 
            SpeedButton_Perm_Wr_Prot_6B.Location = new Point(198, 143);
            SpeedButton_Perm_Wr_Prot_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Perm_Wr_Prot_6B.Name = "SpeedButton_Perm_Wr_Prot_6B";
            SpeedButton_Perm_Wr_Prot_6B.Size = new Size(201, 29);
            SpeedButton_Perm_Wr_Prot_6B.TabIndex = 7;
            SpeedButton_Perm_Wr_Prot_6B.Text = "Permanently Write  Protect";
            SpeedButton_Perm_Wr_Prot_6B.UseVisualStyleBackColor = true;
            SpeedButton_Perm_Wr_Prot_6B.Click += SpeedButton_PermWriteProtect_6B_Click;
            // 
            // SpeedButton_Write_6B
            // 
            SpeedButton_Write_6B.Location = new Point(104, 143);
            SpeedButton_Write_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Write_6B.Name = "SpeedButton_Write_6B";
            SpeedButton_Write_6B.Size = new Size(88, 29);
            SpeedButton_Write_6B.TabIndex = 6;
            SpeedButton_Write_6B.Text = "Write";
            SpeedButton_Write_6B.UseVisualStyleBackColor = true;
            SpeedButton_Write_6B.Click += SpeedButton_Write_6B_Click;
            // 
            // SpeedButton_Read_6B
            // 
            SpeedButton_Read_6B.Location = new Point(9, 143);
            SpeedButton_Read_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Read_6B.Name = "SpeedButton_Read_6B";
            SpeedButton_Read_6B.Size = new Size(88, 29);
            SpeedButton_Read_6B.TabIndex = 5;
            SpeedButton_Read_6B.Text = "Read";
            SpeedButton_Read_6B.UseVisualStyleBackColor = true;
            SpeedButton_Read_6B.Click += SpeedButton_Read_6B_Click;
            // 
            // Edit_Len_6B
            // 
            Edit_Len_6B.Location = new Point(446, 66);
            Edit_Len_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_Len_6B.MaxLength = 2;
            Edit_Len_6B.Name = "Edit_Len_6B";
            Edit_Len_6B.Size = new Size(116, 23);
            Edit_Len_6B.TabIndex = 4;
            Edit_Len_6B.Text = "12";
            Edit_Len_6B.TextChanged += filterOnlyDigits_TextChanged;
            Edit_Len_6B.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(330, 66);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(88, 30);
            label35.TabIndex = 3;
            label35.Text = "Length of Data:\r\n(1-32/Byte/D)";
            // 
            // Edit_StartAddress_6B
            // 
            Edit_StartAddress_6B.Location = new Point(167, 66);
            Edit_StartAddress_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_StartAddress_6B.MaxLength = 2;
            Edit_StartAddress_6B.Name = "Edit_StartAddress_6B";
            Edit_StartAddress_6B.Size = new Size(116, 23);
            Edit_StartAddress_6B.TabIndex = 2;
            Edit_StartAddress_6B.Text = "00";
            Edit_StartAddress_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_StartAddress_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(7, 62);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(119, 30);
            label34.TabIndex = 1;
            label34.Text = "Start/Protect Address\r\n(00-E9)(Hex):   ";
            // 
            // ComboBox_ID1_6B
            // 
            ComboBox_ID1_6B.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_ID1_6B.FormattingEnabled = true;
            ComboBox_ID1_6B.Location = new Point(7, 21);
            ComboBox_ID1_6B.Margin = new Padding(4, 3, 4, 3);
            ComboBox_ID1_6B.Name = "ComboBox_ID1_6B";
            ComboBox_ID1_6B.Size = new Size(552, 23);
            ComboBox_ID1_6B.TabIndex = 0;
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(Edit_ConditionContent_6B);
            groupBox21.Controls.Add(Edit_Query_StartAddress_6B);
            groupBox21.Controls.Add(label33);
            groupBox21.Controls.Add(label32);
            groupBox21.Controls.Add(Greater_6B);
            groupBox21.Controls.Add(Less_6B);
            groupBox21.Controls.Add(Different_6B);
            groupBox21.Controls.Add(Same_6B);
            groupBox21.Location = new Point(1, 558);
            groupBox21.Margin = new Padding(4, 3, 4, 3);
            groupBox21.Name = "groupBox21";
            groupBox21.Padding = new Padding(4, 3, 4, 3);
            groupBox21.Size = new Size(374, 219);
            groupBox21.TabIndex = 2;
            groupBox21.TabStop = false;
            groupBox21.Text = "Query Tags by Condition";
            // 
            // Edit_ConditionContent_6B
            // 
            Edit_ConditionContent_6B.Location = new Point(211, 180);
            Edit_ConditionContent_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_ConditionContent_6B.MaxLength = 8;
            Edit_ConditionContent_6B.Name = "Edit_ConditionContent_6B";
            Edit_ConditionContent_6B.Size = new Size(114, 23);
            Edit_ConditionContent_6B.TabIndex = 7;
            Edit_ConditionContent_6B.Text = "00";
            Edit_ConditionContent_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_ConditionContent_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // Edit_Query_StartAddress_6B
            // 
            Edit_Query_StartAddress_6B.Location = new Point(211, 132);
            Edit_Query_StartAddress_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_Query_StartAddress_6B.MaxLength = 2;
            Edit_Query_StartAddress_6B.Name = "Edit_Query_StartAddress_6B";
            Edit_Query_StartAddress_6B.Size = new Size(114, 23);
            Edit_Query_StartAddress_6B.TabIndex = 6;
            Edit_Query_StartAddress_6B.Text = "0";
            Edit_Query_StartAddress_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_Query_StartAddress_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(10, 183);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(163, 15);
            label33.TabIndex = 5;
            label33.Text = "Condition(<=8 Hex Number):";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(9, 135);
            label32.Margin = new Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new Size(152, 15);
            label32.TabIndex = 4;
            label32.Text = "Address of Tag Data(0-223):";
            // 
            // Greater_6B
            // 
            Greater_6B.AutoSize = true;
            Greater_6B.Location = new Point(190, 85);
            Greater_6B.Margin = new Padding(4, 3, 4, 3);
            Greater_6B.Name = "Greater_6B";
            Greater_6B.Size = new Size(146, 19);
            Greater_6B.TabIndex = 3;
            Greater_6B.TabStop = true;
            Greater_6B.Text = "Greater than Condition";
            Greater_6B.UseVisualStyleBackColor = true;
            // 
            // Less_6B
            // 
            Less_6B.AutoSize = true;
            Less_6B.Location = new Point(9, 85);
            Less_6B.Margin = new Padding(4, 3, 4, 3);
            Less_6B.Name = "Less_6B";
            Less_6B.Size = new Size(130, 19);
            Less_6B.TabIndex = 2;
            Less_6B.TabStop = true;
            Less_6B.Text = "Less than Condition";
            Less_6B.UseVisualStyleBackColor = true;
            // 
            // Different_6B
            // 
            Different_6B.AutoSize = true;
            Different_6B.Location = new Point(190, 37);
            Different_6B.Margin = new Padding(4, 3, 4, 3);
            Different_6B.Name = "Different_6B";
            Different_6B.Size = new Size(125, 19);
            Different_6B.TabIndex = 1;
            Different_6B.TabStop = true;
            Different_6B.Text = "Unequal Condition";
            Different_6B.UseVisualStyleBackColor = true;
            // 
            // Same_6B
            // 
            Same_6B.AutoSize = true;
            Same_6B.Location = new Point(9, 37);
            Same_6B.Margin = new Padding(4, 3, 4, 3);
            Same_6B.Name = "Same_6B";
            Same_6B.Size = new Size(110, 19);
            Same_6B.TabIndex = 0;
            Same_6B.TabStop = true;
            Same_6B.Text = "Equal Condition";
            Same_6B.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            groupBox20.Controls.Add(SpeedButton_Query_6B);
            groupBox20.Controls.Add(Bycondition_6B);
            groupBox20.Controls.Add(Byone_6B);
            groupBox20.Controls.Add(ComboBox_IntervalTime_6B);
            groupBox20.Controls.Add(label31);
            groupBox20.Location = new Point(1, 392);
            groupBox20.Margin = new Padding(4, 3, 4, 3);
            groupBox20.Name = "groupBox20";
            groupBox20.Padding = new Padding(4, 3, 4, 3);
            groupBox20.Size = new Size(374, 165);
            groupBox20.TabIndex = 1;
            groupBox20.TabStop = false;
            groupBox20.Text = "Query Tag";
            // 
            // SpeedButton_Query_6B
            // 
            SpeedButton_Query_6B.Enabled = false;
            SpeedButton_Query_6B.Location = new Point(248, 80);
            SpeedButton_Query_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Query_6B.Name = "SpeedButton_Query_6B";
            SpeedButton_Query_6B.Size = new Size(119, 61);
            SpeedButton_Query_6B.TabIndex = 4;
            SpeedButton_Query_6B.Text = "Query";
            SpeedButton_Query_6B.UseVisualStyleBackColor = true;
            SpeedButton_Query_6B.Click += SpeedButton_Query_6B_Click;
            // 
            // Bycondition_6B
            // 
            Bycondition_6B.AutoSize = true;
            Bycondition_6B.Location = new Point(9, 121);
            Bycondition_6B.Margin = new Padding(4, 3, 4, 3);
            Bycondition_6B.Name = "Bycondition_6B";
            Bycondition_6B.Size = new Size(129, 19);
            Bycondition_6B.TabIndex = 3;
            Bycondition_6B.TabStop = true;
            Bycondition_6B.Text = "Query by Condition";
            Bycondition_6B.UseVisualStyleBackColor = true;
            Bycondition_6B.CheckedChanged += Bycondition_6B_CheckedChanged;
            // 
            // Byone_6B
            // 
            Byone_6B.AutoSize = true;
            Byone_6B.Location = new Point(9, 80);
            Byone_6B.Margin = new Padding(4, 3, 4, 3);
            Byone_6B.Name = "Byone_6B";
            Byone_6B.Size = new Size(96, 19);
            Byone_6B.TabIndex = 2;
            Byone_6B.TabStop = true;
            Byone_6B.Text = "Query by one";
            Byone_6B.UseVisualStyleBackColor = true;
            Byone_6B.CheckedChanged += Byone_6B_CheckedChanged;
            // 
            // ComboBox_IntervalTime_6B
            // 
            ComboBox_IntervalTime_6B.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_IntervalTime_6B.FormattingEnabled = true;
            ComboBox_IntervalTime_6B.Location = new Point(118, 17);
            ComboBox_IntervalTime_6B.Margin = new Padding(4, 3, 4, 3);
            ComboBox_IntervalTime_6B.Name = "ComboBox_IntervalTime_6B";
            ComboBox_IntervalTime_6B.Size = new Size(249, 23);
            ComboBox_IntervalTime_6B.TabIndex = 1;
            ComboBox_IntervalTime_6B.SelectedIndexChanged += ComboBox_IntervalTime_SelectedIndexChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(7, 21);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(78, 15);
            label31.TabIndex = 0;
            label31.Text = "Read Interval:";
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(lv6B_Tags);
            groupBox19.Location = new Point(1, 3);
            groupBox19.Margin = new Padding(4, 3, 4, 3);
            groupBox19.Name = "groupBox19";
            groupBox19.Padding = new Padding(4, 3, 4, 3);
            groupBox19.Size = new Size(948, 387);
            groupBox19.TabIndex = 0;
            groupBox19.TabStop = false;
            groupBox19.Text = "List ID of Tags";
            // 
            // lv6B_Tags
            // 
            lv6B_Tags.Activation = ItemActivation.OneClick;
            lv6B_Tags.AllowDrop = true;
            lv6B_Tags.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7 });
            lv6B_Tags.FullRowSelect = true;
            lv6B_Tags.GridLines = true;
            lv6B_Tags.HotTracking = true;
            lv6B_Tags.HoverSelection = true;
            lv6B_Tags.Location = new Point(7, 25);
            lv6B_Tags.Margin = new Padding(4, 3, 4, 3);
            lv6B_Tags.Name = "lv6B_Tags";
            lv6B_Tags.Size = new Size(934, 352);
            lv6B_Tags.TabIndex = 0;
            lv6B_Tags.UseCompatibleStateImageBehavior = false;
            lv6B_Tags.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "No.";
            columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "ID";
            columnHeader6.Width = 600;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Times";
            columnHeader7.Width = 90;
            // 
            // TabSheet_EPCC1G2
            // 
            TabSheet_EPCC1G2.Controls.Add(cb6C_IKnowTagLock);
            TabSheet_EPCC1G2.Controls.Add(groupBox31);
            TabSheet_EPCC1G2.Controls.Add(groupBox18);
            TabSheet_EPCC1G2.Controls.Add(groupBox16);
            TabSheet_EPCC1G2.Controls.Add(groupBox15);
            TabSheet_EPCC1G2.Controls.Add(groupBox14);
            TabSheet_EPCC1G2.Controls.Add(groupBox13);
            TabSheet_EPCC1G2.Controls.Add(groupBox12);
            TabSheet_EPCC1G2.Controls.Add(gbTagLock);
            TabSheet_EPCC1G2.Controls.Add(groupBox5);
            TabSheet_EPCC1G2.Controls.Add(groupBox4);
            TabSheet_EPCC1G2.Location = new Point(4, 24);
            TabSheet_EPCC1G2.Margin = new Padding(4, 3, 4, 3);
            TabSheet_EPCC1G2.Name = "TabSheet_EPCC1G2";
            TabSheet_EPCC1G2.Size = new Size(954, 784);
            TabSheet_EPCC1G2.TabIndex = 2;
            TabSheet_EPCC1G2.Text = "EPC C1-G2 / 6C";
            TabSheet_EPCC1G2.UseVisualStyleBackColor = true;
            // 
            // cb6C_IKnowTagLock
            // 
            cb6C_IKnowTagLock.AutoSize = true;
            cb6C_IKnowTagLock.Location = new Point(3, 760);
            cb6C_IKnowTagLock.Name = "cb6C_IKnowTagLock";
            cb6C_IKnowTagLock.Size = new Size(144, 19);
            cb6C_IKnowTagLock.TabIndex = 10;
            cb6C_IKnowTagLock.Text = "I know what I'm doing";
            cb6C_IKnowTagLock.UseVisualStyleBackColor = true;
            cb6C_IKnowTagLock.CheckedChanged += cb6C_IKnowTagLock_CheckedChanged;
            // 
            // groupBox31
            // 
            groupBox31.Controls.Add(maskLen_textBox);
            groupBox31.Controls.Add(label44);
            groupBox31.Controls.Add(maskadr_textbox);
            groupBox31.Controls.Add(label43);
            groupBox31.Controls.Add(checkBox1);
            groupBox31.Location = new Point(2, 203);
            groupBox31.Margin = new Padding(4, 3, 4, 3);
            groupBox31.Name = "groupBox31";
            groupBox31.Padding = new Padding(4, 3, 4, 3);
            groupBox31.Size = new Size(559, 60);
            groupBox31.TabIndex = 9;
            groupBox31.TabStop = false;
            groupBox31.Text = "EPC Mask Enabled";
            // 
            // maskLen_textBox
            // 
            maskLen_textBox.Enabled = false;
            maskLen_textBox.Location = new Point(402, 23);
            maskLen_textBox.Margin = new Padding(4, 3, 4, 3);
            maskLen_textBox.MaxLength = 2;
            maskLen_textBox.Name = "maskLen_textBox";
            maskLen_textBox.Size = new Size(142, 23);
            maskLen_textBox.TabIndex = 4;
            maskLen_textBox.Text = "00";
            maskLen_textBox.TextChanged += filterOnlyDigits_TextChanged;
            maskLen_textBox.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(334, 29);
            label44.Margin = new Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new Size(57, 15);
            label44.TabIndex = 3;
            label44.Text = "MaskLen:";
            // 
            // maskadr_textbox
            // 
            maskadr_textbox.Enabled = false;
            maskadr_textbox.Location = new Point(196, 23);
            maskadr_textbox.Margin = new Padding(4, 3, 4, 3);
            maskadr_textbox.MaxLength = 2;
            maskadr_textbox.Name = "maskadr_textbox";
            maskadr_textbox.Size = new Size(116, 23);
            maskadr_textbox.TabIndex = 2;
            maskadr_textbox.Text = "00";
            maskadr_textbox.TextChanged += filterOnlyDigits_TextChanged;
            maskadr_textbox.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(127, 29);
            label43.Margin = new Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new Size(57, 15);
            label43.TabIndex = 1;
            label43.Text = "MaskAdr:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(5, 28);
            checkBox1.Margin = new Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(68, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Enabled";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += EPCMask_CheckedChanged;
            // 
            // groupBox18
            // 
            groupBox18.Controls.Add(Button_LockUserBlock_G2);
            groupBox18.Controls.Add(Edit_AccessCode6);
            groupBox18.Controls.Add(ComboBox_BlockNum);
            groupBox18.Controls.Add(label30);
            groupBox18.Controls.Add(label29);
            groupBox18.Controls.Add(ComboBox_EPC6);
            groupBox18.Location = new Point(566, 661);
            groupBox18.Margin = new Padding(4, 3, 4, 3);
            groupBox18.Name = "groupBox18";
            groupBox18.Padding = new Padding(4, 3, 4, 3);
            groupBox18.Size = new Size(379, 118);
            groupBox18.TabIndex = 8;
            groupBox18.TabStop = false;
            groupBox18.Text = "Lock Block for User (Permanently Lock)";
            // 
            // Button_LockUserBlock_G2
            // 
            Button_LockUserBlock_G2.Location = new Point(264, 83);
            Button_LockUserBlock_G2.Margin = new Padding(4, 3, 4, 3);
            Button_LockUserBlock_G2.Name = "Button_LockUserBlock_G2";
            Button_LockUserBlock_G2.Size = new Size(104, 29);
            Button_LockUserBlock_G2.TabIndex = 5;
            Button_LockUserBlock_G2.Text = "Lock";
            Button_LockUserBlock_G2.UseVisualStyleBackColor = true;
            Button_LockUserBlock_G2.Click += Button_LockUserBlock_G2_Click;
            // 
            // Edit_AccessCode6
            // 
            Edit_AccessCode6.Location = new Point(156, 87);
            Edit_AccessCode6.Margin = new Padding(4, 3, 4, 3);
            Edit_AccessCode6.MaxLength = 8;
            Edit_AccessCode6.Name = "Edit_AccessCode6";
            Edit_AccessCode6.Size = new Size(98, 23);
            Edit_AccessCode6.TabIndex = 4;
            Edit_AccessCode6.Text = "00000000";
            Edit_AccessCode6.TextChanged += filterOnlyHex_TextChanged;
            Edit_AccessCode6.KeyPress += filterOnlyHex_KeyPress;
            // 
            // ComboBox_BlockNum
            // 
            ComboBox_BlockNum.FormattingEnabled = true;
            ComboBox_BlockNum.Location = new Point(156, 50);
            ComboBox_BlockNum.Margin = new Padding(4, 3, 4, 3);
            ComboBox_BlockNum.Name = "ComboBox_BlockNum";
            ComboBox_BlockNum.Size = new Size(101, 23);
            ComboBox_BlockNum.TabIndex = 3;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(10, 81);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(96, 30);
            label30.TabIndex = 2;
            label30.Text = "Access Password\r\n(8 Hex):";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(10, 46);
            label29.Margin = new Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new Size(112, 30);
            label29.TabIndex = 1;
            label29.Text = "Address of Tag Data\r\n(Word):";
            // 
            // ComboBox_EPC6
            // 
            ComboBox_EPC6.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC6.FormattingEnabled = true;
            ComboBox_EPC6.Location = new Point(7, 18);
            ComboBox_EPC6.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC6.Name = "ComboBox_EPC6";
            ComboBox_EPC6.Size = new Size(364, 23);
            ComboBox_EPC6.TabIndex = 0;
            // 
            // groupBox16
            // 
            groupBox16.Controls.Add(Label_Alarm);
            groupBox16.Controls.Add(Button_CheckEASAlarm_G2);
            groupBox16.Controls.Add(Button_SetEASAlarm_G2);
            groupBox16.Controls.Add(groupBox17);
            groupBox16.Controls.Add(Edit_AccessCode5);
            groupBox16.Controls.Add(label28);
            groupBox16.Controls.Add(ComboBox_EPC5);
            groupBox16.Location = new Point(566, 524);
            groupBox16.Margin = new Padding(4, 3, 4, 3);
            groupBox16.Name = "groupBox16";
            groupBox16.Padding = new Padding(4, 3, 4, 3);
            groupBox16.Size = new Size(379, 135);
            groupBox16.TabIndex = 7;
            groupBox16.TabStop = false;
            groupBox16.Text = "EAS Alarm";
            // 
            // Label_Alarm
            // 
            Label_Alarm.AutoSize = true;
            Label_Alarm.Font = new Font("Microsoft Sans Serif", 30.3F, FontStyle.Regular, GraphicsUnit.Point, 2, true);
            Label_Alarm.ForeColor = Color.Red;
            Label_Alarm.Location = new Point(284, 45);
            Label_Alarm.Margin = new Padding(4, 0, 4, 0);
            Label_Alarm.Name = "Label_Alarm";
            Label_Alarm.Size = new Size(51, 46);
            Label_Alarm.TabIndex = 14;
            Label_Alarm.Text = "l";
            // 
            // Button_CheckEASAlarm_G2
            // 
            Button_CheckEASAlarm_G2.Enabled = false;
            Button_CheckEASAlarm_G2.Location = new Point(264, 102);
            Button_CheckEASAlarm_G2.Margin = new Padding(4, 3, 4, 3);
            Button_CheckEASAlarm_G2.Name = "Button_CheckEASAlarm_G2";
            Button_CheckEASAlarm_G2.Size = new Size(104, 29);
            Button_CheckEASAlarm_G2.TabIndex = 13;
            Button_CheckEASAlarm_G2.Text = "Check Alarm";
            Button_CheckEASAlarm_G2.UseVisualStyleBackColor = true;
            Button_CheckEASAlarm_G2.Click += Button_CheckEASAlarm_G2_Click;
            // 
            // Button_SetEASAlarm_G2
            // 
            Button_SetEASAlarm_G2.Location = new Point(128, 102);
            Button_SetEASAlarm_G2.Margin = new Padding(4, 3, 4, 3);
            Button_SetEASAlarm_G2.Name = "Button_SetEASAlarm_G2";
            Button_SetEASAlarm_G2.Size = new Size(113, 29);
            Button_SetEASAlarm_G2.TabIndex = 12;
            Button_SetEASAlarm_G2.Text = "Alarm Setting";
            Button_SetEASAlarm_G2.UseVisualStyleBackColor = true;
            Button_SetEASAlarm_G2.Click += Button_SetEASAlarm_G2_Click;
            // 
            // groupBox17
            // 
            groupBox17.Controls.Add(NoAlarm_G2);
            groupBox17.Controls.Add(Alarm_G2);
            groupBox17.Location = new Point(7, 74);
            groupBox17.Margin = new Padding(4, 3, 4, 3);
            groupBox17.Name = "groupBox17";
            groupBox17.Padding = new Padding(4, 3, 4, 3);
            groupBox17.Size = new Size(117, 59);
            groupBox17.TabIndex = 11;
            groupBox17.TabStop = false;
            // 
            // NoAlarm_G2
            // 
            NoAlarm_G2.AutoSize = true;
            NoAlarm_G2.Location = new Point(6, 33);
            NoAlarm_G2.Margin = new Padding(4, 3, 4, 3);
            NoAlarm_G2.Name = "NoAlarm_G2";
            NoAlarm_G2.Size = new Size(76, 19);
            NoAlarm_G2.TabIndex = 1;
            NoAlarm_G2.TabStop = true;
            NoAlarm_G2.Text = "No Alarm";
            NoAlarm_G2.UseVisualStyleBackColor = true;
            // 
            // Alarm_G2
            // 
            Alarm_G2.AutoSize = true;
            Alarm_G2.Location = new Point(6, 13);
            Alarm_G2.Margin = new Padding(4, 3, 4, 3);
            Alarm_G2.Name = "Alarm_G2";
            Alarm_G2.Size = new Size(57, 19);
            Alarm_G2.TabIndex = 0;
            Alarm_G2.TabStop = true;
            Alarm_G2.Text = "Alarm";
            Alarm_G2.UseVisualStyleBackColor = true;
            // 
            // Edit_AccessCode5
            // 
            Edit_AccessCode5.Location = new Point(125, 47);
            Edit_AccessCode5.Margin = new Padding(4, 3, 4, 3);
            Edit_AccessCode5.MaxLength = 8;
            Edit_AccessCode5.Name = "Edit_AccessCode5";
            Edit_AccessCode5.Size = new Size(116, 23);
            Edit_AccessCode5.TabIndex = 10;
            Edit_AccessCode5.Text = "00000000";
            Edit_AccessCode5.TextChanged += filterOnlyHex_TextChanged;
            Edit_AccessCode5.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(7, 44);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(96, 30);
            label28.TabIndex = 9;
            label28.Text = "Access Password\r\n(8 Hex):";
            // 
            // ComboBox_EPC5
            // 
            ComboBox_EPC5.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC5.FormattingEnabled = true;
            ComboBox_EPC5.Location = new Point(7, 16);
            ComboBox_EPC5.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC5.Name = "ComboBox_EPC5";
            ComboBox_EPC5.Size = new Size(364, 23);
            ComboBox_EPC5.TabIndex = 8;
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(Button_CheckReadProtected_G2);
            groupBox15.Controls.Add(Button_RemoveReadProtect_G2);
            groupBox15.Controls.Add(Button_SetMultiReadProtect_G2);
            groupBox15.Controls.Add(Button_SetReadProtect_G2);
            groupBox15.Controls.Add(Edit_AccessCode4);
            groupBox15.Controls.Add(label27);
            groupBox15.Controls.Add(ComboBox_EPC4);
            groupBox15.Location = new Point(566, 302);
            groupBox15.Margin = new Padding(4, 3, 4, 3);
            groupBox15.Name = "groupBox15";
            groupBox15.Padding = new Padding(4, 3, 4, 3);
            groupBox15.Size = new Size(379, 219);
            groupBox15.TabIndex = 6;
            groupBox15.TabStop = false;
            groupBox15.Text = "Read Protection";
            // 
            // Button_CheckReadProtected_G2
            // 
            Button_CheckReadProtected_G2.Enabled = false;
            Button_CheckReadProtected_G2.Location = new Point(7, 185);
            Button_CheckReadProtected_G2.Margin = new Padding(4, 3, 4, 3);
            Button_CheckReadProtected_G2.Name = "Button_CheckReadProtected_G2";
            Button_CheckReadProtected_G2.Size = new Size(365, 29);
            Button_CheckReadProtected_G2.TabIndex = 6;
            Button_CheckReadProtected_G2.Text = "Detect Single Tag Read Protection without EPC Password";
            Button_CheckReadProtected_G2.UseVisualStyleBackColor = true;
            Button_CheckReadProtected_G2.Click += Button_CheckReadProtected_G2_Click;
            // 
            // Button_RemoveReadProtect_G2
            // 
            Button_RemoveReadProtect_G2.Enabled = false;
            Button_RemoveReadProtect_G2.Location = new Point(7, 150);
            Button_RemoveReadProtect_G2.Margin = new Padding(4, 3, 4, 3);
            Button_RemoveReadProtect_G2.Name = "Button_RemoveReadProtect_G2";
            Button_RemoveReadProtect_G2.Size = new Size(365, 29);
            Button_RemoveReadProtect_G2.TabIndex = 5;
            Button_RemoveReadProtect_G2.Text = "Reset Single Tag Read Protection without EPC";
            Button_RemoveReadProtect_G2.UseVisualStyleBackColor = true;
            Button_RemoveReadProtect_G2.Click += Button_RemoveReadProtect_G2_Click;
            // 
            // Button_SetMultiReadProtect_G2
            // 
            Button_SetMultiReadProtect_G2.Enabled = false;
            Button_SetMultiReadProtect_G2.Location = new Point(7, 115);
            Button_SetMultiReadProtect_G2.Margin = new Padding(4, 3, 4, 3);
            Button_SetMultiReadProtect_G2.Name = "Button_SetMultiReadProtect_G2";
            Button_SetMultiReadProtect_G2.Size = new Size(365, 29);
            Button_SetMultiReadProtect_G2.TabIndex = 4;
            Button_SetMultiReadProtect_G2.Text = "Set Single Tag Read Protection without EPC";
            Button_SetMultiReadProtect_G2.UseVisualStyleBackColor = true;
            Button_SetMultiReadProtect_G2.Click += Button_SetMultiReadProtect_G2_Click;
            // 
            // Button_SetReadProtect_G2
            // 
            Button_SetReadProtect_G2.Enabled = false;
            Button_SetReadProtect_G2.Location = new Point(7, 80);
            Button_SetReadProtect_G2.Margin = new Padding(4, 3, 4, 3);
            Button_SetReadProtect_G2.Name = "Button_SetReadProtect_G2";
            Button_SetReadProtect_G2.Size = new Size(365, 29);
            Button_SetReadProtect_G2.TabIndex = 3;
            Button_SetReadProtect_G2.Text = "Set Single Tag Read Protection";
            Button_SetReadProtect_G2.UseVisualStyleBackColor = true;
            Button_SetReadProtect_G2.Click += Button_SetReadProtect_G2_Click;
            // 
            // Edit_AccessCode4
            // 
            Edit_AccessCode4.Location = new Point(125, 48);
            Edit_AccessCode4.Margin = new Padding(4, 3, 4, 3);
            Edit_AccessCode4.MaxLength = 8;
            Edit_AccessCode4.Name = "Edit_AccessCode4";
            Edit_AccessCode4.Size = new Size(116, 23);
            Edit_AccessCode4.TabIndex = 2;
            Edit_AccessCode4.Text = "00000000";
            Edit_AccessCode4.TextChanged += filterOnlyHex_TextChanged;
            Edit_AccessCode4.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(7, 45);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(96, 30);
            label27.TabIndex = 1;
            label27.Text = "Access Password\r\n(8 Hex):";
            // 
            // ComboBox_EPC4
            // 
            ComboBox_EPC4.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC4.FormattingEnabled = true;
            ComboBox_EPC4.Location = new Point(9, 17);
            ComboBox_EPC4.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC4.Name = "ComboBox_EPC4";
            ComboBox_EPC4.Size = new Size(362, 23);
            ComboBox_EPC4.TabIndex = 0;
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(Button_WriteEPC_G2);
            groupBox14.Controls.Add(Edit_AccessCode3);
            groupBox14.Controls.Add(label26);
            groupBox14.Controls.Add(Edit_WriteEPC);
            groupBox14.Controls.Add(label25);
            groupBox14.Location = new Point(566, 212);
            groupBox14.Margin = new Padding(4, 3, 4, 3);
            groupBox14.Name = "groupBox14";
            groupBox14.Padding = new Padding(4, 3, 4, 3);
            groupBox14.Size = new Size(379, 89);
            groupBox14.TabIndex = 5;
            groupBox14.TabStop = false;
            groupBox14.Text = "Write EPC(Random write one tag in the antenna)";
            // 
            // Button_WriteEPC_G2
            // 
            Button_WriteEPC_G2.Enabled = false;
            Button_WriteEPC_G2.Location = new Point(285, 54);
            Button_WriteEPC_G2.Margin = new Padding(4, 3, 4, 3);
            Button_WriteEPC_G2.Name = "Button_WriteEPC_G2";
            Button_WriteEPC_G2.Size = new Size(88, 29);
            Button_WriteEPC_G2.TabIndex = 4;
            Button_WriteEPC_G2.Text = "Write EPC";
            Button_WriteEPC_G2.UseVisualStyleBackColor = true;
            Button_WriteEPC_G2.Click += Button_WriteEPC_G2_Click;
            // 
            // Edit_AccessCode3
            // 
            Edit_AccessCode3.Location = new Point(125, 57);
            Edit_AccessCode3.Margin = new Padding(4, 3, 4, 3);
            Edit_AccessCode3.MaxLength = 8;
            Edit_AccessCode3.Name = "Edit_AccessCode3";
            Edit_AccessCode3.Size = new Size(116, 23);
            Edit_AccessCode3.TabIndex = 3;
            Edit_AccessCode3.Text = "00000000";
            Edit_AccessCode3.TextChanged += filterOnlyHex_TextChanged;
            Edit_AccessCode3.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(7, 50);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(96, 30);
            label26.TabIndex = 2;
            label26.Text = "Access Password\r\n(8 Hex):";
            // 
            // Edit_WriteEPC
            // 
            Edit_WriteEPC.Location = new Point(90, 21);
            Edit_WriteEPC.Margin = new Padding(4, 3, 4, 3);
            Edit_WriteEPC.MaxLength = 60;
            Edit_WriteEPC.Name = "Edit_WriteEPC";
            Edit_WriteEPC.Size = new Size(282, 23);
            Edit_WriteEPC.TabIndex = 1;
            Edit_WriteEPC.Text = "0000";
            Edit_WriteEPC.TextChanged += filterOnlyHex_TextChanged;
            Edit_WriteEPC.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(7, 17);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(67, 30);
            label25.TabIndex = 0;
            label25.Text = "Write EPC:\r\n(1-15Word)";
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(Button_DestroyCard);
            groupBox13.Controls.Add(Edit_DestroyCode);
            groupBox13.Controls.Add(label24);
            groupBox13.Controls.Add(ComboBox_EPC3);
            groupBox13.Location = new Point(566, 123);
            groupBox13.Margin = new Padding(4, 3, 4, 3);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new Padding(4, 3, 4, 3);
            groupBox13.Size = new Size(379, 87);
            groupBox13.TabIndex = 4;
            groupBox13.TabStop = false;
            groupBox13.Text = "Kill Tag";
            // 
            // Button_DestroyCard
            // 
            Button_DestroyCard.Location = new Point(285, 50);
            Button_DestroyCard.Margin = new Padding(4, 3, 4, 3);
            Button_DestroyCard.Name = "Button_DestroyCard";
            Button_DestroyCard.Size = new Size(88, 29);
            Button_DestroyCard.TabIndex = 3;
            Button_DestroyCard.Text = "Kill Tag";
            Button_DestroyCard.UseVisualStyleBackColor = true;
            Button_DestroyCard.Click += Button_DestroyCard_Click;
            // 
            // Edit_DestroyCode
            // 
            Edit_DestroyCode.Location = new Point(134, 53);
            Edit_DestroyCode.Margin = new Padding(4, 3, 4, 3);
            Edit_DestroyCode.MaxLength = 8;
            Edit_DestroyCode.Name = "Edit_DestroyCode";
            Edit_DestroyCode.Size = new Size(107, 23);
            Edit_DestroyCode.TabIndex = 2;
            Edit_DestroyCode.Text = "00000000";
            Edit_DestroyCode.TextChanged += filterOnlyHex_TextChanged;
            Edit_DestroyCode.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(7, 50);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(76, 30);
            label24.TabIndex = 1;
            label24.Text = "Kill Password\r\n(8 Hex):";
            // 
            // ComboBox_EPC3
            // 
            ComboBox_EPC3.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC3.FormattingEnabled = true;
            ComboBox_EPC3.Location = new Point(9, 18);
            ComboBox_EPC3.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC3.Name = "ComboBox_EPC3";
            ComboBox_EPC3.Size = new Size(362, 23);
            ComboBox_EPC3.TabIndex = 0;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(CheckBox_TID);
            groupBox12.Controls.Add(gbQueryTIDParams);
            groupBox12.Controls.Add(Button_QueryTag);
            groupBox12.Controls.Add(ComboBox_IntervalTime);
            groupBox12.Controls.Add(label23);
            groupBox12.Location = new Point(566, 0);
            groupBox12.Margin = new Padding(4, 3, 4, 3);
            groupBox12.Name = "groupBox12";
            groupBox12.Padding = new Padding(4, 3, 4, 3);
            groupBox12.Size = new Size(379, 121);
            groupBox12.TabIndex = 3;
            groupBox12.TabStop = false;
            groupBox12.Text = "Query Tag";
            // 
            // CheckBox_TID
            // 
            CheckBox_TID.AutoSize = true;
            CheckBox_TID.Location = new Point(231, 80);
            CheckBox_TID.Margin = new Padding(4, 3, 4, 3);
            CheckBox_TID.Name = "CheckBox_TID";
            CheckBox_TID.Size = new Size(44, 19);
            CheckBox_TID.TabIndex = 12;
            CheckBox_TID.Text = "TID";
            CheckBox_TID.UseVisualStyleBackColor = true;
            CheckBox_TID.CheckedChanged += CheckBox_TID_CheckedChanged;
            // 
            // gbQueryTIDParams
            // 
            gbQueryTIDParams.Controls.Add(textBox5);
            gbQueryTIDParams.Controls.Add(label55);
            gbQueryTIDParams.Controls.Add(textBox4);
            gbQueryTIDParams.Controls.Add(label54);
            gbQueryTIDParams.Enabled = false;
            gbQueryTIDParams.Location = new Point(9, 54);
            gbQueryTIDParams.Margin = new Padding(4, 3, 4, 3);
            gbQueryTIDParams.Name = "gbQueryTIDParams";
            gbQueryTIDParams.Padding = new Padding(4, 3, 4, 3);
            gbQueryTIDParams.Size = new Size(215, 60);
            gbQueryTIDParams.TabIndex = 11;
            gbQueryTIDParams.TabStop = false;
            gbQueryTIDParams.Text = "Query TID Parameter (In Hex)";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(164, 25);
            textBox5.Margin = new Padding(4, 3, 4, 3);
            textBox5.MaxLength = 2;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(42, 23);
            textBox5.TabIndex = 3;
            textBox5.Text = "04";
            textBox5.TextChanged += filterOnlyHex_TextChanged;
            textBox5.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new Point(133, 30);
            label55.Margin = new Padding(4, 0, 4, 0);
            label55.Name = "label55";
            label55.Size = new Size(29, 15);
            label55.TabIndex = 2;
            label55.Text = "Len:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(80, 25);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.MaxLength = 2;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(42, 23);
            textBox4.TabIndex = 1;
            textBox4.Text = "02";
            textBox4.TextChanged += filterOnlyHex_TextChanged;
            textBox4.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new Point(6, 29);
            label54.Margin = new Padding(4, 0, 4, 0);
            label54.Name = "label54";
            label54.Size = new Size(63, 15);
            label54.TabIndex = 0;
            label54.Text = "Start Addr:";
            // 
            // Button_QueryTag
            // 
            Button_QueryTag.Enabled = false;
            Button_QueryTag.Location = new Point(273, 21);
            Button_QueryTag.Margin = new Padding(4, 3, 4, 3);
            Button_QueryTag.Name = "Button_QueryTag";
            Button_QueryTag.Size = new Size(98, 29);
            Button_QueryTag.TabIndex = 2;
            Button_QueryTag.Text = "Query Tag";
            Button_QueryTag.UseVisualStyleBackColor = true;
            Button_QueryTag.Click += btnQueryTag_Click;
            // 
            // ComboBox_IntervalTime
            // 
            ComboBox_IntervalTime.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_IntervalTime.FormattingEnabled = true;
            ComboBox_IntervalTime.Location = new Point(118, 25);
            ComboBox_IntervalTime.Margin = new Padding(4, 3, 4, 3);
            ComboBox_IntervalTime.Name = "ComboBox_IntervalTime";
            ComboBox_IntervalTime.Size = new Size(139, 23);
            ComboBox_IntervalTime.TabIndex = 1;
            ComboBox_IntervalTime.SelectedIndexChanged += ComboBox_IntervalTime_SelectedIndexChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(7, 30);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(78, 15);
            label23.TabIndex = 0;
            label23.Text = "Read Interval:";
            // 
            // gbTagLock
            // 
            gbTagLock.Controls.Add(Button_SetProtectState);
            gbTagLock.Controls.Add(textBox2);
            gbTagLock.Controls.Add(label22);
            gbTagLock.Controls.Add(gbLockTIDnUSER);
            gbTagLock.Controls.Add(groupBox10);
            gbTagLock.Controls.Add(gbLockPassword);
            gbTagLock.Controls.Add(ComboBox_EPC1);
            gbTagLock.Enabled = false;
            gbTagLock.Location = new Point(1, 518);
            gbTagLock.Margin = new Padding(4, 3, 4, 3);
            gbTagLock.Name = "gbTagLock";
            gbTagLock.Padding = new Padding(4, 3, 4, 3);
            gbTagLock.Size = new Size(561, 239);
            gbTagLock.TabIndex = 2;
            gbTagLock.TabStop = false;
            gbTagLock.Text = "Set Protect For Reading Or Writing";
            // 
            // Button_SetProtectState
            // 
            Button_SetProtectState.Location = new Point(438, 192);
            Button_SetProtectState.Margin = new Padding(4, 3, 4, 3);
            Button_SetProtectState.Name = "Button_SetProtectState";
            Button_SetProtectState.Size = new Size(115, 29);
            Button_SetProtectState.TabIndex = 6;
            Button_SetProtectState.Text = "Set Protect";
            Button_SetProtectState.UseVisualStyleBackColor = true;
            Button_SetProtectState.Click += Button_SetProtectState_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(307, 194);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.MaxLength = 8;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "00000000";
            textBox2.TextChanged += filterOnlyHex_TextChanged;
            textBox2.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(304, 173);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(139, 15);
            label22.TabIndex = 4;
            label22.Text = "Access Password (8 Hex):";
            // 
            // gbLockTIDnUSER
            // 
            gbLockTIDnUSER.Controls.Add(AlwaysNot2);
            gbLockTIDnUSER.Controls.Add(Always2);
            gbLockTIDnUSER.Controls.Add(Proect2);
            gbLockTIDnUSER.Controls.Add(NoProect2);
            gbLockTIDnUSER.Location = new Point(301, 54);
            gbLockTIDnUSER.Margin = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Name = "gbLockTIDnUSER";
            gbLockTIDnUSER.Padding = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Size = new Size(253, 117);
            gbLockTIDnUSER.TabIndex = 3;
            gbLockTIDnUSER.TabStop = false;
            gbLockTIDnUSER.Text = "Lock of [EPC, TID, USER] Bank";
            // 
            // AlwaysNot2
            // 
            AlwaysNot2.AutoSize = true;
            AlwaysNot2.Location = new Point(6, 93);
            AlwaysNot2.Margin = new Padding(4, 3, 4, 3);
            AlwaysNot2.Name = "AlwaysNot2";
            AlwaysNot2.Size = new Size(107, 19);
            AlwaysNot2.TabIndex = 3;
            AlwaysNot2.TabStop = true;
            AlwaysNot2.Text = "Never writeable";
            AlwaysNot2.UseVisualStyleBackColor = true;
            // 
            // Always2
            // 
            Always2.AutoSize = true;
            Always2.Location = new Point(6, 70);
            Always2.Margin = new Padding(4, 3, 4, 3);
            Always2.Name = "Always2";
            Always2.Size = new Size(143, 19);
            Always2.TabIndex = 2;
            Always2.TabStop = true;
            Always2.Text = "Permanently writeable";
            Always2.UseVisualStyleBackColor = true;
            // 
            // Proect2
            // 
            Proect2.AutoSize = true;
            Proect2.Location = new Point(6, 46);
            Proect2.Margin = new Padding(4, 3, 4, 3);
            Proect2.Name = "Proect2";
            Proect2.Size = new Size(196, 19);
            Proect2.TabIndex = 1;
            Proect2.TabStop = true;
            Proect2.Text = "Writeable from the secured state";
            Proect2.UseVisualStyleBackColor = true;
            // 
            // NoProect2
            // 
            NoProect2.AutoSize = true;
            NoProect2.Location = new Point(6, 23);
            NoProect2.Margin = new Padding(4, 3, 4, 3);
            NoProect2.Name = "NoProect2";
            NoProect2.Size = new Size(154, 19);
            NoProect2.TabIndex = 0;
            NoProect2.TabStop = true;
            NoProect2.Text = "Writeable from any state";
            NoProect2.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(P_User);
            groupBox10.Controls.Add(P_TID);
            groupBox10.Controls.Add(P_EPC);
            groupBox10.Controls.Add(P_Reserve);
            groupBox10.Location = new Point(302, 15);
            groupBox10.Margin = new Padding(4, 3, 4, 3);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(4, 3, 4, 3);
            groupBox10.Size = new Size(251, 39);
            groupBox10.TabIndex = 2;
            groupBox10.TabStop = false;
            // 
            // P_User
            // 
            P_User.AutoSize = true;
            P_User.Location = new Point(189, 14);
            P_User.Margin = new Padding(4, 3, 4, 3);
            P_User.Name = "P_User";
            P_User.Size = new Size(48, 19);
            P_User.TabIndex = 3;
            P_User.TabStop = true;
            P_User.Text = "User";
            P_User.UseVisualStyleBackColor = true;
            P_User.CheckedChanged += P_User_CheckedChanged;
            // 
            // P_TID
            // 
            P_TID.AutoSize = true;
            P_TID.Location = new Point(139, 14);
            P_TID.Margin = new Padding(4, 3, 4, 3);
            P_TID.Name = "P_TID";
            P_TID.Size = new Size(43, 19);
            P_TID.TabIndex = 2;
            P_TID.TabStop = true;
            P_TID.Text = "TID";
            P_TID.UseVisualStyleBackColor = true;
            P_TID.CheckedChanged += P_TID_CheckedChanged;
            // 
            // P_EPC
            // 
            P_EPC.AutoSize = true;
            P_EPC.Location = new Point(90, 14);
            P_EPC.Margin = new Padding(4, 3, 4, 3);
            P_EPC.Name = "P_EPC";
            P_EPC.Size = new Size(46, 19);
            P_EPC.TabIndex = 1;
            P_EPC.TabStop = true;
            P_EPC.Text = "EPC";
            P_EPC.UseVisualStyleBackColor = true;
            P_EPC.CheckedChanged += P_EPC_CheckedChanged;
            // 
            // P_Reserve
            // 
            P_Reserve.AutoSize = true;
            P_Reserve.Location = new Point(5, 14);
            P_Reserve.Margin = new Padding(4, 3, 4, 3);
            P_Reserve.Name = "P_Reserve";
            P_Reserve.Size = new Size(78, 19);
            P_Reserve.TabIndex = 0;
            P_Reserve.TabStop = true;
            P_Reserve.Text = "RESERVED";
            P_Reserve.UseVisualStyleBackColor = true;
            P_Reserve.CheckedChanged += P_Reserve_CheckedChanged;
            // 
            // ComboBox_EPC1
            // 
            ComboBox_EPC1.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC1.FormattingEnabled = true;
            ComboBox_EPC1.Location = new Point(5, 17);
            ComboBox_EPC1.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC1.Name = "ComboBox_EPC1";
            ComboBox_EPC1.Size = new Size(290, 23);
            ComboBox_EPC1.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox_pc);
            groupBox5.Controls.Add(checkBox_pc);
            groupBox5.Controls.Add(Button_BlockWrite);
            groupBox5.Controls.Add(ComboBox_EPC2);
            groupBox5.Controls.Add(Button_ListClear);
            groupBox5.Controls.Add(Button_BlockErase);
            groupBox5.Controls.Add(Button_DataWrite);
            groupBox5.Controls.Add(SpeedButton_Read_G2);
            groupBox5.Controls.Add(Edit_WriteData);
            groupBox5.Controls.Add(Edit_AccessCode2);
            groupBox5.Controls.Add(txtDataLen);
            groupBox5.Controls.Add(txtDataAddr);
            groupBox5.Controls.Add(listBox1);
            groupBox5.Controls.Add(label21);
            groupBox5.Controls.Add(label20);
            groupBox5.Controls.Add(label19);
            groupBox5.Controls.Add(label18);
            groupBox5.Controls.Add(groupBox6);
            groupBox5.Location = new Point(1, 264);
            groupBox5.Margin = new Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4, 3, 4, 3);
            groupBox5.Size = new Size(561, 254);
            groupBox5.TabIndex = 1;
            groupBox5.TabStop = false;
            groupBox5.Text = "Read Data / Write Data / Block Erase";
            // 
            // textBox_pc
            // 
            textBox_pc.BackColor = SystemColors.Window;
            textBox_pc.Location = new Point(510, 18);
            textBox_pc.Margin = new Padding(4, 3, 4, 3);
            textBox_pc.Name = "textBox_pc";
            textBox_pc.Size = new Size(41, 23);
            textBox_pc.TabIndex = 27;
            textBox_pc.Text = "0800";
            // 
            // checkBox_pc
            // 
            checkBox_pc.AutoSize = true;
            checkBox_pc.Location = new Point(352, 23);
            checkBox_pc.Margin = new Padding(4, 3, 4, 3);
            checkBox_pc.Name = "checkBox_pc";
            checkBox_pc.Size = new Size(140, 19);
            checkBox_pc.TabIndex = 26;
            checkBox_pc.Text = "Compute and add PC";
            checkBox_pc.UseVisualStyleBackColor = true;
            checkBox_pc.CheckedChanged += checkBox_pc_CheckedChanged;
            // 
            // Button_BlockWrite
            // 
            Button_BlockWrite.Location = new Point(115, 219);
            Button_BlockWrite.Margin = new Padding(4, 3, 4, 3);
            Button_BlockWrite.Name = "Button_BlockWrite";
            Button_BlockWrite.Size = new Size(84, 29);
            Button_BlockWrite.TabIndex = 16;
            Button_BlockWrite.Text = "BlockWrite";
            Button_BlockWrite.UseVisualStyleBackColor = true;
            Button_BlockWrite.Click += BlockWrite_Click;
            // 
            // ComboBox_EPC2
            // 
            ComboBox_EPC2.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_EPC2.FormattingEnabled = true;
            ComboBox_EPC2.Location = new Point(5, 20);
            ComboBox_EPC2.Margin = new Padding(4, 3, 4, 3);
            ComboBox_EPC2.Name = "ComboBox_EPC2";
            ComboBox_EPC2.Size = new Size(340, 23);
            ComboBox_EPC2.TabIndex = 15;
            // 
            // Button_ListClear
            // 
            Button_ListClear.Location = new Point(295, 219);
            Button_ListClear.Margin = new Padding(4, 3, 4, 3);
            Button_ListClear.Name = "Button_ListClear";
            Button_ListClear.Size = new Size(50, 29);
            Button_ListClear.TabIndex = 14;
            Button_ListClear.Text = "Clear";
            Button_ListClear.UseVisualStyleBackColor = true;
            Button_ListClear.Click += Button_ListClear_Click;
            // 
            // Button_BlockErase
            // 
            Button_BlockErase.Location = new Point(203, 219);
            Button_BlockErase.Margin = new Padding(4, 3, 4, 3);
            Button_BlockErase.Name = "Button_BlockErase";
            Button_BlockErase.Size = new Size(89, 29);
            Button_BlockErase.TabIndex = 13;
            Button_BlockErase.Text = "BlockErase";
            Button_BlockErase.UseVisualStyleBackColor = true;
            Button_BlockErase.Click += Button_BlockErase_Click;
            // 
            // Button_DataWrite
            // 
            Button_DataWrite.Location = new Point(63, 219);
            Button_DataWrite.Margin = new Padding(4, 3, 4, 3);
            Button_DataWrite.Name = "Button_DataWrite";
            Button_DataWrite.Size = new Size(50, 29);
            Button_DataWrite.TabIndex = 12;
            Button_DataWrite.Text = "Write";
            Button_DataWrite.UseVisualStyleBackColor = true;
            Button_DataWrite.Click += Button_DataWrite_Click;
            // 
            // SpeedButton_Read_G2
            // 
            SpeedButton_Read_G2.Location = new Point(5, 219);
            SpeedButton_Read_G2.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Read_G2.Name = "SpeedButton_Read_G2";
            SpeedButton_Read_G2.Size = new Size(55, 29);
            SpeedButton_Read_G2.TabIndex = 11;
            SpeedButton_Read_G2.Text = "Read";
            SpeedButton_Read_G2.UseVisualStyleBackColor = true;
            SpeedButton_Read_G2.Click += SpeedButton_Read_G2_Click;
            // 
            // Edit_WriteData
            // 
            Edit_WriteData.Location = new Point(135, 190);
            Edit_WriteData.Margin = new Padding(4, 3, 4, 3);
            Edit_WriteData.Name = "Edit_WriteData";
            Edit_WriteData.Size = new Size(209, 23);
            Edit_WriteData.TabIndex = 10;
            Edit_WriteData.Text = "0000";
            Edit_WriteData.TextChanged += Edit_WriteData_TextChanged;
            Edit_WriteData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // Edit_AccessCode2
            // 
            Edit_AccessCode2.Location = new Point(181, 157);
            Edit_AccessCode2.Margin = new Padding(4, 3, 4, 3);
            Edit_AccessCode2.MaxLength = 8;
            Edit_AccessCode2.Name = "Edit_AccessCode2";
            Edit_AccessCode2.Size = new Size(164, 23);
            Edit_AccessCode2.TabIndex = 9;
            Edit_AccessCode2.Text = "00000000";
            Edit_AccessCode2.TextChanged += filterOnlyHex_TextChanged;
            Edit_AccessCode2.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtDataLen
            // 
            txtDataLen.Location = new Point(239, 123);
            txtDataLen.Margin = new Padding(4, 3, 4, 3);
            txtDataLen.MaxLength = 3;
            txtDataLen.Name = "txtDataLen";
            txtDataLen.Size = new Size(106, 23);
            txtDataLen.TabIndex = 8;
            txtDataLen.Text = "4";
            txtDataLen.TextChanged += filterOnlyDigits_TextChanged;
            txtDataLen.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // txtDataAddr
            // 
            txtDataAddr.Location = new Point(239, 85);
            txtDataAddr.Margin = new Padding(4, 3, 4, 3);
            txtDataAddr.MaxLength = 2;
            txtDataAddr.Name = "txtDataAddr";
            txtDataAddr.Size = new Size(106, 23);
            txtDataAddr.TabIndex = 7;
            txtDataAddr.Text = "00";
            txtDataAddr.TextChanged += filterOnlyHex_TextChanged;
            txtDataAddr.KeyPress += filterOnlyHex_KeyPress;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(351, 47);
            listBox1.Margin = new Padding(4, 3, 4, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(202, 199);
            listBox1.TabIndex = 6;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(9, 196);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(96, 15);
            label21.TabIndex = 5;
            label21.Text = "Write Data (Hex):";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(9, 162);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(139, 15);
            label20.TabIndex = 4;
            label20.Text = "Access Password (8 Hex):";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(9, 122);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(183, 30);
            label19.TabIndex = 3;
            label19.Text = "Length of Data(Read/Block Erase)\r\n(0-120/Word/D):";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(9, 96);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(177, 15);
            label18.TabIndex = 2;
            label18.Text = "Address of Tag Data(Word/Hex):";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(C_User);
            groupBox6.Controls.Add(C_TID);
            groupBox6.Controls.Add(C_EPC);
            groupBox6.Controls.Add(C_Reserve);
            groupBox6.Location = new Point(7, 39);
            groupBox6.Margin = new Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(4, 3, 4, 3);
            groupBox6.Size = new Size(338, 39);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            // 
            // C_User
            // 
            C_User.AutoSize = true;
            C_User.Location = new Point(241, 14);
            C_User.Margin = new Padding(4, 3, 4, 3);
            C_User.Name = "C_User";
            C_User.Size = new Size(48, 19);
            C_User.TabIndex = 3;
            C_User.TabStop = true;
            C_User.Text = "User";
            C_User.UseVisualStyleBackColor = true;
            C_User.CheckedChanged += C_User_CheckedChanged;
            // 
            // C_TID
            // 
            C_TID.AutoSize = true;
            C_TID.Location = new Point(174, 14);
            C_TID.Margin = new Padding(4, 3, 4, 3);
            C_TID.Name = "C_TID";
            C_TID.Size = new Size(43, 19);
            C_TID.TabIndex = 2;
            C_TID.TabStop = true;
            C_TID.Text = "TID";
            C_TID.UseVisualStyleBackColor = true;
            C_TID.CheckedChanged += C_TID_CheckedChanged;
            // 
            // C_EPC
            // 
            C_EPC.AutoSize = true;
            C_EPC.Location = new Point(102, 14);
            C_EPC.Margin = new Padding(4, 3, 4, 3);
            C_EPC.Name = "C_EPC";
            C_EPC.Size = new Size(46, 19);
            C_EPC.TabIndex = 1;
            C_EPC.TabStop = true;
            C_EPC.Text = "EPC";
            C_EPC.UseVisualStyleBackColor = true;
            C_EPC.CheckedChanged += C_EPC_CheckedChanged;
            // 
            // C_Reserve
            // 
            C_Reserve.AutoSize = true;
            C_Reserve.Location = new Point(5, 14);
            C_Reserve.Margin = new Padding(4, 3, 4, 3);
            C_Reserve.Name = "C_Reserve";
            C_Reserve.Size = new Size(78, 19);
            C_Reserve.TabIndex = 0;
            C_Reserve.TabStop = true;
            C_Reserve.Text = "RESERVED";
            C_Reserve.UseVisualStyleBackColor = true;
            C_Reserve.CheckedChanged += C_Reserve_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(ListView1_EPC);
            groupBox4.Location = new Point(1, 0);
            groupBox4.Margin = new Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 3, 4, 3);
            groupBox4.Size = new Size(560, 203);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "List EPC of Tags";
            // 
            // ListView1_EPC
            // 
            ListView1_EPC.AccessibleRole = AccessibleRole.IpAddress;
            ListView1_EPC.AutoArrange = false;
            ListView1_EPC.BackColor = SystemColors.ButtonHighlight;
            ListView1_EPC.Columns.AddRange(new ColumnHeader[] { listViewCol_Number, listViewCol_ID, listViewCol_Length, listViewCol_Times });
            ListView1_EPC.Dock = DockStyle.Top;
            ListView1_EPC.FullRowSelect = true;
            ListView1_EPC.GridLines = true;
            ListView1_EPC.Location = new Point(4, 19);
            ListView1_EPC.Margin = new Padding(4, 3, 4, 3);
            ListView1_EPC.Name = "ListView1_EPC";
            ListView1_EPC.Size = new Size(552, 171);
            ListView1_EPC.TabIndex = 1;
            ListView1_EPC.UseCompatibleStateImageBehavior = false;
            ListView1_EPC.View = View.Details;
            ListView1_EPC.DoubleClick += ListView1_EPC_DoubleClick;
            // 
            // listViewCol_Number
            // 
            listViewCol_Number.Text = "No.";
            listViewCol_Number.Width = 40;
            // 
            // listViewCol_ID
            // 
            listViewCol_ID.Text = "ID";
            listViewCol_ID.Width = 221;
            // 
            // listViewCol_Length
            // 
            listViewCol_Length.Text = "EPCLength";
            listViewCol_Length.Width = 101;
            // 
            // listViewCol_Times
            // 
            listViewCol_Times.Text = "Times";
            listViewCol_Times.Width = 66;
            // 
            // TabSheet_CMD
            // 
            TabSheet_CMD.BackColor = Color.Transparent;
            TabSheet_CMD.Controls.Add(groupBox3);
            TabSheet_CMD.Controls.Add(progressBar1);
            TabSheet_CMD.Controls.Add(groupBox2);
            TabSheet_CMD.Controls.Add(GroupBox1);
            TabSheet_CMD.Location = new Point(4, 24);
            TabSheet_CMD.Margin = new Padding(4, 3, 4, 3);
            TabSheet_CMD.Name = "TabSheet_CMD";
            TabSheet_CMD.Padding = new Padding(4, 3, 4, 3);
            TabSheet_CMD.Size = new Size(954, 784);
            TabSheet_CMD.TabIndex = 1;
            TabSheet_CMD.Text = "Reader Parameter";
            TabSheet_CMD.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(groupBox30);
            groupBox3.Controls.Add(btnReader_SetDefaultParameter);
            groupBox3.Controls.Add(btnReader_SetParameter);
            groupBox3.Controls.Add(ComboBox_scantime);
            groupBox3.Controls.Add(cbReader_SetBaud);
            groupBox3.Controls.Add(CheckBox_SameFre);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(ComboBox_dmaxfre);
            groupBox3.Controls.Add(ComboBox_dminfre);
            groupBox3.Controls.Add(ComboBox_PowerDbm);
            groupBox3.Controls.Add(Edit_NewComAdr);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label12);
            groupBox3.Location = new Point(172, 160);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(774, 210);
            groupBox3.TabIndex = 42;
            groupBox3.TabStop = false;
            groupBox3.Text = "Set Reader Parameter";
            // 
            // groupBox30
            // 
            groupBox30.Controls.Add(rbReader_FreqBand_Europe);
            groupBox30.Controls.Add(rbReader_FreqBand_Korean);
            groupBox30.Controls.Add(rbReader_FreqBand_US);
            groupBox30.Controls.Add(rbReader_FreqBand_Chinese);
            groupBox30.Controls.Add(rbReader_FreqBand_User);
            groupBox30.Location = new Point(554, 17);
            groupBox30.Margin = new Padding(4, 3, 4, 3);
            groupBox30.Name = "groupBox30";
            groupBox30.Padding = new Padding(4, 3, 4, 3);
            groupBox30.Size = new Size(210, 145);
            groupBox30.TabIndex = 44;
            groupBox30.TabStop = false;
            groupBox30.Text = "FreqBand Setting";
            // 
            // rbReader_FreqBand_Europe
            // 
            rbReader_FreqBand_Europe.AutoSize = true;
            rbReader_FreqBand_Europe.Location = new Point(7, 111);
            rbReader_FreqBand_Europe.Margin = new Padding(4, 3, 4, 3);
            rbReader_FreqBand_Europe.Name = "rbReader_FreqBand_Europe";
            rbReader_FreqBand_Europe.Size = new Size(69, 19);
            rbReader_FreqBand_Europe.TabIndex = 5;
            rbReader_FreqBand_Europe.TabStop = true;
            rbReader_FreqBand_Europe.Text = "EU band";
            rbReader_FreqBand_Europe.UseVisualStyleBackColor = true;
            rbReader_FreqBand_Europe.CheckedChanged += radioButton_band5_CheckedChanged;
            // 
            // rbReader_FreqBand_Korean
            // 
            rbReader_FreqBand_Korean.AutoSize = true;
            rbReader_FreqBand_Korean.Location = new Point(7, 85);
            rbReader_FreqBand_Korean.Margin = new Padding(4, 3, 4, 3);
            rbReader_FreqBand_Korean.Name = "rbReader_FreqBand_Korean";
            rbReader_FreqBand_Korean.Size = new Size(92, 19);
            rbReader_FreqBand_Korean.TabIndex = 3;
            rbReader_FreqBand_Korean.TabStop = true;
            rbReader_FreqBand_Korean.Text = "Korean band";
            rbReader_FreqBand_Korean.UseVisualStyleBackColor = true;
            rbReader_FreqBand_Korean.CheckedChanged += radioButton_band4_CheckedChanged;
            // 
            // rbReader_FreqBand_US
            // 
            rbReader_FreqBand_US.AutoSize = true;
            rbReader_FreqBand_US.Location = new Point(7, 62);
            rbReader_FreqBand_US.Margin = new Padding(4, 3, 4, 3);
            rbReader_FreqBand_US.Name = "rbReader_FreqBand_US";
            rbReader_FreqBand_US.Size = new Size(69, 19);
            rbReader_FreqBand_US.TabIndex = 2;
            rbReader_FreqBand_US.TabStop = true;
            rbReader_FreqBand_US.Text = "US band";
            rbReader_FreqBand_US.UseVisualStyleBackColor = true;
            rbReader_FreqBand_US.CheckedChanged += radioButton_band3_CheckedChanged;
            // 
            // rbReader_FreqBand_Chinese
            // 
            rbReader_FreqBand_Chinese.AutoSize = true;
            rbReader_FreqBand_Chinese.Location = new Point(7, 39);
            rbReader_FreqBand_Chinese.Margin = new Padding(4, 3, 4, 3);
            rbReader_FreqBand_Chinese.Name = "rbReader_FreqBand_Chinese";
            rbReader_FreqBand_Chinese.Size = new Size(97, 19);
            rbReader_FreqBand_Chinese.TabIndex = 1;
            rbReader_FreqBand_Chinese.TabStop = true;
            rbReader_FreqBand_Chinese.Text = "Chinese band";
            rbReader_FreqBand_Chinese.UseVisualStyleBackColor = true;
            rbReader_FreqBand_Chinese.CheckedChanged += radioButton_band2_CheckedChanged;
            // 
            // rbReader_FreqBand_User
            // 
            rbReader_FreqBand_User.AutoSize = true;
            rbReader_FreqBand_User.Location = new Point(7, 16);
            rbReader_FreqBand_User.Margin = new Padding(4, 3, 4, 3);
            rbReader_FreqBand_User.Name = "rbReader_FreqBand_User";
            rbReader_FreqBand_User.Size = new Size(78, 19);
            rbReader_FreqBand_User.TabIndex = 0;
            rbReader_FreqBand_User.TabStop = true;
            rbReader_FreqBand_User.Text = "User band";
            rbReader_FreqBand_User.UseVisualStyleBackColor = true;
            rbReader_FreqBand_User.CheckedChanged += radioButton_band1_CheckedChanged;
            // 
            // btnReader_SetDefaultParameter
            // 
            btnReader_SetDefaultParameter.Location = new Point(628, 170);
            btnReader_SetDefaultParameter.Margin = new Padding(4, 3, 4, 3);
            btnReader_SetDefaultParameter.Name = "btnReader_SetDefaultParameter";
            btnReader_SetDefaultParameter.Size = new Size(138, 29);
            btnReader_SetDefaultParameter.TabIndex = 14;
            btnReader_SetDefaultParameter.Text = "Default Parameter";
            btnReader_SetDefaultParameter.UseVisualStyleBackColor = true;
            btnReader_SetDefaultParameter.Click += btnReader_SetDefaultParameter_Click;
            // 
            // btnReader_SetParameter
            // 
            btnReader_SetParameter.Location = new Point(471, 170);
            btnReader_SetParameter.Margin = new Padding(4, 3, 4, 3);
            btnReader_SetParameter.Name = "btnReader_SetParameter";
            btnReader_SetParameter.Size = new Size(141, 29);
            btnReader_SetParameter.TabIndex = 13;
            btnReader_SetParameter.Text = "Set Parameter";
            btnReader_SetParameter.UseVisualStyleBackColor = true;
            btnReader_SetParameter.Click += btnReader_SetParameter_Click;
            // 
            // ComboBox_scantime
            // 
            ComboBox_scantime.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_scantime.FormattingEnabled = true;
            ComboBox_scantime.Location = new Point(406, 76);
            ComboBox_scantime.Margin = new Padding(4, 3, 4, 3);
            ComboBox_scantime.Name = "ComboBox_scantime";
            ComboBox_scantime.Size = new Size(140, 23);
            ComboBox_scantime.TabIndex = 12;
            // 
            // cbReader_SetBaud
            // 
            cbReader_SetBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_SetBaud.FormattingEnabled = true;
            cbReader_SetBaud.Items.AddRange(new object[] { "9600bps", "19200bps", "38400bps", "57600bps", "115200bps" });
            cbReader_SetBaud.Location = new Point(406, 25);
            cbReader_SetBaud.Margin = new Padding(4, 3, 4, 3);
            cbReader_SetBaud.Name = "cbReader_SetBaud";
            cbReader_SetBaud.Size = new Size(140, 23);
            cbReader_SetBaud.TabIndex = 11;
            // 
            // CheckBox_SameFre
            // 
            CheckBox_SameFre.AutoSize = true;
            CheckBox_SameFre.Location = new Point(251, 130);
            CheckBox_SameFre.Margin = new Padding(4, 3, 4, 3);
            CheckBox_SameFre.Name = "CheckBox_SameFre";
            CheckBox_SameFre.Size = new Size(150, 19);
            CheckBox_SameFre.TabIndex = 10;
            CheckBox_SameFre.Text = "Single Frequency Point ";
            CheckBox_SameFre.UseVisualStyleBackColor = true;
            CheckBox_SameFre.CheckedChanged += CheckBox_SameFre_CheckedChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(248, 80);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(137, 15);
            label17.TabIndex = 9;
            label17.Text = "Max InventoryScanTime:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(248, 33);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(63, 15);
            label16.TabIndex = 8;
            label16.Text = "Baud Rate:";
            // 
            // ComboBox_dmaxfre
            // 
            ComboBox_dmaxfre.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_dmaxfre.FormattingEnabled = true;
            ComboBox_dmaxfre.Location = new Point(111, 173);
            ComboBox_dmaxfre.Margin = new Padding(4, 3, 4, 3);
            ComboBox_dmaxfre.Name = "ComboBox_dmaxfre";
            ComboBox_dmaxfre.Size = new Size(116, 23);
            ComboBox_dmaxfre.TabIndex = 7;
            ComboBox_dmaxfre.SelectedIndexChanged += ComboBox_dfreSelect;
            // 
            // ComboBox_dminfre
            // 
            ComboBox_dminfre.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_dminfre.FormattingEnabled = true;
            ComboBox_dminfre.Location = new Point(111, 128);
            ComboBox_dminfre.Margin = new Padding(4, 3, 4, 3);
            ComboBox_dminfre.Name = "ComboBox_dminfre";
            ComboBox_dminfre.Size = new Size(116, 23);
            ComboBox_dminfre.TabIndex = 6;
            ComboBox_dminfre.SelectedIndexChanged += ComboBox_dfreSelect;
            // 
            // ComboBox_PowerDbm
            // 
            ComboBox_PowerDbm.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_PowerDbm.FormattingEnabled = true;
            ComboBox_PowerDbm.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" });
            ComboBox_PowerDbm.Location = new Point(111, 76);
            ComboBox_PowerDbm.Margin = new Padding(4, 3, 4, 3);
            ComboBox_PowerDbm.Name = "ComboBox_PowerDbm";
            ComboBox_PowerDbm.Size = new Size(116, 23);
            ComboBox_PowerDbm.TabIndex = 5;
            // 
            // Edit_NewComAdr
            // 
            Edit_NewComAdr.Location = new Point(111, 25);
            Edit_NewComAdr.Margin = new Padding(4, 3, 4, 3);
            Edit_NewComAdr.MaxLength = 2;
            Edit_NewComAdr.Name = "Edit_NewComAdr";
            Edit_NewComAdr.Size = new Size(116, 23);
            Edit_NewComAdr.TabIndex = 4;
            Edit_NewComAdr.Text = "00";
            Edit_NewComAdr.TextChanged += filterOnlyHex_TextChanged;
            Edit_NewComAdr.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 177);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(90, 15);
            label15.TabIndex = 3;
            label15.Text = "Max.Frequency:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 132);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(89, 15);
            label14.TabIndex = 2;
            label14.Text = "Min.Frequency:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 80);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(43, 15);
            label13.TabIndex = 1;
            label13.Text = "Power:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 33);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 0;
            label12.Text = "Address(HEX):";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(282, 391);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(465, 29);
            progressBar1.TabIndex = 43;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnReader_GetReaderInfo);
            groupBox2.Controls.Add(Edit_scantime);
            groupBox2.Controls.Add(EPCC1G2);
            groupBox2.Controls.Add(ISO180006B);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(Edit_dmaxfre);
            groupBox2.Controls.Add(Edit_powerdBm);
            groupBox2.Controls.Add(Edit_Version);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(Edit_dminfre);
            groupBox2.Controls.Add(Edit_ComAdr);
            groupBox2.Controls.Add(Edit_Type);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(172, 7);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(774, 149);
            groupBox2.TabIndex = 41;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reader Information";
            // 
            // btnReader_GetReaderInfo
            // 
            btnReader_GetReaderInfo.Location = new Point(628, 113);
            btnReader_GetReaderInfo.Margin = new Padding(4, 3, 4, 3);
            btnReader_GetReaderInfo.Name = "btnReader_GetReaderInfo";
            btnReader_GetReaderInfo.Size = new Size(138, 29);
            btnReader_GetReaderInfo.TabIndex = 17;
            btnReader_GetReaderInfo.Text = "Get Reader Info";
            btnReader_GetReaderInfo.UseVisualStyleBackColor = true;
            btnReader_GetReaderInfo.Click += btnReader_GetReaderInfo_Click;
            // 
            // Edit_scantime
            // 
            Edit_scantime.BackColor = SystemColors.ScrollBar;
            Edit_scantime.Location = new Point(628, 68);
            Edit_scantime.Margin = new Padding(4, 3, 4, 3);
            Edit_scantime.Name = "Edit_scantime";
            Edit_scantime.Size = new Size(137, 23);
            Edit_scantime.TabIndex = 16;
            // 
            // EPCC1G2
            // 
            EPCC1G2.AutoSize = true;
            EPCC1G2.Location = new Point(628, 40);
            EPCC1G2.Margin = new Padding(4, 3, 4, 3);
            EPCC1G2.Name = "EPCC1G2";
            EPCC1G2.Size = new Size(80, 19);
            EPCC1G2.TabIndex = 15;
            EPCC1G2.Text = "EPCC1-G2";
            EPCC1G2.UseVisualStyleBackColor = true;
            // 
            // ISO180006B
            // 
            ISO180006B.AutoSize = true;
            ISO180006B.Location = new Point(628, 16);
            ISO180006B.Margin = new Padding(4, 3, 4, 3);
            ISO180006B.Name = "ISO180006B";
            ISO180006B.Size = new Size(92, 19);
            ISO180006B.TabIndex = 14;
            ISO180006B.Text = "ISO18000-6B";
            ISO180006B.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(469, 73);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(137, 15);
            label11.TabIndex = 13;
            label11.Text = "Max InventoryScanTime:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(469, 27);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 12;
            label10.Text = "Protocols:";
            // 
            // Edit_dmaxfre
            // 
            Edit_dmaxfre.BackColor = SystemColors.ScrollBar;
            Edit_dmaxfre.Location = new Point(334, 115);
            Edit_dmaxfre.Margin = new Padding(4, 3, 4, 3);
            Edit_dmaxfre.Name = "Edit_dmaxfre";
            Edit_dmaxfre.Size = new Size(116, 23);
            Edit_dmaxfre.TabIndex = 11;
            // 
            // Edit_powerdBm
            // 
            Edit_powerdBm.BackColor = SystemColors.ScrollBar;
            Edit_powerdBm.Location = new Point(334, 69);
            Edit_powerdBm.Margin = new Padding(4, 3, 4, 3);
            Edit_powerdBm.Name = "Edit_powerdBm";
            Edit_powerdBm.Size = new Size(116, 23);
            Edit_powerdBm.TabIndex = 10;
            // 
            // Edit_Version
            // 
            Edit_Version.BackColor = SystemColors.ScrollBar;
            Edit_Version.Location = new Point(334, 23);
            Edit_Version.Margin = new Padding(4, 3, 4, 3);
            Edit_Version.Name = "Edit_Version";
            Edit_Version.Size = new Size(116, 23);
            Edit_Version.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(230, 119);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 8;
            label9.Text = "Max.Frequency:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(230, 73);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 7;
            label8.Text = "Power:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(230, 27);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 6;
            label7.Text = "Version:";
            // 
            // Edit_dminfre
            // 
            Edit_dminfre.BackColor = SystemColors.ScrollBar;
            Edit_dminfre.Location = new Point(111, 115);
            Edit_dminfre.Margin = new Padding(4, 3, 4, 3);
            Edit_dminfre.Name = "Edit_dminfre";
            Edit_dminfre.Size = new Size(98, 23);
            Edit_dminfre.TabIndex = 5;
            // 
            // Edit_ComAdr
            // 
            Edit_ComAdr.BackColor = SystemColors.ScrollBar;
            Edit_ComAdr.Location = new Point(111, 69);
            Edit_ComAdr.Margin = new Padding(4, 3, 4, 3);
            Edit_ComAdr.Name = "Edit_ComAdr";
            Edit_ComAdr.Size = new Size(98, 23);
            Edit_ComAdr.TabIndex = 4;
            // 
            // Edit_Type
            // 
            Edit_Type.BackColor = SystemColors.ScrollBar;
            Edit_Type.Location = new Point(111, 23);
            Edit_Type.Margin = new Padding(4, 3, 4, 3);
            Edit_Type.Name = "Edit_Type";
            Edit_Type.Size = new Size(98, 23);
            Edit_Type.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 119);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 2;
            label6.Text = "Min.Frequency:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 73);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 1;
            label5.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 27);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 0;
            label4.Text = "Type:";
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(cbReader_ComBaud);
            GroupBox1.Controls.Add(label47);
            GroupBox1.Controls.Add(cbReader_AlreadyOpenCOM);
            GroupBox1.Controls.Add(label3);
            GroupBox1.Controls.Add(btnReader_ClosePort);
            GroupBox1.Controls.Add(btnReader_OpenPort);
            GroupBox1.Controls.Add(txtReader_CmdComAddr);
            GroupBox1.Controls.Add(Label2);
            GroupBox1.Controls.Add(cbReader_COM);
            GroupBox1.Controls.Add(Label1);
            GroupBox1.Location = new Point(6, 7);
            GroupBox1.Margin = new Padding(4, 3, 4, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 3, 4, 3);
            GroupBox1.Size = new Size(159, 256);
            GroupBox1.TabIndex = 40;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Communication";
            // 
            // cbReader_ComBaud
            // 
            cbReader_ComBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_ComBaud.FormattingEnabled = true;
            cbReader_ComBaud.Items.AddRange(new object[] { "9600bps", "19200bps", "38400bps", "57600bps", "115200bps" });
            cbReader_ComBaud.Location = new Point(8, 137);
            cbReader_ComBaud.Margin = new Padding(4, 3, 4, 3);
            cbReader_ComBaud.Name = "cbReader_ComBaud";
            cbReader_ComBaud.Size = new Size(140, 23);
            cbReader_ComBaud.TabIndex = 12;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(8, 119);
            label47.Margin = new Padding(4, 0, 4, 0);
            label47.Name = "label47";
            label47.Size = new Size(63, 15);
            label47.TabIndex = 9;
            label47.Text = "Baud Rate:";
            // 
            // cbReader_AlreadyOpenCOM
            // 
            cbReader_AlreadyOpenCOM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_AlreadyOpenCOM.FormattingEnabled = true;
            cbReader_AlreadyOpenCOM.Location = new Point(7, 189);
            cbReader_AlreadyOpenCOM.Margin = new Padding(4, 3, 4, 3);
            cbReader_AlreadyOpenCOM.Name = "cbReader_AlreadyOpenCOM";
            cbReader_AlreadyOpenCOM.Size = new Size(145, 23);
            cbReader_AlreadyOpenCOM.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 167);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 6;
            label3.Text = "Opened COM Port:";
            // 
            // btnReader_ClosePort
            // 
            btnReader_ClosePort.Location = new Point(7, 219);
            btnReader_ClosePort.Margin = new Padding(4, 3, 4, 3);
            btnReader_ClosePort.Name = "btnReader_ClosePort";
            btnReader_ClosePort.Size = new Size(146, 29);
            btnReader_ClosePort.TabIndex = 5;
            btnReader_ClosePort.Text = "ClosePort";
            btnReader_ClosePort.UseVisualStyleBackColor = true;
            btnReader_ClosePort.Click += btnReader_ClosePort_Click;
            // 
            // btnReader_OpenPort
            // 
            btnReader_OpenPort.Location = new Point(6, 83);
            btnReader_OpenPort.Margin = new Padding(4, 3, 4, 3);
            btnReader_OpenPort.Name = "btnReader_OpenPort";
            btnReader_OpenPort.Size = new Size(146, 29);
            btnReader_OpenPort.TabIndex = 4;
            btnReader_OpenPort.Text = "Open COM Port";
            btnReader_OpenPort.UseVisualStyleBackColor = true;
            btnReader_OpenPort.Click += btnReader_OpenPort_Click;
            // 
            // txtReader_CmdComAddr
            // 
            txtReader_CmdComAddr.BackColor = SystemColors.Window;
            txtReader_CmdComAddr.Location = new Point(114, 48);
            txtReader_CmdComAddr.Margin = new Padding(4, 3, 4, 3);
            txtReader_CmdComAddr.MaxLength = 2;
            txtReader_CmdComAddr.Name = "txtReader_CmdComAddr";
            txtReader_CmdComAddr.Size = new Size(37, 23);
            txtReader_CmdComAddr.TabIndex = 3;
            txtReader_CmdComAddr.Text = "FF";
            txtReader_CmdComAddr.TextChanged += filterOnlyHex_TextChanged;
            txtReader_CmdComAddr.KeyPress += filterOnlyHex_KeyPress;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Location = new Point(7, 53);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(91, 15);
            Label2.TabIndex = 2;
            Label2.Text = "Reader Address:";
            // 
            // cbReader_COM
            // 
            cbReader_COM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_COM.FormattingEnabled = true;
            cbReader_COM.Location = new Point(76, 16);
            cbReader_COM.Margin = new Padding(4, 3, 4, 3);
            cbReader_COM.Name = "cbReader_COM";
            cbReader_COM.Size = new Size(75, 23);
            cbReader_COM.TabIndex = 1;
            cbReader_COM.SelectedIndexChanged += ComboBox_COM_SelectedIndexChanged;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 27);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(66, 15);
            Label1.TabIndex = 0;
            Label1.Text = "COM Port：";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabSheet_CMD);
            tabControl1.Controls.Add(TabSheet_EPCC1G2);
            tabControl1.Controls.Add(TabSheet_6B);
            tabControl1.Controls.Add(TabSheet_DUP);
            tabControl1.Location = new Point(2, 1);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(962, 812);
            tabControl1.TabIndex = 0;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(AccessCode);
            groupBox9.Controls.Add(DestroyCode);
            groupBox9.Location = new Point(6, 23);
            groupBox9.Margin = new Padding(4, 3, 4, 3);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(4, 3, 4, 3);
            groupBox9.Size = new Size(276, 60);
            groupBox9.TabIndex = 0;
            groupBox9.TabStop = false;
            // 
            // DestroyCode
            // 
            DestroyCode.AutoSize = true;
            DestroyCode.Location = new Point(7, 25);
            DestroyCode.Margin = new Padding(4, 3, 4, 3);
            DestroyCode.Name = "DestroyCode";
            DestroyCode.Size = new Size(94, 19);
            DestroyCode.TabIndex = 0;
            DestroyCode.TabStop = true;
            DestroyCode.Text = "Kill Password";
            DestroyCode.UseVisualStyleBackColor = true;
            // 
            // AccessCode
            // 
            AccessCode.AutoSize = true;
            AccessCode.Location = new Point(126, 25);
            AccessCode.Margin = new Padding(4, 3, 4, 3);
            AccessCode.Name = "AccessCode";
            AccessCode.Size = new Size(114, 19);
            AccessCode.TabIndex = 1;
            AccessCode.TabStop = true;
            AccessCode.Text = "Access Password";
            AccessCode.UseVisualStyleBackColor = true;
            // 
            // NoProect
            // 
            NoProect.AutoSize = true;
            NoProect.Location = new Point(7, 84);
            NoProect.Margin = new Padding(4, 3, 4, 3);
            NoProect.Name = "NoProect";
            NoProect.Size = new Size(229, 19);
            NoProect.TabIndex = 1;
            NoProect.TabStop = true;
            NoProect.Text = "Readable and  writeable from any state";
            NoProect.UseVisualStyleBackColor = true;
            // 
            // Proect
            // 
            Proect.AutoSize = true;
            Proect.Location = new Point(7, 108);
            Proect.Margin = new Padding(4, 3, 4, 3);
            Proect.Name = "Proect";
            Proect.Size = new Size(268, 19);
            Proect.TabIndex = 2;
            Proect.TabStop = true;
            Proect.Text = "Readable and writeable from the secured state";
            Proect.UseVisualStyleBackColor = true;
            // 
            // Always
            // 
            Always.AutoSize = true;
            Always.Location = new Point(7, 131);
            Always.Margin = new Padding(4, 3, 4, 3);
            Always.Name = "Always";
            Always.Size = new Size(214, 19);
            Always.TabIndex = 3;
            Always.TabStop = true;
            Always.Text = "Permanently readable and writeable";
            Always.UseVisualStyleBackColor = true;
            // 
            // AlwaysNot
            // 
            AlwaysNot.AutoSize = true;
            AlwaysNot.Location = new Point(7, 155);
            AlwaysNot.Margin = new Padding(4, 3, 4, 3);
            AlwaysNot.Name = "AlwaysNot";
            AlwaysNot.Size = new Size(178, 19);
            AlwaysNot.TabIndex = 4;
            AlwaysNot.TabStop = true;
            AlwaysNot.Text = "Never readable and writeable";
            AlwaysNot.UseVisualStyleBackColor = true;
            // 
            // gbLockPassword
            // 
            gbLockPassword.Controls.Add(AlwaysNot);
            gbLockPassword.Controls.Add(Always);
            gbLockPassword.Controls.Add(Proect);
            gbLockPassword.Controls.Add(NoProect);
            gbLockPassword.Controls.Add(groupBox9);
            gbLockPassword.Location = new Point(5, 46);
            gbLockPassword.Margin = new Padding(4, 3, 4, 3);
            gbLockPassword.Name = "gbLockPassword";
            gbLockPassword.Padding = new Padding(4, 3, 4, 3);
            gbLockPassword.Size = new Size(289, 184);
            gbLockPassword.TabIndex = 1;
            gbLockPassword.TabStop = false;
            gbLockPassword.Text = "Lock of [RESERVED] Password";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(966, 839);
            Controls.Add(StatusBar1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LJYZN-105 / BY-RFID105";
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += Form1_Load;
            StatusBar1.ResumeLayout(false);
            StatusBar1.PerformLayout();
            TabSheet_DUP.ResumeLayout(false);
            groupBox36.ResumeLayout(false);
            groupBox29.ResumeLayout(false);
            groupBox29.PerformLayout();
            groupBox28.ResumeLayout(false);
            groupBox28.PerformLayout();
            groupBox27.ResumeLayout(false);
            groupBox26.ResumeLayout(false);
            groupBox26.PerformLayout();
            groupBox23.ResumeLayout(false);
            groupBox25.ResumeLayout(false);
            groupBox24.ResumeLayout(false);
            TabSheet_6B.ResumeLayout(false);
            groupBox22.ResumeLayout(false);
            groupBox22.PerformLayout();
            groupBox21.ResumeLayout(false);
            groupBox21.PerformLayout();
            groupBox20.ResumeLayout(false);
            groupBox20.PerformLayout();
            groupBox19.ResumeLayout(false);
            TabSheet_EPCC1G2.ResumeLayout(false);
            TabSheet_EPCC1G2.PerformLayout();
            groupBox31.ResumeLayout(false);
            groupBox31.PerformLayout();
            groupBox18.ResumeLayout(false);
            groupBox18.PerformLayout();
            groupBox16.ResumeLayout(false);
            groupBox16.PerformLayout();
            groupBox17.ResumeLayout(false);
            groupBox17.PerformLayout();
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            gbQueryTIDParams.ResumeLayout(false);
            gbQueryTIDParams.PerformLayout();
            gbTagLock.ResumeLayout(false);
            gbTagLock.PerformLayout();
            gbLockTIDnUSER.ResumeLayout(false);
            gbLockTIDnUSER.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            TabSheet_CMD.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox30.ResumeLayout(false);
            groupBox30.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            gbLockPassword.ResumeLayout(false);
            gbLockPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.StatusStrip StatusBar1;
        private System.Windows.Forms.Timer Timer_Test_;
        private System.Windows.Forms.Timer Timer_G2_Read;
        private System.Windows.Forms.Timer Timer_G2_Alarm;
        private System.Windows.Forms.Timer Timer_Test_6B;
        private System.Windows.Forms.Timer Timer_6B_Read;
        private System.Windows.Forms.Timer Timer_6B_Write;
        private System.Windows.Forms.ToolStripStatusLabel tss_Status;
        private System.Windows.Forms.ToolStripStatusLabel tss_COM;
        private TabPage TabSheet_DUP;
        private GroupBox groupBox36;
        private Button btnDup_MonzaQTWrite;
        private Button btnDup_MonzaQTQuery;
        private ComboBox cbDup_MonzaQT_Distance;
        private ComboBox cbDup_MonzaQT_Profile;
        private GroupBox groupBox29;
        private TextBox txtDup_Read_STI_Prod;
        private TextBox txtDup_Read_STI_Manu;
        private Label label57;
        private TextBox txtReadTMN;
        private CheckBox chkReadFileOpen;
        private CheckBox chkReadAuthChlg;
        private CheckBox chkReadXTID;
        private Label label58;
        private TextBox txtReadMDID;
        private GroupBox groupBox28;
        private Label label48;
        private TextBox txtAFI;
        private CheckBox cbEPCGA;
        private CheckBox cbXPC;
        private CheckBox cbUMI;
        private TextBox txtEPCLength;
        private Label label46;
        private GroupBox groupBox27;
        private Button btnDup_ResetWaveCard;
        private Button btnDup_CreateWaveCard;
        private GroupBox groupBox26;
        private TextBox txtDup_Write_TID_PWD;
        private Label lblDup_WriteTID;
        private Button btnDup_WriteTID;
        private TextBox txtDup_Write_TID;
        private TextBox txtDup_Read_FullEPCLen;
        private Button btnLoadReadData;
        private Button btnSaveReadData;
        private TextBox txtDup_Validate_UserDataLen;
        private Label label61;
        private TextBox txtDup_Read_KillPwd;
        private TextBox txtDup_Read_UserDataLen;
        private Label lblDup_ValidateTID;
        private TextBox txtDup_Validate_TID;
        private Label label49;
        private Label label56;
        private TextBox txtDup_Validate_PC;
        private Label label52;
        private Label label53;
        private TextBox txtDup_Validate_CRC;
        private TextBox txtDup_Read_PC;
        private Label label51;
        private Label label50;
        private TextBox txtDup_Read_CRC;
        private Label lblDup_ReadTID;
        private TextBox txtDup_Read_TID;
        private TextBox txtDup_Validate_AccessPwd;
        private TextBox txtDup_Write_AccessPwd;
        private TextBox txtDup_Read_AccessPwd;
        private Label label45;
        private Label label42;
        private TextBox txtDup_Read_UserData;
        private TextBox txtDup_Write_UserData;
        private TextBox txtDup_Validate_UserData;
        private Label label41;
        private Label label40;
        private Label label39;
        private Label label38;
        private TextBox txtDup_Write_FullEPC;
        private TextBox txtDup_Write_EPC;
        private Label label37;
        private TextBox txtDup_Validate_EPC;
        private TextBox txtDup_Read_FullEPC;
        private TextBox txtDup_Read_EPC;
        private TextBox txtDup_Validate_FullEPC;
        private GroupBox groupBox23;
        private Button btnDup_SearchCard;
        private GroupBox groupBox25;
        private Button btnHasLockedUserBlocks;
        private Button btnWavev2Flag;
        private Button waveFlagRed;
        private Button waveFlagPurple;
        private Button waveFlagBlack;
        private Button waveFlagBlue;
        private Button waveFlagGreen;
        private Button waveFlagYellow;
        private GroupBox groupBox24;
        private Button btnDup_ValidateCard;
        private Button btnDup_WriteCard;
        private Button btnDup_ReadCard;
        private TabPage TabSheet_6B;
        private GroupBox groupBox22;
        private TextBox Edit_WriteData_6B;
        private Label label36;
        private ListBox lb6B_list2;
        private Button SpeedButton_Clear_6B;
        private Button SpeedButton_Check_6B;
        private Button SpeedButton_Perm_Wr_Prot_6B;
        private Button SpeedButton_Write_6B;
        private Button SpeedButton_Read_6B;
        private TextBox Edit_Len_6B;
        private Label label35;
        private TextBox Edit_StartAddress_6B;
        private Label label34;
        private ComboBox ComboBox_ID1_6B;
        private GroupBox groupBox21;
        private TextBox Edit_ConditionContent_6B;
        private TextBox Edit_Query_StartAddress_6B;
        private Label label33;
        private Label label32;
        private RadioButton Greater_6B;
        private RadioButton Less_6B;
        private RadioButton Different_6B;
        private RadioButton Same_6B;
        private GroupBox groupBox20;
        private Button SpeedButton_Query_6B;
        private RadioButton Bycondition_6B;
        private RadioButton Byone_6B;
        private ComboBox ComboBox_IntervalTime_6B;
        private Label label31;
        private GroupBox groupBox19;
        private ListView lv6B_Tags;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private TabPage TabSheet_EPCC1G2;
        private GroupBox groupBox31;
        private TextBox maskLen_textBox;
        private Label label44;
        private TextBox maskadr_textbox;
        private Label label43;
        private CheckBox checkBox1;
        private GroupBox groupBox18;
        private Button Button_LockUserBlock_G2;
        private TextBox Edit_AccessCode6;
        private ComboBox ComboBox_BlockNum;
        private Label label30;
        private Label label29;
        private ComboBox ComboBox_EPC6;
        private GroupBox groupBox16;
        private Label Label_Alarm;
        private Button Button_CheckEASAlarm_G2;
        private Button Button_SetEASAlarm_G2;
        private GroupBox groupBox17;
        private RadioButton NoAlarm_G2;
        private RadioButton Alarm_G2;
        private TextBox Edit_AccessCode5;
        private Label label28;
        private ComboBox ComboBox_EPC5;
        private GroupBox groupBox15;
        private Button Button_CheckReadProtected_G2;
        private Button Button_RemoveReadProtect_G2;
        private Button Button_SetMultiReadProtect_G2;
        private Button Button_SetReadProtect_G2;
        private TextBox Edit_AccessCode4;
        private Label label27;
        private ComboBox ComboBox_EPC4;
        private GroupBox groupBox14;
        private Button Button_WriteEPC_G2;
        private TextBox Edit_AccessCode3;
        private Label label26;
        private TextBox Edit_WriteEPC;
        private Label label25;
        private GroupBox groupBox13;
        private Button Button_DestroyCard;
        private TextBox Edit_DestroyCode;
        private Label label24;
        private ComboBox ComboBox_EPC3;
        private GroupBox groupBox12;
        private CheckBox CheckBox_TID;
        private GroupBox gbQueryTIDParams;
        private TextBox textBox5;
        private Label label55;
        private TextBox textBox4;
        private Label label54;
        private Button Button_QueryTag;
        private ComboBox ComboBox_IntervalTime;
        private Label label23;
        private GroupBox gbTagLock;
        private Button Button_SetProtectState;
        private TextBox textBox2;
        private Label label22;
        private GroupBox gbLockTIDnUSER;
        private RadioButton AlwaysNot2;
        private RadioButton Always2;
        private RadioButton Proect2;
        private RadioButton NoProect2;
        private GroupBox groupBox10;
        private RadioButton P_User;
        private RadioButton P_TID;
        private RadioButton P_EPC;
        private RadioButton P_Reserve;
        private ComboBox ComboBox_EPC1;
        private GroupBox groupBox5;
        private TextBox textBox_pc;
        private CheckBox checkBox_pc;
        private Button Button_BlockWrite;
        private ComboBox ComboBox_EPC2;
        private Button Button_ListClear;
        private Button Button_BlockErase;
        private Button Button_DataWrite;
        private Button SpeedButton_Read_G2;
        private TextBox Edit_WriteData;
        private TextBox Edit_AccessCode2;
        private TextBox txtDataLen;
        private TextBox txtDataAddr;
        private ListBox listBox1;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private GroupBox groupBox6;
        private RadioButton C_User;
        private RadioButton C_TID;
        private RadioButton C_EPC;
        private RadioButton C_Reserve;
        private GroupBox groupBox4;
        private ListView ListView1_EPC;
        private ColumnHeader listViewCol_Number;
        private ColumnHeader listViewCol_ID;
        private ColumnHeader listViewCol_Length;
        private ColumnHeader listViewCol_Times;
        private TabPage TabSheet_CMD;
        private GroupBox groupBox3;
        private GroupBox groupBox30;
        private RadioButton rbReader_FreqBand_Europe;
        private RadioButton rbReader_FreqBand_Korean;
        private RadioButton rbReader_FreqBand_US;
        private RadioButton rbReader_FreqBand_Chinese;
        private RadioButton rbReader_FreqBand_User;
        private Button btnReader_SetDefaultParameter;
        private Button btnReader_SetParameter;
        private ComboBox ComboBox_scantime;
        private ComboBox cbReader_SetBaud;
        private CheckBox CheckBox_SameFre;
        private Label label17;
        private Label label16;
        private ComboBox ComboBox_dmaxfre;
        private ComboBox ComboBox_dminfre;
        private ComboBox ComboBox_PowerDbm;
        private TextBox Edit_NewComAdr;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private ProgressBar progressBar1;
        private GroupBox groupBox2;
        private Button btnReader_GetReaderInfo;
        private TextBox Edit_scantime;
        private CheckBox EPCC1G2;
        private CheckBox ISO180006B;
        private Label label11;
        private Label label10;
        private TextBox Edit_dmaxfre;
        private TextBox Edit_powerdBm;
        private TextBox Edit_Version;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox Edit_dminfre;
        private TextBox Edit_ComAdr;
        private TextBox Edit_Type;
        private Label label6;
        private Label label5;
        private Label label4;
        internal GroupBox GroupBox1;
        private ComboBox cbReader_ComBaud;
        private Label label47;
        private ComboBox cbReader_AlreadyOpenCOM;
        private Label label3;
        internal Button btnReader_ClosePort;
        internal Button btnReader_OpenPort;
        internal TextBox txtReader_CmdComAddr;
        internal Label Label2;
        internal ComboBox cbReader_COM;
        internal Label Label1;
        private TabControl tabControl1;
        private CheckBox cb6C_IKnowTagLock;
        private GroupBox gbLockPassword;
        private RadioButton AlwaysNot;
        private RadioButton Always;
        private RadioButton Proect;
        private RadioButton NoProect;
        private GroupBox groupBox9;
        private RadioButton AccessCode;
        private RadioButton DestroyCode;
    }
}

