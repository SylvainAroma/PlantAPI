global using ApiModels;
using System.ComponentModel.DataAnnotations;
using PlantAPI.Helpers;
using Microsoft.EntityFrameworkCore;

const string allowAllOrigins = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);

//If your services become large, use extension methods
builder.Services.AddDbContext<Persistence>(opt => opt.UseInMemoryDatabase("PlantList"));
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
app.MapPost("/plant", async (Persistence db, [Required] Plant plant) =>
{
    await db.Plants.AddAsync(plant);
    await db.SaveChangesAsync();
});
app.MapGet("/plants", async Task<List<Plant>> (Persistence db) => await db.Plants.ToListAsync());
app.MapDelete("/plants", async (Persistence db) =>
{
    db.Plants.RemoveRange();
    await db.SaveChangesAsync();
});

//Endpoint calling external API
app.MapGet("/apod", async () => await ApiHelper.GetAstronomyPictureOfTheDay());


app.UseCors(allowAllOrigins);

app.Run();