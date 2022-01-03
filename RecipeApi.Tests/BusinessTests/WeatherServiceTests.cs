using RecipeApi.Business.Interfaces;
using RecipeApi.Business.Services;
using RecipeApi.Data.TestRepositories;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RecipeApi.Tests.BusinessTests
{
    public class WeatherServiceTests
    {
        private readonly IWeatherService _weatherService;

        public WeatherServiceTests()
        {
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<WeatherService>();
            var weatherRepository = new TestWeatherRepository();
            _weatherService = new WeatherService(logger, weatherRepository);
        }
        [Fact]
        public async Task Test1()
        {
            var weather = await _weatherService.GetWeatherAsync();
            Assert.NotNull(weather);
            Assert.NotStrictEqual(0, weather.Count());
        }

    }
}
