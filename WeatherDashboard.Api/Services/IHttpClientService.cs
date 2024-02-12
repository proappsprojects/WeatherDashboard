namespace WeatherDashboard.Api.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
