using System;
using System.Collections.Generic;
using Garage;

namespace CSharpDiscovery.Quest04
{
    public class Parc
    {
        private List<Car> listcars;

        public Parc()
        {
            listcars = new List<Car>();
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
    }
}