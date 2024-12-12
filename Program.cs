using System;
using Garage;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Parc parc = new Parc();

            parc.AddBrand("Toyota");
            parc.AddBrand("Ford");
            parc.AddBrand("Honda");
            parc.AddBrand("Tesla");

            parc.AddModel("Corolla");
            parc.AddModel("Mustang");
            parc.AddModel("Civic");
            parc.AddModel("Model S");

            parc.AddCars("Toyota", "Corolla", 1, false, 2020);
            parc.AddCars("Ford", "Mustang", 2, false, 2021);
            parc.AddCars("Honda", "Civic", 3, false, 2022);
            parc.AddCars("Tesla", "Model S", 4, false, 2023);

            Console.WriteLine("\n--- Liste des voitures ---");
            parc.ListCars();

            Console.WriteLine("\n--- Liste des marques ---");
            parc.ListBrands();

            Console.WriteLine("\n--- Liste des modèles ---");
            parc.ListModels();

            Console.WriteLine("\n--- Test de location ---");
            parc.LouerVoiture(1);
            parc.LouerVoiture(2);

            Console.WriteLine("\n--- Test de retour ---");
            parc.ArreterLocation(1);
            parc.ArreterLocation(3);
        }
    }
}