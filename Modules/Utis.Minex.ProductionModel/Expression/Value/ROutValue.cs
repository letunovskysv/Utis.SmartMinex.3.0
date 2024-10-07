using System;
using System.Linq.Expressions;

namespace Utis.Minex.ProductionModel.Expression.Value
{
    using Utis.Minex.Common;

    /// <summary>
    /// Выражения для поиска значений выходного регистра.
    /// </summary>
    public static class ROutValueExpression
    {
        /// <summary>
        /// Получение значения по вхождению во временной промежуток.
        /// </summary>
        public static Expression<Func<TROutValue, bool>> DateTime<TROutValue, TRDimension>(DateTime datetime, bool deleted = false)
            where TROutValue : ROutValueBase<TRDimension>
            where TRDimension : RDimensionBase
        {
            return CommonExpression.AppendDeletedCondition<TROutValue>
                (x => datetime >= x.Datetime && (x.Dateout == default || datetime <= x.Dateout), deleted);
        }

        /// <summary>
        /// Получение значения по пустому времени отвязки.
        /// </summary>
        public static Expression<Func<TROutValue, bool>> EmptyDateout<TROutValue, TRDimension>(bool deleted = false)
            where TROutValue : ROutValueBase<TRDimension>
            where TRDimension : RDimensionBase
        {
            return CommonExpression.AppendDeletedCondition<TROutValue>
                (x => x.Dateout == default, deleted);
        }
    }
}