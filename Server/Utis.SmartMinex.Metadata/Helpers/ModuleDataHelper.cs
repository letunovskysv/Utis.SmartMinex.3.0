//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ModuleDataHelper – Обработчик метаданных модулей, сервисов.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Json.Nodes;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

/// <summary> Обработчик метаданных модулей, сервисов.</summary>
class ModuleDataHelper(IMetadata md) : IDataHelper
{
    readonly IMetadata _md = md;

    public object? Read(object? data)
    {
        if (data is ZObject zobj && zobj.Type == TType.Module && TSerializator.Deserialize<TModule>(zobj.Definition) is TModule obj)
        {
            obj.Designer ??= _md.GetObject(obj.Type)?.Designer;
            obj.FromDatabase = true;
            var exclude = obj.GetType().GetProperties().Select(p => p.Name.ToLower());
            obj.Parameters.Add(nameof(obj.Name), obj.Name);
            if (JsonNode.Parse(zobj.Definition.ToText()) is JsonObject prms)
                foreach (var prm in prms.Where(p => !exclude.Contains(p.Key.ToLower())))
                    if (prm.Value is JsonObject jobj)
                        obj.Parameters.Add(prm.Key, jobj.ToString());
                    else if (prm.Value is JsonArray arr)
                        obj.Parameters.Add(prm.Key, arr.Select(a => a?.GetValue<string>()).ToArray());
                    else
                        obj.Parameters.Add(prm.Key, prm.Value.GetValue<object>().ToString());

            return obj;
        }
        return null;
    }

    public object? Write(object? data) => throw new NotImplementedException();
}
