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

        public Boolean isPortCurrentlyOpen() {

            if (serialPort == null) {
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

        public Tuple<Boolean,String> serialSendSuccess(int rpm, int speed, int gas, int gear)
        {
            if (serialPort ==null)
            {
                return new Tuple<Boolean, String>(false, "PORT IS NOT OPEN");
            }

            string message = $"#{rpm:D3},{speed:D3},{gas:D3},{gear:D1}$";

            if (message.Equals(lastSentMessage))
            {
                return new Tuple<Boolean, String>(true, "ALREADY SENT");
            }

            lastSentMessage = message;

            try
            {
                serialPort.Write(message + "\n");
                return new Tuple<Boolean, String>(true, "SENT OK");
            }
            catch (Exception ex)
            {
                tryClosePort();             
                return new Tuple<Boolean, String>(false, ex.ToString());
            }

            // For debug purposes read the response from the serial port and print it
            //string response = serialPort.ReadLine(); // This will block until a newline character is received
            //Console.WriteLine("Received: " + response);
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