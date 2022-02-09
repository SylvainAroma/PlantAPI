using Microsoft.EntityFrameworkCore;

namespace PlantAPI.Helpers;

public class Persistence : DbContext
{
    public Persistence(DbContextOptions options) : base(options) {}
    public DbSet<Plant> Plants { get; set; }
}