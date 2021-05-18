using CryptoExchange.Net.Objects;

namespace HitBTC.Net
{
    public class HitBTCSocketClientOptions : SocketClientOptions
    {
        public HitBTCSocketClientOptions() : base("wss://api.hitbtc.com/api/2/ws")
        {

        }
        public HitBTCSocketClientOptions(string address) : base(address)
        {
            //SocketSubscriptionsCombineTarget = 10;
        }
    }
}
