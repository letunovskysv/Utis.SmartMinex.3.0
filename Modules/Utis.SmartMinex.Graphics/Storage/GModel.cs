//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: GModel – Классы описывающие хранение план-схемы (карты).
//--------------------------------------------------------------------------------------------------
#region Using
using System.Text.Json.Serialization;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Graphics;

public class ZScheme : TEntity
{
    //[JsonIgnore]
    [JsonPropertyOrder(16)]
    public List<ZLevel> Levels { get; set; }
    [JsonPropertyOrder(17)]
    public ZStyles Styles { get; set; }
    [JsonPropertyOrder(18)]
    public List<ZObject> Objects { get; set; }
}

public class ZLevel : TEntity
{
    //[JsonIgnore]
    [JsonPropertyOrder(16)]
    public List<ZLayer> Layers { get; set; }
}

public class ZLayer : TEntity
{
    [JsonPropertyOrder(16)]
    public List<ZNode> Nodes { get; set; }
    [JsonPropertyOrder(17)]
    public List<ZSection> Sections { get; set; }
}

public class ZStyles : List<ZStyle>
{
    public ZStyle? this[string name] =>
        this.FirstOrDefault(s => s.Name != null && s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}

public class ZStyle
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Font { get; set; }
    public string? Align { get; set; }
    public string? Color { get; set; }
    public string? Background { get; set; }
    public string? Border { get; set; }
    public float? Width { get; set; }
}

public class ZNode
{
    public long Id { get; set; }
    public float[] D { get; set; }

    public string Name { get; set; }
    public string Type { get; set; }
    public long Bind { get; set; }

    /// <summary> Старый ИД.</summary>
    public string Id1 { get; set; }
}

public class ZSection
{
    public long Id { get; set; }
    public string Name { get; set; }
    /// <summary> 0 - line; 1 - arcs; 2 - pass; shaft - 3; unknown - 255 </summary>
    public int Type { get; set; }
    public string Style { get; set; }
    public string Start { get; set; }
    public string Sweep { get; set; }
    public string Text { get; set; }
    public long[] D { get; set; }

    /// <summary> Старый ИД.</summary>
    public string Id1 { get; set; }
}
