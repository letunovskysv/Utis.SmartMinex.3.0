//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DatabaseFactorySuite.Select – Доступ к базе данных. Запрос данных.
//--------------------------------------------------------------------------------------------------
#pragma warning disable CS8601, CS8602
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public partial class DatabaseFactorySuite
{
    public IFactorySuite Select(TObject obj)
    {
        Clear();
        _state = XState.Select;
        _obj = obj;
        var alias = "a";

        _from.Add(new XFrom(" FROM ", obj.Factory.Table, alias));
        obj.Attributes.ForEach(ai => _fields.Add(new XField(alias, ai)));

        return this;
    }

    public IFactorySuite Select(Type type)
    {
        if (_md.TryGetObject(type, out var ent) && ent is TObject obj && obj.Model != null && obj.Attributes.KeyField != null)
        {
            Clear();
            _state = XState.Select;
            _obj = obj;
            var alias = "a";
            var refalias = alias;

            _from.Add(new XFrom(" FROM ", obj.Factory.Table, alias));
            _types.Add(obj.Model);
            _ids.Add(obj.Attributes.KeyField.Source);
            obj.Attributes.ForEach(ai =>
            {
                if (ai.Factory.IsReference)
                {
                    _fields.Add(new XField(alias, ai));
                    if (_md.TryGetObject(ai.Factory.PropertyType, out var refent) && refent is TObject refobj)
                    {
                        _fields.Add(new XField(refalias = NextAlias(refalias), null));
                        _types.Add(ai.Factory.PropertyType);
                        _ids.Add(ai.Source);
                        _from.Add(new XFrom(" LEFT JOIN ", refobj.Factory.Table, refalias,
                            refobj.Attributes.KeyField.Factory.Name, alias, ai.Factory.Name));
                    }
                }
                else
                    _fields.Add(new XField(alias, ai));
            });
        }
        return this;
    }

    static string NextAlias(string alias) =>
        ((char)(alias[0] + 1)).ToString();
}
#pragma warning restore CS8601, CS8602
