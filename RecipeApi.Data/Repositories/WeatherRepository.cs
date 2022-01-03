using RecipeApi.Data.Interfaces;
using RecipeApi.Shared.Entities;
using RecipeApi.Data.DBContexts;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Data.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ILogger<WeatherRepository> _logger;
        private readonly RecipeApiContext _context;

        public WeatherRepository(ILogger<WeatherRepository> logger, RecipeApiContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<WeatherForecast>> GetWeatherForecastsAsync()
        {
            _logger.LogInformation("GetWeatherForecastsAsync");
            var weather = await _context.WeatherForecasts.ToListAsync();
            return weather;
        }
        public async Task<WeatherForecast> GetWeatherForecastByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"GetWeatherForecastByIdAsync for id: { id }");
                var weatherForecast = await _context.WeatherForecasts.FirstOrDefaultAsync(w => w.Id == id);
                return weatherForecast;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to GetWeatherForecastByIdAsync for id: { id }");
                return null;
            }
        }

    }
}







