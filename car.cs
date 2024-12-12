using System;

namespace CSharpDiscovery.Quest04
{
    public class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }

        public int Year { get; set; }
        public bool Statue { get; set; }
        public Car()
        {
            Statue = false;
            Year = 0;
            Id = 0;
            Brand = "Unknown";
            Model = "Unknown";
                
        }
        public Car(string model,string brand, int year, bool statue, int id)
        {
            Statue = statue;
            Year = year;
            Id = id;
            Brand = brand;
            Model = model;
        }
        public override string ToString()
        {
            return $"Brand: {Brand},\nModel: {Model},\nYear: {Year},\nIs rentable: {Statue}";
        }
    }
}
