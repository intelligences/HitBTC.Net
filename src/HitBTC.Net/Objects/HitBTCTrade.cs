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
        /// Unique identifier for Order as assigned by exchange
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; private set; }
        
        /// <summary>
        /// Unique identifier for Order as assigned by trader
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; private set; }

        /// <summary>
        /// Trading symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }
        
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
        /// Trade commission.
        /// Can be negative ('rebate' - reward paid to a trader). See fee currency in the symbol config.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; private set; }

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

        /// <summary>
        /// Liquidity indicator
        /// </summary>
        [JsonProperty("taker")]
        public bool Taker { get; private set; }

        /// <summary>
        /// Optional parameter. Liquidation trade flag for margin trades
        /// </summary>
        [JsonProperty("liquidation")]
        public bool Liquidation { get; private set; }
    }
}
