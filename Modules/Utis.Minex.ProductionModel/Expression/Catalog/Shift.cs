using System;
using System.Linq.Expressions;
using Utis.Minex.ProductionModel.Catalog.Organize;
using EntityShift = Utis.Minex.ProductionModel.Catalog.Organize.Shift;

namespace Utis.Minex.ProductionModel.Expression.Catalog
{
    /// <summary>
    /// Выражения для поиска смен
    /// </summary>
    /// //TODO: delete
    //public static class ShiftExpression
    //{
    //    /// <summary>
    //    /// Получение смены по рассписанию
    //    /// </summary>
    //    public static Expression<Func<EntityShift, bool>> WorkSchedule(ShiftDuration workSchedule, bool deleted = false)
    //    {
    //        return CommonExpression.AppendDeletedCondition<EntityShift>
    //            (x => x.ShiftDuration == workSchedule, deleted);
    //    }
    //}
}