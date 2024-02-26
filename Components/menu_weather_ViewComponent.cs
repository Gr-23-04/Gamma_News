using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gamma_News.Components
{
    [ViewComponent(Name = "weather")]
    public class menu_weather_ViewComponent : ViewComponent
    {
        private readonly WeatherService _get_weather;
        public menu_weather_ViewComponent(WeatherService get_weather)
        {
            _get_weather = get_weather;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var weatherData = await GetWeatherDataAsync();

            return View(weatherData);
        }

        private async Task<Weather> GetWeatherDataAsync()
        {
            var weather_comp = await _get_weather.GetWeatherAsync("linköping");

            return weather_comp;
        }
    }

}


