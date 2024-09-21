using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRottaO.CSharp.CarSimDashboard
{
    public class PortIO
    {
        private String lastSentMessage = "";

        private SerialPort serialPort;

        public Boolean isPortCurrentlyOpen()
        {
            if (serialPort == null)
            {
                return false;
            }

            return serialPort.IsOpen;
        }

        public Boolean tryPortInit(String portName)
        {
            try
            {
                serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = 100,
                    WriteTimeout = 100
                };

                serialPort.Open();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public Tuple<Boolean, String> tryToSendMessage(String message)
        {
            if (serialPort == null || !isPortCurrentlyOpen())
            {
                return new Tuple<Boolean, String>(false, "PORT IS NOT OPEN");
            }

            if (lastSentMessage.Equals(message))
            {
                return new Tuple<Boolean, String>(true, "ALREADY SENT");
            }

            lastSentMessage = message;

            try
            {
                serialPort.Write(message + "\n");

                //Console.Write(message + "\n");

                // For debug purposes you can read the response from the uC and print it
                //string response = serialPort.ReadLine(); // This will block until a newline character is received
                //Console.WriteLine("Received: " + response);

                return new Tuple<Boolean, String>(true, "SENT OK");
            }
            catch (Exception ex)
            {
                return new Tuple<Boolean, String>(false, ex.ToString());
            }
        }

        public Boolean tryClosePort()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
                return true;
            }
            return false;
        }
    }
}