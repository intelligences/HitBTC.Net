namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to order book updates
    /// </summary>
    internal class SubscribeOrderBookRequest : HitBTCSocketRequest
    {
        private readonly string symbol;

        public SubscribeOrderBookRequest(int id, string symbol) : base(id, "subscribeOrderbook")
        {
            this.symbol = symbol;

            this.AddParameter("symbol", symbol);
        }

        /// <summary>
        /// Get subscribed symbol
        /// </summary>
        /// <returns></returns>
        public string GetSymbol()
        {
            return this.symbol;
        }
    }
}
