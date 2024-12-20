
namespace Garage
{
    // Définit une classe représentant une voiture dans le garage
    public class Car 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Id { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }
        
        // Constructeur de la classe Car permettant d'initialiser les propriétés
        public Car(string brandName, string modelName, int manufactureYear, int carId, bool isrented = false)
        {
            IsRented = isrented;
            Year = manufactureYear;
            Id = carId;
            Brand = brandName;
            Model = modelName;
        }

        // Redéfinit la méthode ToString pour afficher les informations sur la voiture sous forme de chaîne
        public override string ToString()
        {
            return $"Brand: {Brand},\nModel: {Model},\nYear: {Year},\nIs rentable: {IsRented}";
        }
    }
}
