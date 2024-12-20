
namespace Garage
{
    public class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }

        public int Year { get; set; }
        public bool IsRented { get; set; }
        
        public Car(string brandName,string modelName, int manufactureYear,int carId, bool isrented=false)
        {
            IsRented = isrented;
            Year = manufactureYear;
            Id = carId;
            Brand = brandName;
            Model = modelName;
        }
        public override string ToString()
        {
            return $"Brand: {Brand},\nModel: {Model},\nYear: {Year},\nIs rentable: {IsRented}";
        }
    }
}
