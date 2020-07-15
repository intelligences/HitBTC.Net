using CryptoExchange.Net.Objects;

namespace HitBTC.Net
{
    public class HitBTCSocketClientOptions : SocketClientOptions
    {
        public HitBTCSocketClientOptions() : base("wss://api.demo.hitbtc.com/api/2/ws/public")
        {

        }
        public HitBTCSocketClientOptions(string address) : base(address)
        {
            //SocketSubscriptionsCombineTarget = 10;
        }
    }
}
