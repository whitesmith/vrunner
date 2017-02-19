#include <CapacitiveSensor.h>

#define pinRight     2
#define pinLeft      3
#define pinReceiver  4

CapacitiveSensor   cs2 = CapacitiveSensor(pinReceiver,pinRight); 
CapacitiveSensor   cs3 = CapacitiveSensor(pinReceiver,pinLeft);

int wait = 10;

// Buttons Flags

bool rState = false;
bool rStateLast = false;
bool rFlag = false;

bool lState = false;
bool lStateLast = false;
bool lFlag = false;

void setup()                    
{
  Serial.begin(9600);
}

void loop()                    
{
  
  long bRight =  cs2.capacitiveSensor(30);
  long bLeft =  cs3.capacitiveSensor(30);
  
  // Right Arrow

  if (bRight > 1000) {
    rState = true;
  } else {
    rState = false;
  }

  if (rState != rStateLast) {
    Serial.print("r");
    Serial.println(rState);
  }
  rStateLast = rState;

  // Left Arrow
  
  if (bLeft > 1000) {
    lState = true;
  } else {
    lState = false;
  }

  if (lState != lStateLast) {
    Serial.print("l");
    Serial.println(lState);
  }
  lStateLast = lState;
  
  delay(wait); 
}
