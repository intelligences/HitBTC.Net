namespace HitBTC.Net.Requests
{
    internal class CancelOrderRequest : HitBTCSocketRequest
    {
        public CancelOrderRequest(int id, string clientOrderId) : base(id, "cancelOrder")
        {
            this.AddParameter("clientOrderId", clientOrderId);
        }
    }
}
