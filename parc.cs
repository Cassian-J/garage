using System;

namespace CSharpDiscovery.Quest04
{
    public class parc 
    {
        private List<cars> listcars;

        public Parc()
        {
            voitures = new List<Voiture>();
        }

        public void addcars(string Brand, string Model,int id)
        {
            cars.Add(new Voiture(Brand, Model,));
            Console.WriteLine($"Voiture ajoutée : {Brand} {Model}{}");
        }

    }
}
