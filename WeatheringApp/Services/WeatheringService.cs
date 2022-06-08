using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatheringApp.Models.Service;

namespace Weathering.Services
{
    public class WeatheringService
    {
        public async Task<OpenWeatherData> GetOpenWeather()
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");


            string response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&units=metric&&appid=23ae38f3922855a87b791024ef31457d");

            OpenWeatherData weather = JsonConvert.DeserializeObject<OpenWeatherData>(response);

            return weather;

        }

  
    }
}
