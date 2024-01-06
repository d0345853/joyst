
#include <math.h>
byte Data[150];
int Data_point = 0;
int flag=0;
int Joyst_Angle = 0;
int Last_Angle = 0;
int Po=0;
int Last_Joyst_Angle = 0;
double Data_x = 0.0;
double Data_x_nor = 0.0;
double Data_y = 0.0;
double Data_y_nor = 0.0;
double Data_z = 0.0;
double Data_s = 0.0;
int GO_pin=3;
int go_speed=0;
int mission_index = 0;  
int count = 0;
float Go_head; 

void setup() {
  Serial.begin(115200);
  Serial2.begin(9600);    //Serial2 joystick from VS communicate with ardunio
  //Serial3.begin(9600); //Serial3 ardunio communicate with Motor
  motor_ini();
}

void loop() {
  motor_ini();
  Last_Joyst_Angle = 0.5*(Last_Joyst_Angle + Joyst_Angle) ;
  //Serial2.print(Motor_Position);
  Serial2.print("PT=");  
  Serial2.print(Po);         //position Po
  delay(50);   
  Serial2.print(" ");   
  Serial2.print("G ");
  delay(10); 

  // forward motor //
  go_speed = Go_head*255/1.414;
  analogWrite(GO_pin,go_speed);
}

// Joysteak serial //
void serialEvent() {             
    if (Serial.available()>0)         
    {
         Data[Data_point] =   Serial.read();    //Joysteak input 
         if (Data_point >= 149) Data_point = 0;
         if (Data_point >= 11 && (Data[Data_point] == 254) && (Data[Data_point - 10] == 255))
         {
                flag=1;
                                            Last_Angle = Joyst_Angle;
                Serial.print("Last_Angle");
                Serial.print(Last_Angle);
                // X arix //
                int x_1 = Data[Data_point - 9];
                int x_2 = Data[Data_point - 8];
                Data_x = ((x_1 * 256.0 + x_2 )-3000) / 100;
                Data_x_nor = Data_x/20;                            //normalization
    
                // Y arix //
                int y_1 = Data[Data_point - 7];
                int y_2 = Data[Data_point - 6];
                Data_y = ((y_1 * 256.0 + y_2 )-3000) / 100;
                Data_y_nor = Data_y/7.5;                            //normalization
    
                // radius //
                Go_head =  sqrt((pow(Data_x_nor,2)+pow(Data_y_nor,2)));
            

                // angle //
                Joyst_Angle = atan2(Data_y_nor,Data_x_nor)*180/3.14;
                if(Joyst_Angle<0) Joyst_Angle = Joyst_Angle+360;   
                             
                Serial.print(" Joyst_Angle: ");
                Serial.print(Joyst_Angle);
                if(Go_head<0.3) Joyst_Angle = 90;    //在60%位移的範圍內，角度都不變
              
                    
                    // angle range setting//     
                    if(Joyst_Angle>=45&&Joyst_Angle<=135){
                        Po=-120 * Last_Joyst_Angle + 10800;
                        Po=-120 * Joyst_Angle + 10800;
                        Serial.print(" Po1111: ");
                        Serial.println(Po);
                    } 
                    else if(Joyst_Angle>135&&Joyst_Angle<=270){    
                        Po=-5400;
                        Serial.print(" Po2222: ");
                        Serial.println(Po);
                    
                    }     
                    else {
                        Po=5400;
                        Serial.print(" Po: ");
                        Serial.println(Po);            
                    }
    
                    int z_1 = Data[Data_point - 5];
                    int z_2 = Data[Data_point - 4];
                    int s_1 = Data[Data_point - 3];
                    int s_2 = Data[Data_point - 2];            
                    int catch_data = Data[Data_point - 1];
                    if (catch_data == 1) {
                      mission_index = 2;
                    }
                    Data_point = 0;          
                
          }
          Data_point++;
    }
}

void motor_ini() {
  Serial2.print("EIGN(2) ");
  delay(10);
  Serial2.print("EIGN(3) ");
  delay(10);
  Serial2.print("ZS ");
  delay(10);
  Serial2.print("MP ");
  delay(10);
  Serial2.print("ADT=500 ");
  delay(10);
  Serial2.print("VT=32768 ");
  delay(10);
}
