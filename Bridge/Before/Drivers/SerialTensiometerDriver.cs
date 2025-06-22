using Bridge.Before.Devices;
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
        public const string StartMeasurementCommand = "0x00 0x01 0x020";
        public const string StopMeasurementCommand = "0x00 0x01 0x021";

        public override void InitialiseDevice()
        {
            Console.WriteLine($"Initialised {this.Name} on port {port}");
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {this.Name}");

            serialPort.Open();
            serialPort.WriteLine(StartMeasurementCommand);

            //var result = serialPort.ReadLine();

            serialPort.Close();

            //interpret result from serialPort

            return new List<Measurement>()
            {
                new Measurement()
                {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Systolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = 121,
                    Unit = "mmHG"
                },
                new Measurement()
                {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Diastolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = 81,
                    Unit = "mmHG"
                }
            };
        }

        public override void StopMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {this.Name}");

            serialPort.Open();
            serialPort.WriteLine(StartMeasurementCommand);

            //var result = serialPort.ReadLine();

            serialPort.Close();
        }
    }
}