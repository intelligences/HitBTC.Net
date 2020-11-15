using Newtonsoft.Json;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// Information about comission
    /// </summary>
    public class HitBTCComission
    {
        /// <summary>
        /// Default fee rate
        /// </summary>
        [JsonProperty("takeLiquidityRate")]
        public decimal TakeLiquidityRate { get; private set; }

        /// <summary>
        /// Default fee rate for market making trades
        /// </summary>
        [JsonProperty("provideLiquidityRate")]
        public decimal ProvideLiquidityRate { get; private set; }
    }
}
