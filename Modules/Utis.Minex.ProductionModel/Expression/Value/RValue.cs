using System;
using System.Linq.Expressions;
using Utis.Minex.Common;

namespace Utis.Minex.ProductionModel.Expression.Value
{
    /// <summary>
    /// Выражения для поиска значений регистра
    /// </summary>
    public static class RValueExpression
    {
        /// <summary>
        /// Получение записи по времени
        /// </summary>
        public static Expression<Func<TRValue, bool>> Datetime<TRValue, TRDimension>(DateTime datetime, bool deleted = false)
            where TRValue : RValueBase<TRDimension> where TRDimension : RDimensionBase
        {
            return CommonExpression.AppendDeletedCondition<TRValue>
                (x => x.Datetime == datetime, deleted);
        }

        /// <summary>
        /// Дата/время записи больше указанного
        /// </summary>
        public static Expression<Func<TRValue, bool>> MoreThanDatetime<TRValue, TRDimension>(DateTime datetime, bool deleted = false)
            where TRValue : RValueBase<TRDimension> where TRDimension : RDimensionBase
        {
            return CommonExpression.AppendDeletedCondition<TRValue>
                (x => x.Datetime > datetime, deleted);
        }

        /// <summary>
        /// Дата/время записи меньше или равно указанному
        /// </summary>
        public static Expression<Func<TRValue, bool>> LessOrEqualThanDatetime<TRValue, TRDimension>(DateTime datetime, bool deleted = false)
            where TRValue : RValueBase<TRDimension> where TRDimension : RDimensionBase
        {
            return CommonExpression.AppendDeletedCondition<TRValue>
                (x => x.Datetime <= datetime, deleted);
        }
    }
}