using System;
using Garage;

namespace Garage
{
    public class Parc
    {
        private List<Car> listcars;
        private List<string> brands;
        private Dictionary<string, List<string>> models;

        public Parc()
        {
            listcars = new List<Car>();
            brands = new List<string>();
            models = new Dictionary<string, List<string>>();
        }

        public void AddBrand(string brand)
        {
            if (!brands.Contains(brand))
            {
                models[brand] = new List<string>();
                brands.Add(brand);
                Console.WriteLine($"Marque ajoutée : {brand}");
            }
            else
            {
                Console.WriteLine($"La marque {brand} existe déjà.");
            }
        }

        public void AddModel(string model, string brandId)
        {
            if (!models[brandId].Contains(model))
            {
                models[brandId].Add(model);
                Console.WriteLine($"Modèle ajouté : {model}");
            }
            else
            {
                Console.WriteLine($"Le modèle {model} existe déjà.");
            }
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

            Console.WriteLine("Liste des voitures :");
            foreach (var car in listcars)
            {
                Console.WriteLine(car);
            }
        }

        public void ListBrands()
        {
            if (brands.Count == 0)
            {
                Console.WriteLine("Aucune marque ajoutée.");
                return;
            }

            Console.WriteLine("Liste des marques :");
            foreach (var brand in brands)
            {
                Console.WriteLine($"- {brand}");
            }
        }

        public void ListModels()
        {
            if (models.Count == 0)
            {
                Console.WriteLine("Aucun modèle ajouté.");
                return;
            }

            Console.WriteLine("Liste des modèles :");
            foreach (var brand in models)
            {
                foreach (var model in brands){
                    Console.WriteLine($"-{brand} : {model}");
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