
Objective

Interface a chinese motorcycle dashboard to a game (Asseto Corsa) to indicate speed, engine RPMs, selected gear and fuel level. 

2024-09-19 Changelog

- Read values from game* and send them via Serial using Python [COMPLETE]
- Read values from game* and send them via Serial using C# [COMPLETE]

* Based on the excellent work of mdjarvGet (Mathias Djärv), thank you!

- Show RPM and SPEED using Arduino [FAIL]
- Show RPM and SPEED using Raspberry Pi Pico [FAIL]
Show RPM and SPEED using ESP32 [PARTIAL SUCCESS] The PWM generation for the RPMs works great, but the KM/H is wonky. Fuel Level and Gear are not yet implemented

![image](https://github.com/user-attachments/assets/d40cd68c-b41b-4763-bd2a-323c06ec24d3)

![image](https://github.com/user-attachments/assets/2f610a38-3bf6-4e99-8796-456524584b2e)
