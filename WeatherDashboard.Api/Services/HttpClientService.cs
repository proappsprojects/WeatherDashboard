
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
        /// <summary>
        /// Asynchronous wrapper around the HttpClient.GetAsync 
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }
    }
}
