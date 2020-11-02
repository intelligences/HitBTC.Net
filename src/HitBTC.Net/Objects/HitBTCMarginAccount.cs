using HitBTC.Net.Enum;
using Newtonsoft.Json;
using System;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// HitBTC margin account
    /// </summary>
    public class HitBTCMarginAccount
    {
        /// <summary>
        /// Symbol
        /// </summary>
        /// <remarks>Trading symbol. Where base currency is the currency of funds reserved on the trading account for positions and quote currency is the currency of funds reserved on a Isolated Margin Account (e.g. "BTCUSD").</remarks>
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        /// <summary>
        /// Margin leverage.
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; private set; }

        /// <summary>
        /// Amount of currency, reserved for margin purpose.
        /// </summary>
        [JsonProperty("marginBalance")]
        public decimal MarginBalance { get; private set; }

        /// <summary>
        /// Amount of currency, reserved for margin orders.
        /// </summary>
        [JsonProperty("marginBalanceOrders")]
        public int MarginBalanceOrders { get; private set; }

        /// <summary>
        /// Amount of currency, reserved for margin position close.
        /// </summary>
        [JsonProperty("marginBalanceRequired")]
        public int MarginBalanceRequired { get; private set; }

        /// <summary>
        /// Account creation date and time.
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Account last update date and time.
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; private set; }

        /// <summary>
        /// Amount of currency, reserved for margin orders.
        /// </summary>
        [JsonProperty("reportType")]
        public HitBTCReportType ReportType { get; private set; }

        /// <summary>
        /// Reason of report
        /// </summary>
        [JsonProperty("reportReason")]
        public HitBTCReportReason ReportReason { get; private set; }

        /// <summary>
        /// Position
        /// </summary>
        [JsonProperty("position")]
        public HitBTCPosition Position { get; private set; }
    }
}
