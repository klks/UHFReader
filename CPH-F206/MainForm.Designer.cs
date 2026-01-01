using System.Resources;

namespace CPH_F206
{
    partial class MainForm
    {
        private ComboBox skinComboBox_serial_port;
        private Label skinLabel_serialport_num;
        private Button skinButton_fresh;
        private ListView listView_result;
        private ColumnHeader columnHeader_time;
        private ColumnHeader columnHeader_text;
        private Panel skinPanel_serialport;
        private Panel skinPanel_connection;
        private ComboBox skinComboBox_interface;
        private Label skinLabel_interface;
        private Button skinButton_connect;
        private Panel skinPanel_network;
        private Label skinLabel_ip;
        private Label skinLabel_port;
        private TextBox skinWaterTextBox_remote_port;
        private TextBox skinWaterTextBox_remote_ip;
        private ComboBox skinComboBox_net_protocol;
        private Label skinLabel1;
        private Button skinButton_net_scan;
        private PictureBox skinPictureBox_welcom;
        private Button skinButton_tcp_server;
        private TextBox skinWaterTextBox_local_port;
        private Label skinLabel2;
        private ComboBox skinComboBox_baudrate;
        private Label skinLabel3;
        private Panel skinPanel_USB_Connect;
        private ComboBox skinComboBox_deviceusb_list;
        private Label skinLabel_usblist;
        private Panel skinPanel1;
        private Button skinButton_fun_wifi;
        private Button skinButton_fun_main;
        private Label skinLabel4;
        private ComboBox skinComboBox_net_local_ip;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            skinComboBox_serial_port = new ComboBox();
            skinLabel_serialport_num = new Label();
            skinButton_fresh = new Button();
            listView_result = new ListView();
            columnHeader_time = new ColumnHeader();
            columnHeader_text = new ColumnHeader();
            skinPanel_serialport = new Panel();
            skinPanel_network = new Panel();
            skinComboBox_net_local_ip = new ComboBox();
            skinLabel4 = new Label();
            skinWaterTextBox_local_port = new TextBox();
            skinLabel2 = new Label();
            skinComboBox_net_protocol = new ComboBox();
            skinLabel1 = new Label();
            skinWaterTextBox_remote_port = new TextBox();
            skinWaterTextBox_remote_ip = new TextBox();
            skinLabel_port = new Label();
            skinLabel_ip = new Label();
            skinComboBox_baudrate = new ComboBox();
            skinLabel3 = new Label();
            skinPanel_connection = new Panel();
            skinComboBox_interface = new ComboBox();
            skinLabel_interface = new Label();
            skinButton_connect = new Button();
            skinButton_tcp_server = new Button();
            skinButton_net_scan = new Button();
            skinPictureBox_welcom = new PictureBox();
            skinPanel_USB_Connect = new Panel();
            skinComboBox_deviceusb_list = new ComboBox();
            skinLabel_usblist = new Label();
            skinPanel1 = new Panel();
            skinButton_fun_wifi = new Button();
            skinButton_fun_main = new Button();
            skinPanel_serialport.SuspendLayout();
            skinPanel_network.SuspendLayout();
            skinPanel_connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinPictureBox_welcom).BeginInit();
            skinPanel_USB_Connect.SuspendLayout();
            skinPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // skinComboBox_serial_port
            // 
            skinComboBox_serial_port.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_serial_port.FormattingEnabled = true;
            skinComboBox_serial_port.Location = new Point(97, 18);
            skinComboBox_serial_port.Margin = new Padding(4);
            skinComboBox_serial_port.Name = "skinComboBox_serial_port";
            skinComboBox_serial_port.Size = new Size(110, 23);
            skinComboBox_serial_port.TabIndex = 0;
            // 
            // skinLabel_serialport_num
            // 
            skinLabel_serialport_num.AutoSize = true;
            skinLabel_serialport_num.BackColor = Color.Transparent;
            skinLabel_serialport_num.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_serialport_num.Location = new Point(18, 21);
            skinLabel_serialport_num.Margin = new Padding(4, 0, 4, 0);
            skinLabel_serialport_num.Name = "skinLabel_serialport_num";
            skinLabel_serialport_num.Size = new Size(71, 17);
            skinLabel_serialport_num.TabIndex = 1;
            skinLabel_serialport_num.Text = "Serial Port:";
            // 
            // skinButton_fresh
            // 
            skinButton_fresh.BackColor = Color.Transparent;
            skinButton_fresh.Location = new Point(62, 112);
            skinButton_fresh.Margin = new Padding(4);
            skinButton_fresh.Name = "skinButton_fresh";
            skinButton_fresh.Size = new Size(88, 29);
            skinButton_fresh.TabIndex = 5;
            skinButton_fresh.Text = "Refresh";
            skinButton_fresh.UseVisualStyleBackColor = false;
            skinButton_fresh.Click += skinButton_fresh_Click;
            // 
            // listView_result
            // 
            listView_result.Columns.AddRange(new ColumnHeader[] { columnHeader_time, columnHeader_text });
            listView_result.FullRowSelect = true;
            listView_result.Location = new Point(14, 525);
            listView_result.Margin = new Padding(4);
            listView_result.Name = "listView_result";
            listView_result.Size = new Size(916, 172);
            listView_result.TabIndex = 11;
            listView_result.UseCompatibleStateImageBehavior = false;
            listView_result.View = View.Details;
            // 
            // columnHeader_time
            // 
            columnHeader_time.Text = "Time";
            columnHeader_time.Width = 81;
            // 
            // columnHeader_text
            // 
            columnHeader_text.Text = "Message";
            columnHeader_text.Width = 701;
            // 
            // skinPanel_serialport
            // 
            skinPanel_serialport.BackColor = Color.Transparent;
            skinPanel_serialport.Controls.Add(skinComboBox_baudrate);
            skinPanel_serialport.Controls.Add(skinLabel3);
            skinPanel_serialport.Controls.Add(skinLabel_serialport_num);
            skinPanel_serialport.Controls.Add(skinComboBox_serial_port);
            skinPanel_serialport.Controls.Add(skinButton_fresh);
            skinPanel_serialport.Location = new Point(0, 40);
            skinPanel_serialport.Margin = new Padding(4);
            skinPanel_serialport.Name = "skinPanel_serialport";
            skinPanel_serialport.Size = new Size(218, 166);
            skinPanel_serialport.TabIndex = 12;
            // 
            // skinPanel_network
            // 
            skinPanel_network.BackColor = Color.Transparent;
            skinPanel_network.Controls.Add(skinComboBox_net_local_ip);
            skinPanel_network.Controls.Add(skinLabel4);
            skinPanel_network.Controls.Add(skinWaterTextBox_local_port);
            skinPanel_network.Controls.Add(skinLabel2);
            skinPanel_network.Controls.Add(skinComboBox_net_protocol);
            skinPanel_network.Controls.Add(skinLabel1);
            skinPanel_network.Controls.Add(skinWaterTextBox_remote_port);
            skinPanel_network.Controls.Add(skinWaterTextBox_remote_ip);
            skinPanel_network.Controls.Add(skinLabel_port);
            skinPanel_network.Controls.Add(skinLabel_ip);
            skinPanel_network.Location = new Point(4, 33);
            skinPanel_network.Margin = new Padding(4);
            skinPanel_network.Name = "skinPanel_network";
            skinPanel_network.Size = new Size(217, 194);
            skinPanel_network.TabIndex = 15;
            // 
            // skinComboBox_net_local_ip
            // 
            skinComboBox_net_local_ip.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_net_local_ip.FormattingEnabled = true;
            skinComboBox_net_local_ip.Location = new Point(58, 158);
            skinComboBox_net_local_ip.Margin = new Padding(4);
            skinComboBox_net_local_ip.Name = "skinComboBox_net_local_ip";
            skinComboBox_net_local_ip.Size = new Size(152, 23);
            skinComboBox_net_local_ip.TabIndex = 11;
            // 
            // skinLabel4
            // 
            skinLabel4.AutoSize = true;
            skinLabel4.BackColor = Color.Transparent;
            skinLabel4.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel4.Location = new Point(1, 160);
            skinLabel4.Margin = new Padding(4, 0, 4, 0);
            skinLabel4.Name = "skinLabel4";
            skinLabel4.Size = new Size(56, 17);
            skinLabel4.TabIndex = 10;
            skinLabel4.Text = "Local IP:";
            // 
            // skinWaterTextBox_local_port
            // 
            skinWaterTextBox_local_port.Location = new Point(107, 85);
            skinWaterTextBox_local_port.Margin = new Padding(4);
            skinWaterTextBox_local_port.Name = "skinWaterTextBox_local_port";
            skinWaterTextBox_local_port.Size = new Size(96, 23);
            skinWaterTextBox_local_port.TabIndex = 9;
            skinWaterTextBox_local_port.Text = "0";
            // 
            // skinLabel2
            // 
            skinLabel2.AutoSize = true;
            skinLabel2.BackColor = Color.Transparent;
            skinLabel2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel2.Location = new Point(16, 88);
            skinLabel2.Margin = new Padding(4, 0, 4, 0);
            skinLabel2.Name = "skinLabel2";
            skinLabel2.Size = new Size(70, 17);
            skinLabel2.TabIndex = 8;
            skinLabel2.Text = "Local port:";
            // 
            // skinComboBox_net_protocol
            // 
            skinComboBox_net_protocol.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_net_protocol.FormattingEnabled = true;
            skinComboBox_net_protocol.Items.AddRange(new object[] { "UDP", "TCP Client" });
            skinComboBox_net_protocol.Location = new Point(82, 119);
            skinComboBox_net_protocol.Margin = new Padding(4);
            skinComboBox_net_protocol.Name = "skinComboBox_net_protocol";
            skinComboBox_net_protocol.Size = new Size(124, 23);
            skinComboBox_net_protocol.TabIndex = 6;
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.Location = new Point(9, 122);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(60, 17);
            skinLabel1.TabIndex = 5;
            skinLabel1.Text = "Protocol:";
            // 
            // skinWaterTextBox_remote_port
            // 
            skinWaterTextBox_remote_port.Location = new Point(107, 50);
            skinWaterTextBox_remote_port.Margin = new Padding(4);
            skinWaterTextBox_remote_port.Name = "skinWaterTextBox_remote_port";
            skinWaterTextBox_remote_port.Size = new Size(97, 23);
            skinWaterTextBox_remote_port.TabIndex = 3;
            // 
            // skinWaterTextBox_remote_ip
            // 
            skinWaterTextBox_remote_ip.Location = new Point(82, 15);
            skinWaterTextBox_remote_ip.Margin = new Padding(4);
            skinWaterTextBox_remote_ip.Name = "skinWaterTextBox_remote_ip";
            skinWaterTextBox_remote_ip.Size = new Size(124, 23);
            skinWaterTextBox_remote_ip.TabIndex = 2;
            // 
            // skinLabel_port
            // 
            skinLabel_port.AutoSize = true;
            skinLabel_port.BackColor = Color.Transparent;
            skinLabel_port.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_port.Location = new Point(4, 52);
            skinLabel_port.Margin = new Padding(4, 0, 4, 0);
            skinLabel_port.Name = "skinLabel_port";
            skinLabel_port.Size = new Size(85, 17);
            skinLabel_port.TabIndex = 1;
            skinLabel_port.Text = "Reader addr:";
            // 
            // skinLabel_ip
            // 
            skinLabel_ip.AutoSize = true;
            skinLabel_ip.BackColor = Color.Transparent;
            skinLabel_ip.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_ip.Location = new Point(1, 18);
            skinLabel_ip.Margin = new Padding(4, 0, 4, 0);
            skinLabel_ip.Name = "skinLabel_ip";
            skinLabel_ip.Size = new Size(68, 17);
            skinLabel_ip.TabIndex = 0;
            skinLabel_ip.Text = "Reader IP:";
            // 
            // skinComboBox_baudrate
            // 
            skinComboBox_baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_baudrate.FormattingEnabled = true;
            skinComboBox_baudrate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            skinComboBox_baudrate.Location = new Point(97, 60);
            skinComboBox_baudrate.Margin = new Padding(4);
            skinComboBox_baudrate.Name = "skinComboBox_baudrate";
            skinComboBox_baudrate.Size = new Size(110, 23);
            skinComboBox_baudrate.TabIndex = 7;
            // 
            // skinLabel3
            // 
            skinLabel3.AutoSize = true;
            skinLabel3.BackColor = Color.Transparent;
            skinLabel3.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel3.Location = new Point(21, 62);
            skinLabel3.Margin = new Padding(4, 0, 4, 0);
            skinLabel3.Name = "skinLabel3";
            skinLabel3.Size = new Size(68, 17);
            skinLabel3.TabIndex = 6;
            skinLabel3.Text = "Baud rate:";
            // 
            // skinPanel_connection
            // 
            skinPanel_connection.BackColor = Color.Transparent;
            skinPanel_connection.Controls.Add(skinPanel_network);
            skinPanel_connection.Controls.Add(skinComboBox_interface);
            skinPanel_connection.Controls.Add(skinLabel_interface);
            skinPanel_connection.Controls.Add(skinButton_connect);
            skinPanel_connection.Controls.Add(skinPanel_serialport);
            skinPanel_connection.Location = new Point(14, 20);
            skinPanel_connection.Margin = new Padding(4);
            skinPanel_connection.Name = "skinPanel_connection";
            skinPanel_connection.Size = new Size(226, 275);
            skinPanel_connection.TabIndex = 14;
            // 
            // skinComboBox_interface
            // 
            skinComboBox_interface.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_interface.FormattingEnabled = true;
            skinComboBox_interface.Items.AddRange(new object[] { "RS232/RS485", "RJ45", "USB" });
            skinComboBox_interface.Location = new Point(77, 8);
            skinComboBox_interface.Margin = new Padding(4);
            skinComboBox_interface.Name = "skinComboBox_interface";
            skinComboBox_interface.Size = new Size(112, 23);
            skinComboBox_interface.TabIndex = 15;
            skinComboBox_interface.SelectedIndexChanged += skinComboBox1_SelectedIndexChanged;
            // 
            // skinLabel_interface
            // 
            skinLabel_interface.AutoSize = true;
            skinLabel_interface.BackColor = Color.Transparent;
            skinLabel_interface.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_interface.Location = new Point(5, 10);
            skinLabel_interface.Margin = new Padding(4, 0, 4, 0);
            skinLabel_interface.Name = "skinLabel_interface";
            skinLabel_interface.Size = new Size(62, 17);
            skinLabel_interface.TabIndex = 14;
            skinLabel_interface.Text = "Interface:";
            // 
            // skinButton_connect
            // 
            skinButton_connect.BackColor = Color.Transparent;
            skinButton_connect.Location = new Point(61, 235);
            skinButton_connect.Margin = new Padding(4);
            skinButton_connect.Name = "skinButton_connect";
            skinButton_connect.Size = new Size(112, 31);
            skinButton_connect.TabIndex = 13;
            skinButton_connect.Text = "Connect";
            skinButton_connect.UseVisualStyleBackColor = false;
            skinButton_connect.Click += skinButton_connect_Click;
            // 
            // skinButton_tcp_server
            // 
            skinButton_tcp_server.BackColor = Color.Transparent;
            skinButton_tcp_server.Location = new Point(111, 51);
            skinButton_tcp_server.Margin = new Padding(4);
            skinButton_tcp_server.Name = "skinButton_tcp_server";
            skinButton_tcp_server.Size = new Size(88, 29);
            skinButton_tcp_server.TabIndex = 7;
            skinButton_tcp_server.Text = "TCP Server";
            skinButton_tcp_server.UseVisualStyleBackColor = false;
            skinButton_tcp_server.Click += skinButton_tcp_server_Click;
            // 
            // skinButton_net_scan
            // 
            skinButton_net_scan.BackColor = Color.Transparent;
            skinButton_net_scan.Location = new Point(10, 51);
            skinButton_net_scan.Margin = new Padding(4);
            skinButton_net_scan.Name = "skinButton_net_scan";
            skinButton_net_scan.Size = new Size(88, 29);
            skinButton_net_scan.TabIndex = 4;
            skinButton_net_scan.Text = "Scan";
            skinButton_net_scan.UseVisualStyleBackColor = false;
            skinButton_net_scan.Click += skinButton_net_scan_Click;
            // 
            // skinPictureBox_welcom
            // 
            skinPictureBox_welcom.BackColor = Color.Transparent;
            skinPictureBox_welcom.Image = (Image)resources.GetObject("skinPictureBox_welcom.Image");
            skinPictureBox_welcom.Location = new Point(248, 22);
            skinPictureBox_welcom.Margin = new Padding(4);
            skinPictureBox_welcom.Name = "skinPictureBox_welcom";
            skinPictureBox_welcom.Size = new Size(684, 495);
            skinPictureBox_welcom.TabIndex = 15;
            skinPictureBox_welcom.TabStop = false;
            // 
            // skinPanel_USB_Connect
            // 
            skinPanel_USB_Connect.BackColor = Color.Transparent;
            skinPanel_USB_Connect.Controls.Add(skinComboBox_deviceusb_list);
            skinPanel_USB_Connect.Controls.Add(skinLabel_usblist);
            skinPanel_USB_Connect.Location = new Point(18, 481);
            skinPanel_USB_Connect.Margin = new Padding(4);
            skinPanel_USB_Connect.Name = "skinPanel_USB_Connect";
            skinPanel_USB_Connect.Size = new Size(215, 39);
            skinPanel_USB_Connect.TabIndex = 16;
            // 
            // skinComboBox_deviceusb_list
            // 
            skinComboBox_deviceusb_list.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_deviceusb_list.FormattingEnabled = true;
            skinComboBox_deviceusb_list.Location = new Point(82, 8);
            skinComboBox_deviceusb_list.Margin = new Padding(4);
            skinComboBox_deviceusb_list.Name = "skinComboBox_deviceusb_list";
            skinComboBox_deviceusb_list.Size = new Size(119, 23);
            skinComboBox_deviceusb_list.TabIndex = 1;
            skinComboBox_deviceusb_list.MouseClick += skinComboBox_deviceusb_list_MouseClick;
            // 
            // skinLabel_usblist
            // 
            skinLabel_usblist.AutoSize = true;
            skinLabel_usblist.BackColor = Color.Transparent;
            skinLabel_usblist.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_usblist.Location = new Point(16, 10);
            skinLabel_usblist.Margin = new Padding(4, 0, 4, 0);
            skinLabel_usblist.Name = "skinLabel_usblist";
            skinLabel_usblist.Size = new Size(58, 17);
            skinLabel_usblist.TabIndex = 0;
            skinLabel_usblist.Text = "USB List:";
            // 
            // skinPanel1
            // 
            skinPanel1.BackColor = Color.Transparent;
            skinPanel1.BorderStyle = BorderStyle.FixedSingle;
            skinPanel1.Controls.Add(skinButton_fun_wifi);
            skinPanel1.Controls.Add(skinButton_fun_main);
            skinPanel1.Controls.Add(skinButton_tcp_server);
            skinPanel1.Controls.Add(skinButton_net_scan);
            skinPanel1.Location = new Point(18, 345);
            skinPanel1.Margin = new Padding(4);
            skinPanel1.Name = "skinPanel1";
            skinPanel1.Size = new Size(226, 103);
            skinPanel1.TabIndex = 17;
            // 
            // skinButton_fun_wifi
            // 
            skinButton_fun_wifi.BackColor = Color.Transparent;
            skinButton_fun_wifi.Location = new Point(111, 15);
            skinButton_fun_wifi.Margin = new Padding(4);
            skinButton_fun_wifi.Name = "skinButton_fun_wifi";
            skinButton_fun_wifi.Size = new Size(88, 29);
            skinButton_fun_wifi.TabIndex = 1;
            skinButton_fun_wifi.Text = "WIFI Settings";
            skinButton_fun_wifi.UseVisualStyleBackColor = false;
            skinButton_fun_wifi.Click += skinButton_fun_wifi_Click;
            // 
            // skinButton_fun_main
            // 
            skinButton_fun_main.BackColor = Color.Transparent;
            skinButton_fun_main.Location = new Point(10, 15);
            skinButton_fun_main.Margin = new Padding(4);
            skinButton_fun_main.Name = "skinButton_fun_main";
            skinButton_fun_main.Size = new Size(88, 29);
            skinButton_fun_main.TabIndex = 0;
            skinButton_fun_main.Text = "Read/Write";
            skinButton_fun_main.UseVisualStyleBackColor = false;
            skinButton_fun_main.Click += skinButton_fun_main_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.FromArgb(242, 254, 220);
            ClientSize = new Size(945, 707);
            Controls.Add(skinPanel1);
            Controls.Add(skinPanel_USB_Connect);
            Controls.Add(skinPictureBox_welcom);
            Controls.Add(skinPanel_connection);
            Controls.Add(listView_result);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UHF RFID Test Demo V1.1.7（2024.12.23）";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            skinPanel_serialport.ResumeLayout(false);
            skinPanel_serialport.PerformLayout();
            skinPanel_network.ResumeLayout(false);
            skinPanel_network.PerformLayout();
            skinPanel_connection.ResumeLayout(false);
            skinPanel_connection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinPictureBox_welcom).EndInit();
            skinPanel_USB_Connect.ResumeLayout(false);
            skinPanel_USB_Connect.PerformLayout();
            skinPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
