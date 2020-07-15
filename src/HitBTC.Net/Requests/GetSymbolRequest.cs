namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get symbol
    /// </summary>
    internal class GetSymbolRequest : HitBTCSocketRequest
    {
        public GetSymbolRequest(int id, string symbol) : base(id, "getSymbol")
        {
            this.AddParameter("symbol", symbol);
        }
    }
}
