using System;
using Garage;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Parc parc = new Parc();
            parc.AddCars("Toyota", "Corolla", 1, 2020);
            parc.ListCars();

            parc.LouerVoiture(1);

            parc.ArreterLocation(1);

        }
    }
}