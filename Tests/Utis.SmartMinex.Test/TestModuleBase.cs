//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TestModuleBase – Базовый тестовый модуль.
//--------------------------------------------------------------------------------------------------
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Test;

public abstract class TestModuleBase(IRuntime runtime) : SmartModule(runtime)
{
    protected const int MSG_TEST1 = MSG.Custom + 55555;
    protected const int MSG_TEST2 = MSG.Custom + 55556;
    protected const int MSG_TEST3 = MSG.Custom + 55557;
    protected const int MSG_SCHEDULE1 = MSG.Custom + 55558;
}
