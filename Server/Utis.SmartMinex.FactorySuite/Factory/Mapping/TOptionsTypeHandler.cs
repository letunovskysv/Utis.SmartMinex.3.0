//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: TOptionsTypeHandler – Фабрика SQL-инструкций к базе данных.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Data;
using Dapper;
using Newtonsoft.Json;
using Utis.SmartMinex.Runtime;
#endregion Using

namespace Utis.SmartMinex.FactorySuite;

public class TOptionsTypeHandler : SqlMapper.TypeHandler<TOptions>
{
    public override TOptions? Parse(object? value)
    {
        if (value == null) return null;

        try
        {
            return JsonConvert.DeserializeObject<TOptions>(value.ToString());
        }
        catch (Exception ex)
        {
            throw new InvalidCastException("Ошибка приведения типа EquipmentOptionsTypeHandler. " + ex.Message);
        }
    }

    public override void SetValue(IDbDataParameter parameter, TOptions? value)
    {
        parameter.Value = value;
    }
}
