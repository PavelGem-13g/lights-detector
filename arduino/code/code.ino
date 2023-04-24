String readdata;
int pin1 = 2;
int pin2 = 3;
int pin3 = 4;
int pin4 = 5;
int pin5 = 6;
int pin6 = 7;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(pin1, OUTPUT);
  pinMode(pin2, OUTPUT);
  pinMode(pin3, OUTPUT);
  pinMode(pin4, OUTPUT);
  pinMode(pin5, OUTPUT);
  pinMode(pin6, OUTPUT);
  
  digitalWrite(pin1, LOW);
  digitalWrite(pin2, LOW);
  digitalWrite(pin3, LOW);
  digitalWrite(pin4, LOW);
  digitalWrite(pin5, LOW);
  digitalWrite(pin6, LOW);
} 

void loop() {

  if(Serial.available()>0)
  {
    char data = Serial.read();
    readdata.concat(data);
    }
    else
    {
      //Serial.println(readdata);
      if(readdata.equals("Hello"))
      {
        Serial.write("ardok");
        readdata = "";
      }
      else if(readdata.substring(0) =="1H")
      {
        digitalWrite(pin1, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="1L")
      {
        digitalWrite(pin1, LOW);
        readdata = "";
      }
      else if(readdata.substring(0) =="2H")
      {
        digitalWrite(pin2, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="2L")
      {
        digitalWrite(pin2, LOW);
        readdata = "";
      }
      else if(readdata.substring(0) =="3H")
      {
        digitalWrite(pin3, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="3L")
      {
        digitalWrite(pin3, LOW);
        readdata = "";
      }
      else if(readdata.substring(0) =="4H")
      {
        digitalWrite(pin4, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="4L")
      {
        digitalWrite(pin4, LOW);
        readdata = "";
      }
      else if(readdata.substring(0) =="5H")
      {
        digitalWrite(pin5, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="5L")
      {
        digitalWrite(pin5, LOW);
        readdata = "";
      }
      else if(readdata.substring(0) =="6H")
      {
        digitalWrite(pin6, HIGH);
        readdata = "";
      }
      else if(readdata.substring(0) =="6L")
      {
        digitalWrite(pin6, LOW);
        readdata = "";
      }
    }
}
