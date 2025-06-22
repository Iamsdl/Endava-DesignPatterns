using After.Communicator;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Drivers
{
    public abstract class DeviceDriver(string name, IDeviceCommunicator communicator)
    {
        public string Name { get; } = name;
        protected IDeviceCommunicator Communicator { get; } = communicator;

        public virtual void InitialiseDevice() => Communicator.Initialise();
        public virtual bool IsFunctional() => Communicator.IsFunctional();

        public abstract List<Measurement> StartMeasurement();

        public abstract void StopMeasurement();
    }

}
