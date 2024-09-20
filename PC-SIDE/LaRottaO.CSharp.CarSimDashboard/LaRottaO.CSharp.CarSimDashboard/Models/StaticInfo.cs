using System.Runtime.InteropServices;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StaticInfo
    {
        public float MaxTorque;
        public float MaxPower;
        public int MaxRpm;
        public float MaxFuel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionMaxTravel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreRadius;
    }
}