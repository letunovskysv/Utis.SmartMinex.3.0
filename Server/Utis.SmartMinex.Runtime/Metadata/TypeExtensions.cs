//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TypeExtensions –
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel;
using System.Reflection;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public static class TypeExtensions
{
    /// <summary> Возвращает тип, если это возможно.</summary>
    public static Type? ToType(this string? value, string? pathAssembly)
    {
        return Type.GetType(value ?? string.Empty,
            (asm) =>
            {
                try // Загружаем только собственные библиотеки -->
                {
                    var entry = Assembly.GetEntryAssembly();
                    var res = Assembly.LoadFrom(Path.Combine(pathAssembly ?? TPath.GetDirectoryName(entry.Location), asm.FullName + ".dll"));
                    return entry.GetName().GetPublicKeyToken().SequenceEqual(res.GetName().GetPublicKeyToken())
                        ? res
                        : null;
                }
                catch
                {
                    return null;
                }
            },
            (asm, ctype, ignoreCase) => asm?.GetType(ctype, false, ignoreCase)
                ?? asm?.GetTypes().FirstOrDefault(t => t.Name.Equals(ctype, StringComparison.OrdinalIgnoreCase)),

            false, true);
    }

    public static string ToCamelString(this string value) =>
        string.Concat(value.Split([' ', '/', '.', ',', '-'], StringSplitOptions.RemoveEmptyEntries)
            .Select(a => a[0].ToString().ToUpper() + (a.Length > 1 ? a[1..].ToLower() : string.Empty)));

    /// <summary> Рекурсивная выборка указанных элементов иерархического списка. Плоский список.</summary>
    public static IEnumerable<T> RecursiveBy<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
    {
        if (source != null)
            foreach (var item in source)
            {
                yield return item;

                if ((selector(item) ?? []).RecursiveBy(selector) is IEnumerable<T> items)
                    foreach (var child in items)
                        yield return child;
            }
    }

    /// <summary> Возвращает значение атрибута Description(...).</summary>
    public static string ToDescription(this Enum value) =>
        value.GetType().GetFields().First(f => f.Name.Equals(value.ToString()))
            .GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() is DescriptionAttribute attr ? attr.Description : value.ToString();
}
