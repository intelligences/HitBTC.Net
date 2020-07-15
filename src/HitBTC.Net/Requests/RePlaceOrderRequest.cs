namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Replace(modify) order request
    /// </summary>
    internal class RePlaceOrderRequest : HitBTCSocketRequest
    {
        public RePlaceOrderRequest(int id, string clientOrderId, string requestClientId, decimal price, decimal quantity) : base(id, "cancelReplaceOrder")
        {
            this.AddParameter("clientOrderId", clientOrderId);
            this.AddParameter("requestClientId", requestClientId);
            this.AddParameter("price", price);
            this.AddParameter("quantity", quantity);
        }
    }
}
