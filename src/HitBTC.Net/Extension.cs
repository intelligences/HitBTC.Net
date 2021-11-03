using E = System.Enum;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HitBTC.Net
{
    public static class Extension
    {
        internal static string GetValue(this E value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes?[0] is EnumMemberAttribute enumMemberAttribute)
                return enumMemberAttribute.Value;
            else
                return value.ToString();
        }

        internal static Dictionary<string, object>? ToParametersDictionary(this object? obj)
        {
            if (obj is null)
            {
                return null;
            }

            Dictionary<string, object> parameters = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(obj));

            if (parameters.Count == 0)
            {
                return null;
            }

            return parameters.Where(p => p.Value != null).ToDictionary(p => p.Key, p => p.Value);
        }

        internal static string? ToQueryString(this Dictionary<string, object>? dict)
        {
            if (dict is null)
            {
                return null;
            }

            return string.Join("&", dict.Select(kvp => $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value.ToString())}"));
        }
    }

}
