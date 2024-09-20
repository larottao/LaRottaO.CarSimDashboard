//Receives the commands from the PC via serial port and sets the frequency of the Chinese motorcycle dashboard
//Optimized for ESP32 using Arduino by Luis Felipe La Rotta
//Use esp32 byEspressif systems 2.0.17 library and ESP32 Dev Module on Arduino IDE if using ESP32-WROOM-32 board

#include <Arduino.h>

#define OUTPUT_PIN1 16  // Speed pin
#define OUTPUT_PIN2 17  // RPM pin

const int PWM_CHANNEL1 = 0;  // PWM channel for speed
const int PWM_CHANNEL2 = 4;  // PWM channel for RPM
const int PWM_RESOLUTION = 8;  // 8-bit resolution (0-255)
const int PWM_FREQ_INITIAL = 0;  // Initial frequency

const char START_CHAR = '#';
const char END_CHAR = '$';

// Global variables
int currentSpeed = -1;  // Initialize to a value that will not match any valid frequency
int currentRPM = -1;    // Initialize to a value that will not match any valid frequency

void setup() {
  Serial.begin(115200);

  // Setup PWM for speed
  ledcSetup(PWM_CHANNEL1, PWM_FREQ_INITIAL, PWM_RESOLUTION);
  ledcAttachPin(OUTPUT_PIN1, PWM_CHANNEL1);

  // Setup PWM for RPM
  ledcSetup(PWM_CHANNEL2, PWM_FREQ_INITIAL, PWM_RESOLUTION);
  ledcAttachPin(OUTPUT_PIN2, PWM_CHANNEL2);
}

void loop() {
  if (Serial.available() > 0) {
    String message = Serial.readStringUntil('\n');
    message.trim();  // Remove any extraneous characters like newline

    if (message.startsWith(String(START_CHAR)) && message.endsWith(String(END_CHAR))) {
      // Strip start and end characters
      message = message.substring(1, message.length() - 1);

      // Parse the message
      parseMessage(message);
    } else {
      sendUARTMessage("Invalid message format: " + message);
    }
  }
}

void parseMessage(String message) {
  // Split the message into components
  int commaIndex1 = message.indexOf(',');
  int commaIndex2 = message.indexOf(',', commaIndex1 + 1);
  int commaIndex3 = message.indexOf(',', commaIndex2 + 1);

  // Extract the values for RPM and Speed
  int rpm = message.substring(0, commaIndex1).toInt();
  int speed = message.substring(commaIndex1 + 1, commaIndex2).toInt();

  // Set the Speed and RPM
  setSpeedAndRPM(speed, rpm);
}

void setSpeedAndRPM(int speed, int rpm) {
  // Update speed if changed
  if (speed != currentSpeed) {
    currentSpeed = speed;
    if (speed == 0) {
      // Turn off PWM for speed
      ledcWrite(PWM_CHANNEL1, 0);
    } else {
      // Set the frequency and a 50% duty cycle for speed
      ledcWriteTone(PWM_CHANNEL1, speed);
      ledcWrite(PWM_CHANNEL1, 128);  // 50% duty cycle (128 out of 255)
    }
  }

  // Update RPM if changed
  if (rpm != currentRPM) {
    currentRPM = rpm;
    if (rpm == 0) {
      // Turn off PWM for RPM
      ledcWrite(PWM_CHANNEL2, 0);
    } else {
      // Set the frequency and a 50% duty cycle for RPM
      ledcWriteTone(PWM_CHANNEL2, rpm);
      ledcWrite(PWM_CHANNEL2, 128);  // 50% duty cycle (128 out of 255)
    }
  }
}

void sendUARTMessage(String message) {
  // Send a message back to the PC
  Serial.println(message);
}
