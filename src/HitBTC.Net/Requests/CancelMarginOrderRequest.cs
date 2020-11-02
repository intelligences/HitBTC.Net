namespace HitBTC.Net.Requests
{
    internal class CancelMarginOrderRequest : HitBTCSocketRequest
    {
        public CancelMarginOrderRequest(int id, string clientOrderId) : base(id, "marginOrderCancel")
        {
            this.AddParameter("clientOrderId", clientOrderId);
        }
    }
}
