using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    partial class TcpServerWindows
    {
        private Panel skinPanel1;
        private Label skinLabel_interface;
        private ComboBox skinComboBox_pc_interface;
        private Button skinButton_stop;
        private Button skinButton_listen;
        private TextBox skinWaterTextBox_listen_port;
        private Label skinLabel1;
        private ListView skinListView_ip_list;
        private ColumnHeader columnHeader_none;
        private ColumnHeader columnHeader_ip;
        private ColumnHeader columnHeader_port;
        private ListView skinListView_tags;
        private ColumnHeader columnHeader_id_none;
        private ColumnHeader columnHeader_tags_ip;
        private ColumnHeader columnHeader_tags_data;
        private ColumnHeader columnHeader_tags_count;
        private ColumnHeader columnHeader_rssi;
        private ColumnHeader columnHeader_heart_beats;

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
            skinPanel1 = new Panel();
            skinButton_stop = new Button();
            skinButton_listen = new Button();
            skinWaterTextBox_listen_port = new TextBox();
            skinLabel1 = new Label();
            skinComboBox_pc_interface = new ComboBox();
            skinLabel_interface = new Label();
            skinListView_ip_list = new ListView();
            columnHeader_none = new ColumnHeader();
            columnHeader_ip = new ColumnHeader();
            columnHeader_port = new ColumnHeader();
            columnHeader_heart_beats = new ColumnHeader();
            skinListView_tags = new ListView();
            columnHeader_id_none = new ColumnHeader();
            columnHeader_tags_ip = new ColumnHeader();
            columnHeader_tags_data = new ColumnHeader();
            columnHeader_rssi = new ColumnHeader();
            columnHeader_tags_count = new ColumnHeader();
            skinPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // skinPanel1
            // 
            skinPanel1.BackColor = Color.Transparent;
            skinPanel1.Controls.Add(skinButton_stop);
            skinPanel1.Controls.Add(skinButton_listen);
            skinPanel1.Controls.Add(skinWaterTextBox_listen_port);
            skinPanel1.Controls.Add(skinLabel1);
            skinPanel1.Controls.Add(skinComboBox_pc_interface);
            skinPanel1.Controls.Add(skinLabel_interface);
            skinPanel1.Location = new Point(9, 26);
            skinPanel1.Margin = new Padding(4);
            skinPanel1.Name = "skinPanel1";
            skinPanel1.Size = new Size(286, 142);
            skinPanel1.TabIndex = 0;
            // 
            // skinButton_stop
            // 
            skinButton_stop.BackColor = Color.Transparent;
            skinButton_stop.Location = new Point(174, 105);
            skinButton_stop.Margin = new Padding(4);
            skinButton_stop.Name = "skinButton_stop";
            skinButton_stop.Size = new Size(66, 29);
            skinButton_stop.TabIndex = 6;
            skinButton_stop.Text = "Stop";
            skinButton_stop.UseVisualStyleBackColor = false;
            skinButton_stop.Click += skinButton_stop_Click;
            // 
            // skinButton_listen
            // 
            skinButton_listen.BackColor = Color.Transparent;
            skinButton_listen.Location = new Point(38, 105);
            skinButton_listen.Margin = new Padding(4);
            skinButton_listen.Name = "skinButton_listen";
            skinButton_listen.Size = new Size(70, 29);
            skinButton_listen.TabIndex = 5;
            skinButton_listen.Text = "Listen";
            skinButton_listen.UseVisualStyleBackColor = false;
            skinButton_listen.Click += skinButton_listen_Click;
            // 
            // skinWaterTextBox_listen_port
            // 
            skinWaterTextBox_listen_port.Location = new Point(99, 60);
            skinWaterTextBox_listen_port.Margin = new Padding(4);
            skinWaterTextBox_listen_port.Name = "skinWaterTextBox_listen_port";
            skinWaterTextBox_listen_port.Size = new Size(116, 23);
            skinWaterTextBox_listen_port.TabIndex = 3;
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.Location = new Point(9, 64);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(72, 17);
            skinLabel1.TabIndex = 2;
            skinLabel1.Text = "Listen Port:";
            // 
            // skinComboBox_pc_interface
            // 
            skinComboBox_pc_interface.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_pc_interface.FormattingEnabled = true;
            skinComboBox_pc_interface.Location = new Point(99, 15);
            skinComboBox_pc_interface.Margin = new Padding(4);
            skinComboBox_pc_interface.Name = "skinComboBox_pc_interface";
            skinComboBox_pc_interface.Size = new Size(159, 23);
            skinComboBox_pc_interface.TabIndex = 1;
            // 
            // skinLabel_interface
            // 
            skinLabel_interface.AutoSize = true;
            skinLabel_interface.BackColor = Color.Transparent;
            skinLabel_interface.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_interface.Location = new Point(20, 18);
            skinLabel_interface.Margin = new Padding(4, 0, 4, 0);
            skinLabel_interface.Name = "skinLabel_interface";
            skinLabel_interface.Size = new Size(62, 17);
            skinLabel_interface.TabIndex = 0;
            skinLabel_interface.Text = "Interface:";
            // 
            // skinListView_ip_list
            // 
            skinListView_ip_list.Columns.AddRange(new ColumnHeader[] { columnHeader_none, columnHeader_ip, columnHeader_port, columnHeader_heart_beats });
            skinListView_ip_list.Location = new Point(303, 26);
            skinListView_ip_list.Margin = new Padding(4);
            skinListView_ip_list.Name = "skinListView_ip_list";
            skinListView_ip_list.Size = new Size(368, 142);
            skinListView_ip_list.TabIndex = 1;
            skinListView_ip_list.UseCompatibleStateImageBehavior = false;
            skinListView_ip_list.View = View.Details;
            // 
            // columnHeader_none
            // 
            columnHeader_none.Text = "none";
            columnHeader_none.Width = 0;
            // 
            // columnHeader_ip
            // 
            columnHeader_ip.Text = "Client IP";
            columnHeader_ip.TextAlign = HorizontalAlignment.Center;
            columnHeader_ip.Width = 156;
            // 
            // columnHeader_port
            // 
            columnHeader_port.Text = "Port";
            columnHeader_port.TextAlign = HorizontalAlignment.Center;
            columnHeader_port.Width = 69;
            // 
            // columnHeader_heart_beats
            // 
            columnHeader_heart_beats.Text = "Heart Beat";
            columnHeader_heart_beats.Width = 87;
            // 
            // skinListView_tags
            // 
            skinListView_tags.Columns.AddRange(new ColumnHeader[] { columnHeader_id_none, columnHeader_tags_ip, columnHeader_tags_data, columnHeader_rssi, columnHeader_tags_count });
            skinListView_tags.Location = new Point(9, 176);
            skinListView_tags.Margin = new Padding(4);
            skinListView_tags.Name = "skinListView_tags";
            skinListView_tags.Size = new Size(662, 285);
            skinListView_tags.TabIndex = 2;
            skinListView_tags.UseCompatibleStateImageBehavior = false;
            skinListView_tags.View = View.Details;
            // 
            // columnHeader_id_none
            // 
            columnHeader_id_none.Text = "None";
            columnHeader_id_none.Width = 0;
            // 
            // columnHeader_tags_ip
            // 
            columnHeader_tags_ip.Text = "IP Address";
            columnHeader_tags_ip.TextAlign = HorizontalAlignment.Center;
            columnHeader_tags_ip.Width = 174;
            // 
            // columnHeader_tags_data
            // 
            columnHeader_tags_data.Text = "Tag Data";
            columnHeader_tags_data.TextAlign = HorizontalAlignment.Center;
            columnHeader_tags_data.Width = 244;
            // 
            // columnHeader_rssi
            // 
            columnHeader_rssi.Text = "RSSI";
            columnHeader_rssi.TextAlign = HorizontalAlignment.Center;
            columnHeader_rssi.Width = 86;
            // 
            // columnHeader_tags_count
            // 
            columnHeader_tags_count.Text = "Times";
            columnHeader_tags_count.TextAlign = HorizontalAlignment.Center;
            // 
            // TcpServerWindows
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(684, 494);
            ControlBox = false;
            Controls.Add(skinListView_tags);
            Controls.Add(skinListView_ip_list);
            Controls.Add(skinPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TcpServerWindows";
            ShowIcon = false;
            ShowInTaskbar = false;
            FormClosing += TcpServerWindows_FormClosing;
            skinPanel1.ResumeLayout(false);
            skinPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}