//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: StringExpression – Расширение операций со строками.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion Using

namespace Utis.SmartMinex.Data;

/// <summary> Расширение операций со строками.</summary>
public static class StringExpression
{
    /// <summary> Возращает строковое значение из JSON-строки.</summary>
    public static string JsonValue(this string s, string name) =>
        ((JObject)JsonConvert.DeserializeObject(s))[name]?.ToString();

    /// <summary> Возращает булевое значение из JSON-строки.</summary>
    public static T JsonValue<T>(this string s, string name)
    {
        if (typeof(T) == typeof(bool))
        {
            var res = s.JsonValue(name);
            return (T)(object)(!string.IsNullOrWhiteSpace(res) && bool.TryParse(res, out bool val) && val);
        }
        else if (typeof(T) == typeof(string))
        {
            return (T)(object)s.JsonValue(name);
        }
        return default;
    }

    /// <summary> Возращает булевое значение из JSON-строки.</summary>
    public static string[] JsonNames(this string s) =>
        s == null
            ? new string[0]
            : Regex.Matches(s, @"(?<=[\{,]+"")\w+(?=""\:)").Cast<Match>().Select(m => m.Value).ToArray();

    public static string SetJsonValue(this string s, string name, object value)
    {
        try
        {
            var json = (JObject)JsonConvert.DeserializeObject(string.IsNullOrEmpty(s) ? "{}" : s);
            if (json[name] is JValue val)
                val.Value = value;
            else
                json.Add(name, new JValue(value));

            s = json.ToString(Formatting.None);
        }
        catch { }
        return s;
    }

    public static string[] SplitArguments(this string s) =>
        Regex.Matches(s, @"#(?=\d)|(?<=#)\d+|("".*?"")|[=<>]+\s*|(?<=^|\s|[=<>]).*?(?=\s|[=<>]|$)").Cast<Match>()
            .Select(m => m.Value.Trim()).ToArray();

    public static string ToHexString(this string s) =>
        string.Concat(Encoding.UTF8.GetBytes(s).Select(n => n.ToString("X2")));

    public static string ToHexString(this byte[] bytes) =>
        string.Concat(bytes.Select(n => n.ToString("X2")));

    public static byte[] HexToByteArray(this string s) =>
        Regex.Matches(s, @"\w{2}").Cast<Match>().Select(m => byte.Parse(m.Value, NumberStyles.HexNumber)).ToArray();
}