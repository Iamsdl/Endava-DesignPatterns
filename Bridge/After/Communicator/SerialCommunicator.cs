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

        public byte[]? SendCommand(byte[] command)
        {
            try
            {
                serialPort.Open();
                
                Console.WriteLine($"Sending command: {BitConverter.ToString(command)}");
                serialPort.Write(command, 0, command.Length);

                var response = new byte[64];
                //var bytesRead = serialPort.Read(buffer, 0, buffer.Length);

                serialPort.Close();

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
