//Receives the commands from the PC via serial port and sets the frequency of the Chinese motorcycle dashboard
//Optimized for ESP32 using Arduino by Luis Felipe La Rotta
//Use esp32 byEspressif systems 2.0.17 library and ESP32 Dev Module on Arduino IDE if using ESP32-WROOM-32 board

#include <Arduino.h>

#define ON_BOARD_LED_PIN 2

#define OUTPUT_PIN1 16  // Speed pin
#define OUTPUT_PIN2 17  // RPM pin

#define OUTPUT_GEAR_PIN_7 32
#define OUTPUT_GEAR_PIN_6 33
#define OUTPUT_GEAR_PIN_5 25
#define OUTPUT_GEAR_PIN_4 26
#define OUTPUT_GEAR_PIN_3 27
#define OUTPUT_GEAR_PIN_2 14
#define OUTPUT_GEAR_PIN_1 12

#define OUTPUT_FUEL_PIN_1 22
#define OUTPUT_FUEL_PIN_2 21
#define OUTPUT_FUEL_PIN_3 19
#define OUTPUT_FUEL_PIN_4 18
#define OUTPUT_FUEL_PIN_5 5


const int PWM_CHANNEL1 = 1;  // PWM channel for speed
const int PWM_CHANNEL2 = 4;  // PWM channel for RPM
const int PWM_RESOLUTION = 8;  // 8-bit resolution (0-255)
const int PWM_FREQ_INITIAL = 0;  // Initial frequency

const char START_CHAR = '#';
const char END_CHAR = '$';

// Global variables
int currentSpeed = -1;  // Initialize to a value that will not match any valid frequency
int currentRPM = -1;    // Initialize to a value that will not match any valid frequency

int currentFuel = -1;
int currentGear = -1;


void setup() {
  Serial.begin(115200);

  // Setup PWM for speed
  ledcSetup(PWM_CHANNEL1, PWM_FREQ_INITIAL, PWM_RESOLUTION);
  ledcAttachPin(OUTPUT_PIN1, PWM_CHANNEL1);

  // Setup PWM for RPM
  ledcSetup(PWM_CHANNEL2, PWM_FREQ_INITIAL, PWM_RESOLUTION);
  ledcAttachPin(OUTPUT_PIN2, PWM_CHANNEL2);

 // Set fuel pins as outputs
  pinMode(OUTPUT_GEAR_PIN_1, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_2, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_3, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_4, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_5, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_6, OUTPUT);
  pinMode(OUTPUT_GEAR_PIN_7, OUTPUT);

  pinMode(OUTPUT_FUEL_PIN_1, OUTPUT);
  pinMode(OUTPUT_FUEL_PIN_2, OUTPUT);
  pinMode(OUTPUT_FUEL_PIN_3, OUTPUT);
  pinMode(OUTPUT_FUEL_PIN_4, OUTPUT);
  pinMode(OUTPUT_FUEL_PIN_5, OUTPUT);

  setAllGearPinsLow();

  pinMode(ON_BOARD_LED_PIN, OUTPUT);

}

void loop() {

  if (Serial.available() > 0) {
    String message = Serial.readStringUntil('\n');
    message.trim();  // Remove any extraneous characters like newline

    if (message.startsWith(String(START_CHAR)) && message.endsWith(String(END_CHAR))) {
      // Strip start and end characters
      message = message.substring(1, message.length() - 1);

      // Parse the message based on the header
      parseMessage(message);
    } else {
      sendUARTMessage("Invalid message format: " + message);
    }
  }
}

void parseMessage(String message) {
  // Check for known message headers and extract values
    if (message.startsWith("ident")) {    
    ident();
  }
  else if (message.startsWith("rpm:")) {
    int rpm = message.substring(4).toInt();  // Extract RPM value
    setRPM(rpm);
  }
  else if (message.startsWith("speed:")) {
    int speed = message.substring(6).toInt();  // Extract speed value
    setSpeed(speed);
  }
  else if (message.startsWith("fuel:")) {
    int fuel = message.substring(5).toInt();  // Extract fuel value
    setFuel(fuel);
  }
  else if (message.startsWith("gear:")) {
    int gear = message.substring(5).toInt();  // Extract gear value
    setGear(gear);
  }
  else {
    sendUARTMessage("Unknown message type: " + message);
  }
}

void ident() {   
   sendUARTMessage("larottao-dashboard");
}

void setRPM(int rpm) {
  
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

void setSpeed(int speed) {

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

}

void setAllGearPinsLow(){

  digitalWrite(OUTPUT_GEAR_PIN_1, LOW);
  digitalWrite(OUTPUT_GEAR_PIN_2, LOW);
  digitalWrite(OUTPUT_GEAR_PIN_3, LOW);
  digitalWrite(OUTPUT_GEAR_PIN_4, LOW);
  digitalWrite(OUTPUT_GEAR_PIN_5, LOW);  
  digitalWrite(OUTPUT_GEAR_PIN_6, LOW);  
  digitalWrite(OUTPUT_GEAR_PIN_7, LOW);  

}

void setAllFuelPinsLow(){

  digitalWrite(OUTPUT_FUEL_PIN_1, LOW);
  digitalWrite(OUTPUT_FUEL_PIN_2, LOW);
  digitalWrite(OUTPUT_FUEL_PIN_3, LOW);
  digitalWrite(OUTPUT_FUEL_PIN_4, LOW);
  digitalWrite(OUTPUT_FUEL_PIN_5, LOW);
  
}

void setFuel(int fuel) {
 
   
 if (fuel != currentFuel) {  
  
    currentFuel = fuel;

    setAllFuelPinsLow();

    if(fuel == 1){
    digitalWrite(OUTPUT_FUEL_PIN_1, HIGH);
    }
    else if(fuel == 2){   
      digitalWrite(OUTPUT_FUEL_PIN_2, HIGH);  
    }
    else if(fuel == 3){
      digitalWrite(OUTPUT_FUEL_PIN_3, HIGH);
    }
    else if(fuel == 4){
    digitalWrite(OUTPUT_FUEL_PIN_4, HIGH);
    }
    else if(fuel == 5){
    digitalWrite(OUTPUT_FUEL_PIN_5, HIGH);
    }     

  }
}

void setGear(int gear) {


 if (gear != currentGear) {  
  
    currentGear = gear;

    setAllGearPinsLow();

    if(gear == 1){
    digitalWrite(OUTPUT_GEAR_PIN_1, HIGH);
    }
    else if(gear == 2){   
      digitalWrite(OUTPUT_GEAR_PIN_2, HIGH);  
    }
    else if(gear == 3){
      digitalWrite(OUTPUT_GEAR_PIN_3, HIGH);
    }
    else if(gear == 4){
    digitalWrite(OUTPUT_GEAR_PIN_4, HIGH);
    }
    else if(gear == 5){
    digitalWrite(OUTPUT_GEAR_PIN_5, HIGH);
    }
    else if(gear == 6){
    digitalWrite(OUTPUT_GEAR_PIN_6, HIGH);
    }
    else if(gear == 7){
    digitalWrite(OUTPUT_GEAR_PIN_7, HIGH);
    }
    
  }

}


void sendUARTMessage(String message) {
  // Send a message back to the PC
  Serial.println(message);
}

void blinkLed(){
  digitalWrite(ON_BOARD_LED_PIN,HIGH);
  delay(300);
  digitalWrite(ON_BOARD_LED_PIN,LOW);
  delay(300);
}
