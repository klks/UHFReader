namespace LJYZN_105
{
    partial class Form_6B
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
            groupBox22 = new GroupBox();
            Edit_WriteData_6B = new TextBox();
            label36 = new Label();
            lb6B_list2 = new ListBox();
            SpeedButton_Clear_6B = new Button();
            SpeedButton_Check_6B = new Button();
            SpeedButton_Perm_Wr_Prot_6B = new Button();
            SpeedButton_Write_6B = new Button();
            SpeedButton_Read_6B = new Button();
            Edit_Len_6B = new TextBox();
            label35 = new Label();
            Edit_StartAddress_6B = new TextBox();
            label34 = new Label();
            ComboBox_ID1_6B = new ComboBox();
            groupBox21 = new GroupBox();
            Edit_ConditionContent_6B = new TextBox();
            Edit_Query_StartAddress_6B = new TextBox();
            label33 = new Label();
            label32 = new Label();
            Greater_6B = new RadioButton();
            Less_6B = new RadioButton();
            Different_6B = new RadioButton();
            Same_6B = new RadioButton();
            groupBox20 = new GroupBox();
            SpeedButton_Query_6B = new Button();
            Bycondition_6B = new RadioButton();
            Byone_6B = new RadioButton();
            ComboBox_IntervalTime_6B = new ComboBox();
            label31 = new Label();
            groupBox19 = new GroupBox();
            lv6B_Tags = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            Timer_Test_6B = new System.Windows.Forms.Timer(components);
            Timer_6B_Read = new System.Windows.Forms.Timer(components);
            Timer_6B_Write = new System.Windows.Forms.Timer(components);
            groupBox22.SuspendLayout();
            groupBox21.SuspendLayout();
            groupBox20.SuspendLayout();
            groupBox19.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox22
            // 
            groupBox22.Controls.Add(Edit_WriteData_6B);
            groupBox22.Controls.Add(label36);
            groupBox22.Controls.Add(lb6B_list2);
            groupBox22.Controls.Add(SpeedButton_Clear_6B);
            groupBox22.Controls.Add(SpeedButton_Check_6B);
            groupBox22.Controls.Add(SpeedButton_Perm_Wr_Prot_6B);
            groupBox22.Controls.Add(SpeedButton_Write_6B);
            groupBox22.Controls.Add(SpeedButton_Read_6B);
            groupBox22.Controls.Add(Edit_Len_6B);
            groupBox22.Controls.Add(label35);
            groupBox22.Controls.Add(Edit_StartAddress_6B);
            groupBox22.Controls.Add(label34);
            groupBox22.Controls.Add(ComboBox_ID1_6B);
            groupBox22.Location = new Point(386, 389);
            groupBox22.Margin = new Padding(4, 3, 4, 3);
            groupBox22.Name = "groupBox22";
            groupBox22.Padding = new Padding(4, 3, 4, 3);
            groupBox22.Size = new Size(567, 385);
            groupBox22.TabIndex = 7;
            groupBox22.TabStop = false;
            groupBox22.Text = "Read and Write Data Block / Permanently Write  Protect Block of  byte";
            // 
            // Edit_WriteData_6B
            // 
            Edit_WriteData_6B.Location = new Point(209, 106);
            Edit_WriteData_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_WriteData_6B.Name = "Edit_WriteData_6B";
            Edit_WriteData_6B.Size = new Size(350, 23);
            Edit_WriteData_6B.TabIndex = 12;
            Edit_WriteData_6B.Text = "0000";
            Edit_WriteData_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_WriteData_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(8, 110);
            label36.Margin = new Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new Size(150, 15);
            label36.TabIndex = 11;
            label36.Text = "Write Data (1-32 Byte/Hex):";
            // 
            // lb6B_list2
            // 
            lb6B_list2.FormattingEnabled = true;
            lb6B_list2.ItemHeight = 15;
            lb6B_list2.Location = new Point(7, 179);
            lb6B_list2.Margin = new Padding(4, 3, 4, 3);
            lb6B_list2.Name = "lb6B_list2";
            lb6B_list2.Size = new Size(552, 199);
            lb6B_list2.TabIndex = 10;
            // 
            // SpeedButton_Clear_6B
            // 
            SpeedButton_Clear_6B.Location = new Point(500, 143);
            SpeedButton_Clear_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Clear_6B.Name = "SpeedButton_Clear_6B";
            SpeedButton_Clear_6B.Size = new Size(59, 29);
            SpeedButton_Clear_6B.TabIndex = 9;
            SpeedButton_Clear_6B.Text = "Clear";
            SpeedButton_Clear_6B.UseVisualStyleBackColor = true;
            SpeedButton_Clear_6B.Click += SpeedButton_Clear_6B_Click;
            // 
            // SpeedButton_Check_6B
            // 
            SpeedButton_Check_6B.Location = new Point(406, 143);
            SpeedButton_Check_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Check_6B.Name = "SpeedButton_Check_6B";
            SpeedButton_Check_6B.Size = new Size(88, 29);
            SpeedButton_Check_6B.TabIndex = 8;
            SpeedButton_Check_6B.Text = "Check Protect";
            SpeedButton_Check_6B.UseVisualStyleBackColor = true;
            SpeedButton_Check_6B.Click += SpeedButton_Check_6B_Click;
            // 
            // SpeedButton_Perm_Wr_Prot_6B
            // 
            SpeedButton_Perm_Wr_Prot_6B.Location = new Point(198, 143);
            SpeedButton_Perm_Wr_Prot_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Perm_Wr_Prot_6B.Name = "SpeedButton_Perm_Wr_Prot_6B";
            SpeedButton_Perm_Wr_Prot_6B.Size = new Size(201, 29);
            SpeedButton_Perm_Wr_Prot_6B.TabIndex = 7;
            SpeedButton_Perm_Wr_Prot_6B.Text = "Permanently Write  Protect";
            SpeedButton_Perm_Wr_Prot_6B.UseVisualStyleBackColor = true;
            SpeedButton_Perm_Wr_Prot_6B.Click += SpeedButton_PermWriteProtect_6B_Click;
            // 
            // SpeedButton_Write_6B
            // 
            SpeedButton_Write_6B.Location = new Point(104, 143);
            SpeedButton_Write_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Write_6B.Name = "SpeedButton_Write_6B";
            SpeedButton_Write_6B.Size = new Size(88, 29);
            SpeedButton_Write_6B.TabIndex = 6;
            SpeedButton_Write_6B.Text = "Write";
            SpeedButton_Write_6B.UseVisualStyleBackColor = true;
            SpeedButton_Write_6B.Click += SpeedButton_Write_6B_Click;
            // 
            // SpeedButton_Read_6B
            // 
            SpeedButton_Read_6B.Location = new Point(9, 143);
            SpeedButton_Read_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Read_6B.Name = "SpeedButton_Read_6B";
            SpeedButton_Read_6B.Size = new Size(88, 29);
            SpeedButton_Read_6B.TabIndex = 5;
            SpeedButton_Read_6B.Text = "Read";
            SpeedButton_Read_6B.UseVisualStyleBackColor = true;
            SpeedButton_Read_6B.Click += SpeedButton_Read_6B_Click;
            // 
            // Edit_Len_6B
            // 
            Edit_Len_6B.Location = new Point(446, 66);
            Edit_Len_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_Len_6B.MaxLength = 2;
            Edit_Len_6B.Name = "Edit_Len_6B";
            Edit_Len_6B.Size = new Size(116, 23);
            Edit_Len_6B.TabIndex = 4;
            Edit_Len_6B.Text = "12";
            Edit_Len_6B.TextChanged += filterOnlyDigits_TextChanged;
            Edit_Len_6B.KeyPress += filterOnlyDigits_KeyPress;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(331, 66);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(88, 30);
            label35.TabIndex = 3;
            label35.Text = "Length of Data:\r\n(1-32/Byte/D)";
            // 
            // Edit_StartAddress_6B
            // 
            Edit_StartAddress_6B.Location = new Point(167, 66);
            Edit_StartAddress_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_StartAddress_6B.MaxLength = 2;
            Edit_StartAddress_6B.Name = "Edit_StartAddress_6B";
            Edit_StartAddress_6B.Size = new Size(116, 23);
            Edit_StartAddress_6B.TabIndex = 2;
            Edit_StartAddress_6B.Text = "00";
            Edit_StartAddress_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_StartAddress_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(8, 62);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(119, 30);
            label34.TabIndex = 1;
            label34.Text = "Start/Protect Address\r\n(00-E9)(Hex):   ";
            // 
            // ComboBox_ID1_6B
            // 
            ComboBox_ID1_6B.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_ID1_6B.FormattingEnabled = true;
            ComboBox_ID1_6B.Location = new Point(7, 21);
            ComboBox_ID1_6B.Margin = new Padding(4, 3, 4, 3);
            ComboBox_ID1_6B.Name = "ComboBox_ID1_6B";
            ComboBox_ID1_6B.Size = new Size(552, 23);
            ComboBox_ID1_6B.TabIndex = 0;
            // 
            // groupBox21
            // 
            groupBox21.Controls.Add(Edit_ConditionContent_6B);
            groupBox21.Controls.Add(Edit_Query_StartAddress_6B);
            groupBox21.Controls.Add(label33);
            groupBox21.Controls.Add(label32);
            groupBox21.Controls.Add(Greater_6B);
            groupBox21.Controls.Add(Less_6B);
            groupBox21.Controls.Add(Different_6B);
            groupBox21.Controls.Add(Same_6B);
            groupBox21.Location = new Point(4, 555);
            groupBox21.Margin = new Padding(4, 3, 4, 3);
            groupBox21.Name = "groupBox21";
            groupBox21.Padding = new Padding(4, 3, 4, 3);
            groupBox21.Size = new Size(374, 219);
            groupBox21.TabIndex = 6;
            groupBox21.TabStop = false;
            groupBox21.Text = "Query Tags by Condition";
            // 
            // Edit_ConditionContent_6B
            // 
            Edit_ConditionContent_6B.Location = new Point(211, 180);
            Edit_ConditionContent_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_ConditionContent_6B.MaxLength = 8;
            Edit_ConditionContent_6B.Name = "Edit_ConditionContent_6B";
            Edit_ConditionContent_6B.Size = new Size(114, 23);
            Edit_ConditionContent_6B.TabIndex = 7;
            Edit_ConditionContent_6B.Text = "00";
            Edit_ConditionContent_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_ConditionContent_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // Edit_Query_StartAddress_6B
            // 
            Edit_Query_StartAddress_6B.Location = new Point(211, 132);
            Edit_Query_StartAddress_6B.Margin = new Padding(4, 3, 4, 3);
            Edit_Query_StartAddress_6B.MaxLength = 2;
            Edit_Query_StartAddress_6B.Name = "Edit_Query_StartAddress_6B";
            Edit_Query_StartAddress_6B.Size = new Size(114, 23);
            Edit_Query_StartAddress_6B.TabIndex = 6;
            Edit_Query_StartAddress_6B.Text = "0";
            Edit_Query_StartAddress_6B.TextChanged += filterOnlyHex_TextChanged;
            Edit_Query_StartAddress_6B.KeyPress += filterOnlyHex_KeyPress;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(11, 183);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(163, 15);
            label33.TabIndex = 5;
            label33.Text = "Condition(<=8 Hex Number):";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(10, 135);
            label32.Margin = new Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new Size(152, 15);
            label32.TabIndex = 4;
            label32.Text = "Address of Tag Data(0-223):";
            // 
            // Greater_6B
            // 
            Greater_6B.AutoSize = true;
            Greater_6B.Enabled = false;
            Greater_6B.Location = new Point(191, 85);
            Greater_6B.Margin = new Padding(4, 3, 4, 3);
            Greater_6B.Name = "Greater_6B";
            Greater_6B.Size = new Size(146, 19);
            Greater_6B.TabIndex = 3;
            Greater_6B.Text = "Greater than Condition";
            Greater_6B.UseVisualStyleBackColor = true;
            // 
            // Less_6B
            // 
            Less_6B.AutoSize = true;
            Less_6B.Enabled = false;
            Less_6B.Location = new Point(10, 85);
            Less_6B.Margin = new Padding(4, 3, 4, 3);
            Less_6B.Name = "Less_6B";
            Less_6B.Size = new Size(130, 19);
            Less_6B.TabIndex = 2;
            Less_6B.Text = "Less than Condition";
            Less_6B.UseVisualStyleBackColor = true;
            // 
            // Different_6B
            // 
            Different_6B.AutoSize = true;
            Different_6B.Enabled = false;
            Different_6B.Location = new Point(191, 37);
            Different_6B.Margin = new Padding(4, 3, 4, 3);
            Different_6B.Name = "Different_6B";
            Different_6B.Size = new Size(125, 19);
            Different_6B.TabIndex = 1;
            Different_6B.Text = "Unequal Condition";
            Different_6B.UseVisualStyleBackColor = true;
            // 
            // Same_6B
            // 
            Same_6B.AutoSize = true;
            Same_6B.Checked = true;
            Same_6B.Enabled = false;
            Same_6B.Location = new Point(10, 37);
            Same_6B.Margin = new Padding(4, 3, 4, 3);
            Same_6B.Name = "Same_6B";
            Same_6B.Size = new Size(110, 19);
            Same_6B.TabIndex = 0;
            Same_6B.TabStop = true;
            Same_6B.Text = "Equal Condition";
            Same_6B.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            groupBox20.Controls.Add(SpeedButton_Query_6B);
            groupBox20.Controls.Add(Bycondition_6B);
            groupBox20.Controls.Add(Byone_6B);
            groupBox20.Controls.Add(ComboBox_IntervalTime_6B);
            groupBox20.Controls.Add(label31);
            groupBox20.Location = new Point(4, 389);
            groupBox20.Margin = new Padding(4, 3, 4, 3);
            groupBox20.Name = "groupBox20";
            groupBox20.Padding = new Padding(4, 3, 4, 3);
            groupBox20.Size = new Size(374, 165);
            groupBox20.TabIndex = 5;
            groupBox20.TabStop = false;
            groupBox20.Text = "Query Tag";
            // 
            // SpeedButton_Query_6B
            // 
            SpeedButton_Query_6B.Location = new Point(248, 80);
            SpeedButton_Query_6B.Margin = new Padding(4, 3, 4, 3);
            SpeedButton_Query_6B.Name = "SpeedButton_Query_6B";
            SpeedButton_Query_6B.Size = new Size(119, 61);
            SpeedButton_Query_6B.TabIndex = 4;
            SpeedButton_Query_6B.Text = "Query";
            SpeedButton_Query_6B.UseVisualStyleBackColor = true;
            SpeedButton_Query_6B.Click += SpeedButton_Query_6B_Click;
            // 
            // Bycondition_6B
            // 
            Bycondition_6B.AutoSize = true;
            Bycondition_6B.Location = new Point(10, 121);
            Bycondition_6B.Margin = new Padding(4, 3, 4, 3);
            Bycondition_6B.Name = "Bycondition_6B";
            Bycondition_6B.Size = new Size(129, 19);
            Bycondition_6B.TabIndex = 3;
            Bycondition_6B.Text = "Query by Condition";
            Bycondition_6B.UseVisualStyleBackColor = true;
            Bycondition_6B.CheckedChanged += Bycondition_6B_CheckedChanged;
            // 
            // Byone_6B
            // 
            Byone_6B.AutoSize = true;
            Byone_6B.Checked = true;
            Byone_6B.Location = new Point(10, 80);
            Byone_6B.Margin = new Padding(4, 3, 4, 3);
            Byone_6B.Name = "Byone_6B";
            Byone_6B.Size = new Size(96, 19);
            Byone_6B.TabIndex = 2;
            Byone_6B.TabStop = true;
            Byone_6B.Text = "Query by one";
            Byone_6B.UseVisualStyleBackColor = true;
            Byone_6B.CheckedChanged += Byone_6B_CheckedChanged;
            // 
            // ComboBox_IntervalTime_6B
            // 
            ComboBox_IntervalTime_6B.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBox_IntervalTime_6B.FormattingEnabled = true;
            ComboBox_IntervalTime_6B.Location = new Point(118, 17);
            ComboBox_IntervalTime_6B.Margin = new Padding(4, 3, 4, 3);
            ComboBox_IntervalTime_6B.Name = "ComboBox_IntervalTime_6B";
            ComboBox_IntervalTime_6B.Size = new Size(249, 23);
            ComboBox_IntervalTime_6B.TabIndex = 1;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(8, 21);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(78, 15);
            label31.TabIndex = 0;
            label31.Text = "Read Interval:";
            // 
            // groupBox19
            // 
            groupBox19.Controls.Add(lv6B_Tags);
            groupBox19.Location = new Point(4, 0);
            groupBox19.Margin = new Padding(4, 3, 4, 3);
            groupBox19.Name = "groupBox19";
            groupBox19.Padding = new Padding(4, 3, 4, 3);
            groupBox19.Size = new Size(948, 387);
            groupBox19.TabIndex = 4;
            groupBox19.TabStop = false;
            groupBox19.Text = "List ID of Tags";
            // 
            // lv6B_Tags
            // 
            lv6B_Tags.Activation = ItemActivation.OneClick;
            lv6B_Tags.AllowDrop = true;
            lv6B_Tags.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7 });
            lv6B_Tags.FullRowSelect = true;
            lv6B_Tags.GridLines = true;
            lv6B_Tags.HotTracking = true;
            lv6B_Tags.HoverSelection = true;
            lv6B_Tags.Location = new Point(7, 25);
            lv6B_Tags.Margin = new Padding(4, 3, 4, 3);
            lv6B_Tags.Name = "lv6B_Tags";
            lv6B_Tags.Size = new Size(934, 352);
            lv6B_Tags.TabIndex = 0;
            lv6B_Tags.UseCompatibleStateImageBehavior = false;
            lv6B_Tags.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "No.";
            columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "ID";
            columnHeader6.Width = 600;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Times";
            columnHeader7.Width = 90;
            // 
            // Timer_Test_6B
            // 
            Timer_Test_6B.Tick += Timer_Test_6B_Tick;
            // 
            // Timer_6B_Read
            // 
            Timer_6B_Read.Tick += Timer_6B_Read_Tick;
            // 
            // Timer_6B_Write
            // 
            Timer_6B_Write.Tick += Timer_6B_Write_Tick;
            // 
            // Form_6B
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox22);
            Controls.Add(groupBox21);
            Controls.Add(groupBox20);
            Controls.Add(groupBox19);
            Name = "Form_6B";
            Size = new Size(959, 778);
            groupBox22.ResumeLayout(false);
            groupBox22.PerformLayout();
            groupBox21.ResumeLayout(false);
            groupBox21.PerformLayout();
            groupBox20.ResumeLayout(false);
            groupBox20.PerformLayout();
            groupBox19.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox22;
        private TextBox Edit_WriteData_6B;
        private Label label36;
        private ListBox lb6B_list2;
        private Button SpeedButton_Clear_6B;
        private Button SpeedButton_Check_6B;
        private Button SpeedButton_Perm_Wr_Prot_6B;
        private Button SpeedButton_Write_6B;
        private Button SpeedButton_Read_6B;
        private TextBox Edit_Len_6B;
        private Label label35;
        private TextBox Edit_StartAddress_6B;
        private Label label34;
        private ComboBox ComboBox_ID1_6B;
        private GroupBox groupBox21;
        private TextBox Edit_ConditionContent_6B;
        private TextBox Edit_Query_StartAddress_6B;
        private Label label33;
        private Label label32;
        private RadioButton Greater_6B;
        private RadioButton Less_6B;
        private RadioButton Different_6B;
        private RadioButton Same_6B;
        private GroupBox groupBox20;
        private Button SpeedButton_Query_6B;
        private RadioButton Bycondition_6B;
        private RadioButton Byone_6B;
        private ComboBox ComboBox_IntervalTime_6B;
        private Label label31;
        private GroupBox groupBox19;
        public ListView lv6B_Tags;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private System.Windows.Forms.Timer Timer_Test_6B;
        private System.Windows.Forms.Timer Timer_6B_Read;
        private System.Windows.Forms.Timer Timer_6B_Write;
    }
}
