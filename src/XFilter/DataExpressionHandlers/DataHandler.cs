using System;
using System.Linq.Expressions;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public abstract class DataHandler<TType> : IExpressionDataHandler
    {
        public abstract Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression);

        public virtual Expression Equals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression NotEquals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression GreaterThan(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression GreaterThanOrEqual(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression LessThan(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression LessThanOrEqual(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, typeof(TType));
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }
    }
}
