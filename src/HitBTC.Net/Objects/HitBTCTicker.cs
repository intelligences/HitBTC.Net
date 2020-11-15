using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// Ticker
    /// </summary>
    public class HitBTCTicker
    {
        /// <summary>
        /// Best ask price
        /// </summary>
        [JsonProperty("ask")]
        public decimal? Ask { get; private set; }

        /// <summary>
        /// Best bid price
        /// </summary>
        [JsonProperty("bid")]
        public decimal? Bid { get; private set; }

        /// <summary>
        /// Last trade price
        /// </summary>
        [JsonProperty("last")]
        public decimal? Last { get; private set; }

        /// <summary>
        /// Last trade price 24 hours ago
        /// </summary>
        [JsonProperty("open")]
        public decimal? Open { get; private set; }

        /// <summary>
        /// Lowest trade price within 24 hours
        /// </summary>
        [JsonProperty("low")]
        public decimal? Low { get; private set; }

        /// <summary>
        /// Highest trade price within 24 hours
        /// </summary>
        [JsonProperty("high")]
        public decimal? High { get; private set; }

        /// <summary>
        /// Total trading amount within 24 hours in base currency
        /// </summary>
        [JsonProperty("volume")]
        public decimal? Volume { get; private set; }

        /// <summary>
        /// Total trading amount within 24 hours in quote currency
        /// </summary>
        [JsonProperty("volumeQuote")]
        public decimal? VolumeQuote { get; private set; }

        /// <summary>
        /// Last update or refresh ticker timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Symbol nam
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }
    }
}