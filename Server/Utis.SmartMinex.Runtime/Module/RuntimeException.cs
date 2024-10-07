//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: RuntimeException –
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

public class RuntimeException : Exception
{
    public RuntimeException(IModule module, string message, Exception? innerException)
        : base(string.Concat('#', module.ProcessId, "> ", message), innerException)
    {
    }
}
