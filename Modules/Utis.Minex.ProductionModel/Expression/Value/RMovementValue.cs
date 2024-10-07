using System;
using System.Linq.Expressions;
using Utis.Minex.Common;
using Utis.Minex.ProductionModel.Register.Value.Common;

namespace Utis.Minex.ProductionModel.Expression.Value
{
    /// <summary>
    /// Выражения для поиска значений регистра перемещения
    /// </summary>
    public static class RMovementValueExpression
    {
        /// <summary>
        /// Выражение для поиска значений регистра перемещения c непустой выработкой
        /// </summary>
        public static Expression<Func<TRMovementValue, bool>> Working<TRMovementValue, TRMovementDimension>(bool workingEmpty = false, bool deleted = false)
            where TRMovementValue : RMovementValueBase<TRMovementDimension>
            where TRMovementDimension : RDimensionBase
        {
            Expression<Func<TRMovementValue, bool>> ex = workingEmpty ?
                ex = x => x.Working == null :
                ex = x => x.Working != null;
            return CommonExpression.AppendDeletedCondition(ex, deleted);
        }
    }
}