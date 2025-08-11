namespace ES_F3105U
{
    partial class MainForm
    {
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new TabControl();
            TabSheet_READER = new TabPage();
            TabSheet_6C = new TabPage();
            TabSheet_DUP = new TabPage();
            TabSheet_LOG = new TabPage();
            lbResponse = new ListBox();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabSheet_READER);
            tabControl1.Controls.Add(TabSheet_6C);
            tabControl1.Controls.Add(TabSheet_DUP);
            tabControl1.Controls.Add(TabSheet_LOG);
            tabControl1.Location = new Point(2, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(983, 831);
            tabControl1.TabIndex = 0;
            // 
            // TabSheet_READER
            // 
            TabSheet_READER.Location = new Point(4, 24);
            TabSheet_READER.Name = "TabSheet_READER";
            TabSheet_READER.Padding = new Padding(3);
            TabSheet_READER.Size = new Size(975, 803);
            TabSheet_READER.TabIndex = 1;
            TabSheet_READER.Text = "Reader Parameter";
            TabSheet_READER.UseVisualStyleBackColor = true;
            // 
            // TabSheet_6C
            // 
            TabSheet_6C.Location = new Point(4, 24);
            TabSheet_6C.Name = "TabSheet_6C";
            TabSheet_6C.Size = new Size(975, 803);
            TabSheet_6C.TabIndex = 2;
            TabSheet_6C.Text = "EPC C1-G2 / 6C";
            TabSheet_6C.UseVisualStyleBackColor = true;
            // 
            // TabSheet_DUP
            // 
            TabSheet_DUP.Location = new Point(4, 24);
            TabSheet_DUP.Name = "TabSheet_DUP";
            TabSheet_DUP.Size = new Size(975, 803);
            TabSheet_DUP.TabIndex = 3;
            TabSheet_DUP.Text = "Duplicator";
            TabSheet_DUP.UseVisualStyleBackColor = true;
            // 
            // TabSheet_LOG
            // 
            TabSheet_LOG.Location = new Point(4, 24);
            TabSheet_LOG.Name = "TabSheet_LOG";
            TabSheet_LOG.Size = new Size(975, 803);
            TabSheet_LOG.TabIndex = 6;
            TabSheet_LOG.Text = "Logging";
            TabSheet_LOG.UseVisualStyleBackColor = true;
            // 
            lbResponse.FormattingEnabled = true;
            lbResponse.ItemHeight = 15;
            lbResponse.Location = new Point(991, 17);
            lbResponse.Name = "lbResponse";
            lbResponse.Size = new Size(479, 814);
            lbResponse.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1482, 836);
            Controls.Add(lbResponse);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ES-F3105U / UCM601";
            FormClosed += MainForm_FormClosed;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TabSheet_READER;
        private TabPage TabSheet_6C;
        private TabPage TabSheet_DUP;
        private TabPage TabSheet_LOG;
        private ListBox lbResponse;
    }
}
