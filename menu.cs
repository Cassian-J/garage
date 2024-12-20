namespace Garage
{
    // Classe représentant le menu principal de gestion du garage
    public class Menu
    {
        Parc garage = new Parc();
        CarContainer carDataHandler = new CarContainer();

        // Constructeur : tente de charger les données depuis un fichier
        public Menu()
        {
            try
            {
                var dataStore = carDataHandler.LoadFromFile("save.txt");
                garage.DataGetter(dataStore);
            }
            catch (FileNotFoundException)
            {
                // Message si aucun fichier de sauvegarde n'est trouvé
                Console.WriteLine("Aucun fichier de sauvegarde trouvé. Une nouvelle base de données sera créée.");
            }
        }
        public void Print()
        {
            while (true)
            {
                // Synchronisation des données et sauvegarde dans un fichier
                carDataHandler.DataSeter(garage.GetList(), garage.GetDictionnary());
                carDataHandler.SaveToFile("save.txt");
                Console.Clear();

                // Affiche les options du menu
                Console.WriteLine("=== GESTION DU GARAGE ===");
                Console.WriteLine("[1] Ajouter une voiture");
                Console.WriteLine("[2] Ajouter une marque");
                Console.WriteLine("[3] Ajouter un modèle");
                Console.WriteLine("[4] Louer une voiture");
                Console.WriteLine("[5] Rendre une voiture");
                Console.WriteLine("[6] Lister les voitures");
                Console.WriteLine("[7] Lister les marques");
                Console.WriteLine("[8] Lister les modèles");
                Console.WriteLine("[9] Quitter");
                Console.WriteLine("==========================");
                Console.Write("Veuillez choisir une option: ");

                // Lecture et traitement de l'option choisie
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1: AddCar(); break;
                        case 2: AddBrand(); break;
                        case 3: AddModel(); break;
                        case 4: RentCar(); break;
                        case 5: ReturnCar(); break;
                        case 6: ListCars(); break;
                        case 7: ListBrands(); break;
                        case 8: ListModels(); break;
                        case 9: Quit(); return;
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

        // Méthode pour ajouter une nouvelle voiture
        private void AddCar()
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

        // Méthode pour ajouter une nouvelle marque
        private void AddBrand()
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

        // Méthode pour ajouter un nouveau modèle
        private void AddModel()
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

        // Méthode pour louer une voiture
        private void RentCar()
        {
            Console.Clear();
            Console.WriteLine("=== Louer une voiture ===");
            garage.ListCars();

            Console.Write("Entrez l'ID de la voiture à louer: ");
            if (int.TryParse(Console.ReadLine(), out int idRentCar))
            {
                garage.RentCar(idRentCar);
            }
            else
            {
                Console.WriteLine("❌ ID invalide.");
            }
            Pause();
        }

        // Méthode pour rendre une voiture
        private void ReturnCar()
        {
            Console.Clear();
            Console.WriteLine("=== Rendre une voiture ===");
            garage.ListCars();

            Console.Write("Entrez l'ID de la voiture à rendre: ");
            if (int.TryParse(Console.ReadLine(), out int idReturnedCar))
            {
                garage.ReturnCar(idReturnedCar);
            }
            else
            {
                Console.WriteLine("❌ ID invalide.");
            }
            Pause();
        }

        // Méthode pour lister les voitures
        private void ListCars()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des voitures ===");
            garage.ListCars();
            Pause();
        }

        // Méthode pour lister les marques
        private void ListBrands()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des marques ===");
            garage.ListBrands();
            Pause();
        }

        // Méthode pour lister les modèles
        private void ListModels()
        {
            Console.Clear();
            Console.WriteLine("=== Liste des modèles ===");
            garage.ListModels();
            Pause();
        }

        // Méthode pour quitter le programme
        private void Quit()
        {
            Console.Clear();
            Console.WriteLine("Merci d'avoir utilisé le gestionnaire de garage !");
            Console.WriteLine("👋 À bientôt !");
            Console.ReadKey();
        }

        // Méthode pour ajouter une pause dans l'exécution et attendre une entrée utilisateur
        private void Pause()
        {
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }
}
