//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IDispatcher –
//--------------------------------------------------------------------------------------------------
using System.Data;
using Utis.SmartMinex.Runtime;

namespace Utis.SmartMinex.Archestra;

public interface IDispatcher
{
    int? ClientPort { get; }

    /// <summary> Возвращает сведения об объекте конфигурации.</summary>
    /// <remarks> Осуществляется поиск по нескольким полям (Id, Model, Code, Source) в зависимости от типа искомого значения.</remarks>
    /// <returns> Вовзращает копию сведений об объекте конфигурации.</returns>
    bool TryGetObject(object? search, out TEntity entity);
    /// <summary> Возвращает сведения об объекте конфигурации.</summary>
    /// <remarks> Осуществляется поиск по нескольким полям (Id, Model, Code, Source) в зависимости от типа искомого значения.</remarks>
    /// <returns> Вовзращает копию сведений об объекте конфигурации.</returns>
    bool TryGetObject<T>(object? search, out T entity);

    /// <summary> Запрос сведений об объекте конфигурации.</summary>
    /// <returns> Вовзращает копию сведений об объекте конфигурации.</returns>
    TEntity? GetObject(long id);

    /// <summary> Возвращает список (копии) объектов конфигурации указанного связанного типа (модели).</summary>
    /// <returns> Список копий объектов конфигурации.</returns>
    List<T> Select<T>();

    /// <summary> Возвращает список (копии) объектов конфигурации указанных типов метаданных.</summary>
    /// <returns> Список копий объектов конфигурации.</returns>
    List<TEntity> Select(params TType[] types);

    /// <summary> Возвращает список (копии) объектов конфигурации указанных типов метаданных.</summary>
    /// <returns> Список копий объектов конфигурации.</returns>
    List<T> Select<T>(params TType[] types);

    /// <summary> Возвращает список (копии) дочерниих объектов конфигурации.</summary>
    /// <returns> Список копий объектов конфигурации.</returns>
    List<TEntity> ParentBy(long parent);

    /// <summary> Обновление объекта конфигурации в базе данных.</summary>
    TEntity? Update(TEntity? entity);

    /// <summary> Выполняет запрос к БД и возвращает результат в виде списка объектов.</summary>
    DataTable? Select(TObject obj, string? where, string? order);

    #region Events

    /// <summary> Событие изменния метаданных. Требуется обновить инспектор конфигурации.</summary>
    event MetadataEventHandlerAsync MetadataChanged;

    #endregion Events
}
