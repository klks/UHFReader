using CPH_F206.RfidSDK;
using CPH_F206.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CPH_F206.FormTabs
{
    public partial class M100Window : Form
    {
        private RfidReader reader;
        private MainForm parentWindow;
        private Dictionary<string, TagItem> tagDictionary;
        private RfidWorkParam workParam;
        private RfidTransmissionParam transferParam;
        private RfidAdvanceParam advanceParam;
        private bool initWorkParamFlag;
        private bool initTransParamFlag;
        private bool initAdvanceParamFlag;
        private FileStream record_file_stream;
        private StreamWriter record_writer;
        public byte autoWriteMode;
        public byte autoIncreseFlag;
        private System.Timers.Timer timer = new System.Timers.Timer(800.0);
        private string mWriteFilePath;
        private int mWriteStartLine;
        public int mFileWriteMode;
        //private IWorkbook mFileWorkBook;
        //private IRow mFileRow;
        //private ICell mFileCell;
        //private ISheet mFileSheet;
        private CheckBox[] mFreqBoxs;
        private byte[] mLastWriteData = new byte[128];
        private byte mLastWriteDataLen;
        private byte mDevType;
        private System.Timers.Timer mFileWriteTimer = new System.Timers.Timer(800.0);
        private System.Timers.Timer mAutoAddVerfiyTimer = new System.Timers.Timer(800.0);
        private bool mAutoAddVerfiyFlag;
        private FileStream mFileWriteStream;
        private const byte TAG_DIS_COLUNM_COUNT_INDEX = 0;
        private const byte TAG_DIS_COLUNM_EPC_INDEX = 1;
        private const byte TAG_DIS_COLUNM_TID_INDEX = 2;
        private const byte TAG_DIS_COLUNM_USER_INDEX = 3;
        private const byte TAG_DIS_COLUNM_EXT_INDEX = 4;
        private const byte ADVANCE_FREQ_MAX_COUNT = 64;
        public static byte DEVICE_TYPE_NORMAL = 6;
        public static byte DEVICE_TYPE_GX = 3;
        public static byte DEVICE_TYPE_FDW = 5;

        public M100Window()
        {
            InitializeComponent();
            workParam = new RfidWorkParam();
            transferParam = new RfidTransmissionParam();
            advanceParam = new RfidAdvanceParam();
            tagDictionary = new Dictionary<string, TagItem>();
            tagDictionary.Clear();
            skinWaterTextBox_address.Text = "2";
            skinComboBox_membank.SelectedIndex = 1;
            skinWater_content.Text = "01 02 03 04";
            skinWaterTextBox_length.Text = "2";
            skinWaterTextBox_password.Text = "00 00 00 00";
            textBox_auto_hex_write_text.Text = "E2 01 02 03 04 05 06 07 08 09 0A 0B";
            textBox_auto_wiegand_write_text.Text = "1234";
            timer.Elapsed += HandleWriteTagTimer;
            timer.AutoReset = true;
            timer.Enabled = true;
            mFileWriteTimer.Elapsed += HandleFileWriteTagTimer;
            mFileWriteTimer.AutoReset = true;
            mFileWriteTimer.Enabled = true;
            mFileWriteTimer.Stop();
            mFileWriteMode = 0;
            mAutoAddVerfiyTimer.Elapsed += HandleAutoAddVerfiyTimer;
            mAutoAddVerfiyTimer.AutoReset = true;
            mAutoAddVerfiyTimer.Enabled = true;
            mAutoAddVerfiyTimer.Stop();
            mFreqBoxs = new CheckBox[64];
            for (int i = 0; i < mFreqBoxs.Length; i++)
            {
                mFreqBoxs[i] = new CheckBox();
                mFreqBoxs[i].AutoSize = true;
            }
            FreshFreqCheckBoxs(0);
        }

        public void SaveParam()
        {
            byte b = 0;
            CIniFile.WriteIniKeys("INFO", "WriteHexData", textBox_auto_hex_write_text.Text, parentWindow.sys_init_path);
            CIniFile.WriteIniKeys("INFO", "WriteWiegandData", textBox_auto_wiegand_write_text.Text, parentWindow.sys_init_path);
            if (checkBox_auto_write_flag.Checked)
            {
                b = 1;
            }
            if (checkBox_auto_write_increse.Checked)
            {
                b = (byte)(b | 2u);
            }
            CIniFile.WriteIniKeys("INFO", "WriteAutoInfo", b.ToString(), parentWindow.sys_init_path);
            CIniFile.WriteIniKeys("INFO", "WriteFilePath", textBox_write_file_path.Text, parentWindow.sys_init_path);
            CIniFile.WriteIniKeys("INFO", "WriteFileData", textBox_write_file_data.Text, parentWindow.sys_init_path);
            CIniFile.WriteIniKeys("INFO", "WriteFileStartLine", numericUpDown_write_file_row.Value.ToString(), parentWindow.sys_init_path);
        }

        public void OnClose()
        {
            mFileWriteTimer.Stop();
            timer.Stop();
            if (mFileWriteStream != null)
            {
                mFileWriteStream.Close();
            }
        }

        public void UpdateParam()
        {
            textBox_auto_hex_write_text.Text = CIniFile.ReadIniKeys("INFO", "WriteHexData", parentWindow.sys_init_path);
            textBox_auto_wiegand_write_text.Text = CIniFile.ReadIniKeys("INFO", "WriteWiegandData", parentWindow.sys_init_path);
            try
            {
                string text = CIniFile.ReadIniKeys("INFO", "WriteAutoInfo", parentWindow.sys_init_path);
                if (text.Trim().Length > 0)
                {
                    int num = int.Parse(text);
                    if (((uint)num & (true ? 1u : 0u)) != 0)
                    {
                        checkBox_auto_write_flag.Checked = true;
                    }
                    if (((uint)num & 2u) != 0)
                    {
                        checkBox_auto_write_increse.Checked = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            textBox_write_file_path.Text = CIniFile.ReadIniKeys("INFO", "WriteFilePath", parentWindow.sys_init_path);
            textBox_write_file_data.Text = CIniFile.ReadIniKeys("INFO", "WriteFileData", parentWindow.sys_init_path);
            numericUpDown_write_file_row.Text = CIniFile.ReadIniKeys("INFO", "WriteFileStartLine", parentWindow.sys_init_path);
        }

        public void SetParentWindow(MainForm window)
        {
            parentWindow = window;
            UpdateParam();
        }

        public void SetReader(RfidReader reader)
        {
            this.reader = reader;
        }

        private void skinButton_start_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                ((MainForm)base.Parent.Parent).AddResultItem("Send start inventorying cmd.", MessageType.Normal);
                reader.StartInventory();
            }
        }

        private void skinButton_stop_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                ((MainForm)base.Parent.Parent).AddResultItem("send stop inventory.", MessageType.Normal);
                reader.StopInventory();
            }
        }

        private void skinButton_save_Click(object sender, EventArgs e)
        {
            //string text = null;
            //int num = 0;
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx";
            //saveFileDialog.FilterIndex = 1;
            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            //text = saveFileDialog.FileName;
            //HSSFWorkbook hSSFWorkbook = new HSSFWorkbook();
            //ISheet sheet = hSSFWorkbook.CreateSheet("UHF Data" + $"{DateTime.Now:yyyy-MM-dd}");
            //foreach (ListViewItem item in skinListView_tags.Items)
            //{
            //    if (item.SubItems[1].Text.Trim().Length != 0)
            //    {
            //        sheet.CreateRow(num).CreateCell(0).SetCellValue(item.SubItems[1].Text);
            //        item.SubItems[2].Text.Trim();
            //        num++;
            //    }
            //}
            //sheet.AutoSizeColumn(0);
            //FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write);
            //hSSFWorkbook.Write(fileStream);
            //fileStream.Close();
            //parentWindow.AddResultItem("文件：" + text + " 成功", MessageType.Normal);
        }

        private void DisplayOneTag(string epcStr, string tidStr, string userStr, string ext_msg)
        {
            TagItem value = null;
            try
            {
                if (tidStr.Length != 0)
                {
                    tagDictionary.TryGetValue(tidStr, out value);
                }
                else if (userStr.Length != 0)
                {
                    tagDictionary.TryGetValue(userStr, out value);
                }
                else if (epcStr.Length != 0)
                {
                    tagDictionary.TryGetValue(epcStr, out value);
                }
            }
            catch (ArgumentNullException)
            {
            }
            if (value != null)
            {
                value.mReadTimes++;
                value.viewItem.SubItems[1].Text = epcStr;
                value.viewItem.SubItems[0].Text = value.mReadTimes.ToString();
                value.viewItem.SubItems[2].Text = tidStr;
                value.viewItem.SubItems[3].Text = userStr;
                value.viewItem.SubItems[4].Text = ext_msg;
                return;
            }
            value = new TagItem();
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Text = "1";
            listViewItem.SubItems.Add(epcStr);
            if (tidStr.Length != 0)
            {
                listViewItem.SubItems.Add(tidStr);
            }
            else
            {
                listViewItem.SubItems.Add("");
            }
            if (userStr.Length != 0)
            {
                listViewItem.SubItems.Add(userStr);
            }
            else
            {
                listViewItem.SubItems.Add("");
            }
            if (ext_msg.Length != 0)
            {
                listViewItem.SubItems.Add(ext_msg);
            }
            else
            {
                listViewItem.SubItems.Add("");
            }
            value.viewItem = listViewItem;
            value.mReadTimes = 1;
            skinListView_tags.Items.Add(listViewItem);
            if (tidStr.Length != 0)
            {
                tagDictionary.Add(tidStr, value);
            }
            else if (userStr.Length != 0)
            {
                tagDictionary.Add(userStr, value);
            }
            else if (epcStr.Length != 0)
            {
                tagDictionary.Add(epcStr, value);
            }
            skinLabel_tag_num.Text = tagDictionary.Count.ToString();
        }

        public void InsertTagRecord(RfidReader reader, TlvValueItem[] tlvItems, int tlvCount)
        {
            int num = 0;
            int num2 = 0;
            ushort num3 = 0;
            string text = "";
            string text2 = "";
            string text3 = "";
            float num4 = 0f;
            string text4 = "";
            if (tlvItems == null || tlvItems.Length < tlvCount)
            {
                return;
            }
            for (num = 0; num < tlvCount; num++)
            {
                switch (tlvItems[num]._tlvType)
                {
                    case 1:
                    case 16:
                        for (num2 = 0; num2 < tlvItems[num]._tlvLen; num2++)
                        {
                            text += tlvItems[num]._tlvValue[num2].ToString("X2");
                        }
                        break;
                    case 5:
                        text4 = text4 + "RSSI=" + tlvItems[num]._tlvValue[0].ToString("X2") + ";";
                        break;
                    case 4:
                        for (num2 = 0; num2 < tlvItems[num]._tlvLen; num2++)
                        {
                            text2 += tlvItems[num]._tlvValue[num2].ToString("X2");
                        }
                        break;
                    case 2:
                        for (num2 = 0; num2 < tlvItems[num]._tlvLen; num2++)
                        {
                            text3 += tlvItems[num]._tlvValue[num2].ToString("X2");
                        }
                        break;
                    case 112:
                        text4 = text4 + "Tempeture" + (float)((tlvItems[num]._tlvValue[0] << 8) + tlvItems[num]._tlvValue[1]) / 10f + " C";
                        break;
                    case 10:
                        text4 = text4 + "ANT=" + tlvItems[num]._tlvValue[0] + ";";
                        break;
                    case 82:
                        text4 = text4 + "Dev No=" + Encoding.Default.GetString(tlvItems[num]._tlvValue) + ";";
                        break;
                    case 6:
                        num3 = tlvItems[num]._tlvValue[0];
                        num3 <<= 8;
                        num3 += tlvItems[num]._tlvValue[1];
                        text4 += $"{num3:4d}/{tlvItems[num]._tlvValue[2]:2d}/{tlvItems[num]._tlvValue[3]:2d} {tlvItems[num]._tlvValue[4]:2d}:{tlvItems[num]._tlvValue[5]:2d}:{tlvItems[num]._tlvValue[6]:2d}";
                        break;
                }
            }
            DisplayOneTag(text, text2, text3, text4);
        }

        public void OnRecvRecordNodtify(RfidReader reader, string time, string tagId)
        {
            if (record_writer != null)
            {
                string value = time + " " + tagId;
                record_writer.WriteLine(value);
                parentWindow.AddResultItem(value, MessageType.Normal);
            }
        }

        public void OnRecvRecordStatusRsp(RfidReader reader, byte status)
        {
            record_writer.Flush();
            record_writer.Close();
            record_writer = null;
            record_file_stream.Close();
            record_file_stream = null;
            parentWindow.AddResultItem("Receive record from reader completed.", MessageType.Normal);
        }

        public void OnRecvSetRtcTimeRsp(RfidReader reader, byte status)
        {
            if (status == 0)
            {
                parentWindow.AddResultItem("Success to set reader's rtc time.", MessageType.Normal);
            }
            else
            {
                parentWindow.AddResultItem("Fail to set reader's rtc time.", MessageType.Error);
            }
        }

        public void OnRecvQueryRtcTimeRsp(int year, int month, int day, int hour, int min, int sec)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("The reader's time: {0}.{1}.{2}  {3}:{4}:{5}", year, month, day, hour, min, sec);
            parentWindow.AddResultItem(stringBuilder.ToString(), MessageType.Normal);
        }

        public void OnRecvQuerySingleParam(TlvValueItem item)
        {
            if (item._tlvType == 4)
            {
                ushort num = 0;
                string text = "";
                num = item._tlvValue[3];
                num <<= 8;
                num += item._tlvValue[4];
                text = "Mixer Gain：" + item._tlvValue[1] + " , IF AMP Gain：" + item._tlvValue[2] + "  , Threshold:" + num.ToString("X4");
                ((MainForm)base.Parent.Parent).AddResultItem(text, MessageType.Normal);
            }
            else if (item._tlvType == 240)
            {
                string text2 = "";
                skinWaterTextBox_dev_num.Text = Encoding.UTF8.GetString(item._tlvValue, 0, item._tlvValue.Length);
                text2 = "The device number found is:" + Encoding.UTF8.GetString(item._tlvValue, 0, item._tlvValue.Length);
                ((MainForm)base.Parent.Parent).AddResultItem(text2, MessageType.Normal);
            }
        }

        public void OnRecvWorkingParamRep(RfidWorkParam newParam)
        {
            initWorkParamFlag = true;
            workParam = newParam;
            skinNumericUpDown_power.Value = workParam.ucRFPower;
            if (workParam.ucInventoryArea < skinComboBox_inventory_area.Items.Count)
            {
                skinComboBox_inventory_area.SelectedIndex = workParam.ucInventoryArea;
            }
            skinWaterTextBox_inventory_address.Text = workParam.ucInventoryAddress.ToString();
            skinWaterTextBox_inventory_length.Text = workParam.ucInventoryLength.ToString();
            skinNumericUpDown_trigger_time.Value = workParam.ucAutoTrigoffTime;
            skinNumericUpDown_work_filter.Value = workParam.ucFilterTime;
            skinNumericUpDown_work_interval.Value = workParam.ucScanInterval;
            if (workParam.ucBeepOnFlag != 0)
            {
                buzzer_check.Checked = true;
            }
            else
            {
                buzzer_check.Checked = false;
            }
            skinWaterTextBox_addr.Text = workParam.usDeviceAddr.ToString();
            if (workParam.ucWorkMode < skinComboBox_work_mode.Items.Count)
            {
                skinComboBox_work_mode.SelectedIndex = workParam.ucWorkMode;
            }
            for (int i = 0; i < 8; i++)
            {
                if ((workParam.usAntennaFlag & (1 << i)) != 0)
                {
                    checkedListBox_work_ant.SetItemChecked(i, value: true);
                }
            }
            if (workParam.ucIsEnableRecord != 0)
            {
                record_check.Checked = true;
            }
            else
            {
                record_check.Checked = false;
            }
        }

        private void skinButton_clear_Click(object sender, EventArgs e)
        {
            tagDictionary.Clear();
            skinListView_tags.Items.Clear();
            skinLabel_tag_num.Text = "000";
        }

        private void skinButton_work_refresh_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryWorkingParam();
            }
        }

        private void skinButton_work_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                return;
            }
            byte result = 0;
            RfidWorkParam rfidWorkParam = new RfidWorkParam();
            rfidWorkParam.ucParamVersion = workParam.ucParamVersion;
            rfidWorkParam.ucRFPower = (byte)skinNumericUpDown_power.Value;
            rfidWorkParam.ucScanInterval = (byte)skinNumericUpDown_work_interval.Value;
            rfidWorkParam.ucAutoTrigoffTime = (byte)skinNumericUpDown_trigger_time.Value;
            rfidWorkParam.ucWorkMode = (byte)skinComboBox_work_mode.SelectedIndex;
            rfidWorkParam.ucFilterTime = (byte)skinNumericUpDown_work_filter.Value;
            rfidWorkParam.usAntennaFlag = 0;
            rfidWorkParam.usDeviceAddr = Convert.ToUInt16(skinWaterTextBox_addr.Text.ToString());
            if (buzzer_check.Checked)
            {
                rfidWorkParam.ucBeepOnFlag = 1;
            }
            else
            {
                rfidWorkParam.ucBeepOnFlag = 0;
            }
            rfidWorkParam.usAntennaFlag = 0;
            for (int i = 0; i < 8; i++)
            {
                if (checkedListBox_work_ant.GetItemChecked(i))
                {
                    rfidWorkParam.usAntennaFlag |= (ushort)(1 << i);
                }
            }
            rfidWorkParam.ucInventoryArea = (byte)skinComboBox_inventory_area.SelectedIndex;
            if (byte.TryParse(skinWaterTextBox_inventory_address.Text, out result))
            {
                rfidWorkParam.ucInventoryAddress = result;
            }
            else
            {
                rfidWorkParam.ucInventoryAddress = 0;
            }
            if (byte.TryParse(skinWaterTextBox_inventory_length.Text, out result))
            {
                rfidWorkParam.ucInventoryLength = result;
            }
            else
            {
                rfidWorkParam.ucInventoryLength = 0;
            }
            if (record_check.Checked)
            {
                rfidWorkParam.ucIsEnableRecord = 1;
            }
            else
            {
                rfidWorkParam.ucIsEnableRecord = 0;
            }
            reader.SetWorkingParam(rfidWorkParam);
        }

        private void skinButton_transfer_query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryTransferParam();
            }
        }

        public void FreshTransmissionParam(RfidTransmissionParam transParam)
        {
            int num = 0;
            initTransParamFlag = true;
            transferParam = transParam;
            if (transferParam.ucTransferLink <= skinComboBox_transfer_mode.Items.Count)
            {
                skinComboBox_transfer_mode.SelectedIndex = transferParam.ucTransferLink;
            }
            FreshProtoOnLinkChanged();
            if (transferParam.ucBaudRate < 5)
            {
                skinComboBox_transfer_baudrate.SelectedIndex = transferParam.ucBaudRate;
            }
            if (transferParam.ucWiegandProtocol < skinComboBox_wiegand_protocl.Items.Count)
            {
                skinComboBox_wiegand_protocl.SelectedIndex = transferParam.ucWiegandProtocol;
            }
            skinWaterTextBox_wiegand_width.Text = transferParam.ucWiegandPulseWidth.ToString();
            skinWaterTextBox_wiegand_prorid.Text = transferParam.ucWiegandPulsePeriod.ToString();
            skinWaterTextBox_wiegand_interval.Text = transferParam.ucWiegandInterval.ToString();
            skinNumericUpDown_wiegand_location.Value = transferParam.ucWiegandPosition;
            if (transferParam.ucWiegandDirection == 0)
            {
                skinComboBox_wiegand_direction.SelectedIndex = 0;
            }
            else
            {
                skinComboBox_wiegand_direction.SelectedIndex = 1;
            }
            string text = "";
            for (num = 0; num < 6; num++)
            {
                text = ((num == 5) ? (text + transferParam.mac_addr[num].ToString("X2")) : (text + transferParam.mac_addr[num].ToString("X2") + ":"));
            }
            skinWaterTextBox_ip_mac.Text = text;
            if (transferParam.config_ip_mode != 0)
            {
                dhcp_check.Checked = true;
            }
            else
            {
                dhcp_check.Checked = false;
            }
            text = "";
            for (num = 0; num < 4; num++)
            {
                text = ((num == 3) ? (text + transferParam.sub_mask_addr[num]) : (text + transferParam.sub_mask_addr[num] + "."));
            }
            skinWaterTextBox_ip_sub_masker.Text = text;
            text = "";
            for (num = 0; num < 4; num++)
            {
                text = ((num == 3) ? (text + transferParam.gateway[num]) : (text + transferParam.gateway[num] + "."));
            }
            skinWaterTextBox_gate_way.Text = text;
            text = "";
            for (num = 0; num < 4; num++)
            {
                text = ((num == 3) ? (text + transferParam.local_ip[num]) : (text + transferParam.local_ip[num] + "."));
            }
            skinWaterTextBox_ip_local.Text = text;
            text = "";
            for (num = 0; num < 4; num++)
            {
                text = ((num == 3) ? (text + transferParam.remote_ip_addr[num]) : (text + transferParam.remote_ip_addr[num] + "."));
            }
            skinWaterTextBox_ip_remote.Text = text;
            if (transferParam.ucTransferProtocol < skinComboBox_sub_protocol.Items.Count)
            {
                skinComboBox_sub_protocol.SelectedIndex = transferParam.ucTransferProtocol;
            }
            skinWaterTextBox_local_port.Text = transferParam.local_port.ToString();
            skinWaterTextBox_remote_port.Text = transferParam.remote_port.ToString();
            skinWaterTextBox_heart_beats.Text = transferParam.heartBeates.ToString();
            skinWaterTextBox_module_sn.Text = new string(transferParam.syris_module_sn);
            skinWaterTextBox_module_id.Text = transferParam.syris_module_id.ToString();
        }

        private void skinButton_transfer_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                return;
            }
            int num = 0;
            RfidTransmissionParam rfidTransmissionParam = new RfidTransmissionParam();
            rfidTransmissionParam.ucTransferLink = (byte)skinComboBox_transfer_mode.SelectedIndex;
            rfidTransmissionParam.ucBaudRate = (byte)skinComboBox_transfer_baudrate.SelectedIndex;
            rfidTransmissionParam.ucTransferProtocol = 0;
            rfidTransmissionParam.ucWiegandProtocol = (byte)skinComboBox_wiegand_protocl.SelectedIndex;
            rfidTransmissionParam.ucWiegandPulseWidth = byte.Parse(skinWaterTextBox_wiegand_width.Text);
            rfidTransmissionParam.ucWiegandPulsePeriod = byte.Parse(skinWaterTextBox_wiegand_prorid.Text);
            rfidTransmissionParam.ucWiegandInterval = byte.Parse(skinWaterTextBox_wiegand_interval.Text);
            rfidTransmissionParam.ucWiegandPosition = (byte)skinNumericUpDown_wiegand_location.Value;
            if (skinComboBox_wiegand_direction.SelectedIndex == 0)
            {
                rfidTransmissionParam.ucWiegandDirection = 0;
            }
            else
            {
                rfidTransmissionParam.ucWiegandDirection = 1;
            }
            string[] array = skinWaterTextBox_ip_mac.Text.Split(':');
            if (array.Length < 6)
            {
                parentWindow.AddResultItem("Please check your MAC address", MessageType.Error);
                return;
            }
            for (num = 0; num < 6; num++)
            {
                rfidTransmissionParam.mac_addr[num] = Convert.ToByte(array[num], 16);
            }
            if (dhcp_check.Checked)
            {
                rfidTransmissionParam.config_ip_mode = 1;
            }
            else
            {
                rfidTransmissionParam.config_ip_mode = 0;
            }
            string[] array2 = skinWaterTextBox_ip_sub_masker.Text.Split('.');
            for (num = 0; num < 4; num++)
            {
                rfidTransmissionParam.sub_mask_addr[num] = Convert.ToByte(array2[num]);
            }
            string[] array3 = skinWaterTextBox_gate_way.Text.Split('.');
            for (num = 0; num < 4; num++)
            {
                rfidTransmissionParam.gateway[num] = Convert.ToByte(array3[num]);
            }
            string[] array4 = skinWaterTextBox_ip_local.Text.Split('.');
            for (num = 0; num < 4; num++)
            {
                rfidTransmissionParam.local_ip[num] = Convert.ToByte(array4[num]);
            }
            string[] array5 = skinWaterTextBox_ip_remote.Text.Split('.');
            for (num = 0; num < 4; num++)
            {
                rfidTransmissionParam.remote_ip_addr[num] = Convert.ToByte(array5[num]);
            }
            rfidTransmissionParam.local_port = Convert.ToUInt16(skinWaterTextBox_local_port.Text);
            rfidTransmissionParam.remote_port = Convert.ToUInt16(skinWaterTextBox_remote_port.Text);
            rfidTransmissionParam.heartBeates = Convert.ToByte(skinWaterTextBox_heart_beats.Text);
            rfidTransmissionParam.ucTransferProtocol = (byte)skinComboBox_sub_protocol.SelectedIndex;
            if (skinWaterTextBox_module_sn.Text.Length != 8)
            {
                parentWindow.AddResultItem("The module sn is error parameter.", MessageType.Error);
                return;
            }
            char[] array6 = skinWaterTextBox_module_sn.Text.Trim().ToArray();
            for (num = 0; num < 8; num++)
            {
                rfidTransmissionParam.syris_module_sn[num] = array6[num];
            }
            if (skinWaterTextBox_module_id.Text.Trim().Length == 0)
            {
                parentWindow.AddResultItem("The module id is error parameter.", MessageType.Error);
                return;
            }
            char[] array7 = skinWaterTextBox_module_id.Text.ToArray();
            rfidTransmissionParam.syris_module_id = array7[0];
            reader.SetTransferParam(rfidTransmissionParam);
        }

        private void skinButton_advance_refresh_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryAdvanceParam();
            }
        }

        private void skinButton_advance_set_Click(object sender, EventArgs e)
        {
            RfidAdvanceParam rfidAdvanceParam = new RfidAdvanceParam();
            rfidAdvanceParam.ucDevType = 0;
            if (reader == null)
            {
                return;
            }
            if (skinComboBox_advan_region.SelectedIndex == skinComboBox_advan_region.Items.Count - 1)
            {
                rfidAdvanceParam.ucRegion = 128;
            }
            else
            {
                rfidAdvanceParam.ucRegion = (byte)skinComboBox_advan_region.SelectedIndex;
            }
            rfidAdvanceParam.ucChannelIndex = byte.Parse(skinWaterTextBox_advan_channel.Text);
            rfidAdvanceParam.ucFreqHoppingFlag = (byte)skinComboBox_advan_hopping.SelectedIndex;
            rfidAdvanceParam.ucCWFlag = (byte)skinComboBox_advan_cw.SelectedIndex;
            rfidAdvanceParam.sel_flag = (byte)skinComboBox_advan_sel.SelectedIndex;
            rfidAdvanceParam.session = (byte)skinComboBox_advan_session.SelectedIndex;
            rfidAdvanceParam.target = (byte)skinComboBox_advan_target.SelectedIndex;
            rfidAdvanceParam.QValue = (byte)skinNumericUpDown_advan_Q.Value;
            rfidAdvanceParam.rssiValue = byte.Parse(textBox_advan_rssi.Text.Trim());
            for (byte b = 0; b < 64; b++)
            {
                if (mFreqBoxs[b].Checked)
                {
                    rfidAdvanceParam.arrFreqs[rfidAdvanceParam.freqsLength] = b;
                    rfidAdvanceParam.freqsLength++;
                }
            }
            reader.SetAdvanceParam(rfidAdvanceParam);
        }

        public void FreshAdvanceParam(RfidAdvanceParam advanceParam)
        {
            this.advanceParam = advanceParam;
            initAdvanceParamFlag = true;
            mDevType = advanceParam.ucDevType;
            if (advanceParam.ucRegion == 128)
            {
                skinComboBox_advan_region.SelectedIndex = skinComboBox_advan_region.Items.Count - 1;
            }
            else
            {
                skinComboBox_advan_region.SelectedIndex = advanceParam.ucRegion;
            }
            skinWaterTextBox_advan_channel.Text = advanceParam.ucChannelIndex.ToString();
            if (advanceParam.ucFreqHoppingFlag != 0)
            {
                skinComboBox_advan_hopping.SelectedIndex = 1;
            }
            else
            {
                skinComboBox_advan_hopping.SelectedIndex = 0;
            }
            if (advanceParam.ucCWFlag != 0)
            {
                skinComboBox_advan_cw.SelectedIndex = 1;
            }
            else
            {
                skinComboBox_advan_cw.SelectedIndex = 0;
            }
            skinComboBox_advan_sel.SelectedIndex = advanceParam.sel_flag;
            if (advanceParam.session < 4)
            {
                skinComboBox_advan_session.SelectedIndex = advanceParam.session;
            }
            if (advanceParam.target == 0)
            {
                skinComboBox_advan_target.SelectedIndex = 0;
            }
            else
            {
                skinComboBox_advan_target.SelectedIndex = 1;
            }
            if (advanceParam.QValue > 15)
            {
                skinNumericUpDown_advan_Q.Value = 0m;
            }
            else
            {
                skinNumericUpDown_advan_Q.Value = advanceParam.QValue;
            }
            textBox_advan_rssi.Text = advanceParam.rssiValue.ToString();
            FreqSetPoints(advanceParam.ucRegion, advanceParam.arrFreqs, advanceParam.freqsLength);
        }

        private void skinButton_defualt_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.SetDefaultParam();
            }
        }

        private void skinButton_once_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.InventoryOnce();
            }
        }

        private void skinButton_reset_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.ResetReader();
            }
        }

        private void tabControl_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reader == null)
            {
                return;
            }
            if (tabControl_function.SelectedIndex == 1)
            {
                if (!initWorkParamFlag)
                {
                    reader.QueryWorkingParam();
                }
            }
            else if (tabControl_function.SelectedIndex == 2)
            {
                if (!initTransParamFlag)
                {
                    reader.QueryTransferParam();
                }
            }
            else if (tabControl_function.SelectedIndex == 3 && !initAdvanceParamFlag)
            {
                reader.QueryAdvanceParam();
            }
        }

        private void skinButton_single_Parameter_Query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QuerySingleParam(4);
            }
        }

        private void skinButton_operation_write_Click(object sender, EventArgs e)
        {
            ushort num = 0;
            string[] array = null;
            string[] array2 = null;
            byte[] array3 = null;
            byte b = 0;
            byte[] array4 = new byte[4];
            byte b2 = 0;
            if (reader == null)
            {
                return;
            }
            try
            {
                num = ushort.Parse(skinWaterTextBox_address.Text);
                array = skinWater_content.Text.Trim().Split(' ');
                array2 = skinWaterTextBox_password.Text.Trim().Split(' ');
                b2 = (byte)skinComboBox_membank.SelectedIndex;
                array3 = new byte[array.Length];
                b = byte.Parse(skinWaterTextBox_length.Text.Trim());
                for (int i = 0; i < array.Length; i++)
                {
                    array3[i] = byte.Parse(array[i], NumberStyles.AllowHexSpecifier);
                }
                if (array2.Length < 4)
                {
                    return;
                }
                for (int j = 0; j < 4; j++)
                {
                    array4[j] = byte.Parse(array2[j], NumberStyles.AllowHexSpecifier);
                }
            }
            catch (Exception ex)
            {
                parentWindow.AddResultItem(ex.ToString(), MessageType.Error);
                return;
            }
            if (array.Length % 2 != 0)
            {
                parentWindow.AddResultItem("the length of you input is error", MessageType.Error);
            }
            else
            {
                reader.WriteTag(b2, num, b, array3, array4);
            }
        }

        private void skinButton_operation_read_Click(object sender, EventArgs e)
        {
            ushort num = 0;
            string[] array = null;
            byte b = 0;
            byte[] array2 = new byte[4];
            byte b2 = 0;
            if (reader == null)
            {
                return;
            }
            try
            {
                num = ushort.Parse(skinWaterTextBox_address.Text);
                array = skinWaterTextBox_password.Text.Trim().Split(' ');
                b2 = (byte)skinComboBox_membank.SelectedIndex;
                b = byte.Parse(skinWaterTextBox_length.Text.Trim());
                if (array.Length < 4)
                {
                    return;
                }
                for (int i = 0; i < 4; i++)
                {
                    array2[i] = byte.Parse(array[i], NumberStyles.AllowHexSpecifier);
                }
            }
            catch (Exception ex)
            {
                parentWindow.AddResultItem(ex.ToString(), MessageType.Error);
                return;
            }
            reader.ReadTag(b2, num, b, array2);
        }

        public void OnOperationResult(string result)
        {
            skinTextBox_opt_result.Text = result;
        }

        private void skinButton_wiegand_write_Click(object sender, EventArgs e)
        {
            uint result = 0u;
            _ = new byte[4];
            if (reader != null)
            {
                if (transferParam != null && transferParam.ucWiegandPosition > 0)
                {
                    _ = (transferParam.ucWiegandPosition - 1) / 2;
                }
                if (!uint.TryParse(skinWaterTextBox_wiegand_write_data.Text, out result))
                {
                    parentWindow.AddResultItem("Wiegand Written Data:" + skinWaterTextBox_wiegand_write_data.Text + "is illegal.", MessageType.Error);
                }
                else
                {
                    reader.WiegandWriteTag(result, null);
                }
            }
        }

        private void skinButton_upload_record_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            DateTime now = DateTime.Now;
            stringBuilder.AppendFormat("{0}_{1}_{2}_{3}_{4}_{5}_record.txt", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            string text = AppDomain.CurrentDomain.BaseDirectory.ToString();
            text += "\\records\\";
            if (reader != null)
            {
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                text += stringBuilder.ToString();
                record_file_stream = File.Open(text, FileMode.OpenOrCreate, FileAccess.Write);
                record_file_stream.Seek(0L, SeekOrigin.Begin);
                record_file_stream.SetLength(0L);
                record_writer = new StreamWriter(record_file_stream);
                reader.UploadRecord();
            }
        }

        private void skinButton_query_time_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryTime();
            }
        }

        private void skinButton_sync_time_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                DateTime now = DateTime.Now;
                reader.SetTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            }
        }

        private void button_ext_fresh_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryExtParam();
            }
        }

        public void OnRecvQueryExtParam(byte result, RfidExtParam ext_param)
        {
            if (result != 0)
            {
                ((MainForm)base.Parent.Parent).AddResultItem("Query extended parameters failed", MessageType.Error);
                return;
            }
            if (((uint)ext_param.ucRelayMode & (true ? 1u : 0u)) != 0)
            {
                checkBox_relay1_auto.Checked = true;
            }
            if ((ext_param.ucRelayMode & 2u) != 0)
            {
                checkBox_relay2_auto.Checked = true;
            }
            textBox_relay_time.Text = ext_param.ucRelayTime.ToString();
            if (ext_param.ucVerifyFlag != 0)
            {
                checkBox_tag_verify.Checked = true;
            }
            else
            {
                checkBox_tag_verify.Checked = false;
            }
            textBox_tag_verify_pwd.Text = ext_param.usVerifyPwd.ToString("X4");
        }

        private void button_relay_set_Click(object sender, EventArgs e)
        {
            if (reader == null)
            {
                return;
            }
            RfidExtParam rfidExtParam = new RfidExtParam();
            if (textBox_tag_verify_pwd.Text.Trim().Length > 4)
            {
                ((MainForm)base.Parent.Parent).AddResultItem("Passwords cannot exceed 4 hexadecimal characters.", MessageType.Error);
                return;
            }
            if (checkBox_relay1_auto.Checked)
            {
                rfidExtParam.ucRelayMode |= 1;
            }
            if (checkBox_relay2_auto.Checked)
            {
                rfidExtParam.ucRelayMode |= 2;
            }
            rfidExtParam.ucRelayTime = byte.Parse(textBox_relay_time.Text.ToString());
            if (checkBox_tag_verify.Checked)
            {
                rfidExtParam.ucVerifyFlag = 1;
            }
            else
            {
                rfidExtParam.ucVerifyFlag = 0;
            }
            rfidExtParam.usVerifyPwd = ushort.Parse(textBox_tag_verify_pwd.Text.ToString(), NumberStyles.AllowHexSpecifier);
            reader.SetExtParam(rfidExtParam);
        }

        private void button_audio_play_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.AudioPlay(textBox_audio_text.Text.Trim());
            }
        }

        private void button_relay_control_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                int selectedIndex = comboBox_op_index.SelectedIndex;
                byte op_time = byte.Parse(textBox_relay_ctrl_time.Text.Trim());
                switch (selectedIndex)
                {
                    case 0:
                        reader.RelayOperation(1, 1, op_time);
                        break;
                    case 1:
                        reader.RelayOperation(1, 0, op_time);
                        break;
                    case 2:
                        reader.RelayOperation(2, 1, op_time);
                        break;
                    case 3:
                        reader.RelayOperation(2, 0, op_time);
                        break;
                    case 4:
                        reader.RelayOperation(3, 1, op_time);
                        break;
                    case 5:
                        reader.RelayOperation(3, 0, op_time);
                        break;
                }
            }
        }

        private void button_audio_set_vol_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.AudioSetOfflineContext(textBox_audio_text.Text.Trim());
            }
        }

        private void skinButton_tag_lock_Click(object sender, EventArgs e)
        {
            byte[] array = new byte[4];
            string[] array2 = null;
            byte membank = (byte)comboBox_lock_type.SelectedIndex;
            array2 = skinWaterTextBox_password.Text.Trim().Split(' ');
            if (reader != null && array2.Length >= 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    array[i] = byte.Parse(array2[i], NumberStyles.AllowHexSpecifier);
                }
                reader.LockTag(membank, array);
            }
        }

        private void skinButton_kill_tag_Click(object sender, EventArgs e)
        {
            byte[] array = new byte[4];
            byte[] array2 = new byte[4];
            string[] array3 = null;
            array3 = skinWaterTextBox_password.Text.Trim().Split(' ');
            if (reader != null && array3.Length >= 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    array[i] = byte.Parse(array3[i], NumberStyles.AllowHexSpecifier);
                    array2[i] = byte.Parse(array3[i], NumberStyles.AllowHexSpecifier);
                }
                reader.KillTag(array, array2);
            }
        }

        private void skinButton_dev_query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QuerySingleParam(240);
            }
        }

        private void skinButton_dev_set_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (skinWaterTextBox_dev_num.Text.Length > 12)
                {
                    ((MainForm)base.Parent.Parent).AddResultItem("The device number you enter cannot exceed 12 digits or letters.", MessageType.Error);
                    return;
                }
                byte[] bytes = Encoding.UTF8.GetBytes(skinWaterTextBox_dev_num.Text.Trim());
                byte[] array = new byte[bytes.Length + 1];
                array[0] = (byte)bytes.Length;
                Array.Copy(bytes, 0, array, 1, bytes.Length);
                reader.SetSingleParam(240, array);
            }
        }

        private void skinButton_tag_verify_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.AddVerifyToTag();
            }
        }

        public void AutoWriteWiegandTag()
        {
            if (reader != null)
            {
                uint result = 0u;
                _ = new byte[4];
                if (!uint.TryParse(textBox_auto_wiegand_write_text.Text, out result))
                {
                    parentWindow.AddResultItem(textBox_auto_wiegand_write_text.Text + "It is an incorrect Wiegand card number.", MessageType.Error);
                }
                else
                {
                    reader.WiegandWriteTag(result, null);
                }
            }
        }

        public void OnRecvAutoWriteRsp(int status)
        {
            uint result = 0u;
            if (status == 0)
            {
                parentWindow.AddResultItem("Data written successfully:" + textBox_auto_wiegand_write_text.Text, MessageType.Normal);
                if (!uint.TryParse(textBox_auto_wiegand_write_text.Text, out result))
                {
                    parentWindow.AddResultItem(textBox_auto_wiegand_write_text.Text + "It is an incorrect Wiegand card number.", MessageType.Error);
                    return;
                }
                result++;
                textBox_auto_wiegand_write_text.Text = result.ToString();
            }
        }

        public byte[] StringToHex(string str, out int hexlen)
        {
            hexlen = 0;
            byte[] array = new byte[str.Length / 2 + 1];
            int num = 0;
            int num2 = 0;
            char[] array2 = str.ToCharArray();
            try
            {
                for (int i = 0; i < array2.Length; i++)
                {
                    if (array2[i] == ' ')
                    {
                        if (num != 0)
                        {
                            return null;
                        }
                        continue;
                    }
                    if (array2[i] >= '0' && array2[i] <= '9')
                    {
                        if (num == 0)
                        {
                            array[num2] = (byte)(array2[i] - 48);
                            num = 1;
                            continue;
                        }
                        array[num2] <<= 4;
                        array[num2] += (byte)(array2[i] - 48);
                        num2++;
                        num = 0;
                        continue;
                    }
                    if (array2[i] >= 'a' && array2[i] <= 'f')
                    {
                        if (num == 0)
                        {
                            array[num2] = (byte)(array2[i] - 97 + 10);
                            num = 1;
                            continue;
                        }
                        array[num2] <<= 4;
                        array[num2] += (byte)(array2[i] - 97 + 10);
                        num2++;
                        num = 0;
                        continue;
                    }
                    if (array2[i] >= 'A' && array2[i] <= 'F')
                    {
                        if (num == 0)
                        {
                            array[num2] = (byte)(array2[i] - 65 + 10);
                            num = 1;
                            continue;
                        }
                        array[num2] <<= 4;
                        array[num2] += (byte)(array2[i] - 65 + 10);
                        num2++;
                        num = 0;
                        continue;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                hexlen = 0;
                return null;
            }
            hexlen = num2;
            return array;
        }

        public void AutoWriteHexTag()
        {
            byte b = 0;
            string[] array = null;
            string[] array2 = null;
            byte[] array3 = null;
            byte b2 = 0;
            byte[] array4 = new byte[4];
            byte b3 = 0;
            if (reader == null)
            {
                return;
            }
            try
            {
                b = 2;
                array = textBox_auto_hex_write_text.Text.Trim().Split(' ');
                array2 = skinWaterTextBox_password.Text.Trim().Split(' ');
                b3 = 1;
                array3 = new byte[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array3[i] = byte.Parse(array[i], NumberStyles.AllowHexSpecifier);
                }
                b2 = (byte)(array.Length / 2);
                if (array2.Length < 4)
                {
                    return;
                }
                for (int j = 0; j < 4; j++)
                {
                    array4[j] = byte.Parse(array2[j], NumberStyles.AllowHexSpecifier);
                }
            }
            catch (Exception ex)
            {
                parentWindow.AddResultItem(ex.ToString(), MessageType.Error);
                return;
            }
            if (array.Length % 2 != 0)
            {
                parentWindow.AddResultItem("The card number to be written must be a multiple of 2, separated by spaces.", MessageType.Error);
            }
            else
            {
                reader.WriteEpc(b3, b, b2, array3, array4);
            }
        }

        public void OnRecvAutoWriteHexTag(int status)
        {
            string[] array = null;
            byte[] array2 = null;
            _ = new byte[4];
            StringBuilder stringBuilder = new StringBuilder();
            parentWindow.AddResultItem("Data written successfully:" + textBox_auto_hex_write_text.Text.Trim(), MessageType.Normal);
            try
            {
                array = textBox_auto_hex_write_text.Text.Trim().Split(' ');
                array2 = new byte[array.Length];
                byte.Parse(skinWaterTextBox_length.Text.Trim());
                for (int i = 0; i < array.Length; i++)
                {
                    array2[i] = byte.Parse(array[i], NumberStyles.AllowHexSpecifier);
                }
                int num = array.Length - 1;
                while (num >= 0)
                {
                    if (array2[num] == byte.MaxValue)
                    {
                        array2[num] = 0;
                        num--;
                        continue;
                    }
                    array2[num]++;
                    break;
                }
                stringBuilder.Clear();
                for (int j = 0; j < array.Length; j++)
                {
                    stringBuilder.Append(array2[j].ToString("X2") + " ");
                }
                textBox_auto_hex_write_text.Text = stringBuilder.ToString().Trim();
            }
            catch (Exception ex)
            {
                parentWindow.AddResultItem(ex.ToString(), MessageType.Error);
            }
        }

        public int GetCurTagPageIndex()
        {
            return tabControl_function.SelectedIndex;
        }

        public void HandleWriteTagTimer(object source, ElapsedEventArgs e)
        {
            if (autoWriteMode == 1)
            {
                AutoWriteHexTag();
            }
            else if (autoWriteMode == 2)
            {
                AutoWriteWiegandTag();
            }
        }

        private void button_auto_write_hex_Click(object sender, EventArgs e)
        {
            if (checkBox_auto_write_increse.Checked)
            {
                autoIncreseFlag = 1;
            }
            else
            {
                autoIncreseFlag = 0;
            }
            if (!checkBox_auto_write_flag.Checked)
            {
                AutoWriteHexTag();
            }
            else if (autoWriteMode == 0)
            {
                autoWriteMode = 1;
                ButtonDisableOnWrite(1);
                button_auto_write_hex.Text = "Stop";
                timer.Start();
            }
            else
            {
                timer.Stop();
                autoWriteMode = 0;
                button_auto_write_hex.Text = "Hex card writing";
                ButtonEnableWrite();
            }
        }

        private void button_auto_write_wiegand_Click(object sender, EventArgs e)
        {
            if (checkBox_auto_write_increse.Checked)
            {
                autoIncreseFlag = 1;
            }
            else
            {
                autoIncreseFlag = 0;
            }
            if (!checkBox_auto_write_flag.Checked)
            {
                AutoWriteWiegandTag();
            }
            else if (autoWriteMode == 0)
            {
                autoWriteMode = 2;
                button_auto_write_hex.Enabled = false;
                checkBox_auto_write_increse.Enabled = false;
                checkBox_auto_write_flag.Enabled = false;
                button_auto_write_wiegand.Text = "Stop";
                ButtonDisableOnWrite(2);
                timer.Start();
            }
            else
            {
                timer.Stop();
                autoWriteMode = 0;
                button_auto_write_wiegand.Text = "Wiegand Card";
                ButtonEnableWrite();
            }
        }

        private void button_usbdata_query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryUsbInfoParam();
            }
        }

        public void OnRecvQueryUsbData(byte interfacetype, byte usbDataProto, byte usbEnterFlag)
        {
            switch (interfacetype)
            {
                case 7:
                    radioButton_USB_HID.Checked = true;
                    break;
                case 8:
                    radioButton_USB_COM.Checked = true;
                    break;
                default:
                    radioButton_USB_HID.Checked = false;
                    radioButton_USB_COM.Checked = false;
                    break;
            }
            if (usbDataProto < comboBox_usbdata_proto.Items.Count)
            {
                comboBox_usbdata_proto.SelectedIndex = usbDataProto;
            }
            else
            {
                comboBox_usbdata_proto.SelectedIndex = -1;
            }
            if (usbEnterFlag != 0)
            {
                checkBox_usbdata_enter_flag.Checked = true;
            }
            else
            {
                checkBox_usbdata_enter_flag.Checked = false;
            }
            parentWindow.AddResultItem("USB parameters successfully queried", MessageType.Normal);
        }

        private void button_usbdata_sset_Click(object sender, EventArgs e)
        {
            byte b = 0;
            byte b2 = 0;
            byte b3 = 0;
            if (reader == null)
            {
                return;
            }
            if (radioButton_USB_COM.Checked)
            {
                b3 = 8;
            }
            else
            {
                if (!radioButton_USB_HID.Checked)
                {
                    return;
                }
                b3 = 7;
            }
            b = (byte)((-1 != comboBox_usbdata_proto.SelectedIndex) ? ((byte)comboBox_usbdata_proto.SelectedIndex) : 0);
            b2 = (byte)(checkBox_usbdata_enter_flag.Checked ? 1 : 0);
            reader.SetUsbInfo(b3, b, b2);
        }

        public void OnRecvQueryDataFlag(ushort dataFlag, byte dataFormat)
        {
            if (((uint)dataFlag & (true ? 1u : 0u)) != 0)
            {
                checkBoxDataFlag_RSSI.Checked = true;
            }
            else
            {
                checkBoxDataFlag_RSSI.Checked = false;
            }
            if ((dataFlag & 2u) != 0)
            {
                checkBoxDataFlag_DevNo.Checked = true;
            }
            else
            {
                checkBoxDataFlag_DevNo.Checked = false;
            }
            if ((dataFlag & 4u) != 0)
            {
                checkBoxDataFlag_ANT.Checked = true;
            }
            else
            {
                checkBoxDataFlag_ANT.Checked = false;
            }
            if ((dataFlag & 8u) != 0)
            {
                checkBox_DataFlag_Enter.Checked = true;
            }
            else
            {
                checkBox_DataFlag_Enter.Checked = false;
            }
            if (dataFormat < comboBox_dataflag_format.Items.Count)
            {
                comboBox_dataflag_format.SelectedIndex = dataFormat;
            }
            else
            {
                comboBox_dataflag_format.SelectedIndex = 0;
            }
            parentWindow.AddResultItem("Successfully queried data parameters", MessageType.Normal);
        }

        private void button_dataflag_query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QUeryDatainfoFlag();
            }
        }

        private void button_dataflag_set_Click(object sender, EventArgs e)
        {
            ushort num = 0;
            byte ddataFormat = 0;
            if (reader != null)
            {
                if (checkBoxDataFlag_RSSI.Checked)
                {
                    num = (ushort)(num | 1u);
                }
                if (checkBoxDataFlag_DevNo.Checked)
                {
                    num = (ushort)(num | 2u);
                }
                if (checkBoxDataFlag_ANT.Checked)
                {
                    num = (ushort)(num | 4u);
                }
                if (checkBox_DataFlag_Enter.Checked)
                {
                    num = (ushort)(num | 8u);
                }
                if (comboBox_dataflag_format.SelectedIndex > 0)
                {
                    ddataFormat = (byte)comboBox_dataflag_format.SelectedIndex;
                }
                reader.SetDataInfoFlag(num, ddataFormat);
            }
        }

        private void button_ext_add_verify_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.AddVerifyToTag();
            }
        }

        public void HandleAutoAddVerfiyTimer(object source, ElapsedEventArgs e)
        {
            if (reader != null)
            {
                reader.AddVerifyToTag();
            }
        }

        private void button_ext_auto_verify_Click(object sender, EventArgs e)
        {
            if (!mAutoAddVerfiyFlag)
            {
                button_ext_auto_add_verify.Text = "Stop verification";
                mAutoAddVerfiyTimer.Start();
                mAutoAddVerfiyFlag = true;
            }
            else
            {
                button_ext_auto_add_verify.Text = "Automatic verification";
                mAutoAddVerfiyTimer.Stop();
                mAutoAddVerfiyFlag = false;
            }
        }

        private void button_ex_modbus_query_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.QueryModebusParam();
            }
        }

        public void OnRecvQueryModbusParam(byte tagNum, byte unionSize, byte startAddr, byte clearFlag, int modbusproto)
        {
            numericUpDown_ex_modbus_tag_num.Value = tagNum;
            numericUpDown_ex_modbus_union_size.Value = unionSize;
            numericUpDown_ex_modbus_startaddr.Value = startAddr;
            if (clearFlag != 0)
            {
                checkBox_ex_modbus_clear_flag.Checked = true;
            }
            else
            {
                checkBox_ex_modbus_clear_flag.Checked = false;
            }
            if (modbusproto >= 0)
            {
                comboBox_ex_modbus_proto.SelectedIndex = modbusproto;
            }
            else
            {
                comboBox_ex_modbus_proto.SelectedIndex = -1;
            }
            parentWindow.AddResultItem("Successfully queried Modbus parameters", MessageType.Normal);
        }

        private void button_ex_modbus_set_Click(object sender, EventArgs e)
        {
            byte b = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte b4 = 0;
            int num = 0;
            b = (byte)numericUpDown_ex_modbus_tag_num.Value;
            b2 = (byte)numericUpDown_ex_modbus_union_size.Value;
            b3 = (byte)numericUpDown_ex_modbus_startaddr.Value;
            if (reader != null)
            {
                b4 = (byte)(checkBox_ex_modbus_clear_flag.Checked ? 1 : 0);
                num = comboBox_ex_modbus_proto.SelectedIndex;
                if (num == -1)
                {
                    parentWindow.AddResultItem("Please select the Modbus protocol format.", MessageType.Error);
                }
                else
                {
                    reader.SetModbusParam(b, b2, b3, b4, (byte)num);
                }
            }
        }

        private void FreshProtoOnLinkChanged()
        {
            skinComboBox_sub_protocol.Items.Clear();
            switch (skinComboBox_transfer_mode.SelectedIndex)
            {
                case 0:
                    skinComboBox_sub_protocol.Items.Add("Normal(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 1:
                    skinComboBox_sub_protocol.Items.Add("Wiegand(Deault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 2:
                    skinComboBox_sub_protocol.Items.Add("TCP Server");
                    skinComboBox_sub_protocol.Items.Add("TCP Client");
                    skinComboBox_sub_protocol.Items.Add("UDP");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 3:
                    skinComboBox_sub_protocol.Items.Add("Syris485(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 4:
                    skinComboBox_sub_protocol.Items.Add("TCP Client");
                    skinComboBox_sub_protocol.Items.Add("UDP Client");
                    skinComboBox_sub_protocol.Items.Add("Http");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 5:
                    skinComboBox_sub_protocol.Items.Add("ModbusRtu(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 6:
                    skinComboBox_sub_protocol.Items.Add("ModbusTcp(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 7:
                    skinComboBox_sub_protocol.Items.Add("UsbKeyBoard(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 8:
                    skinComboBox_sub_protocol.Items.Add("USB_CDC(Deafault)");
                    skinComboBox_sub_protocol.SelectedIndex = 0;
                    break;
                case 9:
                    skinComboBox_sub_protocol.Items.Add("TCP Client");
                    skinComboBox_sub_protocol.Items.Add("TCP Server");
                    skinComboBox_sub_protocol.Items.Add("UDP");
                    skinComboBox_sub_protocol.Items.Add("UDP Server");
                    skinComboBox_sub_protocol.Items.Add("HTTP");
                    skinComboBox_sub_protocol.Items.Add("HTTP Server");
                    break;
            }
        }

        private void skinComboBox_transfer_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FreshProtoOnLinkChanged();
        }

        private void button_write_file_choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "excel files (*.xls,*.xlsx)|*.xls;*.xlsx|txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_write_file_path.Text = openFileDialog.FileName.Trim();
                mWriteFilePath = textBox_write_file_path.Text;
                numericUpDown_write_file_row.Value = 1m;
            }
        }

        private void button_write_file_hand_Click(object sender, EventArgs e)
        {
            //mWriteFilePath = textBox_write_file_path.Text.Trim();
            //mWriteStartLine = (int)numericUpDown_write_file_row.Value;
            //if (reader == null)
            //{
            //    return;
            //}
            //if (mWriteFilePath.Length == 0)
            //{
            //    parentWindow.AddResultItem("请选择要加载的写入文件", MessageType.Error);
            //    return;
            //}
            //try
            //{
            //    if (mFileWriteStream != null)
            //    {
            //        mFileWriteStream.Close();
            //        mFileWriteStream = null;
            //    }
            //    mFileWriteStream = new FileStream(mWriteFilePath, FileMode.Open, FileAccess.Read);
            //}
            //catch (Exception)
            //{
            //    parentWindow.AddResultItem("打开文件失败.", MessageType.Error);
            //    return;
            //}
            //string extension = Path.GetExtension(mWriteFilePath);
            //if (extension.Equals(".xls"))
            //{
            //    mFileWorkBook = new HSSFWorkbook(mFileWriteStream);
            //}
            //else if (extension.Equals(".xlsx"))
            //{
            //    mFileWorkBook = new XSSFWorkbook((Stream)mFileWriteStream);
            //}
            //mFileSheet = mFileWorkBook.GetSheetAt(0);
            //mFileWriteMode = 1;
            //mFileWriteTimer.Start();
        }

        private void button_write_file_reload_Click(object sender, EventArgs e)
        {
            //int num = 0;
            //if (textBox_write_file_path.Text.Trim().Length == 0)
            //{
            //    parentWindow.AddResultItem("文件路径为空，不能获取该行数据", MessageType.Error);
            //    return;
            //}
            //mWriteFilePath = textBox_write_file_path.Text.Trim();
            //num = (mWriteStartLine = (int)numericUpDown_write_file_row.Value);
            //try
            //{
            //    FileStream fileStream = new FileStream(mWriteFilePath, FileMode.Open, FileAccess.Read);
            //    string extension = Path.GetExtension(mWriteFilePath);
            //    IWorkbook workbook;
            //    if (extension.Equals(".xls"))
            //    {
            //        workbook = new HSSFWorkbook(fileStream);
            //    }
            //    else
            //    {
            //        if (!extension.Equals(".xlsx"))
            //        {
            //            fileStream.Close();
            //            return;
            //        }
            //        workbook = new XSSFWorkbook((Stream)fileStream);
            //    }
            //    IRow row = workbook.GetSheetAt(0).GetRow(num - 1);
            //    if (row == null)
            //    {
            //        parentWindow.AddResultItem("第" + num + "行不存在，请检查", MessageType.Error);
            //        fileStream.Close();
            //        return;
            //    }
            //    string text = row.GetCell(0).StringCellValue.Trim();
            //    int hexlen = 0;
            //    byte[] array = StringToHex(text, out hexlen);
            //    if (hexlen == 0)
            //    {
            //        parentWindow.AddResultItem("第" + num + "行数据为非法数据，数据内容：" + text, MessageType.Error);
            //        textBox_write_file_data.Text = "";
            //    }
            //    else
            //    {
            //        StringBuilder stringBuilder = new StringBuilder();
            //        for (int i = 0; i < hexlen; i++)
            //        {
            //            stringBuilder.AppendFormat("{0:X2} ", array[i]);
            //        }
            //        textBox_write_file_data.Text = stringBuilder.ToString().Trim();
            //        parentWindow.AddResultItem("读取第" + num + "行数据成功，数据内容：" + stringBuilder.ToString().Trim(), MessageType.Normal);
            //    }
            //    fileStream.Close();
            //}
            //catch (Exception)
            //{
            //    parentWindow.AddResultItem("打开文件失败,请检查文件是否已经被其它程序打开", MessageType.Error);
            //}
        }

        public int ArrayByteCompare(byte[] array1, byte[] array2, int compareLen)
        {
            int result = 0;
            if (array1.Length < compareLen || array2.Length < compareLen)
            {
                return -1;
            }
            for (int i = 0; i < compareLen; i++)
            {
                if (array1[i] != array2[i])
                {
                    return -1;
                }
            }
            return result;
        }

        public void OnRecvIdentify(RfidReader reader, TlvValueItem[] tlvItems, byte tlvCount)
        {
            if (tlvCount != 0)
            {
                if (mLastWriteDataLen == tlvItems[0]._tlvLen && ArrayByteCompare(mLastWriteData, tlvItems[0]._tlvValue, mLastWriteDataLen) == 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < mLastWriteDataLen; i++)
                    {
                        stringBuilder.AppendFormat("{0:X2} ", mLastWriteData[i]);
                    }
                    parentWindow.AddResultItem("This tag [" + stringBuilder.ToString().Trim() + "] Please change the tags as the data was written previously.", MessageType.Error);
                }
                else if (TimerFileWrite() != 0)
                {
                    ButtonEnableWrite();
                    mFileWriteStream.Close();
                    mFileWriteStream = null;
                    mFileWriteTimer.Stop();
                }
            }
            if (mFileWriteMode <= 1)
            {
                if (mFileWriteStream != null)
                {
                    mFileWriteStream.Close();
                    mFileWriteStream = null;
                }
                mFileWriteTimer.Stop();
            }
        }

        public void OnRecvFileWriteEpc(int status)
        {
            //byte[] array = null;
            //int hexlen = 0;
            //parentWindow.AddResultItem("成功写入第" + mWriteStartLine + "行数据[" + textBox_write_file_data.Text.Trim() + "]", MessageType.Normal);
            //while (true)
            //{
            //    mWriteStartLine++;
            //    numericUpDown_write_file_row.Value = mWriteStartLine;
            //    mFileRow = mFileSheet.GetRow(mWriteStartLine - 1);
            //    if (mFileRow == null)
            //    {
            //        parentWindow.AddResultItem("第" + mWriteStartLine + "行在文件中不存在,文件读取结束", MessageType.Normal);
            //        textBox_write_file_data.Text = "";
            //        ButtonEnableWrite();
            //        if (mFileWriteStream != null)
            //        {
            //            mFileWriteStream.Close();
            //            mFileWriteStream = null;
            //        }
            //        mFileWriteTimer.Stop();
            //    }
            //    mFileCell = mFileRow.GetCell(0);
            //    array = StringToHex(mFileCell.StringCellValue.Trim(), out hexlen);
            //    if (hexlen == 0)
            //    {
            //        parentWindow.AddResultItem("第" + mWriteStartLine + "行检测到错误的数据格式[" + mFileCell.StringCellValue.Trim() + "]，切换到第" + (mWriteStartLine + 1) + "行数据", MessageType.Error);
            //        mWriteStartLine++;
            //        continue;
            //    }
            //    if (hexlen % 2 == 0)
            //    {
            //        break;
            //    }
            //    parentWindow.AddResultItem("第" + mWriteStartLine + "行检测到错误的数据格式[" + mFileCell.StringCellValue.Trim() + "]的长度为" + hexlen + "(必须是2的整数倍)切换到第" + (mWriteStartLine + 1) + "行数据", MessageType.Error);
            //    mWriteStartLine++;
            //}
            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 0; i < hexlen; i++)
            //{
            //    stringBuilder.AppendFormat("{0:X2}", array[i]);
            //}
            //textBox_write_file_data.Text = stringBuilder.ToString().Trim();
        }

        public int TimerFileWrite()
        {
            //byte[] array = null;
            //int hexlen = 0;
            //while (true)
            //{
            //    mFileRow = mFileSheet.GetRow(mWriteStartLine - 1);
            //    if (mFileRow == null)
            //    {
            //        parentWindow.AddResultItem("第" + mWriteStartLine + "行在文件中不存在", MessageType.Normal);
            //        return 1;
            //    }
            //    mFileCell = mFileRow.GetCell(0);
            //    array = StringToHex(mFileCell.StringCellValue.Trim(), out hexlen);
            //    if (hexlen == 0)
            //    {
            //        parentWindow.AddResultItem("第" + mWriteStartLine + "行检测到错误的数据格式[" + mFileCell.StringCellValue.Trim() + "]，切换到第" + (mWriteStartLine + 1) + "行数据", MessageType.Error);
            //        mWriteStartLine++;
            //        continue;
            //    }
            //    if (hexlen % 2 == 0)
            //    {
            //        break;
            //    }
            //    parentWindow.AddResultItem("第" + mWriteStartLine + "行检测到错误的数据格式[" + mFileCell.StringCellValue.Trim() + "]的长度为" + hexlen + "(必须是2的整数倍)切换到第" + (mWriteStartLine + 1) + "行数据", MessageType.Error);
            //    mWriteStartLine++;
            //}
            //StringBuilder stringBuilder = new StringBuilder();
            //for (int i = 0; i < hexlen; i++)
            //{
            //    stringBuilder.AppendFormat("{0:X2} ", array[i]);
            //}
            //textBox_write_file_data.Text = stringBuilder.ToString().Trim();
            //if (array != null && hexlen != 0 && hexlen % 2 == 0)
            //{
            //    Array.Copy(array, 0, mLastWriteData, 0, hexlen);
            //    mLastWriteDataLen = (byte)hexlen;
            //    reader.WriteEpc(1, 2, (byte)(hexlen / 2), array, null);
            //    return 0;
            //}
            //parentWindow.AddResultItem("第" + mWriteStartLine + "行检测到错误的数据，停止写卡", MessageType.Error);
            return 1;
        }

        public void HandleFileWriteTagTimer(object source, ElapsedEventArgs e)
        {
            if (reader != null)
            {
                reader.GetEpcData();
            }
        }

        private void ButtonDisableOnWrite(int mode)
        {
            numericUpDown_write_file_row.Enabled = false;
            button_write_file_reload.Enabled = false;
            button_write_file_hand.Enabled = false;
            checkBox_auto_write_increse.Enabled = false;
            checkBox_auto_write_flag.Enabled = false;
            textBox_auto_hex_write_text.Enabled = false;
            textBox_auto_wiegand_write_text.Enabled = false;
            switch (mode)
            {
                case 1:
                    button_auto_write_wiegand.Enabled = false;
                    button_write_file_auto.Enabled = false;
                    break;
                case 2:
                    button_auto_write_hex.Enabled = false;
                    button_write_file_auto.Enabled = false;
                    break;
                case 3:
                    button_auto_write_wiegand.Enabled = false;
                    button_auto_write_hex.Enabled = false;
                    break;
            }
        }

        private void ButtonEnableWrite()
        {
            numericUpDown_write_file_row.Enabled = true;
            button_write_file_reload.Enabled = true;
            button_write_file_hand.Enabled = true;
            button_auto_write_wiegand.Enabled = true;
            button_write_file_auto.Enabled = true;
            button_auto_write_hex.Enabled = true;
            checkBox_auto_write_increse.Enabled = true;
            checkBox_auto_write_flag.Enabled = true;
            textBox_auto_hex_write_text.Enabled = true;
            textBox_auto_wiegand_write_text.Enabled = true;
        }

        private void button_write_file_auto_Click(object sender, EventArgs e)
        {
            //mWriteFilePath = textBox_write_file_path.Text.Trim();
            //mWriteStartLine = (int)numericUpDown_write_file_row.Value;
            //if (reader == null)
            //{
            //    return;
            //}
            //if (mFileWriteMode == 2)
            //{
            //    button_write_file_auto.Text = "自动写卡";
            //    ButtonEnableWrite();
            //    mFileWriteTimer.Stop();
            //    mFileWriteStream.Close();
            //}
            //if (mWriteFilePath.Length == 0)
            //{
            //    parentWindow.AddResultItem("请选择要加载的写入文件", MessageType.Error);
            //    return;
            //}
            //try
            //{
            //    mFileWriteStream = new FileStream(mWriteFilePath, FileMode.Open, FileAccess.Read);
            //}
            //catch (Exception)
            //{
            //    parentWindow.AddResultItem("打开文件失败.", MessageType.Error);
            //    return;
            //}
            //string extension = Path.GetExtension(mWriteFilePath);
            //if (extension.Equals(".xls"))
            //{
            //    mFileWorkBook = new HSSFWorkbook(mFileWriteStream);
            //}
            //else if (extension.Equals(".xlsx"))
            //{
            //    mFileWorkBook = new XSSFWorkbook((Stream)mFileWriteStream);
            //}
            //mFileSheet = mFileWorkBook.GetSheetAt(0);
            //mFileWriteMode = 2;
            //ButtonDisableOnWrite(3);
            //button_write_file_auto.Text = "停止";
            //mFileWriteTimer.Start();
        }

        private void FreshFreqCheckBoxs(byte regionIndex)
        {
            int num = 0;
            float num2 = 902f;
            float num3 = 0.5f;
            float num4 = 0f;
            float num5 = 0f;
            flowLayoutPanel_advance_freqs.Controls.Clear();
            if (mDevType == DEVICE_TYPE_NORMAL)
            {
                switch (regionIndex)
                {
                    case 0:
                        num2 = 902.125f;
                        num3 = 0.5f;
                        num5 = 927.625f;
                        break;
                    case 1:
                        num2 = 865.125f;
                        num3 = 0.25f;
                        num5 = 867.625f;
                        break;
                    case 2:
                        num2 = 920.125f;
                        num3 = 0.25f;
                        num5 = 924.625f;
                        break;
                    default:
                        return;
                }
            }
            else if (mDevType == DEVICE_TYPE_GX)
            {
                switch (regionIndex)
                {
                    case 0:
                        num2 = 902.75f;
                        num3 = 0.5f;
                        num5 = 927.25f;
                        break;
                    case 1:
                        num2 = 865.7f;
                        num3 = 0.6f;
                        num5 = 868.1f;
                        break;
                    case 2:
                        num2 = 920.625f;
                        num3 = 0.25f;
                        num5 = 924.375f;
                        break;
                    default:
                        return;
                }
            }
            num4 = num2;
            num = 0;
            while (num4 <= num5)
            {
                mFreqBoxs[num].Text = $"{num4:0.000}";
                mFreqBoxs[num].Enabled = true;
                mFreqBoxs[num].Visible = true;
                mFreqBoxs[num].Checked = false;
                flowLayoutPanel_advance_freqs.Controls.Add(mFreqBoxs[num]);
                num4 += num3;
                num++;
            }
            for (; num < mFreqBoxs.Length; num++)
            {
                mFreqBoxs[num].Visible = false;
            }
        }

        private void FreqSetPoints(byte region, byte[] arrPoints, byte pointlength)
        {
            FreshFreqCheckBoxs(region);
            for (int i = 0; i < pointlength; i++)
            {
                if (arrPoints[i] < mFreqBoxs.Length)
                {
                    mFreqBoxs[arrPoints[i]].Checked = true;
                }
            }
        }

        private void skinComboBox_advan_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skinComboBox_advan_region.SelectedIndex == 0)
            {
                FreshFreqCheckBoxs(0);
                return;
            }
            if (skinComboBox_advan_region.SelectedIndex == 1)
            {
                FreshFreqCheckBoxs(1);
                return;
            }
            if (skinComboBox_advan_region.SelectedIndex == 2)
            {
                FreshFreqCheckBoxs(2);
                return;
            }
            if (skinComboBox_advan_region.SelectedIndex == 3)
            {
                FreshFreqCheckBoxs(3);
                return;
            }
            for (int i = 0; i < mFreqBoxs.Length; i++)
            {
                mFreqBoxs[i].Enabled = false;
                mFreqBoxs[i].Visible = false;
            }
        }

        private void skinButton_advance_cancel_select_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mFreqBoxs.Length; i++)
            {
                mFreqBoxs[i].Checked = false;
            }
        }
    }
}
