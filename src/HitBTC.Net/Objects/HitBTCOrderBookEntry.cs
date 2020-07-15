using Newtonsoft.Json;

namespace HitBTC.Net.Objects
{
    public class HitBTCOrderBookEntry
    {
        /// <summary>
        /// Level price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; private set; }

        /// <summary>
        /// Level size
        /// </summary>
        [JsonProperty("size")]
        public decimal Size { get; private set; }
    }
}
