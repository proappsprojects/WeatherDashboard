
using System.Net.Http;

namespace WeatherDashboard.Api.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }
    }
}
