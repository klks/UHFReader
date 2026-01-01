using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    partial class ScanWindow
    {
        private Label skinLabel1;
        private TextBox skinWaterTextBox_port;
        private Button skinButton_scan;
        private Button skinButton_stop;
        private ListView skinListView_devices;
        private Label skinLabel2;
        private ComboBox skinComboBox_interface;
        private ProgressBar skinProgressIndicator_scan_flag;
        private ColumnHeader columnHeader_none;
        private ColumnHeader columnHeader_IP;
        private ColumnHeader columnHeader_mac;
        private ColumnHeader columnHeader_port;
        private ColumnHeader columnHeader_transport_type;
        private Button skinButton_set;
        private ColumnHeader columnHeader_local_port;
        private Button skinButton_all_reset;

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
            skinLabel1 = new Label();
            skinWaterTextBox_port = new TextBox();
            skinButton_scan = new Button();
            skinButton_stop = new Button();
            skinListView_devices = new ListView();
            columnHeader_none = new ColumnHeader();
            columnHeader_IP = new ColumnHeader();
            columnHeader_mac = new ColumnHeader();
            columnHeader_port = new ColumnHeader();
            columnHeader_transport_type = new ColumnHeader();
            columnHeader_local_port = new ColumnHeader();
            skinLabel2 = new Label();
            skinComboBox_interface = new ComboBox();
            skinProgressIndicator_scan_flag = new ProgressBar();
            skinButton_set = new Button();
            skinButton_all_reset = new Button();
            SuspendLayout();
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.Location = new Point(14, 57);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(66, 17);
            skinLabel1.TabIndex = 0;
            skinLabel1.Text = "Scan Port:";
            // 
            // skinWaterTextBox_port
            // 
            skinWaterTextBox_port.Location = new Point(88, 54);
            skinWaterTextBox_port.Margin = new Padding(4, 3, 4, 3);
            skinWaterTextBox_port.Name = "skinWaterTextBox_port";
            skinWaterTextBox_port.Size = new Size(67, 23);
            skinWaterTextBox_port.TabIndex = 1;
            // 
            // skinButton_scan
            // 
            skinButton_scan.BackColor = Color.Transparent;
            skinButton_scan.Location = new Point(268, 50);
            skinButton_scan.Margin = new Padding(4, 3, 4, 3);
            skinButton_scan.Name = "skinButton_scan";
            skinButton_scan.Size = new Size(72, 29);
            skinButton_scan.TabIndex = 2;
            skinButton_scan.Text = "Scan";
            skinButton_scan.UseVisualStyleBackColor = false;
            skinButton_scan.Click += skinButton_scan_Click;
            // 
            // skinButton_stop
            // 
            skinButton_stop.BackColor = Color.Transparent;
            skinButton_stop.Location = new Point(348, 50);
            skinButton_stop.Margin = new Padding(4, 3, 4, 3);
            skinButton_stop.Name = "skinButton_stop";
            skinButton_stop.Size = new Size(68, 29);
            skinButton_stop.TabIndex = 3;
            skinButton_stop.Text = "Stop";
            skinButton_stop.UseVisualStyleBackColor = false;
            skinButton_stop.Click += skinButton_stop_Click;
            // 
            // skinListView_devices
            // 
            skinListView_devices.Columns.AddRange(new ColumnHeader[] { columnHeader_none, columnHeader_IP, columnHeader_mac, columnHeader_port, columnHeader_transport_type, columnHeader_local_port });
            skinListView_devices.FullRowSelect = true;
            skinListView_devices.Location = new Point(10, 89);
            skinListView_devices.Margin = new Padding(4, 3, 4, 3);
            skinListView_devices.Name = "skinListView_devices";
            skinListView_devices.OwnerDraw = true;
            skinListView_devices.Size = new Size(566, 364);
            skinListView_devices.TabIndex = 4;
            skinListView_devices.UseCompatibleStateImageBehavior = false;
            skinListView_devices.View = View.Details;
            // 
            // columnHeader_none
            // 
            columnHeader_none.Text = "none";
            columnHeader_none.Width = 0;
            // 
            // columnHeader_IP
            // 
            columnHeader_IP.Text = "Reader IP";
            columnHeader_IP.TextAlign = HorizontalAlignment.Center;
            columnHeader_IP.Width = 111;
            // 
            // columnHeader_mac
            // 
            columnHeader_mac.Text = "mac";
            columnHeader_mac.TextAlign = HorizontalAlignment.Center;
            columnHeader_mac.Width = 139;
            // 
            // columnHeader_port
            // 
            columnHeader_port.Text = "Port";
            columnHeader_port.TextAlign = HorizontalAlignment.Center;
            columnHeader_port.Width = 74;
            // 
            // columnHeader_transport_type
            // 
            columnHeader_transport_type.Text = "Transport Type";
            columnHeader_transport_type.TextAlign = HorizontalAlignment.Center;
            columnHeader_transport_type.Width = 107;
            // 
            // columnHeader_local_port
            // 
            columnHeader_local_port.Text = "Local";
            columnHeader_local_port.TextAlign = HorizontalAlignment.Center;
            // 
            // skinLabel2
            // 
            skinLabel2.AutoSize = true;
            skinLabel2.BackColor = Color.Transparent;
            skinLabel2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel2.Location = new Point(14, 12);
            skinLabel2.Margin = new Padding(4, 0, 4, 0);
            skinLabel2.Name = "skinLabel2";
            skinLabel2.Size = new Size(114, 17);
            skinLabel2.TabIndex = 5;
            skinLabel2.Text = "Ethernet Interface:";
            // 
            // skinComboBox_interface
            // 
            skinComboBox_interface.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_interface.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_interface.FormattingEnabled = true;
            skinComboBox_interface.Location = new Point(154, 12);
            skinComboBox_interface.Margin = new Padding(4, 3, 4, 3);
            skinComboBox_interface.Name = "skinComboBox_interface";
            skinComboBox_interface.Size = new Size(360, 24);
            skinComboBox_interface.TabIndex = 6;
            // 
            // skinProgressIndicator_scan_flag
            // 
            skinProgressIndicator_scan_flag.Location = new Point(167, 48);
            skinProgressIndicator_scan_flag.Margin = new Padding(4, 3, 4, 3);
            skinProgressIndicator_scan_flag.Name = "skinProgressIndicator_scan_flag";
            skinProgressIndicator_scan_flag.Size = new Size(93, 30);
            skinProgressIndicator_scan_flag.Style = ProgressBarStyle.Marquee;
            skinProgressIndicator_scan_flag.TabIndex = 7;
            skinProgressIndicator_scan_flag.Text = "Scaning";
            // 
            // skinButton_set
            // 
            skinButton_set.BackColor = Color.Transparent;
            skinButton_set.Location = new Point(422, 50);
            skinButton_set.Margin = new Padding(4, 3, 4, 3);
            skinButton_set.Name = "skinButton_set";
            skinButton_set.Size = new Size(78, 29);
            skinButton_set.TabIndex = 8;
            skinButton_set.Text = "Select";
            skinButton_set.UseVisualStyleBackColor = false;
            skinButton_set.Click += skinButton_set_Click;
            // 
            // skinButton_all_reset
            // 
            skinButton_all_reset.BackColor = Color.Transparent;
            skinButton_all_reset.Location = new Point(507, 50);
            skinButton_all_reset.Margin = new Padding(4, 3, 4, 3);
            skinButton_all_reset.Name = "skinButton_all_reset";
            skinButton_all_reset.Size = new Size(70, 29);
            skinButton_all_reset.TabIndex = 9;
            skinButton_all_reset.Text = "Reset";
            skinButton_all_reset.UseVisualStyleBackColor = false;
            skinButton_all_reset.Click += skinButton_all_reset_Click;
            // 
            // ScanWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(592, 467);
            Controls.Add(skinButton_all_reset);
            Controls.Add(skinButton_set);
            Controls.Add(skinProgressIndicator_scan_flag);
            Controls.Add(skinComboBox_interface);
            Controls.Add(skinLabel2);
            Controls.Add(skinListView_devices);
            Controls.Add(skinButton_stop);
            Controls.Add(skinButton_scan);
            Controls.Add(skinWaterTextBox_port);
            Controls.Add(skinLabel1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScanWindow";
            ShowIcon = false;
            Text = "Scan Rfid Reader Device";
            FormClosing += ScanWindow_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}