//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DataFileConverter – Конвертация типов (моделей) в объекты конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
#endregion Using

namespace Utis.SmartMinex.Utils;

/// <summary> Конвертация типов (моделей) в объекты конфигурации.</summary>
class DataFileConverter
{
    public static void Rebuild()
    {
        long id = 4503599627370496;
        long iter = 281474976710656;
        var files = Directory.GetFiles(@"D:\Projects\Utis.SmartMinex.3.0\Server\Utis.SmartMinex.Configuration\solutions\lantern\data\", "*.*", SearchOption.AllDirectories);
        foreach (var file in files)
            if (!file.EndsWith("folders.json"))
            {
                var f = JsonNode.Parse(File.ReadAllText(file));
                var t = f.Root["objects"][0];
                t["id"] = id;
                long aid = id + 1024;
                foreach (var a in (JsonArray)t["attributes"])
                {
                    a["id"] = aid;
                    aid += 1024;
                }
                using var stream = new FileStream(file, FileMode.Truncate);
                using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions() { Indented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
                JsonSerializerOptions options = new()
                {
                    WriteIndented = true,

                };
                f.WriteTo(writer, options);
                id += iter;
            }
    }
}
