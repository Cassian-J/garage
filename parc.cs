namespace Garage
{
    // Classe représentant un parc automobile, gérant les voitures et les marques/modèles associés
    public class Parc
    {
        private List<Car> carList;
        private Dictionary<string, List<string>> brandsModels;

        // Constructeur initialisant les collections pour stocker les données
        public Parc()
        {
            carList = new List<Car>();
            brandsModels = new Dictionary<string, List<string>>();
        }

        // Méthode pour charger les données dans le parc
        public void DataGetter((List<Car> ListCars, Dictionary<string, List<string>> Models) Data)
        {
            carList = Data.ListCars;
            brandsModels = Data.Models;
        }

        // Retourne la liste des voitures
        public List<Car> GetList()
        {
            return carList;
        }

        // Retourne le dictionnaire des marques et modèles
        public Dictionary<string, List<string>> GetDictionnary()
        {
            return brandsModels;
        }

        // Ajoute une nouvelle marque au parc
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

        // Ajoute un modèle à une marque existante
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

        // Ajoute une voiture au parc si la marque et le modèle existent
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

        // Affiche la liste des voitures du parc
        public void ListCars()
        {
            if (carList.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le garage.");
                return;
            }

            // Trie les voitures par marque et modèle pour un affichage organisé
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

        // Affiche la liste des marques disponibles
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

        // Affiche la liste des modèles avec leurs marques associées
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

        // Loue une voiture à partir de son ID
        public void RentCar(int carId)
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

        // Retourne une voiture louée en mettant à jour son statut
        public void ReturnCar(int carId)
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
