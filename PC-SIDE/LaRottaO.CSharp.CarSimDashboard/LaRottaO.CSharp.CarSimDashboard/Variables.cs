using LRottaO.CSharp.SimDashboardCtrl;
using System.IO.Ports;

namespace LaRottaO.CSharp.CarSimDashboard
{
    public static class Variables
    {
             

        //Values calibrated for my motorcycle dashbord, tune as required

        public static readonly ValuePair[] RealRpmTable =
        {
            new ValuePair(0, 0),
            new ValuePair(500, 11),
            new ValuePair(1000, 20),
            new ValuePair(2000, 35),
            new ValuePair(2000, 38),
            new ValuePair(3000, 52),
            new ValuePair(4000, 69),
            new ValuePair(5000, 85),
            new ValuePair(6000, 101),
            new ValuePair(7000, 117),
            new ValuePair(8000, 134),
            new ValuePair(9000, 152),
            new ValuePair(10000, 168),
            new ValuePair(11000, 185),
            new ValuePair(12000, 202),
            new ValuePair(13000, 220),
            new ValuePair(14000, 237),
            new ValuePair(15000, 255)
        };

        public static ValuePair[] RpmTable10KRedline { get; set; } =
{
            new ValuePair(0, 0),
            new ValuePair(500, 11),
            new ValuePair(1000, 20),
            new ValuePair(2000, 35),
            new ValuePair(2000, 38),
            new ValuePair(3000, 52),
            new ValuePair(6000, 168),
            new ValuePair(7000, 185)
        };

        public static readonly ValuePair[] KphTable =
            {
            new ValuePair(0, 0),
            new ValuePair(5, 1),
            new ValuePair(10, 3),
            new ValuePair(20, 6),
            new ValuePair(30, 9),
            new ValuePair(40, 12),
            new ValuePair(50, 15),
            new ValuePair(60, 18),
            new ValuePair(70, 22),
            new ValuePair(80, 25),
            new ValuePair(90, 29),
            new ValuePair(100, 31),
            new ValuePair(110, 34),
            new ValuePair(120, 37),
            new ValuePair(130, 39),
            new ValuePair(140, 42),
            new ValuePair(150, 45),
            new ValuePair(160, 48),
            new ValuePair(170, 51),
            new ValuePair(180, 54),
            new ValuePair(190, 57),
            new ValuePair(200, 60),
            new ValuePair(210, 63),
            new ValuePair(220, 66),
            new ValuePair(230, 68),
            new ValuePair(240, 71),
            new ValuePair(250, 74),
            new ValuePair(260, 77),
            new ValuePair(270, 80),
            new ValuePair(280, 83),
            new ValuePair(290, 91)
        };

        public const double scalingFactor = 1E47;

    }
}
