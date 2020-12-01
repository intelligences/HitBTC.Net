using Newtonsoft.Json;

namespace HitBTC.Net.Filters
{
    public class OrderBookRequestFilter
    {
        /// <summary>
        /// Comma-separated list of symbol codes. Optional parameter
        /// </summary>
        public string Symbols { get; set; }

        /// <summary>
        /// Limit of Order Book levels
        /// </summary>
        /// <remarks>Default value: 100 Set 0 to view full list of Order Book levels.</remarks>
        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
