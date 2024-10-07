using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
#pragma warning disable 1591

namespace Utis.Minex.Common
{
    public static class Extensions
    {
        public static bool StartsWithAny(this string str, params string[] values)
        {
            if (str == null)
            {
                return false;
            }

            if (!values.Any())
            {
                throw new ArgumentException("Не переданны значения в перечисление");
            }

            foreach (var value in values)
            {
                if (str.StartsWith(value))
                {
                    return true;
                }
            }

            return false;
        }

        public static string RemoveRefDTO(this string propertyName)
        {
            var indexName = propertyName.ToLower().IndexOf("refdto");

            if (indexName == -1)
            {
                return propertyName;
            }

            var name = propertyName.Remove(indexName);

            return name;
        }

        /// <summary>
        /// Удаление 'DTO' в конце строки независимо от регистра
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string RemoveDTO(this string propertyName)
        {
            var length = propertyName.Length;
            if (length <= 3)
                return propertyName;

            var subString = propertyName.Substring(length - 3, 3);
            if (subString.ToLower() == "dto")
                return propertyName.Remove(length-3);

            return propertyName;
        }

        public static bool IsNullableType(this Type type, out Type notNullableType)
        {
            notNullableType = type;
            var result = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
            if (result)
                notNullableType = Nullable.GetUnderlyingType(type);

            return result;
        }

        /// <summary>
        /// Конвертирует Enum-объект в Enum заданного типа
        /// </summary>
        /// <typeparam name="TEnum">Тип, в который конвертируется исходный объект Enum</typeparam>
        /// <param name="enumForConvert">Исходное Enum-производное перечисление</param>
        /// <returns></returns>
        public static TEnum ConvertToEnum<TEnum>(this System.Enum enumForConvert)
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Аргументы должны быть типа Enum!");

            var str = System.Enum.GetName(enumForConvert.GetType(), enumForConvert);
            return (TEnum)System.Enum.Parse(typeof(TEnum), str);
        }

