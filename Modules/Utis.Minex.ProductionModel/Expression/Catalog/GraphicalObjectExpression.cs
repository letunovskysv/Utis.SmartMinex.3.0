using System;
using System.Linq.Expressions;
using EntityGraphicalObject = Utis.Minex.ProductionModel.Graphical.GraphicalObject;

namespace Utis.Minex.ProductionModel.Expression.Catalog
{
    /// <summary>
    /// Выражения для поиска графических объектов
    /// </summary>
    public static class GraphicalObjectExpression
    {

        const long mdType = 25 /*Рудник*/;

        /// <summary>
        /// Получение опубликованной ИМР по Id
        /// </summary>
        public static Expression<Func<EntityGraphicalObject, bool>> PublishedMine(long id, bool deleted = false)
        {
            Expression<Func<EntityGraphicalObject, bool>> left = x => x.Parent == null && x.MdType == mdType && x.Id == id && x.IsPublished == true;

            return CommonExpression.AppendDeletedCondition(left, deleted);
        }

        /// <summary>
        /// Получение опубликованных ИМР имеющих подразделение
        /// </summary>
        public static Expression<Func<EntityGraphicalObject, bool>> PublishedMines(bool deleted = false)
        {

            Expression<Func<EntityGraphicalObject, bool>> left = x => x.Parent == null && x.MineObject != null && x.MdType == mdType && x.IsPublished == true;

            return CommonExpression.AppendDeletedCondition(left, deleted);
        }
    }
}