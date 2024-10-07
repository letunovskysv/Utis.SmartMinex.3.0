//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: DatabaseFactorySuite.Where – Доступ к базе данных. Условие отбора данных.
//--------------------------------------------------------------------------------------------------
#pragma warning disable CS8601, CS8602
#region Using
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.Data;

public partial class DatabaseFactorySuite
{
    public IFactorySuite Where(string? expression)
    {
        return this;
    }
}
#pragma warning restore CS8601, CS8602
