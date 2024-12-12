using System;

namespace CSharpDiscovery.Quest04
{
    class Program
    {
        static void Main(string[] args)
        {
            Parc parc = new Parc();
            parc.AddCars("Toyota", "Corolla", 1, false, 2020);
            parc.ListCars();

            parc.LouerVoiture(1);

            parc.ArreterLocation(1);

        }
    }
}