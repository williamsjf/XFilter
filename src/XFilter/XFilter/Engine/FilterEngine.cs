using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using XFilter.DataExpressionHandlers;
using XFilter.Exceptions;
using XFilter.Query;

namespace XFilter.Engine
{
    public class FilterEngine
    {
        public Expression<Func<TObject, bool>> BuildExpression<TObject>(IList<Clause> clauses)
        {
            Expression fullExpression = null;

            var parameter = Expression.Parameter(typeof(TObject), "target");

            for (int i = 0; i < clauses.Count; i++)
            {
                var clause = clauses[i];

                var propertyType = clause.Value.GetType();

                var property = Expression.Property(parameter, clause.Member);
                var constant = Expression.Constant(clause.Value);

                IExpressionDataHandler expressionDataHandler = null;

                if (string.IsNullOrEmpty(clause.DataHandlerName))
                    expressionDataHandler = ExpressionDataHandlerFactory.BuildDataHandler(clause.Value.GetType());
                else
                    expressionDataHandler = ExpressionDataHandlerFactory.BuildDataHandler(clause.DataHandlerName);

                Expression expression = expressionDataHandler.BuildExpression(clause, property, constant);

                if (i == 0)
                    fullExpression = expression;
                else
                {
                    var lastStatementConnector = clauses[i - 1].Connector;

                    switch (lastStatementConnector)
                    {
                        case Connector.And:
                            {
                                fullExpression = Expression.And(fullExpression, expression);
                                break;
                            }
                        case Connector.Or:
                            {
                                fullExpression = Expression.Or(fullExpression, expression);
                                break;
                            }

                        default:
                            throw new InvalidClauseConnectorException(lastStatementConnector);
                    }
                }
            }

            return Expression.Lambda<Func<TObject, bool>>(fullExpression, parameter);
        }

        public Func<TObject, bool> BuildPredicate<TObject>(IList<Clause> clauses)
        {
            return BuildExpression<TObject>(clauses).Compile();
        }
    }
}
