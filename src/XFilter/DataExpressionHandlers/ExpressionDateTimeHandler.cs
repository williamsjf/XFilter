using System;
using System.Linq.Expressions;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionDateTimeHandler : DataHandler<DateTime>, IExpressionDataHandler
    {
        public override Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
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
                    throw new UnsupportedOperatorException(clause.Operator, typeof(DateTime));
            }
        }
    }
}
