using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    partial class M100Window
    {
        private TabControl tabControl_function;
        private TabPage tabPage_inventory;
        private Button skinButton_once;
        private Button skinButton_stop;
        private ListView skinListView_tags;
        private Button skinButton_start;
        private ColumnHeader columnHeader_time;
        private ColumnHeader columnHeader_ID;
        private ColumnHeader columnHeader_tid;
        private ColumnHeader columnHeader_user;
        private Button skinButton_clear;
        private TabPage tabPage_work_param;
        private Label skinLabel1;
        private NumericUpDown skinNumericUpDown_power;
        private Button skinButton_work_set;
        private Button skinButton_work_refresh;
        private NumericUpDown skinNumericUpDown_work_interval;
        private NumericUpDown skinNumericUpDown_work_filter;
        private Label skinLabel3;
        private Label skinLabel2;
        private TextBox skinWaterTextBox_addr;
        private Label skinLabel4;
        private NumericUpDown skinNumericUpDown_trigger_time;
        private Label skinLabel_trigger;
        private ComboBox skinComboBox_work_mode;
        private Label skinLabel_work_mode;
        private TabPage tabPage_transfer;
        private ComboBox skinComboBox_transfer_mode;
        private Label skinLabel6;
        private GroupBox skinGroupBox2;
        private GroupBox skinGroupBox1;
        private ComboBox skinComboBox_transfer_baudrate;
        private Label skinLabel5;
        private NumericUpDown skinNumericUpDown_wiegand_location;
        private TextBox skinWaterTextBox_wiegand_interval;
        private TextBox skinWaterTextBox_wiegand_prorid;
        private TextBox skinWaterTextBox_wiegand_width;
        private ComboBox skinComboBox_wiegand_protocl;
        private Label skinLabel11;
        private Label skinLabel10;
        private Label skinLabel9;
        private Label skinLabel8;
        private Label skinLabel7;
        private Button skinButton_transfer_set;
        private Button skinButton_transfer_query;
        private GroupBox skinGroupBox3;
        private TextBox skinWaterTextBox_gate_way;
        private Label skinLabel19;
        private TextBox skinWaterTextBox_ip_sub_masker;
        private Label skinLabel18;
        private TextBox skinWaterTextBox_remote_port;
        private TextBox skinWaterTextBox_ip_remote;
        private Label skinLabel16;
        private Label skinLabel15;
        private TextBox skinWaterTextBox_local_port;
        private Label skinLabel14;
        private TextBox skinWaterTextBox_ip_local;
        private Label skinLabel13;
        private TextBox skinWaterTextBox_ip_mac;
        private Label skinLabel12;
        private TabPage tabPage_advance;
        private NumericUpDown skinNumericUpDown_advan_Q;
        private Button skinButton_advance_set;
        private Button skinButton_advance_refresh;
        private Label skinLabel28;
        private Label skinLabel27;
        private ComboBox skinComboBox_advan_target;
        private Label skinLabel26;
        private ComboBox skinComboBox_advan_session;
        private Label skinLabel25;
        private ComboBox skinComboBox_advan_sel;
        private Label skinLabel24;
        private ComboBox skinComboBox_advan_cw;
        private Label skinLabel23;
        private ComboBox skinComboBox_advan_hopping;
        private Label skinLabel22;
        private TextBox skinWaterTextBox_advan_channel;
        private Label skinLabel21;
        private ComboBox skinComboBox_advan_region;
        private Label skinLabel20;
        private Button skinButton_defualt;
        private TextBox skinWaterTextBox_heart_beats;
        private Label skinLabel30;
        private Button skinButton_reset;
        private Label skinLabel31;
        private Label skinLabel33;
        private Label skinLabel32;
        private TabPage tabPage1;
        private Button skinButton_operation_write;
        private TextBox skinWater_content;
        private Label skinLabel40;
        private TextBox skinWaterTextBox_password;
        private Label skinLabel39;
        private TextBox skinWaterTextBox_length;
        private Label skinLabel38;
        private TextBox skinWaterTextBox_address;
        private Label skinLabel37;
        private ComboBox skinComboBox_membank;
        private Label skinLabel36;
        private Label skinLabel_tag_num;
        private Button skinButton_operation_read;
        private Label skinLabel41;
        private TextBox skinTextBox_opt_result;
        private CheckedListBox checkedListBox_work_ant;
        private GroupBox skinGroupBox5;
        private TextBox skinWaterTextBox_module_id;
        private TextBox skinWaterTextBox_module_sn;
        private Label skinLabel43;
        private Label skinLabel42;
        private GroupBox skinGroupBox6;
        private GroupBox skinGroupBox7;
        private CheckBox buzzer_check;
        private Label skinLabel49;
        private Label skinLabel48;
        private TextBox skinWaterTextBox_inventory_length;
        private Label skinLabel47;
        private Label skinLabel46;
        private TextBox skinWaterTextBox_inventory_address;
        private Label skinLabel45;
        private ComboBox skinComboBox_inventory_area;
        private Label skinLabel44;
        private Label skinLabel50;
        private GroupBox skinGroupBox8;
        private CheckBox dhcp_check;
        private Label skinLabel17;
        private CheckBox record_check;
        private ComboBox skinComboBox_sub_protocol;
        private Label skinLabel29;
        private ComboBox skinComboBox_wiegand_direction;
        private Label label4;
        private Label label3;
        private Label label2;
        private ColumnHeader columnHeader_tid2;
        private Button skinButton_wiegand_write;
        private TextBox skinWaterTextBox_wiegand_write_data;
        private Label skinLabel51;
        private GroupBox skinGroupBox4;
        private Button skinButton_query_time;
        private Button skinButton_sync_time;
        private Button skinButton_upload_record;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private Button button_audio_play;
        private TextBox textBox_audio_text;
        private Label label9;
        private GroupBox groupBox1;
        private Label label10;
        private Button button_relay_set;
        private Button button_ext_fresh;
        private Label label8;
        private TextBox textBox_relay_time;
        private Label label7;
        private CheckBox checkBox_relay2_auto;
        private Label label6;
        private CheckBox checkBox_relay1_auto;
        private Label label5;
        private GroupBox groupBox3;
        private Button button_relay_control;
        private TextBox textBox_relay_ctrl_time;
        private Label label12;
        private ComboBox comboBox_op_index;
        private Label label11;
        private Button button_audio_set_vol;
        private ComboBox comboBox_lock_type;
        private Label label16;
        private Button skinButton_tag_lock;
        private Button skinButton_kill_tag;
        private GroupBox groupBox4;
        private TextBox skinWaterTextBox_dev_num;
        private Button skinButton_dev_set;
        private Button skinButton_dev_query;
        private Label label17;
        private Label label19;
        private Label label18;
        private TextBox textBox_tag_verify_pwd;
        private CheckBox checkBox_tag_verify;
        private Button skinButton_tag_verify;
        private TabPage tabPage3;
        private GroupBox groupBox5;
        private CheckBox checkBox_auto_write_increse;
        private CheckBox checkBox_auto_write_flag;
        private Button button_auto_write_wiegand;
        private Button button_auto_write_hex;
        private TextBox textBox_auto_wiegand_write_text;
        private TextBox textBox_auto_hex_write_text;
        private Label label14;
        private Label label13;
        private TabPage tabPage_ExDataParam;
        private GroupBox groupBox6;
        private Button button_usbdata_sset;
        private Button button_usbdata_query;
        private CheckBox checkBox_usbdata_enter_flag;
        private ComboBox comboBox_usbdata_proto;
        private Label label15;
        private GroupBox groupBox7;
        private Button button_dataflag_set;
        private Button button_dataflag_query;
        private CheckBox checkBoxDataFlag_DevNo;
        private CheckBox checkBoxDataFlag_ANT;
        private CheckBox checkBoxDataFlag_RSSI;
        private RadioButton radioButton_USB_COM;
        private RadioButton radioButton_USB_HID;
        private Label label20;
        private Label label21;
        private Button button_ext_add_verify;
        private GroupBox groupBox8;
        private Label label_ex_modbus_register_num;
        private Button button_ex_modbus_set;
        private Button button_ex_modbus_query;
        private CheckBox checkBox_ex_modbus_clear_flag;
        private NumericUpDown numericUpDown_ex_modbus_startaddr;
        private Label label24;
        private NumericUpDown numericUpDown_ex_modbus_union_size;
        private Label label23;
        private NumericUpDown numericUpDown_ex_modbus_tag_num;
        private Label label22;
        private Label label26;
        private Label label25;
        private Label label27;
        private TextBox textBox_advan_rssi;
        private ComboBox comboBox_dataflag_format;
        private Label label34;
        private Label label33;
        private RadioButton radioButton_remote_ipmode_IP;
        private RadioButton radioButton_remote_ipmode_host;
        private ComboBox comboBox_ex_modbus_proto;
        private Label label1;
        private GroupBox groupBox9;
        private TextBox textBox_write_file_path;
        private Label label35;
        private Button button_write_file_choose;
        private NumericUpDown numericUpDown_write_file_row;
        private Label label36;
        private TextBox textBox_write_file_data;
        private Label label37;
        private Button button_write_file_auto;
        private Button button_write_file_hand;
        private Button button_write_file_reload;
        private Button skinButton_save;
        private Button button_ext_auto_add_verify;
        private CheckBox checkBox_DataFlag_Enter;
        private FlowLayoutPanel flowLayoutPanel_advance_freqs;
        private Button skinButton_advance_cancel_select;

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
            tabControl_function = new TabControl();
            tabPage_inventory = new TabPage();
            skinLabel_tag_num = new Label();
            skinButton_clear = new Button();
            skinButton_start = new Button();
            skinButton_once = new Button();
            skinButton_save = new Button();
            skinButton_stop = new Button();
            skinListView_tags = new ListView();
            columnHeader_time = new ColumnHeader();
            columnHeader_ID = new ColumnHeader();
            columnHeader_tid2 = new ColumnHeader();
            columnHeader_tid = new ColumnHeader();
            columnHeader_user = new ColumnHeader();
            tabPage_work_param = new TabPage();
            groupBox4 = new GroupBox();
            skinWaterTextBox_dev_num = new TextBox();
            skinButton_dev_set = new Button();
            skinButton_dev_query = new Button();
            label17 = new Label();
            skinGroupBox7 = new GroupBox();
            skinLabel50 = new Label();
            skinLabel4 = new Label();
            skinLabel31 = new Label();
            skinWaterTextBox_addr = new TextBox();
            checkedListBox_work_ant = new CheckedListBox();
            skinLabel1 = new Label();
            skinNumericUpDown_power = new NumericUpDown();
            skinGroupBox6 = new GroupBox();
            record_check = new CheckBox();
            buzzer_check = new CheckBox();
            skinLabel49 = new Label();
            skinLabel48 = new Label();
            skinWaterTextBox_inventory_length = new TextBox();
            skinLabel47 = new Label();
            skinLabel33 = new Label();
            skinLabel46 = new Label();
            skinWaterTextBox_inventory_address = new TextBox();
            skinLabel45 = new Label();
            skinComboBox_inventory_area = new ComboBox();
            skinLabel44 = new Label();
            skinLabel_work_mode = new Label();
            skinNumericUpDown_trigger_time = new NumericUpDown();
            skinLabel_trigger = new Label();
            skinComboBox_work_mode = new ComboBox();
            skinNumericUpDown_work_interval = new NumericUpDown();
            skinLabel3 = new Label();
            skinLabel2 = new Label();
            skinLabel32 = new Label();
            skinNumericUpDown_work_filter = new NumericUpDown();
            skinButton_reset = new Button();
            skinButton_defualt = new Button();
            skinButton_work_set = new Button();
            skinButton_work_refresh = new Button();
            tabPage_transfer = new TabPage();
            skinGroupBox8 = new GroupBox();
            dhcp_check = new CheckBox();
            skinLabel12 = new Label();
            skinWaterTextBox_ip_mac = new TextBox();
            skinWaterTextBox_gate_way = new TextBox();
            skinLabel13 = new Label();
            skinWaterTextBox_ip_local = new TextBox();
            skinLabel19 = new Label();
            skinLabel14 = new Label();
            skinWaterTextBox_local_port = new TextBox();
            skinWaterTextBox_ip_sub_masker = new TextBox();
            skinLabel18 = new Label();
            skinGroupBox5 = new GroupBox();
            skinWaterTextBox_module_id = new TextBox();
            skinWaterTextBox_module_sn = new TextBox();
            skinLabel43 = new Label();
            skinLabel42 = new Label();
            skinComboBox_sub_protocol = new ComboBox();
            skinButton_transfer_set = new Button();
            skinLabel29 = new Label();
            skinButton_transfer_query = new Button();
            skinGroupBox3 = new GroupBox();
            radioButton_remote_ipmode_host = new RadioButton();
            radioButton_remote_ipmode_IP = new RadioButton();
            skinWaterTextBox_heart_beats = new TextBox();
            skinLabel17 = new Label();
            skinLabel30 = new Label();
            skinWaterTextBox_remote_port = new TextBox();
            skinWaterTextBox_ip_remote = new TextBox();
            skinLabel16 = new Label();
            skinLabel15 = new Label();
            skinComboBox_transfer_mode = new ComboBox();
            skinLabel6 = new Label();
            skinGroupBox2 = new GroupBox();
            skinComboBox_wiegand_direction = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            skinNumericUpDown_wiegand_location = new NumericUpDown();
            skinWaterTextBox_wiegand_interval = new TextBox();
            skinWaterTextBox_wiegand_prorid = new TextBox();
            skinWaterTextBox_wiegand_width = new TextBox();
            skinComboBox_wiegand_protocl = new ComboBox();
            skinLabel11 = new Label();
            skinLabel10 = new Label();
            skinLabel9 = new Label();
            skinLabel8 = new Label();
            skinLabel7 = new Label();
            skinGroupBox1 = new GroupBox();
            skinComboBox_transfer_baudrate = new ComboBox();
            skinLabel5 = new Label();
            tabPage_advance = new TabPage();
            skinButton_advance_cancel_select = new Button();
            flowLayoutPanel_advance_freqs = new FlowLayoutPanel();
            label27 = new Label();
            textBox_advan_rssi = new TextBox();
            skinNumericUpDown_advan_Q = new NumericUpDown();
            skinButton_advance_set = new Button();
            skinButton_advance_refresh = new Button();
            skinLabel28 = new Label();
            skinLabel27 = new Label();
            skinComboBox_advan_target = new ComboBox();
            skinLabel26 = new Label();
            skinComboBox_advan_session = new ComboBox();
            skinLabel25 = new Label();
            skinComboBox_advan_sel = new ComboBox();
            skinLabel24 = new Label();
            skinComboBox_advan_cw = new ComboBox();
            skinLabel23 = new Label();
            skinComboBox_advan_hopping = new ComboBox();
            skinLabel22 = new Label();
            skinWaterTextBox_advan_channel = new TextBox();
            skinLabel21 = new Label();
            skinComboBox_advan_region = new ComboBox();
            skinLabel20 = new Label();
            tabPage1 = new TabPage();
            skinButton_tag_verify = new Button();
            skinButton_kill_tag = new Button();
            skinButton_tag_lock = new Button();
            comboBox_lock_type = new ComboBox();
            label16 = new Label();
            skinGroupBox4 = new GroupBox();
            skinButton_query_time = new Button();
            skinButton_sync_time = new Button();
            skinButton_upload_record = new Button();
            skinButton_wiegand_write = new Button();
            skinWaterTextBox_wiegand_write_data = new TextBox();
            skinLabel51 = new Label();
            skinLabel41 = new Label();
            skinButton_operation_read = new Button();
            skinButton_operation_write = new Button();
            skinWater_content = new TextBox();
            skinLabel40 = new Label();
            skinWaterTextBox_password = new TextBox();
            skinLabel39 = new Label();
            skinWaterTextBox_length = new TextBox();
            skinLabel38 = new Label();
            skinWaterTextBox_address = new TextBox();
            skinLabel37 = new Label();
            skinComboBox_membank = new ComboBox();
            skinLabel36 = new Label();
            skinTextBox_opt_result = new TextBox();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            button_relay_control = new Button();
            textBox_relay_ctrl_time = new TextBox();
            label12 = new Label();
            comboBox_op_index = new ComboBox();
            label11 = new Label();
            groupBox2 = new GroupBox();
            button_audio_set_vol = new Button();
            button_audio_play = new Button();
            textBox_audio_text = new TextBox();
            label9 = new Label();
            groupBox1 = new GroupBox();
            button_ext_auto_add_verify = new Button();
            button_ext_add_verify = new Button();
            label21 = new Label();
            label19 = new Label();
            label18 = new Label();
            textBox_tag_verify_pwd = new TextBox();
            checkBox_tag_verify = new CheckBox();
            label10 = new Label();
            button_relay_set = new Button();
            button_ext_fresh = new Button();
            label8 = new Label();
            textBox_relay_time = new TextBox();
            label7 = new Label();
            checkBox_relay2_auto = new CheckBox();
            label6 = new Label();
            checkBox_relay1_auto = new CheckBox();
            label5 = new Label();
            tabPage3 = new TabPage();
            groupBox9 = new GroupBox();
            button_write_file_reload = new Button();
            button_write_file_auto = new Button();
            button_write_file_hand = new Button();
            textBox_write_file_data = new TextBox();
            label37 = new Label();
            numericUpDown_write_file_row = new NumericUpDown();
            label36 = new Label();
            button_write_file_choose = new Button();
            textBox_write_file_path = new TextBox();
            label35 = new Label();
            groupBox5 = new GroupBox();
            label14 = new Label();
            label13 = new Label();
            checkBox_auto_write_increse = new CheckBox();
            checkBox_auto_write_flag = new CheckBox();
            button_auto_write_wiegand = new Button();
            button_auto_write_hex = new Button();
            textBox_auto_wiegand_write_text = new TextBox();
            textBox_auto_hex_write_text = new TextBox();
            tabPage_ExDataParam = new TabPage();
            groupBox8 = new GroupBox();
            comboBox_ex_modbus_proto = new ComboBox();
            label1 = new Label();
            label26 = new Label();
            label25 = new Label();
            label_ex_modbus_register_num = new Label();
            button_ex_modbus_set = new Button();
            button_ex_modbus_query = new Button();
            checkBox_ex_modbus_clear_flag = new CheckBox();
            numericUpDown_ex_modbus_startaddr = new NumericUpDown();
            label24 = new Label();
            numericUpDown_ex_modbus_union_size = new NumericUpDown();
            label23 = new Label();
            numericUpDown_ex_modbus_tag_num = new NumericUpDown();
            label22 = new Label();
            groupBox7 = new GroupBox();
            checkBox_DataFlag_Enter = new CheckBox();
            comboBox_dataflag_format = new ComboBox();
            label34 = new Label();
            label33 = new Label();
            button_dataflag_set = new Button();
            button_dataflag_query = new Button();
            checkBoxDataFlag_DevNo = new CheckBox();
            checkBoxDataFlag_ANT = new CheckBox();
            checkBoxDataFlag_RSSI = new CheckBox();
            groupBox6 = new GroupBox();
            radioButton_USB_COM = new RadioButton();
            radioButton_USB_HID = new RadioButton();
            label20 = new Label();
            button_usbdata_sset = new Button();
            button_usbdata_query = new Button();
            checkBox_usbdata_enter_flag = new CheckBox();
            comboBox_usbdata_proto = new ComboBox();
            label15 = new Label();
            tabControl_function.SuspendLayout();
            tabPage_inventory.SuspendLayout();
            tabPage_work_param.SuspendLayout();
            groupBox4.SuspendLayout();
            skinGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_power).BeginInit();
            skinGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_trigger_time).BeginInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_work_interval).BeginInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_work_filter).BeginInit();
            tabPage_transfer.SuspendLayout();
            skinGroupBox8.SuspendLayout();
            skinGroupBox5.SuspendLayout();
            skinGroupBox3.SuspendLayout();
            skinGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_wiegand_location).BeginInit();
            skinGroupBox1.SuspendLayout();
            tabPage_advance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_advan_Q).BeginInit();
            tabPage1.SuspendLayout();
            skinGroupBox4.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_write_file_row).BeginInit();
            groupBox5.SuspendLayout();
            tabPage_ExDataParam.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_startaddr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_union_size).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_tag_num).BeginInit();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl_function
            // 
            tabControl_function.Controls.Add(tabPage_inventory);
            tabControl_function.Controls.Add(tabPage_work_param);
            tabControl_function.Controls.Add(tabPage_transfer);
            tabControl_function.Controls.Add(tabPage_advance);
            tabControl_function.Controls.Add(tabPage1);
            tabControl_function.Controls.Add(tabPage2);
            tabControl_function.Controls.Add(tabPage3);
            tabControl_function.Controls.Add(tabPage_ExDataParam);
            tabControl_function.Location = new Point(0, -1);
            tabControl_function.Margin = new Padding(4);
            tabControl_function.Name = "tabControl_function";
            tabControl_function.SelectedIndex = 0;
            tabControl_function.Size = new Size(684, 494);
            tabControl_function.TabIndex = 0;
            tabControl_function.SelectedIndexChanged += tabControl_function_SelectedIndexChanged;
            // 
            // tabPage_inventory
            // 
            tabPage_inventory.Controls.Add(skinLabel_tag_num);
            tabPage_inventory.Controls.Add(skinButton_clear);
            tabPage_inventory.Controls.Add(skinButton_start);
            tabPage_inventory.Controls.Add(skinButton_once);
            tabPage_inventory.Controls.Add(skinButton_save);
            tabPage_inventory.Controls.Add(skinButton_stop);
            tabPage_inventory.Controls.Add(skinListView_tags);
            tabPage_inventory.Location = new Point(4, 24);
            tabPage_inventory.Margin = new Padding(4);
            tabPage_inventory.Name = "tabPage_inventory";
            tabPage_inventory.Padding = new Padding(4);
            tabPage_inventory.Size = new Size(676, 466);
            tabPage_inventory.TabIndex = 0;
            tabPage_inventory.Text = "Inventory";
            tabPage_inventory.UseVisualStyleBackColor = true;
            // 
            // skinLabel_tag_num
            // 
            skinLabel_tag_num.AutoSize = true;
            skinLabel_tag_num.BackColor = Color.Transparent;
            skinLabel_tag_num.Font = new Font("Microsoft YaHei", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_tag_num.ForeColor = Color.Blue;
            skinLabel_tag_num.Location = new Point(569, 412);
            skinLabel_tag_num.Margin = new Padding(4, 0, 4, 0);
            skinLabel_tag_num.Name = "skinLabel_tag_num";
            skinLabel_tag_num.Size = new Size(68, 38);
            skinLabel_tag_num.TabIndex = 6;
            skinLabel_tag_num.Text = "000";
            // 
            // skinButton_clear
            // 
            skinButton_clear.BackColor = Color.Transparent;
            skinButton_clear.Location = new Point(14, 420);
            skinButton_clear.Margin = new Padding(4);
            skinButton_clear.Name = "skinButton_clear";
            skinButton_clear.Size = new Size(88, 29);
            skinButton_clear.TabIndex = 5;
            skinButton_clear.Text = "Clear";
            skinButton_clear.UseVisualStyleBackColor = false;
            skinButton_clear.Click += skinButton_clear_Click;
            // 
            // skinButton_start
            // 
            skinButton_start.BackColor = Color.Transparent;
            skinButton_start.Location = new Point(119, 420);
            skinButton_start.Margin = new Padding(4);
            skinButton_start.Name = "skinButton_start";
            skinButton_start.Size = new Size(88, 29);
            skinButton_start.TabIndex = 4;
            skinButton_start.Text = "Start";
            skinButton_start.UseVisualStyleBackColor = false;
            skinButton_start.Click += skinButton_start_Click;
            // 
            // skinButton_once
            // 
            skinButton_once.BackColor = Color.Transparent;
            skinButton_once.Location = new Point(331, 420);
            skinButton_once.Margin = new Padding(4);
            skinButton_once.Name = "skinButton_once";
            skinButton_once.Size = new Size(88, 29);
            skinButton_once.TabIndex = 3;
            skinButton_once.Text = "Active Read";
            skinButton_once.UseVisualStyleBackColor = false;
            skinButton_once.Click += skinButton_once_Click;
            // 
            // skinButton_save
            // 
            skinButton_save.BackColor = Color.Transparent;
            skinButton_save.Location = new Point(439, 420);
            skinButton_save.Margin = new Padding(4);
            skinButton_save.Name = "skinButton_save";
            skinButton_save.Size = new Size(88, 29);
            skinButton_save.TabIndex = 2;
            skinButton_save.Text = "Save data";
            skinButton_save.UseVisualStyleBackColor = false;
            skinButton_save.Click += skinButton_save_Click;
            // 
            // skinButton_stop
            // 
            skinButton_stop.BackColor = Color.Transparent;
            skinButton_stop.Location = new Point(224, 420);
            skinButton_stop.Margin = new Padding(4);
            skinButton_stop.Name = "skinButton_stop";
            skinButton_stop.Size = new Size(88, 29);
            skinButton_stop.TabIndex = 2;
            skinButton_stop.Text = "Stop";
            skinButton_stop.UseVisualStyleBackColor = false;
            skinButton_stop.Click += skinButton_stop_Click;
            // 
            // skinListView_tags
            // 
            skinListView_tags.Columns.AddRange(new ColumnHeader[] { columnHeader_time, columnHeader_ID, columnHeader_tid2, columnHeader_tid, columnHeader_user });
            skinListView_tags.Location = new Point(0, -1);
            skinListView_tags.Margin = new Padding(4);
            skinListView_tags.Name = "skinListView_tags";
            skinListView_tags.Size = new Size(674, 398);
            skinListView_tags.TabIndex = 0;
            skinListView_tags.UseCompatibleStateImageBehavior = false;
            skinListView_tags.View = View.Details;
            // 
            // columnHeader_time
            // 
            columnHeader_time.Text = "Count";
            // 
            // columnHeader_ID
            // 
            columnHeader_ID.Text = "EPC";
            columnHeader_ID.TextAlign = HorizontalAlignment.Center;
            columnHeader_ID.Width = 180;
            // 
            // columnHeader_tid2
            // 
            columnHeader_tid2.Text = "TID";
            columnHeader_tid2.TextAlign = HorizontalAlignment.Center;
            columnHeader_tid2.Width = 180;
            // 
            // columnHeader_tid
            // 
            columnHeader_tid.Text = "User";
            columnHeader_tid.TextAlign = HorizontalAlignment.Center;
            columnHeader_tid.Width = 180;
            // 
            // columnHeader_user
            // 
            columnHeader_user.Text = "Other";
            columnHeader_user.TextAlign = HorizontalAlignment.Center;
            columnHeader_user.Width = 120;
            // 
            // tabPage_work_param
            // 
            tabPage_work_param.Controls.Add(groupBox4);
            tabPage_work_param.Controls.Add(skinGroupBox7);
            tabPage_work_param.Controls.Add(skinGroupBox6);
            tabPage_work_param.Controls.Add(skinButton_reset);
            tabPage_work_param.Controls.Add(skinButton_defualt);
            tabPage_work_param.Controls.Add(skinButton_work_set);
            tabPage_work_param.Controls.Add(skinButton_work_refresh);
            tabPage_work_param.ForeColor = Color.Black;
            tabPage_work_param.Location = new Point(4, 24);
            tabPage_work_param.Margin = new Padding(4);
            tabPage_work_param.Name = "tabPage_work_param";
            tabPage_work_param.Padding = new Padding(4);
            tabPage_work_param.Size = new Size(676, 466);
            tabPage_work_param.TabIndex = 2;
            tabPage_work_param.Text = "Working Params";
            tabPage_work_param.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(skinWaterTextBox_dev_num);
            groupBox4.Controls.Add(skinButton_dev_set);
            groupBox4.Controls.Add(skinButton_dev_query);
            groupBox4.Controls.Add(label17);
            groupBox4.Location = new Point(10, 384);
            groupBox4.Margin = new Padding(4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4);
            groupBox4.Size = new Size(657, 68);
            groupBox4.TabIndex = 24;
            groupBox4.TabStop = false;
            groupBox4.Text = "Device Serial";
            // 
            // skinWaterTextBox_dev_num
            // 
            skinWaterTextBox_dev_num.Location = new Point(88, 30);
            skinWaterTextBox_dev_num.Margin = new Padding(4);
            skinWaterTextBox_dev_num.Name = "skinWaterTextBox_dev_num";
            skinWaterTextBox_dev_num.Size = new Size(218, 23);
            skinWaterTextBox_dev_num.TabIndex = 27;
            // 
            // skinButton_dev_set
            // 
            skinButton_dev_set.BackColor = Color.Transparent;
            skinButton_dev_set.Location = new Point(432, 26);
            skinButton_dev_set.Margin = new Padding(4);
            skinButton_dev_set.Name = "skinButton_dev_set";
            skinButton_dev_set.Size = new Size(88, 29);
            skinButton_dev_set.TabIndex = 26;
            skinButton_dev_set.Text = "Save";
            skinButton_dev_set.UseVisualStyleBackColor = false;
            skinButton_dev_set.Click += skinButton_dev_set_Click;
            // 
            // skinButton_dev_query
            // 
            skinButton_dev_query.BackColor = Color.Transparent;
            skinButton_dev_query.Location = new Point(327, 26);
            skinButton_dev_query.Margin = new Padding(4);
            skinButton_dev_query.Name = "skinButton_dev_query";
            skinButton_dev_query.Size = new Size(88, 29);
            skinButton_dev_query.TabIndex = 25;
            skinButton_dev_query.Text = "Query";
            skinButton_dev_query.UseVisualStyleBackColor = false;
            skinButton_dev_query.Click += skinButton_dev_query_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(24, 34);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(41, 15);
            label17.TabIndex = 0;
            label17.Text = "Serial：";
            // 
            // skinGroupBox7
            // 
            skinGroupBox7.BackColor = Color.Transparent;
            skinGroupBox7.Controls.Add(skinLabel50);
            skinGroupBox7.Controls.Add(skinLabel4);
            skinGroupBox7.Controls.Add(skinLabel31);
            skinGroupBox7.Controls.Add(skinWaterTextBox_addr);
            skinGroupBox7.Controls.Add(checkedListBox_work_ant);
            skinGroupBox7.Controls.Add(skinLabel1);
            skinGroupBox7.Controls.Add(skinNumericUpDown_power);
            skinGroupBox7.ForeColor = Color.Black;
            skinGroupBox7.Location = new Point(9, 202);
            skinGroupBox7.Margin = new Padding(4);
            skinGroupBox7.Name = "skinGroupBox7";
            skinGroupBox7.Padding = new Padding(4);
            skinGroupBox7.Size = new Size(657, 104);
            skinGroupBox7.TabIndex = 23;
            skinGroupBox7.TabStop = false;
            skinGroupBox7.Text = "Reader settings";
            // 
            // skinLabel50
            // 
            skinLabel50.AutoSize = true;
            skinLabel50.BackColor = Color.Transparent;
            skinLabel50.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel50.Location = new Point(26, 68);
            skinLabel50.Margin = new Padding(4, 0, 4, 0);
            skinLabel50.Name = "skinLabel50";
            skinLabel50.Size = new Size(55, 17);
            skinLabel50.TabIndex = 22;
            skinLabel50.Text = "Antenna";
            // 
            // skinLabel4
            // 
            skinLabel4.AutoSize = true;
            skinLabel4.BackColor = Color.Transparent;
            skinLabel4.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel4.ForeColor = Color.Black;
            skinLabel4.Location = new Point(9, 28);
            skinLabel4.Margin = new Padding(4, 0, 4, 0);
            skinLabel4.Name = "skinLabel4";
            skinLabel4.Size = new Size(100, 17);
            skinLabel4.TabIndex = 12;
            skinLabel4.Text = "Device address:";
            // 
            // skinLabel31
            // 
            skinLabel31.AutoSize = true;
            skinLabel31.BackColor = Color.Transparent;
            skinLabel31.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel31.Location = new Point(394, 26);
            skinLabel31.Margin = new Padding(4, 0, 4, 0);
            skinLabel31.Name = "skinLabel31";
            skinLabel31.Size = new Size(85, 17);
            skinLabel31.TabIndex = 18;
            skinLabel31.Text = "(1 ~ 33 dbm)";
            // 
            // skinWaterTextBox_addr
            // 
            skinWaterTextBox_addr.Location = new Point(117, 26);
            skinWaterTextBox_addr.Margin = new Padding(4);
            skinWaterTextBox_addr.Name = "skinWaterTextBox_addr";
            skinWaterTextBox_addr.Size = new Size(73, 23);
            skinWaterTextBox_addr.TabIndex = 13;
            // 
            // checkedListBox_work_ant
            // 
            checkedListBox_work_ant.CheckOnClick = true;
            checkedListBox_work_ant.ColumnWidth = 60;
            checkedListBox_work_ant.FormattingEnabled = true;
            checkedListBox_work_ant.Items.AddRange(new object[] { "ANT1", "ANT2", "ANT3", "ANT4", "ANT5", "ANT6", "ANT7", "ANT8" });
            checkedListBox_work_ant.Location = new Point(89, 66);
            checkedListBox_work_ant.Margin = new Padding(4);
            checkedListBox_work_ant.MultiColumn = true;
            checkedListBox_work_ant.Name = "checkedListBox_work_ant";
            checkedListBox_work_ant.Size = new Size(500, 22);
            checkedListBox_work_ant.TabIndex = 21;
            // 
            // skinLabel1
            // 
            skinLabel1.AutoSize = true;
            skinLabel1.BackColor = Color.Transparent;
            skinLabel1.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel1.ForeColor = Color.Black;
            skinLabel1.Location = new Point(266, 26);
            skinLabel1.Margin = new Padding(4, 0, 4, 0);
            skinLabel1.Name = "skinLabel1";
            skinLabel1.Size = new Size(47, 17);
            skinLabel1.TabIndex = 0;
            skinLabel1.Text = "Power:";
            // 
            // skinNumericUpDown_power
            // 
            skinNumericUpDown_power.Location = new Point(314, 26);
            skinNumericUpDown_power.Margin = new Padding(4);
            skinNumericUpDown_power.Maximum = new decimal(new int[] { 33, 0, 0, 0 });
            skinNumericUpDown_power.Name = "skinNumericUpDown_power";
            skinNumericUpDown_power.Size = new Size(74, 23);
            skinNumericUpDown_power.TabIndex = 1;
            skinNumericUpDown_power.TextAlign = HorizontalAlignment.Center;
            skinNumericUpDown_power.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // skinGroupBox6
            // 
            skinGroupBox6.BackColor = Color.Transparent;
            skinGroupBox6.Controls.Add(record_check);
            skinGroupBox6.Controls.Add(buzzer_check);
            skinGroupBox6.Controls.Add(skinLabel49);
            skinGroupBox6.Controls.Add(skinLabel48);
            skinGroupBox6.Controls.Add(skinWaterTextBox_inventory_length);
            skinGroupBox6.Controls.Add(skinLabel47);
            skinGroupBox6.Controls.Add(skinLabel33);
            skinGroupBox6.Controls.Add(skinLabel46);
            skinGroupBox6.Controls.Add(skinWaterTextBox_inventory_address);
            skinGroupBox6.Controls.Add(skinLabel45);
            skinGroupBox6.Controls.Add(skinComboBox_inventory_area);
            skinGroupBox6.Controls.Add(skinLabel44);
            skinGroupBox6.Controls.Add(skinLabel_work_mode);
            skinGroupBox6.Controls.Add(skinNumericUpDown_trigger_time);
            skinGroupBox6.Controls.Add(skinLabel_trigger);
            skinGroupBox6.Controls.Add(skinComboBox_work_mode);
            skinGroupBox6.Controls.Add(skinNumericUpDown_work_interval);
            skinGroupBox6.Controls.Add(skinLabel3);
            skinGroupBox6.Controls.Add(skinLabel2);
            skinGroupBox6.Controls.Add(skinLabel32);
            skinGroupBox6.Controls.Add(skinNumericUpDown_work_filter);
            skinGroupBox6.ForeColor = Color.Black;
            skinGroupBox6.Location = new Point(9, 4);
            skinGroupBox6.Margin = new Padding(4);
            skinGroupBox6.Name = "skinGroupBox6";
            skinGroupBox6.Padding = new Padding(4);
            skinGroupBox6.Size = new Size(662, 191);
            skinGroupBox6.TabIndex = 22;
            skinGroupBox6.TabStop = false;
            skinGroupBox6.Text = "Card reader parameter settings";
            // 
            // record_check
            // 
            record_check.AutoSize = true;
            record_check.BackColor = Color.Transparent;
            record_check.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            record_check.Location = new Point(19, 150);
            record_check.Margin = new Padding(4);
            record_check.Name = "record_check";
            record_check.Size = new Size(174, 21);
            record_check.TabIndex = 30;
            record_check.Text = "Disconnection record tag";
            record_check.UseVisualStyleBackColor = false;
            // 
            // buzzer_check
            // 
            buzzer_check.AutoSize = true;
            buzzer_check.BackColor = Color.Transparent;
            buzzer_check.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            buzzer_check.Location = new Point(220, 150);
            buzzer_check.Margin = new Padding(4);
            buzzer_check.Name = "buzzer_check";
            buzzer_check.Size = new Size(141, 21);
            buzzer_check.TabIndex = 29;
            buzzer_check.Text = "Card reader buzzer";
            buzzer_check.UseVisualStyleBackColor = false;
            // 
            // skinLabel49
            // 
            skinLabel49.AutoSize = true;
            skinLabel49.BackColor = Color.Transparent;
            skinLabel49.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel49.Location = new Point(253, 89);
            skinLabel49.Margin = new Padding(4, 0, 4, 0);
            skinLabel49.Name = "skinLabel49";
            skinLabel49.Size = new Size(56, 17);
            skinLabel49.TabIndex = 28;
            skinLabel49.Text = "(* 10ms)";
            // 
            // skinLabel48
            // 
            skinLabel48.AutoSize = true;
            skinLabel48.BackColor = Color.Transparent;
            skinLabel48.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel48.Location = new Point(561, 89);
            skinLabel48.Margin = new Padding(4, 0, 4, 0);
            skinLabel48.Name = "skinLabel48";
            skinLabel48.Size = new Size(49, 17);
            skinLabel48.TabIndex = 27;
            skinLabel48.Text = "(Word)";
            // 
            // skinWaterTextBox_inventory_length
            // 
            skinWaterTextBox_inventory_length.Location = new Point(469, 89);
            skinWaterTextBox_inventory_length.Margin = new Padding(4);
            skinWaterTextBox_inventory_length.Name = "skinWaterTextBox_inventory_length";
            skinWaterTextBox_inventory_length.Size = new Size(83, 23);
            skinWaterTextBox_inventory_length.TabIndex = 26;
            // 
            // skinLabel47
            // 
            skinLabel47.AutoSize = true;
            skinLabel47.BackColor = Color.Transparent;
            skinLabel47.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel47.Location = new Point(348, 91);
            skinLabel47.Margin = new Padding(4, 0, 4, 0);
            skinLabel47.Name = "skinLabel47";
            skinLabel47.Size = new Size(116, 17);
            skinLabel47.TabIndex = 25;
            skinLabel47.Text = "Card Read Length:";
            // 
            // skinLabel33
            // 
            skinLabel33.AutoSize = true;
            skinLabel33.BackColor = Color.Transparent;
            skinLabel33.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel33.Location = new Point(257, 119);
            skinLabel33.Margin = new Padding(4, 0, 4, 0);
            skinLabel33.Name = "skinLabel33";
            skinLabel33.Size = new Size(23, 17);
            skinLabel33.TabIndex = 20;
            skinLabel33.Text = "(S)";
            // 
            // skinLabel46
            // 
            skinLabel46.AutoSize = true;
            skinLabel46.BackColor = Color.Transparent;
            skinLabel46.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel46.Location = new Point(561, 56);
            skinLabel46.Margin = new Padding(4, 0, 4, 0);
            skinLabel46.Name = "skinLabel46";
            skinLabel46.Size = new Size(49, 17);
            skinLabel46.TabIndex = 24;
            skinLabel46.Text = "(Word)";
            // 
            // skinWaterTextBox_inventory_address
            // 
            skinWaterTextBox_inventory_address.Location = new Point(469, 52);
            skinWaterTextBox_inventory_address.Margin = new Padding(4);
            skinWaterTextBox_inventory_address.Name = "skinWaterTextBox_inventory_address";
            skinWaterTextBox_inventory_address.Size = new Size(83, 23);
            skinWaterTextBox_inventory_address.TabIndex = 23;
            // 
            // skinLabel45
            // 
            skinLabel45.AutoSize = true;
            skinLabel45.BackColor = Color.Transparent;
            skinLabel45.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel45.Location = new Point(321, 57);
            skinLabel45.Margin = new Padding(4, 0, 4, 0);
            skinLabel45.Name = "skinLabel45";
            skinLabel45.Size = new Size(143, 17);
            skinLabel45.TabIndex = 22;
            skinLabel45.Text = "Card Read Start Offset:";
            // 
            // skinComboBox_inventory_area
            // 
            skinComboBox_inventory_area.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_inventory_area.FormattingEnabled = true;
            skinComboBox_inventory_area.Items.AddRange(new object[] { "Reserve", "EPC", "TID", "USER", "TID+EPC", "USRE+EPC", "USER+TID+EPC", "6B_Tag", "6C_EPC_6B_Tags", "YueHe_Temperature_Tag", "DTU_Temperature_Tag", "GB_Standard_Tag" });
            skinComboBox_inventory_area.Location = new Point(469, 22);
            skinComboBox_inventory_area.Margin = new Padding(4);
            skinComboBox_inventory_area.Name = "skinComboBox_inventory_area";
            skinComboBox_inventory_area.Size = new Size(185, 23);
            skinComboBox_inventory_area.TabIndex = 21;
            // 
            // skinLabel44
            // 
            skinLabel44.AutoSize = true;
            skinLabel44.BackColor = Color.Transparent;
            skinLabel44.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel44.Location = new Point(392, 26);
            skinLabel44.Margin = new Padding(4, 0, 4, 0);
            skinLabel44.Name = "skinLabel44";
            skinLabel44.Size = new Size(72, 17);
            skinLabel44.TabIndex = 20;
            skinLabel44.Text = "Read Area:";
            // 
            // skinLabel_work_mode
            // 
            skinLabel_work_mode.AutoSize = true;
            skinLabel_work_mode.BackColor = Color.Transparent;
            skinLabel_work_mode.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_work_mode.Location = new Point(28, 24);
            skinLabel_work_mode.Margin = new Padding(4, 0, 4, 0);
            skinLabel_work_mode.Name = "skinLabel_work_mode";
            skinLabel_work_mode.Size = new Size(81, 17);
            skinLabel_work_mode.TabIndex = 14;
            skinLabel_work_mode.Text = "Work mode:";
            // 
            // skinNumericUpDown_trigger_time
            // 
            skinNumericUpDown_trigger_time.Location = new Point(164, 119);
            skinNumericUpDown_trigger_time.Margin = new Padding(4);
            skinNumericUpDown_trigger_time.Name = "skinNumericUpDown_trigger_time";
            skinNumericUpDown_trigger_time.Size = new Size(79, 23);
            skinNumericUpDown_trigger_time.TabIndex = 9;
            skinNumericUpDown_trigger_time.TextAlign = HorizontalAlignment.Center;
            // 
            // skinLabel_trigger
            // 
            skinLabel_trigger.AutoSize = true;
            skinLabel_trigger.BackColor = Color.Transparent;
            skinLabel_trigger.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel_trigger.Location = new Point(15, 121);
            skinLabel_trigger.Margin = new Padding(4, 0, 4, 0);
            skinLabel_trigger.Name = "skinLabel_trigger";
            skinLabel_trigger.Size = new Size(141, 17);
            skinLabel_trigger.TabIndex = 8;
            skinLabel_trigger.Text = "Trigger extended time:";
            // 
            // skinComboBox_work_mode
            // 
            skinComboBox_work_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_work_mode.FormattingEnabled = true;
            skinComboBox_work_mode.Items.AddRange(new object[] { "Passive mode (command card reading)", "Active mode (timed)", "Trigger mode", "Card swipe mode" });
            skinComboBox_work_mode.Location = new Point(117, 22);
            skinComboBox_work_mode.Margin = new Padding(4);
            skinComboBox_work_mode.Name = "skinComboBox_work_mode";
            skinComboBox_work_mode.Size = new Size(267, 23);
            skinComboBox_work_mode.TabIndex = 15;
            // 
            // skinNumericUpDown_work_interval
            // 
            skinNumericUpDown_work_interval.Location = new Point(164, 85);
            skinNumericUpDown_work_interval.Margin = new Padding(4);
            skinNumericUpDown_work_interval.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            skinNumericUpDown_work_interval.Name = "skinNumericUpDown_work_interval";
            skinNumericUpDown_work_interval.Size = new Size(80, 23);
            skinNumericUpDown_work_interval.TabIndex = 7;
            skinNumericUpDown_work_interval.TextAlign = HorizontalAlignment.Center;
            // 
            // skinLabel3
            // 
            skinLabel3.AutoSize = true;
            skinLabel3.BackColor = Color.Transparent;
            skinLabel3.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel3.Location = new Point(22, 89);
            skinLabel3.Margin = new Padding(4, 0, 4, 0);
            skinLabel3.Name = "skinLabel3";
            skinLabel3.Size = new Size(134, 17);
            skinLabel3.TabIndex = 5;
            skinLabel3.Text = "Card reading interval:";
            // 
            // skinLabel2
            // 
            skinLabel2.AutoSize = true;
            skinLabel2.BackColor = Color.Transparent;
            skinLabel2.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel2.Location = new Point(46, 54);
            skinLabel2.Margin = new Padding(4, 0, 4, 0);
            skinLabel2.Name = "skinLabel2";
            skinLabel2.Size = new Size(110, 17);
            skinLabel2.TabIndex = 4;
            skinLabel2.Text = "Tag filtering time:";
            // 
            // skinLabel32
            // 
            skinLabel32.AutoSize = true;
            skinLabel32.BackColor = Color.Transparent;
            skinLabel32.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel32.Location = new Point(251, 55);
            skinLabel32.Margin = new Padding(4, 0, 4, 0);
            skinLabel32.Name = "skinLabel32";
            skinLabel32.Size = new Size(23, 17);
            skinLabel32.TabIndex = 19;
            skinLabel32.Text = "(S)";
            // 
            // skinNumericUpDown_work_filter
            // 
            skinNumericUpDown_work_filter.Location = new Point(164, 51);
            skinNumericUpDown_work_filter.Margin = new Padding(4);
            skinNumericUpDown_work_filter.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            skinNumericUpDown_work_filter.Name = "skinNumericUpDown_work_filter";
            skinNumericUpDown_work_filter.Size = new Size(80, 23);
            skinNumericUpDown_work_filter.TabIndex = 6;
            skinNumericUpDown_work_filter.TextAlign = HorizontalAlignment.Center;
            // 
            // skinButton_reset
            // 
            skinButton_reset.BackColor = Color.Transparent;
            skinButton_reset.Location = new Point(465, 318);
            skinButton_reset.Margin = new Padding(4);
            skinButton_reset.Name = "skinButton_reset";
            skinButton_reset.Size = new Size(88, 29);
            skinButton_reset.TabIndex = 17;
            skinButton_reset.Text = "Restart";
            skinButton_reset.UseVisualStyleBackColor = false;
            skinButton_reset.Click += skinButton_reset_Click;
            // 
            // skinButton_defualt
            // 
            skinButton_defualt.BackColor = Color.Transparent;
            skinButton_defualt.Location = new Point(98, 318);
            skinButton_defualt.Margin = new Padding(4);
            skinButton_defualt.Name = "skinButton_defualt";
            skinButton_defualt.Size = new Size(104, 29);
            skinButton_defualt.TabIndex = 16;
            skinButton_defualt.Text = "Factory Reset";
            skinButton_defualt.UseVisualStyleBackColor = false;
            skinButton_defualt.Click += skinButton_defualt_Click;
            // 
            // skinButton_work_set
            // 
            skinButton_work_set.BackColor = Color.Transparent;
            skinButton_work_set.Location = new Point(351, 318);
            skinButton_work_set.Margin = new Padding(4);
            skinButton_work_set.Name = "skinButton_work_set";
            skinButton_work_set.Size = new Size(88, 29);
            skinButton_work_set.TabIndex = 3;
            skinButton_work_set.Text = "Save";
            skinButton_work_set.UseVisualStyleBackColor = false;
            skinButton_work_set.Click += skinButton_work_set_Click;
            // 
            // skinButton_work_refresh
            // 
            skinButton_work_refresh.BackColor = Color.Transparent;
            skinButton_work_refresh.Location = new Point(234, 318);
            skinButton_work_refresh.Margin = new Padding(4);
            skinButton_work_refresh.Name = "skinButton_work_refresh";
            skinButton_work_refresh.Size = new Size(88, 29);
            skinButton_work_refresh.TabIndex = 2;
            skinButton_work_refresh.Text = "Query";
            skinButton_work_refresh.UseVisualStyleBackColor = false;
            skinButton_work_refresh.Click += skinButton_work_refresh_Click;
            // 
            // tabPage_transfer
            // 
            tabPage_transfer.Controls.Add(skinGroupBox8);
            tabPage_transfer.Controls.Add(skinGroupBox5);
            tabPage_transfer.Controls.Add(skinComboBox_sub_protocol);
            tabPage_transfer.Controls.Add(skinButton_transfer_set);
            tabPage_transfer.Controls.Add(skinLabel29);
            tabPage_transfer.Controls.Add(skinButton_transfer_query);
            tabPage_transfer.Controls.Add(skinGroupBox3);
            tabPage_transfer.Controls.Add(skinComboBox_transfer_mode);
            tabPage_transfer.Controls.Add(skinLabel6);
            tabPage_transfer.Controls.Add(skinGroupBox2);
            tabPage_transfer.Controls.Add(skinGroupBox1);
            tabPage_transfer.Location = new Point(4, 24);
            tabPage_transfer.Margin = new Padding(4);
            tabPage_transfer.Name = "tabPage_transfer";
            tabPage_transfer.Padding = new Padding(4);
            tabPage_transfer.Size = new Size(676, 466);
            tabPage_transfer.TabIndex = 3;
            tabPage_transfer.Text = "Config";
            tabPage_transfer.UseVisualStyleBackColor = true;
            // 
            // skinGroupBox8
            // 
            skinGroupBox8.BackColor = Color.Transparent;
            skinGroupBox8.Controls.Add(dhcp_check);
            skinGroupBox8.Controls.Add(skinLabel12);
            skinGroupBox8.Controls.Add(skinWaterTextBox_ip_mac);
            skinGroupBox8.Controls.Add(skinWaterTextBox_gate_way);
            skinGroupBox8.Controls.Add(skinLabel13);
            skinGroupBox8.Controls.Add(skinWaterTextBox_ip_local);
            skinGroupBox8.Controls.Add(skinLabel19);
            skinGroupBox8.Controls.Add(skinLabel14);
            skinGroupBox8.Controls.Add(skinWaterTextBox_local_port);
            skinGroupBox8.Controls.Add(skinWaterTextBox_ip_sub_masker);
            skinGroupBox8.Controls.Add(skinLabel18);
            skinGroupBox8.ForeColor = Color.Black;
            skinGroupBox8.Location = new Point(6, 229);
            skinGroupBox8.Margin = new Padding(4);
            skinGroupBox8.Name = "skinGroupBox8";
            skinGroupBox8.Padding = new Padding(4);
            skinGroupBox8.Size = new Size(660, 90);
            skinGroupBox8.TabIndex = 8;
            skinGroupBox8.TabStop = false;
            skinGroupBox8.Text = "Reader local network parameters";
            // 
            // dhcp_check
            // 
            dhcp_check.AutoSize = true;
            dhcp_check.BackColor = Color.Transparent;
            dhcp_check.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dhcp_check.Location = new Point(42, 52);
            dhcp_check.Margin = new Padding(4);
            dhcp_check.Name = "dhcp_check";
            dhcp_check.Size = new Size(60, 21);
            dhcp_check.TabIndex = 15;
            dhcp_check.Text = "DHCP";
            dhcp_check.UseVisualStyleBackColor = false;
            // 
            // skinLabel12
            // 
            skinLabel12.AutoSize = true;
            skinLabel12.BackColor = Color.Transparent;
            skinLabel12.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel12.Location = new Point(456, 26);
            skinLabel12.Margin = new Padding(4, 0, 4, 0);
            skinLabel12.Name = "skinLabel12";
            skinLabel12.Size = new Size(39, 17);
            skinLabel12.TabIndex = 0;
            skinLabel12.Text = "MAC:";
            // 
            // skinWaterTextBox_ip_mac
            // 
            skinWaterTextBox_ip_mac.Location = new Point(506, 22);
            skinWaterTextBox_ip_mac.Margin = new Padding(4);
            skinWaterTextBox_ip_mac.Name = "skinWaterTextBox_ip_mac";
            skinWaterTextBox_ip_mac.Size = new Size(131, 23);
            skinWaterTextBox_ip_mac.TabIndex = 1;
            // 
            // skinWaterTextBox_gate_way
            // 
            skinWaterTextBox_gate_way.Location = new Point(506, 52);
            skinWaterTextBox_gate_way.Margin = new Padding(4);
            skinWaterTextBox_gate_way.Name = "skinWaterTextBox_gate_way";
            skinWaterTextBox_gate_way.Size = new Size(116, 23);
            skinWaterTextBox_gate_way.TabIndex = 16;
            // 
            // skinLabel13
            // 
            skinLabel13.AutoSize = true;
            skinLabel13.BackColor = Color.Transparent;
            skinLabel13.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel13.Location = new Point(37, 24);
            skinLabel13.Margin = new Padding(4, 0, 4, 0);
            skinLabel13.Name = "skinLabel13";
            skinLabel13.Size = new Size(26, 17);
            skinLabel13.TabIndex = 2;
            skinLabel13.Text = " IP:";
            // 
            // skinWaterTextBox_ip_local
            // 
            skinWaterTextBox_ip_local.Location = new Point(72, 22);
            skinWaterTextBox_ip_local.Margin = new Padding(4);
            skinWaterTextBox_ip_local.Name = "skinWaterTextBox_ip_local";
            skinWaterTextBox_ip_local.Size = new Size(121, 23);
            skinWaterTextBox_ip_local.TabIndex = 3;
            // 
            // skinLabel19
            // 
            skinLabel19.AutoSize = true;
            skinLabel19.BackColor = Color.Transparent;
            skinLabel19.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel19.Location = new Point(433, 54);
            skinLabel19.Margin = new Padding(4, 0, 4, 0);
            skinLabel19.Name = "skinLabel19";
            skinLabel19.Size = new Size(60, 17);
            skinLabel19.TabIndex = 15;
            skinLabel19.Text = "Gateway:";
            // 
            // skinLabel14
            // 
            skinLabel14.AutoSize = true;
            skinLabel14.BackColor = Color.Transparent;
            skinLabel14.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel14.Location = new Point(222, 22);
            skinLabel14.Margin = new Padding(4, 0, 4, 0);
            skinLabel14.Name = "skinLabel14";
            skinLabel14.Size = new Size(35, 17);
            skinLabel14.TabIndex = 4;
            skinLabel14.Text = "Port:";
            // 
            // skinWaterTextBox_local_port
            // 
            skinWaterTextBox_local_port.Location = new Point(270, 22);
            skinWaterTextBox_local_port.Margin = new Padding(4);
            skinWaterTextBox_local_port.Name = "skinWaterTextBox_local_port";
            skinWaterTextBox_local_port.Size = new Size(88, 23);
            skinWaterTextBox_local_port.TabIndex = 5;
            // 
            // skinWaterTextBox_ip_sub_masker
            // 
            skinWaterTextBox_ip_sub_masker.Location = new Point(270, 52);
            skinWaterTextBox_ip_sub_masker.Margin = new Padding(4);
            skinWaterTextBox_ip_sub_masker.Name = "skinWaterTextBox_ip_sub_masker";
            skinWaterTextBox_ip_sub_masker.Size = new Size(116, 23);
            skinWaterTextBox_ip_sub_masker.TabIndex = 14;
            // 
            // skinLabel18
            // 
            skinLabel18.AutoSize = true;
            skinLabel18.BackColor = Color.Transparent;
            skinLabel18.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel18.Location = new Point(175, 55);
            skinLabel18.Margin = new Padding(4, 0, 4, 0);
            skinLabel18.Name = "skinLabel18";
            skinLabel18.Size = new Size(87, 17);
            skinLabel18.TabIndex = 13;
            skinLabel18.Text = "Subnet Mask:";
            // 
            // skinGroupBox5
            // 
            skinGroupBox5.BackColor = Color.Transparent;
            skinGroupBox5.Controls.Add(skinWaterTextBox_module_id);
            skinGroupBox5.Controls.Add(skinWaterTextBox_module_sn);
            skinGroupBox5.Controls.Add(skinLabel43);
            skinGroupBox5.Controls.Add(skinLabel42);
            skinGroupBox5.ForeColor = Color.Black;
            skinGroupBox5.Location = new Point(7, 138);
            skinGroupBox5.Margin = new Padding(4);
            skinGroupBox5.Name = "skinGroupBox5";
            skinGroupBox5.Padding = new Padding(4);
            skinGroupBox5.Size = new Size(247, 82);
            skinGroupBox5.TabIndex = 7;
            skinGroupBox5.TabStop = false;
            skinGroupBox5.Text = "Syris485";
            // 
            // skinWaterTextBox_module_id
            // 
            skinWaterTextBox_module_id.Location = new Point(62, 54);
            skinWaterTextBox_module_id.Margin = new Padding(4);
            skinWaterTextBox_module_id.Name = "skinWaterTextBox_module_id";
            skinWaterTextBox_module_id.Size = new Size(116, 23);
            skinWaterTextBox_module_id.TabIndex = 3;
            // 
            // skinWaterTextBox_module_sn
            // 
            skinWaterTextBox_module_sn.Location = new Point(62, 26);
            skinWaterTextBox_module_sn.Margin = new Padding(4);
            skinWaterTextBox_module_sn.Name = "skinWaterTextBox_module_sn";
            skinWaterTextBox_module_sn.Size = new Size(116, 23);
            skinWaterTextBox_module_sn.TabIndex = 2;
            // 
            // skinLabel43
            // 
            skinLabel43.AutoSize = true;
            skinLabel43.BackColor = Color.Transparent;
            skinLabel43.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel43.Location = new Point(31, 56);
            skinLabel43.Margin = new Padding(4, 0, 4, 0);
            skinLabel43.Name = "skinLabel43";
            skinLabel43.Size = new Size(24, 17);
            skinLabel43.TabIndex = 1;
            skinLabel43.Text = "ID:";
            // 
            // skinLabel42
            // 
            skinLabel42.AutoSize = true;
            skinLabel42.BackColor = Color.Transparent;
            skinLabel42.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel42.Location = new Point(27, 28);
            skinLabel42.Margin = new Padding(4, 0, 4, 0);
            skinLabel42.Name = "skinLabel42";
            skinLabel42.Size = new Size(28, 17);
            skinLabel42.TabIndex = 0;
            skinLabel42.Text = "SN:";
            // 
            // skinComboBox_sub_protocol
            // 
            skinComboBox_sub_protocol.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_sub_protocol.FormattingEnabled = true;
            skinComboBox_sub_protocol.Items.AddRange(new object[] { "TCP-Server", "TCP-Client", "UDP", "HTTP Client" });
            skinComboBox_sub_protocol.Location = new Point(117, 44);
            skinComboBox_sub_protocol.Margin = new Padding(4);
            skinComboBox_sub_protocol.Name = "skinComboBox_sub_protocol";
            skinComboBox_sub_protocol.Size = new Size(142, 23);
            skinComboBox_sub_protocol.TabIndex = 22;
            // 
            // skinButton_transfer_set
            // 
            skinButton_transfer_set.BackColor = Color.Transparent;
            skinButton_transfer_set.Location = new Point(374, 429);
            skinButton_transfer_set.Margin = new Padding(4);
            skinButton_transfer_set.Name = "skinButton_transfer_set";
            skinButton_transfer_set.Size = new Size(88, 29);
            skinButton_transfer_set.TabIndex = 6;
            skinButton_transfer_set.Text = "Save";
            skinButton_transfer_set.UseVisualStyleBackColor = false;
            skinButton_transfer_set.Click += skinButton_transfer_set_Click;
            // 
            // skinLabel29
            // 
            skinLabel29.AutoSize = true;
            skinLabel29.BackColor = Color.Transparent;
            skinLabel29.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel29.Location = new Point(8, 47);
            skinLabel29.Margin = new Padding(4, 0, 4, 0);
            skinLabel29.Name = "skinLabel29";
            skinLabel29.Size = new Size(99, 17);
            skinLabel29.TabIndex = 21;
            skinLabel29.Text = "Comm Protocol";
            // 
            // skinButton_transfer_query
            // 
            skinButton_transfer_query.BackColor = Color.Transparent;
            skinButton_transfer_query.Location = new Point(192, 429);
            skinButton_transfer_query.Margin = new Padding(4);
            skinButton_transfer_query.Name = "skinButton_transfer_query";
            skinButton_transfer_query.Size = new Size(88, 29);
            skinButton_transfer_query.TabIndex = 5;
            skinButton_transfer_query.Text = "Query";
            skinButton_transfer_query.UseVisualStyleBackColor = false;
            skinButton_transfer_query.Click += skinButton_transfer_query_Click;
            // 
            // skinGroupBox3
            // 
            skinGroupBox3.BackColor = Color.Transparent;
            skinGroupBox3.Controls.Add(radioButton_remote_ipmode_host);
            skinGroupBox3.Controls.Add(radioButton_remote_ipmode_IP);
            skinGroupBox3.Controls.Add(skinWaterTextBox_heart_beats);
            skinGroupBox3.Controls.Add(skinLabel17);
            skinGroupBox3.Controls.Add(skinLabel30);
            skinGroupBox3.Controls.Add(skinWaterTextBox_remote_port);
            skinGroupBox3.Controls.Add(skinWaterTextBox_ip_remote);
            skinGroupBox3.Controls.Add(skinLabel16);
            skinGroupBox3.Controls.Add(skinLabel15);
            skinGroupBox3.ForeColor = Color.Black;
            skinGroupBox3.Location = new Point(7, 322);
            skinGroupBox3.Margin = new Padding(4);
            skinGroupBox3.Name = "skinGroupBox3";
            skinGroupBox3.Padding = new Padding(4);
            skinGroupBox3.Size = new Size(659, 99);
            skinGroupBox3.TabIndex = 4;
            skinGroupBox3.TabStop = false;
            skinGroupBox3.Text = "Remote server parameters";
            // 
            // radioButton_remote_ipmode_host
            // 
            radioButton_remote_ipmode_host.AutoSize = true;
            radioButton_remote_ipmode_host.Location = new Point(479, 22);
            radioButton_remote_ipmode_host.Margin = new Padding(4);
            radioButton_remote_ipmode_host.Name = "radioButton_remote_ipmode_host";
            radioButton_remote_ipmode_host.Size = new Size(100, 19);
            radioButton_remote_ipmode_host.TabIndex = 23;
            radioButton_remote_ipmode_host.TabStop = true;
            radioButton_remote_ipmode_host.Text = "Domain name";
            radioButton_remote_ipmode_host.UseVisualStyleBackColor = true;
            // 
            // radioButton_remote_ipmode_IP
            // 
            radioButton_remote_ipmode_IP.AutoSize = true;
            radioButton_remote_ipmode_IP.Location = new Point(404, 22);
            radioButton_remote_ipmode_IP.Margin = new Padding(4);
            radioButton_remote_ipmode_IP.Name = "radioButton_remote_ipmode_IP";
            radioButton_remote_ipmode_IP.Size = new Size(76, 19);
            radioButton_remote_ipmode_IP.TabIndex = 23;
            radioButton_remote_ipmode_IP.TabStop = true;
            radioButton_remote_ipmode_IP.Text = "IP Format";
            radioButton_remote_ipmode_IP.UseVisualStyleBackColor = true;
            // 
            // skinWaterTextBox_heart_beats
            // 
            skinWaterTextBox_heart_beats.Location = new Point(334, 56);
            skinWaterTextBox_heart_beats.Margin = new Padding(4);
            skinWaterTextBox_heart_beats.Name = "skinWaterTextBox_heart_beats";
            skinWaterTextBox_heart_beats.Size = new Size(62, 23);
            skinWaterTextBox_heart_beats.TabIndex = 20;
            // 
            // skinLabel17
            // 
            skinLabel17.AutoSize = true;
            skinLabel17.BackColor = Color.Transparent;
            skinLabel17.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel17.Location = new Point(400, 59);
            skinLabel17.Margin = new Padding(4, 0, 4, 0);
            skinLabel17.Name = "skinLabel17";
            skinLabel17.Size = new Size(41, 17);
            skinLabel17.TabIndex = 20;
            skinLabel17.Text = "(*10s)";
            // 
            // skinLabel30
            // 
            skinLabel30.AutoSize = true;
            skinLabel30.BackColor = Color.Transparent;
            skinLabel30.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel30.Location = new Point(261, 60);
            skinLabel30.Margin = new Padding(4, 0, 4, 0);
            skinLabel30.Name = "skinLabel30";
            skinLabel30.Size = new Size(69, 17);
            skinLabel30.TabIndex = 19;
            skinLabel30.Text = "Heartbeat:";
            // 
            // skinWaterTextBox_remote_port
            // 
            skinWaterTextBox_remote_port.Location = new Point(69, 56);
            skinWaterTextBox_remote_port.Margin = new Padding(4);
            skinWaterTextBox_remote_port.Name = "skinWaterTextBox_remote_port";
            skinWaterTextBox_remote_port.Size = new Size(72, 23);
            skinWaterTextBox_remote_port.TabIndex = 9;
            // 
            // skinWaterTextBox_ip_remote
            // 
            skinWaterTextBox_ip_remote.Location = new Point(68, 22);
            skinWaterTextBox_ip_remote.Margin = new Padding(4);
            skinWaterTextBox_ip_remote.Name = "skinWaterTextBox_ip_remote";
            skinWaterTextBox_ip_remote.Size = new Size(312, 23);
            skinWaterTextBox_ip_remote.TabIndex = 8;
            // 
            // skinLabel16
            // 
            skinLabel16.AutoSize = true;
            skinLabel16.BackColor = Color.Transparent;
            skinLabel16.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel16.Location = new Point(27, 60);
            skinLabel16.Margin = new Padding(4, 0, 4, 0);
            skinLabel16.Name = "skinLabel16";
            skinLabel16.Size = new Size(35, 17);
            skinLabel16.TabIndex = 7;
            skinLabel16.Text = "Port:";
            // 
            // skinLabel15
            // 
            skinLabel15.AutoSize = true;
            skinLabel15.BackColor = Color.Transparent;
            skinLabel15.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel15.Location = new Point(6, 25);
            skinLabel15.Margin = new Padding(4, 0, 4, 0);
            skinLabel15.Name = "skinLabel15";
            skinLabel15.Size = new Size(59, 17);
            skinLabel15.TabIndex = 6;
            skinLabel15.Text = "Address:";
            // 
            // skinComboBox_transfer_mode
            // 
            skinComboBox_transfer_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_transfer_mode.FormattingEnabled = true;
            skinComboBox_transfer_mode.Items.AddRange(new object[] { "RS232/RS485", "Wiegand", "RJ45", "Syris485", "4G", "ModbusRtu", "ModBusTcp", "USB Keyboard", "USB Virtual COM", "WIFI" });
            skinComboBox_transfer_mode.Location = new Point(117, 8);
            skinComboBox_transfer_mode.Margin = new Padding(4);
            skinComboBox_transfer_mode.Name = "skinComboBox_transfer_mode";
            skinComboBox_transfer_mode.Size = new Size(142, 23);
            skinComboBox_transfer_mode.TabIndex = 3;
            skinComboBox_transfer_mode.SelectedIndexChanged += skinComboBox_transfer_mode_SelectedIndexChanged;
            // 
            // skinLabel6
            // 
            skinLabel6.AutoSize = true;
            skinLabel6.BackColor = Color.Transparent;
            skinLabel6.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel6.ForeColor = Color.Black;
            skinLabel6.Location = new Point(8, 11);
            skinLabel6.Margin = new Padding(4, 0, 4, 0);
            skinLabel6.Name = "skinLabel6";
            skinLabel6.Size = new Size(106, 17);
            skinLabel6.TabIndex = 2;
            skinLabel6.Text = "Output Interface:";
            // 
            // skinGroupBox2
            // 
            skinGroupBox2.BackColor = Color.Transparent;
            skinGroupBox2.Controls.Add(skinComboBox_wiegand_direction);
            skinGroupBox2.Controls.Add(label4);
            skinGroupBox2.Controls.Add(label3);
            skinGroupBox2.Controls.Add(label2);
            skinGroupBox2.Controls.Add(skinNumericUpDown_wiegand_location);
            skinGroupBox2.Controls.Add(skinWaterTextBox_wiegand_interval);
            skinGroupBox2.Controls.Add(skinWaterTextBox_wiegand_prorid);
            skinGroupBox2.Controls.Add(skinWaterTextBox_wiegand_width);
            skinGroupBox2.Controls.Add(skinComboBox_wiegand_protocl);
            skinGroupBox2.Controls.Add(skinLabel11);
            skinGroupBox2.Controls.Add(skinLabel10);
            skinGroupBox2.Controls.Add(skinLabel9);
            skinGroupBox2.Controls.Add(skinLabel8);
            skinGroupBox2.Controls.Add(skinLabel7);
            skinGroupBox2.ForeColor = Color.Black;
            skinGroupBox2.Location = new Point(321, 8);
            skinGroupBox2.Margin = new Padding(4);
            skinGroupBox2.Name = "skinGroupBox2";
            skinGroupBox2.Padding = new Padding(4);
            skinGroupBox2.Size = new Size(346, 188);
            skinGroupBox2.TabIndex = 1;
            skinGroupBox2.TabStop = false;
            skinGroupBox2.Text = "Wiegand settings";
            // 
            // skinComboBox_wiegand_direction
            // 
            skinComboBox_wiegand_direction.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_wiegand_direction.FormattingEnabled = true;
            skinComboBox_wiegand_direction.Items.AddRange(new object[] { "MSB First", "LSB First" });
            skinComboBox_wiegand_direction.Location = new Point(260, 150);
            skinComboBox_wiegand_direction.Margin = new Padding(4);
            skinComboBox_wiegand_direction.Name = "skinComboBox_wiegand_direction";
            skinComboBox_wiegand_direction.Size = new Size(79, 23);
            skinComboBox_wiegand_direction.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(244, 124);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 12;
            label4.Text = "(* 10ms)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(244, 90);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 11;
            label3.Text = "(* 100 us)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 56);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 10;
            label2.Text = "(*10 us)";
            // 
            // skinNumericUpDown_wiegand_location
            // 
            skinNumericUpDown_wiegand_location.Location = new Point(161, 150);
            skinNumericUpDown_wiegand_location.Margin = new Padding(4);
            skinNumericUpDown_wiegand_location.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            skinNumericUpDown_wiegand_location.Name = "skinNumericUpDown_wiegand_location";
            skinNumericUpDown_wiegand_location.Size = new Size(75, 23);
            skinNumericUpDown_wiegand_location.TabIndex = 9;
            skinNumericUpDown_wiegand_location.TextAlign = HorizontalAlignment.Center;
            // 
            // skinWaterTextBox_wiegand_interval
            // 
            skinWaterTextBox_wiegand_interval.Location = new Point(162, 120);
            skinWaterTextBox_wiegand_interval.Margin = new Padding(4);
            skinWaterTextBox_wiegand_interval.Name = "skinWaterTextBox_wiegand_interval";
            skinWaterTextBox_wiegand_interval.Size = new Size(74, 23);
            skinWaterTextBox_wiegand_interval.TabIndex = 8;
            // 
            // skinWaterTextBox_wiegand_prorid
            // 
            skinWaterTextBox_wiegand_prorid.Location = new Point(162, 86);
            skinWaterTextBox_wiegand_prorid.Margin = new Padding(4);
            skinWaterTextBox_wiegand_prorid.Name = "skinWaterTextBox_wiegand_prorid";
            skinWaterTextBox_wiegand_prorid.Size = new Size(74, 23);
            skinWaterTextBox_wiegand_prorid.TabIndex = 7;
            // 
            // skinWaterTextBox_wiegand_width
            // 
            skinWaterTextBox_wiegand_width.Location = new Point(162, 52);
            skinWaterTextBox_wiegand_width.Margin = new Padding(4);
            skinWaterTextBox_wiegand_width.Name = "skinWaterTextBox_wiegand_width";
            skinWaterTextBox_wiegand_width.Size = new Size(74, 23);
            skinWaterTextBox_wiegand_width.TabIndex = 6;
            // 
            // skinComboBox_wiegand_protocl
            // 
            skinComboBox_wiegand_protocl.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_wiegand_protocl.FormattingEnabled = true;
            skinComboBox_wiegand_protocl.Items.AddRange(new object[] { "Wiegand26", "Wiegand32", "Wiegand34", "Wiegand44" });
            skinComboBox_wiegand_protocl.Location = new Point(162, 23);
            skinComboBox_wiegand_protocl.Margin = new Padding(4);
            skinComboBox_wiegand_protocl.Name = "skinComboBox_wiegand_protocl";
            skinComboBox_wiegand_protocl.Size = new Size(114, 23);
            skinComboBox_wiegand_protocl.TabIndex = 5;
            // 
            // skinLabel11
            // 
            skinLabel11.AutoSize = true;
            skinLabel11.BackColor = Color.Transparent;
            skinLabel11.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel11.Location = new Point(16, 153);
            skinLabel11.Margin = new Padding(4, 0, 4, 0);
            skinLabel11.Name = "skinLabel11";
            skinLabel11.Size = new Size(134, 17);
            skinLabel11.TabIndex = 4;
            skinLabel11.Text = "Output label position:";
            // 
            // skinLabel10
            // 
            skinLabel10.AutoSize = true;
            skinLabel10.BackColor = Color.Transparent;
            skinLabel10.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel10.Location = new Point(3, 120);
            skinLabel10.Margin = new Padding(4, 0, 4, 0);
            skinLabel10.Name = "skinLabel10";
            skinLabel10.Size = new Size(147, 17);
            skinLabel10.TabIndex = 3;
            skinLabel10.Text = "Communication interval:";
            // 
            // skinLabel9
            // 
            skinLabel9.AutoSize = true;
            skinLabel9.BackColor = Color.Transparent;
            skinLabel9.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel9.Location = new Point(66, 92);
            skinLabel9.Margin = new Padding(4, 0, 4, 0);
            skinLabel9.Name = "skinLabel9";
            skinLabel9.Size = new Size(84, 17);
            skinLabel9.TabIndex = 2;
            skinLabel9.Text = "Pulse period:";
            // 
            // skinLabel8
            // 
            skinLabel8.AutoSize = true;
            skinLabel8.BackColor = Color.Transparent;
            skinLabel8.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel8.Location = new Point(74, 56);
            skinLabel8.Margin = new Padding(4, 0, 4, 0);
            skinLabel8.Name = "skinLabel8";
            skinLabel8.Size = new Size(76, 17);
            skinLabel8.TabIndex = 1;
            skinLabel8.Text = "Pulse width:";
            // 
            // skinLabel7
            // 
            skinLabel7.AutoSize = true;
            skinLabel7.BackColor = Color.Transparent;
            skinLabel7.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel7.Location = new Point(55, 25);
            skinLabel7.Margin = new Padding(4, 0, 4, 0);
            skinLabel7.Name = "skinLabel7";
            skinLabel7.Size = new Size(95, 17);
            skinLabel7.TabIndex = 0;
            skinLabel7.Text = "Wiegand Type:";
            // 
            // skinGroupBox1
            // 
            skinGroupBox1.BackColor = Color.Transparent;
            skinGroupBox1.Controls.Add(skinComboBox_transfer_baudrate);
            skinGroupBox1.Controls.Add(skinLabel5);
            skinGroupBox1.ForeColor = Color.Black;
            skinGroupBox1.Location = new Point(7, 76);
            skinGroupBox1.Margin = new Padding(4);
            skinGroupBox1.Name = "skinGroupBox1";
            skinGroupBox1.Padding = new Padding(4);
            skinGroupBox1.Size = new Size(248, 59);
            skinGroupBox1.TabIndex = 0;
            skinGroupBox1.TabStop = false;
            skinGroupBox1.Text = "RS232 / RS485";
            // 
            // skinComboBox_transfer_baudrate
            // 
            skinComboBox_transfer_baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_transfer_baudrate.FormattingEnabled = true;
            skinComboBox_transfer_baudrate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            skinComboBox_transfer_baudrate.Location = new Point(119, 22);
            skinComboBox_transfer_baudrate.Margin = new Padding(4);
            skinComboBox_transfer_baudrate.Name = "skinComboBox_transfer_baudrate";
            skinComboBox_transfer_baudrate.Size = new Size(115, 23);
            skinComboBox_transfer_baudrate.TabIndex = 1;
            // 
            // skinLabel5
            // 
            skinLabel5.AutoSize = true;
            skinLabel5.BackColor = Color.Transparent;
            skinLabel5.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel5.Location = new Point(36, 26);
            skinLabel5.Margin = new Padding(4, 0, 4, 0);
            skinLabel5.Name = "skinLabel5";
            skinLabel5.Size = new Size(64, 17);
            skinLabel5.TabIndex = 0;
            skinLabel5.Text = "Baudrate:";
            // 
            // tabPage_advance
            // 
            tabPage_advance.Controls.Add(skinButton_advance_cancel_select);
            tabPage_advance.Controls.Add(flowLayoutPanel_advance_freqs);
            tabPage_advance.Controls.Add(label27);
            tabPage_advance.Controls.Add(textBox_advan_rssi);
            tabPage_advance.Controls.Add(skinNumericUpDown_advan_Q);
            tabPage_advance.Controls.Add(skinButton_advance_set);
            tabPage_advance.Controls.Add(skinButton_advance_refresh);
            tabPage_advance.Controls.Add(skinLabel28);
            tabPage_advance.Controls.Add(skinLabel27);
            tabPage_advance.Controls.Add(skinComboBox_advan_target);
            tabPage_advance.Controls.Add(skinLabel26);
            tabPage_advance.Controls.Add(skinComboBox_advan_session);
            tabPage_advance.Controls.Add(skinLabel25);
            tabPage_advance.Controls.Add(skinComboBox_advan_sel);
            tabPage_advance.Controls.Add(skinLabel24);
            tabPage_advance.Controls.Add(skinComboBox_advan_cw);
            tabPage_advance.Controls.Add(skinLabel23);
            tabPage_advance.Controls.Add(skinComboBox_advan_hopping);
            tabPage_advance.Controls.Add(skinLabel22);
            tabPage_advance.Controls.Add(skinWaterTextBox_advan_channel);
            tabPage_advance.Controls.Add(skinLabel21);
            tabPage_advance.Controls.Add(skinComboBox_advan_region);
            tabPage_advance.Controls.Add(skinLabel20);
            tabPage_advance.Location = new Point(4, 24);
            tabPage_advance.Margin = new Padding(4);
            tabPage_advance.Name = "tabPage_advance";
            tabPage_advance.Padding = new Padding(4);
            tabPage_advance.Size = new Size(676, 466);
            tabPage_advance.TabIndex = 4;
            tabPage_advance.Text = "Advance Config";
            tabPage_advance.UseVisualStyleBackColor = true;
            // 
            // skinButton_advance_cancel_select
            // 
            skinButton_advance_cancel_select.BackColor = Color.Transparent;
            skinButton_advance_cancel_select.Location = new Point(540, 427);
            skinButton_advance_cancel_select.Margin = new Padding(4);
            skinButton_advance_cancel_select.Name = "skinButton_advance_cancel_select";
            skinButton_advance_cancel_select.Size = new Size(127, 29);
            skinButton_advance_cancel_select.TabIndex = 0;
            skinButton_advance_cancel_select.Text = "Cancel selection";
            skinButton_advance_cancel_select.UseVisualStyleBackColor = false;
            skinButton_advance_cancel_select.Click += skinButton_advance_cancel_select_Click;
            // 
            // flowLayoutPanel_advance_freqs
            // 
            flowLayoutPanel_advance_freqs.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_advance_freqs.Location = new Point(8, 152);
            flowLayoutPanel_advance_freqs.Margin = new Padding(4);
            flowLayoutPanel_advance_freqs.Name = "flowLayoutPanel_advance_freqs";
            flowLayoutPanel_advance_freqs.Size = new Size(659, 263);
            flowLayoutPanel_advance_freqs.TabIndex = 23;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(188, 103);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(47, 15);
            label27.TabIndex = 22;
            label27.Text = "(0~255)";
            // 
            // textBox_advan_rssi
            // 
            textBox_advan_rssi.Location = new Point(109, 97);
            textBox_advan_rssi.Margin = new Padding(4);
            textBox_advan_rssi.Name = "textBox_advan_rssi";
            textBox_advan_rssi.Size = new Size(70, 23);
            textBox_advan_rssi.TabIndex = 21;
            // 
            // skinNumericUpDown_advan_Q
            // 
            skinNumericUpDown_advan_Q.Location = new Point(315, 99);
            skinNumericUpDown_advan_Q.Margin = new Padding(4);
            skinNumericUpDown_advan_Q.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            skinNumericUpDown_advan_Q.Name = "skinNumericUpDown_advan_Q";
            skinNumericUpDown_advan_Q.Size = new Size(50, 23);
            skinNumericUpDown_advan_Q.TabIndex = 20;
            skinNumericUpDown_advan_Q.TextAlign = HorizontalAlignment.Center;
            // 
            // skinButton_advance_set
            // 
            skinButton_advance_set.BackColor = Color.Transparent;
            skinButton_advance_set.Location = new Point(324, 425);
            skinButton_advance_set.Margin = new Padding(4);
            skinButton_advance_set.Name = "skinButton_advance_set";
            skinButton_advance_set.Size = new Size(88, 29);
            skinButton_advance_set.TabIndex = 19;
            skinButton_advance_set.Text = "Save";
            skinButton_advance_set.UseVisualStyleBackColor = false;
            skinButton_advance_set.Click += skinButton_advance_set_Click;
            // 
            // skinButton_advance_refresh
            // 
            skinButton_advance_refresh.BackColor = Color.Transparent;
            skinButton_advance_refresh.Location = new Point(218, 425);
            skinButton_advance_refresh.Margin = new Padding(4);
            skinButton_advance_refresh.Name = "skinButton_advance_refresh";
            skinButton_advance_refresh.Size = new Size(88, 29);
            skinButton_advance_refresh.TabIndex = 18;
            skinButton_advance_refresh.Text = "Query";
            skinButton_advance_refresh.UseVisualStyleBackColor = false;
            skinButton_advance_refresh.Click += skinButton_advance_refresh_Click;
            // 
            // skinLabel28
            // 
            skinLabel28.AutoSize = true;
            skinLabel28.BackColor = Color.Transparent;
            skinLabel28.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel28.Location = new Point(13, 101);
            skinLabel28.Margin = new Padding(4, 0, 4, 0);
            skinLabel28.Name = "skinLabel28";
            skinLabel28.Size = new Size(96, 17);
            skinLabel28.TabIndex = 16;
            skinLabel28.Text = "RSSI threshold:";
            // 
            // skinLabel27
            // 
            skinLabel27.AutoSize = true;
            skinLabel27.BackColor = Color.Transparent;
            skinLabel27.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel27.Location = new Point(261, 99);
            skinLabel27.Margin = new Padding(4, 0, 4, 0);
            skinLabel27.Name = "skinLabel27";
            skinLabel27.Size = new Size(55, 17);
            skinLabel27.TabIndex = 14;
            skinLabel27.Text = "Q value:";
            // 
            // skinComboBox_advan_target
            // 
            skinComboBox_advan_target.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_target.FormattingEnabled = true;
            skinComboBox_advan_target.Items.AddRange(new object[] { "target A", "target B" });
            skinComboBox_advan_target.Location = new Point(513, 54);
            skinComboBox_advan_target.Margin = new Padding(4);
            skinComboBox_advan_target.Name = "skinComboBox_advan_target";
            skinComboBox_advan_target.Size = new Size(100, 23);
            skinComboBox_advan_target.TabIndex = 13;
            // 
            // skinLabel26
            // 
            skinLabel26.AutoSize = true;
            skinLabel26.BackColor = Color.Transparent;
            skinLabel26.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel26.Location = new Point(456, 54);
            skinLabel26.Margin = new Padding(4, 0, 4, 0);
            skinLabel26.Name = "skinLabel26";
            skinLabel26.Size = new Size(49, 17);
            skinLabel26.TabIndex = 12;
            skinLabel26.Text = "Target:";
            // 
            // skinComboBox_advan_session
            // 
            skinComboBox_advan_session.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_session.FormattingEnabled = true;
            skinComboBox_advan_session.Items.AddRange(new object[] { "Sesion0", "Session1", "Session2", "Session3" });
            skinComboBox_advan_session.Location = new Point(294, 51);
            skinComboBox_advan_session.Margin = new Padding(4);
            skinComboBox_advan_session.Name = "skinComboBox_advan_session";
            skinComboBox_advan_session.Size = new Size(146, 23);
            skinComboBox_advan_session.TabIndex = 11;
            // 
            // skinLabel25
            // 
            skinLabel25.AutoSize = true;
            skinLabel25.BackColor = Color.Transparent;
            skinLabel25.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel25.Location = new Point(230, 52);
            skinLabel25.Margin = new Padding(4, 0, 4, 0);
            skinLabel25.Name = "skinLabel25";
            skinLabel25.Size = new Size(55, 17);
            skinLabel25.TabIndex = 10;
            skinLabel25.Text = "Session:";
            // 
            // skinComboBox_advan_sel
            // 
            skinComboBox_advan_sel.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_sel.FormattingEnabled = true;
            skinComboBox_advan_sel.Items.AddRange(new object[] { "ALL", "ALL", "~SL", "SL" });
            skinComboBox_advan_sel.Location = new Point(150, 51);
            skinComboBox_advan_sel.Margin = new Padding(4);
            skinComboBox_advan_sel.Name = "skinComboBox_advan_sel";
            skinComboBox_advan_sel.Size = new Size(65, 23);
            skinComboBox_advan_sel.TabIndex = 9;
            // 
            // skinLabel24
            // 
            skinLabel24.AutoSize = true;
            skinLabel24.BackColor = Color.Transparent;
            skinLabel24.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel24.Location = new Point(119, 54);
            skinLabel24.Margin = new Padding(4, 0, 4, 0);
            skinLabel24.Name = "skinLabel24";
            skinLabel24.Size = new Size(28, 17);
            skinLabel24.TabIndex = 8;
            skinLabel24.Text = "Sel:";
            // 
            // skinComboBox_advan_cw
            // 
            skinComboBox_advan_cw.AutoCompleteCustomSource.AddRange(new string[] { "off", "on" });
            skinComboBox_advan_cw.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_cw.FormattingEnabled = true;
            skinComboBox_advan_cw.Items.AddRange(new object[] { "off", "on" });
            skinComboBox_advan_cw.Location = new Point(46, 52);
            skinComboBox_advan_cw.Margin = new Padding(4);
            skinComboBox_advan_cw.Name = "skinComboBox_advan_cw";
            skinComboBox_advan_cw.Size = new Size(65, 23);
            skinComboBox_advan_cw.TabIndex = 7;
            // 
            // skinLabel23
            // 
            skinLabel23.AutoSize = true;
            skinLabel23.BackColor = Color.Transparent;
            skinLabel23.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel23.Location = new Point(8, 54);
            skinLabel23.Margin = new Padding(4, 0, 4, 0);
            skinLabel23.Name = "skinLabel23";
            skinLabel23.RightToLeft = RightToLeft.No;
            skinLabel23.Size = new Size(31, 17);
            skinLabel23.TabIndex = 6;
            skinLabel23.Text = "CW:";
            // 
            // skinComboBox_advan_hopping
            // 
            skinComboBox_advan_hopping.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_hopping.FormattingEnabled = true;
            skinComboBox_advan_hopping.Items.AddRange(new object[] { "Disabled", "Enabled" });
            skinComboBox_advan_hopping.Location = new Point(537, 15);
            skinComboBox_advan_hopping.Margin = new Padding(4);
            skinComboBox_advan_hopping.Name = "skinComboBox_advan_hopping";
            skinComboBox_advan_hopping.Size = new Size(104, 23);
            skinComboBox_advan_hopping.TabIndex = 5;
            // 
            // skinLabel22
            // 
            skinLabel22.AutoSize = true;
            skinLabel22.BackColor = Color.Transparent;
            skinLabel22.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel22.Location = new Point(463, 18);
            skinLabel22.Margin = new Padding(4, 0, 4, 0);
            skinLabel22.Name = "skinLabel22";
            skinLabel22.Size = new Size(66, 17);
            skinLabel22.TabIndex = 4;
            skinLabel22.Text = "Freq Hop:";
            // 
            // skinWaterTextBox_advan_channel
            // 
            skinWaterTextBox_advan_channel.Location = new Point(324, 15);
            skinWaterTextBox_advan_channel.Margin = new Padding(4);
            skinWaterTextBox_advan_channel.Name = "skinWaterTextBox_advan_channel";
            skinWaterTextBox_advan_channel.Size = new Size(116, 23);
            skinWaterTextBox_advan_channel.TabIndex = 3;
            // 
            // skinLabel21
            // 
            skinLabel21.AutoSize = true;
            skinLabel21.BackColor = Color.Transparent;
            skinLabel21.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel21.Location = new Point(248, 16);
            skinLabel21.Margin = new Padding(4, 0, 4, 0);
            skinLabel21.Name = "skinLabel21";
            skinLabel21.Size = new Size(57, 17);
            skinLabel21.TabIndex = 2;
            skinLabel21.Text = "Channel:";
            // 
            // skinComboBox_advan_region
            // 
            skinComboBox_advan_region.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_advan_region.FormattingEnabled = true;
            skinComboBox_advan_region.Items.AddRange(new object[] { "North America", "Europe", "China", "ALL" });
            skinComboBox_advan_region.Location = new Point(78, 15);
            skinComboBox_advan_region.Margin = new Padding(4);
            skinComboBox_advan_region.Name = "skinComboBox_advan_region";
            skinComboBox_advan_region.Size = new Size(138, 23);
            skinComboBox_advan_region.TabIndex = 1;
            skinComboBox_advan_region.SelectedIndexChanged += skinComboBox_advan_region_SelectedIndexChanged;
            // 
            // skinLabel20
            // 
            skinLabel20.AutoSize = true;
            skinLabel20.BackColor = Color.Transparent;
            skinLabel20.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel20.Location = new Point(13, 18);
            skinLabel20.Margin = new Padding(4, 0, 4, 0);
            skinLabel20.Name = "skinLabel20";
            skinLabel20.Size = new Size(52, 17);
            skinLabel20.TabIndex = 0;
            skinLabel20.Text = "Region:";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(skinButton_tag_verify);
            tabPage1.Controls.Add(skinButton_kill_tag);
            tabPage1.Controls.Add(skinButton_tag_lock);
            tabPage1.Controls.Add(comboBox_lock_type);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(skinGroupBox4);
            tabPage1.Controls.Add(skinButton_wiegand_write);
            tabPage1.Controls.Add(skinWaterTextBox_wiegand_write_data);
            tabPage1.Controls.Add(skinLabel51);
            tabPage1.Controls.Add(skinLabel41);
            tabPage1.Controls.Add(skinButton_operation_read);
            tabPage1.Controls.Add(skinButton_operation_write);
            tabPage1.Controls.Add(skinWater_content);
            tabPage1.Controls.Add(skinLabel40);
            tabPage1.Controls.Add(skinWaterTextBox_password);
            tabPage1.Controls.Add(skinLabel39);
            tabPage1.Controls.Add(skinWaterTextBox_length);
            tabPage1.Controls.Add(skinLabel38);
            tabPage1.Controls.Add(skinWaterTextBox_address);
            tabPage1.Controls.Add(skinLabel37);
            tabPage1.Controls.Add(skinComboBox_membank);
            tabPage1.Controls.Add(skinLabel36);
            tabPage1.Controls.Add(skinTextBox_opt_result);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(676, 466);
            tabPage1.TabIndex = 5;
            tabPage1.Text = "Tag operation";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // skinButton_tag_verify
            // 
            skinButton_tag_verify.BackColor = Color.Transparent;
            skinButton_tag_verify.Location = new Point(203, 224);
            skinButton_tag_verify.Margin = new Padding(4);
            skinButton_tag_verify.Name = "skinButton_tag_verify";
            skinButton_tag_verify.Size = new Size(88, 29);
            skinButton_tag_verify.TabIndex = 23;
            skinButton_tag_verify.Text = "Verify Label";
            skinButton_tag_verify.UseVisualStyleBackColor = false;
            skinButton_tag_verify.Click += skinButton_tag_verify_Click;
            // 
            // skinButton_kill_tag
            // 
            skinButton_kill_tag.BackColor = Color.Transparent;
            skinButton_kill_tag.Location = new Point(92, 224);
            skinButton_kill_tag.Margin = new Padding(4);
            skinButton_kill_tag.Name = "skinButton_kill_tag";
            skinButton_kill_tag.Size = new Size(88, 29);
            skinButton_kill_tag.TabIndex = 22;
            skinButton_kill_tag.Text = "Kill Tag";
            skinButton_kill_tag.UseVisualStyleBackColor = false;
            skinButton_kill_tag.Click += skinButton_kill_tag_Click;
            // 
            // skinButton_tag_lock
            // 
            skinButton_tag_lock.BackColor = Color.Transparent;
            skinButton_tag_lock.Location = new Point(396, 186);
            skinButton_tag_lock.Margin = new Padding(4);
            skinButton_tag_lock.Name = "skinButton_tag_lock";
            skinButton_tag_lock.Size = new Size(88, 29);
            skinButton_tag_lock.TabIndex = 21;
            skinButton_tag_lock.Text = "Lock";
            skinButton_tag_lock.UseVisualStyleBackColor = false;
            skinButton_tag_lock.Click += skinButton_tag_lock_Click;
            // 
            // comboBox_lock_type
            // 
            comboBox_lock_type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_lock_type.FormattingEnabled = true;
            comboBox_lock_type.Items.AddRange(new object[] { "No operation", "Lock write to EPC (password required)", "Permanently lock EPC (password required)", "Cancel password access to EPC", "Lock the write USER area", "Permanently lock USER section (password required).", "Unlock USER area", "Password access ACCESS", "Permanently lock ACCESS", "Cancel password access to ACCESS", "Password access KILL", "Permanently lock KILL", "Unlock KILL" });
            comboBox_lock_type.Location = new Point(92, 189);
            comboBox_lock_type.Margin = new Padding(4);
            comboBox_lock_type.Name = "comboBox_lock_type";
            comboBox_lock_type.Size = new Size(296, 23);
            comboBox_lock_type.TabIndex = 20;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(53, 193);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(35, 15);
            label16.TabIndex = 19;
            label16.Text = "Lock:";
            // 
            // skinGroupBox4
            // 
            skinGroupBox4.BackColor = Color.Transparent;
            skinGroupBox4.Controls.Add(skinButton_query_time);
            skinGroupBox4.Controls.Add(skinButton_sync_time);
            skinGroupBox4.Controls.Add(skinButton_upload_record);
            skinGroupBox4.ForeColor = Color.Black;
            skinGroupBox4.Location = new Point(10, 376);
            skinGroupBox4.Margin = new Padding(4);
            skinGroupBox4.Name = "skinGroupBox4";
            skinGroupBox4.Padding = new Padding(4);
            skinGroupBox4.Size = new Size(654, 60);
            skinGroupBox4.TabIndex = 18;
            skinGroupBox4.TabStop = false;
            skinGroupBox4.Text = "Tag Records";
            // 
            // skinButton_query_time
            // 
            skinButton_query_time.BackColor = Color.Transparent;
            skinButton_query_time.Location = new Point(277, 24);
            skinButton_query_time.Margin = new Padding(4);
            skinButton_query_time.Name = "skinButton_query_time";
            skinButton_query_time.Size = new Size(88, 26);
            skinButton_query_time.TabIndex = 2;
            skinButton_query_time.Text = "Query Time";
            skinButton_query_time.UseVisualStyleBackColor = false;
            skinButton_query_time.Click += skinButton_query_time_Click;
            // 
            // skinButton_sync_time
            // 
            skinButton_sync_time.BackColor = Color.Transparent;
            skinButton_sync_time.Location = new Point(137, 24);
            skinButton_sync_time.Margin = new Padding(4);
            skinButton_sync_time.Name = "skinButton_sync_time";
            skinButton_sync_time.Size = new Size(132, 26);
            skinButton_sync_time.TabIndex = 1;
            skinButton_sync_time.Text = "Synchronize Time";
            skinButton_sync_time.UseVisualStyleBackColor = false;
            skinButton_sync_time.Click += skinButton_sync_time_Click;
            // 
            // skinButton_upload_record
            // 
            skinButton_upload_record.BackColor = Color.Transparent;
            skinButton_upload_record.Location = new Point(14, 24);
            skinButton_upload_record.Margin = new Padding(4);
            skinButton_upload_record.Name = "skinButton_upload_record";
            skinButton_upload_record.Size = new Size(115, 26);
            skinButton_upload_record.TabIndex = 0;
            skinButton_upload_record.Text = "Read Tag Records";
            skinButton_upload_record.UseVisualStyleBackColor = false;
            skinButton_upload_record.Click += skinButton_upload_record_Click;
            // 
            // skinButton_wiegand_write
            // 
            skinButton_wiegand_write.BackColor = Color.Transparent;
            skinButton_wiegand_write.Location = new Point(269, 344);
            skinButton_wiegand_write.Margin = new Padding(2);
            skinButton_wiegand_write.Name = "skinButton_wiegand_write";
            skinButton_wiegand_write.Size = new Size(88, 27);
            skinButton_wiegand_write.TabIndex = 17;
            skinButton_wiegand_write.Text = "Send";
            skinButton_wiegand_write.UseVisualStyleBackColor = false;
            skinButton_wiegand_write.Click += skinButton_wiegand_write_Click;
            // 
            // skinWaterTextBox_wiegand_write_data
            // 
            skinWaterTextBox_wiegand_write_data.Location = new Point(114, 346);
            skinWaterTextBox_wiegand_write_data.Margin = new Padding(2);
            skinWaterTextBox_wiegand_write_data.Name = "skinWaterTextBox_wiegand_write_data";
            skinWaterTextBox_wiegand_write_data.Size = new Size(150, 23);
            skinWaterTextBox_wiegand_write_data.TabIndex = 16;
            // 
            // skinLabel51
            // 
            skinLabel51.AutoSize = true;
            skinLabel51.BackColor = Color.Transparent;
            skinLabel51.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel51.Location = new Point(20, 348);
            skinLabel51.Margin = new Padding(2, 0, 2, 0);
            skinLabel51.Name = "skinLabel51";
            skinLabel51.Size = new Size(94, 17);
            skinLabel51.TabIndex = 15;
            skinLabel51.Text = "Wiegand Data:";
            // 
            // skinLabel41
            // 
            skinLabel41.AutoSize = true;
            skinLabel41.BackColor = Color.Transparent;
            skinLabel41.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel41.Location = new Point(2, 136);
            skinLabel41.Margin = new Padding(4, 0, 4, 0);
            skinLabel41.Name = "skinLabel41";
            skinLabel41.Size = new Size(86, 17);
            skinLabel41.TabIndex = 12;
            skinLabel41.Text = "Read Results:";
            // 
            // skinButton_operation_read
            // 
            skinButton_operation_read.BackColor = Color.Transparent;
            skinButton_operation_read.Location = new Point(271, 52);
            skinButton_operation_read.Margin = new Padding(4);
            skinButton_operation_read.Name = "skinButton_operation_read";
            skinButton_operation_read.Size = new Size(88, 29);
            skinButton_operation_read.TabIndex = 11;
            skinButton_operation_read.Text = "Read";
            skinButton_operation_read.UseVisualStyleBackColor = false;
            skinButton_operation_read.Click += skinButton_operation_read_Click;
            // 
            // skinButton_operation_write
            // 
            skinButton_operation_write.BackColor = Color.Transparent;
            skinButton_operation_write.Location = new Point(396, 52);
            skinButton_operation_write.Margin = new Padding(4);
            skinButton_operation_write.Name = "skinButton_operation_write";
            skinButton_operation_write.Size = new Size(88, 29);
            skinButton_operation_write.TabIndex = 10;
            skinButton_operation_write.Text = "Write";
            skinButton_operation_write.UseVisualStyleBackColor = false;
            skinButton_operation_write.Click += skinButton_operation_write_Click;
            // 
            // skinWater_content
            // 
            skinWater_content.Location = new Point(92, 89);
            skinWater_content.Margin = new Padding(4);
            skinWater_content.Multiline = true;
            skinWater_content.Name = "skinWater_content";
            skinWater_content.Size = new Size(572, 40);
            skinWater_content.TabIndex = 9;
            // 
            // skinLabel40
            // 
            skinLabel40.AutoSize = true;
            skinLabel40.BackColor = Color.Transparent;
            skinLabel40.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel40.Location = new Point(21, 90);
            skinLabel40.Margin = new Padding(4, 0, 4, 0);
            skinLabel40.Name = "skinLabel40";
            skinLabel40.Size = new Size(73, 17);
            skinLabel40.TabIndex = 8;
            skinLabel40.Text = "Write Data:";
            // 
            // skinWaterTextBox_password
            // 
            skinWaterTextBox_password.Location = new Point(92, 56);
            skinWaterTextBox_password.Margin = new Padding(4);
            skinWaterTextBox_password.Name = "skinWaterTextBox_password";
            skinWaterTextBox_password.Size = new Size(156, 23);
            skinWaterTextBox_password.TabIndex = 7;
            // 
            // skinLabel39
            // 
            skinLabel39.AutoSize = true;
            skinLabel39.BackColor = Color.Transparent;
            skinLabel39.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel39.Location = new Point(12, 59);
            skinLabel39.Margin = new Padding(4, 0, 4, 0);
            skinLabel39.Name = "skinLabel39";
            skinLabel39.Size = new Size(75, 17);
            skinLabel39.TabIndex = 6;
            skinLabel39.Text = "Access Key:";
            // 
            // skinWaterTextBox_length
            // 
            skinWaterTextBox_length.Location = new Point(461, 19);
            skinWaterTextBox_length.Margin = new Padding(4);
            skinWaterTextBox_length.Name = "skinWaterTextBox_length";
            skinWaterTextBox_length.Size = new Size(106, 23);
            skinWaterTextBox_length.TabIndex = 5;
            // 
            // skinLabel38
            // 
            skinLabel38.AutoSize = true;
            skinLabel38.BackColor = Color.Transparent;
            skinLabel38.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel38.Location = new Point(406, 22);
            skinLabel38.Margin = new Padding(4, 0, 4, 0);
            skinLabel38.Name = "skinLabel38";
            skinLabel38.Size = new Size(50, 17);
            skinLabel38.TabIndex = 4;
            skinLabel38.Text = "Length:";
            // 
            // skinWaterTextBox_address
            // 
            skinWaterTextBox_address.Location = new Point(271, 19);
            skinWaterTextBox_address.Margin = new Padding(4);
            skinWaterTextBox_address.Name = "skinWaterTextBox_address";
            skinWaterTextBox_address.Size = new Size(116, 23);
            skinWaterTextBox_address.TabIndex = 3;
            // 
            // skinLabel37
            // 
            skinLabel37.AutoSize = true;
            skinLabel37.BackColor = Color.Transparent;
            skinLabel37.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel37.Location = new Point(196, 22);
            skinLabel37.Margin = new Padding(4, 0, 4, 0);
            skinLabel37.Name = "skinLabel37";
            skinLabel37.Size = new Size(70, 17);
            skinLabel37.TabIndex = 2;
            skinLabel37.Text = "Start addr:";
            // 
            // skinComboBox_membank
            // 
            skinComboBox_membank.DropDownStyle = ComboBoxStyle.DropDownList;
            skinComboBox_membank.FormattingEnabled = true;
            skinComboBox_membank.Items.AddRange(new object[] { "Reserve", "EPC", "TID", "USER" });
            skinComboBox_membank.Location = new Point(92, 16);
            skinComboBox_membank.Margin = new Padding(4);
            skinComboBox_membank.Name = "skinComboBox_membank";
            skinComboBox_membank.Size = new Size(92, 23);
            skinComboBox_membank.TabIndex = 1;
            // 
            // skinLabel36
            // 
            skinLabel36.AutoSize = true;
            skinLabel36.BackColor = Color.Transparent;
            skinLabel36.Font = new Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            skinLabel36.Location = new Point(15, 19);
            skinLabel36.Margin = new Padding(4, 0, 4, 0);
            skinLabel36.Name = "skinLabel36";
            skinLabel36.Size = new Size(64, 17);
            skinLabel36.TabIndex = 0;
            skinLabel36.Text = "Tag Area:";
            // 
            // skinTextBox_opt_result
            // 
            skinTextBox_opt_result.Font = new Font("Segoe UI", 9F);
            skinTextBox_opt_result.Location = new Point(92, 134);
            skinTextBox_opt_result.Margin = new Padding(0);
            skinTextBox_opt_result.MinimumSize = new Size(33, 34);
            skinTextBox_opt_result.Multiline = true;
            skinTextBox_opt_result.Name = "skinTextBox_opt_result";
            skinTextBox_opt_result.ReadOnly = true;
            skinTextBox_opt_result.Size = new Size(572, 51);
            skinTextBox_opt_result.TabIndex = 13;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(676, 466);
            tabPage2.TabIndex = 6;
            tabPage2.Text = "Extended Functions";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button_relay_control);
            groupBox3.Controls.Add(textBox_relay_ctrl_time);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(comboBox_op_index);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(10, 299);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(657, 60);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Relay control test";
            // 
            // button_relay_control
            // 
            button_relay_control.Location = new Point(457, 22);
            button_relay_control.Margin = new Padding(4);
            button_relay_control.Name = "button_relay_control";
            button_relay_control.Size = new Size(88, 26);
            button_relay_control.TabIndex = 4;
            button_relay_control.Text = "Send";
            button_relay_control.UseVisualStyleBackColor = true;
            button_relay_control.Click += button_relay_control_Click;
            // 
            // textBox_relay_ctrl_time
            // 
            textBox_relay_ctrl_time.Location = new Point(318, 24);
            textBox_relay_ctrl_time.Margin = new Padding(4);
            textBox_relay_ctrl_time.Name = "textBox_relay_ctrl_time";
            textBox_relay_ctrl_time.Size = new Size(81, 23);
            textBox_relay_ctrl_time.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(272, 29);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(34, 15);
            label12.TabIndex = 2;
            label12.Text = "Time";
            // 
            // comboBox_op_index
            // 
            comboBox_op_index.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_op_index.FormattingEnabled = true;
            comboBox_op_index.Items.AddRange(new object[] { "Relay 1 on", "", "Shock device 1 off", "", "Relay 2 on", "", "Relay 2 off", "", "Relays 1 and 2 on", "", "Relays 1 and 2 off" });
            comboBox_op_index.Location = new Point(97, 26);
            comboBox_op_index.Margin = new Padding(4);
            comboBox_op_index.Name = "comboBox_op_index";
            comboBox_op_index.Size = new Size(140, 23);
            comboBox_op_index.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(5, 31);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(88, 15);
            label11.TabIndex = 0;
            label11.Text = "Operation Type";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_audio_set_vol);
            groupBox2.Controls.Add(button_audio_play);
            groupBox2.Controls.Add(textBox_audio_text);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(10, 190);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(657, 102);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Voice Module";
            // 
            // button_audio_set_vol
            // 
            button_audio_set_vol.Location = new Point(80, 56);
            button_audio_set_vol.Margin = new Padding(2);
            button_audio_set_vol.Name = "button_audio_set_vol";
            button_audio_set_vol.Size = new Size(148, 31);
            button_audio_set_vol.TabIndex = 8;
            button_audio_set_vol.Text = "Set to offline playback";
            button_audio_set_vol.UseVisualStyleBackColor = true;
            button_audio_set_vol.Click += button_audio_set_vol_Click;
            // 
            // button_audio_play
            // 
            button_audio_play.Location = new Point(562, 22);
            button_audio_play.Margin = new Padding(4);
            button_audio_play.Name = "button_audio_play";
            button_audio_play.Size = new Size(88, 26);
            button_audio_play.TabIndex = 2;
            button_audio_play.Text = "Play";
            button_audio_play.UseVisualStyleBackColor = true;
            button_audio_play.Click += button_audio_play_Click;
            // 
            // textBox_audio_text
            // 
            textBox_audio_text.Location = new Point(80, 24);
            textBox_audio_text.Margin = new Padding(4);
            textBox_audio_text.Name = "textBox_audio_text";
            textBox_audio_text.Size = new Size(464, 23);
            textBox_audio_text.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 23);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(54, 30);
            label9.TabIndex = 0;
            label9.Text = "Playback\r\nContent:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button_ext_auto_add_verify);
            groupBox1.Controls.Add(button_ext_add_verify);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(textBox_tag_verify_pwd);
            groupBox1.Controls.Add(checkBox_tag_verify);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(button_relay_set);
            groupBox1.Controls.Add(button_ext_fresh);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox_relay_time);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(checkBox_relay2_auto);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(checkBox_relay1_auto);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(7, 11);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(660, 173);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Extended Functional Parameters";
            // 
            // button_ext_auto_add_verify
            // 
            button_ext_auto_add_verify.Location = new Point(229, 127);
            button_ext_auto_add_verify.Margin = new Padding(4);
            button_ext_auto_add_verify.Name = "button_ext_auto_add_verify";
            button_ext_auto_add_verify.Size = new Size(133, 29);
            button_ext_auto_add_verify.TabIndex = 15;
            button_ext_auto_add_verify.Text = "Automatic verification";
            button_ext_auto_add_verify.UseVisualStyleBackColor = true;
            button_ext_auto_add_verify.Click += button_ext_auto_verify_Click;
            // 
            // button_ext_add_verify
            // 
            button_ext_add_verify.Location = new Point(112, 127);
            button_ext_add_verify.Margin = new Padding(4);
            button_ext_add_verify.Name = "button_ext_add_verify";
            button_ext_add_verify.Size = new Size(110, 29);
            button_ext_add_verify.TabIndex = 15;
            button_ext_add_verify.Text = "Tag verification";
            button_ext_add_verify.UseVisualStyleBackColor = true;
            button_ext_add_verify.Click += button_ext_add_verify_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(20, 134);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(88, 15);
            label21.TabIndex = 14;
            label21.Text = "Tag operations:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(198, 92);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(91, 15);
            label19.TabIndex = 13;
            label19.Text = "（0000H~FFFFH)";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(16, 92);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(92, 15);
            label18.TabIndex = 12;
            label18.Text = "Verify password:";
            // 
            // textBox_tag_verify_pwd
            // 
            textBox_tag_verify_pwd.Location = new Point(112, 87);
            textBox_tag_verify_pwd.Margin = new Padding(4);
            textBox_tag_verify_pwd.Name = "textBox_tag_verify_pwd";
            textBox_tag_verify_pwd.Size = new Size(83, 23);
            textBox_tag_verify_pwd.TabIndex = 11;
            textBox_tag_verify_pwd.Text = "0000";
            // 
            // checkBox_tag_verify
            // 
            checkBox_tag_verify.AutoSize = true;
            checkBox_tag_verify.Location = new Point(314, 88);
            checkBox_tag_verify.Margin = new Padding(4);
            checkBox_tag_verify.Name = "checkBox_tag_verify";
            checkBox_tag_verify.Size = new Size(249, 19);
            checkBox_tag_verify.TabIndex = 10;
            checkBox_tag_verify.Text = "Enable tag verification when reading cards";
            checkBox_tag_verify.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = SystemColors.AppWorkspace;
            label10.Location = new Point(24, 51);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(577, 30);
            label10.TabIndex = 9;
            label10.Text = "(If the option to automatically turn on the device is selected, the relay will automatically turn on after the tag\r\nis read and will automatically turn off after the turn-on time has elapsed.)";
            // 
            // button_relay_set
            // 
            button_relay_set.Location = new Point(566, 134);
            button_relay_set.Margin = new Padding(4);
            button_relay_set.Name = "button_relay_set";
            button_relay_set.Size = new Size(88, 26);
            button_relay_set.TabIndex = 8;
            button_relay_set.Text = "Save";
            button_relay_set.UseVisualStyleBackColor = true;
            button_relay_set.Click += button_relay_set_Click;
            // 
            // button_ext_fresh
            // 
            button_ext_fresh.Location = new Point(461, 134);
            button_ext_fresh.Margin = new Padding(4);
            button_ext_fresh.Name = "button_ext_fresh";
            button_ext_fresh.Size = new Size(88, 26);
            button_ext_fresh.TabIndex = 7;
            button_ext_fresh.Text = "Query";
            button_ext_fresh.UseVisualStyleBackColor = true;
            button_ext_fresh.Click += button_ext_fresh_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(589, 26);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 6;
            label8.Text = "(Seconds)";
            // 
            // textBox_relay_time
            // 
            textBox_relay_time.Location = new Point(520, 22);
            textBox_relay_time.Margin = new Padding(4);
            textBox_relay_time.Name = "textBox_relay_time";
            textBox_relay_time.Size = new Size(62, 23);
            textBox_relay_time.TabIndex = 5;
            textBox_relay_time.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(433, 26);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 4;
            label7.Text = "Opening time:";
            // 
            // checkBox_relay2_auto
            // 
            checkBox_relay2_auto.AutoSize = true;
            checkBox_relay2_auto.Location = new Point(282, 25);
            checkBox_relay2_auto.Margin = new Padding(4);
            checkBox_relay2_auto.Name = "checkBox_relay2_auto";
            checkBox_relay2_auto.Size = new Size(142, 19);
            checkBox_relay2_auto.TabIndex = 3;
            checkBox_relay2_auto.Text = "Automatically turn on";
            checkBox_relay2_auto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(236, 26);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 2;
            label6.Text = "Relay 2:";
            // 
            // checkBox_relay1_auto
            // 
            checkBox_relay1_auto.AutoSize = true;
            checkBox_relay1_auto.Location = new Point(81, 25);
            checkBox_relay1_auto.Margin = new Padding(4);
            checkBox_relay1_auto.Name = "checkBox_relay1_auto";
            checkBox_relay1_auto.Size = new Size(142, 19);
            checkBox_relay1_auto.TabIndex = 1;
            checkBox_relay1_auto.Text = "Automatically turn on";
            checkBox_relay1_auto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 26);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 0;
            label5.Text = "Relay 1:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox9);
            tabPage3.Controls.Add(groupBox5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4);
            tabPage3.Size = new Size(676, 466);
            tabPage3.TabIndex = 7;
            tabPage3.Text = "Writing";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(button_write_file_reload);
            groupBox9.Controls.Add(button_write_file_auto);
            groupBox9.Controls.Add(button_write_file_hand);
            groupBox9.Controls.Add(textBox_write_file_data);
            groupBox9.Controls.Add(label37);
            groupBox9.Controls.Add(numericUpDown_write_file_row);
            groupBox9.Controls.Add(label36);
            groupBox9.Controls.Add(button_write_file_choose);
            groupBox9.Controls.Add(textBox_write_file_path);
            groupBox9.Controls.Add(label35);
            groupBox9.Location = new Point(13, 152);
            groupBox9.Margin = new Padding(4);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(4);
            groupBox9.Size = new Size(654, 154);
            groupBox9.TabIndex = 1;
            groupBox9.TabStop = false;
            groupBox9.Text = "Document writing card";
            // 
            // button_write_file_reload
            // 
            button_write_file_reload.Location = new Point(302, 118);
            button_write_file_reload.Margin = new Padding(4);
            button_write_file_reload.Name = "button_write_file_reload";
            button_write_file_reload.Size = new Size(99, 29);
            button_write_file_reload.TabIndex = 8;
            button_write_file_reload.Text = "Overload data";
            button_write_file_reload.UseVisualStyleBackColor = true;
            button_write_file_reload.Click += button_write_file_reload_Click;
            // 
            // button_write_file_auto
            // 
            button_write_file_auto.Location = new Point(527, 118);
            button_write_file_auto.Margin = new Padding(4);
            button_write_file_auto.Name = "button_write_file_auto";
            button_write_file_auto.Size = new Size(116, 29);
            button_write_file_auto.TabIndex = 7;
            button_write_file_auto.Text = "Automatic writing";
            button_write_file_auto.UseVisualStyleBackColor = true;
            button_write_file_auto.Click += button_write_file_auto_Click;
            // 
            // button_write_file_hand
            // 
            button_write_file_hand.Location = new Point(409, 118);
            button_write_file_hand.Margin = new Padding(4);
            button_write_file_hand.Name = "button_write_file_hand";
            button_write_file_hand.Size = new Size(110, 29);
            button_write_file_hand.TabIndex = 7;
            button_write_file_hand.Text = "Manual writing";
            button_write_file_hand.UseVisualStyleBackColor = true;
            button_write_file_hand.Click += button_write_file_hand_Click;
            // 
            // textBox_write_file_data
            // 
            textBox_write_file_data.Location = new Point(281, 68);
            textBox_write_file_data.Margin = new Padding(4);
            textBox_write_file_data.Name = "textBox_write_file_data";
            textBox_write_file_data.ReadOnly = true;
            textBox_write_file_data.Size = new Size(361, 23);
            textBox_write_file_data.TabIndex = 6;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(211, 72);
            label37.Margin = new Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new Size(64, 15);
            label37.TabIndex = 5;
            label37.Text = "Write data:";
            // 
            // numericUpDown_write_file_row
            // 
            numericUpDown_write_file_row.Location = new Point(89, 68);
            numericUpDown_write_file_row.Margin = new Padding(4);
            numericUpDown_write_file_row.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown_write_file_row.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_write_file_row.Name = "numericUpDown_write_file_row";
            numericUpDown_write_file_row.Size = new Size(105, 23);
            numericUpDown_write_file_row.TabIndex = 4;
            numericUpDown_write_file_row.TextAlign = HorizontalAlignment.Center;
            numericUpDown_write_file_row.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(13, 65);
            label36.Margin = new Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new Size(69, 30);
            label36.TabIndex = 3;
            label36.Text = "Current line\r\nnumber:";
            label36.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button_write_file_choose
            // 
            button_write_file_choose.Location = new Point(206, 118);
            button_write_file_choose.Margin = new Padding(4);
            button_write_file_choose.Name = "button_write_file_choose";
            button_write_file_choose.Size = new Size(88, 29);
            button_write_file_choose.TabIndex = 2;
            button_write_file_choose.Text = "File selection";
            button_write_file_choose.UseVisualStyleBackColor = true;
            button_write_file_choose.Click += button_write_file_choose_Click;
            // 
            // textBox_write_file_path
            // 
            textBox_write_file_path.Location = new Point(51, 30);
            textBox_write_file_path.Margin = new Padding(4);
            textBox_write_file_path.Name = "textBox_write_file_path";
            textBox_write_file_path.ReadOnly = true;
            textBox_write_file_path.Size = new Size(591, 23);
            textBox_write_file_path.TabIndex = 1;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(8, 35);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(34, 15);
            label35.TabIndex = 0;
            label35.Text = "Path:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(label13);
            groupBox5.Controls.Add(checkBox_auto_write_increse);
            groupBox5.Controls.Add(checkBox_auto_write_flag);
            groupBox5.Controls.Add(button_auto_write_wiegand);
            groupBox5.Controls.Add(button_auto_write_hex);
            groupBox5.Controls.Add(textBox_auto_wiegand_write_text);
            groupBox5.Controls.Add(textBox_auto_hex_write_text);
            groupBox5.Location = new Point(12, 21);
            groupBox5.Margin = new Padding(4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4);
            groupBox5.Size = new Size(656, 121);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Automatic card writing";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 87);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(132, 15);
            label14.TabIndex = 7;
            label14.Text = "Wiegand Card Number:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 46);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(105, 15);
            label13.TabIndex = 6;
            label13.Text = "Hex Card Number:";
            // 
            // checkBox_auto_write_increse
            // 
            checkBox_auto_write_increse.AutoSize = true;
            checkBox_auto_write_increse.Location = new Point(205, 16);
            checkBox_auto_write_increse.Margin = new Padding(4);
            checkBox_auto_write_increse.Name = "checkBox_auto_write_increse";
            checkBox_auto_write_increse.Size = new Size(134, 19);
            checkBox_auto_write_increse.TabIndex = 5;
            checkBox_auto_write_increse.Text = "Automatically Add 1";
            checkBox_auto_write_increse.UseVisualStyleBackColor = true;
            // 
            // checkBox_auto_write_flag
            // 
            checkBox_auto_write_flag.AutoSize = true;
            checkBox_auto_write_flag.Location = new Point(112, 16);
            checkBox_auto_write_flag.Margin = new Padding(4);
            checkBox_auto_write_flag.Name = "checkBox_auto_write_flag";
            checkBox_auto_write_flag.Size = new Size(82, 19);
            checkBox_auto_write_flag.TabIndex = 4;
            checkBox_auto_write_flag.Text = "Automatic";
            checkBox_auto_write_flag.UseVisualStyleBackColor = true;
            // 
            // button_auto_write_wiegand
            // 
            button_auto_write_wiegand.Location = new Point(331, 81);
            button_auto_write_wiegand.Margin = new Padding(4);
            button_auto_write_wiegand.Name = "button_auto_write_wiegand";
            button_auto_write_wiegand.Size = new Size(99, 26);
            button_auto_write_wiegand.TabIndex = 3;
            button_auto_write_wiegand.Text = "Wiegand Card";
            button_auto_write_wiegand.UseVisualStyleBackColor = true;
            button_auto_write_wiegand.Click += button_auto_write_wiegand_Click;
            // 
            // button_auto_write_hex
            // 
            button_auto_write_hex.Location = new Point(528, 42);
            button_auto_write_hex.Margin = new Padding(4);
            button_auto_write_hex.Name = "button_auto_write_hex";
            button_auto_write_hex.Size = new Size(106, 26);
            button_auto_write_hex.TabIndex = 2;
            button_auto_write_hex.Text = "Hex card writing";
            button_auto_write_hex.UseVisualStyleBackColor = true;
            button_auto_write_hex.Click += button_auto_write_hex_Click;
            // 
            // textBox_auto_wiegand_write_text
            // 
            textBox_auto_wiegand_write_text.Location = new Point(141, 82);
            textBox_auto_wiegand_write_text.Margin = new Padding(4);
            textBox_auto_wiegand_write_text.Name = "textBox_auto_wiegand_write_text";
            textBox_auto_wiegand_write_text.Size = new Size(172, 23);
            textBox_auto_wiegand_write_text.TabIndex = 1;
            // 
            // textBox_auto_hex_write_text
            // 
            textBox_auto_hex_write_text.Location = new Point(112, 42);
            textBox_auto_hex_write_text.Margin = new Padding(4);
            textBox_auto_hex_write_text.Name = "textBox_auto_hex_write_text";
            textBox_auto_hex_write_text.Size = new Size(394, 23);
            textBox_auto_hex_write_text.TabIndex = 0;
            // 
            // tabPage_ExDataParam
            // 
            tabPage_ExDataParam.Controls.Add(groupBox8);
            tabPage_ExDataParam.Controls.Add(groupBox7);
            tabPage_ExDataParam.Controls.Add(groupBox6);
            tabPage_ExDataParam.Location = new Point(4, 24);
            tabPage_ExDataParam.Margin = new Padding(2);
            tabPage_ExDataParam.Name = "tabPage_ExDataParam";
            tabPage_ExDataParam.Padding = new Padding(2);
            tabPage_ExDataParam.Size = new Size(676, 466);
            tabPage_ExDataParam.TabIndex = 8;
            tabPage_ExDataParam.Text = "Data Expansion";
            tabPage_ExDataParam.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(comboBox_ex_modbus_proto);
            groupBox8.Controls.Add(label1);
            groupBox8.Controls.Add(label26);
            groupBox8.Controls.Add(label25);
            groupBox8.Controls.Add(label_ex_modbus_register_num);
            groupBox8.Controls.Add(button_ex_modbus_set);
            groupBox8.Controls.Add(button_ex_modbus_query);
            groupBox8.Controls.Add(checkBox_ex_modbus_clear_flag);
            groupBox8.Controls.Add(numericUpDown_ex_modbus_startaddr);
            groupBox8.Controls.Add(label24);
            groupBox8.Controls.Add(numericUpDown_ex_modbus_union_size);
            groupBox8.Controls.Add(label23);
            groupBox8.Controls.Add(numericUpDown_ex_modbus_tag_num);
            groupBox8.Controls.Add(label22);
            groupBox8.Location = new Point(20, 262);
            groupBox8.Margin = new Padding(2);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(2);
            groupBox8.Size = new Size(638, 123);
            groupBox8.TabIndex = 2;
            groupBox8.TabStop = false;
            groupBox8.Text = "Modbus Settings";
            // 
            // comboBox_ex_modbus_proto
            // 
            comboBox_ex_modbus_proto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ex_modbus_proto.FormattingEnabled = true;
            comboBox_ex_modbus_proto.Items.AddRange(new object[] { "ModbusRtu", "ModbusAscii", "ModbusTcp" });
            comboBox_ex_modbus_proto.Location = new Point(348, 32);
            comboBox_ex_modbus_proto.Margin = new Padding(4);
            comboBox_ex_modbus_proto.Name = "comboBox_ex_modbus_proto";
            comboBox_ex_modbus_proto.Size = new Size(140, 23);
            comboBox_ex_modbus_proto.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 11;
            label1.Text = "Protocol:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(227, 89);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(97, 15);
            label26.TabIndex = 10;
            label26.Text = "(Unit: characters)";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(167, 66);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(97, 15);
            label25.TabIndex = 10;
            label25.Text = "(Unit: characters)";
            // 
            // label_ex_modbus_register_num
            // 
            label_ex_modbus_register_num.AutoSize = true;
            label_ex_modbus_register_num.Location = new Point(282, 61);
            label_ex_modbus_register_num.Margin = new Padding(2, 0, 2, 0);
            label_ex_modbus_register_num.Name = "label_ex_modbus_register_num";
            label_ex_modbus_register_num.Size = new Size(66, 15);
            label_ex_modbus_register_num.TabIndex = 9;
            label_ex_modbus_register_num.Text = "Registers：0";
            // 
            // button_ex_modbus_set
            // 
            button_ex_modbus_set.Location = new Point(552, 85);
            button_ex_modbus_set.Margin = new Padding(2);
            button_ex_modbus_set.Name = "button_ex_modbus_set";
            button_ex_modbus_set.Size = new Size(59, 25);
            button_ex_modbus_set.TabIndex = 8;
            button_ex_modbus_set.Text = "Set";
            button_ex_modbus_set.UseVisualStyleBackColor = true;
            button_ex_modbus_set.Click += button_ex_modbus_set_Click;
            // 
            // button_ex_modbus_query
            // 
            button_ex_modbus_query.Location = new Point(480, 85);
            button_ex_modbus_query.Margin = new Padding(2);
            button_ex_modbus_query.Name = "button_ex_modbus_query";
            button_ex_modbus_query.Size = new Size(58, 25);
            button_ex_modbus_query.TabIndex = 7;
            button_ex_modbus_query.Text = "Query";
            button_ex_modbus_query.UseVisualStyleBackColor = true;
            button_ex_modbus_query.Click += button_ex_modbus_query_Click;
            // 
            // checkBox_ex_modbus_clear_flag
            // 
            checkBox_ex_modbus_clear_flag.AutoSize = true;
            checkBox_ex_modbus_clear_flag.Location = new Point(360, 62);
            checkBox_ex_modbus_clear_flag.Margin = new Padding(2);
            checkBox_ex_modbus_clear_flag.Name = "checkBox_ex_modbus_clear_flag";
            checkBox_ex_modbus_clear_flag.Size = new Size(98, 19);
            checkBox_ex_modbus_clear_flag.TabIndex = 6;
            checkBox_ex_modbus_clear_flag.Text = "Clear Register";
            checkBox_ex_modbus_clear_flag.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_ex_modbus_startaddr
            // 
            numericUpDown_ex_modbus_startaddr.Location = new Point(161, 87);
            numericUpDown_ex_modbus_startaddr.Margin = new Padding(2);
            numericUpDown_ex_modbus_startaddr.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown_ex_modbus_startaddr.Name = "numericUpDown_ex_modbus_startaddr";
            numericUpDown_ex_modbus_startaddr.Size = new Size(59, 23);
            numericUpDown_ex_modbus_startaddr.TabIndex = 5;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(0, 89);
            label24.Margin = new Padding(2, 0, 2, 0);
            label24.Name = "label24";
            label24.Size = new Size(150, 15);
            label24.TabIndex = 4;
            label24.Text = "Starting address of storage:";
            // 
            // numericUpDown_ex_modbus_union_size
            // 
            numericUpDown_ex_modbus_union_size.Location = new Point(98, 59);
            numericUpDown_ex_modbus_union_size.Margin = new Padding(2);
            numericUpDown_ex_modbus_union_size.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown_ex_modbus_union_size.Name = "numericUpDown_ex_modbus_union_size";
            numericUpDown_ex_modbus_union_size.Size = new Size(62, 23);
            numericUpDown_ex_modbus_union_size.TabIndex = 3;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(6, 61);
            label23.Margin = new Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new Size(87, 15);
            label23.TabIndex = 2;
            label23.Text = "Single Tag Size:";
            // 
            // numericUpDown_ex_modbus_tag_num
            // 
            numericUpDown_ex_modbus_tag_num.Location = new Point(98, 29);
            numericUpDown_ex_modbus_tag_num.Margin = new Padding(2);
            numericUpDown_ex_modbus_tag_num.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDown_ex_modbus_tag_num.Name = "numericUpDown_ex_modbus_tag_num";
            numericUpDown_ex_modbus_tag_num.Size = new Size(62, 23);
            numericUpDown_ex_modbus_tag_num.TabIndex = 1;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(21, 32);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(66, 15);
            label22.TabIndex = 0;
            label22.Text = "Total Tags：";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(checkBox_DataFlag_Enter);
            groupBox7.Controls.Add(comboBox_dataflag_format);
            groupBox7.Controls.Add(label34);
            groupBox7.Controls.Add(label33);
            groupBox7.Controls.Add(button_dataflag_set);
            groupBox7.Controls.Add(button_dataflag_query);
            groupBox7.Controls.Add(checkBoxDataFlag_DevNo);
            groupBox7.Controls.Add(checkBoxDataFlag_ANT);
            groupBox7.Controls.Add(checkBoxDataFlag_RSSI);
            groupBox7.Location = new Point(20, 134);
            groupBox7.Margin = new Padding(2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(2);
            groupBox7.Size = new Size(638, 110);
            groupBox7.TabIndex = 1;
            groupBox7.TabStop = false;
            groupBox7.Text = "Data Parameters";
            // 
            // checkBox_DataFlag_Enter
            // 
            checkBox_DataFlag_Enter.AutoSize = true;
            checkBox_DataFlag_Enter.Location = new Point(368, 31);
            checkBox_DataFlag_Enter.Margin = new Padding(4);
            checkBox_DataFlag_Enter.Name = "checkBox_DataFlag_Enter";
            checkBox_DataFlag_Enter.Size = new Size(94, 19);
            checkBox_DataFlag_Enter.TabIndex = 5;
            checkBox_DataFlag_Enter.Text = "Add Newline";
            checkBox_DataFlag_Enter.UseVisualStyleBackColor = true;
            // 
            // comboBox_dataflag_format
            // 
            comboBox_dataflag_format.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_dataflag_format.FormattingEnabled = true;
            comboBox_dataflag_format.Items.AddRange(new object[] { "0: Default including protocol data", "1: Raw tag data", "2: Hexadecimal string", "3：JSON", "4: Wiegand26 characters (integer 2+1)", "5: Wiegand26 characters (integer, 3 bytes)", "6: Wiegand34/32 (integer 4 bytes)", "7: The last three hexadecimal characters of the label" });
            comboBox_dataflag_format.Location = new Point(125, 65);
            comboBox_dataflag_format.Margin = new Padding(2);
            comboBox_dataflag_format.Name = "comboBox_dataflag_format";
            comboBox_dataflag_format.Size = new Size(236, 23);
            comboBox_dataflag_format.TabIndex = 4;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(49, 68);
            label34.Margin = new Padding(2, 0, 2, 0);
            label34.Name = "label34";
            label34.Size = new Size(73, 15);
            label34.TabIndex = 3;
            label34.Text = "Data format:";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(4, 31);
            label33.Margin = new Padding(2, 0, 2, 0);
            label33.Name = "label33";
            label33.Size = new Size(114, 15);
            label33.TabIndex = 2;
            label33.Text = "Upload Information:";
            // 
            // button_dataflag_set
            // 
            button_dataflag_set.Location = new Point(560, 79);
            button_dataflag_set.Margin = new Padding(2);
            button_dataflag_set.Name = "button_dataflag_set";
            button_dataflag_set.Size = new Size(63, 26);
            button_dataflag_set.TabIndex = 1;
            button_dataflag_set.Text = "Set";
            button_dataflag_set.UseVisualStyleBackColor = true;
            button_dataflag_set.Click += button_dataflag_set_Click;
            // 
            // button_dataflag_query
            // 
            button_dataflag_query.Location = new Point(475, 79);
            button_dataflag_query.Margin = new Padding(2);
            button_dataflag_query.Name = "button_dataflag_query";
            button_dataflag_query.Size = new Size(63, 26);
            button_dataflag_query.TabIndex = 1;
            button_dataflag_query.Text = "Query";
            button_dataflag_query.UseVisualStyleBackColor = true;
            button_dataflag_query.Click += button_dataflag_query_Click;
            // 
            // checkBoxDataFlag_DevNo
            // 
            checkBoxDataFlag_DevNo.AutoSize = true;
            checkBoxDataFlag_DevNo.Location = new Point(197, 31);
            checkBoxDataFlag_DevNo.Margin = new Padding(2);
            checkBoxDataFlag_DevNo.Name = "checkBoxDataFlag_DevNo";
            checkBoxDataFlag_DevNo.Size = new Size(75, 19);
            checkBoxDataFlag_DevNo.TabIndex = 0;
            checkBoxDataFlag_DevNo.Text = "Device ID";
            checkBoxDataFlag_DevNo.UseVisualStyleBackColor = true;
            // 
            // checkBoxDataFlag_ANT
            // 
            checkBoxDataFlag_ANT.AutoSize = true;
            checkBoxDataFlag_ANT.Location = new Point(285, 31);
            checkBoxDataFlag_ANT.Margin = new Padding(2);
            checkBoxDataFlag_ANT.Name = "checkBoxDataFlag_ANT";
            checkBoxDataFlag_ANT.Size = new Size(81, 19);
            checkBoxDataFlag_ANT.TabIndex = 0;
            checkBoxDataFlag_ANT.Text = "Antenna #";
            checkBoxDataFlag_ANT.UseVisualStyleBackColor = true;
            // 
            // checkBoxDataFlag_RSSI
            // 
            checkBoxDataFlag_RSSI.AutoSize = true;
            checkBoxDataFlag_RSSI.Location = new Point(125, 31);
            checkBoxDataFlag_RSSI.Margin = new Padding(2);
            checkBoxDataFlag_RSSI.Name = "checkBoxDataFlag_RSSI";
            checkBoxDataFlag_RSSI.Size = new Size(48, 19);
            checkBoxDataFlag_RSSI.TabIndex = 0;
            checkBoxDataFlag_RSSI.Text = "RSSI";
            checkBoxDataFlag_RSSI.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(radioButton_USB_COM);
            groupBox6.Controls.Add(radioButton_USB_HID);
            groupBox6.Controls.Add(label20);
            groupBox6.Controls.Add(button_usbdata_sset);
            groupBox6.Controls.Add(button_usbdata_query);
            groupBox6.Controls.Add(checkBox_usbdata_enter_flag);
            groupBox6.Controls.Add(comboBox_usbdata_proto);
            groupBox6.Controls.Add(label15);
            groupBox6.Location = new Point(20, 16);
            groupBox6.Margin = new Padding(2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(2);
            groupBox6.Size = new Size(638, 96);
            groupBox6.TabIndex = 0;
            groupBox6.TabStop = false;
            groupBox6.Text = "USB";
            // 
            // radioButton_USB_COM
            // 
            radioButton_USB_COM.AutoSize = true;
            radioButton_USB_COM.Location = new Point(243, 21);
            radioButton_USB_COM.Margin = new Padding(4);
            radioButton_USB_COM.Name = "radioButton_USB_COM";
            radioButton_USB_COM.Size = new Size(178, 19);
            radioButton_USB_COM.TabIndex = 6;
            radioButton_USB_COM.TabStop = true;
            radioButton_USB_COM.Text = "USB Virtual Serial Port (COM)";
            radioButton_USB_COM.UseVisualStyleBackColor = true;
            // 
            // radioButton_USB_HID
            // 
            radioButton_USB_HID.AutoSize = true;
            radioButton_USB_HID.Location = new Point(114, 20);
            radioButton_USB_HID.Margin = new Padding(4);
            radioButton_USB_HID.Name = "radioButton_USB_HID";
            radioButton_USB_HID.Size = new Size(122, 19);
            radioButton_USB_HID.TabIndex = 6;
            radioButton_USB_HID.TabStop = true;
            radioButton_USB_HID.Text = "USB HID Keyboard";
            radioButton_USB_HID.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(10, 22);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(72, 15);
            label20.TabIndex = 5;
            label20.Text = "USB Output:";
            // 
            // button_usbdata_sset
            // 
            button_usbdata_sset.Location = new Point(562, 56);
            button_usbdata_sset.Margin = new Padding(2);
            button_usbdata_sset.Name = "button_usbdata_sset";
            button_usbdata_sset.Size = new Size(61, 25);
            button_usbdata_sset.TabIndex = 4;
            button_usbdata_sset.Text = "Set";
            button_usbdata_sset.UseVisualStyleBackColor = true;
            button_usbdata_sset.Click += button_usbdata_sset_Click;
            // 
            // button_usbdata_query
            // 
            button_usbdata_query.Location = new Point(474, 56);
            button_usbdata_query.Margin = new Padding(2);
            button_usbdata_query.Name = "button_usbdata_query";
            button_usbdata_query.Size = new Size(63, 25);
            button_usbdata_query.TabIndex = 3;
            button_usbdata_query.Text = "Query";
            button_usbdata_query.UseVisualStyleBackColor = true;
            button_usbdata_query.Click += button_usbdata_query_Click;
            // 
            // checkBox_usbdata_enter_flag
            // 
            checkBox_usbdata_enter_flag.AutoSize = true;
            checkBox_usbdata_enter_flag.Location = new Point(360, 56);
            checkBox_usbdata_enter_flag.Margin = new Padding(2);
            checkBox_usbdata_enter_flag.Name = "checkBox_usbdata_enter_flag";
            checkBox_usbdata_enter_flag.Size = new Size(94, 19);
            checkBox_usbdata_enter_flag.TabIndex = 2;
            checkBox_usbdata_enter_flag.Text = "Add Newline";
            checkBox_usbdata_enter_flag.UseVisualStyleBackColor = true;
            // 
            // comboBox_usbdata_proto
            // 
            comboBox_usbdata_proto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_usbdata_proto.FormattingEnabled = true;
            comboBox_usbdata_proto.Items.AddRange(new object[] { "Hexadecimal Characters", "Wiegand26(1+2)", "Wiegand26(3)", "Wiegand34", "ASCII characters (labels store ASCII values)", "The last three characters of the tag (HEX)" });
            comboBox_usbdata_proto.Location = new Point(114, 52);
            comboBox_usbdata_proto.Margin = new Padding(2);
            comboBox_usbdata_proto.Name = "comboBox_usbdata_proto";
            comboBox_usbdata_proto.Size = new Size(234, 23);
            comboBox_usbdata_proto.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(11, 56);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(99, 15);
            label15.TabIndex = 0;
            label15.Text = "USB Data Format:";
            // 
            // M100Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 492);
            Controls.Add(tabControl_function);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "M100Window";
            Text = "M100Window";
            tabControl_function.ResumeLayout(false);
            tabPage_inventory.ResumeLayout(false);
            tabPage_inventory.PerformLayout();
            tabPage_work_param.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            skinGroupBox7.ResumeLayout(false);
            skinGroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_power).EndInit();
            skinGroupBox6.ResumeLayout(false);
            skinGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_trigger_time).EndInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_work_interval).EndInit();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_work_filter).EndInit();
            tabPage_transfer.ResumeLayout(false);
            tabPage_transfer.PerformLayout();
            skinGroupBox8.ResumeLayout(false);
            skinGroupBox8.PerformLayout();
            skinGroupBox5.ResumeLayout(false);
            skinGroupBox5.PerformLayout();
            skinGroupBox3.ResumeLayout(false);
            skinGroupBox3.PerformLayout();
            skinGroupBox2.ResumeLayout(false);
            skinGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_wiegand_location).EndInit();
            skinGroupBox1.ResumeLayout(false);
            skinGroupBox1.PerformLayout();
            tabPage_advance.ResumeLayout(false);
            tabPage_advance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skinNumericUpDown_advan_Q).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            skinGroupBox4.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_write_file_row).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabPage_ExDataParam.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_startaddr).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_union_size).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_ex_modbus_tag_num).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}