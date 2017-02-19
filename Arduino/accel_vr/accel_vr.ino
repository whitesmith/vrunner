#define pinA         A0

boolean state = false;
boolean lastState = false;
int val;
float velocity;

float accel;
float accelArray[] = {0,0};
int wait = 250;

int turnsCounter = 0;

void setup() { 
  pinMode(pinA, INPUT);
  Serial.begin(9600);
}

void loop() {
  countTurns(analogRead(pinA));
      
  if (millis() % wait == 0) {
    getAccel();
  }
}

int countTurns(int val){
  
  if (val > 1000) {
    state = true;
  } else {
    state = false;
  }

  if (state != lastState){
    turnsCounter++;
  }
  
  lastState = state;
  return turnsCounter;
}

void getAccel(){
  velocity = ((turnsCounter * 0.2/2) / (wait/1000.0)) ;
  accelArray[1] = velocity;
  accel = (accelArray[1]-accelArray[0]) / (wait/1000.0);
  accelArray[0] = accelArray[1];
  Serial.println(accel);
  turnsCounter = 0;
  delay(10);
}

