//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ObjectDataHelper – Загрузчик объектов конфигурации.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Data;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Helpers;

/// <summary> Загрузчик объектов конфигурации.</summary>
class ObjectDataHelper(IMetadata md) : EntityDataHelper(md)
{
    public override object? Read(object? data)
    {
        if (data is ZObject zobj && TSerializator.Deserialize<TObject>(zobj.Definition) is TObject obj)
            return _md.UseDatabase(fs =>
            {
                obj.FullName = string.Concat(_md.GetObject(obj.Type)?.Code, '.', obj.Code);
                ReadAttributes(obj, fs);

                obj.Designer ??= _md.GetObject(obj.Type)?.Designer;
                obj.Factory.Database = fs.ZDatabase(obj.Source);
                obj.Factory.Table = fs.ZTable(obj.Source);
                obj.Factory.IsExternal = obj.Factory.Database != fs.DatabaseName;
                fs.Dispose();
                return obj;
            });

        return null;
    }

    void ReadAttributes(TObject obj, IFactorySuite fs)
    {
        var model = obj.Model?.GetProperties().ToDictionary(k => k.Name.ToUpper(), v => v.PropertyType); // Существующие старый типы данных (модели)

        foreach (var ai in _md.Select<ZObject>(r => r.Parent == obj.Id && r.Type == TType.Attribute)
            .Select(zattr => TSerializator.Deserialize<TAttribute>(zattr.Definition))
            .OrderBy(ai => ai.Ordinal).ThenBy(ai => ai.Id))
        {
            var fld = ai.Source.ToUpper();
            if (fld.EndsWith("_ID")) fld = fld[0..^3]; // В текущей реализации, к ссылочным полям, добавляется суффикс «_id»
            ai.Object = obj;
            ai.FullName = string.Concat(obj.Code, '.', ai.Code);
            ai.ReadOnly |= ai.Flags.HasFlag(TAttributeFlags.Key);

            ai.Designer ??= _md.GetObject(ai.Type)?.Designer;
            ai.Factory.Name = fs.ZField(ai.Source);
            ai.Factory.PropertyType = model != null && model.TryGetValue(fld, out var ptyp) ? ptyp : null;
            ai.Factory.IsReference = !(ai.Factory.PropertyType == null || ai.Factory.PropertyType.IsPrimitive || ai.Factory.PropertyType.IsEnum
                || ai.Factory.PropertyType.IsValueType || ai.Factory.PropertyType == typeof(string));

            obj.Attributes.Add(ai);
        }
    }

    public override object? Write(object? data)
    {
        if (data is TObject obj)
        {
            obj.Designer = null;
            return base.Write(obj);
        }
        return null;
    }
}
