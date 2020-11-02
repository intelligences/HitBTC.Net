namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get active orders request
    /// </summary>
    internal class GetActiveOrders : HitBTCSocketRequest
    {
        public GetActiveOrders(int id) : base(id, "getOrders")
        {
        }
    }
}
