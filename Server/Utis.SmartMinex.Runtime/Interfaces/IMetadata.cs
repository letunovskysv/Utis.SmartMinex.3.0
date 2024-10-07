//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IMetadataFactory – Интерфейс получения метаданных и данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Collections.Concurrent;
using System.Data;
using System.Linq.Expressions;
using Utis.SmartMinex.Data;
#endregion Using

namespace Utis.SmartMinex.Runtime;

/// <summary> Интерфейс получения метаданных и данных.</summary>
public interface IMetadata
{
    /// <summary> Текущий узел базы данных.</summary>
    TNode Node { get; }
    /// <summary> Версия метаданных.</summary>
    string Version { get; }

    IObjectCollection Objects { get; }

    /// <summary> Возвращает фабрику базы данных.</summary>
    IFactorySuite CreateFactorySuite();

    void UseDatabase(Action<IFactorySuite?>? func);
    T UseDatabase<T>(Func<IFactorySuite, T>? func);

    /// <summary> Возвращает сведения об объекте конфигурации.</summary>
    TEntity? GetObject(long id);

    /// <summary> Возвращает сведения об объекте указанного типа.</summary>
    T? GetObject<T>(long id) where T: TEntity;

    /// <summary> Возвращает сведения об объекте конфигурации.</summary>
    /// <remarks> Осуществляется поиск по нескольким полям (Id, Model, Code, Source) в зависимости от типа искомого значения.</remarks>
    bool TryGetObject(object search, out TEntity entity);

    /// <summary> Выполняет запрос к БД и возвращает результат в виде списка объектов.</summary>
    IEnumerable<object?>? Select(Type type, string? where, string? order);
    /// <summary> Возвращает результат в виде списка указанного типа.</summary>
    IEnumerable<T>? Select<T>(Expression<Func<T, bool>>? predicate = null);

    /// <summary> Выполняет запрос к БД и возвращает результат в виде списка объектов.</summary>
    DataTable? Select(long id, string? where, string? order);
    /// <summary> Выполняет запрос к БД и возвращает результат в виде списка объектов.</summary>
    DataTable? Select(string name, string? where, string? order);
    /// <summary> Выполняет запрос к БД и возвращает результат в виде списка объектов.</summary>
    DataTable? Select(TObject obj, string? where, string? order);

    /// <summary> Обновление объекта конфигурации в базе данных.</summary>
    TEntity? Update(TEntity entity);

    /// <summary> Возвращает SQL-инструкцию. Для отладки.</summary>
    string? Query(object uid, string? where, string? order);
}
