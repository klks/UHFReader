namespace FM_5XX.FormTabs
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
            label5 = new Label();
            cbRFBand = new ComboBox();
            btnSaveRFBand = new Button();
            gbVersionInfo = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textHWVer = new TextBox();
            btnGetVersion = new Button();
            textSWVer = new TextBox();
            textReaderID = new TextBox();
            groupBox1 = new GroupBox();
            btnReader_COMClose = new Button();
            btnReader_COMOpen = new Button();
            btnRefreshComPorts = new Button();
            cbReader_COM = new ComboBox();
            Label1 = new Label();
            gbRFInfo.SuspendLayout();
            gbVersionInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
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
            gbRFInfo.Location = new Point(502, 4);
            gbRFInfo.Name = "gbRFInfo";
            gbRFInfo.Size = new Size(269, 157);
            gbRFInfo.TabIndex = 63;
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
            // gbVersionInfo
            // 
            gbVersionInfo.Controls.Add(label2);
            gbVersionInfo.Controls.Add(label3);
            gbVersionInfo.Controls.Add(label4);
            gbVersionInfo.Controls.Add(textHWVer);
            gbVersionInfo.Controls.Add(btnGetVersion);
            gbVersionInfo.Controls.Add(textSWVer);
            gbVersionInfo.Controls.Add(textReaderID);
            gbVersionInfo.Location = new Point(209, 3);
            gbVersionInfo.Name = "gbVersionInfo";
            gbVersionInfo.Size = new Size(287, 97);
            gbVersionInfo.TabIndex = 62;
            gbVersionInfo.TabStop = false;
            gbVersionInfo.Text = "Version Information";
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
            // textHWVer
            // 
            textHWVer.Location = new Point(200, 19);
            textHWVer.Name = "textHWVer";
            textHWVer.ReadOnly = true;
            textHWVer.Size = new Size(68, 23);
            textHWVer.TabIndex = 32;
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
            // textSWVer
            // 
            textSWVer.Location = new Point(63, 19);
            textSWVer.Name = "textSWVer";
            textSWVer.ReadOnly = true;
            textSWVer.Size = new Size(68, 23);
            textSWVer.TabIndex = 31;
            // 
            // textReaderID
            // 
            textReaderID.Location = new Point(74, 49);
            textReaderID.Name = "textReaderID";
            textReaderID.ReadOnly = true;
            textReaderID.Size = new Size(97, 23);
            textReaderID.TabIndex = 36;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnReader_COMClose);
            groupBox1.Controls.Add(btnReader_COMOpen);
            groupBox1.Controls.Add(btnRefreshComPorts);
            groupBox1.Controls.Add(cbReader_COM);
            groupBox1.Controls.Add(Label1);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 97);
            groupBox1.TabIndex = 61;
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
            btnRefreshComPorts.Click += btnRFFreqRefresh_Click;
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
            // Form_Reader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbRFInfo);
            Controls.Add(gbVersionInfo);
            Controls.Add(groupBox1);
            Name = "Form_Reader";
            Size = new Size(1259, 593);
            gbRFInfo.ResumeLayout(false);
            gbRFInfo.PerformLayout();
            gbVersionInfo.ResumeLayout(false);
            gbVersionInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public GroupBox gbRFInfo;
        internal Button btnRFFreqSave;
        internal Button btnGetPowerLevel;
        internal Button btnSavePowerLevel;
        private ComboBox cbPowerLevel;
        internal Label label18;
        internal Label lbFreqOffset;
        internal Label label14;
        private RadioButton rbBBM_RX;
        private RadioButton rbBBM_Carry;
        internal Label label8;
        private ComboBox cbFreqSel;
        internal Label label7;
        internal Button btnRFFreqRefresh;
        internal Label label5;
        private ComboBox cbRFBand;
        internal Button btnSaveRFBand;
        public GroupBox gbVersionInfo;
        internal Label label2;
        internal Label label3;
        internal Label label4;
        private TextBox textHWVer;
        private Button btnGetVersion;
        private TextBox textSWVer;
        private TextBox textReaderID;
        private GroupBox groupBox1;
        internal Button btnReader_COMClose;
        internal Button btnReader_COMOpen;
        private Button btnRefreshComPorts;
        internal ComboBox cbReader_COM;
        internal Label Label1;
    }
}
