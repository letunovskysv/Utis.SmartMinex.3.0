//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: MinexModelTypeConverter – Конвертация типов (моделей) в объекты конфигурации.
// Типы содержаться в библиотеке Modules/Models/Utis.Minex.ProductionModel
// select * from z_objects where typeentity like '%RfidDevice%'
// select * from metadataobject where type like '%RfidDevice%'
//--------------------------------------------------------------------------------------------------
#region Using
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Utils;

[DebuggerDisplay("{Code}, {Source}, {Type}, {IsReference}, {IsEnum}")]
class XAttribute
{
    public long Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Source { get; set; }
    public long DataType { get; set; }
    public bool? Readonly { get; set; }
    public string? Flags { get; set; }
    public bool Visible { get; set; }
}

class XObject
{
    public long Id { get; set; }
    public long Parent { get; set; }
    public long Type { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Source { get; set; }
    public string? Model { get; set; }
    public string? Flags { get; set; }
    public List<XAttribute> Attributes { get; set; } = [];
    public List<string> Data { get; set; } = [];
}

class XCollection
{
    public List<XObject> Objects { get; set; } = [];
}

class XLowerCasePolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        string.IsNullOrEmpty(name) || !char.IsUpper(name[0]) ? name : name.ToLower();
}
