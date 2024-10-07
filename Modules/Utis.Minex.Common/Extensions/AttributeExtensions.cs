using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Utis.Minex.Common.Enum;

namespace Utis.Minex.Common
{
    public static class AttributeExtensions
    {
        public static T GetAttribute<T>(this ICustomAttributeProvider obj) where T : Attribute
        {
            if (obj != null)
                if (obj.IsDefined(typeof(T), true))
                    return (T)obj.GetCustomAttributes(typeof(T), true).FirstOrDefault();

            return null;
        }

        /// <summary>
        /// Проверка наличия атрибута
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this ICustomAttributeProvider obj, out T attr) where T : Attribute
        {
            attr = null;
            if (obj != null && obj.IsDefined(typeof(T), true))
                    attr = (T)obj.GetCustomAttributes(typeof(T), true).FirstOrDefault();

            return attr != default;
        }

        public static string GetDescription(this ICustomAttributeProvider obj)
        {
            var result = GetAttribute<DescriptionAttribute>(obj)?.Description;

            if (string.IsNullOrEmpty(result))
                result = GetAttribute<System.ComponentModel.DescriptionAttribute>(obj)?.Description;
            
            return result;
        }
        
        public static string GetDisplayName(this ICustomAttributeProvider obj)
        {
            var result = GetAttribute<DisplayNameAttribute>(obj)?.DisplayName;

            if (string.IsNullOrEmpty(result))
                result = GetAttribute<System.ComponentModel.DisplayNameAttribute>(obj)?.DisplayName;
            
            return result;
        }

        /// <summary>
        /// Возвращает содержимое атрибута DisplayName у свойства.
        /// </summary>
        /// <param name="type">Тип</param>
        /// <param name="propertyName">Свойство.</param>
        /// <returns>Содержимое атрибута или null.</returns>
        public static string GetDisplayName(this Type type, string propertyName)
        {
            var info = type.GetProperty(propertyName);

            return info?.GetDisplayName();
        }

        /// <summary>
        /// Возвращает содержимое атрибута DisplayName у значения перечисления.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumvalue"></param>
        /// <returns></returns>
        public static string GetEnumDisplayName<T>(this T enumvalue) where T : System.Enum
        {
            var type = enumvalue.GetType();
            var memberinfo = type.GetMember(enumvalue.ToString()).FirstOrDefault();
            return memberinfo.GetDisplayName();
        }

        /// <summary>
        /// Проверка наличия атрибута
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumvalue"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        public static bool IsHasAttribute<T>(this System.Enum enumvalue, out T attr) 
            where T : Attribute
        {
            var type = enumvalue.GetType();
            var memberinfo =type.GetMember(enumvalue.ToString()).FirstOrDefault();
            return memberinfo.IsHasAttribute<T>(out attr);
        }

        /// <summary>
        /// Конвертация коллекции Enum в одиночное значение аналогично ...|...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enums"></param>
        /// <returns></returns>
        public static T ToCombined<T>(this IEnumerable<T> enums)
            where T : struct, System.Enum
        {
            if (!enums.Any())
                return default(T);

            Type underlyingType = System.Enum.GetUnderlyingType(typeof(T));

            var currentParameter = Expression.Parameter(typeof(T), "current");
            var nextParameter = Expression.Parameter(typeof(T), "next");

            Func<T, T, T> aggregator = Expression.Lambda<Func<T, T, T>>(
                Expression.Convert(
                    Expression.Or(
                        Expression.Convert(currentParameter, underlyingType),
                        Expression.Convert(nextParameter, underlyingType)
                        ),
                    typeof(T)
                    ),
                currentParameter,
                nextParameter
                ).Compile();

            return enums.Aggregate(aggregator);
        }

        /// <summary>
        /// Перевести комбинированное перечисление в коллекцию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToValues<T>(this T flags) where T : struct, System.Enum
        {
            if (IsSingle(flags))
                return new T[] { flags };

            int inputInt = (int)(object)(T)flags;

            var enumCol = new List<T>();
            foreach (T value in System.Enum.GetValues<T>())
            {
                int valueInt = (int)(object)(T)value;

                if (0 != (valueInt & inputInt))
                {
                    if (IsSingle(value))
                        enumCol.Add(value);
                }
            }

            return enumCol;
        }

        /// <summary>
        /// Является ли значение перечисления комбинированным
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSingle<T>(this T value) where T : struct, System.Enum
        {
            var items = System.Enum.GetValues<T>()
                .Where(x=> !x.Equals(value) && Convert.ToInt32(x) > 0);

            if (items.Any(x => value.HasFlag(x)))
                return false;

            return true;
        }

        /// <summary>
        /// Возвращает содержимое атрибута Description у значения перечисления.
        /// </summary>
        public static string GetEnumDescription<T>(this T enumvalue) where T : System.Enum
        {
            var type = typeof(T);
            var memberinfo = type.GetMember(enumvalue.ToString()).FirstOrDefault();
            return memberinfo.GetDescription();
        }


        /// <summary>
        /// Возвращает содержимое всех значений атрибута DisplayName у перечисления 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string[] GetEnumDisplayNames(this Type enumType, bool onlyEditable = true) 
        {
            var values = enumType.GetFields(BindingFlags.Static | BindingFlags.Public)
                    .Where(field => 
                        onlyEditable? 
                            field.GetAttribute<EnumDetailEditable>()?.Editable ?? true : true)
                    .Select(field =>
                    {
                        var fieldValue = (System.Enum)field.GetValue(null);

                        var atr = field.GetAttribute<DisplayNameAttribute>();
                        var name = atr == null
                            ? fieldValue.ToString()
                            : atr.DisplayName;

                        return name;
                    });

            return values.ToArray();
        }

        /// <summary>
        /// Возвращает значение перечисления перечисления по его DisplayName
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="enumDisplayName"></param>
        /// <returns></returns>
        public static dynamic GetValueByDisplayName(this Type enumType, string enumDisplayName)
        {
            var values = System.Enum.GetValues(enumType).Cast<dynamic>();
            foreach (var value in values)
            {
                if (GetEnumDisplayName(value) == enumDisplayName)
                    return value;
            }

            return null;
        }
    }
}