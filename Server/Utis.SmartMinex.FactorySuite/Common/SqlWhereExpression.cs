//--------------------------------------------------------------------------------------------------
// (С) 2017-2025 ООО УралТехИС. Интеллектуальная Системная Платформа 3.0. Все права защищены.
// Описание: SqlWhereExpression – Конвертирует выражение в строку условия WHERE.
//--------------------------------------------------------------------------------------------------
#region Using
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
#endregion Using

namespace Utis.SmartMinex.Data;

/// <summary> Конвертирует выражение в строку условия WHERE.</summary>
public static class SqlWhereExpression
{
    public static string Convert<T>(Expression<Func<T, bool>>? expression)
    {
        if (expression == null) return string.Empty;

        StringBuilder where = new StringBuilder();
        BuildWhereString(expression.Body, where);
        return where.ToString();
    }

    static void BuildWhereString(object body, StringBuilder where)
    {
        Type type = body.GetType();
        var node = (ExpressionType)body.GetType().GetProperty("NodeType").GetValue(body);
        if (node == ExpressionType.Call)
        {
            BuildCallExpression((MethodCallExpression)body, where);
        }
        else if (node == ExpressionType.MemberAccess)
        {
            MemberValue(body, where);
        }
        else
        {
            object left = type.GetProperty("Left").GetValue(body);
            BuildPart(left, where);
            switch (node)
            {
                case ExpressionType.AndAlso:
                    where.Append(" AND ");
                    break;
                case ExpressionType.OrElse:
                    where.Append(" OR ");
                    break;
                case ExpressionType.Equal:
                    where.Append('=');
                    break;
                case ExpressionType.NotEqual:
                    where.Append("<>");
                    break;
                case ExpressionType.LessThan:
                    where.Append('<');
                    break;
                case ExpressionType.LessThanOrEqual:
                    where.Append("<=");
                    break;
                case ExpressionType.GreaterThan:
                    where.Append('>');
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    where.Append(">=");
                    break;
            }
            object right = type.GetProperty("Right").GetValue(body);
            BuildPart(right, where);
        }
    }

    static void BuildCallExpression(MethodCallExpression body, StringBuilder where)
    {
        var call = body.Method;
        switch (call.Name)
        {
            case "Contains":
                var args = body.Arguments[0];
                var expr = ((ConstantExpression)args.GetType().GetProperty("Expression").GetValue(args)).Value;
                var vals = string.Join(",", (long[])expr.GetType().GetFields().First().GetValue(expr));
                PropertyValue(body.Arguments[1], where);
                where.Append(" IN(").Append(vals).Append(')');
                break;
        }
    }

    static void BuildPart(object body, StringBuilder where)
    {
        switch ((ExpressionType)body.GetType().GetProperty("NodeType").GetValue(body))
        {
            case ExpressionType.AndAlso:
                BuildWhereString(body, where);
                break;

            case ExpressionType.Equal:
            case ExpressionType.NotEqual:
            case ExpressionType.LessThan:
            case ExpressionType.LessThanOrEqual:
            case ExpressionType.GreaterThan:
            case ExpressionType.GreaterThanOrEqual:
                BuildWhereString(body, where);
                break;

            case ExpressionType.MemberAccess:
                Type tbody = body.GetType().GetProperty("Expression").GetValue(body).GetType();
                if (tbody.Name.Equals("FieldExpression"))
                    ExpressionValue(body, where);
                else if (tbody.Name.Equals("ConstantExpression"))
                    FieldValue(body, where);
                else
                    PropertyValue(body, where);
                break;

            case ExpressionType.Constant:
                ConstantValue(body, where);
                break;

            case ExpressionType.Convert:
                ConvertValue(body, where);
                break;

            case ExpressionType.Not:
                NotValue(body, where);
                break;
        }
    }

    static void PropertyValue(object body, StringBuilder where)
    {
        var fld = body.GetType().GetProperty("Member").GetValue(body) as FieldInfo; // PropertyInfo
        if (fld == null)
        {
            var expr = body.GetType().GetProperty("Member").GetValue(body);
            where.Append('"').Append(expr.GetType().GetProperty("Name").GetValue(expr).ToString().ToLower()).Append('"');
        }
        else
            where.Append('"').Append(fld.Name.ToLower()).Append('"');
    }

    static void ConstantValue(object body, StringBuilder where)
    {
        where.Append(body.GetType().GetProperty("Value").GetValue(body, null));
    }

    static void ExpressionValue(object body, StringBuilder where)
    {
        var expr = body.GetType().GetProperty("Expression").GetValue(body);
        var exprName = (FieldInfo)expr.GetType().GetProperty("Member").GetValue(expr);
        var cons = expr.GetType().GetProperty("Expression").GetValue(expr);
        var valf = cons.GetType().GetProperty("Value").GetValue(cons);
        var val = valf.GetType().GetField(exprName.Name).GetValue(valf);
        if (body.GetType().GetProperty("Member").GetValue(body) is FieldInfo fi)
            where.Append(val.GetType().GetField(fi.Name).GetValue(val));
        else
            where.Append(val.GetType().GetProperty(((PropertyInfo)body.GetType().GetProperty("Member").GetValue(body)).Name).GetValue(val));
    }

    static void FieldValue(object body, StringBuilder where)
    {
        var name = ((FieldInfo)body.GetType().GetProperty("Member").GetValue(body)).Name;
        var expr = body.GetType().GetProperty("Expression").GetValue(body);
        var val = expr.GetType().GetProperty("Value").GetValue(expr);
        where.Append(val.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(val));
    }

    static void ConvertValue(object body, StringBuilder where)
    {
        var oper = ((UnaryExpression)body).Operand;
        var memb = (PropertyInfo)oper.GetType().GetProperty("Member").GetValue(oper);
        where.Append('"').Append(memb.Name).Append('"');
    }

    static void MemberValue(object body, StringBuilder where)
    {
        var memb = (PropertyInfo)body.GetType().GetProperty("Member").GetValue(body);
        where.Append('"').Append(memb.Name.ToLower()).Append("\"=").Append(memb.PropertyType.Equals(typeof(bool)) ? "true" : "false");
    }

    static void NotValue(object body, StringBuilder where)
    {
        var oper = ((UnaryExpression)body).Operand;
        var memb = (PropertyInfo)oper.GetType().GetProperty("Member").GetValue(oper);
        if (memb.PropertyType == typeof(bool))
            where.Append(memb.Name).Append("=False");
    }
}
