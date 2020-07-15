using E = System.Enum;
using System.Runtime.Serialization;

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
    }

}
