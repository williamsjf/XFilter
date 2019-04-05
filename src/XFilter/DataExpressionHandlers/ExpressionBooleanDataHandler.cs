using System;
using System.Linq.Expressions;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public class ExpressionBooleanDataHandler : DataHandler<bool>
    {
        public override Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression)
        {
            switch (clause.Operator)
            {
                case Operator.Equal:
                    return Equals(clause, memberExpression, constantExpression);

                case Operator.NotEqual:
                    return NotEquals(clause, memberExpression, constantExpression);

                case Operator.Contains:
                case Operator.NotContains:
                case Operator.StartsWith:
                case Operator.EndsWith:
                case Operator.GreaterThan:
                case Operator.LessThan:
                case Operator.GreaterThanOrEqual:
                case Operator.LessThanOrEqual:
                    throw new NotImplementedException();

                default:
                    throw new UnsupportedOperatorException(clause.Operator, typeof(bool));
            }
        }
    }
}
