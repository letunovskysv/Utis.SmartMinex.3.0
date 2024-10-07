using System;
using System.Linq;
using System.Linq.Expressions;

namespace Utis.Minex.Common
{
    /// <summary>
    /// Расширения для выражений.
    /// </summary>
    public static class ExpressionExtensions
    {
        #region private methods
        public static Expression ReplaceParameter(this Expression expression, ParameterExpression parameter)
        {
            return new ExpressionReplaceableParameter(parameter).Visit(expression);
        }
        private static Expression<Func<T, bool>> MakeLambda<T>(this Expression body, ParameterExpression parameter)
        {
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        #endregion

        #region public methods

        /// <summary>
        /// AndAlso
        /// </summary>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (right == null || left == null) return right ?? left;

            var parameter = left.Parameters.Single();
            return Expression.AndAlso(left.Body, right.Body.ReplaceParameter(parameter)).MakeLambda<T>(parameter);
        }
        /// <summary>
        /// OrElse
        /// </summary>
        public static Expression<Func<T, bool>> OrElse<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (right == null || left == null) return right ?? left;

            var parameter = left.Parameters.Single();
            return Expression.OrElse(left.Body, right.Body.ReplaceParameter(parameter)).MakeLambda<T>(parameter);
        }

        /// <summary>
        /// Not
        /// </summary>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            return Expression.Not(expression.Body).MakeLambda<T>(parameter);
        }

        #endregion

        #region internal classes

        private class ExpressionReplaceableParameter : ExpressionVisitor
        {
            /// <summary>
            /// expression of parameter
            /// </summary>
            private readonly ParameterExpression newParameter;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="newParameter">Expresion for replace</param>
            public ExpressionReplaceableParameter(ParameterExpression newParameter)
            {
                this.newParameter = newParameter;
            }

            /// <summary>
            /// Visit tree
            /// </summary>
            /// <param name="p">Expression that contain parameter</param>
            /// <returns>Expression</returns>
            protected override Expression VisitParameter(ParameterExpression p)
            {
                return base.VisitParameter(newParameter);
            }
        }

        #endregion
    }
}
