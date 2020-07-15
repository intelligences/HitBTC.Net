using CryptoExchange.Net.Objects;

namespace HitBTC.Net.Objects
{
    public class HitBTCClientOptions : RestClientOptions
    {
        /// <summary>
        /// ctor
        /// </summary>
        public HitBTCClientOptions() : base("https://api.hitbtc.com/api/2")
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Сustom url to connect via mirror website</param>
        public HitBTCClientOptions(string baseAddress) : base(baseAddress)
        {

            //LoadInstruments = loadInstrumentIndexes;
            //if (useMultiplexing)
            //{
            //    throw new NotImplementedException("Multiplex client is not implemented yet");
            //}
            //IsTestnet = isTestnet;
            //key.ValidateNotNull(nameof(key));
            //secret.ValidateNotNull(nameof(secret));
            //ApiCredentials = new CryptoExchange.Net.Authentication.ApiCredentials(key, secret);
        }

    }
}