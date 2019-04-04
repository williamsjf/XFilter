using System;
using System.Collections.Generic;
using System.Linq;
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
            var parameter = Expression.Parameter(typeof(TObject), "target");
            var fullExpression = BuildFullExpression(clauses, parameter);

            return Expression.Lambda<Func<TObject, bool>>(fullExpression, parameter);
        }

        public LambdaExpression BuildExpression(object targetObj, IList<Clause> clauses)
        {
            var parameter = Expression.Parameter(targetObj.GetType(), "target");
            Expression fullExpression = BuildFullExpression(clauses, parameter);

            var func = typeof(Func<,>).MakeGenericType(targetObj.GetType(), typeof(bool));
            return Expression.Lambda(func, fullExpression, parameter);
        }

        public Func<TObject, bool> BuildPredicate<TObject>(IList<Clause> clauses)
        {
            return BuildExpression<TObject>(clauses).Compile();
        }

        public LambdaExpression BuildPredicate(object targetObj, IList<Clause> clauses)
        {
            return BuildExpression(targetObj, clauses);
        }

        private Expression BuildFullExpression(IList<Clause> clauses, ParameterExpression parameter)
        {
            Expression fullExpression = null;
            for (int i = 0; i < clauses.Count; i++)
            {
                var clause = clauses[i];

                var property = Expression.Property(parameter, clause.Member);
                var constant = Expression.Constant(clause.Value);

                IExpressionDataHandler expressionDataHandler = null;

                if (string.IsNullOrEmpty(clause.DataHandlerName))
                {
                    expressionDataHandler = ExpressionDataHandlerFactory.BuildDataHandler(clause.Value.GetType());
                }
                else
                {
                    expressionDataHandler = ExpressionDataHandlerFactory.BuildDataHandler(clause.DataHandlerName);
                }

                Expression expression = expressionDataHandler.BuildExpression(clause, property, constant);

                if (i == 0)
                {
                    fullExpression = expression;
                }
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

            return fullExpression;
        }

        public bool Evaluate(object targetObj, IList<Clause> clauses)
        {
            if (!IsCompatible(targetObj, clauses))
                throw new IncompatibleClauseException("There is an incompatible clause with the target object");

            var expression = BuildExpression(targetObj, clauses).Compile();
            return (bool)expression.DynamicInvoke(targetObj);
        }

        /// <summary>
        /// Checks whether the object contains the property with the same name and type.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="property"></param>
        private bool IsCompatible(object targetType, IList<Clause> clauses)
        {
            var targetProperties = targetType.GetType().GetProperties();

            foreach (var clause in clauses)
            {
                if (!targetProperties.Any(x => x.Name == clause.Member))
                    return false;

                var targetProperty = targetProperties.FirstOrDefault(x => x.Name == clause.Member);

                if (targetProperty.PropertyType.Name != clause.Value.GetType().Name)
                    return false;
            }

            return true;
        }
    }
}
