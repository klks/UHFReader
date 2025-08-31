namespace FM_5XX
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btnLogClearStatus = new Button();
            lbStatusMessage = new ListBox();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1256, 755);
            tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1248, 727);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Reader Parameter";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1248, 727);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "EPC C1-G2 / 6C";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLogClearStatus
            // 
            btnLogClearStatus.Location = new Point(582, 845);
            btnLogClearStatus.Name = "btnLogClearStatus";
            btnLogClearStatus.Size = new Size(75, 23);
            btnLogClearStatus.TabIndex = 12;
            btnLogClearStatus.Text = "Clear";
            btnLogClearStatus.UseVisualStyleBackColor = true;
            btnLogClearStatus.Click += btnLogClearStatus_Click;
            // 
            // lbStatusMessage
            // 
            lbStatusMessage.FormattingEnabled = true;
            lbStatusMessage.ItemHeight = 15;
            lbStatusMessage.Location = new Point(6, 759);
            lbStatusMessage.Name = "lbStatusMessage";
            lbStatusMessage.Size = new Size(570, 109);
            lbStatusMessage.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 874);
            Controls.Add(lbStatusMessage);
            Controls.Add(btnLogClearStatus);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "FM-5XX";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnLogClearStatus;
        private ListBox lbStatusMessage;
    }
}