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
        private static readonly byte[] StartMeasurementCommand = [0x01, 0x01, 0x020];
        private static readonly byte[] CancelMeasurementCommand = [0x01, 0x01, 0x021];

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {this.Name}");

            byte[] result = Communicator.SendCommand(StartMeasurementCommand);

            // interpret result from communicator
            int systolic = 120;
            int diastolic = 80;

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

        public override void CancelMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {this.Name}");
            Communicator.SendCommand(CancelMeasurementCommand);
        }
    }

}
