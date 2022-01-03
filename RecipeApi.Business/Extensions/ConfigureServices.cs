using Microsoft.Extensions.DependencyInjection;
using RecipeApi.Business.Interfaces;
using RecipeApi.Business.Services;

namespace RecipeApi.Business.Extensions;

public static class ConfigureServices
{
    public static void AddBusiness(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWeatherService, WeatherService>();
        serviceCollection.AddScoped<IRecipeService, RecipeService>();
    }
}

