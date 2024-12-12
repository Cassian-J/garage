using System;

namespace CSharpDiscovery.Quest04
{
    public class Car 
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public int CurrentSpeed { get; set; }
        public Car()
            {
                Brand = "Unknown";
                Color = "Unknown";
                CurrentSpeed = 0;
            }
        public Car(string model,string brand, string color, int currentSpeed = 0)
            : base(brand, color,currentSpeed)
            {
                Model = model;
            }
        public override string ToString()
        {
            return $"{Color} {Brand} {Model}";
        }
        public override void Accelerate(int speedIncrease)
        {
            CurrentSpeed += speedIncrease;
            if (CurrentSpeed > 180)
            {
                CurrentSpeed = 180;
            }
        }
        public override void Brake(int speedDecrease)
        {
            CurrentSpeed -= speedDecrease;
            if (CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
        }
    }
}