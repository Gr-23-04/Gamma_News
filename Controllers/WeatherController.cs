using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;
        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city = "linköping")
        {
            var weather = await _weatherService.GetWeatherAsync(city);
            return View(weather);
        }
        public async Task<IActionResult> details(string city = "linköping")
        {
            var weather = await _weatherService.GetWeatherAsync(city);
            return View(weather);
        }
    }
}
