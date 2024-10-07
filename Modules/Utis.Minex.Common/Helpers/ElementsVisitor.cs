using System.Collections.Generic;
using System.Linq.Expressions;

namespace Utis.Minex.Common.Helpers
{
    /// <summary>
    /// Формирует список обращений к свойствам (Members) и значений (Constants) в посещаемом выражении
    /// </summary>
    public class ElementsVisitor : ExpressionVisitor
    {
        public IList<MemberExpression> Members = new List<MemberExpression>();
        public IList<ConstantExpression> Constants = new List<ConstantExpression>();

        protected override Expression VisitMember(MemberExpression node)
        {
            Members.Add(node);
            return base.VisitMember(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Constants.Add(node);
            return base.VisitConstant(node);
        }

        public ElementsVisitor VisitExpression(Expression expr)
        {
            Members = new List<MemberExpression>();
            Constants = new List<ConstantExpression>();
            Visit(expr);
            return this;
        }

    }
}
