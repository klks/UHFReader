using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHFReaderMainApp
{
    /// <summary>
    /// Main MDI parent form for the UHFReader application.
    /// Manages child windows and application layout.
    /// </summary>
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        string sw_version = "UHFReader 1.0.0 - KLKS (Sept 2025)";
        Form? ChildWindow_TIDParser = null;

        /// <summary>
        /// Initializes the MDI parent form and sets the window title.
        /// </summary>
        public MDIParent()
        {
            InitializeComponent();
            this.Text = sw_version;
        }

        /// <summary>
        /// Creates and shows a new generic child form.
        /// </summary>
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        /// <summary>
        /// Closes the main application window.
        /// </summary>
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Arranges child windows in a cascade layout.
        /// </summary>
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Arranges child windows vertically.
        /// </summary>
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Arranges child windows horizontally.
        /// </summary>
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Arranges icons for minimized child windows.
        /// </summary>
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        /// <summary>
        /// Closes all child windows.
        /// </summary>
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        /// <summary>
        /// Opens the LJYZN-105 child form.
        /// </summary>
        private void lJYZN105ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new LJYZN_105.MainForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        /// <summary>
        /// Opens the ES-F3105U child form.
        /// </summary>
        private void eSF3105UUCM601ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new ES_F3105U.MainForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void yRM100MagicRFQM100ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fM5XXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new FM_5XX.MainForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        /// <summary>
        /// Opens the card comparison utility form.
        /// </summary>
        private void compareCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Utilities.CardCompare();
            childForm.MdiParent = this;
            childForm.Show();
        }

        /// <summary>
        /// Opens the tags database utility form.
        /// </summary>
        private void tagsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Utilities.TagsDatabase();
            childForm.MdiParent = this;
            childForm.Show();
        }

        /// <summary>
        /// Opens the TID parser utility form, or brings it to front if already open.
        /// </summary>
        private void tIDParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChildWindow_TIDParser == null || ChildWindow_TIDParser.IsDisposed)
            {
                ChildWindow_TIDParser = new Utilities.TIDParser();
                ChildWindow_TIDParser.MdiParent = this;
                ChildWindow_TIDParser.Show();
            }
            else
            {
                ChildWindow_TIDParser.BringToFront();
            }
        }

        private void cPHF206ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new CPH_F206.MainForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
