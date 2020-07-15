namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get currency
    /// </summary>
    internal class GetCurrencyRequest : HitBTCSocketRequest
    {
        public GetCurrencyRequest(int id, string currency) : base(id, "getCurrency")
        {
            this.AddParameter("currency", currency);
        }
    }
}
