using System;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace Before.Drivers
{
    public abstract class UsbDeviceDriver(string name, int vendorId, int productId) : DeviceDriver(name)
    {
        protected UsbDevice? usbDevice;
        protected UsbDeviceFinder deviceFinder = new UsbDeviceFinder(vendorId, productId);

        public override bool IsFunctional()
        {
            try
            {
                usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
                //if (usbDevice == null)
                //    return false;

                //// send a test command or check device state here
                //var writer = usbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
                //var reader = usbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
                //writer.Write(new byte[] { 0x00 }, 1000, out _);

                //usbDevice.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}