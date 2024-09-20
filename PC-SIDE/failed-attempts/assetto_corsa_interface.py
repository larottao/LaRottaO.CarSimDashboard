# Runs as a program on a Windows Desktop Computer

import mmap
import ctypes
import serial
import signal
import sys
import time

class Physics(ctypes.Structure):
    _fields_ = [
        ("PacketId", ctypes.c_int),
        ("Gas", ctypes.c_float),
        ("Brake", ctypes.c_float),
        ("Fuel", ctypes.c_float),
        ("Gear", ctypes.c_int),
        ("Rpms", ctypes.c_int),
        ("SteerAngle", ctypes.c_float),
        ("SpeedKmh", ctypes.c_float),
        ("Velocity", ctypes.c_float * 3),
        ("AccG", ctypes.c_float * 3),
        ("WheelSlip", ctypes.c_float * 4),
        ("WheelLoad", ctypes.c_float * 4),
        ("WheelsPressure", ctypes.c_float * 4),
        ("WheelAngularSpeed", ctypes.c_float * 4),
        ("TyreWear", ctypes.c_float * 4),
        ("TyreDirtyLevel", ctypes.c_float * 4),
        ("TyreCoreTemperature", ctypes.c_float * 4),
        ("CamberRad", ctypes.c_float * 4),
        ("SuspensionTravel", ctypes.c_float * 4),
        ("Drs", ctypes.c_float),
        ("TC", ctypes.c_float),
        ("Heading", ctypes.c_float),
        ("Pitch", ctypes.c_float),
        ("Roll", ctypes.c_float),
        ("CgHeight", ctypes.c_float),
        ("CarDamage", ctypes.c_float * 5),
        ("NumberOfTyresOut", ctypes.c_int),
        ("PitLimiterOn", ctypes.c_int),
        ("Abs", ctypes.c_float),
        ("KersCharge", ctypes.c_float),
        ("KersInput", ctypes.c_float),
        ("AutoShifterOn", ctypes.c_int),
        ("RideHeight", ctypes.c_float * 2),
        ("TurboBoost", ctypes.c_float),
        ("Ballast", ctypes.c_float),
        ("AirDensity", ctypes.c_float),
        ("AirTemp", ctypes.c_float),
        ("RoadTemp", ctypes.c_float),
        ("LocalAngularVelocity", ctypes.c_float * 3),
        ("FinalFF", ctypes.c_float),
        ("PerformanceMeter", ctypes.c_float),
        ("EngineBrake", ctypes.c_int),
        ("ErsRecoveryLevel", ctypes.c_int),
        ("ErsPowerLevel", ctypes.c_int),
        ("ErsHeatCharging", ctypes.c_int),
        ("ErsisCharging", ctypes.c_int),
        ("KersCurrentKJ", ctypes.c_float),
        ("DrsAvailable", ctypes.c_int),
        ("DrsEnabled", ctypes.c_int),
        ("BrakeTemp", ctypes.c_float * 4),
        ("Clutch", ctypes.c_float),
        ("TyreTempI", ctypes.c_float * 4),
        ("TyreTempM", ctypes.c_float * 4),
        ("TyreTempO", ctypes.c_float * 4),
        ("IsAIControlled", ctypes.c_int),
        ("BrakeBias", ctypes.c_float),
        ("LocalVelocity", ctypes.c_float * 3)
    ]

class StaticInfo(ctypes.Structure):
    _fields_ = [
        ("MaxTorque", ctypes.c_float),
        ("MaxPower", ctypes.c_float),
        ("MaxRpm", ctypes.c_int),
        ("MaxFuel", ctypes.c_float),
        ("SuspensionMaxTravel", ctypes.c_float * 4),
        ("TyreRadius", ctypes.c_float * 4)
    ]

# Real and equivalent RPM and KPH values for interpolation
#real_rpm_values = [0, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000]
#equiv_rpm_values = [0, 20, 35, 52, 68, 85, 102, 119, 135, 152, 169, 186, 203, 220, 237, 255]

