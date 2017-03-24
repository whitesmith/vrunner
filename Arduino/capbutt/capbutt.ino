#include <CapacitiveSensor.h>

#define pinRight     2
#define pinLeft      4
#define pinReceiver  3

CapacitiveSensor   csR = CapacitiveSensor(pinReceiver,pinRight); 
CapacitiveSensor   csL = CapacitiveSensor(pinReceiver,pinLeft);

int wait = 10;
int limit = 750;

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
  //Serial.println("Init");
}

void loop()                    
{
  
  long bRight =  csR.capacitiveSensor(50);
  //Serial.println(bRight);
  long bLeft =  csL.capacitiveSensor(50);
  
  // Right Arrow

  if (bRight > limit) {
    rState = true;
  } else {
    rState = false;
  }

  if (rState != rStateLast) {
    Serial.print("r");
    /*
    Serial.print("\t");
    Serial.print(bRight);
    Serial.print("\t");
    */
    Serial.println(rState);
  }
  rStateLast = rState;

  // Left Arrow
  
  if (bLeft > limit) {
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
