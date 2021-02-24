using HitBTC.Net.Enum;

namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to trades
    /// </summary>
    internal class SubscribeCandlesRequest : HitBTCSocketRequest
    {
        private readonly string symbol;
        private readonly HitBTCPeriod period;

        public SubscribeCandlesRequest(int id, string symbol, HitBTCPeriod period, int limit = 100) : base(id, "subscribeCandles")
        {
            this.symbol = symbol;
            this.period = period;

            this.AddParameter("symbol", symbol);
            this.AddParameter("period", this.period.GetValue());
            this.AddParameter("limit", limit);
        }

        public string GetSymbol()
        {
            return this.symbol;
        }

        public HitBTCPeriod GetPeriod()
        {
            return this.period;
        }
    }
}