real_rpm_values = [0, 1000, 2000, 3000, 6500]
equiv_rpm_values = [0, 20, 35, 52, 186]

real_kph_values = [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240, 250, 260, 270, 280, 290]
equiv_kph_values = [1, 3, 6, 9, 12, 15, 18, 22, 25, 29, 31, 34, 37, 39, 42, 45, 48, 51, 54, 57, 60, 63, 66, 68, 71, 74, 77, 80, 83, 91]

# Serial port initialization
def serial_init():
    s = serial.Serial(port="COM17", baudrate=115200, parity=serial.PARITY_NONE, timeout=0.1)
    s.flush()
    return s

# Interpolation function
def interpolate(val_to_find, real_values, equiv_freq_values):
    if val_to_find <= real_values[0]:
        return equiv_freq_values[0]
    elif val_to_find >= real_values[-1]:
        return equiv_freq_values[-1]
    else:
        for i in range(len(real_values) - 1):
            if real_values[i] <= val_to_find <= real_values[i + 1]:
                x0, x1 = real_values[i], real_values[i + 1]
                y0, y1 = equiv_freq_values[i], equiv_freq_values[i + 1]
                return y0 + (y1 - y0) * ((val_to_find - x0) / (x1 - x0))
        return equiv_freq_values[-1]  # In case something goes wrong, return the last value

# Serial send function
def serial_send(s, rpm, speed, gas, gear):
    rpm = min(max(int(rpm), 0), 999)  
    speed = min(max(int(speed), 0), 999)  
    gas = min(max(int(gas), 0), 999)     
    gear = min(max(int(gear), 0), 9)   

    message = f"#{rpm:03d},{speed:03d},{gas:03d},{gear:01d}$"
    s.write(message.encode('utf-8'))
    #print("---->" + str(message))

# Signal handler for graceful shutdown
def signal_handler(sig, frame):
    print('Exiting...')
    serial_close()
    sys.exit(0)

# Main telemetry class
class AssettoCorsaTelemetry:
    def __init__(self):
        self.physics_shared_memory_name = "Local\\acpmf_physics"
        self.static_info_shared_memory_name = "Local\\acpmf_static"
        self.mapped_file_physics = self.open_mapped_file(self.physics_shared_memory_name)
        self.mapped_file_static = self.open_mapped_file(self.static_info_shared_memory_name)

    def open_mapped_file(self, name):
        return mmap.mmap(-1, 2048, name, access=mmap.ACCESS_READ)

    def read_physics(self):
        size = ctypes.sizeof(Physics)
        self.mapped_file_physics.seek(0)
        data = self.mapped_file_physics.read(size)
        return Physics.from_buffer_copy(data)

    def read_static_info(self):
        size = ctypes.sizeof(StaticInfo)
        self.mapped_file_static.seek(0)
        data = self.mapped_file_static.read(size)
        return StaticInfo.from_buffer_copy(data)

# Main execution
if __name__ == "__main__":
    s = serial_init()
    telemetry = AssettoCorsaTelemetry()
    
    signal.signal(signal.SIGINT, signal_handler)
    signal.signal(signal.SIGTERM, signal_handler)

    try:
        static_info = telemetry.read_static_info()
        print(f"MaxPower: {static_info.MaxPower} MaxRpm: {static_info.MaxRpm} MaxFuel: {static_info.MaxFuel}")

        while True:
            physics = telemetry.read_physics()

            equiv_rpm_freq = interpolate(physics.Rpms, real_rpm_values, equiv_rpm_values)
            equiv_kmh_freq = interpolate(physics.SpeedKmh, real_kph_values, equiv_kph_values)

            serial_send(s, round(equiv_rpm_freq), round(equiv_kmh_freq), round(physics.Fuel), round(physics.Gear))

            time.sleep(0.1)

    except KeyboardInterrupt:
        print('Interrupted by user')
        s.close()
    finally:
        if s.is_open:
            s.close()
