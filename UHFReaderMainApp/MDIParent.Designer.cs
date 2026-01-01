namespace UHFReaderMainApp
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            uHFReaderToolStripMenuItem = new ToolStripMenuItem();
            lJYZN105ToolStripMenuItem = new ToolStripMenuItem();
            eSF3105UUCM601ToolStripMenuItem = new ToolStripMenuItem();
            yRM100MagicRFQM100ToolStripMenuItem = new ToolStripMenuItem();
            fM5XXToolStripMenuItem = new ToolStripMenuItem();
            yPDR200ToolStripMenuItem = new ToolStripMenuItem();
            utilitiesToolStripMenuItem = new ToolStripMenuItem();
            compareCardsToolStripMenuItem = new ToolStripMenuItem();
            tagsDatabaseToolStripMenuItem = new ToolStripMenuItem();
            tIDParserToolStripMenuItem = new ToolStripMenuItem();
            windowsMenu = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            closeAllToolStripMenuItem = new ToolStripMenuItem();
            arrangeIconsToolStripMenuItem = new ToolStripMenuItem();
            cPHF206ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileMenu, uHFReaderToolStripMenuItem, utilitiesToolStripMenuItem, windowsMenu });
            menuStrip.Location = new Point(0, 0);
            menuStrip.MdiWindowListItem = windowsMenu;
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(1584, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator5, exitToolStripMenuItem });
            fileMenu.ImageTransparentColor = SystemColors.ActiveBorder;
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += ExitToolsStripMenuItem_Click;
            // 
            // uHFReaderToolStripMenuItem
            // 
            uHFReaderToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { lJYZN105ToolStripMenuItem, eSF3105UUCM601ToolStripMenuItem, yRM100MagicRFQM100ToolStripMenuItem, fM5XXToolStripMenuItem, yPDR200ToolStripMenuItem, cPHF206ToolStripMenuItem });
            uHFReaderToolStripMenuItem.Name = "uHFReaderToolStripMenuItem";
            uHFReaderToolStripMenuItem.Size = new Size(81, 20);
            uHFReaderToolStripMenuItem.Text = "UHF Reader";
            // 
            // lJYZN105ToolStripMenuItem
            // 
            lJYZN105ToolStripMenuItem.Name = "lJYZN105ToolStripMenuItem";
            lJYZN105ToolStripMenuItem.Size = new Size(223, 22);
            lJYZN105ToolStripMenuItem.Text = "LJYZN-105 / BY-RFID105";
            lJYZN105ToolStripMenuItem.Click += lJYZN105ToolStripMenuItem_Click;
            // 
            // eSF3105UUCM601ToolStripMenuItem
            // 
            eSF3105UUCM601ToolStripMenuItem.Name = "eSF3105UUCM601ToolStripMenuItem";
            eSF3105UUCM601ToolStripMenuItem.Size = new Size(223, 22);
            eSF3105UUCM601ToolStripMenuItem.Text = "ES-F3105U / UCM601";
            eSF3105UUCM601ToolStripMenuItem.Click += eSF3105UUCM601ToolStripMenuItem_Click;
            // 
            // yRM100MagicRFQM100ToolStripMenuItem
            // 
            yRM100MagicRFQM100ToolStripMenuItem.Enabled = false;
            yRM100MagicRFQM100ToolStripMenuItem.Name = "yRM100MagicRFQM100ToolStripMenuItem";
            yRM100MagicRFQM100ToolStripMenuItem.Size = new Size(223, 22);
            yRM100MagicRFQM100ToolStripMenuItem.Text = "YRM100 / MagicRF (Q)M100";
            yRM100MagicRFQM100ToolStripMenuItem.Click += yRM100MagicRFQM100ToolStripMenuItem_Click;
            // 
            // fM5XXToolStripMenuItem
            // 
            fM5XXToolStripMenuItem.Name = "fM5XXToolStripMenuItem";
            fM5XXToolStripMenuItem.Size = new Size(223, 22);
            fM5XXToolStripMenuItem.Text = "FM-5XX";
            fM5XXToolStripMenuItem.Click += fM5XXToolStripMenuItem_Click;
            // 
            // yPDR200ToolStripMenuItem
            // 
            yPDR200ToolStripMenuItem.Enabled = false;
            yPDR200ToolStripMenuItem.Name = "yPDR200ToolStripMenuItem";
            yPDR200ToolStripMenuItem.Size = new Size(223, 22);
            yPDR200ToolStripMenuItem.Text = "YPD-R200";
            // 
            // utilitiesToolStripMenuItem
            // 
            utilitiesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { compareCardsToolStripMenuItem, tagsDatabaseToolStripMenuItem, tIDParserToolStripMenuItem });
            utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            utilitiesToolStripMenuItem.Size = new Size(58, 20);
            utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // compareCardsToolStripMenuItem
            // 
            compareCardsToolStripMenuItem.Name = "compareCardsToolStripMenuItem";
            compareCardsToolStripMenuItem.Size = new Size(156, 22);
            compareCardsToolStripMenuItem.Text = "Compare Cards";
            compareCardsToolStripMenuItem.Click += compareCardsToolStripMenuItem_Click;
            // 
            // tagsDatabaseToolStripMenuItem
            // 
            tagsDatabaseToolStripMenuItem.Name = "tagsDatabaseToolStripMenuItem";
            tagsDatabaseToolStripMenuItem.Size = new Size(156, 22);
            tagsDatabaseToolStripMenuItem.Text = "Tags Database";
            tagsDatabaseToolStripMenuItem.Click += tagsDatabaseToolStripMenuItem_Click;
            // 
            // tIDParserToolStripMenuItem
            // 
            tIDParserToolStripMenuItem.Name = "tIDParserToolStripMenuItem";
            tIDParserToolStripMenuItem.Size = new Size(156, 22);
            tIDParserToolStripMenuItem.Text = "TID Parser";
            tIDParserToolStripMenuItem.Click += tIDParserToolStripMenuItem_Click;
            // 
            // windowsMenu
            // 
            windowsMenu.DropDownItems.AddRange(new ToolStripItem[] { cascadeToolStripMenuItem, tileVerticalToolStripMenuItem, tileHorizontalToolStripMenuItem, closeAllToolStripMenuItem, arrangeIconsToolStripMenuItem });
            windowsMenu.Name = "windowsMenu";
            windowsMenu.Size = new Size(68, 20);
            windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(151, 22);
            cascadeToolStripMenuItem.Text = "&Cascade";
            cascadeToolStripMenuItem.Click += CascadeToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(151, 22);
            tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            tileVerticalToolStripMenuItem.Click += TileVerticalToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(151, 22);
            tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            tileHorizontalToolStripMenuItem.Click += TileHorizontalToolStripMenuItem_Click;
            // 
            // closeAllToolStripMenuItem
            // 
            closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            closeAllToolStripMenuItem.Size = new Size(151, 22);
            closeAllToolStripMenuItem.Text = "C&lose All";
            closeAllToolStripMenuItem.Click += CloseAllToolStripMenuItem_Click;
            // 
            // arrangeIconsToolStripMenuItem
            // 
            arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            arrangeIconsToolStripMenuItem.Size = new Size(151, 22);
            arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            arrangeIconsToolStripMenuItem.Click += ArrangeIconsToolStripMenuItem_Click;
            // 
            // cPHF206ToolStripMenuItem
            // 
            cPHF206ToolStripMenuItem.Name = "cPHF206ToolStripMenuItem";
            cPHF206ToolStripMenuItem.Size = new Size(223, 22);
            cPHF206ToolStripMenuItem.Text = "CPH-F206";
            cPHF206ToolStripMenuItem.Click += cPHF206ToolStripMenuItem_Click;
            // 
            // MDIParent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 961);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MDIParent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UHFReader";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private ToolStripMenuItem uHFReaderToolStripMenuItem;
        private ToolStripMenuItem lJYZN105ToolStripMenuItem;
        private ToolStripMenuItem eSF3105UUCM601ToolStripMenuItem;
        private ToolStripMenuItem yRM100MagicRFQM100ToolStripMenuItem;
        private ToolStripMenuItem fM5XXToolStripMenuItem;
        private ToolStripMenuItem utilitiesToolStripMenuItem;
        private ToolStripMenuItem compareCardsToolStripMenuItem;
        private ToolStripMenuItem tagsDatabaseToolStripMenuItem;
        private ToolStripMenuItem yPDR200ToolStripMenuItem;
        private ToolStripMenuItem tIDParserToolStripMenuItem;
        private ToolStripMenuItem cPHF206ToolStripMenuItem;
    }
}



