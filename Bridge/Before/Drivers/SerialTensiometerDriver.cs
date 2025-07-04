﻿using Bridge.Before.Devices;
using DBModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Before.Devices
{
    public class SerialTensiometerDriver(string name, string port) : SerialDeviceDriver(name, port)
    {
        public static readonly byte[] StartMeasurementCommand = [0x01, 0x01, 0x020];
        public static readonly byte[] StopMeasurementCommand = [0x01, 0x01, 0x021];

        public override void InitialiseDevice()
        {
            Console.WriteLine($"Initialised {this.Name} on port {port}");
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {this.Name}");

            serialPort.Open();
            Console.WriteLine($"Sending command: {BitConverter.ToString(StartMeasurementCommand)}");
            serialPort.Write(StartMeasurementCommand, 0, StartMeasurementCommand.Length);

            //var buffer = new byte[64];
            //var bytesRead = serialPort.Read(buffer, 0, buffer.Length);

            serialPort.Close();

            //interpret result from serialPort
            int systolic = 120;
            int diastolic = 80;

            return new List<Measurement>()
            {
                new Measurement()
                {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Systolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = systolic,
                    Unit = "mmHG"
                },
                new Measurement()
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
            Console.WriteLine($"Stopping BloodPressure Measurement on {this.Name}");

            serialPort.Open();
            Console.WriteLine($"Sending command: {BitConverter.ToString(StopMeasurementCommand)}");
            serialPort.Write(StopMeasurementCommand, 0, StopMeasurementCommand.Length);

            //var buffer = new byte[64];
            //var bytesRead = serialPort.Read(buffer, 0, buffer.Length);

            serialPort.Close();
        }
    }
}