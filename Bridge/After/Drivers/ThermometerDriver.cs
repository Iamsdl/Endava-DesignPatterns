using After.Communicator;
using DBModel;
using System;
using System.Collections.Generic;

namespace After.Drivers
{
    public class ThermometerDriver(string name, IDeviceCommunicator communicator)
        : DeviceDriver(name, communicator)
    {
        private static readonly byte[] StartMeasurementCommand = [0x01, 0x02, 0x020];
        private static readonly byte[] CancelMeasurementCommand = [0x01, 0x02, 0x021];

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting Temperature Measurement on {this.Name}");

            byte[] result = Communicator.SendCommand(StartMeasurementCommand);

            // interpret result from communicator
            double temperature = 37.2;

            return
            [
                new()
                {
                    MeasurementCategory = MeasurementCategoryEnum.Temperature,
                    MeasurementType = MeasurementTypeEnum.None,
                    MeasurementSide = MeasurementSideEnum.None,
                    Value = temperature,
                    Unit = "°C"
                }
            ];
        }

        public override void CancelMeasurement()
        {
            Console.WriteLine($"Stopping Temperature Measurement on {this.Name}");
            Communicator.SendCommand(CancelMeasurementCommand);
        }
    }
}