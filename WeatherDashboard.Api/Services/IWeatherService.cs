using WeatherDashboard.Api.Models;

namespace WeatherDashboard.Api.Services
{
    public interface IWeatherService
    {
        public Task<WeatherData> GetWeatherByCityAsync(string cityName);
    }
}
