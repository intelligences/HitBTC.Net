using HitBTC.Net.Enum;
using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    public class HitBTCTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; private set; }

        /// <summary>
        /// Trade price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; private set; }

        /// <summary>
        /// Trade quantity
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; private set; }

        /// <summary>
        /// Trade side sell or buy
        /// </summary>
        [JsonProperty("side")]
        public HitBTCSide Side { get; private set; }

        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }
    }
}
