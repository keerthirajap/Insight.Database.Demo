namespace Insight.Database.Demo.Part1.Controllers
{
    using Insight.Database.Demo.Part1.Repository;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository weatherForecastRepository)
        {
            this._weatherForecastRepository = weatherForecastRepository;

            _logger = logger;
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            weatherForecasts = this._weatherForecastRepository.GetAllWeatherForecast();

            return weatherForecasts;
        }

        [HttpGet]
        [Route("GetWeatherForecast-SQL-Attribute-Async")]
        public async Task<List<WeatherForecast>> GetAllWeatherForecastAsync()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            weatherForecasts = await this._weatherForecastRepository.GetAllWeatherForecastAsync();

            return weatherForecasts;
        }

        [HttpPost]
        [Route("AddWeatherForecasts")]
        public async Task<IActionResult> AddWeatherForecastsAsync([FromBody] List<WeatherForecast> weatherForecasts)
        {
            await this._weatherForecastRepository.AddWeatherForecastsAsync(weatherForecasts);

            return Ok();
        }

        [HttpPost]
        [Route("GetAddWeatherForecastsAndSummary")]
        public async Task<IActionResult> GetAddWeatherForecastsAndSummaryAsync([FromBody] List<WeatherForecast> weatherForecasts_new)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            List<SummaryDim> summaries = new List<SummaryDim>();

            var result = await this._weatherForecastRepository.GetAddWeatherForecastsAndSummaryAsync(weatherForecasts_new);

            weatherForecasts = result.Set1.ToList();
            summaries = result.Set2.ToList();

            dynamic returnVal = new System.Dynamic.ExpandoObject();
            returnVal.weatherForecasts = weatherForecasts;
            returnVal.summaries = summaries;

            return Ok(returnVal);
        }
    }
}