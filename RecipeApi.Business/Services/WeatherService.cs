using RecipeApi.Business.Interfaces;
using RecipeApi.Shared.Entities;
using Microsoft.Extensions.Logging;
using RecipeApi.Data.Interfaces;

namespace RecipeApi.Business.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILogger<WeatherService> _logger;
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(ILogger<WeatherService> logger, IWeatherRepository weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
        {
            _logger.LogInformation("WeatherService.GetWeatherAsync");
            return await _weatherRepository.GetWeatherForecastsAsync();            
        }
        public async Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
        {
            _logger.LogInformation("WeatherService.GetWeatherByIdAync");
            return await _weatherRepository.GetWeatherForecastByIdAsync(id);
        }
    }
}
