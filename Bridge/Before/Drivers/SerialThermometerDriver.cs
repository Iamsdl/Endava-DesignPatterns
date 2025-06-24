using Bridge.Before.Devices;
using DBModel;
using System;
using System.Collections.Generic;

namespace Before.Devices
{
    public class SerialThermometerDriver(string name, string port) : SerialDeviceDriver(name, port)
    {
        public static readonly byte[] StartMeasurementCommand = [0x01, 0x02, 0x020];
        public static readonly byte[] StopMeasurementCommand = [0x01, 0x02, 0x021];

        public override void InitialiseDevice()
        {
            Console.WriteLine($"Initialised {this.Name} on port {port}");
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting Temperature Measurement on {this.Name}");

            serialPort.Open();
            Console.WriteLine($"Sending command: {BitConverter.ToString(StartMeasurementCommand)}");
            serialPort.Write(StartMeasurementCommand, 0, StartMeasurementCommand.Length);

            //var buffer = new byte[64];
            //var bytesRead = serialPort.Read(buffer, 0, buffer.Length);

            serialPort.Close();

            //interpret result from serialPort
            double temperature = 37.2;

            return new List<Measurement>()
            {
                new Measurement()
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
            Console.WriteLine($"Stopping Temperature Measurement on {this.Name}");

            serialPort.Open();
            Console.WriteLine($"Sending command: {BitConverter.ToString(StopMeasurementCommand)}");
            serialPort.Write(StopMeasurementCommand, 0, StopMeasurementCommand.Length);

            //var buffer = new byte[64];
            //var bytesRead = serialPort.Read(buffer, 0, buffer.Length);

            serialPort.Close();
        }
    }
}