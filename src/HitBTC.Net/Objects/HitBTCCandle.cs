using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// Candle
    /// </summary>
    public class HitBTCCandle
    {
        /// <summary>
        /// Candle timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Open price
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; private set; }

        /// <summary>
        /// Close price
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; private set; }

        /// <summary>
        /// Min price
        /// </summary>
        [JsonProperty("min")]
        public decimal Min { get; private set; }

        /// <summary>
        /// Max price
        /// </summary>
        [JsonProperty("max")]
        public decimal Max { get; private set; }

        /// <summary>
        /// Volume in base currency
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; private set; }

        /// <summary>
        /// Volume in quote currency
        /// </summary>
        [JsonProperty("volumeQuote")]
        public decimal VolumeQuote { get; private set; }
    }

}
