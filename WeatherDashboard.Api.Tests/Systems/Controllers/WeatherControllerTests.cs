using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherDashboard.Api.Controllers;
using WeatherDashboard.Api.Models;
using WeatherDashboard.Api.Services;
using WeatherDashboard.Api.Tests.Fixtures;

namespace WeatherDashboard.Api.Tests.Systems.Controllers
{
    public class WeatherControllerTests
    {
        private const string cityName = "London";

        [Fact]
        public async Task Should_Return_StatusCode_200_When_Success()
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(service => service.GetWeatherByCityAsync(It.IsAny<string>()))
                .ReturnsAsync(WeatherDataFixture.GetWeatherData());

            var sut = new WeatherController(mockWeatherService.Object);

            //Act 
            var result = await sut.GetByCityName(cityName) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public async Task Should_Invoke_User_Service_ExactlyOnce_When_Success()
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService
            .Setup(service => service.GetWeatherByCityAsync(It.IsAny<string>()))
            .ReturnsAsync(WeatherDataFixture.GetWeatherData());

            var sut = new WeatherController(mockWeatherService.Object);

            //Act 
            var result = await sut.GetByCityName(cityName) as OkObjectResult;

            //Assert
            mockWeatherService.Verify(service => service.GetWeatherByCityAsync(cityName), Times.Once());
            mockWeatherService.Verify(service => service.GetWeatherByCityAsync(cityName), Times.Exactly(1));

        }

        [Fact]
        public async Task Should_Return_Weather_Details_When_Success()
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(service => service.GetWeatherByCityAsync(It.IsAny<string>()))
                .ReturnsAsync(WeatherDataFixture.GetWeatherData());

            var sut = new WeatherController(mockWeatherService.Object);

            //Act 
            var result = await sut.GetByCityName(cityName) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public async Task Should_Return_404__For_Invalid_City()
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            string testCityName = "NonExistentCity";

            mockWeatherService
                .Setup(service => service.GetWeatherByCityAsync(testCityName))
                              .ReturnsAsync(new WeatherData
                              {
                                  Name = testCityName,
                                  Weather = new List<Weather>(),
                                  Main = new Main(),
                                  Wind = new Wind(),
                                  Sys = new SystemInfo()
                              });

            var sut = new WeatherController(mockWeatherService.Object);

            //Act
            var result = await sut.GetByCityName(testCityName);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.NotNull(notFoundResult); // Further asserts can be added as needed
            Assert.Equal(404, notFoundResult.StatusCode);
        }

    }
}