namespace HitBTC.Net.Requests
{
    /// <summary>
    /// UnSubscribe from order book updates
    /// </summary>
    internal class UnSubscribeOrderBookRequest : HitBTCSocketRequest
    {
        private readonly string symbol;

        public UnSubscribeOrderBookRequest(int id, string symbol) : base(id, "unsubscribeOrderbook")
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
