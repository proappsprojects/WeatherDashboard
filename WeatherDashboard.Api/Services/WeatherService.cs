using Newtonsoft.Json;
using System.Net;
using WeatherDashboard.Api.Models;

namespace WeatherDashboard.Api.Services
{
    /// <summary>
    /// Weather service class to retrieve weather data
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherService> _logger;

        public WeatherService(IHttpClientService httpClientService, IConfiguration configuration, ILogger<WeatherService> logger)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            _logger = logger;
        }
        /// <summary>
        /// Retrieves weather data for a specified city and handles various response scenarios
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<WeatherData> GetWeatherByCityAsync(string cityName)
        {
            _logger.LogInformation("Fetching Weather Details");
            // Check if city name is an empty string or its length is less thean 1
            if (string.IsNullOrWhiteSpace(cityName))
            {
                _logger.LogError($"City name {cityName} cannot be null, empty, or whitespace.");
                throw new ArgumentNullException(nameof(cityName), "City name cannot be null, empty, or whitespace.");                
            }

            try
            {
                var apiAddress = _configuration["WeatherMapApiAddress:uri"];
                var apiKey = _configuration["WeatherMapApiAddress:apiKey"];
                var requestUri = $"{apiAddress}{cityName}&appid={apiKey}";

                var apiResponse = await _httpClientService.GetAsync(requestUri);

                // Check if aspi response was null or invalid
                if (apiResponse == null || apiResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    _logger.LogError($"Weather data for city {cityName} not found.");
                    throw new KeyNotFoundException($"Weather data for city {cityName} not found.");
                }

                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = await apiResponse.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(result);
                    // Check if weatherData is null
                    if (weatherData == null)
                    {
                        _logger.LogError("Weather data is empty.");
                        throw new InvalidOperationException("Weather data is empty.");
                    }
                    _logger.LogInformation("Fetching Weather details completed successfully");
                    return weatherData;
                }
                _logger.LogError($"Weather data API called failed for {cityName} with response status: {apiResponse.StatusCode}.");
                throw new HttpRequestException($"Weather data API called failed for {cityName} with response status: {apiResponse.StatusCode}.");
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it as needed
                _logger.LogError(ex.Message);
                throw new HttpRequestException(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                // Log the exception or handle it as needed
                _logger.LogError(ex.Message);
                throw new KeyNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred: {ex.Message}");
                throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
            }

        }
    }
}
