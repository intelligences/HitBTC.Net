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
    public class HitBTCAuthenticationProvider : AuthenticationProvider
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

            return parameters;
        }
    }

    public class HitBTCRestAuthenticationProvider : AuthenticationProvider
    {
        public HitBTCRestAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");
        }

        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, PostParameters postParameterPosition, ArrayParametersSerialization arraySerialization)
        {
            if (!signed)
                return new Dictionary<string, string>();

            if (Credentials.Key == null)
                throw new ArgumentException("ApiKey/Secret needed");

            if (Credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");

            var result = new Dictionary<string, string>();

            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Credentials.Key.GetString() + ":" + Credentials.Secret.GetString()));
            result.Add("Authorization", "Basic " + encoded);

            return result;
        }
    }
}
