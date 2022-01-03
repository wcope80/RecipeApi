using RecipeApi.Shared.Entities;

namespace RecipeApi.Business.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
        Task<WeatherForecast> GetWeatherForecastByIdAsync(int id);


    }
}
