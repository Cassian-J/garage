using System;
using Garage;

namespace CSharpDiscovery.Quest04
{
    public class Parc
    {
        private List<Car> listcars;
        private List<string> brands;
        private List<string> models;

        public Parc()
        {
            listcars = new List<Car>();
            brands = new List<string>();
            models = new List<string>();
        }

        public void AddBrand(string brand)
        {
            if (!brands.Contains(brand))
            {
                brands.Add(brand);
                Console.WriteLine($"Marque ajoutée : {brand}");
            }
            else
            {
                Console.WriteLine($"La marque {brand} existe déjà.");
            }
        }

        public void AddModel(string model)
        {
            if (!models.Contains(model))
            {
                models.Add(model);
                Console.WriteLine($"Modèle ajouté : {model}");
            }
            else
            {
                Console.WriteLine($"Le modèle {model} existe déjà.");
            }
        }

        public void AddCars(string brand, string model, int id, bool isRented = false, int year = 0)
        {
            Car car = new Car(brand, model, year, id, isRented);
            listcars.Add(car);
            Console.WriteLine($"Voiture ajoutée : {brand} {model} (ID: {id}, Année: {year})");
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
            foreach (var model in models)
            {
                Console.WriteLine($"- {model}");
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