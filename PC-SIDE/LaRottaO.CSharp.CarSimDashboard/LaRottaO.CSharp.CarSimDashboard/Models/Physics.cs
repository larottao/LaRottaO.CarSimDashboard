﻿using System.Runtime.InteropServices;

namespace LRottaO.CSharp.SimDashboardCtrl
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Physics
    {
        public int PacketId;
        public float Gas;
        public float Brake;
        public float Fuel;
        public int Gear;
        public int Rpms;
        public float SteerAngle;
        public float SpeedKmh;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Velocity;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] AccG;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelSlip;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelLoad;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelsPressure;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelAngularSpeed;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreWear;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreDirtyLevel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreCoreTemperature;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] CamberRad;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionTravel;

        public float Drs;
        public float TC;
        public float Heading;
        public float Pitch;
        public float Roll;
        public float CgHeight;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] CarDamage;

        public int NumberOfTyresOut;
        public int PitLimiterOn;
        public float Abs;
        public float KersCharge;
        public float KersInput;
        public int AutoShifterOn;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] RideHeight;

        public float TurboBoost;
        public float Ballast;
        public float AirDensity;
        public float AirTemp;
        public float RoadTemp;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] LocalAngularVelocity;

        public float FinalFF;
        public float PerformanceMeter;
        public int EngineBrake;
        public int ErsRecoveryLevel;
        public int ErsPowerLevel;
        public int ErsHeatCharging;
        public int ErsisCharging;
        public float KersCurrentKJ;
        public int DrsAvailable;
        public int DrsEnabled;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] BrakeTemp;

        public float Clutch;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreTempI;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreTempM;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreTempO;

        public int IsAIControlled;
        public float BrakeBias;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] LocalVelocity;
    }
}