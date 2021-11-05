namespace Insight.Database.Demo.Part1.UnitTest
{
    using FizzWare.NBuilder;
    using Insight.Database.Demo.Part1.Controllers;
    using Insight.Database.Demo.Part1.Repository;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class Tests
    {
        private WeatherForecastController _weatherForecastController { get; set; }

        private Mock<ILogger<WeatherForecastController>> _logger { get; set; }

        private Mock<IWeatherForecastRepository> _weatherForecastRepository { get; set; }

        [SetUp]
        public void Setup()
        {
            this._weatherForecastRepository = new Mock<IWeatherForecastRepository>();
            this._logger = new Mock<ILogger<WeatherForecastController>>();
        }

        [Test]
        public void WeatherForecastController_Get()
        {
            //Arrange
            List<WeatherForecast> weatherForecasts = Builder<WeatherForecast>.CreateListOfSize(5).Build().ToList();

            this._weatherForecastRepository
             .Setup(m => m.GetAllWeatherForecast())
             .Returns(weatherForecasts);

            this._weatherForecastController = new WeatherForecastController(this._logger.Object, this._weatherForecastRepository.Object);

            //Act
            var result = this._weatherForecastController.Get();

            //Assert

            Assert.AreEqual(result, weatherForecasts);
        }

        [Test]
        public async Task GetAllWeatherForecastAsync()
        {
            //Arrange
            List<WeatherForecast> weatherForecasts = Builder<WeatherForecast>.CreateListOfSize(5).Build().ToList();

            this._weatherForecastRepository
             .Setup(m => m.GetAllWeatherForecastAsync())
             .ReturnsAsync(weatherForecasts);

            this._weatherForecastController = new WeatherForecastController(this._logger.Object, this._weatherForecastRepository.Object);

            //Act
            var result = await this._weatherForecastController.GetAllWeatherForecastAsync();

            //Assert

            Assert.AreEqual(result, weatherForecasts);
        }

        [Test]
        public async Task AddWeatherForecastsAsync()
        {
            //Arrange
            List<WeatherForecast> weatherForecasts = Builder<WeatherForecast>.CreateListOfSize(5).Build().ToList();

            this._weatherForecastRepository
             .Setup(m => m.AddWeatherForecastsAsync(weatherForecasts));

            this._weatherForecastController = new WeatherForecastController(this._logger.Object, this._weatherForecastRepository.Object);

            //Act
            var result = await this._weatherForecastController.AddWeatherForecastsAsync(weatherForecasts);

            //Assert

            Assert.AreEqual(result.GetType(), typeof(OkResult));
        }

        [Test]
        public async Task GetAddWeatherForecastsAndSummaryAsync()
        {
            //Arrange
            List<WeatherForecast> weatherForecasts = Builder<WeatherForecast>.CreateListOfSize(5).Build().ToList();

            List<SummaryDim> summaries = Builder<SummaryDim>.CreateListOfSize(5).Build().ToList();

            var resultSet = new Results<WeatherForecast, SummaryDim>(weatherForecasts, summaries);

            this._weatherForecastRepository
             .Setup(m => m.GetAddWeatherForecastsAndSummaryAsync(weatherForecasts))
             .ReturnsAsync(resultSet);

            this._weatherForecastController = new WeatherForecastController(this._logger.Object, this._weatherForecastRepository.Object);

            //Act
            var result = await this._weatherForecastController.GetAddWeatherForecastsAndSummaryAsync(weatherForecasts);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));
        }
    }
}