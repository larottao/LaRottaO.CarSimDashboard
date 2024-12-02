
Objective

Interface a chinese motorcycle dashboard to a game (Asseto Corsa) to indicate speed, engine RPMs, selected gear and fuel level. 

2024-12-02

- Added a digital version of the gauges (WIP) that can be projected on an auxiliary screen, in case the user doesn't want / have a physical dashboard

2024-11-14 Changelog

- Read values from game for gearbox and fuel level indicator, and show them on the dashboard [COMPLETE]
 
2024-09-20 Changelog

- Show RPM and SPEED using ESP32 [SUCCESS] - The physical dashboard requires a slower update rate for the speed data than the engine RPMs data. So, instead of sending RPM, Speed, Gas and Fuel data on a single serial packet, the solution was using independent data packets for each item, sent at different rates with different timers.

2024-09-19 Changelog

- Read values from game* and send them via Serial using Python [COMPLETE]
- Read values from game* and send them via Serial using C# [COMPLETE]

NOTES: Based on the excellent work of mdjarvGet (Mathias Djärv), thank you!

- Show RPM and SPEED using Arduino [FAIL] - Unable to generate accurate PWM below 20 hz
- Show RPM and SPEED using Raspberry Pi Pico [FAIL] - Pico's PWM generation works "fine" between 1 and 64 hz, fails between 64-90, and works again between 90-255 Hz.
- Show RPM and SPEED using ESP32 [PARTIAL SUCCESS] - The PWM generation for the RPMs works great at first, but after some use the KM/H gets wonky / reason unknown.

NOTES: Fuel Level and Gear are not yet implemented

![image](https://github.com/user-attachments/assets/d40cd68c-b41b-4763-bd2a-323c06ec24d3)

![image](https://github.com/user-attachments/assets/2f610a38-3bf6-4e99-8796-456524584b2e)

![digital_gauges_example](https://github.com/user-attachments/assets/9ba62d27-6f5e-4744-9972-12dae03cf7e2)
