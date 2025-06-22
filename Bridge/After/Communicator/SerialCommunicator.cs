using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace After.Communicator
{
    public class SerialCommunicator(string port) : IDeviceCommunicator
    {
        private const string startBytes = "0x00 0x01 0x020";
        private const string stopBytes = "0x00 0x01 0x021";

        private readonly SerialPort serialPort = new(port);

        public void Initialise()
        {
            Console.WriteLine($"Initialised SerialCommunicator on {port}");
        }

        public bool IsFunctional()
        {
            try
            {
                serialPort.Open();
                serialPort.Write("test bytes");
                var result = "ok"; // simulate serialPort.ReadLine()
                serialPort.Close();
                return result == "ok";
            }
            catch
            {
                return false;
            }
        }

        public string SendCommand(DeviceCommand command)
        {
            try
            {
                string result;
                serialPort.Open();

                switch (command)
                {
                    case DeviceCommand.Start:
                        serialPort.WriteLine(startBytes);
                        result = "121:81";
                        break;
                    case DeviceCommand.Stop:
                        serialPort.WriteLine(stopBytes);
                        result = "ok";
                        break;
                    default:
                        result = "ok";
                        break;
                }

                serialPort.Close();

                return result;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
