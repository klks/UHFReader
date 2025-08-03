using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCchip.Reader.API;
using Utilities;

namespace ES_F3105U
{

    public partial class MainForm : Form
    {
        //Global variables
        UCchipClient? readerClient = null;
        ErrorCode status;
        int minCooldown = 500;

        public MainForm()
        {
            InitializeComponent();
            Init_ReaderUI();
            Init_6CUI();
        }
        private async Task<ErrorCode> WaitForFlag(Ref<bool> flagName, int timeout = 5000)
        {
            int waited = 0;
            while (flagName.Value == false)
            {
                await Task.Delay(10);
                waited += 10;
                if (waited > timeout)
                {
                    AddListBoxResponse($"WaitForFlag({flagName.FlagName}) -> Timeout");
                    return ErrorCode.Timeout;
                }
            }
            return ErrorCode.OK;
        }

        private void filterOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_KeyPress(sender, e);
        }

        private void filterOnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities.Utilities.filterOnlyDigits_KeyPress(sender, e);
        }

        private void filterOnlyHex_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyHex_TextChanged(sender, e);
        }

        private void filterOnlyDigits_TextChanged(object sender, EventArgs e)
        {
            Utilities.Utilities.filterOnlyDigits_TextChanged(sender, e);
        }

        private byte[] HexStringToByteArray(string? s)
        {
            if (s == null || s == "")
                return [];

            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (readerClient != null)
                readerClient.Dispose();
            readerClient = null;
        }

    }
}
