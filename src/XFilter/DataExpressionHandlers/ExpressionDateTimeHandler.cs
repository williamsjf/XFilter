using System;
using System.Linq.Expressions;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionDateTimeHandler : IExpressionDataHandler
    {
        public Type Type => typeof(DateTime);

        public Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            switch (clause.Operator)
            {
                case Operator.Equal:
                    return Equals(clause, memberExpression, constantExpression);

                case Operator.NotEqual:
                    return NotEquals(clause, memberExpression, constantExpression);

                case Operator.GreaterThan:
                    return GreaterThan(clause, memberExpression, constantExpression);

                case Operator.GreaterThanOrEqual:
                    return GreaterThanOrEqual(clause, memberExpression, constantExpression);

                case Operator.LessThan:
                    return LessThan(clause, memberExpression, constantExpression);

                case Operator.LessThanOrEqual:
                    return LessThanOrEqual(clause, memberExpression, constantExpression);

                default:
                    throw new UnsupportedOperatorException(clause.Operator, Type);
            }
        }

        public virtual Expression Equals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression NotEquals(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression GreaterThan(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression GreaterThanOrEqual(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression LessThan(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }

        public virtual Expression LessThanOrEqual(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            ExpressionType expressionType;

            if (!Enum.TryParse(clause.Operator.ToString(), out expressionType))
            {
                throw new UnsupportedOperatorException(clause.Operator, Type);
            }

            return Expression.MakeBinary(expressionType, memberExpression, constantExpression);
        }
    }
}
