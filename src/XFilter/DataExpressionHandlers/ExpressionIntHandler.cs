using System;
using System.Linq.Expressions;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionIntHandler : IExpressionDataHandler
    {
        public Type Type => typeof(int);

        public Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            switch (clause.Operator)
            {
                case Operator.Equal:
                    return this.Equals(clause, memberExpression, constantExpression);

                case Operator.NotEqual:
                    return this.NotEquals(clause, memberExpression, constantExpression);

                default:
                    throw new UnsupportedOperatorException(clause.Operator, Type);
            }
        }

        public virtual Expression Equals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
                throw new UnsupportedOperatorException(clause.Operator, Type);

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression NotEquals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
                throw new UnsupportedOperatorException(clause.Operator, Type);

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }
    }
}
