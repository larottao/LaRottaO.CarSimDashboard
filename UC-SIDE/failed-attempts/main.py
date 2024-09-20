#Receives the commands from the PC via serial port and sets the frequency of the Chinese dashboard
#by Luis Felipe La Rotta

from machine import Pin, Timer, UART
import time

# Define the output pins
output_pin1 = Pin(16, Pin.OUT)  # Speed
output_pin2 = Pin(17, Pin.OUT)  # RPM

# Define timers, only one needed for high-frequency RPM
timer1 = Timer()  # Timer for speed
timer2 = Timer()  # Timer for RPM (high frequencies)

# Global variables to track the current frequency
current_speed = None
current_rpm = None
rpm_manual_mode = False
last_rpm_toggle_time = 0
rpm_toggle_interval = 0

def set_speed_rpm_pwms(speed, rpm):
    global current_speed, current_rpm, rpm_manual_mode, last_rpm_toggle_time, rpm_toggle_interval

    # Update speed if changed
    if speed != current_speed:
        current_speed = speed
        timer1.deinit()
        if speed == 0:
            output_pin1.value(0)  # Turn off the output on pin 1
        elif speed <= 100:
            period1 = 1 / speed  # Period in seconds
            half_period1 = period1 / 2
            timer1.init(period=int(half_period1 * 1000), mode=Timer.PERIODIC, callback=lambda t: output_pin1.toggle())
        else:
            toggle_freq1 = speed * 2  # Timer needs to toggle twice per period
            timer1.init(freq=toggle_freq1, mode=Timer.PERIODIC, callback=lambda t: output_pin1.toggle())

    # Update RPM if changed
    if rpm != current_rpm:
        current_rpm = rpm

        # If RPM is below or equal to 100 Hz, use manual toggling
        if rpm > 0 and rpm <= 100:
            timer2.deinit()  # Stop the timer if it's running
            rpm_manual_mode = True
            rpm_toggle_interval = 1 / (2 * rpm)  # Half period
            last_rpm_toggle_time = time.ticks_ms()

        # If RPM is higher than 100 Hz, use the Timer
        elif rpm > 100:
            rpm_manual_mode = False  # Exit manual mode
            timer2.deinit()  # Stop any ongoing timer operations
            toggle_freq2 = rpm * 2  # Timer needs to toggle twice per period
            timer2.init(freq=toggle_freq2, mode=Timer.PERIODIC, callback=lambda t: output_pin2.toggle())

        # If RPM is 0, stop everything
        elif rpm == 0:
            rpm_manual_mode = False  # Exit manual mode
            output_pin2.value(0)  # Turn off the output on pin 2

START_CHAR = '#'
END_CHAR = '$'

def parse_message(message):
    if message.startswith(START_CHAR) and message.endswith(END_CHAR):
        # Strip start and end characters
        message = message[1:-1]

        try:
            # Split the message into components and convert to integers
            rpm_str, speed_str, gas_str, gear_str = message.split(',')
            rpm = int(rpm_str)
            speed = int(speed_str)
            gas = int(gas_str)
            gear = int(gear_str)

            set_speed_rpm_pwms(speed, rpm)

        except ValueError as e:
            send_uart_message(f"ValueError: {e}")
        except Exception as e:
            send_uart_message(f"Exception: {e}")
    else:
        send_uart_message("Invalid message format: " + message)

# Set up UART on GPIO0 (GP0) and GPIO1 (GP1)
uart = UART(0, baudrate=115200, tx=Pin(0), rx=Pin(1))

def send_uart_message(message):
    """Send a UTF-8 encoded message through UART."""
    uart.write(message.encode('utf-8'))

def receive_uart_message():
    """Receive a UTF-8 encoded message from UART."""
    if uart.any():
        return uart.read().decode('utf-8')
    return None

def main():
    global last_rpm_toggle_time, rpm_toggle_interval, rpm_manual_mode

    while True:
        # Check for new UART messages
        message = receive_uart_message()
        if message:
            parse_message(message)

        # Handle manual toggling for low-frequency RPM (0-100 Hz)
        if rpm_manual_mode:
            current_time = time.ticks_ms()
            if time.ticks_diff(current_time, last_rpm_toggle_time) >= (rpm_toggle_interval * 1000):
                output_pin2.toggle()
                last_rpm_toggle_time = current_time

        # Small delay to avoid busy-waiting, can be tuned
        time.sleep(0.001)

main()
