using Newtonsoft.Json;
using System.Collections.Generic;

namespace HitBTC.Net.Requests
{
    /// <summary>
    /// HitBTC socket request
    /// </summary>
    internal class HitBTCSocketRequest
    {
        [JsonProperty("method")]
        public string Method { get; set; } = "";

        [JsonProperty("params")]
        public Dictionary<string, dynamic> Parameters { get; private set; } = new Dictionary<string, dynamic>();

        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        public HitBTCSocketRequest(int id, string action)
        {
            this.Id = id;
            this.Method = action;
        }

        /// <summary>
        /// Add parameter to request
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParameter(string key, dynamic value)
        {
            this.Parameters.Add(key, value);
        }
    }
}
