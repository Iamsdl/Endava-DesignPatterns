using System;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace After.Communicator
{
    public class UsbCommunicator(ushort vendorId, ushort productId) : IDeviceCommunicator
    {
        private readonly UsbDeviceFinder deviceFinder = new(vendorId, productId);
        private UsbDevice? usbDevice;

        public void Initialise()
        {
            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            Console.WriteLine($"Initialised UsbCommunicator (USB VID: {vendorId:X4}, PID: {productId:X4})");
            usbDevice?.Close();
        }

        public bool IsFunctional()
        {
            try
            {
                usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
                //if (usbDevice == null)
                //    return false;

                //// Send test command
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

        public byte[]? SendCommand(byte[] command)
        {
            try
            {
                usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
                //if (usbDevice == null)
                //    return null;

                //var writer = usbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
                //var reader = usbDevice.OpenEndpointReader(ReadEndpointID.Ep01);

                Console.WriteLine($"Sending command: {BitConverter.ToString(command)}");
                //writer.Write(command, 1000, out _);

                byte[] response = new byte[64];
                //reader.Read(response, 1000, out int bytesRead);

                //usbDevice.Close();

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}