using System;
using System.Linq;
using System.Linq.Expressions;

namespace Utis.Minex.Business.Common
{
    using Utis.Minex.Common;

    public interface IQueryOperation : IDisposable
    {
        IQueryable Query(Expression query = null);
    }

    /// <summary>
    /// Операции для запросов.
    /// </summary>
    public interface IQueryOperation<T> : IQueryOperation where T : ObjectBase
    {
        IQueryable<T> Query(bool useTransaction, Expression<Func<T, bool>> query = null);

        T FirstOrDefault(Expression<Func<T, bool>> query = null);

        T GetById(long id);
    }
}