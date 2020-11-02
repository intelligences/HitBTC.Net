namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get symbol
    /// </summary>
    internal class GetMarginAccountsRequest : HitBTCSocketRequest
    {
        public GetMarginAccountsRequest(int id) : base(id, "marginAccountsGet")
        {
        }
    }
}
