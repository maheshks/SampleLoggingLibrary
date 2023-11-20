using Microsoft.AspNetCore.Mvc;
using Logging.Core;

namespace Logging.Startup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly Logging.Core.ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(Logging.Core.ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _logger.LogInfo("Weather forecast Get method is invoked");

                var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                _logger.LogDebug("Added debug message to investigate the issue");

                _logger.LogWarning("There is warning while running the code");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error details", ex);
            }

            return new List<WeatherForecast>();
        }
    }
}
