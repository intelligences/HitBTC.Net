using HitBTC.Net.Enum;
using Newtonsoft.Json;

namespace HitBTC.Net.Filters
{
    public class CandlesRequestFilter
    {
        /// <summary>
        /// Comma-separated list of symbol codes. Optional parameter
        /// </summary>
        [JsonProperty("symbols")]
        public string Symbols { get; set; }

        /// <summary>
        /// Candles time frame
        /// </summary>
        [JsonProperty("period")]
        public HitBTCPeriod Period { get; set; }

        /// <summary>
        /// Sort direction.
        /// </summary>
        /// <remarks>Accepted values: DESC, ASC. Default value: DESC</remarks>
        [JsonProperty("sort")]
        public HitBTCSortType? Sort { get; set; }

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
