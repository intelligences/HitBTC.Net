using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// HitBTC Position
    /// </summary>
    public class HitBTCPosition
    {
        /// <summary>
        /// Position identifier.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        /// Trading symbol.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        /// <summary>
        /// Position quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public decimal Quantity { get; private set; }

        /// <summary>
        /// Unrealized profit and loss valued in currency.
        /// </summary>
        [JsonProperty("pnl")]
        public decimal Pnl { get; private set; }

        /// <summary>
        /// The price of the first transaction that opened a position.
        /// </summary>
        [JsonProperty("priceEntry")]
        public decimal PriceEntry { get; private set; }

        /// <summary>
        /// The market price of the margin call.
        /// </summary>
        [JsonProperty("priceMarginCall")]
        public decimal? PriceMarginCall { get; private set; }

        /// <summary>
        /// The market price of force close.
        /// </summary>
        [JsonProperty("priceLiquidation")]
        public decimal PriceLiquidation { get; private set; }

        /// <summary>
        /// Position creation date and time.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Position last update date and time.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; private set; }
    }
}
