//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: IFactorySuite – Интерфейс доступа к базе данных.
//--------------------------------------------------------------------------------------------------
using System.Data;

namespace Utis.SmartMinex.Runtime;

public interface IFactorySuite : IDisposable
{
    #region Properties

    IDatabase Database { get; }

    /// <summary> Схема по-умолчанию.</summary>
    string DefaultScheme { get; }
    /// <summary> Возвращает версию базы данных.</summary>
    string Version { get; }
    /// <summary> Возвращает количество подключений к БД.</summary>
    int ConnectionCount { get; }
    /// <summary> Возвращает наименование базы данных.</summary>
    string DatabaseName { get; }
    /// <summary> Возвращает физический размер БД на диске.</summary>
    string DatabaseSize { get; }

    #endregion Properties

    void Amend(Stream configuration);

    #region Casting

    /// <summary> Возвращает наименование базы данных, где находится объект.</summary>
    string ZDatabase(string source);

    /// <summary> Возвращает полное имя таблицы с экранирующими символами.</summary>
    string ZTable(string source);

    /// <summary> Возвращает имя поля с экранирующими символами.</summary>
    string? ZField(string? source);

    #endregion Casting

    /// <summary> Использовать новое подключение к указанной БД на текущем сервере.</summary>
    IFactorySuite Use(IDatabase db);

    /// <summary> Запрос объекта идентификации. Результат в виде перечисляемого типа, списка объектов.</summary>
    IFactorySuite Select(Type type);

    /// <summary> Запрос объекта идентификации.</summary>
    IFactorySuite Select(TObject obj);

    /// <summary> Выражение условия отбора данных</summary>
    IFactorySuite Where(string? expression);

    /// <summary> Выражение сортировки возвращаемых данных</summary>
    IFactorySuite Order(string? expression);

    /// <summary> Построение SQL-инструкции на основании введённых параметров.</summary>
    IFactorySuite Build();

    /// <summary> Вставить или обновить объект в базе данных на основании типа.</summary>
    void Insert(object item);

    /// <summary> Выполнить SQL-запрос к базе данных.</summary>
    DataTable? Run();
    /// <summary> Выполнить SQL-запрос к базе данных.</summary>
    IEnumerable<T>? Run<T>();
    /// <summary> Выполнить SQL-запрос к базе данных.</summary>
    IEnumerable<object>? RunAsEnumerable();
}

public interface IDatabaseFactory // For isolation
{
    /// <summary> Создаёт новую базу данных.</summary>
    void CreateDatabase(string connectionString, Stream? configuration);
}
