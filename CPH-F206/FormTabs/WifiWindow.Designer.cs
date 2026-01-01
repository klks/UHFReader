using CPH_F206.RfidSDK;
using CPH_F206.FormTabs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    partial class WifiWindow
    {
        private TabControl skinTabControl_wifi;
        private TabPage skinTabPage_connect;
        private TabPage skinTabPage_AP;
        private TabPage skinTabPage_wifi_connect;
        private CheckBox skinCheckBox_AP_Enable;
        private Label skinLabel1;
        private TextBox skinTextBox_AP_SSID;
        private Label skinLabel2;
        private TextBox skinTextBox_AP_Passwd;
        private Label skinLabel4;
        private ComboBox skinComboBox_AP_Encrypt;
        private ComboBox skinComboBox_AP_Channel;
        private Label skinLabel3;
        private Button skinButton_AP_Set;
        private Button skinButton_AP_Query;
        private ComboBox skinComboBox_conn_protocol;
        private Label skinLabel5;
        private Button skinButton_Conn_Query;
        private TextBox skinTextBox_Conn_Port;
        private Label skinLabel8;
        private Label skinLabel7;
        private Button skinButton_Conn_Set;
        private Label skinLabel_sta_name;
        private Button skinButton_sta_scan;
        private Button skinButton_sta_set;
        private Button skinButton_sta_query;
        private Label skinLabel9;
        private TextBox skinTextBox_sta_passwd;
        private TextBox skinTextBox_sta_ssid;
        private Label label1;
        private ComboBox skinComboBox_conn_ipmode;
        private Label skinLabel10;
        private CheckBox skinCheckBox_sta_enable;
        private TextBox skinTextBox_sta_baseid;
        private Label skinLabel11;
        private ComboBox skinComboBox_sta_ip_mode;
        private Label skinLabel_sta_get_ip_mode;
        private Label skinLabel12;
        private Label skinLabelstaMask;
        private TextBox skinTextBox_sta_ip_netmask;
        private TextBox skinTextBox_sta_ip_gateway;
        private TextBox skinTextBox_sta_ip;
        private Label skinLabel_sta_ip;
        private TextBox skinTextBox_Conn_IP;
        private Label skinLabel13;
        private TextBox skinTextBox_net_local_port;
        private Label skinLabel14;

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
            skinTabControl_wifi = new TabControl();
            skinTabPage_connect = new TabPage();
            skinLabel14 = new Label();
            skinLabel13 = new Label();
            skinTextBox_Conn_IP = new TextBox();
            skinComboBox_conn_ipmode = new ComboBox();
            skinLabel10 = new Label();
            label1 = new Label();
            skinButton_Conn_Set = new Button();
            skinButton_Conn_Query = new Button();
            skinTextBox_net_local_port = new TextBox();
            skinTextBox_Conn_Port = new TextBox();
            skinLabel8 = new Label();
            skinLabel7 = new Label();
            skinComboBox_conn_protocol = new ComboBox();
            skinLabel5 = new Label();
            skinTabPage_AP = new TabPage();
            skinButton_AP_Set = new Button();
            skinButton_AP_Query = new Button();
            skinLabel4 = new Label();
            skinComboBox_AP_Encrypt = new ComboBox();
            skinComboBox_AP_Channel = new ComboBox();
            skinCheckBox_AP_Enable = new CheckBox();
            skinLabel3 = new Label();
            skinLabel2 = new Label();
            skinLabel1 = new Label();
            skinTextBox_AP_Passwd = new TextBox();
            skinTextBox_AP_SSID = new TextBox();
            skinTabPage_wifi_connect = new TabPage();
            skinLabel12 = new Label();
            skinLabelstaMask = new Label();
            skinTextBox_sta_ip_netmask = new TextBox();
            skinTextBox_sta_ip_gateway = new TextBox();
            skinTextBox_sta_ip = new TextBox();
            skinLabel_sta_ip = new Label();
            skinComboBox_sta_ip_mode = new ComboBox();
            skinLabel_sta_get_ip_mode = new Label();
            skinCheckBox_sta_enable = new CheckBox();
            skinButton_sta_set = new Button();
            skinButton_sta_query = new Button();
            skinLabel9 = new Label();
            skinTextBox_sta_passwd = new TextBox();
            skinTextBox_sta_baseid = new TextBox();
            skinLabel11 = new Label();
            skinTextBox_sta_ssid = new TextBox();
            skinLabel_sta_name = new Label();
            skinButton_sta_scan = new Button();
            skinTabControl_wifi.SuspendLayout();
            skinTabPage_connect.SuspendLayout();
            skinTabPage_AP.SuspendLayout();
            skinTabPage_wifi_connect.SuspendLayout();
            SuspendLayout();
            // 
            // skinTabControl_wifi
            // 
            skinTabControl_wifi.Controls.Add(skinTabPage_connect);
            skinTabControl_wifi.Controls.Add(skinTabPage_AP);
            skinTabControl_wifi.Controls.Add(skinTabPage_wifi_connect);
            skinTabControl_wifi.ItemSize = new Size(70, 36);
            skinTabControl_wifi.Location = new Point(4, 8);
            skinTabControl_wifi.Margin = new Padding(4);
            skinTabControl_wifi.Name = "skinTabControl_wifi";
            skinTabControl_wifi.SelectedIndex = 0;
            skinTabControl_wifi.Size = new Size(681, 474);
            skinTabControl_wifi.TabIndex = 0;
            // 
            // skinTabPage_connect
            // 
            skinTabPage_connect.BackColor = Color.White;
            skinTabPage_connect.Controls.Add(skinLabel14);
            skinTabPage_connect.Controls.Add(skinLabel13);
            skinTabPage_connect.Controls.Add(skinTextBox_Conn_IP);
            skinTabPage_connect.Controls.Add(skinComboBox_conn_ipmode);
            skinTabPage_connect.Controls.Add(skinLabel10);
            skinTabPage_connect.Controls.Add(label1);
            skinTabPage_connect.Controls.Add(skinButton_Conn_Set);
            skinTabPage_connect.Controls.Add(skinButton_Conn_Query);
            skinTabPage_connect.Controls.Add(skinTextBox_net_local_port);
            skinTabPage_connect.Controls.Add(skinTextBox_Conn_Port);
            skinTabPage_connect.Controls.Add(skinLabel8);
            skinTabPage_connect.Controls.Add(skinLabel7);
            skinTabPage_connect.Controls.Add(skinComboBox_conn_protocol);
            skinTabPage_connect.Controls.Add(skinLabel5);
            skinTabPage_connect.Location = new Point(4, 40);
            skinTabPage_connect.Margin = new Padding(4);
            skinTabPage_connect.Name = "skinTabPage_connect";
            skinTabPage_connect.Size = new Size(673, 430);
            skinTabPage_connect.TabIndex = 0;
            skinTabPage_connect.Text = "Connection";
            // 
            // skinLabel14
            // 
            skinLabel14.AutoSize = true;
            skinLabel14.BackColor = Color.Transparent;
            skinLabel14.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel14.Location = new Point(215, 235);
            skinLabel14.Margin = new Padding(4, 0, 4, 0);
            skinLabel14.Name = "skinLabel14";
            skinLabel14.Size = new Size(359, 34);
            skinLabel14.TabIndex = 12;
            skinLabel14.Text = "(TCP Client: the port used to receive data on the server side;\r\nUDP: the port used by the peer to receive data)";
            // 
            // skinLabel13
            // 
            skinLabel13.AutoSize = true;
            skinLabel13.BackColor = Color.Transparent;
            skinLabel13.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel13.Location = new Point(125, 298);
            skinLabel13.Margin = new Padding(4, 0, 4, 0);
            skinLabel13.Name = "skinLabel13";
            skinLabel13.Size = new Size(72, 17);
            skinLabel13.TabIndex = 11;
            skinLabel13.Text = "Listen Port:";
            // 
            // skinTextBox_Conn_IP
            // 
            skinTextBox_Conn_IP.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_Conn_IP.Location = new Point(215, 156);
            skinTextBox_Conn_IP.Margin = new Padding(0);
            skinTextBox_Conn_IP.MinimumSize = new Size(33, 28);
            skinTextBox_Conn_IP.Name = "skinTextBox_Conn_IP";
            skinTextBox_Conn_IP.Size = new Size(436, 28);
            skinTextBox_Conn_IP.TabIndex = 10;
            skinTextBox_Conn_IP.Text = "192.168.3.12";
            // 
            // skinComboBox_conn_ipmode
            // 
            skinComboBox_conn_ipmode.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_conn_ipmode.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_conn_ipmode.FormattingEnabled = true;
            skinComboBox_conn_ipmode.Items.AddRange(new object[] { "IPV4", "IPV6", "Host" });
            skinComboBox_conn_ipmode.Location = new Point(220, 111);
            skinComboBox_conn_ipmode.Margin = new Padding(4);
            skinComboBox_conn_ipmode.Name = "skinComboBox_conn_ipmode";
            skinComboBox_conn_ipmode.Size = new Size(215, 24);
            skinComboBox_conn_ipmode.TabIndex = 9;
            // 
            // skinLabel10
            // 
            skinLabel10.AutoSize = true;
            skinLabel10.BackColor = Color.Transparent;
            skinLabel10.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel10.Location = new Point(114, 113);
            skinLabel10.Margin = new Padding(4, 0, 4, 0);
            skinLabel10.Name = "skinLabel10";
            skinLabel10.Size = new Size(88, 17);
            skinLabel10.TabIndex = 8;
            skinLabel10.Text = "Address type:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Gold;
            label1.Location = new Point(222, 379);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(303, 15);
            label1.TabIndex = 7;
            label1.Text = "(After setup, the tag's data will be transmitted via Wi-Fi.)";
            // 
            // skinButton_Conn_Set
            // 
            skinButton_Conn_Set.BackColor = Color.Transparent;
            skinButton_Conn_Set.Location = new Point(354, 341);
            skinButton_Conn_Set.Margin = new Padding(4);
            skinButton_Conn_Set.Name = "skinButton_Conn_Set";
            skinButton_Conn_Set.Size = new Size(88, 29);
            skinButton_Conn_Set.TabIndex = 6;
            skinButton_Conn_Set.Text = "Save";
            skinButton_Conn_Set.UseVisualStyleBackColor = false;
            skinButton_Conn_Set.Click += skinButton_Conn_Set_Click;
            // 
            // skinButton_Conn_Query
            // 
            skinButton_Conn_Query.BackColor = Color.Transparent;
            skinButton_Conn_Query.Location = new Point(222, 341);
            skinButton_Conn_Query.Margin = new Padding(4);
            skinButton_Conn_Query.Name = "skinButton_Conn_Query";
            skinButton_Conn_Query.Size = new Size(88, 29);
            skinButton_Conn_Query.TabIndex = 5;
            skinButton_Conn_Query.Text = "Query";
            skinButton_Conn_Query.UseVisualStyleBackColor = false;
            skinButton_Conn_Query.Click += skinButton_Conn_Query_Click;
            // 
            // skinTextBox_net_local_port
            // 
            skinTextBox_net_local_port.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_net_local_port.Location = new Point(215, 204);
            skinTextBox_net_local_port.Margin = new Padding(0);
            skinTextBox_net_local_port.MinimumSize = new Size(33, 28);
            skinTextBox_net_local_port.Name = "skinTextBox_net_local_port";
            skinTextBox_net_local_port.Size = new Size(147, 28);
            skinTextBox_net_local_port.TabIndex = 4;
            skinTextBox_net_local_port.Text = "12345";
            // 
            // skinTextBox_Conn_Port
            // 
            skinTextBox_Conn_Port.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_Conn_Port.Location = new Point(215, 293);
            skinTextBox_Conn_Port.Margin = new Padding(0);
            skinTextBox_Conn_Port.MinimumSize = new Size(33, 28);
            skinTextBox_Conn_Port.Name = "skinTextBox_Conn_Port";
            skinTextBox_Conn_Port.Size = new Size(95, 28);
            skinTextBox_Conn_Port.TabIndex = 4;
            skinTextBox_Conn_Port.Text = "12345";
            // 
            // skinLabel8
            // 
            skinLabel8.AutoSize = true;
            skinLabel8.BackColor = Color.Transparent;
            skinLabel8.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel8.Location = new Point(162, 211);
            skinLabel8.Margin = new Padding(4, 0, 4, 0);
            skinLabel8.Name = "skinLabel8";
            skinLabel8.Size = new Size(35, 17);
            skinLabel8.TabIndex = 3;
            skinLabel8.Text = "Port:";
            // 
            // skinLabel7
            // 
            skinLabel7.AutoSize = true;
            skinLabel7.BackColor = Color.Transparent;
            skinLabel7.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel7.Location = new Point(138, 161);
            skinLabel7.Margin = new Padding(4, 0, 4, 0);
            skinLabel7.Name = "skinLabel7";
            skinLabel7.Size = new Size(59, 17);
            skinLabel7.TabIndex = 3;
            skinLabel7.Text = "Address:";
            // 
            // skinComboBox_conn_protocol
            // 
            skinComboBox_conn_protocol.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_conn_protocol.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_conn_protocol.FormattingEnabled = true;
            skinComboBox_conn_protocol.Location = new Point(220, 44);
            skinComboBox_conn_protocol.Margin = new Padding(4);
            skinComboBox_conn_protocol.Name = "skinComboBox_conn_protocol";
            skinComboBox_conn_protocol.Size = new Size(215, 24);
            skinComboBox_conn_protocol.TabIndex = 1;
            // 
            // skinLabel5
            // 
            skinLabel5.AutoSize = true;
            skinLabel5.BackColor = Color.Transparent;
            skinLabel5.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel5.Location = new Point(137, 49);
            skinLabel5.Margin = new Padding(4, 0, 4, 0);
            skinLabel5.Name = "skinLabel5";
            skinLabel5.Size = new Size(60, 17);
            skinLabel5.TabIndex = 0;
            skinLabel5.Text = "Protocol:";
            // 
            // skinTabPage_AP
            // 
            skinTabPage_AP.BackColor = Color.White;
            skinTabPage_AP.Controls.Add(skinButton_AP_Set);
            skinTabPage_AP.Controls.Add(skinButton_AP_Query);
            skinTabPage_AP.Controls.Add(skinLabel4);
            skinTabPage_AP.Controls.Add(skinComboBox_AP_Encrypt);
            skinTabPage_AP.Controls.Add(skinComboBox_AP_Channel);
            skinTabPage_AP.Controls.Add(skinCheckBox_AP_Enable);
            skinTabPage_AP.Controls.Add(skinLabel3);
            skinTabPage_AP.Controls.Add(skinLabel2);
            skinTabPage_AP.Controls.Add(skinLabel1);
            skinTabPage_AP.Controls.Add(skinTextBox_AP_Passwd);
            skinTabPage_AP.Controls.Add(skinTextBox_AP_SSID);
            skinTabPage_AP.Location = new Point(4, 40);
            skinTabPage_AP.Margin = new Padding(4);
            skinTabPage_AP.Name = "skinTabPage_AP";
            skinTabPage_AP.Size = new Size(673, 430);
            skinTabPage_AP.TabIndex = 1;
            skinTabPage_AP.Text = "WIFI Hotspot";
            // 
            // skinButton_AP_Set
            // 
            skinButton_AP_Set.BackColor = Color.Transparent;
            skinButton_AP_Set.Location = new Point(335, 281);
            skinButton_AP_Set.Margin = new Padding(4);
            skinButton_AP_Set.Name = "skinButton_AP_Set";
            skinButton_AP_Set.Size = new Size(88, 29);
            skinButton_AP_Set.TabIndex = 6;
            skinButton_AP_Set.Text = "Save";
            skinButton_AP_Set.UseVisualStyleBackColor = false;
            skinButton_AP_Set.Click += skinButton_AP_Set_Click;
            // 
            // skinButton_AP_Query
            // 
            skinButton_AP_Query.BackColor = Color.Transparent;
            skinButton_AP_Query.Location = new Point(206, 281);
            skinButton_AP_Query.Margin = new Padding(4);
            skinButton_AP_Query.Name = "skinButton_AP_Query";
            skinButton_AP_Query.Size = new Size(88, 29);
            skinButton_AP_Query.TabIndex = 5;
            skinButton_AP_Query.Text = "Query";
            skinButton_AP_Query.UseVisualStyleBackColor = false;
            skinButton_AP_Query.Click += skinButton_AP_Query_Click;
            // 
            // skinLabel4
            // 
            skinLabel4.AutoSize = true;
            skinLabel4.BackColor = Color.Transparent;
            skinLabel4.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel4.Location = new Point(117, 219);
            skinLabel4.Margin = new Padding(4, 0, 4, 0);
            skinLabel4.Name = "skinLabel4";
            skinLabel4.Size = new Size(72, 17);
            skinLabel4.TabIndex = 4;
            skinLabel4.Text = "Encryption:";
            // 
            // skinComboBox_AP_Encrypt
            // 
            skinComboBox_AP_Encrypt.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_AP_Encrypt.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_AP_Encrypt.FormattingEnabled = true;
            skinComboBox_AP_Encrypt.Location = new Point(206, 212);
            skinComboBox_AP_Encrypt.Margin = new Padding(4);
            skinComboBox_AP_Encrypt.Name = "skinComboBox_AP_Encrypt";
            skinComboBox_AP_Encrypt.Size = new Size(215, 24);
            skinComboBox_AP_Encrypt.TabIndex = 3;
            // 
            // skinComboBox_AP_Channel
            // 
            skinComboBox_AP_Channel.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_AP_Channel.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_AP_Channel.FormattingEnabled = true;
            skinComboBox_AP_Channel.Location = new Point(206, 172);
            skinComboBox_AP_Channel.Margin = new Padding(4);
            skinComboBox_AP_Channel.Name = "skinComboBox_AP_Channel";
            skinComboBox_AP_Channel.Size = new Size(215, 24);
            skinComboBox_AP_Channel.TabIndex = 3;
            // 
            // skinCheckBox_AP_Enable
            // 
            skinCheckBox_AP_Enable.AutoSize = true;
            skinCheckBox_AP_Enable.BackColor = Color.Transparent;
            skinCheckBox_AP_Enable.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinCheckBox_AP_Enable.Location = new Point(211, 30);
            skinCheckBox_AP_Enable.Margin = new Padding(4);
            skinCheckBox_AP_Enable.Name = "skinCheckBox_AP_Enable";
            skinCheckBox_AP_Enable.Size = new Size(115, 21);
            skinCheckBox_AP_Enable.TabIndex = 2;
            skinCheckBox_AP_Enable.Text = "Enable hotspot";
            skinCheckBox_AP_Enable.UseVisualStyleBackColor = false;
            // 
            // skinLabel3
            // 
            skinLabel3.AutoSize = true;
            skinLabel3.BackColor = Color.Transparent;
            skinLabel3.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel3.Location = new Point(83, 176);
            skinLabel3.Margin = new Padding(4, 0, 4, 0);
            skinLabel3.Name = "skinLabel3";
            skinLabel3.Size = new Size(106, 17);
            skinLabel3.TabIndex = 1;
            skinLabel3.Text = "Channel number:";
            // 
            // skinLabel2
            // 
            skinLabel2.AutoSize = true;
            skinLabel2.BackColor = Color.Transparent;
            skinLabel2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel2.Location = new Point(71, 134);
            skinLabel2.Margin = new Padding(4, 0, 4, 0);
            skinLabel2.Name = "skinLabel2";
            skinLabel2.Size = new Size(118, 17);
            skinLabel2.TabIndex = 1;
            skinLabel2.Text = "Hotspot Password:";
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.Location = new Point(92, 89);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(97, 17);
            skinLabel1.TabIndex = 1;
            skinLabel1.Text = "Hotspot Name:";
            // 
            // skinTextBox_AP_Passwd
            // 
            skinTextBox_AP_Passwd.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_AP_Passwd.Location = new Point(206, 129);
            skinTextBox_AP_Passwd.Margin = new Padding(0);
            skinTextBox_AP_Passwd.MinimumSize = new Size(33, 28);
            skinTextBox_AP_Passwd.Name = "skinTextBox_AP_Passwd";
            skinTextBox_AP_Passwd.Size = new Size(428, 28);
            skinTextBox_AP_Passwd.TabIndex = 0;
            // 
            // skinTextBox_AP_SSID
            // 
            skinTextBox_AP_SSID.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_AP_SSID.Location = new Point(206, 84);
            skinTextBox_AP_SSID.Margin = new Padding(0);
            skinTextBox_AP_SSID.MinimumSize = new Size(33, 28);
            skinTextBox_AP_SSID.Name = "skinTextBox_AP_SSID";
            skinTextBox_AP_SSID.Size = new Size(428, 28);
            skinTextBox_AP_SSID.TabIndex = 0;
            // 
            // skinTabPage_wifi_connect
            // 
            skinTabPage_wifi_connect.BackColor = Color.White;
            skinTabPage_wifi_connect.Controls.Add(skinLabel12);
            skinTabPage_wifi_connect.Controls.Add(skinLabelstaMask);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_ip_netmask);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_ip_gateway);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_ip);
            skinTabPage_wifi_connect.Controls.Add(skinLabel_sta_ip);
            skinTabPage_wifi_connect.Controls.Add(skinComboBox_sta_ip_mode);
            skinTabPage_wifi_connect.Controls.Add(skinLabel_sta_get_ip_mode);
            skinTabPage_wifi_connect.Controls.Add(skinCheckBox_sta_enable);
            skinTabPage_wifi_connect.Controls.Add(skinButton_sta_set);
            skinTabPage_wifi_connect.Controls.Add(skinButton_sta_query);
            skinTabPage_wifi_connect.Controls.Add(skinLabel9);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_passwd);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_baseid);
            skinTabPage_wifi_connect.Controls.Add(skinLabel11);
            skinTabPage_wifi_connect.Controls.Add(skinTextBox_sta_ssid);
            skinTabPage_wifi_connect.Controls.Add(skinLabel_sta_name);
            skinTabPage_wifi_connect.Controls.Add(skinButton_sta_scan);
            skinTabPage_wifi_connect.Location = new Point(4, 40);
            skinTabPage_wifi_connect.Margin = new Padding(4);
            skinTabPage_wifi_connect.Name = "skinTabPage_wifi_connect";
            skinTabPage_wifi_connect.Size = new Size(673, 430);
            skinTabPage_wifi_connect.TabIndex = 2;
            skinTabPage_wifi_connect.Text = "WIFI Connection";
            // 
            // skinLabel12
            // 
            skinLabel12.AutoSize = true;
            skinLabel12.BackColor = Color.Transparent;
            skinLabel12.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel12.Location = new Point(341, 175);
            skinLabel12.Margin = new Padding(4, 0, 4, 0);
            skinLabel12.Name = "skinLabel12";
            skinLabel12.Size = new Size(60, 17);
            skinLabel12.TabIndex = 15;
            skinLabel12.Text = "Gateway:";
            // 
            // skinLabelstaMask
            // 
            skinLabelstaMask.AutoSize = true;
            skinLabelstaMask.BackColor = Color.Transparent;
            skinLabelstaMask.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabelstaMask.Location = new Point(2, 175);
            skinLabelstaMask.Margin = new Padding(4, 0, 4, 0);
            skinLabelstaMask.Name = "skinLabelstaMask";
            skinLabelstaMask.Size = new Size(86, 17);
            skinLabelstaMask.TabIndex = 14;
            skinLabelstaMask.Text = "Subnet mask:";
            // 
            // skinTextBox_sta_ip_netmask
            // 
            skinTextBox_sta_ip_netmask.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_ip_netmask.Location = new Point(92, 170);
            skinTextBox_sta_ip_netmask.Margin = new Padding(0);
            skinTextBox_sta_ip_netmask.MinimumSize = new Size(33, 28);
            skinTextBox_sta_ip_netmask.Name = "skinTextBox_sta_ip_netmask";
            skinTextBox_sta_ip_netmask.Size = new Size(223, 28);
            skinTextBox_sta_ip_netmask.TabIndex = 13;
            // 
            // skinTextBox_sta_ip_gateway
            // 
            skinTextBox_sta_ip_gateway.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_ip_gateway.Location = new Point(405, 170);
            skinTextBox_sta_ip_gateway.Margin = new Padding(0);
            skinTextBox_sta_ip_gateway.MinimumSize = new Size(33, 28);
            skinTextBox_sta_ip_gateway.Name = "skinTextBox_sta_ip_gateway";
            skinTextBox_sta_ip_gateway.Size = new Size(250, 28);
            skinTextBox_sta_ip_gateway.TabIndex = 13;
            // 
            // skinTextBox_sta_ip
            // 
            skinTextBox_sta_ip.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_ip.Location = new Point(405, 130);
            skinTextBox_sta_ip.Margin = new Padding(0);
            skinTextBox_sta_ip.MinimumSize = new Size(33, 28);
            skinTextBox_sta_ip.Name = "skinTextBox_sta_ip";
            skinTextBox_sta_ip.Size = new Size(250, 28);
            skinTextBox_sta_ip.TabIndex = 13;
            // 
            // skinLabel_sta_ip
            // 
            skinLabel_sta_ip.AutoSize = true;
            skinLabel_sta_ip.BackColor = Color.Transparent;
            skinLabel_sta_ip.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_sta_ip.Location = new Point(327, 135);
            skinLabel_sta_ip.Margin = new Padding(4, 0, 4, 0);
            skinLabel_sta_ip.Name = "skinLabel_sta_ip";
            skinLabel_sta_ip.Size = new Size(74, 17);
            skinLabel_sta_ip.TabIndex = 12;
            skinLabel_sta_ip.Text = "IP Address:";
            // 
            // skinComboBox_sta_ip_mode
            // 
            skinComboBox_sta_ip_mode.DrawMode = DrawMode.OwnerDrawFixed;
            skinComboBox_sta_ip_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_sta_ip_mode.FormattingEnabled = true;
            skinComboBox_sta_ip_mode.Location = new Point(92, 135);
            skinComboBox_sta_ip_mode.Margin = new Padding(4);
            skinComboBox_sta_ip_mode.Name = "skinComboBox_sta_ip_mode";
            skinComboBox_sta_ip_mode.Size = new Size(223, 24);
            skinComboBox_sta_ip_mode.TabIndex = 11;
            // 
            // skinLabel_sta_get_ip_mode
            // 
            skinLabel_sta_get_ip_mode.AutoSize = true;
            skinLabel_sta_get_ip_mode.BackColor = Color.Transparent;
            skinLabel_sta_get_ip_mode.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_sta_get_ip_mode.Location = new Point(16, 137);
            skinLabel_sta_get_ip_mode.Margin = new Padding(4, 0, 4, 0);
            skinLabel_sta_get_ip_mode.Name = "skinLabel_sta_get_ip_mode";
            skinLabel_sta_get_ip_mode.Size = new Size(64, 17);
            skinLabel_sta_get_ip_mode.TabIndex = 10;
            skinLabel_sta_get_ip_mode.Text = "Get IP By:";
            // 
            // skinCheckBox_sta_enable
            // 
            skinCheckBox_sta_enable.AutoSize = true;
            skinCheckBox_sta_enable.BackColor = Color.Transparent;
            skinCheckBox_sta_enable.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinCheckBox_sta_enable.Location = new Point(238, 12);
            skinCheckBox_sta_enable.Margin = new Padding(4);
            skinCheckBox_sta_enable.Name = "skinCheckBox_sta_enable";
            skinCheckBox_sta_enable.Size = new Size(166, 21);
            skinCheckBox_sta_enable.TabIndex = 9;
            skinCheckBox_sta_enable.Text = "Enable Wi-Fi connection";
            skinCheckBox_sta_enable.UseVisualStyleBackColor = false;
            // 
            // skinButton_sta_set
            // 
            skinButton_sta_set.BackColor = Color.Transparent;
            skinButton_sta_set.Location = new Point(402, 217);
            skinButton_sta_set.Margin = new Padding(4);
            skinButton_sta_set.Name = "skinButton_sta_set";
            skinButton_sta_set.Size = new Size(88, 29);
            skinButton_sta_set.TabIndex = 5;
            skinButton_sta_set.Text = "Save";
            skinButton_sta_set.UseVisualStyleBackColor = false;
            skinButton_sta_set.Click += skinButton_sta_set_Click;
            // 
            // skinButton_sta_query
            // 
            skinButton_sta_query.BackColor = Color.Transparent;
            skinButton_sta_query.Location = new Point(179, 217);
            skinButton_sta_query.Margin = new Padding(4);
            skinButton_sta_query.Name = "skinButton_sta_query";
            skinButton_sta_query.Size = new Size(88, 29);
            skinButton_sta_query.TabIndex = 4;
            skinButton_sta_query.Text = "Query";
            skinButton_sta_query.UseVisualStyleBackColor = false;
            skinButton_sta_query.Click += skinButton_sta_query_Click;
            // 
            // skinLabel9
            // 
            skinLabel9.AutoSize = true;
            skinLabel9.BackColor = Color.Transparent;
            skinLabel9.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel9.Location = new Point(334, 97);
            skinLabel9.Margin = new Padding(4, 0, 4, 0);
            skinLabel9.Name = "skinLabel9";
            skinLabel9.Size = new Size(67, 17);
            skinLabel9.TabIndex = 3;
            skinLabel9.Text = "Password:";
            // 
            // skinTextBox_sta_passwd
            // 
            skinTextBox_sta_passwd.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_passwd.Location = new Point(405, 92);
            skinTextBox_sta_passwd.Margin = new Padding(0);
            skinTextBox_sta_passwd.MinimumSize = new Size(33, 28);
            skinTextBox_sta_passwd.Name = "skinTextBox_sta_passwd";
            skinTextBox_sta_passwd.Size = new Size(250, 28);
            skinTextBox_sta_passwd.TabIndex = 2;
            // 
            // skinTextBox_sta_baseid
            // 
            skinTextBox_sta_baseid.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_baseid.Location = new Point(92, 102);
            skinTextBox_sta_baseid.Margin = new Padding(0);
            skinTextBox_sta_baseid.MinimumSize = new Size(33, 28);
            skinTextBox_sta_baseid.Name = "skinTextBox_sta_baseid";
            skinTextBox_sta_baseid.Size = new Size(223, 28);
            skinTextBox_sta_baseid.TabIndex = 2;
            // 
            // skinLabel11
            // 
            skinLabel11.AutoSize = true;
            skinLabel11.BackColor = Color.Transparent;
            skinLabel11.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel11.Location = new Point(10, 97);
            skinLabel11.Margin = new Padding(4, 0, 4, 0);
            skinLabel11.Name = "skinLabel11";
            skinLabel11.Size = new Size(61, 17);
            skinLabel11.TabIndex = 1;
            skinLabel11.Text = "BaseID：";
            // 
            // skinTextBox_sta_ssid
            // 
            skinTextBox_sta_ssid.Font = new Font("Microsoft YaHei", 9.75F);
            skinTextBox_sta_ssid.Location = new Point(90, 46);
            skinTextBox_sta_ssid.Margin = new Padding(0);
            skinTextBox_sta_ssid.MinimumSize = new Size(33, 28);
            skinTextBox_sta_ssid.Name = "skinTextBox_sta_ssid";
            skinTextBox_sta_ssid.Size = new Size(225, 28);
            skinTextBox_sta_ssid.TabIndex = 2;
            // 
            // skinLabel_sta_name
            // 
            skinLabel_sta_name.AutoSize = true;
            skinLabel_sta_name.BackColor = Color.Transparent;
            skinLabel_sta_name.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_sta_name.Location = new Point(10, 51);
            skinLabel_sta_name.Margin = new Padding(4, 0, 4, 0);
            skinLabel_sta_name.Name = "skinLabel_sta_name";
            skinLabel_sta_name.Size = new Size(76, 17);
            skinLabel_sta_name.TabIndex = 1;
            skinLabel_sta_name.Text = "WIFI Name:";
            // 
            // skinButton_sta_scan
            // 
            skinButton_sta_scan.BackColor = Color.Transparent;
            skinButton_sta_scan.Location = new Point(476, 46);
            skinButton_sta_scan.Margin = new Padding(4);
            skinButton_sta_scan.Name = "skinButton_sta_scan";
            skinButton_sta_scan.Size = new Size(88, 29);
            skinButton_sta_scan.TabIndex = 0;
            skinButton_sta_scan.Text = "Scan";
            skinButton_sta_scan.UseVisualStyleBackColor = false;
            skinButton_sta_scan.Click += skinButton_sta_scan_Click;
            // 
            // WifiWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 485);
            Controls.Add(skinTabControl_wifi);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "WifiWindow";
            Text = "WifiWindow";
            skinTabControl_wifi.ResumeLayout(false);
            skinTabPage_connect.ResumeLayout(false);
            skinTabPage_connect.PerformLayout();
            skinTabPage_AP.ResumeLayout(false);
            skinTabPage_AP.PerformLayout();
            skinTabPage_wifi_connect.ResumeLayout(false);
            skinTabPage_wifi_connect.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}