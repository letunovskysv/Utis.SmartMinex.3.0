using System;
using System.Linq.Expressions;

namespace Utis.Minex.ProductionModel.Expression
{
    using Utis.Minex.Common;

    public static class CommonExpression
    {
        /// <summary>
        /// Добавить условие по флагу удаления 
        /// </summary>
        public static Expression<Func<TObjectBase, bool>> AppendDeletedCondition<TObjectBase>(Expression<Func<TObjectBase, bool>> ex, bool deleted)
            where TObjectBase : ObjectBase
        {
            //метод удобнее для внутреннего использования, т.к. в отличии от расширения, не нужно заранее создавать входное выражение
            return ex.AndNotDeleted(deleted);
        }

        /// <summary>
        /// Добавить условие по флагу удаления 
        /// </summary>
        public static Expression<Func<TObjectBase, bool>> AndNotDeleted<TObjectBase>(this Expression<Func<TObjectBase, bool>> ex, bool deleted = false)
            where TObjectBase : ObjectBase
        {
            return ex.AndAlso(NotDeleted<TObjectBase>(deleted));
        }

        /// <summary>
        /// Выражение для поиска неудалённых записей
        /// </summary>
        public static Expression<Func<TObjectBase, bool>> NotDeleted<TObjectBase>(bool deleted = false)
            where TObjectBase : ObjectBase
        {
            return x => x.Deleted == deleted;
        }

        /// <summary>
        /// Выражение для поиска объекта по Id
        /// </summary>
        public static Expression<Func<TObjectBase, bool>> Id<TObjectBase>(long id, bool deleted = false)
            where TObjectBase : ObjectBase, new()
        {
            return AppendDeletedCondition<TObjectBase>
                (x => x.Id == id, deleted);
        }
    }
}