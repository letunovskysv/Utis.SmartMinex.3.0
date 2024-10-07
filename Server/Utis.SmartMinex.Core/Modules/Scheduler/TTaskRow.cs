//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TTaskRow – Физическая таблица базы данных.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

/// <summary> Список задач и настроки планировщика.</summary>
public class TTaskRow
{
    /// <summary> Системный идентификатор.</summary>
    public long Id { get; set; }

    /// <summary> Состояние задачи.</summary>
    public int State { get; set; }

    /// <summary> Уровень БД (узла).</summary>
    public int Level { get; set; }

    /// <summary> Площадка.</summary>
   public long Site { get; set; }

    /// <summary> Периодичность выполненния (тип).</summary>
    public TaskTypes Type { get; set; }

    /// <summary> Код задачи.</summary>
    public string Code { get; set; }

    /// <summary> Наименование задачи.</summary>
    public string Name { get; set; }

    public long? Target { get; set; }

    /// <summary> Время начала выполнения задачи.</summary>
    public DateTime Start { get; set; }

    /// <summary> Время окончания выполнения задачи. NULL - безконечная задача.</summary>
    public DateTime? Finish { get; set; }

    /// <summary> Значения периода выполнения.</summary>
    public int Interval { get; set; }

    /// <summary> Количество попыток выполнения.</summary>
    public int Attempt { get; set; }

    /// <summary> Описание задачи.</summary>
    public string Descript { get; set; }

    public long Version { get; set; }
}

/// <summary> Активное расписание заданий.</summary>
public class TScheduleRow
{
    /// <summary> Системный идентификатор.</summary>
    public long Id { get; set; }

    /// <summary> Задание.</summary>
    public TTaskRow Task { get; set; }

    /// <summary> Дата и время начала выполнения задания.</summary>
    public DateTime Datetime { get; set; }
}

/// <summary> Периодичность выполнения заданий (типы).</summary>
public enum TaskTypes
{
    None,
    /// <summary> Разовое выполнение в указанное время.</summary>
    RunOnce,
    /// <summary> Через заданный интервал в секундах.</summary>
    Seconds,
    /// <summary> Через заданный интервал в минутах.</summary>
    Minutes,
    /// <summary> Через заданный интервал в часах.</summary>
    Hours,
    /// <summary> Через заданный интервал в сутках.</summary>
    Days,
    /// <summary> Через заданный интервал в месяцах.</summary>
    Months,
    /// <summary> Ежеминутно.</summary>
    Minutely,
    /// <summary> Каждые полчаса.</summary>
    HalfHour,
    /// <summary> Ежечастно.</summary>
    Нourly,
    /// <summary> Ежедневно.</summary>
    Daily,
    /// <summary> Еженедельно.</summary>
    Weekly,
    /// <summary> Eжемесячно.</summary>
    Monthly,
    /// <summary> Каждый квартал.</summary>
    Quarterly,
    /// <summary> Каждые полгода.</summary>
    HalfYear,
    /// <summary> Eжегодно.</summary>
    Yearly
}
