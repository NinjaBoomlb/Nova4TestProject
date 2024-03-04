using Newtonsoft.Json;

namespace Nova4TestProject.Models
{
    public class BitcoinInfoBitStamp
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("open")]
        public decimal Open { get; set; }

        [JsonProperty("high")]
        public decimal High { get; set; }

        [JsonProperty("low")]
        public decimal Low { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("vwap")]
        public decimal Vwap { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("side")]
        public int Side { get; set; }

        [JsonProperty("open_24")]
        public decimal Open24 { get; set; }

        [JsonProperty("percent_change_24")]
        public decimal PercentChange24 { get; set; }
    }

}
