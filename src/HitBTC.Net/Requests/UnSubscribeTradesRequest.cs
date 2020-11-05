namespace HitBTC.Net.Requests
{
    /// <summary>
    /// UnSubscribe to trades
    /// </summary>
    internal class UnSubscribeTradesRequest : HitBTCSocketRequest
    {
        private readonly string symbol;

        public UnSubscribeTradesRequest(int id, string symbol) : base(id, "subscribeTrades")
        {
            this.symbol = symbol;
            this.AddParameter("symbol", symbol);
        }

        public string GetSymbol()
        {
            return this.symbol;
        }
    }
}
