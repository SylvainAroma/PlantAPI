global using PlantAPIModels;
using PlantAPI.Helpers;

const string allowAllOrigins = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

//Endpoints
app.MapGet("/getplants", async () => await FileHelpers.GetPlants());

app.MapPost("/addplant", async (Plant plant) => await FileHelpers.WritePlants(plant));

app.MapGet("/clearplants", async () => await FileHelpers.ClearPlants());

app.MapGet("/apod", async () => await ApiHelper.GetAstronomyPictureOfTheDay());


app.UseCors(allowAllOrigins);

app.Run();