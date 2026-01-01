using CPH_F206.RfidSDK;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    partial class HCWifiWindow
    {
        private TabControl skinTabControl_user;
        private TabPage skinTabPage_http;
        private TabPage skinTabPage_wifi;
        private Button skinButton_http_set;
        private Button skinButton_http_query;
        private TextBox skinWaterTextBox_recv_addr;
        private Label skinLabel2;
        private NumericUpDown skinNumericUpDown_recv_port;
        private Label skinLabel4;
        private Button skinButton_wifi_sta_query;
        private ComboBox skinComboBox_wifi_sta_name;
        private Label skinLabel6;
        private TextBox skinWaterTextBox_wifi_ap_pwd;
        private Label skinLabel5;
        private TextBox skinWaterTextBox_wifi_ap_name;
        private TextBox skinWaterTextBox_wifi_sta_pwd;
        private Label skinLabel7;
        private Button skinButton_wifi_set;
        private Button skinButton_wifi_query;
        private TabPage skinTabPage1;
        private Label skinLabel12;
        private TextBox skinTextBox_wifi_IP;
        private Label skinLabel11;
        private Label skinLabel_wifi_ip_conn_status;
        private Label skinLabel9;
        private Label skinLabel14;
        private TextBox skinTextBox_wifi_gateway;
        private Label skinLabel13;
        private TextBox skinTextBox_wifi_netmask;
        private ComboBox skinComboBox_wifi_dhcp;
        private TextBox skinTextBox_wifi_mac;
        private Label skinLabel15;
        private Button skinButton_wifi_ip_set;
        private Button skinButton_wifi_ip_query;
        private ComboBox skinComboBox_recv_protocol;
        private Label skinLabel1;
        private Label skinLabel_http_port;
        private ComboBox skinComboBox_recv_ip_type;
        private Label skinLabel8;
        private Label skinLabel10;
        private NumericUpDown skinNumericUpDown_recv_heartbeat;

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
            skinTabControl_user = new TabControl();
            skinTabPage_http = new TabPage();
            skinNumericUpDown_recv_heartbeat = new NumericUpDown();
            skinLabel10 = new Label();
            skinComboBox_recv_ip_type = new ComboBox();
            skinLabel8 = new Label();
            skinComboBox_recv_protocol = new ComboBox();
            skinLabel1 = new Label();
            skinButton_http_set = new Button();
            skinButton_http_query = new Button();
            skinWaterTextBox_recv_addr = new TextBox();
            skinLabel2 = new Label();
            skinNumericUpDown_recv_port = new NumericUpDown();
            skinLabel_http_port = new Label();
            skinTabPage_wifi = new TabPage();
            skinButton_wifi_set = new Button();
            skinButton_wifi_query = new Button();
            skinWaterTextBox_wifi_sta_pwd = new TextBox();
            skinLabel7 = new Label();
            skinButton_wifi_sta_query = new Button();
            skinComboBox_wifi_sta_name = new ComboBox();
            skinLabel6 = new Label();
            skinWaterTextBox_wifi_ap_pwd = new TextBox();
            skinLabel5 = new Label();
            skinWaterTextBox_wifi_ap_name = new TextBox();
            skinLabel4 = new Label();
            skinTabPage1 = new TabPage();
            skinButton_wifi_ip_set = new Button();
            skinButton_wifi_ip_query = new Button();
            skinTextBox_wifi_mac = new TextBox();
            skinLabel15 = new Label();
            skinComboBox_wifi_dhcp = new ComboBox();
            skinLabel14 = new Label();
            skinTextBox_wifi_gateway = new TextBox();
            skinLabel13 = new Label();
            skinTextBox_wifi_netmask = new TextBox();
            skinLabel12 = new Label();
            skinTextBox_wifi_IP = new TextBox();
            skinLabel11 = new Label();
            skinLabel_wifi_ip_conn_status = new Label();
            skinLabel9 = new Label();
            skinTabControl_user.SuspendLayout();
            skinTabPage_http.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_recv_heartbeat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_recv_port).BeginInit();
            skinTabPage_wifi.SuspendLayout();
            skinTabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // skinTabControl_user
            // 
            skinTabControl_user.Controls.Add(skinTabPage_http);
            skinTabControl_user.Controls.Add(skinTabPage_wifi);
            skinTabControl_user.Controls.Add(skinTabPage1);
            skinTabControl_user.ItemSize = new Size(70, 36);
            skinTabControl_user.Location = new Point(4, 12);
            skinTabControl_user.Margin = new Padding(4);
            skinTabControl_user.Name = "skinTabControl_user";
            skinTabControl_user.SelectedIndex = 0;
            skinTabControl_user.Size = new Size(679, 480);
            skinTabControl_user.TabIndex = 0;
            // 
            // skinTabPage_http
            // 
            skinTabPage_http.BackColor = Color.White;
            skinTabPage_http.Controls.Add(skinNumericUpDown_recv_heartbeat);
            skinTabPage_http.Controls.Add(skinLabel10);
            skinTabPage_http.Controls.Add(skinComboBox_recv_ip_type);
            skinTabPage_http.Controls.Add(skinLabel8);
            skinTabPage_http.Controls.Add(skinComboBox_recv_protocol);
            skinTabPage_http.Controls.Add(skinLabel1);
            skinTabPage_http.Controls.Add(skinButton_http_set);
            skinTabPage_http.Controls.Add(skinButton_http_query);
            skinTabPage_http.Controls.Add(skinWaterTextBox_recv_addr);
            skinTabPage_http.Controls.Add(skinLabel2);
            skinTabPage_http.Controls.Add(skinNumericUpDown_recv_port);
            skinTabPage_http.Controls.Add(skinLabel_http_port);
            skinTabPage_http.Location = new Point(4, 40);
            skinTabPage_http.Margin = new Padding(4);
            skinTabPage_http.Name = "skinTabPage_http";
            skinTabPage_http.Size = new Size(671, 436);
            skinTabPage_http.TabIndex = 0;
            skinTabPage_http.Text = "Settings";
            // 
            // skinNumericUpDown_recv_heartbeat
            // 
            skinNumericUpDown_recv_heartbeat.Location = new Point(479, 25);
            skinNumericUpDown_recv_heartbeat.Margin = new Padding(4);
            skinNumericUpDown_recv_heartbeat.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            skinNumericUpDown_recv_heartbeat.Name = "skinNumericUpDown_recv_heartbeat";
            skinNumericUpDown_recv_heartbeat.Size = new Size(140, 23);
            skinNumericUpDown_recv_heartbeat.TabIndex = 15;
            skinNumericUpDown_recv_heartbeat.TextAlign = HorizontalAlignment.Center;
            // 
            // skinLabel10
            // 
            skinLabel10.AutoSize = true;
            skinLabel10.BackColor = Color.Transparent;
            skinLabel10.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel10.Location = new Point(392, 25);
            skinLabel10.Margin = new Padding(4, 0, 4, 0);
            skinLabel10.Name = "skinLabel10";
            skinLabel10.Size = new Size(69, 17);
            skinLabel10.TabIndex = 14;
            skinLabel10.Text = "Heartbeat:";
            // 
            // skinComboBox_recv_ip_type
            // 
            skinComboBox_recv_ip_type.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_recv_ip_type.FormattingEnabled = true;
            skinComboBox_recv_ip_type.Items.AddRange(new object[] { "IPv4", "IPv6 (Not currently supported)", "Host Name" });
            skinComboBox_recv_ip_type.Location = new Point(160, 70);
            skinComboBox_recv_ip_type.Margin = new Padding(4);
            skinComboBox_recv_ip_type.Name = "skinComboBox_recv_ip_type";
            skinComboBox_recv_ip_type.Size = new Size(182, 23);
            skinComboBox_recv_ip_type.TabIndex = 13;
            // 
            // skinLabel8
            // 
            skinLabel8.AutoSize = true;
            skinLabel8.BackColor = Color.Transparent;
            skinLabel8.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel8.Location = new Point(52, 73);
            skinLabel8.Margin = new Padding(4, 0, 4, 0);
            skinLabel8.Name = "skinLabel8";
            skinLabel8.Size = new Size(102, 17);
            skinLabel8.TabIndex = 12;
            skinLabel8.Text = "Address format:";
            // 
            // skinComboBox_recv_protocol
            // 
            skinComboBox_recv_protocol.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_recv_protocol.FormattingEnabled = true;
            skinComboBox_recv_protocol.Items.AddRange(new object[] { "TCP Client", "TCP Server", "UDP", "UDP Server", "HTTP" });
            skinComboBox_recv_protocol.Location = new Point(160, 25);
            skinComboBox_recv_protocol.Margin = new Padding(4);
            skinComboBox_recv_protocol.Name = "skinComboBox_recv_protocol";
            skinComboBox_recv_protocol.Size = new Size(182, 23);
            skinComboBox_recv_protocol.TabIndex = 11;
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.Location = new Point(94, 28);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(60, 17);
            skinLabel1.TabIndex = 10;
            skinLabel1.Text = "Protocol:";
            // 
            // skinButton_http_set
            // 
            skinButton_http_set.BackColor = Color.Transparent;
            skinButton_http_set.Location = new Point(318, 395);
            skinButton_http_set.Margin = new Padding(4);
            skinButton_http_set.Name = "skinButton_http_set";
            skinButton_http_set.Size = new Size(75, 25);
            skinButton_http_set.TabIndex = 9;
            skinButton_http_set.Text = "Save";
            skinButton_http_set.UseVisualStyleBackColor = false;
            skinButton_http_set.Click += skinButton_http_set_Click;
            // 
            // skinButton_http_query
            // 
            skinButton_http_query.BackColor = Color.Transparent;
            skinButton_http_query.Location = new Point(160, 396);
            skinButton_http_query.Margin = new Padding(4);
            skinButton_http_query.Name = "skinButton_http_query";
            skinButton_http_query.Size = new Size(75, 25);
            skinButton_http_query.TabIndex = 8;
            skinButton_http_query.Text = "Query";
            skinButton_http_query.UseVisualStyleBackColor = false;
            skinButton_http_query.Click += skinButton_http_query_Click;
            // 
            // skinWaterTextBox_recv_addr
            // 
            skinWaterTextBox_recv_addr.Location = new Point(160, 110);
            skinWaterTextBox_recv_addr.Margin = new Padding(4);
            skinWaterTextBox_recv_addr.Name = "skinWaterTextBox_recv_addr";
            skinWaterTextBox_recv_addr.Size = new Size(462, 23);
            skinWaterTextBox_recv_addr.TabIndex = 5;
            // 
            // skinLabel2
            // 
            skinLabel2.AutoSize = true;
            skinLabel2.BackColor = Color.Transparent;
            skinLabel2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel2.Location = new Point(43, 114);
            skinLabel2.Margin = new Padding(4, 0, 4, 0);
            skinLabel2.Name = "skinLabel2";
            skinLabel2.Size = new Size(111, 17);
            skinLabel2.TabIndex = 4;
            skinLabel2.Text = "Receiver address:";
            // 
            // skinNumericUpDown_recv_port
            // 
            skinNumericUpDown_recv_port.Location = new Point(479, 65);
            skinNumericUpDown_recv_port.Margin = new Padding(4);
            skinNumericUpDown_recv_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            skinNumericUpDown_recv_port.Name = "skinNumericUpDown_recv_port";
            skinNumericUpDown_recv_port.Size = new Size(144, 23);
            skinNumericUpDown_recv_port.TabIndex = 3;
            skinNumericUpDown_recv_port.TextAlign = HorizontalAlignment.Center;
            skinNumericUpDown_recv_port.Value = new decimal(new int[] { 12345, 0, 0, 0 });
            // 
            // skinLabel_http_port
            // 
            skinLabel_http_port.AutoSize = true;
            skinLabel_http_port.BackColor = Color.Transparent;
            skinLabel_http_port.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_http_port.Location = new Point(426, 70);
            skinLabel_http_port.Margin = new Padding(4, 0, 4, 0);
            skinLabel_http_port.Name = "skinLabel_http_port";
            skinLabel_http_port.Size = new Size(35, 17);
            skinLabel_http_port.TabIndex = 2;
            skinLabel_http_port.Text = "Port:";
            // 
            // skinTabPage_wifi
            // 
            skinTabPage_wifi.BackColor = Color.White;
            skinTabPage_wifi.Controls.Add(skinButton_wifi_set);
            skinTabPage_wifi.Controls.Add(skinButton_wifi_query);
            skinTabPage_wifi.Controls.Add(skinWaterTextBox_wifi_sta_pwd);
            skinTabPage_wifi.Controls.Add(skinLabel7);
            skinTabPage_wifi.Controls.Add(skinButton_wifi_sta_query);
            skinTabPage_wifi.Controls.Add(skinComboBox_wifi_sta_name);
            skinTabPage_wifi.Controls.Add(skinLabel6);
            skinTabPage_wifi.Controls.Add(skinWaterTextBox_wifi_ap_pwd);
            skinTabPage_wifi.Controls.Add(skinLabel5);
            skinTabPage_wifi.Controls.Add(skinWaterTextBox_wifi_ap_name);
            skinTabPage_wifi.Controls.Add(skinLabel4);
            skinTabPage_wifi.Location = new Point(4, 40);
            skinTabPage_wifi.Margin = new Padding(4);
            skinTabPage_wifi.Name = "skinTabPage_wifi";
            skinTabPage_wifi.Size = new Size(671, 436);
            skinTabPage_wifi.TabIndex = 1;
            skinTabPage_wifi.Text = "WIFI";
            // 
            // skinButton_wifi_set
            // 
            skinButton_wifi_set.BackColor = Color.Transparent;
            skinButton_wifi_set.Location = new Point(284, 289);
            skinButton_wifi_set.Margin = new Padding(4);
            skinButton_wifi_set.Name = "skinButton_wifi_set";
            skinButton_wifi_set.Size = new Size(75, 25);
            skinButton_wifi_set.TabIndex = 10;
            skinButton_wifi_set.Text = "Save";
            skinButton_wifi_set.UseVisualStyleBackColor = false;
            skinButton_wifi_set.Click += skinButton_wifi_set_Click;
            // 
            // skinButton_wifi_query
            // 
            skinButton_wifi_query.BackColor = Color.Transparent;
            skinButton_wifi_query.Location = new Point(163, 289);
            skinButton_wifi_query.Margin = new Padding(4);
            skinButton_wifi_query.Name = "skinButton_wifi_query";
            skinButton_wifi_query.Size = new Size(75, 25);
            skinButton_wifi_query.TabIndex = 9;
            skinButton_wifi_query.Text = "Query";
            skinButton_wifi_query.UseVisualStyleBackColor = false;
            skinButton_wifi_query.Click += skinButton_wifi_query_Click;
            // 
            // skinWaterTextBox_wifi_sta_pwd
            // 
            skinWaterTextBox_wifi_sta_pwd.Location = new Point(163, 194);
            skinWaterTextBox_wifi_sta_pwd.Margin = new Padding(4);
            skinWaterTextBox_wifi_sta_pwd.Name = "skinWaterTextBox_wifi_sta_pwd";
            skinWaterTextBox_wifi_sta_pwd.Size = new Size(172, 23);
            skinWaterTextBox_wifi_sta_pwd.TabIndex = 8;
            // 
            // skinLabel7
            // 
            skinLabel7.AutoSize = true;
            skinLabel7.BackColor = Color.Transparent;
            skinLabel7.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel7.Location = new Point(41, 195);
            skinLabel7.Margin = new Padding(4, 0, 4, 0);
            skinLabel7.Name = "skinLabel7";
            skinLabel7.Size = new Size(97, 17);
            skinLabel7.TabIndex = 7;
            skinLabel7.Text = "WIFI Password:";
            // 
            // skinButton_wifi_sta_query
            // 
            skinButton_wifi_sta_query.BackColor = Color.Transparent;
            skinButton_wifi_sta_query.Location = new Point(383, 149);
            skinButton_wifi_sta_query.Margin = new Padding(4);
            skinButton_wifi_sta_query.Name = "skinButton_wifi_sta_query";
            skinButton_wifi_sta_query.Size = new Size(75, 25);
            skinButton_wifi_sta_query.TabIndex = 6;
            skinButton_wifi_sta_query.Text = "Refresh";
            skinButton_wifi_sta_query.UseVisualStyleBackColor = false;
            // 
            // skinComboBox_wifi_sta_name
            // 
            skinComboBox_wifi_sta_name.FormattingEnabled = true;
            skinComboBox_wifi_sta_name.Location = new Point(163, 149);
            skinComboBox_wifi_sta_name.Margin = new Padding(4);
            skinComboBox_wifi_sta_name.Name = "skinComboBox_wifi_sta_name";
            skinComboBox_wifi_sta_name.Size = new Size(214, 23);
            skinComboBox_wifi_sta_name.TabIndex = 5;
            // 
            // skinLabel6
            // 
            skinLabel6.AutoSize = true;
            skinLabel6.BackColor = Color.Transparent;
            skinLabel6.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel6.Location = new Point(59, 151);
            skinLabel6.Margin = new Padding(4, 0, 4, 0);
            skinLabel6.Name = "skinLabel6";
            skinLabel6.Size = new Size(76, 17);
            skinLabel6.TabIndex = 4;
            skinLabel6.Text = "WIFI Name:";
            // 
            // skinWaterTextBox_wifi_ap_pwd
            // 
            skinWaterTextBox_wifi_ap_pwd.Location = new Point(163, 98);
            skinWaterTextBox_wifi_ap_pwd.Margin = new Padding(4);
            skinWaterTextBox_wifi_ap_pwd.Name = "skinWaterTextBox_wifi_ap_pwd";
            skinWaterTextBox_wifi_ap_pwd.Size = new Size(172, 23);
            skinWaterTextBox_wifi_ap_pwd.TabIndex = 3;
            // 
            // skinLabel5
            // 
            skinLabel5.AutoSize = true;
            skinLabel5.BackColor = Color.Transparent;
            skinLabel5.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel5.Location = new Point(42, 100);
            skinLabel5.Margin = new Padding(4, 0, 4, 0);
            skinLabel5.Name = "skinLabel5";
            skinLabel5.Size = new Size(93, 17);
            skinLabel5.TabIndex = 2;
            skinLabel5.Text = "Hotspot Code:";
            // 
            // skinWaterTextBox_wifi_ap_name
            // 
            skinWaterTextBox_wifi_ap_name.Location = new Point(163, 49);
            skinWaterTextBox_wifi_ap_name.Margin = new Padding(4);
            skinWaterTextBox_wifi_ap_name.Name = "skinWaterTextBox_wifi_ap_name";
            skinWaterTextBox_wifi_ap_name.Size = new Size(172, 23);
            skinWaterTextBox_wifi_ap_name.TabIndex = 1;
            // 
            // skinLabel4
            // 
            skinLabel4.AutoSize = true;
            skinLabel4.BackColor = Color.Transparent;
            skinLabel4.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel4.Location = new Point(38, 49);
            skinLabel4.Margin = new Padding(4, 0, 4, 0);
            skinLabel4.Name = "skinLabel4";
            skinLabel4.Size = new Size(97, 17);
            skinLabel4.TabIndex = 0;
            skinLabel4.Text = "Hotspot Name:";
            // 
            // skinTabPage1
            // 
            skinTabPage1.BackColor = Color.White;
            skinTabPage1.Controls.Add(skinButton_wifi_ip_set);
            skinTabPage1.Controls.Add(skinButton_wifi_ip_query);
            skinTabPage1.Controls.Add(skinTextBox_wifi_mac);
            skinTabPage1.Controls.Add(skinLabel15);
            skinTabPage1.Controls.Add(skinComboBox_wifi_dhcp);
            skinTabPage1.Controls.Add(skinLabel14);
            skinTabPage1.Controls.Add(skinTextBox_wifi_gateway);
            skinTabPage1.Controls.Add(skinLabel13);
            skinTabPage1.Controls.Add(skinTextBox_wifi_netmask);
            skinTabPage1.Controls.Add(skinLabel12);
            skinTabPage1.Controls.Add(skinTextBox_wifi_IP);
            skinTabPage1.Controls.Add(skinLabel11);
            skinTabPage1.Controls.Add(skinLabel_wifi_ip_conn_status);
            skinTabPage1.Controls.Add(skinLabel9);
            skinTabPage1.Location = new Point(4, 40);
            skinTabPage1.Margin = new Padding(4);
            skinTabPage1.Name = "skinTabPage1";
            skinTabPage1.Size = new Size(671, 436);
            skinTabPage1.TabIndex = 2;
            skinTabPage1.Text = "IP Settings";
            // 
            // skinButton_wifi_ip_set
            // 
            skinButton_wifi_ip_set.BackColor = Color.Transparent;
            skinButton_wifi_ip_set.Location = new Point(357, 376);
            skinButton_wifi_ip_set.Margin = new Padding(4);
            skinButton_wifi_ip_set.Name = "skinButton_wifi_ip_set";
            skinButton_wifi_ip_set.Size = new Size(88, 29);
            skinButton_wifi_ip_set.TabIndex = 13;
            skinButton_wifi_ip_set.Text = "Save";
            skinButton_wifi_ip_set.UseVisualStyleBackColor = false;
            skinButton_wifi_ip_set.Click += skinButton_wifi_ip_set_Click;
            // 
            // skinButton_wifi_ip_query
            // 
            skinButton_wifi_ip_query.BackColor = Color.Transparent;
            skinButton_wifi_ip_query.Location = new Point(224, 376);
            skinButton_wifi_ip_query.Margin = new Padding(4);
            skinButton_wifi_ip_query.Name = "skinButton_wifi_ip_query";
            skinButton_wifi_ip_query.Size = new Size(88, 29);
            skinButton_wifi_ip_query.TabIndex = 12;
            skinButton_wifi_ip_query.Text = "Query";
            skinButton_wifi_ip_query.UseVisualStyleBackColor = false;
            skinButton_wifi_ip_query.Click += skinButton_wifi_ip_query_Click;
            // 
            // skinTextBox_wifi_mac
            // 
            skinTextBox_wifi_mac.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_wifi_mac.Location = new Point(220, 296);
            skinTextBox_wifi_mac.Margin = new Padding(0);
            skinTextBox_wifi_mac.MinimumSize = new Size(33, 28);
            skinTextBox_wifi_mac.Name = "skinTextBox_wifi_mac";
            skinTextBox_wifi_mac.ReadOnly = true;
            skinTextBox_wifi_mac.Size = new Size(223, 28);
            skinTextBox_wifi_mac.TabIndex = 11;
            // 
            // skinLabel15
            // 
            skinLabel15.AutoSize = true;
            skinLabel15.BackColor = Color.Transparent;
            skinLabel15.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel15.Location = new Point(122, 301);
            skinLabel15.Margin = new Padding(4, 0, 4, 0);
            skinLabel15.Name = "skinLabel15";
            skinLabel15.Size = new Size(91, 17);
            skinLabel15.TabIndex = 10;
            skinLabel15.Text = "MAC Address:";
            // 
            // skinComboBox_wifi_dhcp
            // 
            skinComboBox_wifi_dhcp.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_wifi_dhcp.FormattingEnabled = true;
            skinComboBox_wifi_dhcp.Items.AddRange(new object[] { "Manual setup (STATIC)", "Automatic acquisition (DHCP)" });
            skinComboBox_wifi_dhcp.Location = new Point(220, 76);
            skinComboBox_wifi_dhcp.Margin = new Padding(4);
            skinComboBox_wifi_dhcp.Name = "skinComboBox_wifi_dhcp";
            skinComboBox_wifi_dhcp.Size = new Size(215, 23);
            skinComboBox_wifi_dhcp.TabIndex = 9;
            skinComboBox_wifi_dhcp.SelectedIndexChanged += skinComboBox_wifi_dhcp_SelectedIndexChanged;
            // 
            // skinLabel14
            // 
            skinLabel14.AutoSize = true;
            skinLabel14.BackColor = Color.Transparent;
            skinLabel14.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel14.Location = new Point(46, 82);
            skinLabel14.Margin = new Padding(4, 0, 4, 0);
            skinLabel14.Name = "skinLabel14";
            skinLabel14.Size = new Size(167, 17);
            skinLabel14.TabIndex = 8;
            skinLabel14.Text = "How to obtain the address:";
            // 
            // skinTextBox_wifi_gateway
            // 
            skinTextBox_wifi_gateway.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_wifi_gateway.Location = new Point(220, 237);
            skinTextBox_wifi_gateway.Margin = new Padding(0);
            skinTextBox_wifi_gateway.MinimumSize = new Size(33, 28);
            skinTextBox_wifi_gateway.Name = "skinTextBox_wifi_gateway";
            skinTextBox_wifi_gateway.Size = new Size(223, 28);
            skinTextBox_wifi_gateway.TabIndex = 7;
            // 
            // skinLabel13
            // 
            skinLabel13.AutoSize = true;
            skinLabel13.BackColor = Color.Transparent;
            skinLabel13.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel13.Location = new Point(153, 242);
            skinLabel13.Margin = new Padding(4, 0, 4, 0);
            skinLabel13.Name = "skinLabel13";
            skinLabel13.Size = new Size(60, 17);
            skinLabel13.TabIndex = 6;
            skinLabel13.Text = "Gateway:";
            // 
            // skinTextBox_wifi_netmask
            // 
            skinTextBox_wifi_netmask.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_wifi_netmask.Location = new Point(220, 184);
            skinTextBox_wifi_netmask.Margin = new Padding(0);
            skinTextBox_wifi_netmask.MinimumSize = new Size(33, 28);
            skinTextBox_wifi_netmask.Name = "skinTextBox_wifi_netmask";
            skinTextBox_wifi_netmask.Size = new Size(225, 28);
            skinTextBox_wifi_netmask.TabIndex = 5;
            // 
            // skinLabel12
            // 
            skinLabel12.AutoSize = true;
            skinLabel12.BackColor = Color.Transparent;
            skinLabel12.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel12.Location = new Point(127, 189);
            skinLabel12.Margin = new Padding(4, 0, 4, 0);
            skinLabel12.Name = "skinLabel12";
            skinLabel12.Size = new Size(86, 17);
            skinLabel12.TabIndex = 4;
            skinLabel12.Text = "Subnet mask:";
            // 
            // skinTextBox_wifi_IP
            // 
            skinTextBox_wifi_IP.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_wifi_IP.Location = new Point(220, 127);
            skinTextBox_wifi_IP.Margin = new Padding(0);
            skinTextBox_wifi_IP.MinimumSize = new Size(33, 28);
            skinTextBox_wifi_IP.Name = "skinTextBox_wifi_IP";
            skinTextBox_wifi_IP.Size = new Size(225, 28);
            skinTextBox_wifi_IP.TabIndex = 3;
            // 
            // skinLabel11
            // 
            skinLabel11.AutoSize = true;
            skinLabel11.BackColor = Color.Transparent;
            skinLabel11.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel11.Location = new Point(139, 132);
            skinLabel11.Margin = new Padding(4, 0, 4, 0);
            skinLabel11.Name = "skinLabel11";
            skinLabel11.Size = new Size(74, 17);
            skinLabel11.TabIndex = 2;
            skinLabel11.Text = "IP Address:";
            // 
            // skinLabel_wifi_ip_conn_status
            // 
            skinLabel_wifi_ip_conn_status.AutoSize = true;
            skinLabel_wifi_ip_conn_status.BackColor = Color.Transparent;
            skinLabel_wifi_ip_conn_status.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_wifi_ip_conn_status.Location = new Point(220, 34);
            skinLabel_wifi_ip_conn_status.Margin = new Padding(4, 0, 4, 0);
            skinLabel_wifi_ip_conn_status.Name = "skinLabel_wifi_ip_conn_status";
            skinLabel_wifi_ip_conn_status.Size = new Size(94, 17);
            skinLabel_wifi_ip_conn_status.TabIndex = 1;
            skinLabel_wifi_ip_conn_status.Text = "Not connected";
            // 
            // skinLabel9
            // 
            skinLabel9.AutoSize = true;
            skinLabel9.BackColor = Color.Transparent;
            skinLabel9.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel9.Location = new Point(71, 34);
            skinLabel9.Margin = new Padding(4, 0, 4, 0);
            skinLabel9.Name = "skinLabel9";
            skinLabel9.Size = new Size(142, 17);
            skinLabel9.TabIndex = 0;
            skinLabel9.Text = "WIFI connection status:";
            // 
            // HCWifiWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(684, 494);
            Controls.Add(skinTabControl_user);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "HCWifiWindow";
            Text = "HCWifiWindow";
            skinTabControl_user.ResumeLayout(false);
            skinTabPage_http.ResumeLayout(false);
            skinTabPage_http.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_recv_heartbeat).EndInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_recv_port).EndInit();
            skinTabPage_wifi.ResumeLayout(false);
            skinTabPage_wifi.PerformLayout();
            skinTabPage1.ResumeLayout(false);
            skinTabPage1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}