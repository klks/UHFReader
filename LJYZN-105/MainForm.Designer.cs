namespace LJYZN_105
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
        /// Required method for Designer support - do not
        /// modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            StatusBar1 = new StatusStrip();
            tss_Status = new ToolStripStatusLabel();
            tss_COM = new ToolStripStatusLabel();
            TabSheet_DUP = new TabPage();
            TabSheet_6B = new TabPage();
            TabSheet_EPCC1G2 = new TabPage();
            tabControl1 = new TabControl();
            TabSheet_CMD = new TabPage();
            StatusBar1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // StatusBar1
            // 
            StatusBar1.Items.AddRange(new ToolStripItem[] { tss_Status, tss_COM });
            StatusBar1.Location = new Point(0, 817);
            StatusBar1.Name = "StatusBar1";
            StatusBar1.Padding = new Padding(1, 0, 16, 0);
            StatusBar1.Size = new Size(966, 22);
            StatusBar1.TabIndex = 0;
            // 
            // tss_Status
            // 
            tss_Status.Name = "tss_Status";
            tss_Status.Size = new Size(914, 17);
            tss_Status.Spring = true;
            tss_Status.Text = "Status";
            tss_Status.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tss_COM
            // 
            tss_COM.Name = "tss_COM";
            tss_COM.Size = new Size(35, 17);
            tss_COM.Text = "COM";
            // 
            // TabSheet_DUP
            // 
            TabSheet_DUP.Location = new Point(4, 24);
            TabSheet_DUP.Margin = new Padding(4, 3, 4, 3);
            TabSheet_DUP.Name = "TabSheet_DUP";
            TabSheet_DUP.Padding = new Padding(4, 3, 4, 3);
            TabSheet_DUP.Size = new Size(954, 784);
            TabSheet_DUP.TabIndex = 4;
            TabSheet_DUP.Text = "Duplicator";
            TabSheet_DUP.UseVisualStyleBackColor = true;
            // 
            // TabSheet_6B
            // 
            TabSheet_6B.Location = new Point(4, 24);
            TabSheet_6B.Margin = new Padding(4, 3, 4, 3);
            TabSheet_6B.Name = "TabSheet_6B";
            TabSheet_6B.Size = new Size(954, 784);
            TabSheet_6B.TabIndex = 3;
            TabSheet_6B.Text = "18000-6B";
            TabSheet_6B.UseVisualStyleBackColor = true;
            // 
            // TabSheet_EPCC1G2
            // 
            TabSheet_EPCC1G2.Location = new Point(4, 24);
            TabSheet_EPCC1G2.Margin = new Padding(4, 3, 4, 3);
            TabSheet_EPCC1G2.Name = "TabSheet_EPCC1G2";
            TabSheet_EPCC1G2.Size = new Size(954, 784);
            TabSheet_EPCC1G2.TabIndex = 2;
            TabSheet_EPCC1G2.Text = "EPC C1-G2 / 6C";
            TabSheet_EPCC1G2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabSheet_CMD);
            tabControl1.Controls.Add(TabSheet_EPCC1G2);
            tabControl1.Controls.Add(TabSheet_6B);
            tabControl1.Controls.Add(TabSheet_DUP);
            tabControl1.Location = new Point(0, 2);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(962, 812);
            tabControl1.TabIndex = 0;
            // 
            // TabSheet_CMD
            // 
            TabSheet_CMD.BackColor = Color.Transparent;
            TabSheet_CMD.Location = new Point(4, 24);
            TabSheet_CMD.Margin = new Padding(4, 3, 4, 3);
            TabSheet_CMD.Name = "TabSheet_CMD";
            TabSheet_CMD.Padding = new Padding(4, 3, 4, 3);
            TabSheet_CMD.Size = new Size(954, 784);
            TabSheet_CMD.TabIndex = 1;
            TabSheet_CMD.Text = "Reader Parameter";
            TabSheet_CMD.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(966, 839);
            Controls.Add(StatusBar1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LJYZN-105 / BY-RFID105";
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += Form1_Load;
            StatusBar1.ResumeLayout(false);
            StatusBar1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal System.Windows.Forms.StatusStrip StatusBar1;
        private System.Windows.Forms.ToolStripStatusLabel tss_Status;
        private System.Windows.Forms.ToolStripStatusLabel tss_COM;
        private TabPage TabSheet_DUP;
        private TabPage TabSheet_6B;
        private TabPage TabSheet_EPCC1G2;
        private TabControl tabControl1;
        private TabPage TabSheet_CMD;
    }
}

