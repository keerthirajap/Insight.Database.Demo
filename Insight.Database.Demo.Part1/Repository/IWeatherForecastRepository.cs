namespace Insight.Database.Demo.Part1.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IWeatherForecastRepository
    {
        List<WeatherForecast> GetAllWeatherForecast();

        [Sql("[dbo].[P_GetAllWeatherForecast]")]
        Task<List<WeatherForecast>> GetAllWeatherForecastAsync();

        [Sql("[dbo].[P_AddWeatherForecasts]")]
        Task AddWeatherForecastsAsync(List<WeatherForecast> WeatherForecasts);

        [Sql("[dbo].[P_GetAddWeatherForecastsAndSummary]")]
        Task<Results<WeatherForecast, SummaryDim>> GetAddWeatherForecastsAndSummaryAsync(List<WeatherForecast> WeatherForecasts_New);
    }
}