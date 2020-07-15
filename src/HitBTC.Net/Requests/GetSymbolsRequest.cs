namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get all symbols from server
    /// </summary>
    internal class GetSymbolsRequest : HitBTCSocketRequest
    {
        public GetSymbolsRequest(int id) : base(id, "getSymbols")
        {
        }
    }
}
