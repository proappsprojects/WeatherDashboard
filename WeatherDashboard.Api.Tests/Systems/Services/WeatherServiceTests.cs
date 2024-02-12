using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using WeatherDashboard.Api.Controllers;
using WeatherDashboard.Api.Models;
using WeatherDashboard.Api.Services;

namespace WeatherDashboard.Api.Tests.Systems.Services
{
    public class WeatherServiceTests
    {

        private const string cityName = "London";
        private const string expectedUri = "https://api.openweathermap.org/data/2.5/weather?q=";
        private const string expectdApiKey = "testApiKey";
        private const string weatherData = "{\"temperature\": 20, \"humidity\": 50, \"windSpeed\": 7.72, \"icon\": 1}";

        [Fact]
        public async Task Should_Return_StatusCode_200_When_Success()
        {
            // Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            var mockHttpClientService = new Mock<IHttpClientService>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockLogger = new Mock<ILogger<WeatherService>>();

            mockConfiguration.Setup(x => x["WeatherMapApiAddress:uri"]).Returns(expectedUri);
            mockConfiguration.Setup(c => c["WeatherMapApiAddress:apiKey"]).Returns(expectdApiKey);

            mockHttpClientService.Setup(service => service.GetAsync(It.IsAny<string>()))
                    .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(weatherData)
                    });

            var sut = new WeatherService(mockHttpClientService.Object, mockConfiguration.Object, mockLogger.Object);

            //Act 
            var result = await sut.GetWeatherByCityAsync(cityName);

            //Assert
            Assert.NotNull(result);
            mockHttpClientService.Verify(s => s.GetAsync(It.IsAny<string>()), Times.Once);

        }
        [Fact]
        public async Task Should_Throw_ArgumentNullException_When_Give_Invalid_CityName()
        {
            // Arrange
            var mockHttpClientService = new Mock<IHttpClientService>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockLogger = new Mock<ILogger<WeatherService>>();

            mockHttpClientService.Setup(s => s.GetAsync(It.Is<string>(c => string.IsNullOrEmpty(c))))
                                .Throws<ArgumentNullException>();

            var sut = new WeatherService(mockHttpClientService.Object, mockConfiguration.Object, mockLogger.Object);

            // Act
            Task result() => sut.GetWeatherByCityAsync(string.Empty);


            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(result);

        }
        
        [Fact]
        public async Task Should_Return_404_When_No_Weather_Data_Found_For_The_Given_City()
        {
            //Arrange
            var mockHttpClientService = new Mock<IHttpClientService>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockLogger = new Mock<ILogger<WeatherService>>();

            string cityName = "NonExistentCity";

            mockHttpClientService
                .Setup(service => service.GetAsync(cityName))
                        .ReturnsAsync(
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound
                    });

            var sut = new WeatherService(mockHttpClientService.Object, mockConfiguration.Object, mockLogger.Object);

            //Act
            Task result() => sut.GetWeatherByCityAsync(cityName);

            //Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(result);

        }

        [Fact]
        public async Task Should_Throw_HttpRequestException_When_ApiCallFails()
        {
            // Arrange
            var mockHttpClientService = new Mock<IHttpClientService>();
            var mockConfiguration = new Mock<IConfiguration>();
            var mockLogger = new Mock<ILogger<WeatherService>>();

            var cityName = "ValidCityButApiFails";
            mockHttpClientService.Setup(s => s.GetAsync(It.IsAny<string>()))
                                 .Throws<HttpRequestException>();

            var sut = new WeatherService(mockHttpClientService.Object, mockConfiguration.Object, mockLogger.Object);

            //Act
            Task result() => sut.GetWeatherByCityAsync(cityName);

            //Assert
            await Assert.ThrowsAsync<HttpRequestException>(result);

        }
    }
}
