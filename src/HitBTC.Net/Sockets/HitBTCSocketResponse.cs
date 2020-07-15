using Newtonsoft.Json;

namespace HitBTC.Net.Sockets
{
    internal class HitBTCSocketResponse<T>
    {
        [JsonProperty("error")]
        public HitBTCSocketError? Error { get; set; }
        [JsonProperty("result")]
        public T Result { get; set; } = default!;
        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}
