using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WeatherApp.Server.DTO;
using WeatherApp.Server.Interfaces;

namespace WeatherApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly OpenWeather _openWeather;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IUrlBuilderInterface _urlBuilder;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<OpenWeather> openWeather,
            IHttpClientFactory factory, IUrlBuilderInterface urlBuilder)
        {
            

            _httpClient = factory.CreateClient("OpenWeatherClient");
            _openWeather = openWeather.Value;
            _urlBuilder = urlBuilder;
            _logger = logger;
        }

        [HttpGet(Name = "RandomWeather")]
        public IEnumerable<WeatherForecast> RandomWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
