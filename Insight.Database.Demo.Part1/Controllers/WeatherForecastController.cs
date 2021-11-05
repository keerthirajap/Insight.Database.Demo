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

        private readonly DbConnection _sqlConnection;

        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this._sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Insight.Database.Demo;Persist Security Info=true;Integrated Security=true;");

            this._weatherForecastRepository = this._sqlConnection.As<IWeatherForecastRepository>();

            _logger = logger;
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            weatherForecasts = this._weatherForecastRepository.GetAllWeatherForecast();

            return weatherForecasts;
        }
    }
}