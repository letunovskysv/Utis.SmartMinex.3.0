using System;
using System.Linq;

namespace Utis.Minex.Common.Helpers
{
    public static class GetAttributeHelper
    {
        #region Получение атрибута из Enum

        /// <summary>
        /// Получить атрибут из Enum
        /// </summary>
        /// <typeparam name="T">Тип атрибута</typeparam>
        /// <param name="enumType">Тип Enum</param>
        /// <param name="enumValue">Значение Enum</param>
        /// <returns>Атрибут T</returns>    
        public static TAttribute GetAttribute<TAttribute>(this System.Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = System.Enum.GetName(type, value);
            if (name == null)
                return null;
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        #endregion


        #region GetEnumDisplayName

        private static readonly string[] separator = { ", " };

        private static T GetAttributeByStringEnumValue<T>(Type enumType, string enumValue) where T : Attribute
        {
            var memberInfo =
                enumType.GetMember(enumValue);

            if (memberInfo.Length > 0)
            {
                var attributes =
                    memberInfo[0].GetCustomAttributes(typeof(T), false);

                return (attributes.Length > 0) ? (T)attributes[0] : null;
            }

            return null;
        }

        public static string GetEnumDisplayName<T>(T value) where T : System.Enum
        {
            var enumType = value.GetType();
            var isFlagsAttribute = Attribute.GetCustomAttribute(value.GetType(), typeof(FlagsAttribute)) != null;
            if (isFlagsAttribute)
            {
                string[] someValues = value.ToString().Split(separator, StringSplitOptions.None);
                for (int i = 0; i < someValues.Length; i++)
                {
                    someValues[i] =
                        (GetAttributeByStringEnumValue<DisplayNameAttribute>(enumType, someValues[i])?.DisplayName ?? someValues[i]);
                }

                return string.Join(separator[0], someValues);
            }

            return GetAttributeByStringEnumValue<DisplayNameAttribute>(enumType, value.ToString())?.DisplayName ?? value.ToString();
        }

        #endregion
    }
}
