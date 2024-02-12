namespace WeatherDashboard.Api.Models
{
    public class WeatherData
    {   
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public SystemInfo Sys { get; set; }

    }
}
