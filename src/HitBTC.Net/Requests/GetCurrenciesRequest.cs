namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get all currencies from server
    /// </summary>
    internal class GetCurrenciesRequest : HitBTCSocketRequest
    {
        public GetCurrenciesRequest(int id) : base(id, "getCurrencies")
        {
        }
    }
}
