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
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;
        string sw_version = "UHFReader 1.0.0 - KLKS (Apr 2025)";
        Form? ChildWindow_TIDParser = null;

        public MDIParent()
        {
            InitializeComponent();
            this.Text = sw_version;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void lJYZN105ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new LJYZN_105.MainForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

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

        private void compareCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Utilities.CardCompare();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void tagsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new Utilities.TagsDatabase();
            childForm.MdiParent = this;
            childForm.Show();
        }

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
    }
}
