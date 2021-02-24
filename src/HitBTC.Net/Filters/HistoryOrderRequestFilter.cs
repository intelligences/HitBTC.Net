using Newtonsoft.Json;

namespace HitBTC.Net.Filters
{
    public class HistoryOrderRequestFilter
    {
        /// <summary>
        /// If set, other parameters will be ignored, including limit and offset.
        /// </summary>
        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        /// <summary>
        /// Optional parameter to filter orders by symbol.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Interval initial value (optional parameter)
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Interval end value (optional parameter)
        /// </summary>
        [JsonProperty("till")]
        public string Till { get; set; }

        /// <summary>
        /// Records per page
        /// </summary>
        /// <remarks>Default value: 100; Max value: 1000</remarks>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Offset records
        /// </summary>
        /// <remarks>Default value: 0; Max value: 100000</remarks>
        [JsonProperty("offset")]
        public int? Offset { get; set; }
    }
}
