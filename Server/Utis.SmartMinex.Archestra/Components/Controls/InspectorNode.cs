//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: InspectorNode –
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components.Web;
using Utis.SmartMinex.Archestra.Components.Forms;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Archestra.Components;

public class InspectorNode
{
    static readonly Type EditorDefault = typeof(ObjectEditor);

    public TEntity Target;

    public long Id { get; set; }
    public string Name { get => Target.Name; set => Target.Name = value; }
    public string Icon { get; set; }
    public string Path { get; set; }
    public int Level { get; set; }
    public Type? Editor { get; }
    public Dictionary<string, object?> Parameters { get; }

    bool _expanded;
    public bool Expanded { get => _expanded; set => _expanded = value && Nodes?.Count > 0; }
    public bool HasChild => Nodes?.Count > 0;

    public List<InspectorNode> Nodes { get; set; }

    public InspectorNode(TEntity entity, int level, string icon)
    {
        Target = entity;
        Id = entity.Id;
        Level = level;
        Icon = icon;
        Editor = entity.Id < TType.Bound || string.IsNullOrEmpty(entity.Designer) ? null
            : Type.GetType(entity.Designer) ?? EditorDefault.Assembly.GetTypes().FirstOrDefault(t => t.Name == entity.Designer) ?? EditorDefault;

        if (entity.Type == TType.Attribute && entity is TAttribute ai)
        {
            Path = string.Concat(ai.Object.Type.ToString().ToLower(), '/', ai.Object.Source?.Split(['.']).Last(), '/', ai.Source?.Split(['.']).Last());
            Parameters = new Dictionary<string, object?>()
            {
                { "Id", string.Concat(ai.Object.Code, '.', ai.Code) }
            };
        }
        else if (Editor != null)
        {
            Path = string.Concat(entity.Type.ToString(), '/', entity.Code);
            Parameters = new Dictionary<string, object?>()
            {
                { "Id", entity.Code }
            };
        }
    }
}

public class InspectorItemEventArgs(InspectorNode item, MouseEventArgs mouse) : EventArgs
{
    public InspectorNode Item { get; set; } = item;
    public MouseEventArgs Mouse { get; set; } = mouse;
}
