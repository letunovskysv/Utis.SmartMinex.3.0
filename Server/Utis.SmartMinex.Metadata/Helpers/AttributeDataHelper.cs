//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: AttributeDataHelper – Загрузчик реквизитов и свойств объекта конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

/// <summary> Загрузчик реквизитов и свойств объекта конфигурации.</summary>
class AttributeDataHelper(IMetadata md) : EntityDataHelper(md)
{
    public override object? Read(object? data) =>
        throw new NotImplementedException();

    public override object? Write(object? data) => _md.UseDatabase(fs =>
    {
        if (data is TAttribute attr && _md.Select<ZObject>(z => z.Id == attr.Id).FirstOrDefault() is ZObject zattr)
        {
            zattr.Parent = attr.Parent;
            zattr.Type = attr.Type;
            zattr.Definition = TSerializator.Serialize(attr) ?? throw new Exception("Ошибка сериализации реквизита объекта конфигруации!");
            zattr.Updated = DateTime.Now;
            zattr.RowVersion = DateTime.Now.ToSqlTimestamp();
            fs.Insert(zattr);
            _md.Objects.Invalidate(attr.Parent);
            return _md.GetObject(attr.Parent);
        }
        return null;
    });
}
