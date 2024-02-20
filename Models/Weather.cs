namespace Gamma_News.Models
{
    public class Weather
    {
        public string Summary { get; set; }
        public string City { get; set; }
        public string Lang { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public DateTime Date { get; set;}
        public long UnixTime { get; set; }
        public WeatherIcon Icon { get; set; }
        
    }

    public class WeatherIcon 
    {
       public string Url { get; set; }
        public string Code { get; set; }
    }
}
