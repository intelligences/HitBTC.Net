using HitBTC.Net.Enum;
using Newtonsoft.Json;

namespace HitBTC.Net.Objects
{
    public class HitBTCCandleData
    {
        /// <summary>
        /// Array of candles
        /// </summary>
        [JsonProperty("data")]
        public HitBTCCandle[] Candles { get; private set; }

        /// <summary>
        /// Candles symbol name
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        /// <summary>
        /// Candles period
        /// </summary>
        [JsonProperty("period")]
        public HitBTCPeriod Period { get; private set; }
    }
}
