using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaulController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public PaulController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "paul")]
        public string Get()
        {
            return "Paul lernt Api's zu programmieren";
        }
    }
}
