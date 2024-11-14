using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace LRottaO.CSharp.SimDashboardCtrl
{

    //Based on the excellent work of mdjarvGet (Mathias Djärv), thank you!

    public class AsettoCorsaTelemetry
    {
        private readonly MemoryMappedFile physicsMappedFile;
        private readonly MemoryMappedFile staticMappedFile;
        public Boolean telemetryConnectedSuccess { get; set; } = false;

        public AsettoCorsaTelemetry()
        {
            try
            {
                physicsMappedFile = MemoryMappedFile.OpenExisting("Local\\acpmf_physics");
                staticMappedFile = MemoryMappedFile.OpenExisting("Local\\acpmf_static");
                telemetryConnectedSuccess = true;
            }
            catch
            {
                telemetryConnectedSuccess = false;
            }
        }

        public Physics ReadPhysics()
        {
            
            int size = Marshal.SizeOf(typeof(Physics));

            using (var accessor = physicsMappedFile.CreateViewAccessor(0, size))
            {
                byte[] buffer = new byte[size];
                accessor.ReadArray(0, buffer, 0, size);

                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    return (Physics)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(Physics));
                }
                finally
                {
                    handle.Free();
                }
            }
        }

        public StaticInfo ReadStaticInfo()
        {
            int size = Marshal.SizeOf(typeof(StaticInfo));

            using (var accessor = staticMappedFile.CreateViewAccessor(0, size))
            {
                byte[] buffer = new byte[size];
                accessor.ReadArray(0, buffer, 0, size);

                GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                try
                {
                    return (StaticInfo)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(StaticInfo));
                }
                finally
                {
                    handle.Free();
                }
            }
        }
    }
}