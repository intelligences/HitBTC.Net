namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get balances request
    /// </summary>
    internal class GetTradingBalanceRequest : HitBTCSocketRequest
    {
        public GetTradingBalanceRequest(int id) : base(id, "getTradingBalance")
        {
        }
    }
}
