//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: EntityDataHelper – Загрузчик обработчиков метаданных.
//--------------------------------------------------------------------------------------------------
#region Using
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

/// <summary> Загрузчик обработчиков метаданных.</summary>
class EntityDataHelper(IMetadata md) : IDataHelper
{
    protected readonly IMetadata _md = md;

    public virtual object? Read(object? data)
    {
        if (data is ZObject zobj)
            switch (zobj.Type)
            {
                case TType.Manifest:
                    return TSerializator.Deserialize<TManifest>(zobj.Definition);

                case TType.Helper:
                    var zhelper = TSerializator.Deserialize<THelper>(zobj.Definition);
                    if (zhelper != null && Type.GetType(zhelper.Source) is Type type && Activator.CreateInstance(type, [_md]) is IDataHelper helper)
                        zhelper.Types.ForEach(mdtype => ((Metadata)_md).Helpers.TryAdd(mdtype, helper));

                    break;

                case TType.Folder:
                case TType.Solution:
                case TType.Component:
                case TType.Object:
                    if (TSerializator.Deserialize<TTypeInfo>(zobj.Definition) is TTypeInfo typeObj)
                    {
                        var attrs = _md.Select<ZObject>(r => r.Parent == typeObj.Id && r.Type == TType.Attribute)
                            .Select(zattr => TSerializator.Deserialize<TAttribute>(zattr.Definition))
                            .OrderBy(ai => ai.Ordinal).ThenBy(ai => ai.Id).ToList();

                        if (attrs.Count != 0)
                            typeObj.Attributes = attrs;

                        return typeObj;
                    }
                    break;
            }

        return null;
    }

    public virtual object? Write(object? data) => _md.UseDatabase(fs =>
    {
        if (data is TEntity ent && _md.Select<ZObject>(z => z.Id == ent.Id).FirstOrDefault() is ZObject zobj)
        {
            zobj.Parent = ent.Parent;
            zobj.Type = ent.Type;
            zobj.Definition = TSerializator.Serialize(ent) ?? throw new Exception("Ошибка сериализации объекта конфигруации!");
            zobj.Updated = DateTime.Now;
            zobj.RowVersion = DateTime.Now.ToSqlTimestamp();
            fs.Insert(zobj);
            _md.Objects.Invalidate(ent.Id);
            return _md.GetObject(ent.Id);
        }
        return null;
    });
}
