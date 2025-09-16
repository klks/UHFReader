using FM_5XX.FormTabs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FM_5XX.Shared
{
    public static class FormSharedData
    {
        public enum CommandStates
        {
            DEFAULT,
            INFO,
            EPC,
            TID,
            SELECT,
            PASSWORD,
            MULTI,
            READ,
            WRITE,
            LOCK,
            KILL,
            B02_MULTIREAD,
            B02_MULTIREAD_Q,
            B02_MULTI,
            B02_MULTI_Q,
            INV_EPC,
            INV_TID,
            MASK,
        }

        [DllImport("psapi.dll")]
        private static extern int EmptyWorkingSet(IntPtr hwProc);

        public static ReaderService.Module.Version VersionFW;
        public static ReaderService? readerClient;
        public static bool IsReceiveDataWork = false;
        public static ListBox? lbSerialLog = null;
        public static ListBox? lbStatusMessage = null;
        public static CommandStates DoProcess;
        public static Form_Reader? Form_Reader = null;
        public static Form_EPCC1G26C? Form_6C = null;
        public static bool SuccessStatus = false;

        public static string results_read = "";

        public static void DoSerialPortLoggerWork(string message, string send_direction)
        {
            if (lbSerialLog == null) return;

            string time_now = DateTime.Now.ToLongTimeString();
            
            lbSerialLog.Invoke(new MethodInvoker(delegate
            {
                lbSerialLog.Items.Add($"[{time_now}][{send_direction}] {message}");
                lbSerialLog.SelectedIndex = lbSerialLog.Items.Count - 1;
            }));

        }
        public static void AddStatusMessage(string message)
        {
            if (lbStatusMessage == null) return;

            string time_now = DateTime.Now.ToLongTimeString();
            lbStatusMessage.Invoke(new MethodInvoker(delegate
            {
                lbStatusMessage.Items.Insert(0, $"[{time_now}] {message}");
            }));
        }
        public static void DoReceiveDataWork(object sender, ReaderService.CombineDataReceiveArgument e)
        {
            string s_crlf = e.Data;
            SuccessStatus = true;
            switch (DoProcess)
            {
                case CommandStates.EPC:
                    if (s_crlf.IndexOf("U") != -1)
                    {
                        //OnB01ButtonReadEPCClick(null, null);
                        break;
                    }
                    IsReceiveDataWork = false;
                    // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //B01TextBoxEPC.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'Q');
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.TID:
                    if (s_crlf.IndexOf("U") != -1)
                    {
                        //OnB01ButtonTIDClick(null, null);
                        break;
                    }
                    IsReceiveDataWork = false;
                    //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    // {
                    //B01TextBoxTID.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                    // });
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
                case CommandStates.MASK:
                    if (s_crlf.IndexOf("T") == -1)
                    {
                        string error_code = ReaderService.DeleteCRLFandHandler(s_crlf, 'T');
                        string error_msg = ReaderService.GetErrorCodeString(error_code);
                        AddStatusMessage($"Error Code: {error_msg}");
                        SuccessStatus = false;
                        IsReceiveDataWork = false;
                        break;
                    }
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.SELECT:
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.PASSWORD:
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.MULTI:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                    }
                    break;
                case CommandStates.READ:
                    if (s_crlf.IndexOf("R") == -1)
                    {
                        string error_code = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                        string error_msg = ReaderService.GetErrorCodeString(error_code);
                        AddStatusMessage($"Error Code: {error_msg}");
                        SuccessStatus = false;
                        IsReceiveDataWork = false;
                        break;
                    }
                    if(FormSharedData.Form_6C != null)
                    {
                        FormSharedData.Form_6C.txtReader_ReadData.Invoke(new MethodInvoker(delegate
                        {
                            FormSharedData.Form_6C.txtReader_ReadData.Text = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                        }));
                    }
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.WRITE:
                    if (s_crlf.IndexOf("W") == -1)
                    {
                        string error_code = ReaderService.DeleteCRLFandHandler(s_crlf, 'W');
                        string error_msg = ReaderService.GetErrorCodeString(error_code);
                        AddStatusMessage($"Error Code: {error_msg}");
                        SuccessStatus = false;
                        IsReceiveDataWork = false;
                        break;
                    }
                    AddStatusMessage($"Write OK!");
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.LOCK:
                    //Parse for failure TODO
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.KILL:
                    //Parse for failure TODO
                    IsReceiveDataWork = false;
                    break;
                case CommandStates.B02_MULTI:
                case CommandStates.B02_MULTI_Q:
                    if (s_crlf.Equals("\nU\r\n") || s_crlf.Equals("\nX\r\n"))
                    {
                        IsReceiveDataWork = false;
                        if (s_crlf.Equals("\nX\r\n"))
                        {
                            // base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                            // {
                            //     ErrorCodeCheck(CommandStates.B02_MULTI_Q, "X");
                            // });
                        }
                    }
                    break;
                case CommandStates.B02_MULTIREAD:
                case CommandStates.B02_MULTIREAD_Q:
                    if (s_crlf.Equals("\nU\r\n") || s_crlf.Equals("\nX\r\n"))
                    {
                        IsReceiveDataWork = false;
                        if (s_crlf.Equals("\nX\r\n"))
                        {
                            //base.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                            // {
                            //     ErrorCodeCheck(CommandStates.B02_MULTIREAD_Q, "X");
                            // });
                        }
                    }
                    break;
                case CommandStates.INV_EPC:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                        string epc = ReaderService.DeleteCRLFandHandler(s_crlf, 'U');
                        AddEPCToUI(epc);
                    }
                    break;
                case CommandStates.INV_TID:
                    if (s_crlf.Equals("\nU\r\n"))
                    {
                        IsReceiveDataWork = false;
                    }
                    else
                    {
                        string tid = ReaderService.DeleteCRLFandHandler(s_crlf, 'R');
                        AddTIDToUI(tid);
                    }
                    break;
                case CommandStates.DEFAULT:
                case CommandStates.INFO:
                    IsReceiveDataWork = false;
                    break;
                default:
                    //DisplayInfoMsg("RX", s_crlf);
                    break;
            }
            ClearMemory();
        }
        public static void AddEPCToUI(string epcString)
        {
            if (epcString == "" || epcString.Length == 1) return;
            if (Form_6C == null) return;

            Form_6C.lvInventoryEPC.Invoke(new MethodInvoker(delegate
            {
                bool is_on_list = false;

                string find_epcString = epcString[..^4]; // Remove CRC
                for (int i = 0; i < Form_6C.lvInventoryEPC.Items.Count; i++)
                {
                    if (find_epcString == Form_6C.lvInventoryEPC.Items[i].SubItems[3].Text)
                    {
                        string strCount = Form_6C.lvInventoryEPC.Items[i].SubItems[5].Text;
                        Form_6C.lvInventoryEPC.Items[i].SubItems[5].Text = (int.Parse(strCount) + 1).ToString();    //Update count
                        Form_6C.lvInventoryEPC.EnsureVisible(i);
                        is_on_list = true;
                    }
                }
                if (!is_on_list)
                {
                    ListViewItem item = Form_6C.lvInventoryEPC.Items.Add((Form_6C.lvInventoryEPC.Items.Count + 1).ToString());

                    string PCString = epcString[..4];
                    string CRCString = epcString.Substring(epcString.Length - 4, 4);
                    item.SubItems.Add(CRCString);                                   // 1 - CRC
                    item.SubItems.Add(PCString);                                    // 2 - PC
                    item.SubItems.Add(epcString[..^4]);                             // 3 - EPC
                    item.SubItems.Add((epcString.Length / 2).ToString());           // 4 - EPC Length
                    item.SubItems.Add("1");                                         // 5 - Count
                    Form_6C.lvInventoryEPC.EnsureVisible(Form_6C.lvInventoryEPC.Items.Count - 1);
                }
            }));
        }
        public static void AddTIDToUI(string tidString)
        {
            if (tidString == "" || tidString.Length == 1) return;
            if (Form_6C == null) return;

            Form_6C.lvInventoryTID.Invoke(new MethodInvoker(delegate
            {
                bool is_on_list = false;

                for (int i = 0; i < Form_6C.lvInventoryTID.Items.Count; i++)
                {
                    if (tidString == Form_6C.lvInventoryTID.Items[i].SubItems[1].Text)
                    {
                        string strCount = Form_6C.lvInventoryTID.Items[i].SubItems[3].Text;
                        Form_6C.lvInventoryTID.Items[i].SubItems[3].Text = (int.Parse(strCount) + 1).ToString();    //Update count
                        Form_6C.lvInventoryTID.EnsureVisible(i);
                        is_on_list = true;
                    }
                }
                if (!is_on_list)
                {
                    ListViewItem item = Form_6C.lvInventoryTID.Items.Add((Form_6C.lvInventoryTID.Items.Count + 1).ToString());

                    item.SubItems.Add(tidString);                               // 1 - TID
                    item.SubItems.Add((tidString.Length / 2).ToString());       // 2 - TID Length
                    item.SubItems.Add("1");                                     // 3 - Count
                    Form_6C.lvInventoryTID.EnsureVisible(Form_6C.lvInventoryTID.Items.Count - 1);
                }
            }));
        }
        public static void DoRawReceiveDataWork(object sender, ReaderService.RawDataReceiveArgument e)
        {
        }

        public static void ClearMemory()
        {
            Process currentProcess = Process.GetCurrentProcess();
            try
            {
                EmptyWorkingSet(currentProcess.Handle);
            }
            catch
            {
            }
        }
    }
}
