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
            if (!CheckAssetoRunning.isRunning())
            {

                return new Tuple<Boolean, String>(false, "ASSETO RACING WINDOW NOT OPEN");
            }

            telemetry = new AsettoCorsaTelemetry();

            telemetry.initAssetoTelemety();

            if (!telemetry.telemetryConnectedSuccess)
            {

                return new Tuple<Boolean, String>(false, "UNABLE TO CONNECT TO ASSETO TELEMETRY");
            }
                   

            StaticInfo staticInfo = telemetry.ReadStaticInfo();

            int maxPower = Convert.ToInt32(staticInfo.MaxPower * Variables.scalingFactor);

            //Sets the redline of the tacho to match the cars max power
            //All tested models resulted on 7000, no idea why

            Variables.RpmTable10KRedline = new ValuePair[]
           {
                new ValuePair(0, 0),
                new ValuePair(500, 11),
                new ValuePair(1000, 20),
                new ValuePair(2000, 35),
                new ValuePair(2000, 38),
                new ValuePair(3000, 52),
                new ValuePair(maxPower - 1000, 168),
                new ValuePair(maxPower, 185)
           };

            return new Tuple<Boolean, String>(true, "");

        }

    }
}
