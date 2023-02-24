using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        
        [HttpGet("getNum",Name = "getNumas")]
        public int[] GetNum()
        {
            return new int[] {1,2,3};
        }


        [HttpGet("getNum/{id}", Name = "getNuma")]
        public int GetNum(int id)
        {
            int[] a = { 1, 2, 3 };
            return a[id];
        }

        [HttpGet("getTimezone", Name = "getTimezone")]
        public async Task<object> GetTimeZone(double lat, double lang)
        {

            HttpClient client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync($"https://www.timeapi.io/api/Time/current/coordinate?latitude={lat}&longitude={lang}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            

            return JsonSerializer.Deserialize<object>(responseBody); ;
        }

        [HttpGet("ellie", Name = "ellie")]
        public string ellie()
        {
            return "Ellie ist toll";
        }


    }
}