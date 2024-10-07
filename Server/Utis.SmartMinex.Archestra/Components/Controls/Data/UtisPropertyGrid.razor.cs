//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UtisPropertyGrid – Элемент управления свойствами объекта конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using Microsoft.AspNetCore.Components;
using System.Reflection;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Archestra.Controls;

partial class UtisPropertyGrid : ComponentBase, IDisposable
{
    #region Properties

    [Parameter]
    public TEntity? DataSource { get; set; }

    [Inject]
    IMetadata _md { get; set; }

    public bool Modified { get; set; }

    #endregion Properties

    public void Dispose() => GC.SuppressFinalize(this);

    #region Properties

    bool TryGetProperties(out List<XProperty> properties)
    {
        if (DataSource != null && _md.GetObject(DataSource.Type) is TTypeInfo mdtype && mdtype.Attributes?.Count > 0)
        {
            properties = DataSource.GetType().GetProperties()
                .Where(p => mdtype.Attributes.Any(a => a.Code != null && a.Code.Equals(p.Name, StringComparison.OrdinalIgnoreCase)))
                .Select(p =>
                {
                    var ai = mdtype.Attributes.First(a => a.Code.Equals(p.Name, StringComparison.OrdinalIgnoreCase));
                    return new XProperty
                    {
                        Name = ai.Code,
                        Label = ai.Name,
                        Value = GetValue(p.PropertyType, p.GetValue(DataSource), ai.Source),
                        ReadOnly = ai.ReadOnly,
                        Ordinal = (int)ai.Id
                    };
                }).OrderBy(p => p.Ordinal).ToList();

            return true;
        }
        properties = default!;
        return false;
    }

    object? GetValue(Type type, object? value, string? format)
    {
        if (type.IsEnum && !string.IsNullOrWhiteSpace(format) && Enum.TryParse(type, format, true, out var test))
            return type.GetMethod("HasFlag").Invoke(value, [test]);

        return value;
    }

    #endregion Properties

    #region Editor

    void OnInput(string name, object? value)
    {
        var ds = DataSource;
        var p = ds.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (p != null)
        {
            var prev = p.GetValue(ds);
            switch (prev)
            {
                case string:
                    p.SetValue(ds, value?.ToString());
                    break;

                case bool:
                    p.SetValue(ds, value);
                    break;
            }
        }
        Modified = true;
    }

    #endregion Editor

    class XProperty
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public object? Value { get; set; }
        public bool ReadOnly { get; set; }
        public int Ordinal { get; set; }
    }
}
