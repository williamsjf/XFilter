using System;
using System.Linq.Expressions;
using XFilter.Query;

namespace XFilter.DataExpressionHandlers
{
    public interface IExpressionDataHandler
    {
        Expression BuildExpression(Clause clause, MemberExpression memberExpression, ConstantExpression constantExpression);
    }
}
