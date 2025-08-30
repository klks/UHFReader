using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJYZN_105
{
    public static class FormSharedData
    {
        public static byte fComAdr = 0xff; //当前操作的ComAdr
        public static int ferrorcode;
        public static byte fBaud;
        public static double fdminfre;
        public static double fdmaxfre;
        public static byte Maskadr;
        public static byte MaskLen;
        public static byte MaskFlag;
        public static int fCmdRet = 30; //所有执行指令的返回值
        public static int fOpenComIndex; //打开的串口索引号
        public static bool fIsInventoryScan;
        public static bool fisinventoryscan_6B;

        public static bool bIsInventoryRunning_6C = false;
        public static bool bIsInventoryRunning_6B = false;
        public static bool bIsReadInventoryRunning = false;

        public static byte[] fOperEPC = new byte[36];
        public static byte[] fPassWord = new byte[4];
        public static byte[] fOperID_6B = new byte[8];
        public static int CardNum1 = 0;
        public static ArrayList list = new ArrayList();
        public static bool fTimer_6B_ReadWrite;
        public static string fInventory_EPC_List = ""; //Store the query list (if the read data does not change, it will not be refreshed)
        public static int frmcomportindex;
        public static bool ComOpen = false;
        public static string strDefaultKey = "00000000";
        public static MainForm? MainForm = null; //Main form
        public static Form_Reader? Form_Reader = null; //Reader form
        public static Form_EPCC1G26C? Form_6C = null; //Reader form
        public static Form_6B? Form_6B = null; //Reader form for 6B
        public static Form_Duplicate? Form_Duplicate = null; //Duplicate form

        public static System.Windows.Forms.ToolStripStatusLabel? tss_Status = null;

        public static bool IsReadyForRead()
        {
            if (ComOpen == false) return false;
            if (bIsInventoryRunning_6C == true)
            {
                MessageBox.Show("Please stop 6C inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (bIsInventoryRunning_6B == true)
            {
                MessageBox.Show("Please stop 6B inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsReadyForInventory6C()
        {
            if (ComOpen == false) return false;

            if (bIsInventoryRunning_6B == true)
            {
                MessageBox.Show("Please stop 6B inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (bIsReadInventoryRunning == true)
            {
                MessageBox.Show("Please stop read first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsReadyForInventory6B()
        {
            if (ComOpen == false) return false;

            if (bIsInventoryRunning_6C == true)
            {
                MessageBox.Show("Please stop 6C inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (bIsReadInventoryRunning == true)
            {
                MessageBox.Show("Please stop read first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsReady()
        {
            if (ComOpen == false) return false;
            if (bIsInventoryRunning_6C == true)
            {
                MessageBox.Show("Please stop 6C inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (bIsInventoryRunning_6B == true)
            {
                MessageBox.Show("Please stop 6B inventory first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (bIsReadInventoryRunning == true)
            {
                MessageBox.Show("Please stop read first before proceeding", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
