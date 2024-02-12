using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDashboard.Api.Models;

namespace WeatherDashboard.Api.Tests.Fixtures
{
    public static class WeatherDataFixture
    {
        public static WeatherData GetWeatherData() =>
           new WeatherData()
           {
               Name = "London",
               Main = new Main()
               {
                   Temp = 12, // Assuming Temperature is meant to represent Temp
                   Humidity = 1
               },
               Weather = new List<Weather>()
                {
                    new Weather()
                    {
                        Icon = "" // Assuming you meant to set an empty string for the icon
                    }
                },
               Wind = new Wind()
               {
                   Speed = 12 // Assuming WindSpeed represents Speed
               },
               
               Sys = new SystemInfo()
               {
                   Id = 2075535,
                   Country = "GB"
               }

           };
    }
}
