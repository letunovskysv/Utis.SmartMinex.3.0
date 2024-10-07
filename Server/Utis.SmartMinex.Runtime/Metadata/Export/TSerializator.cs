//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TSerializator –
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public class TSerializator
{
    /// <summary> Настройки JSON-сериализатора.</summary>
    static readonly JsonSerializerOptions _jsonOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        PropertyNamingPolicy = new XLowerCaseNamingPolicy(),
        PropertyNameCaseInsensitive = true,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        WriteIndented = false,
        Converters = { new SystemTypeConverter(), new TTypeConverter() }
    };

    /// <summary> Настройки JSON-сериализатора.</summary>
    static readonly JsonSerializerOptions _jsonTextOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        PropertyNamingPolicy = new XLowerCaseNamingPolicy(),
        PropertyNameCaseInsensitive = true,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        WriteIndented = true,
        Converters = { new SystemTypeConverter(), new TTypeConverter() }
    };

    public static string? SerializeText(object? value) =>
        value == null ? null : JsonSerializer.Serialize(value, _jsonTextOptions);

    public static byte[]? Serialize(object? value) =>
        value == null ? null : Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _jsonOptions));

    /// <summary> Возвращает двоичное значение в виде строки UTF-8.</summary>
    public static T? Deserialize<T>(byte[]? bytes) =>
       bytes == null ? default! : JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(bytes), _jsonOptions);

    #region Nested types

    class XLowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }

    class SystemTypeConverter : JsonConverter<Type?>
    {
        public override Type? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && reader.GetString() is string val)
                return val.ToType(null);

            return default!;
        }

        public override void Write(Utf8JsonWriter writer, Type? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(string.Concat(value.Name, ", ", value.Assembly.GetName().Name));
        }
    }

    class TTypeConverter : JsonConverter<TType>
    {
        public override TType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
                return (TType)reader.GetInt64();

            else if (reader.TokenType == JsonTokenType.String && reader.GetString() is string val)
                return (TType)long.Parse(val);

            return TType.Unknown;
        }

        public override void Write(Utf8JsonWriter writer, TType value, JsonSerializerOptions options) =>
            writer.WriteNumberValue((long)value);
    }

    #endregion Nested types
}

class StringEnumConverter<T> : JsonConverter<T> where T : Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && reader.GetString() is string val)
            return (T)Enum.Parse(typeof(T), val, true);

        else if (reader.TokenType == JsonTokenType.Number && reader.GetInt32() is T eval)
            return eval;

        return default!;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        writer.WriteNumberValue(value is int val ? val : 0);
}
