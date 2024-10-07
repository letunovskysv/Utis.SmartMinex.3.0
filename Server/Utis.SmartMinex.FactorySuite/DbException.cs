//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DbException –
//--------------------------------------------------------------------------------------------------
namespace Utis.SmartMinex.Data;

public class DbException : Exception
{
    public const int NO_INSTANCE = 1;
    public const int NO_DATABASE = 2;

    static readonly Dictionary<int, string> _msgs = new Dictionary<int, string>()
    {
        {NO_INSTANCE, "Не запущен сервер базы данных." },
        {NO_DATABASE, "Отсутвует база данных." }
    };

    public int ErrorCode { get; }
    public string Code { get; }

    public DbException(int errorCode, Exception innerException = null)
        : base(_msgs.ContainsKey(errorCode) ? _msgs[errorCode] : innerException?.Message ?? "Неизвестная ошибка!", innerException)
    {
        ErrorCode = errorCode;
    }

    public DbException(string code, string statement, Exception exception)
        : base($"{statement}{FullMessage(exception)}", exception)
    {
        Code = code;
    }

    static string FullMessage(Exception ex) => $"\r\n{ex.Message}{(ex.InnerException != null ? $"{FullMessage(ex.InnerException)}" : "")}";
}

public class DbNotFoundException : DbException
{
    public DbNotFoundException(int errorCode, Exception innerException = null)
        : base(errorCode, innerException)
    {
    }
}
