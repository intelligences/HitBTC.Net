namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Close margin position request
    /// </summary>
    internal class CloseMarginPositionRequest : HitBTCSocketRequest
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="symbol"></param>
        public CloseMarginPositionRequest(
            int id,
            string symbol
        ) : base(id, "marginPositionClose")
        {
            this.AddParameter("symbol", symbol);
        }
    }
}
