namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Subscribe to order reports
    /// </summary>
    internal class SubscribeOrdersRequest : HitBTCSocketRequest
    {
        public SubscribeOrdersRequest(int id) : base(id, "subscribeReports")
        {
        }
    }
}
