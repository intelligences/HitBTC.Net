using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace HitBTC.Net.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HitBTCSortType
    {
        [EnumMember(Value = "DESC")]
        DESC,

        [EnumMember(Value = "ASC")]
        ASC,
    }
}
