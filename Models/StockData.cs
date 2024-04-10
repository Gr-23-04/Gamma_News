using System.Text.Json.Serialization;

namespace Gamma_News.Models
{
   public class StockData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("close")]
        public float Close { get; set; }

        [JsonPropertyName("percentChange")]
        public float PercentChange { get; set; }
    }
       

    
}
