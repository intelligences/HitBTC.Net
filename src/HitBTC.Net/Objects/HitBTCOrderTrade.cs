using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    public class HitBTCOrderTrade
    {
        /// <summary>
        /// Trade id
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; private set; }
        
        /// <summary>
        /// Trade position id
        /// </summary>
        [JsonProperty("position_id")]
        public long PositionId { get; private set; }
        
        /// <summary>
        /// Trade commission.
        /// Can be negative ('rebate' - reward paid to a trader). See fee currency in the symbol config.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; private set; }
        
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
        /// Liquidity indicator
        /// </summary>
        [JsonProperty("taker")]
        public bool Taker { get; private set; }
        
        /// <summary>
        /// Trade timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; private set; }
    }
}
