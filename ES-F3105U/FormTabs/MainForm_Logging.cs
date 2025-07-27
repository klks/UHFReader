using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES_F3105U
{
    partial class MainForm
    {
        private void Logging_SerialPortLogger(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();

            if (lbSerialLog.InvokeRequired)
            {
                lbSerialLog.Invoke(new MethodInvoker(delegate { lbSerialLog.Items.Add($"[{time_now}] {message}"); }));
            }
            else
            {
                lbSerialLog.Items.Add($"[{time_now}] {message}");
            }
        }

        private void Logging_APILogger(string message)
        {
            string time_now = DateTime.Now.ToLongTimeString();
            
            if (lbAPILog.InvokeRequired)
            {
                lbAPILog.Invoke(new MethodInvoker(delegate { lbAPILog.Items.Add($"[{time_now}] {message}"); }));
            }
            else
            {
                lbAPILog.Items.Add($"[{time_now}] {message}");
            }
        }

        private void btnLogClearSerial_Click(object sender, EventArgs e)
        {
            lbSerialLog.Items.Clear();
        }

        private void btnLogClearAPI_Click(object sender, EventArgs e)
        {
            lbAPILog.Items.Clear();
        }
    }
}
