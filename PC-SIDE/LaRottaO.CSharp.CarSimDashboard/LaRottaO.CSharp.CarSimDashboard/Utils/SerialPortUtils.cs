using System;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace LaRottaO.CSharp.CarSimDashboard
{
    internal static class SerialPortUtils
    {
        // Method to populate ComboBox with COM ports and device names
        public static void populateComPortsWithDeviceNames(ComboBox comboBoxComPorts)
        {
            // Get the list of COM port names
            string[] ports = SerialPort.GetPortNames();

            // Clear existing items (if any)
            comboBoxComPorts.Items.Clear();

            // Add COM ports and device names to the ComboBox
            foreach (string port in ports)
            {
                string deviceName = getDeviceName(port);
                comboBoxComPorts.Items.Add($"{port.ToUpper()} | {deviceName}");
            }

            // Optionally select the first available port
            if (comboBoxComPorts.Items.Count > 0)
            {
                comboBoxComPorts.SelectedIndex = 0;
            }
        }

        // Method to get the device name associated with a COM port using WMI
        private static string getDeviceName(string portName)
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
                {
                    foreach (ManagementObject obj in searcher.Get().OfType<ManagementObject>())
                    {
                        string caption = obj["Caption"]?.ToString();
                        if (caption != null && caption.Contains(portName))
                        {
                            return caption;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving device name: {ex.Message}");
            }

            // Return "Unknown device" if no name is found
            return "Unknown device";
        }
    }
}