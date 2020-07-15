using Newtonsoft.Json;

namespace HitBTC.Net.Objects
{
    public class HitBTCTradesData
    {
        /// <summary>
        /// Array of trades
        /// </summary>
        [JsonProperty("data")]
        public HitBTCTrade[] Trades { get; private set; }

        /// <summary>
        /// Trades symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

    }
}
