//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ArchestraService.Dispatcher – Веб-служба конфигуратора параметров Системы.
//--------------------------------------------------------------------------------------------------
using System.Data;
using Utis.SmartMinex.Runtime;

namespace Utis.SmartMinex.Archestra;

partial class ArchestraService
{
    public int? ClientPort { get; private set; }

    public bool TryGetObject(object? search, out TEntity entity)
    {
        if (search != null && _md.TryGetObject(search, out var obj))
        {
            entity = obj;
            return true;
        }
        entity = default!;
        return false;
    }

    public bool TryGetObject<T>(object? search, out T entity)
    {
        if (search != null && _md.TryGetObject(search, out var obj) && obj is T res)
        {
            entity = res;
            return true;
        }
        entity = default!;
        return false;
    }

    public TEntity? GetObject(long id) => _md.GetObject(id);

    public List<TEntity> Select(params TType[] types) => _md.Objects.Select(types);

    public List<T> Select<T>() => _md.Objects.Select<T>();

    public List<T> Select<T>(params TType[] types) => _md.Objects.Select<T>(types);

    public List<TEntity> ParentBy(long parent) => _md.Objects.ParentBy(parent);

    public TEntity? Update(TEntity? entity)
    {
        if (entity == null) return null;
        return _md.Update(entity);
    }

    public DataTable? Select(TObject obj, string? where, string? order) => _md.Select(obj, where, order);
}

public delegate Task MetadataEventHandlerAsync(long objid, TEntity? entity);
