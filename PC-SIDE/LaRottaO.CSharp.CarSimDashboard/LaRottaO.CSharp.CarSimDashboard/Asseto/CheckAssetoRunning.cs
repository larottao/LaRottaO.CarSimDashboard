using System;
using System.Diagnostics;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    public static class CheckAssetoRunning
    {
        public static Boolean isRunning()
        {
            // Process name to check
            string processName = "acs";

            // Get all processes with the specified name
            Process[] processes = Process.GetProcessesByName(processName);

            // Check if any instances of the process are running
            return (processes.Length > 0);
        }
    }
}