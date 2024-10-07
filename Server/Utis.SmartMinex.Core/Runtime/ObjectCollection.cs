//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: ObjectCollection – Коллекция всех объектов конфигурации (метаданных).
//--------------------------------------------------------------------------------------------------
#region Using
using System.Collections.Concurrent;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Core.Runtime;

/// <summary> Коллекция всех объектов конфигурации (метаданных).</summary>
/// <remarks> Все интерфейсные методы и свойства возвращают только <b><i>КОПИИ</i></b> запрашиваемых объектов.<br/>Для модификации используются специальные методы.</remarks>
public class ObjectCollection : IObjectCollection
{
    readonly ConcurrentDictionary<long, TEntity> _objects = new();

    public void Add(TEntity entity) =>
        _objects.TryAdd(entity.Id, entity);

    public void AddRange(IEnumerable<TEntity> entities) =>
        entities.ToList().ForEach(o => _objects.TryAdd(o.Id, o));

    #region IObjectCollection implementation

    public TEntity? this[long id] =>
        _objects.TryGetValue(id, out var oi) ? (TEntity)oi.Clone() : null;

    public TEntity? this[string name] =>
        (_objects.Values.FirstOrDefault(o => o.Code != null && o.Code.Equals(name, StringComparison.OrdinalIgnoreCase))
            ?? _objects.Values.FirstOrDefault(o => o.Name != null && o.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))?.Clone() as TEntity;

    public TEntity? this[Type type] =>
        _objects.Values.FirstOrDefault(o => o is TObject oi && oi.Model == type)?.Clone() as TEntity;

    public TEntity AddOrUpdate(TEntity entity) =>
        _objects.AddOrUpdate(entity.Id, entity, (id, old) => entity);

    public List<T> Select<T>() =>
        _objects.Values.Where(o => o is T).Select(o => (T)o.Clone()).ToList();

    public List<T> Select<T>(params TType[] types) =>
        _objects.Values.Where(o => o is T && types.Contains(o.Type)).Select(o => (T)o.Clone()).ToList();

    public List<TEntity> Select(params TType[] types) =>
        _objects.Values.Where(o => types.Contains(o.Type)).Select(o => (TEntity)o.Clone()).ToList();

    public List<TEntity> ParentBy(long parent) =>
        _objects.Values.Where(o => o.Parent == parent).Select(o => (TEntity)o.Clone()).ToList();

    public List<T> Where<T>(Func<T, bool> predicate) =>
        _objects.Values.Where(o => o is T e && predicate(e)).Select(o => (T)o.Clone()).ToList();

    public TEntity? FirstOrDefault(Func<TEntity, bool> predicate) =>
        _objects.Values.FirstOrDefault(o => predicate(o))?.Clone() as TEntity;

    public void Invalidate(long id) =>
        _objects.TryRemove(id, out _);

    #endregion IObjectCollection implementation
}