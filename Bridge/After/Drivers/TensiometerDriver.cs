using After.Communicator;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Drivers
{
    public class TensiometerDriver(string name, IDeviceCommunicator communicator)
    : DeviceDriver(name, communicator)
    {
        public const string StartMeasurementCommand = "0x00 0x01 0x020";
        public const string StopMeasurementCommand = "0x00 0x02 0x021";

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {this.Name}");

            var result = Communicator.SendCommand(StartMeasurementCommand);

            // interpret result from communicator
            var parts = result.Split(':');
            if (parts.Length != 2 ||
                !double.TryParse(parts[0], out var systolic) ||
                !double.TryParse(parts[1], out var diastolic))
            {
                systolic = 120; diastolic = 80; // fallback
            }

            return new List<Measurement>
            {
                new() {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Systolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = systolic,
                    Unit = "mmHG"
                },
                new() {
                    MeasurementCategory = MeasurementCategoryEnum.BloodPressure,
                    MeasurementType = MeasurementTypeEnum.Diastolic,
                    MeasurementSide = MeasurementSideEnum.Left,
                    Value = diastolic,
                    Unit = "mmHG"
                }
            };
        }

        public override void StopMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {this.Name}");
            Communicator.SendCommand(StopMeasurementCommand);
        }
    }

}
