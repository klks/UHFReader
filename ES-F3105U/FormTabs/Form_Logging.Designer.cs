namespace ES_F3105U
{
    partial class Form_Logging
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
            groupBox4 = new GroupBox();
            lbAPILog = new ListBox();
            btnLogClearAPI = new Button();
            groupBox5 = new GroupBox();
            lbSerialLog = new ListBox();
            btnLogClearSerial = new Button();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbAPILog);
            groupBox4.Controls.Add(btnLogClearAPI);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(966, 390);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "API Log";
            // 
            // lbAPILog
            // 
            lbAPILog.FormattingEnabled = true;
            lbAPILog.ItemHeight = 15;
            lbAPILog.Location = new Point(6, 27);
            lbAPILog.Name = "lbAPILog";
            lbAPILog.Size = new Size(954, 349);
            lbAPILog.TabIndex = 1;
            // 
            // btnLogClearAPI
            // 
            btnLogClearAPI.Location = new Point(891, 0);
            btnLogClearAPI.Name = "btnLogClearAPI";
            btnLogClearAPI.Size = new Size(75, 23);
            btnLogClearAPI.TabIndex = 0;
            btnLogClearAPI.Text = "Clear";
            btnLogClearAPI.UseVisualStyleBackColor = true;
            btnLogClearAPI.Click += btnLogClearAPI_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbSerialLog);
            groupBox5.Controls.Add(btnLogClearSerial);
            groupBox5.Location = new Point(3, 407);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(966, 390);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Serial Log";
            // 
            // lbSerialLog
            // 
            lbSerialLog.FormattingEnabled = true;
            lbSerialLog.ItemHeight = 15;
            lbSerialLog.Location = new Point(6, 28);
            lbSerialLog.Name = "lbSerialLog";
            lbSerialLog.Size = new Size(954, 349);
            lbSerialLog.TabIndex = 2;
            // 
            // btnLogClearSerial
            // 
            btnLogClearSerial.Location = new Point(891, -1);
            btnLogClearSerial.Name = "btnLogClearSerial";
            btnLogClearSerial.Size = new Size(75, 23);
            btnLogClearSerial.TabIndex = 1;
            btnLogClearSerial.Text = "Clear";
            btnLogClearSerial.UseVisualStyleBackColor = true;
            btnLogClearSerial.Click += btnLogClearSerial_Click;
            // 
            // Form_Logging
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox4);
            Controls.Add(groupBox5);
            Name = "Form_Logging";
            Size = new Size(974, 804);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private ListBox lbAPILog;
        private Button btnLogClearAPI;
        private GroupBox groupBox5;
        private ListBox lbSerialLog;
        private Button btnLogClearSerial;
    }
}
