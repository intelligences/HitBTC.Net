namespace HitBTC.Net.Requests
{
    internal class CancelMarginOrdersRequest : HitBTCSocketRequest
    {
        public CancelMarginOrdersRequest(int id) : base(id, "cancelOrder")
        {
        }
    }
}
