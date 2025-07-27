namespace Utilities
{
    partial class TagsDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagsDatabase));
            groupBox32 = new GroupBox();
            label98 = new Label();
            txtDBNotes = new TextBox();
            txtDBProdUrl = new TextBox();
            txtDBManuURL = new TextBox();
            label97 = new Label();
            label96 = new Label();
            btnDBSearch = new Button();
            btnDBReset = new Button();
            label95 = new Label();
            txtICDB_TMN = new TextBox();
            label67 = new Label();
            txtICDB_MDID = new TextBox();
            lvICDB = new ListView();
            lvICDBCol_MDID = new ColumnHeader();
            lvICDBCol_Manu = new ColumnHeader();
            lvICDBCol_TMN = new ColumnHeader();
            lvICDBCol_Model = new ColumnHeader();
            groupBox32.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox32
            // 
            groupBox32.Controls.Add(label98);
            groupBox32.Controls.Add(txtDBNotes);
            groupBox32.Controls.Add(txtDBProdUrl);
            groupBox32.Controls.Add(txtDBManuURL);
            groupBox32.Controls.Add(label97);
            groupBox32.Controls.Add(label96);
            groupBox32.Controls.Add(btnDBSearch);
            groupBox32.Controls.Add(btnDBReset);
            groupBox32.Controls.Add(label95);
            groupBox32.Controls.Add(txtICDB_TMN);
            groupBox32.Controls.Add(label67);
            groupBox32.Controls.Add(txtICDB_MDID);
            groupBox32.Controls.Add(lvICDB);
            groupBox32.Location = new Point(13, 12);
            groupBox32.Margin = new Padding(4, 3, 4, 3);
            groupBox32.Name = "groupBox32";
            groupBox32.Padding = new Padding(4, 3, 4, 3);
            groupBox32.Size = new Size(964, 637);
            groupBox32.TabIndex = 3;
            groupBox32.TabStop = false;
            groupBox32.Text = "Database";
            // 
            // label98
            // 
            label98.AutoSize = true;
            label98.Location = new Point(70, 518);
            label98.Name = "label98";
            label98.Size = new Size(38, 15);
            label98.TabIndex = 32;
            label98.Text = "Notes";
            // 
            // txtDBNotes
            // 
            txtDBNotes.Location = new Point(118, 515);
            txtDBNotes.Margin = new Padding(4, 3, 4, 3);
            txtDBNotes.MaxLength = 3;
            txtDBNotes.Multiline = true;
            txtDBNotes.Name = "txtDBNotes";
            txtDBNotes.ReadOnly = true;
            txtDBNotes.Size = new Size(838, 109);
            txtDBNotes.TabIndex = 31;
            // 
            // txtDBProdUrl
            // 
            txtDBProdUrl.Location = new Point(118, 486);
            txtDBProdUrl.Margin = new Padding(4, 3, 4, 3);
            txtDBProdUrl.MaxLength = 3;
            txtDBProdUrl.Name = "txtDBProdUrl";
            txtDBProdUrl.ReadOnly = true;
            txtDBProdUrl.Size = new Size(838, 23);
            txtDBProdUrl.TabIndex = 30;
            // 
            // txtDBManuURL
            // 
            txtDBManuURL.Location = new Point(118, 456);
            txtDBManuURL.Margin = new Padding(4, 3, 4, 3);
            txtDBManuURL.MaxLength = 3;
            txtDBManuURL.Name = "txtDBManuURL";
            txtDBManuURL.ReadOnly = true;
            txtDBManuURL.Size = new Size(838, 23);
            txtDBManuURL.TabIndex = 29;
            // 
            // label97
            // 
            label97.AutoSize = true;
            label97.Location = new Point(40, 489);
            label97.Name = "label97";
            label97.Size = new Size(73, 15);
            label97.TabIndex = 28;
            label97.Text = "Product URL";
            // 
            // label96
            // 
            label96.AutoSize = true;
            label96.Location = new Point(10, 459);
            label96.Name = "label96";
            label96.Size = new Size(103, 15);
            label96.TabIndex = 27;
            label96.Text = "Manufacturer URL";
            // 
            // btnDBSearch
            // 
            btnDBSearch.Location = new Point(189, 22);
            btnDBSearch.Name = "btnDBSearch";
            btnDBSearch.RightToLeft = RightToLeft.No;
            btnDBSearch.Size = new Size(75, 23);
            btnDBSearch.TabIndex = 26;
            btnDBSearch.Text = "Search";
            btnDBSearch.UseVisualStyleBackColor = true;
            btnDBSearch.Click += btnDBSearch_Click;
            // 
            // btnDBReset
            // 
            btnDBReset.Location = new Point(270, 22);
            btnDBReset.Name = "btnDBReset";
            btnDBReset.RightToLeft = RightToLeft.No;
            btnDBReset.Size = new Size(75, 23);
            btnDBReset.TabIndex = 25;
            btnDBReset.Text = "Reset";
            btnDBReset.UseVisualStyleBackColor = true;
            btnDBReset.Click += btnDBReset_Click;
            // 
            // label95
            // 
            label95.AutoSize = true;
            label95.Location = new Point(100, 27);
            label95.Margin = new Padding(4, 0, 4, 0);
            label95.Name = "label95";
            label95.Size = new Size(33, 15);
            label95.TabIndex = 23;
            label95.Text = "TMN";
            // 
            // txtICDB_TMN
            // 
            txtICDB_TMN.CharacterCasing = CharacterCasing.Upper;
            txtICDB_TMN.Location = new Point(139, 22);
            txtICDB_TMN.Margin = new Padding(4, 3, 4, 3);
            txtICDB_TMN.MaxLength = 3;
            txtICDB_TMN.Name = "txtICDB_TMN";
            txtICDB_TMN.Size = new Size(38, 23);
            txtICDB_TMN.TabIndex = 22;
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new Point(10, 27);
            label67.Margin = new Padding(4, 0, 4, 0);
            label67.Name = "label67";
            label67.Size = new Size(37, 15);
            label67.TabIndex = 20;
            label67.Text = "MDID";
            // 
            // txtICDB_MDID
            // 
            txtICDB_MDID.CharacterCasing = CharacterCasing.Upper;
            txtICDB_MDID.Location = new Point(54, 22);
            txtICDB_MDID.Margin = new Padding(4, 3, 4, 3);
            txtICDB_MDID.MaxLength = 3;
            txtICDB_MDID.Name = "txtICDB_MDID";
            txtICDB_MDID.Size = new Size(38, 23);
            txtICDB_MDID.TabIndex = 21;
            // 
            // lvICDB
            // 
            lvICDB.Columns.AddRange(new ColumnHeader[] { lvICDBCol_MDID, lvICDBCol_Manu, lvICDBCol_TMN, lvICDBCol_Model });
            lvICDB.FullRowSelect = true;
            lvICDB.GridLines = true;
            lvICDB.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvICDB.Location = new Point(7, 54);
            lvICDB.Margin = new Padding(4, 3, 4, 3);
            lvICDB.Name = "lvICDB";
            lvICDB.Size = new Size(949, 387);
            lvICDB.TabIndex = 0;
            lvICDB.UseCompatibleStateImageBehavior = false;
            lvICDB.View = View.Details;
            lvICDB.Click += lvICDB_Click;
            // 
            // lvICDBCol_MDID
            // 
            lvICDBCol_MDID.Tag = "MDID";
            lvICDBCol_MDID.Text = "MDID";
            lvICDBCol_MDID.Width = 50;
            // 
            // lvICDBCol_Manu
            // 
            lvICDBCol_Manu.Tag = "MANU";
            lvICDBCol_Manu.Text = "Manufacturer";
            lvICDBCol_Manu.Width = 350;
            // 
            // lvICDBCol_TMN
            // 
            lvICDBCol_TMN.Tag = "TMN";
            lvICDBCol_TMN.Text = "TMN";
            lvICDBCol_TMN.Width = 50;
            // 
            // lvICDBCol_Model
            // 
            lvICDBCol_Model.Tag = "MODEL";
            lvICDBCol_Model.Text = "Model Name";
            lvICDBCol_Model.Width = 350;
            // 
            // TagsDatabase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 656);
            Controls.Add(groupBox32);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TagsDatabase";
            Text = "TagsDatabase";
            groupBox32.ResumeLayout(false);
            groupBox32.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox32;
        private Label label98;
        private TextBox txtDBNotes;
        private TextBox txtDBProdUrl;
        private TextBox txtDBManuURL;
        private Label label97;
        private Label label96;
        private Button btnDBSearch;
        private Button btnDBReset;
        private Label label95;
        private TextBox txtICDB_TMN;
        private Label label67;
        private TextBox txtICDB_MDID;
        private ListView lvICDB;
        private ColumnHeader lvICDBCol_MDID;
        private ColumnHeader lvICDBCol_Manu;
        private ColumnHeader lvICDBCol_TMN;
        private ColumnHeader lvICDBCol_Model;
    }
}