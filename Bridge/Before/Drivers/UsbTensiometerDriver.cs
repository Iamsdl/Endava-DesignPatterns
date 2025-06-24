using System;
using System.Collections.Generic;
using DBModel;
using LibUsbDotNet;
using LibUsbDotNet.Main;

namespace Before.Drivers
{
    public class UsbTensiometerDriver(string name, int vendorId, int productId) : UsbDeviceDriver(name, vendorId, productId)
    {
        public static readonly byte[] StartMeasurementCommand = [0x01, 0x01, 0x020];
        public static readonly byte[] StopMeasurementCommand = [0x01, 0x01, 0x021];

        public override void InitialiseDevice()
        {
            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            Console.WriteLine($"Initialised {Name} (USB VID: {deviceFinder.Vid:X4}, PID: {deviceFinder.Pid:X4})");
            usbDevice?.Close();
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {Name}");

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
            double systolic = 121;
            double diastolic = 81;

            return new List<Measurement>
            {
                new Measurement
                {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Systolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = systolic,
                    Unit = "mmHG"
                },
                new Measurement
                {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Diastolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = diastolic,
                    Unit = "mmHG"
                }
            };
        }

        public override void CancelMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {Name}");

            usbDevice = UsbDevice.OpenUsbDevice(deviceFinder);
            if (usbDevice == null)
                return;

            var writer = usbDevice.OpenEndpointWriter(WriteEndpointID.Ep01);
            writer.Write(StopMeasurementCommand, 1000, out _);

            usbDevice.Close();
        }
    }
}