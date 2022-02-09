global using ApiModels;
using System.ComponentModel.DataAnnotations;
using PlantAPI.Helpers;
using Microsoft.EntityFrameworkCore;

const string allowAllOrigins = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

//If your services become large, use extension methods
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

//Endpoints using file helper
app.MapGet("/getplants", async () => await FileHelpers.GetPlants());
app.MapPost("/addplant", async Task<string[]> ([Required] Plant plant) => await FileHelpers.WritePlants(plant));
app.MapGet("/clearplants", async () => await FileHelpers.ClearPlants());

//Endpoint using database
app.MapGet("/plants", async (Persistence db) => await db.Plants.ToListAsync());

//Endpoint calling external API
app.MapGet("/apod", async () => await ApiHelper.GetAstronomyPictureOfTheDay());


app.UseCors(allowAllOrigins);

app.Run();