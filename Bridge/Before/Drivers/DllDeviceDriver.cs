using Before.Drivers;
using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Before.Devices
{
    public abstract class DllDeviceDriver(string name) : DeviceDriver(name)
    {
    }
}
