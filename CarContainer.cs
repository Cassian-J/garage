namespace Garage
{
    public class CarContainer
    {
        public (List<Car> ListCars, Dictionary<string, List<string>> Models) Data;

        public void DataSeter(List<Car> listCars, Dictionary<string, List<string>> models)
        {
            Data = (listCars, models);
        }

        public void SaveToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("[Cars]");
                foreach (var car in Data.ListCars)
                {
                    writer.WriteLine($"{car.Brand},{car.Model},{car.Year},{car.Id},{car.IsRented}");
                }

                writer.WriteLine("[Models]");
                foreach (var entry in Data.Models)
                {
                    writer.WriteLine($"{entry.Key}:{string.Join(",", entry.Value)}");
                }
            }
        }

        public (List<Car>, Dictionary<string, List<string>>) LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Le fichier spécifié n'existe pas.");

            var listCars = new List<Car>();
            var models = new Dictionary<string, List<string>>();

            using (var reader = new StreamReader(filePath))
            {
                string? line;
                bool readingCars = false;
                bool readingModels = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "[Cars]")
                    {
                        readingCars = true;
                        readingModels = false;
                    }
                    else if (line == "[Models]")
                    {
                        readingModels = true;
                        readingCars = false;
                    }
                    else if (readingCars)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            string brand = parts[0];
                            string model = parts[1];
                            int year = int.Parse(parts[2]);
                            int id = int.Parse(parts[3]);
                            bool isRented = bool.Parse(parts[4]);
                            listCars.Add(new Car(brand, model, year, id, isRented));
                        }
                    }
                    else if (readingModels)
                    {
                        var parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            var key = parts[0];
                            var values = parts[1].Split(',');
                            models[key] = new List<string>(values);
                        }
                    }
                }
            }

            Data = (listCars, models);
            return Data;
        }
    }
}
