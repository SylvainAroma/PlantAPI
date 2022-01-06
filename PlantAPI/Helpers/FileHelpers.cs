namespace PlantAPI
{
    public static class FileHelpers
    {
        static readonly string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        static readonly string fileName = "MyPlants.txt";
        static readonly string pathString = Path.Combine(folder, fileName);

        public static string[] WritePlants(Plant p)
        {
            Directory.CreateDirectory(folder);

            if (File.Exists(pathString) == false)
            {
                using (var fs = File.Create(pathString)) { }
            }

            using StreamWriter file = new(pathString, true);

            file.WriteLine($"Name: {p.Name} Water Interval: {p.WaterInterval}");

            file.Close();

            return File.ReadAllLines(pathString);
        }

        public static string[] GetPlants()
        {
            return File.ReadAllLines(pathString);
        }

        public static void ClearPlants()
        { 
            File.Delete(pathString);
        }
    }
}
