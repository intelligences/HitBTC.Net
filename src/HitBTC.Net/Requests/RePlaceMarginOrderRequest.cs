namespace HitBTC.Net.Requests
{
    /// <summary>
    /// RePlace(modify) margin order request
    /// </summary>
    internal class RePlaceMarginOrderRequest : HitBTCSocketRequest
    {
        public RePlaceMarginOrderRequest(int id, string clientOrderId, string requestClientId, decimal price, decimal quantity) : base(id, "marginOrderCancelReplace")
        {
            this.AddParameter("clientOrderId", clientOrderId);
            this.AddParameter("requestClientId", requestClientId);
            this.AddParameter("price", price);
            this.AddParameter("quantity", quantity);
        }
    }
}
