using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.CarSimDashboard.Usb.Models
{
    internal class ConnectedDevice
    {
        public String port { get; set; }
        public String description { get; set; }

        public ConnectedDevice(string port, string description)
        {
            this.port=port;
            this.description=description;
        }
    }
}