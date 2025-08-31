using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Utilities;
using FM_5XX.Shared;
using FM_5XX.FormTabs;

namespace FM_5XX
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FormSharedData.lbStatusMessage = lbStatusMessage;

            //Add Reader User Interface
            var tabReader = new Form_Reader();
            tabReader.Dock = DockStyle.Fill;
            tabControl1.TabPages[0].Controls.Add(tabReader);

            //Add EPCC1G26C User Interface
            var tabEPCC1G26C = new Form_EPCC1G26C();
            tabEPCC1G26C.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(tabEPCC1G26C);

            FormSharedData.Form_Reader = tabReader;
            FormSharedData.Form_6C = tabEPCC1G26C;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormSharedData.readerClient != null)
                FormSharedData.readerClient.Dispose();
            FormSharedData.readerClient = null;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
        private void btnLogClearStatus_Click(object sender, EventArgs e)
        {
            lbStatusMessage.Items.Clear();
        }
    }
}
