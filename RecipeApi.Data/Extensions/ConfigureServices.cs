using Microsoft.Extensions.DependencyInjection;
using RecipeApi.Data.Interfaces;
using RecipeApi.Data.Repositories;
using RecipeApi.Data.DBContexts;

namespace RecipeApi.Data.Extensions;

public static class ConfigureServices
{
    public static void AddData(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWeatherRepository, WeatherRepository>();
        serviceCollection.AddDbContext<RecipeApiContext>();
        serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
    }
}

