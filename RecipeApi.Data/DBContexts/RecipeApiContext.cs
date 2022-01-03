using Microsoft.EntityFrameworkCore;
using RecipeApi.Shared.Entities;
using Microsoft.Extensions.Options;
using RecipeApi.Data.Interfaces;

namespace RecipeApi.Data.DBContexts;

public class RecipeApiContext : DbContext , IRecipeApiContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Direction> Directions { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public ConnectionString _connectionString { get; }

    public RecipeApiContext(IOptions<ConnectionString> connectionString)
    {
        _connectionString = connectionString.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite("Data Source=RecipeApi.db");

}


