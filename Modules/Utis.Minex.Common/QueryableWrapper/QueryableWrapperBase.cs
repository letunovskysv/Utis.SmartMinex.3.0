using System;
using System.Linq;

namespace Utis.Minex.Common.QueryableWrapper
{
    public class QueryableWrapperTwo<T, TF> : QueryableWrapperBase where T : class
    {
        private Func<IQueryable<T>, TF, object> _func;
        
        public override void SetDelegate(object delegateFunc)
        {
            var func = (Func<IQueryable<T>, TF, object>)delegateFunc;
            _func = func;
        }

        public override object Invoke(object queryable, object expression)
        {
            var queryableCast = queryable as IQueryable<T>;
            var expressionCast = (TF)expression;
            return _func.Invoke(queryableCast, expressionCast);
        }
    }

    public abstract class QueryableWrapperBase
    {
        public abstract void SetDelegate(object delegateFunc);

        public abstract object Invoke(object queryable, object expression);
    }

    public class QueryableWrapperOne<T> : QueryableWrapperBase where T : class
    {
        private Func<IQueryable<T>, object> _func;

        public override void SetDelegate(object delegateFunc)
        {
            var func = (Func<IQueryable<T>, object>)delegateFunc;
            _func = func;
        }

        public override object Invoke(object queryable, object expression)
        {
            var queryableCast = queryable as IQueryable<T>;
            return _func.Invoke(queryableCast);
        }
    }
}