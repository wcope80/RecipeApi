using Microsoft.EntityFrameworkCore;
using RecipeApi.Shared.Entities;

namespace RecipeApi.Data.Interfaces;

public interface IRecipeApiContext
{
    DbSet<WeatherForecast> WeatherForecasts { get; set; }
    DBSet<Recipe> Recipes { get; set; }
    DbSet<Direction> Directions { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }
}

