using RecipeApi.Data.Interfaces;
using RecipeApi.Shared.Entities;

namespace RecipeApi.Data.TestRepositories;

public class TestWeatherRepository : IWeatherRepository
{
    private List<WeatherForecast> _weatherForecasts = new List<WeatherForecast>()
    {
        new WeatherForecast() { Id = 1, City = "Atlanta", Date = DateTime.Today, TemperatureCelsius = 20},
        new WeatherForecast() { Id = 2, City = "Chicago", Date = DateTime.Today, TemperatureCelsius = 05},
        new WeatherForecast() { Id = 3, City = "Los Angeles", Date = DateTime.Today, TemperatureCelsius = 30},
        new WeatherForecast() { Id = 4, City = "San Antonio", Date = DateTime.Today, TemperatureCelsius = 28}
    };

    public Task<List<WeatherForecast>> GetWeatherForecastsAsync()
    {
        return Task.FromResult(_weatherForecasts);
    }

    public Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
    {
        try
        {
            var weatherForecast = Task.FromResult(_weatherForecasts.FirstOrDefault(w => w.Id == id));
            return weatherForecast;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

           

