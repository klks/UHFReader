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
    /// <summary>
    /// Form for viewing, searching, and interacting with the ICDB tags database.
    /// </summary>
    public partial class TagsDatabase : Form
    {
        /// <summary>
        /// Initializes the TagsDatabase form and its UI.
        /// </summary>
        public TagsDatabase()
        {
            InitializeComponent();
            Init_DatabaseUI();
        }

        /// <summary>
        /// Initializes the database UI by loading the ICDB and populating the ListView.
        /// </summary>
        private void Init_DatabaseUI()
        {
            // Load database and populate ListView
            LoadICDB();
            Populate();
        }

        /// <summary>
        /// Populates the ListView with entries from DigitsDBList.
        /// </summary>
        private void Populate()
        {
            foreach (DigitsICDB entry in DigitsDBList)
            {
                // Add each entry as a ListViewItem with relevant subitems
                ListViewItem lvItem = new(entry.mdid);
                lvItem.SubItems.Add(entry.manufacturer);
                lvItem.SubItems.Add(entry.tmn);
                lvItem.SubItems.Add(entry.modelName);
                lvICDB.Items.Add(lvItem);
            }
        }

        /// <summary>
        /// Resets the ListView to show all database entries.
        /// </summary>
        private void btnDBReset_Click(object sender, EventArgs e)
        {
            lvICDB.Items.Clear();
            Populate();
        }

        /// <summary>
        /// Handles ListView item click to display detailed info for the selected entry.
        /// </summary>
        private void lvICDB_Click(object sender, EventArgs e)
        {
            if (lvICDB.SelectedItems.Count > 0)
            {
                // Get selected entry details
                ListViewItem selectedItem = lvICDB.SelectedItems[0];
                string mdid = selectedItem.Text;
                string tmn = selectedItem.SubItems[2].Text;
                string modelName = selectedItem.SubItems[3].Text;

                // Find the matching entry and display its details
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

        /// <summary>
        /// Searches the database for entries matching the provided MDID and TMN.
        /// </summary>
        private void btnDBSearch_Click(object sender, EventArgs e)
        {
            string mdid = txtICDB_MDID.Text;
            string tmn = txtICDB_TMN.Text;

            lvICDB.Items.Clear();

            if (mdid != null && mdid != "")
            {
                //Walk database to find a match
                foreach (DigitsICDB entry in Utilities.DigitsDBList)
                {
                    if (entry.mdid == mdid)
                    {
                        // If TMN is empty, populate all matching mdid, else only show matching tmn
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
