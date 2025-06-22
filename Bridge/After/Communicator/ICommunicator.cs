using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Communicator
{
    public interface IDeviceCommunicator
    {
        void Initialise();
        bool IsFunctional();
        string SendCommand(string command);
    }

}
