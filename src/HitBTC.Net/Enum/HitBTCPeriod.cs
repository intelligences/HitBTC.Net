using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace HitBTC.Net.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HitBTCPeriod
    {
        [EnumMember(Value = "M1")]
        Minute1,
        [EnumMember(Value = "M3")]
        Minute3,
        [EnumMember(Value = "M5")]
        Minute5,
        [EnumMember(Value = "M15")]
        Minute15,
        [EnumMember(Value = "M30")]
        Minute30,
        [EnumMember(Value = "H1")]
        Hour1,
        [EnumMember(Value = "H4")]
        Hour4,
        [EnumMember(Value = "D1")]
        Day1,
        [EnumMember(Value = "D7")]
        Day7,
        [EnumMember(Value = "1M")]
        Month1
    }
}
