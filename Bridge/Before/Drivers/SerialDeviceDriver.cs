using Before.Drivers;
using System.IO.Ports;

namespace Bridge.Before.Devices
{
    public abstract class SerialDeviceDriver(string name, string port) : DeviceDriver(name)
    {
        protected SerialPort serialPort = new SerialPort(port);

        public override bool IsFunctional()
        {
            try
            {
                serialPort.Open();

                serialPort.Write("test bytes");
                //var result = serialPort.ReadLine();
                string result = "ok";

                serialPort.Close();

                return result == "ok";
            }
            catch
            {
                return false;
            }
        }
    }
}