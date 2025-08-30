namespace FM_5XX
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new GroupBox();
            btnReader_COMClose = new Button();
            btnReader_COMOpen = new Button();
            btnRefreshComPorts = new Button();
            cbReader_COM = new ComboBox();
            Label1 = new Label();
            cb6C_IKnowTagKill = new CheckBox();
            groupBox_TagKill = new GroupBox();
            label16 = new Label();
            btn6C_KillTag = new Button();
            textBox1 = new TextBox();
            label15 = new Label();
            groupBox6 = new GroupBox();
            label19 = new Label();
            txtInvTID_Length = new TextBox();
            label17 = new Label();
            txtInvTID_Address = new TextBox();
            lvInventoryTID = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            btnInventoryEPC = new Button();
            btnInventoryTID = new Button();
            lvInventoryEPC = new ListView();
            lvInvCol_Number = new ColumnHeader();
            lvInvCol_PC = new ColumnHeader();
            lvInvCol_EPC = new ColumnHeader();
            lvInvCol_Len = new ColumnHeader();
            lvInvCol_Count = new ColumnHeader();
            cb6C_IKnowTagLock = new CheckBox();
            groupBox_TagLocking = new GroupBox();
            btnSetProtectState = new Button();
            groupBox10 = new GroupBox();
            P_User = new RadioButton();
            P_TID = new RadioButton();
            P_EPC = new RadioButton();
            P_Reserve = new RadioButton();
            textBox2 = new TextBox();
            label22 = new Label();
            gbLockPassword = new GroupBox();
            AlwaysNot = new RadioButton();
            Always = new RadioButton();
            Proect = new RadioButton();
            NoProect = new RadioButton();
            groupBox9 = new GroupBox();
            AccessCode = new RadioButton();
            DestroyCode = new RadioButton();
            gbLockTIDnUSER = new GroupBox();
            AlwaysNot2 = new RadioButton();
            Always2 = new RadioButton();
            Proect2 = new RadioButton();
            NoProect2 = new RadioButton();
            timer_InventoryEPC = new System.Windows.Forms.Timer(components);
            timer_InventoryTID = new System.Windows.Forms.Timer(components);
            btnGetVersion = new Button();
            label2 = new Label();
            textSWVer = new TextBox();
            textHWVer = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textReaderID = new TextBox();
            cbRFBand = new ComboBox();
            btnSaveRFBand = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            gbRFInfo = new GroupBox();
            btnRFFreqSave = new Button();
            btnGetPowerLevel = new Button();
            btnSavePowerLevel = new Button();
            cbPowerLevel = new ComboBox();
            label18 = new Label();
            lbFreqOffset = new Label();
            label14 = new Label();
            rbBBM_RX = new RadioButton();
            rbBBM_Carry = new RadioButton();
            label8 = new Label();
            cbFreqSel = new ComboBox();
            label7 = new Label();
            btnRFFreqRefresh = new Button();
            gbVersionInfo = new GroupBox();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            checkBox1 = new CheckBox();
            textBox5 = new TextBox();
            label24 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label20 = new Label();
            label23 = new Label();
            label21 = new Label();
            comboBox1 = new ComboBox();
            gbTagRW = new GroupBox();
            txtReader_ReadData = new TextBox();
            label6 = new Label();
            txtReader_WriteData = new TextBox();
            label13 = new Label();
            txt6C_RWLen = new TextBox();
            label12 = new Label();
            btn6C_Write = new Button();
            btn6C_Read = new Button();
            label11 = new Label();
            cb6C_MemBank = new ComboBox();
            txt6C_StartAddr = new TextBox();
            label10 = new Label();
            label9 = new Label();
            txt6C_AccessPwd = new TextBox();
            groupBox2 = new GroupBox();
            btnLogClearSerial = new Button();
            textSerialInput = new TextBox();
            btnSerialSend = new Button();
            lbSerialLog = new ListBox();
            btnLogClearStatus = new Button();
            lbStatusMessage = new ListBox();
            groupBox1.SuspendLayout();
            groupBox_TagKill.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox_TagLocking.SuspendLayout();
            groupBox10.SuspendLayout();
            gbLockPassword.SuspendLayout();
            groupBox9.SuspendLayout();
            gbLockTIDnUSER.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            gbRFInfo.SuspendLayout();
            gbVersionInfo.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            gbTagRW.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReader_COMClose);
            groupBox1.Controls.Add(btnReader_COMOpen);
            groupBox1.Controls.Add(btnRefreshComPorts);
            groupBox1.Controls.Add(cbReader_COM);
            groupBox1.Controls.Add(Label1);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 97);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Communications";
            // 
            // btnReader_COMClose
            // 
            btnReader_COMClose.Enabled = false;
            btnReader_COMClose.Location = new Point(104, 58);
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
            btnReader_COMOpen.Location = new Point(7, 58);
            btnReader_COMOpen.Margin = new Padding(4, 3, 4, 3);
            btnReader_COMOpen.Name = "btnReader_COMOpen";
            btnReader_COMOpen.Size = new Size(89, 29);
            btnReader_COMOpen.TabIndex = 5;
            btnReader_COMOpen.Text = "Open";
            btnReader_COMOpen.UseVisualStyleBackColor = true;
            btnReader_COMOpen.Click += btnReader_COMOpen_Click;
            // 
            // btnRefreshComPorts
            // 
            btnRefreshComPorts.Image = (Image)resources.GetObject("btnRefreshComPorts.Image");
            btnRefreshComPorts.Location = new Point(168, 25);
            btnRefreshComPorts.Name = "btnRefreshComPorts";
            btnRefreshComPorts.Size = new Size(25, 23);
            btnRefreshComPorts.TabIndex = 1;
            btnRefreshComPorts.UseVisualStyleBackColor = true;
            // 
            // cbReader_COM
            // 
            cbReader_COM.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_COM.FormattingEnabled = true;
            cbReader_COM.Location = new Point(77, 24);
            cbReader_COM.Margin = new Padding(4, 3, 4, 3);
            cbReader_COM.Name = "cbReader_COM";
            cbReader_COM.Size = new Size(82, 23);
            cbReader_COM.TabIndex = 3;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(6, 28);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(66, 15);
            Label1.TabIndex = 2;
            Label1.Text = "COM Port：";
            // 
            // cb6C_IKnowTagKill
            // 
            cb6C_IKnowTagKill.AutoSize = true;
            cb6C_IKnowTagKill.Location = new Point(652, 298);
            cb6C_IKnowTagKill.Name = "cb6C_IKnowTagKill";
            cb6C_IKnowTagKill.Size = new Size(144, 19);
            cb6C_IKnowTagKill.TabIndex = 5;
            cb6C_IKnowTagKill.Text = "I know what I'm doing";
            cb6C_IKnowTagKill.UseVisualStyleBackColor = true;
            cb6C_IKnowTagKill.CheckedChanged += cb6C_IKnowTagKill_CheckedChanged;
            // 
            // groupBox_TagKill
            // 
            groupBox_TagKill.Controls.Add(label16);
            groupBox_TagKill.Controls.Add(btn6C_KillTag);
            groupBox_TagKill.Controls.Add(textBox1);
            groupBox_TagKill.Controls.Add(label15);
            groupBox_TagKill.Enabled = false;
            groupBox_TagKill.Location = new Point(649, 315);
            groupBox_TagKill.Name = "groupBox_TagKill";
            groupBox_TagKill.Size = new Size(234, 77);
            groupBox_TagKill.TabIndex = 4;
            groupBox_TagKill.TabStop = false;
            groupBox_TagKill.Text = "Tag Kill";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(20, 51);
            label16.Name = "label16";
            label16.Size = new Size(35, 15);
            label16.TabIndex = 23;
            label16.Text = "(Hex)";
            // 
            // btn6C_KillTag
            // 
            btn6C_KillTag.Location = new Point(151, 22);
            btn6C_KillTag.Name = "btn6C_KillTag";
            btn6C_KillTag.Size = new Size(75, 30);
            btn6C_KillTag.TabIndex = 21;
            btn6C_KillTag.Text = "Kill";
            btn6C_KillTag.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Location = new Point(77, 26);
            textBox1.MaxLength = 8;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(68, 23);
            textBox1.TabIndex = 21;
            textBox1.Text = "00000000";
            textBox1.TextChanged += filterOnlyHex_TextChanged;
            textBox1.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(14, 21);
            label15.Name = "label15";
            label15.Size = new Size(57, 30);
            label15.TabIndex = 22;
            label15.Text = "Access\r\nPassword";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label19);
            groupBox6.Controls.Add(txtInvTID_Length);
            groupBox6.Controls.Add(label17);
            groupBox6.Controls.Add(txtInvTID_Address);
            groupBox6.Controls.Add(lvInventoryTID);
            groupBox6.Controls.Add(btnInventoryEPC);
            groupBox6.Controls.Add(btnInventoryTID);
            groupBox6.Controls.Add(lvInventoryEPC);
            groupBox6.Location = new Point(6, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(633, 479);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Inventory";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(542, 338);
            label19.Name = "label19";
            label19.Size = new Size(44, 30);
            label19.TabIndex = 25;
            label19.Text = "Length\r\n(Hex)";
            // 
            // txtInvTID_Length
            // 
            txtInvTID_Length.CharacterCasing = CharacterCasing.Upper;
            txtInvTID_Length.Location = new Point(542, 371);
            txtInvTID_Length.MaxLength = 4;
            txtInvTID_Length.Name = "txtInvTID_Length";
            txtInvTID_Length.Size = new Size(70, 23);
            txtInvTID_Length.TabIndex = 26;
            txtInvTID_Length.Text = "6";
            txtInvTID_Length.TextChanged += filterOnlyHex_TextChanged;
            txtInvTID_Length.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(542, 275);
            label17.Name = "label17";
            label17.Size = new Size(69, 30);
            label17.TabIndex = 24;
            label17.Text = "Address\r\n(Word/Hex)";
            // 
            // txtInvTID_Address
            // 
            txtInvTID_Address.CharacterCasing = CharacterCasing.Upper;
            txtInvTID_Address.Location = new Point(542, 308);
            txtInvTID_Address.MaxLength = 4;
            txtInvTID_Address.Name = "txtInvTID_Address";
            txtInvTID_Address.Size = new Size(70, 23);
            txtInvTID_Address.TabIndex = 24;
            txtInvTID_Address.Text = "0";
            txtInvTID_Address.TextChanged += filterOnlyHex_TextChanged;
            txtInvTID_Address.KeyPress += filterOnlyHex_KeyPress;
            // 
            // lvInventoryTID
            // 
            lvInventoryTID.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3, columnHeader4, columnHeader5 });
            lvInventoryTID.FullRowSelect = true;
            lvInventoryTID.GridLines = true;
            lvInventoryTID.Location = new Point(6, 249);
            lvInventoryTID.MultiSelect = false;
            lvInventoryTID.Name = "lvInventoryTID";
            lvInventoryTID.Size = new Size(519, 221);
            lvInventoryTID.TabIndex = 23;
            lvInventoryTID.UseCompatibleStateImageBehavior = false;
            lvInventoryTID.View = View.Details;
            lvInventoryTID.DoubleClick += lvInventoryTID_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "No.";
            columnHeader1.Width = 40;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "TID";
            columnHeader3.Width = 230;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Length";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Count";
            columnHeader5.Width = 80;
            // 
            // btnInventoryEPC
            // 
            btnInventoryEPC.Location = new Point(531, 211);
            btnInventoryEPC.Name = "btnInventoryEPC";
            btnInventoryEPC.Size = new Size(100, 32);
            btnInventoryEPC.TabIndex = 24;
            btnInventoryEPC.Text = "Inventory EPC";
            btnInventoryEPC.UseVisualStyleBackColor = true;
            btnInventoryEPC.Click += btnInventoryEPC_Click;
            // 
            // btnInventoryTID
            // 
            btnInventoryTID.Location = new Point(531, 438);
            btnInventoryTID.Name = "btnInventoryTID";
            btnInventoryTID.Size = new Size(100, 32);
            btnInventoryTID.TabIndex = 1;
            btnInventoryTID.Text = "Inventory TID";
            btnInventoryTID.UseVisualStyleBackColor = true;
            btnInventoryTID.Click += btnInventoryTID_Click;
            // 
            // lvInventoryEPC
            // 
            lvInventoryEPC.Columns.AddRange(new ColumnHeader[] { lvInvCol_Number, lvInvCol_PC, lvInvCol_EPC, lvInvCol_Len, lvInvCol_Count });
            lvInventoryEPC.FullRowSelect = true;
            lvInventoryEPC.GridLines = true;
            lvInventoryEPC.Location = new Point(6, 22);
            lvInventoryEPC.MultiSelect = false;
            lvInventoryEPC.Name = "lvInventoryEPC";
            lvInventoryEPC.Size = new Size(519, 221);
            lvInventoryEPC.TabIndex = 0;
            lvInventoryEPC.UseCompatibleStateImageBehavior = false;
            lvInventoryEPC.View = View.Details;
            lvInventoryEPC.DoubleClick += lvInventoryEPC_DoubleClick;
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
            // cb6C_IKnowTagLock
            // 
            cb6C_IKnowTagLock.AutoSize = true;
            cb6C_IKnowTagLock.Location = new Point(654, 5);
            cb6C_IKnowTagLock.Name = "cb6C_IKnowTagLock";
            cb6C_IKnowTagLock.Size = new Size(144, 19);
            cb6C_IKnowTagLock.TabIndex = 8;
            cb6C_IKnowTagLock.Text = "I know what I'm doing";
            cb6C_IKnowTagLock.UseVisualStyleBackColor = true;
            cb6C_IKnowTagLock.CheckedChanged += cb6C_IKnowTagLock_CheckedChanged;
            // 
            // groupBox_TagLocking
            // 
            groupBox_TagLocking.Controls.Add(btnSetProtectState);
            groupBox_TagLocking.Controls.Add(groupBox10);
            groupBox_TagLocking.Controls.Add(textBox2);
            groupBox_TagLocking.Controls.Add(label22);
            groupBox_TagLocking.Controls.Add(gbLockPassword);
            groupBox_TagLocking.Controls.Add(gbLockTIDnUSER);
            groupBox_TagLocking.Enabled = false;
            groupBox_TagLocking.Location = new Point(645, 24);
            groupBox_TagLocking.Name = "groupBox_TagLocking";
            groupBox_TagLocking.Size = new Size(565, 270);
            groupBox_TagLocking.TabIndex = 7;
            groupBox_TagLocking.TabStop = false;
            groupBox_TagLocking.Text = "Tag Locking";
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
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(P_User);
            groupBox10.Controls.Add(P_TID);
            groupBox10.Controls.Add(P_EPC);
            groupBox10.Controls.Add(P_Reserve);
            groupBox10.Location = new Point(7, 14);
            groupBox10.Margin = new Padding(4, 3, 4, 3);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(4, 3, 4, 3);
            groupBox10.Size = new Size(251, 39);
            groupBox10.TabIndex = 11;
            groupBox10.TabStop = false;
            // 
            // P_User
            // 
            P_User.AutoSize = true;
            P_User.Location = new Point(190, 14);
            P_User.Margin = new Padding(4, 3, 4, 3);
            P_User.Name = "P_User";
            P_User.Size = new Size(48, 19);
            P_User.TabIndex = 3;
            P_User.Text = "User";
            P_User.UseVisualStyleBackColor = true;
            P_User.CheckedChanged += P_EPC_TID_USER_CheckedChanged;
            // 
            // P_TID
            // 
            P_TID.AutoSize = true;
            P_TID.Location = new Point(140, 14);
            P_TID.Margin = new Padding(4, 3, 4, 3);
            P_TID.Name = "P_TID";
            P_TID.Size = new Size(43, 19);
            P_TID.TabIndex = 2;
            P_TID.Text = "TID";
            P_TID.UseVisualStyleBackColor = true;
            P_TID.CheckedChanged += P_EPC_TID_USER_CheckedChanged;
            // 
            // P_EPC
            // 
            P_EPC.AutoSize = true;
            P_EPC.Checked = true;
            P_EPC.Location = new Point(86, 14);
            P_EPC.Margin = new Padding(4, 3, 4, 3);
            P_EPC.Name = "P_EPC";
            P_EPC.Size = new Size(46, 19);
            P_EPC.TabIndex = 1;
            P_EPC.TabStop = true;
            P_EPC.Text = "EPC";
            P_EPC.UseVisualStyleBackColor = true;
            P_EPC.CheckedChanged += P_EPC_TID_USER_CheckedChanged;
            // 
            // P_Reserve
            // 
            P_Reserve.AutoSize = true;
            P_Reserve.Location = new Point(6, 14);
            P_Reserve.Margin = new Padding(4, 3, 4, 3);
            P_Reserve.Name = "P_Reserve";
            P_Reserve.Size = new Size(78, 19);
            P_Reserve.TabIndex = 0;
            P_Reserve.Text = "RESERVED";
            P_Reserve.UseVisualStyleBackColor = true;
            P_Reserve.CheckedChanged += P_Reserve_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(304, 235);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.MaxLength = 8;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 23);
            textBox2.TabIndex = 14;
            textBox2.Text = "00000000";
            textBox2.TextChanged += filterOnlyHex_TextChanged;
            textBox2.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(301, 214);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(139, 15);
            label22.TabIndex = 13;
            label22.Text = "Access Password (8 Hex):";
            // 
            // gbLockPassword
            // 
            gbLockPassword.Controls.Add(AlwaysNot);
            gbLockPassword.Controls.Add(Always);
            gbLockPassword.Controls.Add(Proect);
            gbLockPassword.Controls.Add(NoProect);
            gbLockPassword.Controls.Add(groupBox9);
            gbLockPassword.Enabled = false;
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
            AlwaysNot.Location = new Point(8, 161);
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
            Always.Location = new Point(8, 127);
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
            Proect.Location = new Point(8, 95);
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
            NoProect.Location = new Point(8, 60);
            NoProect.Margin = new Padding(4, 3, 4, 3);
            NoProect.Name = "NoProect";
            NoProect.Size = new Size(229, 19);
            NoProect.TabIndex = 1;
            NoProect.TabStop = true;
            NoProect.Text = "Readable and  writeable from any state";
            NoProect.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(AccessCode);
            groupBox9.Controls.Add(DestroyCode);
            groupBox9.Location = new Point(6, 15);
            groupBox9.Margin = new Padding(4, 3, 4, 3);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(4, 3, 4, 3);
            groupBox9.Size = new Size(276, 39);
            groupBox9.TabIndex = 0;
            groupBox9.TabStop = false;
            // 
            // AccessCode
            // 
            AccessCode.AutoSize = true;
            AccessCode.Location = new Point(127, 15);
            AccessCode.Margin = new Padding(4, 3, 4, 3);
            AccessCode.Name = "AccessCode";
            AccessCode.Size = new Size(114, 19);
            AccessCode.TabIndex = 1;
            AccessCode.Text = "Access Password";
            AccessCode.UseVisualStyleBackColor = true;
            // 
            // DestroyCode
            // 
            DestroyCode.AutoSize = true;
            DestroyCode.Checked = true;
            DestroyCode.Location = new Point(8, 15);
            DestroyCode.Margin = new Padding(4, 3, 4, 3);
            DestroyCode.Name = "DestroyCode";
            DestroyCode.Size = new Size(94, 19);
            DestroyCode.TabIndex = 0;
            DestroyCode.TabStop = true;
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
            AlwaysNot2.Location = new Point(7, 121);
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
            Always2.Location = new Point(7, 89);
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
            Proect2.Location = new Point(7, 57);
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
            NoProect2.Location = new Point(7, 24);
            NoProect2.Margin = new Padding(4, 3, 4, 3);
            NoProect2.Name = "NoProect2";
            NoProect2.Size = new Size(154, 19);
            NoProect2.TabIndex = 0;
            NoProect2.TabStop = true;
            NoProect2.Text = "Writeable from any state";
            NoProect2.UseVisualStyleBackColor = true;
            // 
            // timer_InventoryEPC
            // 
            timer_InventoryEPC.Tick += timer_InventoryEPC_Tick;
            // 
            // timer_InventoryTID
            // 
            timer_InventoryTID.Tick += timer_InventoryTID_Tick;
            // 
            // btnGetVersion
            // 
            btnGetVersion.Location = new Point(177, 48);
            btnGetVersion.Name = "btnGetVersion";
            btnGetVersion.Size = new Size(102, 28);
            btnGetVersion.TabIndex = 29;
            btnGetVersion.Text = "Get Version";
            btnGetVersion.UseVisualStyleBackColor = true;
            btnGetVersion.Click += btnGetVersion_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 24);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 30;
            label2.Text = "SW Ver：";
            // 
            // textSWVer
            // 
            textSWVer.Location = new Point(63, 19);
            textSWVer.Name = "textSWVer";
            textSWVer.ReadOnly = true;
            textSWVer.Size = new Size(68, 23);
            textSWVer.TabIndex = 31;
            // 
            // textHWVer
            // 
            textHWVer.Location = new Point(200, 19);
            textHWVer.Name = "textHWVer";
            textHWVer.ReadOnly = true;
            textHWVer.Size = new Size(68, 23);
            textHWVer.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 24);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 33;
            label3.Text = "HW Ver：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 53);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 34;
            label4.Text = "Reader ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 30);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 35;
            label5.Text = "RF Band：";
            // 
            // textReaderID
            // 
            textReaderID.Location = new Point(74, 49);
            textReaderID.Name = "textReaderID";
            textReaderID.ReadOnly = true;
            textReaderID.Size = new Size(97, 23);
            textReaderID.TabIndex = 36;
            // 
            // cbRFBand
            // 
            cbRFBand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRFBand.FormattingEnabled = true;
            cbRFBand.Items.AddRange(new object[] { "Unknown Value", "01: US 902MHz-928MHz", "02: TW 922MHz-928MHz", "03: CN1 920MHz-925MHz", "04: CN2 840MHz-845MHz", "05: CE 865MHz-868MHz" });
            cbRFBand.Location = new Point(82, 27);
            cbRFBand.Name = "cbRFBand";
            cbRFBand.Size = new Size(151, 23);
            cbRFBand.TabIndex = 39;
            cbRFBand.SelectedIndexChanged += cbRFBand_SelectedIndexChanged;
            // 
            // btnSaveRFBand
            // 
            btnSaveRFBand.Image = (Image)resources.GetObject("btnSaveRFBand.Image");
            btnSaveRFBand.Location = new Point(239, 26);
            btnSaveRFBand.Margin = new Padding(4, 3, 4, 3);
            btnSaveRFBand.Name = "btnSaveRFBand";
            btnSaveRFBand.Size = new Size(24, 24);
            btnSaveRFBand.TabIndex = 58;
            btnSaveRFBand.UseVisualStyleBackColor = true;
            btnSaveRFBand.Click += btnSaveRFBand_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1256, 755);
            tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(gbRFInfo);
            tabPage1.Controls.Add(gbVersionInfo);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1248, 727);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Reader Parameter";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbRFInfo
            // 
            gbRFInfo.Controls.Add(btnRFFreqSave);
            gbRFInfo.Controls.Add(btnGetPowerLevel);
            gbRFInfo.Controls.Add(btnSavePowerLevel);
            gbRFInfo.Controls.Add(cbPowerLevel);
            gbRFInfo.Controls.Add(label18);
            gbRFInfo.Controls.Add(lbFreqOffset);
            gbRFInfo.Controls.Add(label14);
            gbRFInfo.Controls.Add(rbBBM_RX);
            gbRFInfo.Controls.Add(rbBBM_Carry);
            gbRFInfo.Controls.Add(label8);
            gbRFInfo.Controls.Add(cbFreqSel);
            gbRFInfo.Controls.Add(label7);
            gbRFInfo.Controls.Add(btnRFFreqRefresh);
            gbRFInfo.Controls.Add(label5);
            gbRFInfo.Controls.Add(cbRFBand);
            gbRFInfo.Controls.Add(btnSaveRFBand);
            gbRFInfo.Location = new Point(505, 13);
            gbRFInfo.Name = "gbRFInfo";
            gbRFInfo.Size = new Size(269, 157);
            gbRFInfo.TabIndex = 60;
            gbRFInfo.TabStop = false;
            gbRFInfo.Text = "RF Information";
            // 
            // btnRFFreqSave
            // 
            btnRFFreqSave.Image = (Image)resources.GetObject("btnRFFreqSave.Image");
            btnRFFreqSave.Location = new Point(223, 77);
            btnRFFreqSave.Margin = new Padding(4, 3, 4, 3);
            btnRFFreqSave.Name = "btnRFFreqSave";
            btnRFFreqSave.Size = new Size(24, 24);
            btnRFFreqSave.TabIndex = 71;
            btnRFFreqSave.UseVisualStyleBackColor = true;
            btnRFFreqSave.Click += btnRFFreqSave_Click;
            // 
            // btnGetPowerLevel
            // 
            btnGetPowerLevel.Image = (Image)resources.GetObject("btnGetPowerLevel.Image");
            btnGetPowerLevel.Location = new Point(197, 123);
            btnGetPowerLevel.Margin = new Padding(4, 3, 4, 3);
            btnGetPowerLevel.Name = "btnGetPowerLevel";
            btnGetPowerLevel.Size = new Size(24, 24);
            btnGetPowerLevel.TabIndex = 70;
            btnGetPowerLevel.UseVisualStyleBackColor = true;
            btnGetPowerLevel.Click += btnGetPowerLevel_Click;
            // 
            // btnSavePowerLevel
            // 
            btnSavePowerLevel.Image = (Image)resources.GetObject("btnSavePowerLevel.Image");
            btnSavePowerLevel.Location = new Point(223, 123);
            btnSavePowerLevel.Margin = new Padding(4, 3, 4, 3);
            btnSavePowerLevel.Name = "btnSavePowerLevel";
            btnSavePowerLevel.Size = new Size(24, 24);
            btnSavePowerLevel.TabIndex = 69;
            btnSavePowerLevel.UseVisualStyleBackColor = true;
            btnSavePowerLevel.Click += btnSavePowerLevel_Click;
            // 
            // cbPowerLevel
            // 
            cbPowerLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPowerLevel.FormattingEnabled = true;
            cbPowerLevel.Location = new Point(82, 124);
            cbPowerLevel.Name = "cbPowerLevel";
            cbPowerLevel.Size = new Size(109, 23);
            cbPowerLevel.TabIndex = 68;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(29, 128);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(46, 15);
            label18.TabIndex = 67;
            label18.Text = "Power：";
            // 
            // lbFreqOffset
            // 
            lbFreqOffset.AutoSize = true;
            lbFreqOffset.Location = new Point(82, 104);
            lbFreqOffset.Margin = new Padding(4, 0, 4, 0);
            lbFreqOffset.Name = "lbFreqOffset";
            lbFreqOffset.Size = new Size(35, 15);
            lbFreqOffset.TabIndex = 66;
            lbFreqOffset.Text = "+0Hz";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(4, 104);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(71, 15);
            label14.TabIndex = 65;
            label14.Text = "Freq Offset：";
            // 
            // rbBBM_RX
            // 
            rbBBM_RX.AutoSize = true;
            rbBBM_RX.Location = new Point(168, 56);
            rbBBM_RX.Name = "rbBBM_RX";
            rbBBM_RX.Size = new Size(39, 19);
            rbBBM_RX.TabIndex = 64;
            rbBBM_RX.TabStop = true;
            rbBBM_RX.Text = "RX";
            rbBBM_RX.UseVisualStyleBackColor = true;
            // 
            // rbBBM_Carry
            // 
            rbBBM_Carry.AutoSize = true;
            rbBBM_Carry.Location = new Point(109, 56);
            rbBBM_Carry.Name = "rbBBM_Carry";
            rbBBM_Carry.Size = new Size(53, 19);
            rbBBM_Carry.TabIndex = 63;
            rbBBM_Carry.TabStop = true;
            rbBBM_Carry.Text = "Carry";
            rbBBM_Carry.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 58);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(98, 15);
            label8.TabIndex = 62;
            label8.Text = "Baseband Mode：";
            // 
            // cbFreqSel
            // 
            cbFreqSel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFreqSel.FormattingEnabled = true;
            cbFreqSel.Location = new Point(82, 77);
            cbFreqSel.Name = "cbFreqSel";
            cbFreqSel.Size = new Size(109, 23);
            cbFreqSel.TabIndex = 61;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 81);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 60;
            label7.Text = "Frequency：";
            // 
            // btnRFFreqRefresh
            // 
            btnRFFreqRefresh.Image = (Image)resources.GetObject("btnRFFreqRefresh.Image");
            btnRFFreqRefresh.Location = new Point(197, 77);
            btnRFFreqRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRFFreqRefresh.Name = "btnRFFreqRefresh";
            btnRFFreqRefresh.Size = new Size(24, 24);
            btnRFFreqRefresh.TabIndex = 59;
            btnRFFreqRefresh.UseVisualStyleBackColor = true;
            btnRFFreqRefresh.Click += btnRFFreqRefresh_Click;
            // 
            // gbVersionInfo
            // 
            gbVersionInfo.Controls.Add(label2);
            gbVersionInfo.Controls.Add(label3);
            gbVersionInfo.Controls.Add(label4);
            gbVersionInfo.Controls.Add(textHWVer);
            gbVersionInfo.Controls.Add(btnGetVersion);
            gbVersionInfo.Controls.Add(textSWVer);
            gbVersionInfo.Controls.Add(textReaderID);
            gbVersionInfo.Location = new Point(212, 12);
            gbVersionInfo.Name = "gbVersionInfo";
            gbVersionInfo.Size = new Size(287, 97);
            gbVersionInfo.TabIndex = 59;
            gbVersionInfo.TabStop = false;
            gbVersionInfo.Text = "Version Information";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(gbTagRW);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(cb6C_IKnowTagKill);
            tabPage2.Controls.Add(groupBox_TagKill);
            tabPage2.Controls.Add(groupBox6);
            tabPage2.Controls.Add(cb6C_IKnowTagLock);
            tabPage2.Controls.Add(groupBox_TagLocking);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1248, 727);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "EPC C1-G2 / 6C";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(textBox5);
            groupBox3.Controls.Add(label24);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Location = new Point(6, 491);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(631, 81);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(5, -1);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(214, 19);
            checkBox1.TabIndex = 30;
            checkBox1.Text = "Enable Set Select for Pre-Command";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            textBox5.CharacterCasing = CharacterCasing.Upper;
            textBox5.Location = new Point(95, 52);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(530, 23);
            textBox5.TabIndex = 25;
            textBox5.TextChanged += filterOnlyHex_TextChanged;
            textBox5.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(12, 55);
            label24.Name = "label24";
            label24.Size = new Size(62, 15);
            label24.TabIndex = 24;
            label24.Text = "Data (Hex)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(552, 24);
            textBox3.MaxLength = 4;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(70, 23);
            textBox3.TabIndex = 29;
            textBox3.Text = "4";
            textBox3.TextChanged += filterOnlyHex_TextChanged;
            textBox3.KeyPress += filterOnlyHex_KeyPress;
            // 
            // textBox4
            // 
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox4.Location = new Point(351, 24);
            textBox4.MaxLength = 4;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(70, 23);
            textBox4.TabIndex = 25;
            textBox4.Text = "1";
            textBox4.TextChanged += filterOnlyHex_TextChanged;
            textBox4.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(428, 17);
            label20.Name = "label20";
            label20.Size = new Size(110, 30);
            label20.TabIndex = 28;
            label20.Text = "Length (Bits in Hex)\r\n(0-0x60)";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(228, 17);
            label23.Name = "label23";
            label23.Size = new Size(115, 30);
            label23.TabIndex = 24;
            label23.Text = "Address (Bits in Hex)\r\n(0-0x3FFF)";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(10, 27);
            label21.Name = "label21";
            label21.Size = new Size(81, 15);
            label21.TabIndex = 27;
            label21.Text = "Memory Bank";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "RESERVED", "EPC", "TID", "USER" });
            comboBox1.Location = new Point(95, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 26;
            // 
            // gbTagRW
            // 
            gbTagRW.Controls.Add(txtReader_ReadData);
            gbTagRW.Controls.Add(label6);
            gbTagRW.Controls.Add(txtReader_WriteData);
            gbTagRW.Controls.Add(label13);
            gbTagRW.Controls.Add(txt6C_RWLen);
            gbTagRW.Controls.Add(label12);
            gbTagRW.Controls.Add(btn6C_Write);
            gbTagRW.Controls.Add(btn6C_Read);
            gbTagRW.Controls.Add(label11);
            gbTagRW.Controls.Add(cb6C_MemBank);
            gbTagRW.Controls.Add(txt6C_StartAddr);
            gbTagRW.Controls.Add(label10);
            gbTagRW.Controls.Add(label9);
            gbTagRW.Controls.Add(txt6C_AccessPwd);
            gbTagRW.Location = new Point(6, 578);
            gbTagRW.Name = "gbTagRW";
            gbTagRW.Size = new Size(633, 144);
            gbTagRW.TabIndex = 11;
            gbTagRW.TabStop = false;
            gbTagRW.Text = "Tag Read/Write";
            // 
            // txtReader_ReadData
            // 
            txtReader_ReadData.CharacterCasing = CharacterCasing.Upper;
            txtReader_ReadData.Location = new Point(76, 78);
            txtReader_ReadData.Name = "txtReader_ReadData";
            txtReader_ReadData.Size = new Size(470, 23);
            txtReader_ReadData.TabIndex = 23;
            txtReader_ReadData.TextChanged += filterOnlyHex_TextChanged;
            txtReader_ReadData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 81);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 22;
            label6.Text = "Read (Hex)";
            // 
            // txtReader_WriteData
            // 
            txtReader_WriteData.CharacterCasing = CharacterCasing.Upper;
            txtReader_WriteData.Location = new Point(76, 109);
            txtReader_WriteData.Name = "txtReader_WriteData";
            txtReader_WriteData.Size = new Size(470, 23);
            txtReader_WriteData.TabIndex = 20;
            txtReader_WriteData.TextChanged += filterOnlyHex_TextChanged;
            txtReader_WriteData.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(8, 112);
            label13.Name = "label13";
            label13.Size = new Size(66, 15);
            label13.TabIndex = 19;
            label13.Text = "Write (Hex)";
            // 
            // txt6C_RWLen
            // 
            txt6C_RWLen.Location = new Point(371, 48);
            txt6C_RWLen.MaxLength = 4;
            txt6C_RWLen.Name = "txt6C_RWLen";
            txt6C_RWLen.Size = new Size(70, 23);
            txt6C_RWLen.TabIndex = 18;
            txt6C_RWLen.Text = "4";
            txt6C_RWLen.TextChanged += filterOnlyHex_TextChanged;
            txt6C_RWLen.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(231, 51);
            label12.Name = "label12";
            label12.Size = new Size(101, 15);
            label12.TabIndex = 17;
            label12.Text = "R/W Length (Hex)";
            // 
            // btn6C_Write
            // 
            btn6C_Write.Location = new Point(552, 109);
            btn6C_Write.Name = "btn6C_Write";
            btn6C_Write.Size = new Size(75, 23);
            btn6C_Write.TabIndex = 15;
            btn6C_Write.Text = "Write";
            btn6C_Write.UseVisualStyleBackColor = true;
            btn6C_Write.Click += btn6C_Write_Click;
            // 
            // btn6C_Read
            // 
            btn6C_Read.Location = new Point(552, 78);
            btn6C_Read.Name = "btn6C_Read";
            btn6C_Read.Size = new Size(75, 22);
            btn6C_Read.TabIndex = 14;
            btn6C_Read.Text = "Read";
            btn6C_Read.UseVisualStyleBackColor = true;
            btn6C_Read.Click += btn6C_Read_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 23);
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
            cb6C_MemBank.Location = new Point(95, 19);
            cb6C_MemBank.Name = "cb6C_MemBank";
            cb6C_MemBank.Size = new Size(121, 23);
            cb6C_MemBank.TabIndex = 12;
            // 
            // txt6C_StartAddr
            // 
            txt6C_StartAddr.CharacterCasing = CharacterCasing.Upper;
            txt6C_StartAddr.Location = new Point(155, 48);
            txt6C_StartAddr.MaxLength = 4;
            txt6C_StartAddr.Name = "txt6C_StartAddr";
            txt6C_StartAddr.Size = new Size(70, 23);
            txt6C_StartAddr.TabIndex = 11;
            txt6C_StartAddr.Text = "1";
            txt6C_StartAddr.TextChanged += filterOnlyHex_TextChanged;
            txt6C_StartAddr.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 51);
            label10.Name = "label10";
            label10.Size = new Size(141, 15);
            label10.TabIndex = 10;
            label10.Text = "Start Address (Word/Hex)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(228, 22);
            label9.Name = "label9";
            label9.Size = new Size(127, 15);
            label9.TabIndex = 8;
            label9.Text = "Access Password (Hex)";
            // 
            // txt6C_AccessPwd
            // 
            txt6C_AccessPwd.CharacterCasing = CharacterCasing.Upper;
            txt6C_AccessPwd.Location = new Point(364, 19);
            txt6C_AccessPwd.MaxLength = 8;
            txt6C_AccessPwd.Name = "txt6C_AccessPwd";
            txt6C_AccessPwd.Size = new Size(70, 23);
            txt6C_AccessPwd.TabIndex = 7;
            txt6C_AccessPwd.Text = "00000000";
            txt6C_AccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txt6C_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLogClearSerial);
            groupBox2.Controls.Add(textSerialInput);
            groupBox2.Controls.Add(btnSerialSend);
            groupBox2.Controls.Add(lbSerialLog);
            groupBox2.Location = new Point(645, 396);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(600, 328);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Serial Log";
            // 
            // btnLogClearSerial
            // 
            btnLogClearSerial.Location = new Point(7, 299);
            btnLogClearSerial.Name = "btnLogClearSerial";
            btnLogClearSerial.Size = new Size(75, 23);
            btnLogClearSerial.TabIndex = 12;
            btnLogClearSerial.Text = "Clear";
            btnLogClearSerial.UseVisualStyleBackColor = true;
            btnLogClearSerial.Click += btnLogClearSerial_Click_1;
            // 
            // textSerialInput
            // 
            textSerialInput.Location = new Point(355, 300);
            textSerialInput.Name = "textSerialInput";
            textSerialInput.Size = new Size(157, 23);
            textSerialInput.TabIndex = 11;
            // 
            // btnSerialSend
            // 
            btnSerialSend.Location = new Point(519, 299);
            btnSerialSend.Name = "btnSerialSend";
            btnSerialSend.Size = new Size(75, 23);
            btnSerialSend.TabIndex = 10;
            btnSerialSend.Text = "Send";
            btnSerialSend.UseVisualStyleBackColor = true;
            btnSerialSend.Click += btnSerialSend_Click;
            // 
            // lbSerialLog
            // 
            lbSerialLog.FormattingEnabled = true;
            lbSerialLog.ItemHeight = 15;
            lbSerialLog.Location = new Point(6, 21);
            lbSerialLog.Name = "lbSerialLog";
            lbSerialLog.Size = new Size(588, 274);
            lbSerialLog.TabIndex = 3;
            // 
            // btnLogClearStatus
            // 
            btnLogClearStatus.Location = new Point(582, 845);
            btnLogClearStatus.Name = "btnLogClearStatus";
            btnLogClearStatus.Size = new Size(75, 23);
            btnLogClearStatus.TabIndex = 12;
            btnLogClearStatus.Text = "Clear";
            btnLogClearStatus.UseVisualStyleBackColor = true;
            btnLogClearStatus.Click += btnLogClearStatus_Click;
            // 
            // lbStatusMessage
            // 
            lbStatusMessage.FormattingEnabled = true;
            lbStatusMessage.ItemHeight = 15;
            lbStatusMessage.Location = new Point(6, 759);
            lbStatusMessage.Name = "lbStatusMessage";
            lbStatusMessage.Size = new Size(570, 109);
            lbStatusMessage.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 874);
            Controls.Add(lbStatusMessage);
            Controls.Add(btnLogClearStatus);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "FM-5XX";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox_TagKill.ResumeLayout(false);
            groupBox_TagKill.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox_TagLocking.ResumeLayout(false);
            groupBox_TagLocking.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            gbLockPassword.ResumeLayout(false);
            gbLockPassword.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            gbLockTIDnUSER.ResumeLayout(false);
            gbLockTIDnUSER.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            gbRFInfo.ResumeLayout(false);
            gbRFInfo.PerformLayout();
            gbVersionInfo.ResumeLayout(false);
            gbVersionInfo.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbTagRW.ResumeLayout(false);
            gbTagRW.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        internal Button btnReader_COMClose;
        internal Button btnReader_COMOpen;
        private Button btnRefreshComPorts;
        internal ComboBox cbReader_COM;
        internal Label Label1;
        private CheckBox cb6C_IKnowTagKill;
        private GroupBox groupBox_TagKill;
        private Label label16;
        private Button btn6C_KillTag;
        private TextBox textBox1;
        private Label label15;
        private GroupBox groupBox6;
        private Button btnInventoryEPC;
        private ListView lvInventoryTID;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnInventoryTID;
        private ListView lvInventoryEPC;
        private ColumnHeader lvInvCol_Number;
        private ColumnHeader lvInvCol_PC;
        private ColumnHeader lvInvCol_EPC;
        private ColumnHeader lvInvCol_Len;
        private ColumnHeader lvInvCol_Count;
        private CheckBox cb6C_IKnowTagLock;
        private GroupBox groupBox_TagLocking;
        private System.Windows.Forms.Timer timer_InventoryEPC;
        private System.Windows.Forms.Timer timer_InventoryTID;
        private Button btnGetVersion;
        internal Label label2;
        private TextBox textSWVer;
        private TextBox textHWVer;
        internal Label label3;
        internal Label label4;
        internal Label label5;
        private TextBox textReaderID;
        private ComboBox cbRFBand;
        internal Button btnSaveRFBand;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox gbVersionInfo;
        private Button btnSetProtectState;
        private GroupBox groupBox10;
        private RadioButton P_User;
        private RadioButton P_TID;
        private RadioButton P_EPC;
        private RadioButton P_Reserve;
        private TextBox textBox2;
        private Label label22;
        private GroupBox gbLockPassword;
        private RadioButton AlwaysNot;
        private RadioButton Always;
        private RadioButton Proect;
        private RadioButton NoProect;
        private GroupBox groupBox9;
        private RadioButton AccessCode;
        private RadioButton DestroyCode;
        private GroupBox gbLockTIDnUSER;
        private RadioButton AlwaysNot2;
        private RadioButton Always2;
        private RadioButton Proect2;
        private RadioButton NoProect2;
        private GroupBox groupBox2;
        private TextBox textSerialInput;
        private Button btnSerialSend;
        private ListBox lbSerialLog;
        private GroupBox gbTagRW;
        private TextBox txtReader_WriteData;
        private Label label13;
        private TextBox txt6C_RWLen;
        private Label label12;
        private Button btn6C_Write;
        private Button btn6C_Read;
        private Label label11;
        private ComboBox cb6C_MemBank;
        private TextBox txt6C_StartAddr;
        private Label label10;
        private Label label9;
        private TextBox txt6C_AccessPwd;
        private TextBox txtReader_ReadData;
        private Label label6;
        private GroupBox gbRFInfo;
        internal Button btnRFFreqRefresh;
        private ComboBox cbFreqSel;
        internal Label label7;
        private RadioButton rbBBM_RX;
        private RadioButton rbBBM_Carry;
        internal Label label8;
        private ComboBox cbPowerLevel;
        internal Label label18;
        internal Label lbFreqOffset;
        internal Label label14;
        internal Button btnGetPowerLevel;
        internal Button btnSavePowerLevel;
        private Button btnLogClearSerial;
        private Button btnLogClearStatus;
        private ListBox lbStatusMessage;
        internal Button btnRFFreqSave;
        private Label label19;
        private TextBox txtInvTID_Length;
        private Label label17;
        private TextBox txtInvTID_Address;
        private GroupBox groupBox3;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label20;
        private Label label23;
        private Label label21;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private TextBox textBox5;
        private Label label24;
    }
}