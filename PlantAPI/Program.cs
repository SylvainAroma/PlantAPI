using Microsoft.AspNetCore.Mvc;
using PlantAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/hi", () => "Hi there!");

app.MapPost("/addplant", (Plant p) =>
{
    string folder = @"D:\Net6\PlantAPI\PlantAPI";
    string fileName = "MyPlants.txt";

    Directory.CreateDirectory(folder);

    var pathString = Path.Combine(folder, fileName);

    if (!File.Exists(pathString))
    {
        using (var fs = File.Create(pathString))
        {
        }
    }

    using StreamWriter file = new(fileName, append: true);
    //file.WriteLine(s);

});

//integrate NASA API

//app.UseRouting();


app.Run();