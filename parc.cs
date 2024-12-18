namespace Garage
{
    public class Parc
    {
        private List<Car> listcars;
        private Dictionary<string, List<string>> models;

        public Parc()
        {
            listcars = new List<Car>();
            models = new Dictionary<string, List<string>>();
        }
        public void DataGetter((List<Car> ListCars, Dictionary<string, List<string>> Models) Data)
        {
                listcars = Data.ListCars;
                models = Data.Models;
        }
        public List<Car> GetList() {
            return listcars;
        }
        public Dictionary<string, List<string>> GetDictionnary() {
            return models;
        }
        
        public void AddCars(string brand, string model, int year = 0, bool isRented = false)
        {
            if (models[brand].Contains(model)){
                Car car = new Car(brand, model, year, listcars.Count+1, isRented);
                listcars.Add(car);
                Console.WriteLine($"Voiture ajoutée : {brand} {model} (ID: {listcars.Count+1}, Année: {year})");
            }else{
                Console.WriteLine($"la marque {brand} ne possède pas de modèle {model}");
            }
            
        }

        public void ListCars()
        {
            if (listcars.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le parc.");
                return;
            }
            Console.WriteLine("{0,-5} {1,-15} {2,-21} {3,-20} {4,-10}", "ID", "Marque", "Modèle", "Année de création", "Louable");
            Console.WriteLine(new string('-', 72));

            foreach (var car in listcars)
            {
                string isRented = car.IsRented ? "OUI" : "NON";
                Console.WriteLine("{0,-5} {1,-15} {2,-21} {3,-20} {4,-10}",
                                car.Id, car.Brand, car.Model, car.Year, isRented);
            }
        }

        public void ListBrands()
        {
            if (models.Count == 0)
            {
                Console.WriteLine("Aucune marque ajoutée.");
                return;
            }

            Console.WriteLine("{0,-15}", "Marque");
            Console.WriteLine(new string('-', 15));
            foreach (var brand in models)
            {
                Console.WriteLine("{0,-15}",brand.Key);
            }
        }

        public void ListModels()
        {
            if (models.Count == 0)
            {
                Console.WriteLine("Aucun modèle ajouté.");
                return;
            }

            Console.WriteLine("{0,-15} {1,-21}", "Marque","Modèle");
            Console.WriteLine(new string('-', 37));
            foreach (var brand in models)
            {
                string brandName = brand.Key;
                List<string> brandModels = brand.Value; 
                foreach (var model in brandModels){
                    Console.WriteLine("{0,-15} {1,-21}", brandName ,model);
                }
            }
        }

        public void LouerVoiture(int id)
        {
            foreach (var car in listcars)
            {
                if (car.Id == id)
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
                    return;
                }
            }
            Console.WriteLine("Aucune voiture avec cet ID.");
        }

        public void ArreterLocation(int id)
        {
            foreach (var car in listcars)
            {
                if (car.Id == id)
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
                    return;
                }
            }
            Console.WriteLine("Aucune voiture avec cet ID.");
        }
    }
}