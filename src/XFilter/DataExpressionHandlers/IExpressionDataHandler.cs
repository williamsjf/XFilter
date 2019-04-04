using System;
using System.Linq.Expressions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public interface IExpressionDataHandler
    {
        Type Type { get; }

        Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression);
    }
}
