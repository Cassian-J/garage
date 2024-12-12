using System;
using Garage;

namespace Garage
{
    class Menu
    {
        static void Print(){
            Parc parc = new Parc();
            while(true){
                Console.WriteLine("[1] add a car");
                Console.WriteLine("[2] rent a car");
                Console.WriteLine("[3] return a car");
                Console.WriteLine("[4] list all the cars");
                Console.WriteLine("[5] quit");
                if(int.TryParse(Console.ReadLine(),out int input)){
                    if (input == 1){
                        while(true){
                            string brand = Console.ReadLine();
                            string model = Console.ReadLine();
                            if(int.TryParse(Console.ReadLine(),out int id)){
                                if(int.TryParse(Console.ReadLine(),out int year)){
                                    parc.AddCars(brand,model,id, year);
                                    break;
                                }
                            }
                        }
                        
                        
                        
                    }
                    else if (input == 2){
                        Console.WriteLine("what is the id of the car?");
                        if(int.TryParse(Console.ReadLine(),out int id)){
                            parc.LouerVoiture(id);
                        }
                    }
                    else if (input == 3){
                        Console.WriteLine("what is the id of the car?");
                        if(int.TryParse(Console.ReadLine(),out int id)){
                            parc.ArreterLocation(id);
                        }
                    }
                    else if (input == 4){
                        parc.ListCars();
                    }
                    else if (input == 5){
                        break;
                    }
                };
            }
        }
    }
}