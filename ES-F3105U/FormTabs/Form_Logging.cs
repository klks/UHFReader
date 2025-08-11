using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES_F3105U
{
    public partial class Form_Logging : UserControl
    {
        public Form_Logging()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Logs a message to the serial port log ListBox with a timestamp.
        /// Ensures thread-safe UI updates.
        /// </summary>
        public void Logging_SerialPortLogger(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();
            lbSerialLog.Invoke(new MethodInvoker(delegate { lbSerialLog.Items.Add($"[{time_now}] {message}"); }));
        }

        /// <summary>
        /// Logs a message to the API log ListBox with a timestamp.
        /// Ensures thread-safe UI updates.
        /// </summary>
        public void Logging_APILogger(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();
            lbAPILog.Invoke(new MethodInvoker(delegate { lbAPILog.Items.Add($"[{time_now}] {message}"); }));
        }

        /// <summary>
        /// Clears all entries from the serial port log ListBox.
        /// </summary>
        private void btnLogClearSerial_Click(object sender, EventArgs e)
        {
            lbSerialLog.Items.Clear();
        }

        /// <summary>
        /// Clears all entries from the API log ListBox.
        /// </summary>
        private void btnLogClearAPI_Click(object sender, EventArgs e)
        {
            lbAPILog.Items.Clear();
        }
    }
}
