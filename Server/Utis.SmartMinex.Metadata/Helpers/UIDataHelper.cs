//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: UIDataHelper – Загрузчик пользовательского интерфейса, меню, панелей и прочего.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

/// <summary> Загрузчик пользовательского интерфейса, меню и прочего.</summary>
class UIDataHelper(IMetadata md) : IDataHelper
{
    readonly IMetadata _md = md;

    public object? Read(object? data)
    {
        if (data is ZObject zobj && zobj.Type == TType.Menu && TSerializator.Deserialize<TMenu>(zobj.Definition) is TMenu menu)
        {
            TMenuItem prev = default!;
            foreach (var item in menu.Items.RecursiveBy(m => m.Items))
            {
                if (item.Name != null && item.Name.StartsWith('{') && item.Name.EndsWith('}')) // Шаблон
                {
                    var ids = item.Name[1..^1].Split(['.']);
                    if (ids.Length > 1 && ids[1] == "*" && _md.TryGetObject(ids[0], out var mdtype))
                    {
                        prev.Items = _md.Objects.Select(mdtype.Id)
                            .Select(obj => new TMenuItem()
                            {
                                Name = obj.Name,
                                Path = obj.FullName
                            }).ToList();
                    }
                }
                prev = item;
            }
            return menu;
        }
        return null;
    }

    public object? Write(object? data) => throw new NotImplementedException();
}
