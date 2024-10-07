using System;
using System.Linq.Expressions;
using EntityDivision = Utis.Minex.ProductionModel.Catalog.Organize.Division;

namespace Utis.Minex.ProductionModel.Expression.Catalog
{
    /// <summary>
    /// Выражения для поиска подразделений
    /// </summary>
    public static class DivisionExpression
    {
        /// <summary>
        /// Получение подразделения по родителю
        /// </summary>
        public static Expression<Func<TDivision, bool>> Parent<TDivision>(EntityDivision division, bool deleted = false)
            where TDivision : EntityDivision
        {
            return CommonExpression.AppendDeletedCondition<TDivision>
                (x => x.DivisionParent == division, deleted);
        }
    }
}