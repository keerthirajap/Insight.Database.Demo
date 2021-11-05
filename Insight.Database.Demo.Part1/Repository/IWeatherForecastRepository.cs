namespace Insight.Database.Demo.Part1.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IWeatherForecastRepository
    {
        List<WeatherForecast> GetAllWeatherForecast();
    }
}