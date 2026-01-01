using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CPH_F206.RfidSDK
{
    public struct HIDD_ATTRIBUTES
    {
        public int Size;

        public ushort VendorID;

        public ushort ProductID;

        public ushort VersionNumber;
    }

    public struct HIDP_CAPS
    {
        public ushort Usage;

        public ushort UsagePage;

        public ushort InputReportByteLength;

        public ushort OutputReportByteLength;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public ushort[] Reserved;

        public ushort NumberLinkCollectionNodes;

        public ushort NumberInputButtonCaps;

        public ushort NumberInputValueCaps;

        public ushort NumberInputDataIndices;

        public ushort NumberOutputButtonCaps;

        public ushort NumberOutputValueCaps;

        public ushort NumberOutputDataIndices;

        public ushort NumberFeatureButtonCaps;

        public ushort NumberFeatureValueCaps;

        public ushort NumberFeatureDataIndices;
    }

    public enum DIGCF
    {
        DIGCF_DEFAULT = 1,
        DIGCF_PRESENT = 2,
        DIGCF_ALLCLASSES = 4,
        DIGCF_PROFILE = 8,
        DIGCF_DEVICEINTERFACE = 0x10
    }

    public struct SP_DEVICE_INTERFACE_DATA
    {
        public int cbSize;

        public Guid interfaceClassGuid;

        public int flags;

        public int reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SP_DEVINFO_DATA
    {
        public int cbSize = Marshal.SizeOf(typeof(SP_DEVINFO_DATA));

        public Guid classGuid = Guid.Empty;

        public int devInst;

        public int reserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        internal int cbSize;

        internal short devicePath;
    }

    public class report : EventArgs
    {
        public readonly byte reportID;

        public readonly byte[] reportBuff;

        public report(byte id, byte[] arrayBuff)
        {
            reportID = id;
            reportBuff = arrayBuff;
        }
    }

    public class HID
    {
        public enum HID_RETURN
        {
            SUCCESS,
            NO_DEVICE_CONECTED,
            DEVICE_NOT_FIND,
            DEVICE_OPENED,
            WRITE_FAILD,
            READ_FAILD
        }

        public ushort VID = 1155;

        public ushort PID = 22352;

        private nint INVALID_HANDLE_VALUE = new nint(-1);

        private const int MAX_USB_DEVICES = 64;

        private bool deviceOpened;

        private FileStream hidDevice;

        private List<string> deviceList = new List<string>();

        private nint device;

        private bool IsRead = true;

        private int outputReportLength;

        private int inputReportLength;

        private Guid device_class;

        private List<byte[]> buffer = new List<byte[]>();

        public int OutputReportLength => outputReportLength;

        public int InputReportLength => inputReportLength;

        public static Guid HIDGuid
        {
            get
            {
                Guid HidGuid = Guid.Empty;
                HidD_GetHidGuid(ref HidGuid);
                return HidGuid;
            }
        }

        public event EventHandler<report> DataReceived;

        public event EventHandler DeviceArrived;

        public event EventHandler DeviceRemoved;

        [DllImport("hid.dll")]
        private static extern void HidD_GetHidGuid(ref Guid HidGuid);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern nint SetupDiGetClassDevs(ref Guid ClassGuid, uint Enumerator, nint HwndParent, DIGCF Flags);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(nint deviceInfoSet);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        private static extern bool SetupDiEnumDeviceInterfaces(nint deviceInfoSet, nint deviceInfoData, ref Guid interfaceClassGuid, uint memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        private static extern bool SetupDiGetDeviceInterfaceDetail(nint deviceInfoSet, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, nint deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, SP_DEVINFO_DATA deviceInfoData);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetAttributes(nint hidDeviceObject, out HIDD_ATTRIBUTES attributes);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetSerialNumberString(nint hidDeviceObject, nint buffer, int bufferLength);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetPreparsedData(nint hidDeviceObject, out nint PreparsedData);

        [DllImport("hid.dll")]
        private static extern bool HidD_FreePreparsedData(nint PreparsedData);

        [DllImport("hid.dll")]
        private static extern uint HidP_GetCaps(nint PreparsedData, out HIDP_CAPS Capabilities);

        [DllImport("kernel32.dll")]
        private static extern nint CreateFile(string fileName, uint desiredAccess, uint shareMode, uint securityAttributes, uint creationDisposition, uint flagsAndAttributes, uint templateFile);

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(nint hObject);

        [DllImport("Kernel32.dll")]
        private static extern bool ReadFile(nint file, byte[] buffer, uint numberOfBytesToRead, out uint numberOfBytesRead, nint lpOverlapped);

        [DllImport("Kernel32.dll")]
        private static extern bool WriteFile(nint file, byte[] buffer, uint numberOfBytesToWrite, out uint numberOfBytesWritten, nint lpOverlapped);

        [DllImport("User32.dll")]
        private static extern nint RegisterDeviceNotification(nint recipient, nint notificationFilter, int flags);

        [DllImport("user32.dll")]
        private static extern bool UnregisterDeviceNotification(nint handle);

        public HID()
        {
            device_class = HIDGuid;
        }

        public string ListHidDevice(ref int deviceCount)
        {
            string text = "";
            deviceCount = 0;
            deviceList.Clear();
            GetHidDeviceList(ref deviceList);
            for (int i = 0; i < deviceList.Count; i++)
            {
                device = CreateFile(deviceList[i], 3221225472u, 0u, 0u, 3u, 1073741824u, 0u);
                if (device != INVALID_HANDLE_VALUE)
                {
                    HidD_GetAttributes(device, out var attributes);
                    text = text + "VID:" + attributes.VendorID.ToString("X4") + " PID:" + attributes.ProductID.ToString("X4") + "\r\n";
                    deviceCount++;
                    CloseHandle(device);
                }
            }
            if (deviceCount == 0)
            {
                return "Unable to find equipment!";
            }
            return text;
        }

        public HID_RETURN OpenDevice(ushort vID, ushort pID)
        {
            if (!deviceOpened)
            {
                for (int i = 0; i < deviceList.Count; i++)
                {
                    device = CreateFile(deviceList[i], 3221225472u, 0u, 0u, 3u, 1073741824u, 0u);
                    HidD_GetAttributes(device, out var attributes);
                    if (attributes.VendorID == vID && attributes.ProductID == pID)
                    {
                        HidD_GetPreparsedData(device, out var PreparsedData);
                        HidP_GetCaps(PreparsedData, out var Capabilities);
                        HidD_FreePreparsedData(PreparsedData);
                        outputReportLength = Capabilities.OutputReportByteLength;
                        inputReportLength = Capabilities.InputReportByteLength;
                        hidDevice = new FileStream(new SafeFileHandle(device, ownsHandle: false), FileAccess.ReadWrite, inputReportLength, isAsync: true);
                        deviceOpened = true;
                        IsRead = true;
                        BeginAsyncRead();
                        return HID_RETURN.SUCCESS;
                    }
                    CloseHandle(device);
                }
                return HID_RETURN.DEVICE_NOT_FIND;
            }
            return HID_RETURN.DEVICE_OPENED;
        }

        public void StopRead()
        {
            IsRead = false;
        }

        public void StatiRead()
        {
            IsRead = true;
        }

        public void CloseDevice()
        {
            IsRead = false;
            Thread.Sleep(100);
            if (deviceOpened)
            {
                hidDevice.Close();
                deviceOpened = false;
                CloseHandle(device);
            }
        }

        private void BeginAsyncRead()
        {
            byte[] state = new byte[InputReportLength];
            if (IsRead)
            {
                try
                {
                    hidDevice.BeginRead(state, 0, InputReportLength, ReadCompleted, state);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void ReadCompleted(IAsyncResult iResult)
        {
            byte[] array = (byte[])iResult.AsyncState;
            buffer.Add(array);
            if (!IsRead)
            {
                return;
            }
            try
            {
                try
                {
                    hidDevice.EndRead(iResult);
                    byte[] array2 = new byte[array.Length - 1];
                    for (int i = 1; i < array.Length; i++)
                    {
                        array2[i - 1] = array[i];
                    }
                    report e = new report(array[0], array2);
                    OnDataReceived(e);
                }
                finally
                {
                    BeginAsyncRead();
                }
            }
            catch (IOException)
            {
                EventArgs e2 = new EventArgs();
                OnDeviceRemoved(e2);
            }
        }

        protected virtual void OnDataReceived(report e)
        {
            DataReceived?.Invoke(this, e);
        }

        protected virtual void OnDeviceArrived(EventArgs e)
        {
            DeviceArrived?.Invoke(this, e);
        }

        protected virtual void OnDeviceRemoved(EventArgs e)
        {
            DeviceRemoved?.Invoke(this, e);
        }

        public HID_RETURN Write(report r)
        {
            if (deviceOpened)
            {
                try
                {
                    byte[] array = new byte[outputReportLength];
                    array[0] = r.reportID;
                    int num = 0;
                    num = r.reportBuff.Length >= outputReportLength - 1 ? outputReportLength : r.reportBuff.Length;
                    for (int i = 1; i < num; i++)
                    {
                        array[i] = r.reportBuff[i - 1];
                    }
                    hidDevice.Write(array, 0, OutputReportLength);
                    IsRead = true;
                    BeginAsyncRead();
                }
                catch
                {
                    EventArgs e = new EventArgs();
                    OnDeviceRemoved(e);
                    CloseDevice();
                }
            }
            return HID_RETURN.WRITE_FAILD;
        }

        public static void GetHidDeviceList(ref List<string> deviceList)
        {
            Guid HidGuid = Guid.Empty;
            uint num = 0u;
            deviceList.Clear();
            HidD_GetHidGuid(ref HidGuid);
            nint intPtr = SetupDiGetClassDevs(ref HidGuid, 0u, nint.Zero, (DIGCF)18);
            if (intPtr != nint.Zero)
            {
                SP_DEVICE_INTERFACE_DATA deviceInterfaceData = default;
                deviceInterfaceData.cbSize = Marshal.SizeOf(deviceInterfaceData);
                for (num = 0u; num < 64; num++)
                {
                    if (SetupDiEnumDeviceInterfaces(intPtr, nint.Zero, ref HidGuid, num, ref deviceInterfaceData))
                    {
                        int requiredSize = 0;
                        SetupDiGetDeviceInterfaceDetail(intPtr, ref deviceInterfaceData, nint.Zero, requiredSize, ref requiredSize, null);
                        nint intPtr2 = Marshal.AllocHGlobal(requiredSize);
                        SP_DEVICE_INTERFACE_DETAIL_DATA structure = default;
                        structure.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DETAIL_DATA));
                        Marshal.StructureToPtr(structure, intPtr2, fDeleteOld: false);
                        if (SetupDiGetDeviceInterfaceDetail(intPtr, ref deviceInterfaceData, intPtr2, requiredSize, ref requiredSize, null))
                        {
                            deviceList.Add(Marshal.PtrToStringAuto((int)intPtr2 + 4));
                        }
                        Marshal.FreeHGlobal(intPtr2);
                    }
                }
            }
            SetupDiDestroyDeviceInfoList(intPtr);
        }

        public bool CheckDevicePresent(ushort parameterVID, ushort parameterPID)
        {
            VID = parameterVID;
            PID = parameterPID;
            try
            {
                if (OpenDevice(VID, PID) == HID_RETURN.SUCCESS)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ByteToHexString(byte[] bytes)
        {
            string text = string.Empty;
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i].ToString("X2");
                }
            }
            return text;
        }
    }
}
