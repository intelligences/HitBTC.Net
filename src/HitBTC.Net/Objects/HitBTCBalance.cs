using Newtonsoft.Json;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// Information about a balance
    /// </summary>
    public class HitBTCBalance
    {
        /// <summary>
        /// Currency name
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; private set; }

        /// <summary>
        /// Amount available for trading or transfer to main account
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; private set; }

        /// <summary>
        /// Amount reserved for active orders or incomplete transfers to main account
        /// </summary>
        [JsonProperty("reserved")]
        public decimal Reserved { get; private set; }
    }
}
