using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES_F3105U
{
    partial class MainForm
    {
        /// <summary>
        /// Logs a message to the serial port log ListBox with a timestamp.
        /// Ensures thread-safe UI updates.
        /// </summary>
        private void Logging_SerialPortLogger(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();
            lbSerialLog.Invoke(new MethodInvoker(delegate { lbSerialLog.Items.Add($"[{time_now}] {message}"); }));
        }

        /// <summary>
        /// Logs a message to the API log ListBox with a timestamp.
        /// Ensures thread-safe UI updates.
        /// </summary>
        private void Logging_APILogger(string message)
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
