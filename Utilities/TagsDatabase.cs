using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Utilities;

namespace Utilities
{
    public partial class TagsDatabase : Form
    {
        public TagsDatabase()
        {
            InitializeComponent();
            Init_DatabaseUI();
        }

        private void Init_DatabaseUI()
        {
            //Load database
            LoadICDB();
            Populate();
        }

        private void Populate()
        {
            foreach (DigitsICDB entry in DigitsDBList)
            {
                ListViewItem lvItem = new(entry.mdid);
                lvItem.SubItems.Add(entry.manufacturer);
                lvItem.SubItems.Add(entry.tmn);
                lvItem.SubItems.Add(entry.modelName);
                lvICDB.Items.Add(lvItem);
            }
        }

        private void btnDBReset_Click(object sender, EventArgs e)
        {
            lvICDB.Items.Clear();
            Populate();
        }

        private void lvICDB_Click(object sender, EventArgs e)
        {
            if (lvICDB.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvICDB.SelectedItems[0];
                string mdid = selectedItem.Text;
                string tmn = selectedItem.SubItems[2].Text;
                string modelName = selectedItem.SubItems[3].Text;

                foreach (DigitsICDB entry in Utilities.DigitsDBList)
                {
                    if (entry.mdid == mdid)
                    {
                        if (entry.tmn == tmn && entry.modelName == modelName)
                        {
                            txtDBManuURL.Text = entry.manufacturerUrl;
                            txtDBProdUrl.Text = entry.productUrl;
                            txtDBNotes.Text = entry.note;
                            break;
                        }
                    }
                }
            }

        }

        private void btnDBSearch_Click(object sender, EventArgs e)
        {
            string mdid = txtICDB_MDID.Text;
            string tmn = txtICDB_TMN.Text;

            lvICDB.Items.Clear();

            if (mdid != null && mdid != "")
            {
                foreach (DigitsICDB entry in Utilities.DigitsDBList)
                {
                    if (entry.mdid == mdid)
                    {
                        if (tmn == null || tmn == "" || entry.tmn == tmn)
                        {
                            ListViewItem lvItem = new(entry.mdid);
                            lvItem.SubItems.Add(entry.manufacturer);
                            lvItem.SubItems.Add(entry.tmn);
                            lvItem.SubItems.Add(entry.modelName);
                            lvICDB.Items.Add(lvItem);
                        }
                    }
                }
            }
        }
    }
}
