using LaRottaO.CSharp.CarSimDashboard.Usb;
using LaRottaO.CSharp.CarSimDashboard.Usb.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaRottaO.CSharp.CarSimDashboard.Services
{
    internal class UsbService : IUsb
    {
        private String lastSentData = "";

        private String portName;

        private SerialPort serialPort;

        public Boolean isBoardConnected()
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                return false;
            }

            return true;
        }

        public (bool success, string failureReason) connectToBoard()
        {
            if (serialPort != null)
            {
                return (true, "");
            }

            var result = EnumerateConnectedDevices.enumerate();

            if (!result.success)
            {
                return (false, $"Unable to get connected USB devices: {result.failureReason}");
            }

            var connectedBoards = result.connectedDevices.Find(x => x.description.Contains(Constants.BOARD_NAME));

            if (connectedBoards == null)
            {
                return (false, $"Board not detected");
            }

            Console.WriteLine($"Device {Constants.BOARD_NAME} detected on {connectedBoards.port}");

            portName = connectedBoards.port;

            try
            {
                serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = 100,
                    WriteTimeout = 100
                };

                serialPort.Open();

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, $"Unable to open port: {ex.ToString()}");
            }
        }

        public (bool success, string failureReason) sendDataToBoard(string data)
        {
            if (!isBoardConnected())
            {
                return (false, "Unable to send message, port is not open.");
            }

            if (lastSentData.Equals(data))
            {
                return (true, "Unable to send message, already sent.");
            }

            lastSentData = data;

            try
            {
                serialPort.Write(data + "\n");

                Console.Write(data + "\n");

                return (true, "Message sent ok.");
            }
            catch (Exception ex)
            {
                if (!isBoardConnected())
                {
                    return (false, "Unable to send message, port is not open.");
                }

                return (false, $"Unable to send message {ex.ToString()}");
            }
        }

        public (bool succes, string failureReason) disconnectBoard()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            serialPort = null;

            return (true, "");
        }
    }
}