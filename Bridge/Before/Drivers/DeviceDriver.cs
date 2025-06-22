using DBModel;
using System.Diagnostics.Metrics;

namespace Before.Drivers
{
    public abstract class DeviceDriver(string name)
    {
        public string Name { get; } = name;

        public virtual void InitialiseDevice()
        {
            Console.WriteLine($"Initialised {name}");
        }

        public abstract bool IsFunctional();

        public abstract List<Measurement> StartMeasurement();

        public abstract void StopMeasurement();
    }
}