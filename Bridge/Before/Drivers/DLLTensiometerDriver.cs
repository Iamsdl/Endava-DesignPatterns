using Before.Devices;
using DBModel;
using TensiometerDLL;

namespace Before.Drivers
{
    public class DLLTensiometerDriver(string name) : DllDeviceDriver(name)
    {
        TensDLL tensiometerDLL = new TensDLL();

        public override void InitialiseDevice()
        {
            Console.WriteLine($"Initialised {name}");
        }

        public override bool IsFunctional()
        {
            return true;
        }

        public override List<Measurement> StartMeasurement()
        {
            Console.WriteLine($"Starting BloodPressure Measurement on {Name}");

            tensiometerDLL.PerformMeasurement(out double systolic, out double diastolic);

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

        public override void StopMeasurement()
        {
            Console.WriteLine($"Stopping BloodPressure Measurement on {Name}");
            tensiometerDLL.StopMeasurement();
        }
    }
}
