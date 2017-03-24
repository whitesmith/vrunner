#define pinA A0

boolean state = false;
boolean lastState = false;
int val;
float velocity;

float accel;
float accelArray[] = {0,0};
int step = 300;

int turnsCounter = 0;

/*
 * Use AnalogPin as interrupt
 */

void pciSetup(byte pin)
{
    *digitalPinToPCMSK(pin) |= bit (digitalPinToPCMSKbit(pin));  // enable pin
    PCIFR  |= bit (digitalPinToPCICRbit(pin)); // clear any outstanding interrupt
    PCICR  |= bit (digitalPinToPCICRbit(pin)); // enable interrupt for the group
}

ISR (PCINT1_vect) // handle pin change interrupt for A0 to A5 here
{
  turnsCounter++;
}  

void setup() { 
  pinMode(pinA, INPUT);
  Serial.begin(9600);
  pciSetup(pinA);
}

void loop() {      
  if (millis() % step == 0) {
    getAccel();
  }
}

void getAccel(){
  //Serial.println("--");
  velocity = ((turnsCounter * 0.2/2) / (step/1000.0)) ;
  accelArray[1] = velocity;
  accel = (accelArray[1]-accelArray[0]) / (step/1000.0);
  accelArray[0] = accelArray[1];
  Serial.println(accel);
  turnsCounter = 0;
  delay(5);
}

