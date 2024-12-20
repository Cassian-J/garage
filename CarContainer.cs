namespace Garage
{
    public class CarContainer
    {
        public (List<Car> ListCars, Dictionary<string, List<string>> Models) Data;

        public void DataSeter(List<Car> listCars, Dictionary<string, List<string>> brandsModels)
        {
            Data = (listCars, brandsModels);
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
                throw new FileNotFoundException("Le file spécifié n'existe pas.");

            var listCars = new List<Car>();
            var brandsModels = new Dictionary<string, List<string>>();

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
                            string brandName = parts[0];
                            string modelName = parts[1];
                            int manufactureYear = int.Parse(parts[2]);
                            int carId = int.Parse(parts[3]);
                            bool isRented = bool.Parse(parts[4]);
                            listCars.Add(new Car(brandName, modelName, manufactureYear, carId, isRented));
                        }
                    }
                    else if (readingModels)
                    {
                        var parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            var key = parts[0];
                            var values = parts[1].Split(',');
                            brandsModels[key] = new List<string>(values);
                        }
                    }
                }
            }

            Data = (listCars, brandsModels);
            return Data;
        }
    }
}
