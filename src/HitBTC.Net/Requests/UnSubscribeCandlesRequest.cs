using HitBTC.Net.Enum;

namespace HitBTC.Net.Requests
{
    /// <summary>
    /// UnSubscribe candles
    /// </summary>
    internal class UnSubscribeCandlesRequest : HitBTCSocketRequest
    {
        private readonly string symbol;
        private readonly string period;

        public UnSubscribeCandlesRequest(int id, string symbol, HitBTCPeriod period) : base(id, "unsubscribeCandles")
        {
            this.symbol = symbol;
            this.period = period.GetValue();

            this.AddParameter("symbol", symbol);
            this.AddParameter("period", this.period);
        }

        public string GetSymbol()
        {
            return this.symbol;
        }

        public string GetPeriod()
        {
            return this.period;
        }
    }
}
