namespace PlantAPI.Helpers;

public static class FileHelpers
{
    private static readonly string Folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    private const string FileName = "MyPlants.txt";
    private static readonly string PathString = Path.Combine(Folder, FileName);

    public static async Task<string[]> WritePlants(Plant p)
    {
        Directory.CreateDirectory(Folder);

        if (File.Exists(PathString) == false)
        {
            await using (var fs = File.Create(PathString)) { }
        }

        await using StreamWriter file = new(PathString, true);

        await file.WriteLineAsync($"Name: {p.Name} Water Interval: {p.WaterTime}");

        file.Close();

        return await File.ReadAllLinesAsync(PathString);
    }

    public static async Task<string[]> GetPlants()
    {
        return await File.ReadAllLinesAsync(PathString);
    }

    public static async Task<string[]> ClearPlants()
    { 
        File.Delete(PathString);
        return await File.ReadAllLinesAsync(PathString);
    }
}