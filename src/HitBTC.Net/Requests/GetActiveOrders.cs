namespace HitBTC.Net.Requests
{
    internal class GetActiveOrders : HitBTCSocketRequest
    {
        public GetActiveOrders(int id) : base(id, "getOrders")
        {
        }
    }
}
