namespace Garage
{
    public class Menu
        {
        Parc parc = new Parc();
        CarContainer carContainer= new CarContainer();

        public Menu(){
            carContainer.LoadFromFile("save.txt");
            parc.DataGetter(carContainer.LoadFromFile("save.txt"));
        }
        public void Print()
            {
            
            while(true){
                carContainer.DataSeter(parc.GetList(),parc.GetDictionnary());
                carContainer.SaveToFile("save.txt");
                Console.Clear();
                Console.WriteLine("[1] ajouter une voiture");
                Console.WriteLine("[2] ajouter une marque");
                Console.WriteLine("[3] ajouter un modèle");
                Console.WriteLine("[4] louer un voiture");
                Console.WriteLine("[5] rendre une voiture");
                Console.WriteLine("[6] lister les voitures");
                Console.WriteLine("[7] lister les marques");
                Console.WriteLine("[8] lister les modèles");
                Console.WriteLine("[9] quitter");
                if(int.TryParse(Console.ReadLine(),out int input)){
                    switch (input){
                        case 1:
                            while(true){
                                Console.Clear();
                                Console.WriteLine("quelle est la marque? (ecrivez \"exit\" si vous ne voulez plus ajouté de voiture)");
                                string? brand = Console.ReadLine();
                                if (brand == "exit"){
                                    break;
                                }
                                else if (!string.IsNullOrWhiteSpace(brand)){
                                    Console.WriteLine("quelle le modèle de la voiture??");
                                    string? model = Console.ReadLine();
                                    if (!string.IsNullOrWhiteSpace(model)){
                                        Console.WriteLine("en quelle année a t elle été créé?");
                                        if(int.TryParse(Console.ReadLine(),out int year)){
                                            parc.AddCars(brand,model, year);
                                            break;
                                        }
                                    }
                                    
                                }
                                
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("quelle est la marque?");
                            string? newBrand = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newBrand)){
                                parc.AddBrand(newBrand);
                                }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("quelle est la marque de la voiture que vous voulez ajouter?");
                            string? brandId = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(brandId)){
                                Console.WriteLine("quelest le modèle");
                                string? newModel = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(newModel)){
                                    parc.AddModel(newModel,brandId);
                                    }
                                }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("quel est l'id de la voiture?");
                            if(int.TryParse(Console.ReadLine(),out int idRentCar)){
                                parc.LouerVoiture(idRentCar);
                            }
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("quel est l'id de la voiture?");
                            if(int.TryParse(Console.ReadLine(),out int idRetedCar)){
                                parc.ArreterLocation(idRetedCar);
                            }
                            break;
                        case 6:
                            Console.Clear();
                            parc.ListCars();
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            parc.ListBrands();
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            parc.ListModels();
                            Console.ReadKey();
                            break;

                        default:
                            break;

                    }
                    if (input==9){
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}