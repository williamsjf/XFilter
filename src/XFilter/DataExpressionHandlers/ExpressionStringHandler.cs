using System;
using System.Linq.Expressions;
using System.Reflection;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionStringHandler : DataHandler<string>
    {
        public Type Type => typeof(string);

        public override Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            switch (clause.Operator)
            {
                case Operator.Equal:
                    return Equals(clause, memberExpression, constantExpression);

                case Operator.Contains:
                    return Contains(clause, memberExpression, constantExpression);

                case Operator.NotContains:
                    return NotContains(clause, memberExpression, constantExpression);

                case Operator.NotEqual:
                    return NotEquals(clause, memberExpression, constantExpression);

                default:
                    throw new UnsupportedOperatorException(clause.Operator, Type);
            }
        }

        public virtual Expression Contains(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            return Expression.Call(memberExpression, method, constantExpression);
        }

        public virtual Expression NotContains(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var call = Expression.Call(memberExpression, method, constantExpression);

            return Expression.Not(call);
        }
    }
}
