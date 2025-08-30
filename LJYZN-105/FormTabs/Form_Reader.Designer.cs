namespace LJYZN_105
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
            groupBox3.SuspendLayout();
            groupBox30.SuspendLayout();
            groupBox2.SuspendLayout();
            GroupBox1.SuspendLayout();
            SuspendLayout();
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
            groupBox3.Location = new Point(169, 153);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(774, 210);
            groupBox3.TabIndex = 46;
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
            groupBox30.Location = new Point(554, 19);
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
            rbReader_FreqBand_Europe.Location = new Point(8, 113);
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
            rbReader_FreqBand_Korean.Location = new Point(8, 87);
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
            rbReader_FreqBand_US.Location = new Point(8, 64);
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
            rbReader_FreqBand_Chinese.Location = new Point(8, 41);
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
            rbReader_FreqBand_User.Location = new Point(8, 18);
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
            btnReader_SetDefaultParameter.Location = new Point(628, 172);
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
            btnReader_SetParameter.Location = new Point(471, 172);
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
            ComboBox_scantime.Location = new Point(406, 78);
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
            cbReader_SetBaud.Location = new Point(406, 27);
            cbReader_SetBaud.Margin = new Padding(4, 3, 4, 3);
            cbReader_SetBaud.Name = "cbReader_SetBaud";
            cbReader_SetBaud.Size = new Size(140, 23);
            cbReader_SetBaud.TabIndex = 11;
            // 
            // CheckBox_SameFre
            // 
            CheckBox_SameFre.AutoSize = true;
            CheckBox_SameFre.Location = new Point(252, 132);
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
            label17.Location = new Point(249, 82);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(137, 15);
            label17.TabIndex = 9;
            label17.Text = "Max InventoryScanTime:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(249, 35);
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
            ComboBox_dmaxfre.Location = new Point(111, 175);
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
            ComboBox_dminfre.Location = new Point(111, 130);
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
            ComboBox_PowerDbm.Location = new Point(111, 78);
            ComboBox_PowerDbm.Margin = new Padding(4, 3, 4, 3);
            ComboBox_PowerDbm.Name = "ComboBox_PowerDbm";
            ComboBox_PowerDbm.Size = new Size(116, 23);
            ComboBox_PowerDbm.TabIndex = 5;
            // 
            // Edit_NewComAdr
            // 
            Edit_NewComAdr.Location = new Point(111, 27);
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
            label15.Location = new Point(8, 179);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(90, 15);
            label15.TabIndex = 3;
            label15.Text = "Max.Frequency:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(8, 134);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(89, 15);
            label14.TabIndex = 2;
            label14.Text = "Min.Frequency:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(8, 82);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(43, 15);
            label13.TabIndex = 1;
            label13.Text = "Power:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(8, 35);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(82, 15);
            label12.TabIndex = 0;
            label12.Text = "Address(HEX):";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(279, 384);
            progressBar1.Margin = new Padding(4, 3, 4, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(465, 29);
            progressBar1.TabIndex = 47;
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
            groupBox2.Location = new Point(169, 0);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(774, 149);
            groupBox2.TabIndex = 45;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reader Information";
            // 
            // btnReader_GetReaderInfo
            // 
            btnReader_GetReaderInfo.Location = new Point(628, 115);
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
            Edit_scantime.Location = new Point(628, 70);
            Edit_scantime.Margin = new Padding(4, 3, 4, 3);
            Edit_scantime.Name = "Edit_scantime";
            Edit_scantime.Size = new Size(137, 23);
            Edit_scantime.TabIndex = 16;
            // 
            // EPCC1G2
            // 
            EPCC1G2.AutoSize = true;
            EPCC1G2.Location = new Point(629, 42);
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
            ISO180006B.Location = new Point(629, 18);
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
            label11.Location = new Point(470, 75);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(137, 15);
            label11.TabIndex = 13;
            label11.Text = "Max InventoryScanTime:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(470, 29);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 12;
            label10.Text = "Protocols:";
            // 
            // Edit_dmaxfre
            // 
            Edit_dmaxfre.BackColor = SystemColors.ScrollBar;
            Edit_dmaxfre.Location = new Point(334, 117);
            Edit_dmaxfre.Margin = new Padding(4, 3, 4, 3);
            Edit_dmaxfre.Name = "Edit_dmaxfre";
            Edit_dmaxfre.Size = new Size(116, 23);
            Edit_dmaxfre.TabIndex = 11;
            // 
            // Edit_powerdBm
            // 
            Edit_powerdBm.BackColor = SystemColors.ScrollBar;
            Edit_powerdBm.Location = new Point(334, 71);
            Edit_powerdBm.Margin = new Padding(4, 3, 4, 3);
            Edit_powerdBm.Name = "Edit_powerdBm";
            Edit_powerdBm.Size = new Size(116, 23);
            Edit_powerdBm.TabIndex = 10;
            // 
            // Edit_Version
            // 
            Edit_Version.BackColor = SystemColors.ScrollBar;
            Edit_Version.Location = new Point(334, 25);
            Edit_Version.Margin = new Padding(4, 3, 4, 3);
            Edit_Version.Name = "Edit_Version";
            Edit_Version.Size = new Size(116, 23);
            Edit_Version.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(231, 121);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(90, 15);
            label9.TabIndex = 8;
            label9.Text = "Max.Frequency:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(231, 75);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(43, 15);
            label8.TabIndex = 7;
            label8.Text = "Power:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(231, 29);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 6;
            label7.Text = "Version:";
            // 
            // Edit_dminfre
            // 
            Edit_dminfre.BackColor = SystemColors.ScrollBar;
            Edit_dminfre.Location = new Point(111, 117);
            Edit_dminfre.Margin = new Padding(4, 3, 4, 3);
            Edit_dminfre.Name = "Edit_dminfre";
            Edit_dminfre.Size = new Size(98, 23);
            Edit_dminfre.TabIndex = 5;
            // 
            // Edit_ComAdr
            // 
            Edit_ComAdr.BackColor = SystemColors.ScrollBar;
            Edit_ComAdr.Location = new Point(111, 71);
            Edit_ComAdr.Margin = new Padding(4, 3, 4, 3);
            Edit_ComAdr.Name = "Edit_ComAdr";
            Edit_ComAdr.Size = new Size(98, 23);
            Edit_ComAdr.TabIndex = 4;
            // 
            // Edit_Type
            // 
            Edit_Type.BackColor = SystemColors.ScrollBar;
            Edit_Type.Location = new Point(111, 25);
            Edit_Type.Margin = new Padding(4, 3, 4, 3);
            Edit_Type.Name = "Edit_Type";
            Edit_Type.Size = new Size(98, 23);
            Edit_Type.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 121);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 2;
            label6.Text = "Min.Frequency:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 75);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 1;
            label5.Text = "Address:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 29);
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
            GroupBox1.Location = new Point(3, 0);
            GroupBox1.Margin = new Padding(4, 3, 4, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 3, 4, 3);
            GroupBox1.Size = new Size(159, 256);
            GroupBox1.TabIndex = 44;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Communication";
            // 
            // cbReader_ComBaud
            // 
            cbReader_ComBaud.DropDownStyle = ComboBoxStyle.DropDownList;
            cbReader_ComBaud.FormattingEnabled = true;
            cbReader_ComBaud.Items.AddRange(new object[] { "9600bps", "19200bps", "38400bps", "57600bps", "115200bps" });
            cbReader_ComBaud.Location = new Point(8, 139);
            cbReader_ComBaud.Margin = new Padding(4, 3, 4, 3);
            cbReader_ComBaud.Name = "cbReader_ComBaud";
            cbReader_ComBaud.Size = new Size(140, 23);
            cbReader_ComBaud.TabIndex = 12;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(9, 121);
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
            cbReader_AlreadyOpenCOM.Location = new Point(7, 191);
            cbReader_AlreadyOpenCOM.Margin = new Padding(4, 3, 4, 3);
            cbReader_AlreadyOpenCOM.Name = "cbReader_AlreadyOpenCOM";
            cbReader_AlreadyOpenCOM.Size = new Size(145, 23);
            cbReader_AlreadyOpenCOM.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 169);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 6;
            label3.Text = "Opened COM Port:";
            // 
            // btnReader_ClosePort
            // 
            btnReader_ClosePort.Location = new Point(7, 221);
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
            btnReader_OpenPort.Location = new Point(6, 85);
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
            txtReader_CmdComAddr.Location = new Point(114, 50);
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
            Label2.Location = new Point(8, 55);
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
            cbReader_COM.Location = new Point(76, 18);
            cbReader_COM.Margin = new Padding(4, 3, 4, 3);
            cbReader_COM.Name = "cbReader_COM";
            cbReader_COM.Size = new Size(75, 23);
            cbReader_COM.TabIndex = 1;
            cbReader_COM.SelectedIndexChanged += ComboBox_COM_SelectedIndexChanged;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(7, 29);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(66, 15);
            Label1.TabIndex = 0;
            Label1.Text = "COM Port：";
            // 
            // Form_Reader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox3);
            Controls.Add(progressBar1);
            Controls.Add(groupBox2);
            Controls.Add(GroupBox1);
            Name = "Form_Reader";
            Size = new Size(948, 423);
            Load += Form_Reader_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox30.ResumeLayout(false);
            groupBox30.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

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
    }
}
