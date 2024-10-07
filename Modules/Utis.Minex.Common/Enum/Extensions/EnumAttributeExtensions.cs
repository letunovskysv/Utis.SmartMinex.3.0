using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Enum.Extensions
{
    public static class EnumAttributeExtensions
    {
        public static T GetAttribute<T>(this System.Enum value) where T : Attribute
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.Length == 0)
                return null;
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
    }
}
