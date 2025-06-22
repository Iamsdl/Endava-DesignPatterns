using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensiometerDLL;

namespace After.Communicator
{
    public class DLLCommunicator : IDeviceCommunicator
    {
        private readonly TensDLL tensiometerDLL = new();

        public void Initialise()
        {
            Console.WriteLine("Initialised DLLCommunicator");
        }

        public bool IsFunctional() => true;

        public string SendCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.Start:
                    tensiometerDLL.PerformMeasurement(out double sys, out double dia);
                    return $"{sys}:{dia}";
                case DeviceCommand.Stop:
                    tensiometerDLL.StopMeasurement();
                    return "ok";
                default:
                    return "ok";
            }
        }
    }

}
