//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SqlExtensions –
//--------------------------------------------------------------------------------------------------
#region Using
using Newtonsoft.Json;
using System.Text;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public static class SqlExtensions
{
    /// <summary> Возвращает форматированное UTC значение даты/времени.</summary>
    public static string ToSqlDatetime(this DateTime datetime) =>
       string.Concat("'", datetime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ"), "'");

    /// <summary> Возвращает версию записи, UTC-метку времени.</summary>
    public static long ToSqlTimestamp(this DateTime datetime) =>
       datetime.ToFileTimeUtc();

    /// <summary> Возвращает строку в виде двоичного значения.</summary>
    public static string ToSqlBinary(this string? text) =>
       text == null ? "NULL" : string.Concat("'\\x", string.Concat(Encoding.UTF8.GetBytes(text).Select(b => b.ToString("X2"))), "'");

    /// <summary> Возвращает строку в виде двоичного значения.</summary>
    public static string ToSqlBinary(this byte[]? span) =>
       span == null ? "NULL" : string.Concat("'\\x", string.Concat(span.Select(b => b.ToString("X2"))), "'");

    /// <summary> Возвращает строку в виде двоичного значения.</summary>
    public static byte[]? ToBinary(this string? text) =>
       text == null ? null : Encoding.UTF8.GetBytes(text);

    /// <summary> Возвращает двоичное значение в виде строки UTF-8.</summary>
    public static string? ToText(this byte[]? bytes) =>
       bytes == null ? null : Encoding.UTF8.GetString(bytes);
}
