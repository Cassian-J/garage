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
                Console.WriteLine("[2] louer un voiture");
                Console.WriteLine("[3] rendre une voiture");
                Console.WriteLine("[4] lister les voitures");
                Console.WriteLine("[5] lister les marques");
                Console.WriteLine("[6] lister les modèles");
                Console.WriteLine("[7] quitter");
                if(int.TryParse(Console.ReadLine(),out int input)){
                    switch (input){
                        case 1:
                            while(true){
                                Console.WriteLine("quelle est la marque? (faites [entrée] pour sortir de cette partie)");
                                string? brand = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(brand)){
                                    Console.Clear();
                                    break;
                                }
                                else if (!parc.GetDictionnary().ContainsKey(brand))
                                {
                                    Console.WriteLine("Cette marque n'est pas dans la base de donnée.");
                                }
                                else if (!string.IsNullOrWhiteSpace(brand)){
                                    Console.WriteLine("quelle le modèle de la voiture? (faites [entrée] pour sortir de cette partie)");
                                    string? model = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(model)){
                                        Console.Clear();
                                        break;
                                    }
                                    else if (!parc.GetDictionnary()[brand].Contains(model))
                                    {
                                        Console.WriteLine("Ce modèle n'est pas dans la base de donnée.");
                                    }
                                    if (!string.IsNullOrWhiteSpace(model)){
                                        Console.WriteLine("en quelle année a t elle été créé? (faites [entrée] pour sortir de cette partie)");
                                        if(int.TryParse(Console.ReadLine(),out int year)){
                                            parc.AddCars(brand,model, year);
                                            break;
                                        }else{
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    
                                }
                                
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("quel est l'id de la voiture?");
                            if(int.TryParse(Console.ReadLine(),out int idRentCar)){
                                parc.LouerVoiture(idRentCar);
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("quel est l'id de la voiture?");
                            if(int.TryParse(Console.ReadLine(),out int idRetedCar)){
                                parc.ArreterLocation(idRetedCar);
                            }
                            break;
                        case 4:
                            Console.Clear();
                            parc.ListCars();
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            parc.ListBrands();
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            parc.ListModels();
                            Console.ReadKey();
                            break;

                        default:
                            break;

                    }
                    if (input==7){
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}