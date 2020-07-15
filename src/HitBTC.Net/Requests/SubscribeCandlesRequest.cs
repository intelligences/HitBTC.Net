using HitBTC.Net.Enum;

namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to trades
    /// </summary>
    internal class SubscribeCandlesRequest : HitBTCSocketRequest
    {
        private readonly string symbol;
        private readonly string period;

        public SubscribeCandlesRequest(int id, string symbol, HitBTCPeriod period, int limit = 100) : base(id, "subscribeCandles")
        {
            this.symbol = symbol;
            this.period = period.GetValue();

            this.AddParameter("symbol", symbol);
            this.AddParameter("period", this.period);
            this.AddParameter("limit", limit);
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
