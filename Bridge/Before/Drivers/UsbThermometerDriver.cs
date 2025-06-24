using System;
using System.Collections.Generic;
using DBModel;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace Before.Drivers
{
    public class UsbThermometerDriver(string name, int vendorId, int productId) : UsbDeviceDriver(name, vendorId, productId)
    {
        public static readonly byte[] StartMeasurementCommand = [0x01, 0x02, 0x020];
        public static readonly byte[] StopMeasurementCommand = [0x01, 0x02, 0x021];

        public override void InitialiseDevice()
        {
            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            Console.WriteLine($"Initialised {Name} (USB VID: {deviceFinder.Vid:X4}, PID: {deviceFinder.Pid:X4})");
            usbDevice?.Close();
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting Temperature Measurement on {Name}");

            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            //if (usbDevice == null)
            //    throw new Exception("USB device not found.");

            // Example: send start command and read response
            //var writer = usbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            //var reader = usbDevice.OpenEndpointReader(ReadEndpointID.Ep01);

            // Send start command
            Console.WriteLine($"Sending command: {BitConverter.ToString(StartMeasurementCommand)}");
            //writer.Write(StartMeasurementCommand, 1000, out _);

            // Read response
            //byte[] response = new byte[64]; // Adjust size as needed
            //reader.Read(response, 1000, out int bytesRead);

            //usbDevice.Close();

            //parse response
            double temperature = 37.5;

            return new List<Measurement>
            {
                new Measurement
                {
                    MeasurementCategory = MeasurementCategoryEnum.Temperature,
                    MeasurementType = MeasurementTypeEnum.None,
                    MeasurementSide = MeasurementSideEnum.None,
                    Value = temperature,
                    Unit = "°C"
                }
            };
        }

        public override void CancelMeasurement()
        {
            Console.WriteLine($"Stopping Temperature Measurement on {Name}");

            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            if (usbDevice == null)
                return;

            var writer = usbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            writer.Write(StopMeasurementCommand, 1000, out _);

            usbDevice.Close();
        }
    }
}