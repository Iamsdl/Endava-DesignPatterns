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
        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {this.Name}");

            var result = Communicator.SendCommand(DeviceCommand.Start);

            // interpret result from communicator
            var parts = result.Split(':');
            if (parts.Length != 2 ||
                !double.TryParse(parts[0], out var systolic) ||
                !double.TryParse(parts[1], out var diastolic))
            {
                throw new Exception("Something went wrong with the measurement");
            }

            return
            [
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
            ];
        }

        public override void StopMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {this.Name}");
            Communicator.SendCommand(DeviceCommand.Stop);
        }
    }

}
