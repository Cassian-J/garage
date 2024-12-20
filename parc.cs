namespace Garage
{
    public class Parc
    {
        private List<Car> carList;
        private Dictionary<string, List<string>> brandsModels;

        public Parc()
        {
            carList = new List<Car>();
            brandsModels = new Dictionary<string, List<string>>();
        }

        public void DataGetter((List<Car> ListCars, Dictionary<string, List<string>> Models) Data)
        {
            carList = Data.ListCars;
            brandsModels = Data.Models;
        }

        public List<Car> GetList() {
            return carList;
        }

        public Dictionary<string, List<string>> GetDictionnary() {
            return brandsModels;
        }

        public void AddBrand(string brandName)
        {
            if (!brandsModels.ContainsKey(brandName))
            {
                brandsModels[brandName] = new List<string>();
                Console.WriteLine($"Marque ajoutée : {brandName}");
            }
            else
            {
                Console.WriteLine($"La marque {brandName} existe déjà.");
            }
        }

        public void AddModel(string modelName, string brandId)
        {
            if (brandsModels.ContainsKey(brandId))
            {
                if (!brandsModels[brandId].Contains(modelName))
                {
                    brandsModels[brandId].Add(modelName);
                    Console.WriteLine($"Modèle ajouté : {modelName}");
                }
                else
                {
                    Console.WriteLine($"Le modèle {modelName} existe déjà.");
                }
            }
            else 
            {
                Console.WriteLine($"La marque {brandId} n'existe pas.");
            }
        }

        public void AddCars(string brandName, string modelName, int manufactureYear = 0, bool isRented = false)
        {
            if (brandsModels.ContainsKey(brandName) && brandsModels[brandName].Contains(modelName))
            {
                Car car = new Car(brandName, modelName, manufactureYear, carList.Count + 1, isRented);
                carList.Add(car);
                Console.WriteLine($"Voiture ajoutée : {brandName} {modelName} (ID: {carList.Count}, Année: {manufactureYear})");
            }
            else
            {
                Console.WriteLine($"La marque {brandName} ne possède pas de modèle {modelName}.");
            }
        }

        public void ListCars()
        {
            if (carList.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le garage.");
                return;
            }

            var sortedCars = carList.OrderBy(c => c.Brand).ThenBy(c => c.Model).ToList();

            Console.WriteLine("{0,-5} {1,-15} {2,-21} {3,-20} {4,-10}", "ID", "Marque", "Modèle", "Année", "Louée");
            Console.WriteLine(new string('-', 72));

            foreach (var car in sortedCars)
            {
                string isRented = car.IsRented ? "OUI" : "NON";
                Console.WriteLine("{0,-5} {1,-15} {2,-21} {3,-20} {4,-10}",
                                car.Id, car.Brand, car.Model, car.Year, isRented);
            }
        }

        public void ListBrands()
        {
            if (brandsModels.Count == 0)
            {
                Console.WriteLine("Aucune marque ajoutée.");
                return;
            }

            Console.WriteLine("{0,-15}", "Marque");
            Console.WriteLine(new string('-', 15));
            foreach (var brandEntry in brandsModels)
{
                Console.WriteLine("{0,-15}", brandEntry.Key);
            }
        }

        public void ListModels()
        {
            if (brandsModels.Count == 0)
            {
                Console.WriteLine("Aucun modèle ajouté.");
                return;
            }

            Console.WriteLine("{0,-15} {1,-21}", "Marque", "Modèle");
            Console.WriteLine(new string('-', 37));

            foreach (var brandEntry in brandsModels)
            {
                string currentBrand = brandEntry.Key;
                List<string> brandModels = brandEntry.Value;
                foreach (var modelName in brandModels)
                {
                    Console.WriteLine("{0,-15} {1,-21}", currentBrand, modelName);
                }
            }
        }

        public void LouerVoiture(int carId)
        {
            var car = carList.FirstOrDefault(c => c.Id == carId);
            if (car != null)
            {
                if (car.IsRented)
                {
                    Console.WriteLine("La voiture est déjà louée.");
                }
                else
                {
                    car.IsRented = true;
                    Console.WriteLine($"La voiture {car.Brand} {car.Model} a été louée.");
                }
            }
            else
            {
                Console.WriteLine("Aucune voiture avec cet ID.");
            }
        }

        public void ArreterLocation(int carId)
        {
            var car = carList.FirstOrDefault(c => c.Id == carId);
            if (car != null)
            {
                if (!car.IsRented)
                {
                    Console.WriteLine("La voiture n'est pas louée.");
                }
                else
                {
                    car.IsRented = false;
                    Console.WriteLine($"La voiture {car.Brand} {car.Model} a été rendue.");
                }
            }
            else
            {
                Console.WriteLine("Aucune voiture avec cet ID.");
            }
        }
    }
}