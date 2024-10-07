//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TMessage – Системное сообщение.
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Runtime;

/// <summary> Системное сообщение.</summary>
[System.Diagnostics.DebuggerDisplay("Msg={MSG.ToString(Msg)}, {LParam}, {HParam}, {Data}")]
public struct TMessage(int msg, long lparam, long hparam, object? data)
{
    /// <summary> Тип сообщения </summary>
    public int Msg = msg;
    /// <summary> Параметр 1 </summary>
    public long LParam = lparam;
    /// <summary> Параметр 2 </summary>
    public long HParam = hparam;
    /// <summary> Возврат - результат </summary>
    public long Result = 0;
    /// <summary> Произвольные данные </summary>
    public object? Data = data;

    public TMessage(int msg) : this(msg, 0, 0, null)
    { }

    public TMessage(int msg, object data) : this(msg, 0, 0, data)
    { }

    public TMessage(int msg, long lparam, object data) : this(msg, lparam, 0, data)
    { }

    /// <summary> Используется при репликации. Result содержит Timestamp.</summary>
    public TMessage(int msg, long lparam, long hparam, long result, object? data) : this(msg, lparam, hparam, data) => Result = result;
}
