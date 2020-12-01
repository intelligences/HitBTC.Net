using HitBTC.Net.Enum;
using Newtonsoft.Json;

namespace HitBTC.Net.Filters
{
    public class HistoryTradesRequestFilter
    {
        /// <summary>
        /// Optional parameter to filter active orders by symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Sort direction.
        /// </summary>
        /// <remarks>Accepted values: DESC, ASC. Default value: DESC</remarks>
        [JsonProperty("sort")]
        public HitBTCSortType? Sort { get; set; }

        /// <summary>
        /// Defines filter type.
        /// </summary>
        /// <remarks>Accepted values: timestamp, id. Default value: id</remarks>
        [JsonProperty("by")]
        public HitBTCSortType? By { get; set; }

        /// <summary>
        /// Interval initial value (optional parameter)
        /// </summary>
        /// <remarks>If sorting by timestamp is used, then Datetime, otherwise Number of index value.</remarks>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Interval end value (optional parameter)
        /// </summary>
        /// <remarks>If sorting by timestamp is used, then Datetime, otherwise Number of index value.</remarks>
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

        /// <summary>
        /// Filtering of margin orders
        /// </summary>
        /// <remarks>Accepted values: include, only, 'ignore' Default value: include</remarks>
        [JsonProperty("margin")]
        public string Margin { get; set; }
    }
}
