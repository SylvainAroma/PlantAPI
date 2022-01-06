using PlantAPI;
using PlantAPI.Models.Helpers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/getplants", () =>
{
    return FileHelpers.GetPlants();
});

app.MapPost("/addplant", (Plant plant) =>
{
    return FileHelpers.WritePlants(plant);
});

app.MapGet("/clearplants", () => FileHelpers.ClearPlants());

app.MapGet("/apod", async () =>
{
    var uri = ("https://api.nasa.gov/planetary/apod?api_key=XySfp6ledMV8Pb472Hyc0inAi8ekYcPGifqb7NMK");
    var apiHelper = new ApiHelper();

    var content = await apiHelper.GetAstronomyPictureOfTheDay(uri);

    return content;
});

//app.UseRouting();

app.Run();