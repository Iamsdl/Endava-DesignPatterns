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

        public string SendCommand(string command)
        {
            serialPort.Open();
            serialPort.WriteLine(command);
            var result = "ok"; // simulate serialPort.ReadLine()
            serialPort.Close();
            return result;
        }
    }

}
