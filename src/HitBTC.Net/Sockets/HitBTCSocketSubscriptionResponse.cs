using Newtonsoft.Json;

namespace HitBTC.Net.Sockets
{
    internal class HitBTCSocketSubscriptionResponse<T>
    {
        [JsonProperty("error")]
        public HitBTCSocketError Error { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("params")]
        public T Data { get; set; } = default!;
        [JsonProperty("result")]
        public bool? IsSubscribed { get; set; } = null;
    }
}
