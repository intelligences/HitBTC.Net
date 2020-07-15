using CryptoExchange.Net;
using HitBTC.Net.Interfaces;
using HitBTC.Net.Objects;

namespace HitBTC.Net
{
    public class HitBTCClient : RestClient, IHitBTCClient
    {
        private static HitBTCClientOptions defaultOptions = new HitBTCClientOptions();
        private static HitBTCClientOptions DefaultOptions => defaultOptions.Copy();

        public HitBTCClient()
        {

        }

        public static void SetDefaultOptions(HitBTCClientOptions options)
        {
            defaultOptions = options;
        }

        public void SetApiCredentials(string apiKey, string apiSecret)
        {
            throw new System.NotImplementedException();
        }
    }
}
