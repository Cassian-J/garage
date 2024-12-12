using System;

namespace Garage
{
    public class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }

        public int Year { get; set; }
        public bool IsRented { get; set; }
        
        public Car(string brand,string model, int year,int id, bool isrented=false)
        {
            IsRented = isrented;
            Year = year;
            Id = id;
            Brand = brand;
            Model = model;
        }
        public override string ToString()
        {
            return $"Brand: {Brand},\nModel: {Model},\nYear: {Year},\nIs rentable: {IsRented}";
        }
    }
}
