//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IDatabase – Интерфейс доступа к базе данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using System.Linq.Expressions;
#endregion Using

namespace Utis.SmartMinex.Runtime;

public interface IDatabase : IDisposable
{
    string ApplicationName { get; set; }
    string DatabaseName { get; }

    /// <summary> Подключиться к БД.</summary>
    IDatabase Open();
    /// <summary> Закрыть соединение с БД.</summary>
    void Close();

    /// <summary> Возвращает результат SQL-инструкции в виде таблицы.</summary>
    DataTable? Query(string sql, params object?[] args);
    /// <summary> Возвращает результат SQL-инструкции в виде скалярной переменной (первой строчки первой колонки).</summary>
    object? Scalar(string sql, params object?[] args);
    /// <summary> Выполняет SQL-инструкцию без возврата результата.</summary>
    void Exec(string sql, params object?[] args);

    /// <summary> Возвращает результат в виде списка указанного типа.</summary>
    IEnumerable<T>? Select<T>(string sql, params object?[] args);
    /// <summary> Возвращает результат в виде списка указанного типа.</summary>
    IEnumerable<T>? Select<T>(Expression<Func<T, bool>>? predicate = null);
    /// <summary> Возвращает результат в виде списка указанного типа.</summary>
    IEnumerable<object>? Select(Type type, string sql, params object?[] args);
    /// <summary> Возвращает результат в виде списка указанного типа.</summary>
    IEnumerable<object>? Select(Type type, Type[] types, string splitOn, string sql, params object?[] args);

    /// <summary> Возвращает список схем данных в текущей базе данных.</summary>
    List<string> Schemas();
    /// <summary> Возвращает список таблиц в текущей базе данных.</summary>
    List<string> Tables();
    /// <summary> Возвращает список представлений в текущей базе данных.</summary>
    List<string> Views();
    /// <summary> Возвращает список хранимых процедур в текущей базе данных.</summary>
    List<string> Procedures();
}
