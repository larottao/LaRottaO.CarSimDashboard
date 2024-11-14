using LaRottaO.CSharp.CarSimDashboard.Usb.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.CarSimDashboard.Usb
{
    internal static class EnumerateConnectedDevices
    {
        public static (Boolean success, String failureReason, List<ConnectedDevice> connectedDevices) enumerate()
        {
            List<ConnectedDevice> connectedDevicesList = new List<ConnectedDevice>();

            try
            {
                string[] ports = SerialPort.GetPortNames();

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
                {
                    foreach (ManagementObject obj in searcher.Get().OfType<ManagementObject>())
                    {
                        foreach (string port in ports)
                        {
                            string caption = obj["Caption"]?.ToString();
                            if (caption != null && caption.Contains(port))
                            {
                                connectedDevicesList.Add(new ConnectedDevice(port, caption));
                                Console.WriteLine($"Connected USB device: {caption}");
                            }
                        }
                    }
                }

                return (true, "", connectedDevicesList);
            }
            catch (Exception ex)
            {
                return (false, ex.ToString(), new List<ConnectedDevice>());
            }
        }
    }
}