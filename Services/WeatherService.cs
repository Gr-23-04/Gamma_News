using Gamma_News.Models;
using Newtonsoft.Json;
namespace Gamma_News.Services
{
	public class WeatherService
	{
		private readonly HttpClient _httpClient;

		public WeatherService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Weather> GetWeatherAsync(string city)
		{
			//string apiKey = "";//where is the api
			string requestUri = $"https://weatherapi.dreammaker-it.se/Forecast?city={city}&lang=English";
			var response = await _httpClient.GetAsync(requestUri);
			response.EnsureSuccessStatusCode();
			var json = await response.Content.ReadAsStringAsync();
			var weather_json = JsonConvert.DeserializeObject<Weather>(json);
			return weather_json;
		}
	}
}
