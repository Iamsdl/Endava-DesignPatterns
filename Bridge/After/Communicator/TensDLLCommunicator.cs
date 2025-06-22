using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TensiometerDLL;

namespace After.Communicator
{
    /// <summary>
    /// Honestly it's more like an adapter for the TensiometerDLL than just a "communicator".
    /// </summary>
    public class DLLCommunicator : IDeviceCommunicator
    {
        private readonly TensDLL tensiometerDLL = new();

        public void Initialise()
        {
            Console.WriteLine("Initialised DLLCommunicator");
        }

        public bool IsFunctional() => true;

        public string SendCommand(string command)
        {
            // simulate DLL command routing
            tensiometerDLL.PerformMeasurement(out double sys, out double dia);
            return $"{sys}:{dia}";
        }
    }

}
