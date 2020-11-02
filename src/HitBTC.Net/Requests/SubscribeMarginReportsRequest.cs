namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to margin reports (Orders and Account)
    /// </summary>
    /// <remarks>Income methods: `marginOrders`, `marginAccounts`</remarks>
    internal class SubscribeMarginReportsRequest : HitBTCSocketRequest
    {
        public SubscribeMarginReportsRequest(int id) : base(id, "marginSubscribe")
        {
        }
    }
}
