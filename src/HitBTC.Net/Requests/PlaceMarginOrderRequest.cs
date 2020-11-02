using HitBTC.Net.Enum;

namespace HitBTC.Net.Requests
{
    /// <summary>
    /// Place new margin order
    /// </summary>
    internal class PlaceMarginOrderRequest : HitBTCSocketRequest
    {
        public PlaceMarginOrderRequest(
            int id,
            string clientOrderId,
            string symbol,
            HitBTCSide side,
            HitBTCOrderType type,
            decimal price,
            decimal quantity,
            decimal stopPrice = -1,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.GTC,
            bool strictValidate = true
        ) : base(id, "marginOrderNew") {
            this.AddParameter("clientOrderId", clientOrderId);
            this.AddParameter("symbol", symbol);
            this.AddParameter("side", side.ToString().ToLower());
            this.AddParameter("type", type.ToString().ToLower());
            this.AddParameter("price", price);
            this.AddParameter("quantity", quantity);
            this.AddParameter("stopPrice", stopPrice);
            this.AddParameter("timeInForce", timeInForce.ToString());
            this.AddParameter("strictValidate", strictValidate);
        }
    }
}
