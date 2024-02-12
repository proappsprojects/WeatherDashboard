using Microsoft.AspNetCore.Mvc;
using WeatherDashboard.Api.Services;

namespace WeatherDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("cityName")]
        public async Task<IActionResult> GetByCityName(string cityName)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherByCityAsync(cityName);

                if (weatherData.Weather.Count == 0) return NotFound();

                return Ok(weatherData);
            }
            catch (Exception ex)
            {

                return BadRequest($"Error getting weather details from OpenWeather api: {ex.Message}");
            }

        }
    }
}
