using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace testAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EllieController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public EllieController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "ellie")]
        public string Get()
        {
            return "Ellie ist toll";
        }
    }
}