using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCchip.Reader.API;
using Utilities;

namespace ES_F3105U
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            //Add Reader User Interface
            var tabReader = new Form_Reader();
            tabReader.Dock = DockStyle.Fill;
            tabControl1.TabPages[0].Controls.Add(tabReader);

            //Add EPCC1G26C User Interface
            var tabEPCC1G26C = new Form_EPCC1G26C();
            tabEPCC1G26C.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(tabEPCC1G26C);

            //Add Logging User Interface
            var tabDuplicate = new Form_Duplicate();
            tabDuplicate.Dock = DockStyle.Fill;
            tabControl1.TabPages[2].Controls.Add(tabDuplicate);

            //Add Logging User Interface
            var tabLogging = new Form_Logging();
            tabLogging.Dock = DockStyle.Fill;
            tabControl1.TabPages[3].Controls.Add(tabLogging);

            //Register common handlers
            FormSharedData.lbResponse = lbResponse;
            FormSharedData.SerialPortLog = tabLogging.Logging_SerialPortLogger;
            FormSharedData.APILog = tabLogging.Logging_APILogger;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormSharedData.readerClient != null)
                FormSharedData.readerClient.Dispose();
            FormSharedData.readerClient = null;
        }
    }
}
