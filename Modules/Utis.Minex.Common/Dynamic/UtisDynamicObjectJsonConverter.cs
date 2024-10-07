using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Utis.Minex.Common
{
    public class IDynamicObjectJsonConverter : JsonConverter<IDynamicObject>
    {
        const char splitter = '|';
        private static readonly MethodInfo GetEnumValueMethod = typeof(IDynamicObjectJsonConverter)
            .GetMethod("GetEnumValue", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(long) }, null);

        public override IDynamicObject Read(ref Utf8JsonReader reader,
                                      Type typeToConvert,
                                      JsonSerializerOptions options)
        {
            var dynObj = IDynamicObject.Create();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dynObj;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException("JsonTokenType ожидался 'PropertyName'");
                }

                var ar = reader.GetString().Split(splitter);
                var propertyName = ar[0];

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new JsonException("Неверное имя свойства");
                }

                Type type = typeof(object);
                if (ar.Length > 1)
                {
                    var sType = ar[1];
                    type = Type.GetType(sType);
                }

                reader.Read();

                var value = ExtractValue(ref reader, options, type);

                dynObj.SetValue(propertyName!, value);
            }

            return dynObj;
        }

        public override void Write(Utf8JsonWriter writer,
                                   IDynamicObject value,
                                   JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var item in value.GetProperties())
            {
                var valTemp = item.Value as object;
                var type = valTemp?.GetType()?? typeof(object);

                var propertyName = $"{item.Key}{splitter}{type.AssemblyQualifiedName}";

                writer.WritePropertyName(propertyName);
                JsonSerializer.Serialize(writer, valTemp, options);
            }
            writer.WriteEndObject();
        }

        private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options, Type type = null)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }
                    return reader.GetString();
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var result))
                    {
                        if (type.IsEnum)
                        {
                            var reflectionGetEnumValue = GetEnumValueMethod.MakeGenericMethod(type);
                            var objectEnumValue = reflectionGetEnumValue.Invoke(this, new object[] { result });

                            return objectEnumValue;
                        }
                        return Convert.ChangeType(result, type);
                    }
                    if (typeof(Single) == type)
                    {
                        return reader.GetSingle();
                    }
                    return reader.GetDecimal();
                case JsonTokenType.StartObject:
                    return JsonSerializer.Deserialize(ref reader, type, options);
                case JsonTokenType.StartArray:
                    var list = new List<object>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        list.Add(ExtractValue(ref reader, options, type));
                    }
                    return list;
                default:
                    throw new JsonException($"'{reader.TokenType}' не поддерживается");
            }
        }
        private object GetEnumValue<T>(long number) where T : struct, System.Enum, IConvertible
        {
            if (System.Enum.GetUnderlyingType(typeof(T)) == typeof(byte))
            {
                if (IsDefined<T>((byte)number, out object enumValue))
                    return enumValue;
            }
            else
            {
                if (IsDefined<T>((int)number, out object enumValue))
                    return enumValue;
            }

            return null;

            bool IsDefined<T>(object num, out object enumValue) where T : struct, System.Enum, IConvertible
            {
                if (System.Enum.IsDefined(typeof(T), num))
                {
                    enumValue = (T)(object)num;
                    return true;
                }
                enumValue = null;
                return false;
            }
        }
    }
}
