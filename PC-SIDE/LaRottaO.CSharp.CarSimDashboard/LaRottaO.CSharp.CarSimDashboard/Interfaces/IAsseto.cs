using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.CarSimDashboard.Interfaces
{
    internal interface IAsseto
    {
        void detectAssetoRunning();

        void getInitialRaceData();

        void getCurrentRaceData();
    }
}