using CryptoExchange.Net.Interfaces;

namespace HitBTC.Net.Interfaces
{
    public interface IHitBTCSocketClient : ISocketClient
    {
        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
       // void SetApiCredentials(string apiKey, string apiSecret);
    }
}
