//--------------------------------------------------------------------------------------------------
// (C) 2018 ООО «УралТехИс». ПТК «Горный диспетчер». Все права защищены.
//--------------------------------------------------------------------------------------------------
namespace Utis.Minex.Common
{
    #region Using
    using System;
    using System.Linq.Expressions;
    #endregion Using

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfiedBy();
    }
}
