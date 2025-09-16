namespace FM_5XX.FormTabs
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
            lvInvCol_CRC = new ColumnHeader();
            lvInvCol_PC = new ColumnHeader();
            lvInvCol_EPC = new ColumnHeader();
            lvInvCol_Len = new ColumnHeader();
            lvInvCol_Count = new ColumnHeader();
            cbEnableMask = new CheckBox();
            groupBox3 = new GroupBox();
            txtMaskData = new TextBox();
            label24 = new Label();
            txtMaskLen = new TextBox();
            txtMaskStartAddr = new TextBox();
            label20 = new Label();
            label23 = new Label();
            label21 = new Label();
            cbMaskMemBank = new ComboBox();
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
            cb6C_IKnowTagKill = new CheckBox();
            groupBox_TagKill = new GroupBox();
            label16 = new Label();
            btn6C_KillTag = new Button();
            textBox1 = new TextBox();
            label15 = new Label();
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
            timer_InventoryTID = new System.Windows.Forms.Timer(components);
            timer_InventoryEPC = new System.Windows.Forms.Timer(components);
            groupBox6.SuspendLayout();
            groupBox3.SuspendLayout();
            gbTagRW.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox_TagKill.SuspendLayout();
            groupBox_TagLocking.SuspendLayout();
            groupBox10.SuspendLayout();
            gbLockPassword.SuspendLayout();
            groupBox9.SuspendLayout();
            gbLockTIDnUSER.SuspendLayout();
            SuspendLayout();
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
            groupBox6.Location = new Point(3, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(633, 479);
            groupBox6.TabIndex = 15;
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
            lvInventoryEPC.Columns.AddRange(new ColumnHeader[] { lvInvCol_Number, lvInvCol_CRC, lvInvCol_PC, lvInvCol_EPC, lvInvCol_Len, lvInvCol_Count });
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
            // lvInvCol_CRC
            // 
            lvInvCol_CRC.Text = "CRC";
            lvInvCol_CRC.Width = 50;
            // 
            // lvInvCol_PC
            // 
            lvInvCol_PC.Text = "PC";
            lvInvCol_PC.Width = 50;
            // 
            // lvInvCol_EPC
            // 
            lvInvCol_EPC.Text = "EPC";
            lvInvCol_EPC.Width = 240;
            // 
            // lvInvCol_Len
            // 
            lvInvCol_Len.Text = "Length";
            lvInvCol_Len.Width = 50;
            // 
            // lvInvCol_Count
            // 
            lvInvCol_Count.Text = "Count";
            lvInvCol_Count.Width = 50;
            // 
            // cbEnableMask
            // 
            cbEnableMask.AutoSize = true;
            cbEnableMask.Location = new Point(5, -1);
            cbEnableMask.Name = "cbEnableMask";
            cbEnableMask.Size = new Size(214, 19);
            cbEnableMask.TabIndex = 30;
            cbEnableMask.Text = "Enable Set Select for Pre-Command";
            cbEnableMask.UseVisualStyleBackColor = true;
            cbEnableMask.CheckedChanged += cbEnableMask_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbEnableMask);
            groupBox3.Controls.Add(txtMaskData);
            groupBox3.Controls.Add(label24);
            groupBox3.Controls.Add(txtMaskLen);
            groupBox3.Controls.Add(txtMaskStartAddr);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(cbMaskMemBank);
            groupBox3.Location = new Point(3, 488);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(631, 81);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            // 
            // txtMaskData
            // 
            txtMaskData.CharacterCasing = CharacterCasing.Upper;
            txtMaskData.Location = new Point(95, 52);
            txtMaskData.Name = "txtMaskData";
            txtMaskData.Size = new Size(530, 23);
            txtMaskData.TabIndex = 25;
            txtMaskData.TextChanged += filterOnlyHex_TextChanged;
            txtMaskData.KeyPress += filterOnlyHex_KeyPress;
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
            // txtMaskLen
            // 
            txtMaskLen.Location = new Point(552, 24);
            txtMaskLen.MaxLength = 4;
            txtMaskLen.Name = "txtMaskLen";
            txtMaskLen.Size = new Size(70, 23);
            txtMaskLen.TabIndex = 29;
            txtMaskLen.Text = "40";
            txtMaskLen.TextChanged += filterOnlyHex_TextChanged;
            txtMaskLen.KeyPress += filterOnlyHex_KeyPress;
            // 
            // txtMaskStartAddr
            // 
            txtMaskStartAddr.CharacterCasing = CharacterCasing.Upper;
            txtMaskStartAddr.Location = new Point(351, 24);
            txtMaskStartAddr.MaxLength = 4;
            txtMaskStartAddr.Name = "txtMaskStartAddr";
            txtMaskStartAddr.Size = new Size(70, 23);
            txtMaskStartAddr.TabIndex = 25;
            txtMaskStartAddr.Text = "20";
            txtMaskStartAddr.TextChanged += filterOnlyHex_TextChanged;
            txtMaskStartAddr.KeyPress += filterOnlyHex_KeyPress;
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
            // cbMaskMemBank
            // 
            cbMaskMemBank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaskMemBank.FormattingEnabled = true;
            cbMaskMemBank.Items.AddRange(new object[] { "RESERVED", "EPC", "TID", "USER" });
            cbMaskMemBank.Location = new Point(95, 23);
            cbMaskMemBank.Name = "cbMaskMemBank";
            cbMaskMemBank.Size = new Size(121, 23);
            cbMaskMemBank.TabIndex = 26;
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
            gbTagRW.Location = new Point(3, 575);
            gbTagRW.Name = "gbTagRW";
            gbTagRW.Size = new Size(633, 144);
            gbTagRW.TabIndex = 19;
            gbTagRW.TabStop = false;
            gbTagRW.Text = "Tag Read/Write";
            // 
            // txtReader_ReadData
            // 
            txtReader_ReadData.CharacterCasing = CharacterCasing.Upper;
            txtReader_ReadData.Location = new Point(76, 78);
            txtReader_ReadData.Name = "txtReader_ReadData";
            txtReader_ReadData.ReadOnly = true;
            txtReader_ReadData.Size = new Size(470, 23);
            txtReader_ReadData.TabIndex = 23;
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
            txt6C_RWLen.Location = new Point(427, 49);
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
            label12.Location = new Point(320, 52);
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
            label11.Location = new Point(68, 23);
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
            cb6C_MemBank.Location = new Point(155, 19);
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
            label10.Location = new Point(8, 51);
            label10.Name = "label10";
            label10.Size = new Size(141, 15);
            label10.TabIndex = 10;
            label10.Text = "Start Address (Word/Hex)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(294, 23);
            label9.Name = "label9";
            label9.Size = new Size(127, 15);
            label9.TabIndex = 8;
            label9.Text = "Access Password (Hex)";
            // 
            // txt6C_AccessPwd
            // 
            txt6C_AccessPwd.CharacterCasing = CharacterCasing.Upper;
            txt6C_AccessPwd.Location = new Point(427, 21);
            txt6C_AccessPwd.MaxLength = 8;
            txt6C_AccessPwd.Name = "txt6C_AccessPwd";
            txt6C_AccessPwd.Size = new Size(70, 23);
            txt6C_AccessPwd.TabIndex = 7;
            txt6C_AccessPwd.Text = "00000000";
            txt6C_AccessPwd.KeyPress += filterOnlyHex_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLogClearSerial);
            groupBox2.Controls.Add(textSerialInput);
            groupBox2.Controls.Add(btnSerialSend);
            groupBox2.Controls.Add(lbSerialLog);
            groupBox2.Location = new Point(642, 393);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(600, 328);
            groupBox2.TabIndex = 18;
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
            btnLogClearSerial.Click += btnLogClearSerial_Click;
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
            // cb6C_IKnowTagKill
            // 
            cb6C_IKnowTagKill.AutoSize = true;
            cb6C_IKnowTagKill.Location = new Point(649, 295);
            cb6C_IKnowTagKill.Name = "cb6C_IKnowTagKill";
            cb6C_IKnowTagKill.Size = new Size(144, 19);
            cb6C_IKnowTagKill.TabIndex = 14;
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
            groupBox_TagKill.Location = new Point(646, 312);
            groupBox_TagKill.Name = "groupBox_TagKill";
            groupBox_TagKill.Size = new Size(234, 77);
            groupBox_TagKill.TabIndex = 13;
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
            btn6C_KillTag.Click += btn6C_KillTag_Click;
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
            // cb6C_IKnowTagLock
            // 
            cb6C_IKnowTagLock.AutoSize = true;
            cb6C_IKnowTagLock.Location = new Point(651, 2);
            cb6C_IKnowTagLock.Name = "cb6C_IKnowTagLock";
            cb6C_IKnowTagLock.Size = new Size(144, 19);
            cb6C_IKnowTagLock.TabIndex = 17;
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
            groupBox_TagLocking.Location = new Point(642, 21);
            groupBox_TagLocking.Name = "groupBox_TagLocking";
            groupBox_TagLocking.Size = new Size(565, 270);
            groupBox_TagLocking.TabIndex = 16;
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
            btnSetProtectState.Click += btnSetProtectState_Click;
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
            P_User.Location = new Point(191, 14);
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
            P_TID.Location = new Point(141, 14);
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
            P_EPC.Location = new Point(87, 14);
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
            P_Reserve.Location = new Point(7, 14);
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
            AccessCode.Location = new Point(128, 15);
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
            DestroyCode.Location = new Point(9, 15);
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
            // timer_InventoryTID
            // 
            timer_InventoryTID.Tick += timer_InventoryTID_Tick;
            // 
            // timer_InventoryEPC
            // 
            timer_InventoryEPC.Tick += timer_InventoryEPC_Tick;
            // 
            // Form_EPCC1G26C
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox6);
            Controls.Add(groupBox3);
            Controls.Add(gbTagRW);
            Controls.Add(groupBox2);
            Controls.Add(cb6C_IKnowTagKill);
            Controls.Add(groupBox_TagKill);
            Controls.Add(cb6C_IKnowTagLock);
            Controls.Add(groupBox_TagLocking);
            Name = "Form_EPCC1G26C";
            Size = new Size(1247, 727);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            gbTagRW.ResumeLayout(false);
            gbTagRW.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox_TagKill.ResumeLayout(false);
            groupBox_TagKill.PerformLayout();
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox6;
        private Label label19;
        private TextBox txtInvTID_Length;
        private Label label17;
        private TextBox txtInvTID_Address;
        public ListView lvInventoryTID;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnInventoryEPC;
        private Button btnInventoryTID;
        public ListView lvInventoryEPC;
        private ColumnHeader lvInvCol_Number;
        private ColumnHeader lvInvCol_PC;
        private ColumnHeader lvInvCol_EPC;
        private ColumnHeader lvInvCol_Len;
        private ColumnHeader lvInvCol_Count;
        private CheckBox cbEnableMask;
        private GroupBox groupBox3;
        private TextBox txtMaskData;
        private Label label24;
        private TextBox txtMaskLen;
        private TextBox txtMaskStartAddr;
        private Label label20;
        private Label label23;
        private Label label21;
        private ComboBox cbMaskMemBank;
        private GroupBox gbTagRW;
        public TextBox txtReader_ReadData;
        private Label label6;
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
        private GroupBox groupBox2;
        private Button btnLogClearSerial;
        private TextBox textSerialInput;
        private Button btnSerialSend;
        private ListBox lbSerialLog;
        private CheckBox cb6C_IKnowTagKill;
        private GroupBox groupBox_TagKill;
        private Label label16;
        private Button btn6C_KillTag;
        private TextBox textBox1;
        private Label label15;
        private CheckBox cb6C_IKnowTagLock;
        private GroupBox groupBox_TagLocking;
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
        private System.Windows.Forms.Timer timer_InventoryTID;
        private System.Windows.Forms.Timer timer_InventoryEPC;
        private ColumnHeader lvInvCol_CRC;
    }
}
