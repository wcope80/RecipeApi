namespace RecipeApi.Shared.Entities
{
    public class WeatherForecast
    {
        public int Id { get; set; } 
        public string City { get; set; } = String.Empty;
        public DateTime Date { get; set; }

        public int TemperatureCelsius { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureCelsius / 0.5556);

    }
}