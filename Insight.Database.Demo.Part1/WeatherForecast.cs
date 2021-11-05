namespace Insight.Database.Demo.Part1
{
    using System;

    public class WeatherForecast
    {
        public int WeatherForecastId { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}