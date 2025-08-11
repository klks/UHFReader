namespace ES_F3105U
{ 
    partial class Form_EPCC1G26C
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
            components = new System.ComponentModel.Container();
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
            timer6C_PollRead = new System.Windows.Forms.Timer(components);
            timerInventory = new System.Windows.Forms.Timer(components);
            groupBox_TagLocking.SuspendLayout();
            groupBox12.SuspendLayout();
            gbLockPassword.SuspendLayout();
            groupBox13.SuspendLayout();
            gbLockTIDnUSER.SuspendLayout();
            groupBox_TagKill.SuspendLayout();
            gbTagRW.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
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
            groupBox_TagLocking.Location = new Point(392, 317);
            groupBox_TagLocking.Name = "groupBox_TagLocking";
            groupBox_TagLocking.Size = new Size(565, 208);
            groupBox_TagLocking.TabIndex = 33;
            groupBox_TagLocking.TabStop = false;
            groupBox_TagLocking.Text = "Tag Locking";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(262, 24);
            label30.Name = "label30";
            label30.Size = new Size(50, 15);
            label30.TabIndex = 17;
            label30.Text = "Tag EPC";
            // 
            // txt6C_LockEPCTag
            // 
            txt6C_LockEPCTag.Location = new Point(317, 20);
            txt6C_LockEPCTag.Name = "txt6C_LockEPCTag";
            txt6C_LockEPCTag.ReadOnly = true;
            txt6C_LockEPCTag.Size = new Size(240, 23);
            txt6C_LockEPCTag.TabIndex = 16;
            // 
            // btnSetProtectState
            // 
            btnSetProtectState.Location = new Point(442, 173);
            btnSetProtectState.Margin = new Padding(4, 3, 4, 3);
            btnSetProtectState.Name = "btnSetProtectState";
            btnSetProtectState.Size = new Size(115, 29);
            btnSetProtectState.TabIndex = 15;
            btnSetProtectState.Text = "Set Protect";
            btnSetProtectState.UseVisualStyleBackColor = true;
            btnSetProtectState.Click += btnSetProtectState_Click;
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
            P_User.Location = new Point(192, 14);
            P_User.Margin = new Padding(4, 3, 4, 3);
            P_User.Name = "P_User";
            P_User.Size = new Size(48, 19);
            P_User.TabIndex = 3;
            P_User.Text = "User";
            P_User.UseVisualStyleBackColor = true;
            P_User.CheckedChanged += P_TagLock_CheckedChanged;
            // 
            // P_TID
            // 
            P_TID.AutoSize = true;
            P_TID.Location = new Point(142, 14);
            P_TID.Margin = new Padding(4, 3, 4, 3);
            P_TID.Name = "P_TID";
            P_TID.Size = new Size(43, 19);
            P_TID.TabIndex = 2;
            P_TID.Text = "TID";
            P_TID.UseVisualStyleBackColor = true;
            P_TID.CheckedChanged += P_TagLock_CheckedChanged;
            // 
            // P_EPC
            // 
            P_EPC.AutoSize = true;
            P_EPC.Checked = true;
            P_EPC.Location = new Point(88, 14);
            P_EPC.Margin = new Padding(4, 3, 4, 3);
            P_EPC.Name = "P_EPC";
            P_EPC.Size = new Size(46, 19);
            P_EPC.TabIndex = 1;
            P_EPC.TabStop = true;
            P_EPC.Text = "EPC";
            P_EPC.UseVisualStyleBackColor = true;
            P_EPC.CheckedChanged += P_TagLock_CheckedChanged;
            // 
            // P_Reserve
            // 
            P_Reserve.AutoSize = true;
            P_Reserve.Location = new Point(8, 14);
            P_Reserve.Margin = new Padding(4, 3, 4, 3);
            P_Reserve.Name = "P_Reserve";
            P_Reserve.Size = new Size(78, 19);
            P_Reserve.TabIndex = 0;
            P_Reserve.Text = "RESERVED";
            P_Reserve.UseVisualStyleBackColor = true;
            P_Reserve.CheckedChanged += P_Reserve_CheckedChanged;
            // 
            // txt6C_LockEPCAccessPwd
            // 
            txt6C_LockEPCAccessPwd.Location = new Point(304, 178);
            txt6C_LockEPCAccessPwd.Margin = new Padding(4, 3, 4, 3);
            txt6C_LockEPCAccessPwd.MaxLength = 8;
            txt6C_LockEPCAccessPwd.Name = "txt6C_LockEPCAccessPwd";
            txt6C_LockEPCAccessPwd.Size = new Size(130, 23);
            txt6C_LockEPCAccessPwd.TabIndex = 14;
            txt6C_LockEPCAccessPwd.Text = "00000000";
            txt6C_LockEPCAccessPwd.TextChanged += filterOnlyHex_TextChanged;
            txt6C_LockEPCAccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(301, 158);
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
            gbLockPassword.Enabled = false;
            gbLockPassword.Location = new Point(7, 59);
            gbLockPassword.Margin = new Padding(4, 3, 4, 3);
            gbLockPassword.Name = "gbLockPassword";
            gbLockPassword.Padding = new Padding(4, 3, 4, 3);
            gbLockPassword.Size = new Size(289, 137);
            gbLockPassword.TabIndex = 10;
            gbLockPassword.TabStop = false;
            gbLockPassword.Text = "Lock of [RESERVED] Password";
            // 
            // AlwaysNot
            // 
            AlwaysNot.AutoSize = true;
            AlwaysNot.Location = new Point(10, 112);
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
            Always.Location = new Point(10, 95);
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
            Proect.Location = new Point(10, 77);
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
            NoProect.Location = new Point(10, 60);
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
            AccessCode.Location = new Point(129, 15);
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
            DestroyCode.Location = new Point(10, 15);
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
            gbLockTIDnUSER.Location = new Point(304, 49);
            gbLockTIDnUSER.Margin = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Name = "gbLockTIDnUSER";
            gbLockTIDnUSER.Padding = new Padding(4, 3, 4, 3);
            gbLockTIDnUSER.Size = new Size(253, 107);
            gbLockTIDnUSER.TabIndex = 12;
            gbLockTIDnUSER.TabStop = false;
            gbLockTIDnUSER.Text = "Lock of [EPC, TID, USER] Bank";
            // 
            // AlwaysNot2
            // 
            AlwaysNot2.AutoSize = true;
            AlwaysNot2.Location = new Point(9, 79);
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
            Always2.Location = new Point(9, 61);
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
            Proect2.Location = new Point(9, 43);
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
            NoProect2.Location = new Point(9, 24);
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
            label35.Location = new Point(5, 528);
            label35.Name = "label35";
            label35.Size = new Size(227, 15);
            label35.TabIndex = 32;
            label35.Text = "* Double-Clicking copies line to clipboard";
            // 
            // cb6C_IKnowTagLock
            // 
            cb6C_IKnowTagLock.AutoSize = true;
            cb6C_IKnowTagLock.Location = new Point(393, 301);
            cb6C_IKnowTagLock.Name = "cb6C_IKnowTagLock";
            cb6C_IKnowTagLock.Size = new Size(144, 19);
            cb6C_IKnowTagLock.TabIndex = 29;
            cb6C_IKnowTagLock.Text = "I know what I'm doing";
            cb6C_IKnowTagLock.UseVisualStyleBackColor = true;
            cb6C_IKnowTagLock.CheckedChanged += cbIKnowTagLock_CheckedChanged;
            // 
            // cb6C_IKnowTagKill
            // 
            cb6C_IKnowTagKill.AutoSize = true;
            cb6C_IKnowTagKill.Location = new Point(706, 7);
            cb6C_IKnowTagKill.Name = "cb6C_IKnowTagKill";
            cb6C_IKnowTagKill.Size = new Size(144, 19);
            cb6C_IKnowTagKill.TabIndex = 28;
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
            groupBox_TagKill.Location = new Point(703, 24);
            groupBox_TagKill.Name = "groupBox_TagKill";
            groupBox_TagKill.Size = new Size(260, 90);
            groupBox_TagKill.TabIndex = 27;
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
            btn6C_KillTag.Click += btnKillTag_Click;
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
            gbTagRW.Location = new Point(3, 293);
            gbTagRW.Name = "gbTagRW";
            gbTagRW.Size = new Size(378, 232);
            gbTagRW.TabIndex = 26;
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
            btn6C_FindLength.Click += btnFindLength_Click;
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
            txtReader_WriteData.TextChanged += txtWriteData_TextChanged;
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
            btn6C_Clear.Click += btnClear_Click;
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
            btn6C_Write.Click += btnWrite_Click;
            // 
            // btn6C_Read
            // 
            btn6C_Read.Location = new Point(130, 195);
            btn6C_Read.Name = "btn6C_Read";
            btn6C_Read.Size = new Size(75, 30);
            btn6C_Read.TabIndex = 14;
            btn6C_Read.Text = "Read";
            btn6C_Read.UseVisualStyleBackColor = true;
            btn6C_Read.Click += btnRead_Click;
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
            groupBox6.Location = new Point(3, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(694, 287);
            groupBox6.TabIndex = 25;
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
            btn6C_QueryReaderFilter.Click += btnQueryReaderFilter_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 246);
            label14.Name = "label14";
            label14.Size = new Size(158, 15);
            label14.TabIndex = 21;
            label14.Text = "* Double-click to select a tag";
            // 
            // btn6C_Inventory
            // 
            btn6C_Inventory.Location = new Point(586, 249);
            btn6C_Inventory.Name = "btn6C_Inventory";
            btn6C_Inventory.Size = new Size(100, 32);
            btn6C_Inventory.TabIndex = 1;
            btn6C_Inventory.Text = "Inventory";
            btn6C_Inventory.UseVisualStyleBackColor = true;
            btn6C_Inventory.Click += btnInventory_Click;
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
            lb6C_RWResults.Location = new Point(5, 548);
            lb6C_RWResults.Name = "lb6C_RWResults";
            lb6C_RWResults.ScrollAlwaysVisible = true;
            lb6C_RWResults.Size = new Size(958, 244);
            lb6C_RWResults.TabIndex = 30;
            lb6C_RWResults.MouseDoubleClick += lbRWResults_MouseDoubleClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cbDisable_Write_MsgBaseSetAccessEpcMatch);
            groupBox2.Location = new Point(703, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 192);
            groupBox2.TabIndex = 31;
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
            cbDisable_Write_MsgBaseSetAccessEpcMatch.CheckedChanged += cbDisable_Write_MsgBaseSetAccessEpcMatch_CheckedChanged;
            // 
            // timer6C_PollRead
            // 
            timer6C_PollRead.Interval = 1000;
            timer6C_PollRead.Tick += timer6C_PollRead_Tick;
            // 
            // timerInventory
            // 
            timerInventory.Interval = 50;
            timerInventory.Tick += timerInventory_Tick;
            // 
            // Form_EPCC1G26C
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox_TagLocking);
            Controls.Add(label35);
            Controls.Add(cb6C_IKnowTagLock);
            Controls.Add(cb6C_IKnowTagKill);
            Controls.Add(groupBox_TagKill);
            Controls.Add(gbTagRW);
            Controls.Add(groupBox6);
            Controls.Add(lb6C_RWResults);
            Controls.Add(groupBox2);
            Name = "Form_EPCC1G26C";
            Size = new Size(968, 800);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox_TagLocking;
        private Label label30;
        private TextBox txt6C_LockEPCTag;
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
        private Label label35;
        private CheckBox cb6C_IKnowTagLock;
        private CheckBox cb6C_IKnowTagKill;
        private GroupBox groupBox_TagKill;
        private Label label16;
        private Button btn6C_KillTag;
        private TextBox txt6C_KillEPC;
        private TextBox txt6C_KillPwd;
        private Label label15;
        private GroupBox gbTagRW;
        private Button btn6C_FindLength;
        private CheckBox cbReader_PollReading;
        private TextBox txtReader_WriteData;
        private Label label13;
        private TextBox txt6C_RWLen;
        private Label label12;
        private Button btn6C_Clear;
        private Button btn6C_Write;
        private Button btn6C_Read;
        private Label label11;
        private ComboBox cb6C_MemBank;
        private TextBox txt6C_StartAddr;
        private Label label10;
        private Label label9;
        private TextBox txt6C_AccessPwd;
        private Label label7;
        private TextBox txt6C_RWEPC;
        private GroupBox groupBox6;
        private Button btn6C_QueryReaderFilter;
        private Label label14;
        private Button btn6C_Inventory;
        private ListView lvInventory;
        private ColumnHeader lvInvCol_Number;
        private ColumnHeader lvInvCol_PC;
        private ColumnHeader lvInvCol_EPC;
        private ColumnHeader lvInvCol_Len;
        private ColumnHeader lvInvCol_Count;
        private ColumnHeader lvInvCol_RSSI;
        private ColumnHeader lvInvCol_Freq;
        private ListBox lb6C_RWResults;
        private GroupBox groupBox2;
        private CheckBox cbDisable_Write_MsgBaseSetAccessEpcMatch;
        private System.Windows.Forms.Timer timer6C_PollRead;
        private System.Windows.Forms.Timer timerInventory;
    }
}
