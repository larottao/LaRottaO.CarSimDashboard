using LRottaO.CSharp.SimDashboardCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.CarSimDashboard
{
    public static class AssetoIO
    {
        public static AsettoCorsaTelemetry telemetry { get; set; }

        public static Tuple<Boolean, String> tryInitAssetoConnection()
        {
            if (telemetry != null && telemetry.telemetryConnectedSuccess)
            {
                return new Tuple<Boolean, String>(true, "ALREADY DONE");
            }

            telemetry = new AsettoCorsaTelemetry();

            if (!CheckAssetoRunning.isRunning())
            {
                return new Tuple<Boolean, String>(false, "ASSETO RACING WINDOW NOT OPEN");
            }

            if (!telemetry.telemetryConnectedSuccess)
            {
                return new Tuple<Boolean, String>(false, "UNABLE TO CONNECT TO ASSETO TELEMETRY");
            }

            StaticInfo staticInfo = telemetry.ReadStaticInfo();

            return new Tuple<Boolean, String>(true, "");
        }
    }
}