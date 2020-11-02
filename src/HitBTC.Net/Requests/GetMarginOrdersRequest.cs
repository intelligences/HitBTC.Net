namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Get margin orders request
    /// </summary>
    internal class GetMarginOrdersRequest : HitBTCSocketRequest
    {
        public GetMarginOrdersRequest(int id) : base(id, "marginOrdersGet")
        {
        }
    }
}