        /// <summary>
        /// Сравнение исходной строки со строкой без учёта регистра
        /// </summary>
        /// <remarks>StringComparison.CurrentCultureIgnoreCase</remarks>
        /// <param name="comparable">Сравниваемое значение</param>
        /// <param name="compared">Сравнивающееся значение</param>
        /// <returns>true если строки равны независимо от регистра</returns>
        public static bool EqualsInsensitive(this string comparable, string compared)
        {
            if (comparable == null) return false;

            return comparable.Equals(compared, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Проверка на вхождение подстроки в вызываемой строке
        /// </summary>
        /// <param name="comparable">Сравниваемое значение</param>
        /// <param name="compared">Сравнивающееся значение</param>
        /// <returns>true, если comparable содержит compared независимо от регистра</returns>
        public static bool ContainsInsensitive(this string comparable, string compared)
        {
            return comparable.IndexOf(compared, StringComparison.CurrentCultureIgnoreCase) > -1;
        }

        /// <summary>Возвращает наименование уникального ключа для поля, объявленного в типе declaringtype</summary>
        /// <param name="attr">расширяет атрибут</param>
        /// <param name="declaringtype">тип</param>
        public static string GetUniqueKeyName(this UniqueKeyAttribute attr, Type declaringtype)
        {
            return 
                string.IsNullOrEmpty(attr.UniqueKeyName)    ? 
                $"UQ_{declaringtype.Name}_DefaultUniqueKey" : 
                $"UQ_{declaringtype.Name}_{attr.UniqueKeyName}";
        }

        /// <summary>Возвращает MD5 для строки</summary>
        public static string CalculateMD5Hash(this string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }

        /// <summary>возвращает количество мс от 01.01.1970 00:00:00</summary>
        public static long ToLongMs(this DateTime dt, bool toUTC)
        {
            var dttemp = toUTC ? dt.ToUniversalTime() : dt;
            return
                (long)(dttemp - new DateTime(1970, 01, 01, 0, 0, 0, 0)).TotalMilliseconds;
        }

        /// <summary>Возвращает дату/время=кол-ву мс от 01.01.1970</summary>
        public static DateTime ToDatetime(this long ms, bool toLocalTime)
        {
            var result = new DateTime(1970, 01, 01, 0, 0, 0, 0).AddMilliseconds(ms);
            return
                toLocalTime ? result.ToLocalTime() : result;
        }

        public static DateTime RoundToSeconds(this DateTime dateTime)
        {
            return dateTime.AddTicks(-dateTime.Ticks % TimeSpan.TicksPerSecond);
        }

        public static DateTime RoundToMinutes(this DateTime dateTime)
        {
            return dateTime.AddTicks(-dateTime.Ticks % TimeSpan.TicksPerMinute);
        }

        public static DateTime RoundToHours(this DateTime dateTime)
        {
            long ticks = dateTime.Ticks + 18000000000;
            return new DateTime(ticks - ticks % 36000000000, dateTime.Kind);
        }

        /// <summary>
        /// Возвращает дату начала недели, к которой относится параметр
        /// </summary>
        /// <param name="dt">Дата, которую хотим округлить</param>
        /// <param name="startOfWeek">День недели, с которого начинается неделя</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static bool In(this System.Enum someenum, params System.Enum[] values)
        {
            return values.Contains(someenum);
        }

        /// <summary>
        /// Получение из лямбды функтора
        /// </summary>
        public static Func<T, bool> CompileFunc<T>(this LambdaExpression lambda)
        {
            return (Func<T, bool>)lambda.Compile();
        }

        /// <summary>
        /// приведение объекта к типу по указателю типа
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object Cast(this object obj, Type t)
        {
            try
            {
                var param = Expression.Parameter(obj.GetType());
                return Expression.Lambda(Expression.Convert(param, t), param)
                         .Compile().DynamicInvoke(obj);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public static MemberInfo GetMemberByName(this Type type, string membername)
        {
            IEnumerable<MemberInfo> members = Array.Empty<MemberInfo>();
            if (type.IsInterface)
            {
                var flags = BindingFlags.Public | BindingFlags.Instance;
                members = type
                    .GetInterfaces()
                    .Concat(new Type[] { type})
                    .SelectMany(i => i.GetMembers(flags));
            }
            else
                members = type.GetMembers();

            return members.FirstOrDefault(x => x.Name.EqualsInsensitive(membername));
        }

        /// <summary>
        /// проверка на пустое выражение (void)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsEmpty(this Expression expression)
        {
            return
                expression.NodeType == ExpressionType.Default && expression.Type == typeof(void);
        }

        public static object GetValue(this MemberExpression memberExpression, object obj, params ParameterExpression[] parameters)
        {
            return Expression.Lambda(memberExpression, parameters).Compile().DynamicInvoke(obj);
        }

        /// <summary>
        /// возвращает индекс элемента из массива строк, в котором содержится указанная строка регистронезависимо
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="contains"></param>
        /// <returns></returns>
        public static int IndexOfElement(this IEnumerable<string> strings, string contains)
        {
            return strings.ToList().IndexOf(strings.FirstOrDefault(x => x.IndexOf(contains, StringComparison.OrdinalIgnoreCase) > -1));
        }

        /// <summary>
        /// возвращает является ли тип наследуемым от DateTime
        /// </summary>
        public static bool IsDatetimeType(this Type type)
        {
            return typeof(DateTime).IsAssignableFrom(type) || typeof(DateTime?).IsAssignableFrom(type);
        }

        /// <summary>
        /// возвращает содержит ли вызвавшая строка одну из перечисленных в аргументах строк
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool ContainsOneOf(this string source, params string[] args)
        {
            return
                args.Any(x => source.IndexOf(x, StringComparison.CurrentCultureIgnoreCase) > -1);
        }

        private static string _falseStringBit = "0";
        private static string _trueStringBit = "1";
        private static readonly Func<object, object>[] _parseFuncList
            =
            {
                x =>
                {
                    var strRepresent = x?.ToString();
                    if (strRepresent == bool.FalseString || strRepresent == _falseStringBit)
                    {
                        return false;
                    }

                    if (strRepresent == bool.TrueString || strRepresent == _trueStringBit)
                    {
                        return true;
                    }

                    return null;
                },
                x =>
                {
                    if (long.TryParse(x?.ToString(), out var result)) return result;
                    return null;
                },
                x =>
                {
                    if (double.TryParse(x?.ToString(), out var result)) return result;
                    return null;
                }
            };

        /// <summary>
        /// Преобразует строковое представление простого типа данных в тип (поддерживаются int, double, bool)
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static dynamic ParseValue(this string strvalue)
        {
            object value = null;
            foreach (var func in _parseFuncList)
            {
                value = func(strvalue);
                if (value != null) return value;
            }

            return strvalue;
        }

        /// <summary>
        /// преобразует строковое представление bool(true - 1, false - 0) или long в Enum
        /// </summary>
        public static bool ParseValueToEnum<TEnum>(this string strvalue, out TEnum result) 
            where TEnum : struct
        {
            result = default;
            var processed = false;
            var parseValue = strvalue.ParseValue();
            if (parseValue is bool valueBool)
            {
                result = valueBool
                    ? (TEnum) System.Enum.Parse(typeof(TEnum), "1")
                    : (TEnum) System.Enum.Parse(typeof(TEnum), "0");

                processed = true;
            }
            else if (parseValue is long && System.Enum.TryParse(strvalue, out result))
            {
                processed = true;
            }

            return processed;
        }

        /// <summary>
        /// Преобразует строковое представление в long
        /// </summary>
        public static bool ParseValueToLong(this string strvalue, out long result)
        {
            result = default;

            if (!(strvalue.ParseValue() is long longValue))
                return false;

            result = longValue;

            return true;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string ToTrimLower(this string value)
        {
            return value?.Trim()?.ToLower();
        }

        /// <summary>
        /// Если null, то выбрасывает ArgumentNullException
        /// </summary>
        public static void VerifyNotNullArg<T>(this T obj, string argName = default, string message = default) where T : class
        {
            if (obj == default)
            {
                throw new ArgumentNullException(argName);
            }
        }

        /// <summary>
        /// Если null, то выбрасывает Exception
        /// </summary>
        public static void VerifyNotNull<T>(this T obj, string message) where T : class
        {
            if (obj == default)
            {
                throw new Exception(message);
            }
        }

        /// <summary>
        /// возвращает функтор в типе делегата, вызывающий generic-метод, у которого тип входного параметра совпадает с аргументом типа
        /// </summary>
        /// <param name="instance">объект, содержащий вызываемый generic-метод</param>
        /// <param name="type"></param>
        /// <param name="methodname">вызываемый метод</param>
        /// <returns></returns>
        public static Delegate GetFunc(this object instance, string methodname, Type type)
        {
            var parameter = Expression.Parameter(type);
            var methodcall = Expression.Call(Expression.Constant(instance), instance.GetPrivateGenericMethod(methodname, type), parameter);
            return Expression.Lambda(methodcall, parameter).Compile();
        }

        /// <summary>
        /// возвращает определение generic-метода с указанным типом аргумента
        /// </summary>
        /// <param name="instance">объект, содержащий искомый метод</param>
        /// <param name="methodname">имя метода регистронезависимо</param>
        /// <param name="types">аргументы типа</param>
        /// <returns></returns>
        public static MethodInfo GetPrivateGenericMethod(this object instance, string methodname, params Type[] types)
        {
            return instance
                .GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name.EqualsInsensitive(methodname))
                .MakeGenericMethod(types);
        }

        public static void AddOrUpdate<K, T>(this Dictionary<K, T> dict, K key, T value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        public static void AddOrUpdate<K, T>(this SortedList<K, T> sortedList, K key, T value)
        {
            if (sortedList.ContainsKey(key))
            {
                sortedList[key] = value;
            }
            else
            {
                sortedList.Add(key, value);
            }
        }

        public static void AddOrUpdate<K, T>(this SortedDictionary<K, T> sortedDict, K key, T value)
        {
            if (sortedDict.ContainsKey(key))
            {
                sortedDict[key] = value;
            }
            else
            {
                sortedDict.Add(key, value);
            }
        }

        public static TValue TryGetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            dictionary.TryGetValue(key, out var result);

            if (EqualityComparer<TValue>.Default.Equals(result, default) && !EqualityComparer<TValue>.Default.Equals(defaultValue, default))
                return defaultValue;

            return result;
        }


        public static TObj GetOrCreate<TKey, TObj>(this IDictionary<TKey, TObj> dictionary, TKey key) where TObj : new()
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            value = new TObj();
            dictionary.TryAdd(key, value);
            return value;
        }

        /// <summary>
        /// Удалить все значения по ключам
        /// </summary>
        /// <param name="keys">ключи по которым будут удалены пары из словаря</param>
        public static void TryRemoveKeyAndValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, params TKey[] keys)
        {
            foreach (var key in keys)
            {
                if (dictionary.ContainsKey(key))
                    dictionary.Remove(key);
            }
        }

        public static ConcurrentBag<TValue> AddOrUpdateToConcurrentBag<TKey,TValue>(this ConcurrentDictionary<TKey, ConcurrentBag<TValue>> dict, TKey key, TValue value)
        {
            return dict.AddOrUpdate(
                key,
                k =>
                {
                    var tmp = new ConcurrentBag<TValue>
                    {
                        value
                    };
                    return tmp;
                },
                (k, v) =>
                {
                    v?.Add(value);
                    return v;
                });
        }

        public static MemberInfo[] GetInterfaceMemberByName(this Type type, string name)
        {
            var memberInfo = type.GetMember(name);

            if (memberInfo.Length > 0)
                return memberInfo;

            foreach (var interfaceType in type.GetInterfaces())
            {
                memberInfo = interfaceType.GetInterfaceMemberByName(name);
                if(memberInfo.Length > 0)
                    break;
            }

            return memberInfo;
        }

        public static string ToStringSeparate<T>(this IEnumerable<T> list, char separate)
        {
            var builder = new StringBuilder();
            foreach (var item in list)
                builder.Append(item).Append(separate);

            return 
                builder.ToString();
        }

        public static void AddValueOrThrowException<Tkey, Tval>(this ConcurrentDictionary<Tkey, Tval> dict, Tkey id, Tval val)
        {
            if (!dict.TryAdd(id, val))
            {
                ThrowSyncException(dict.ToString());
            }
        }

        public static void RemoveValueOrThrowException<Tkey, Tval>(this ConcurrentDictionary<Tkey, Tval> dict, Tkey id)
        {
            if (!dict.TryRemove(id, out _))
            {
                ThrowSyncException(dict.ToString());
            }
        }

        private static void ThrowSyncException(string collectionName) => 
            throw new Exception($"Нарушена сихнронизация коллекции {collectionName}!");
    }
}