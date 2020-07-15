using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace HitBTC.Net
{
    internal class HitBTCAuthenticationProvider : AuthenticationProvider
    {
        private static long nonce => DateTime.UtcNow.Ticks;
        private readonly HMACSHA256 encryptor;
        private readonly object locker;

        public HitBTCAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");

            locker = new object();
            this.encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(credentials.Secret.GetString()));
        }

        public override Dictionary<string, object> AddAuthenticationToParameters(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, PostParameters postParameterPosition, ArrayParametersSerialization arraySerialization)
        {
            if (!signed)
                return parameters;

            if (Credentials.Key == null || Credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");

            lock (locker)
            {
                parameters.Add("pKey", Credentials.Key.GetString());
                parameters.Add("sKey", Credentials.Secret.GetString());
            }

           //parameters.Add("nonce", nonce);

            return parameters;
        }
    }
}
