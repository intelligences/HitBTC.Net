namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to trades
    /// </summary>
    internal class SubscribeTradesRequest : HitBTCSocketRequest
    {
        private readonly string symbol;

        public SubscribeTradesRequest(int id, string symbol, int limit = 100) : base(id, "subscribeTrades")
        {
            this.symbol = symbol;
            this.AddParameter("symbol", symbol);
            this.AddParameter("limit", limit);
        }

        public string GetSymbol()
        {
            return this.symbol;
        }
    }
}
