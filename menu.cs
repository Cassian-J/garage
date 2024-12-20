using System;

namespace Garage
{
    public class Menu
    {
        Parc garage = new Parc();
        CarContainer carDataHandler = new CarContainer();

        public Menu()
        {
            try
            {
                var dataStore = carDataHandler.LoadFromFile("save.txt");
                garage.DataGetter(dataStore);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Aucun file de sauvegarde trouvé. Une nouvelle base de données sera créée.");
            }
        }

        public void Print()
        {
            while (true)
            {
                carDataHandler.DataSeter(garage.GetList(), garage.GetDictionnary());
                carDataHandler.SaveToFile("save.txt");
                Console.Clear();

                Console.WriteLine("=== GESTION DU GARAGE ===");
                Console.WriteLine("[1] Ajouter une voiture");
                Console.WriteLine("[2] Ajouter une marque");
                Console.WriteLine("[3] Ajouter un modèle");
                Console.WriteLine("[4] Louer une voiture");
                Console.WriteLine("[5] Rendre une voiture");
                Console.WriteLine("[6] Lister les voitures");
                Console.WriteLine("[7] Lister les brands");
                Console.WriteLine("[8] Lister les modèles");
                Console.WriteLine("[9] Quitter");
                Console.WriteLine("==========================");
                Console.Write("Veuillez choisir une option: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1: AjouterVoiture(); break;
                        case 2: AjouterMarque(); break;
                        case 3: AjouterModele(); break;
                        case 4: LouerVoiture(); break;
                        case 5: RendreVoiture(); break;
                        case 6: ListerVoitures(); break;
                        case 7: ListerMarques(); break;
                        case 8: ListerModeles(); break;
                        case 9: Quitter(); return;
                        default:
                            Console.WriteLine("Option invalide, veuillez réessayer.");
                            Pause();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrée non valide. Veuillez entrer un nombre.");
                    Pause();
                }
            }
        }

        private void AjouterVoiture()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter une voiture ===");

            while (true)
            {
                Console.Write("Entrez la marque (ou \"exit\" pour annuler): ");
                string? brandName = Console.ReadLine();
                if (brandName == "exit") return;
                if (string.IsNullOrWhiteSpace(brandName)) continue;

                Console.Write("Entrez le modèle: ");
                string? modelName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(modelName)) continue;

                Console.Write("Entrez l'année de fabrication: ");
                if (int.TryParse(Console.ReadLine(), out int manufactureYear))
                {
                    garage.AddCars(brandName, modelName, manufactureYear);
                    Console.WriteLine("🚗 Voiture ajoutée avec succès !");
                    Pause();
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Année invalide. Veuillez réessayer.");
                }
            }
        }

        private void AjouterMarque()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter une marque ===");

            Console.Write("Entrez le nom de la marque: ");
            string? newBrand = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newBrand))
            {
                garage.AddBrand(newBrand);
                Console.WriteLine("🏁 Marque ajoutée avec succès !");
            }
            else
            {
                Console.WriteLine("❌ Nom de marque invalide.");
            }
            Pause();
        }

        private void AjouterModele()
        {
            Console.Clear();
            Console.WriteLine("=== Ajouter un modèle ===");

            Console.Write("Entrez le nom de la marque: ");
            string? brandId = Console.ReadLine()?.Trim();

            var brands = garage.GetDictionnary();
            if (string.IsNullOrWhiteSpace(brandId) || !brands.ContainsKey(brandId))
            {
                Console.WriteLine("❌ La marque spécifiée n'existe pas.");
                Pause();
                return;
            }

            Console.Write("Entrez le nom du modèle: ");
            string? newModel = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(newModel))
            {
                garage.AddModel(newModel, brandId);
                Console.WriteLine("🚗 Modèle ajouté avec succès !");
            }
            else
            {
                Console.WriteLine("❌ Nom de modèle invalide.");
            }
            Pause();
        }

        private void LouerVoiture()
        {
            Console.Clear();
            Console.WriteLine("=== Louer une voiture ===");
            garage.ListCars();

            Console.Write("Entrez l'ID de la voiture à louer: ");
            if (int.TryParse(Console.ReadLine(), out int idRentCar))
            {
                garage.LouerVoiture(idRentCar);
            }
            else
            {
                Console.WriteLine("❌ ID invalide.");
            }
            Pause();
            }
        private void RendreVoiture()
        {
            Console.Clear();
            Console.WriteLine("=== Rendre une voiture ===");
            garage.ListCars();

            Console.Write("Entrez l'ID de la voiture à rendre: ");
            if (int.TryParse(Console.ReadLine(), out int idReturnedCar))
            {
                garage.ArreterLocation(idReturnedCar);
            }
            else
            {
                Console.WriteLine("❌ ID invalide.");
            }
            Pause();
        }

        private void ListerVoitures()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des voitures ===");
            garage.ListCars();
            Pause();
        }

        private void ListerMarques()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des brands ===");
            garage.ListBrands();
            Pause();
        }

        private void ListerModeles()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des modèles ===");
            garage.ListModels();
            Pause();
        }

        private void Quitter()
        {
            Console.Clear();
            Console.WriteLine("Merci d'avoir utilisé le gestionnaire de garage !");
            Console.WriteLine("👋 À bientôt !");
            Console.ReadKey();
        }

        private void Pause()
        {
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }
}