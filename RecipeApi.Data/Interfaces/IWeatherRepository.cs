using RecipeApi.Shared.Entities;

namespace RecipeApi.Data.Interfaces
{
    public interface IWeatherRepository
    {
        Task<List<WeatherForecast>> GetWeatherForecastsAsync();
        Task<WeatherForecast> GetWeatherForecastByIdAsync(int id);
    }
}
