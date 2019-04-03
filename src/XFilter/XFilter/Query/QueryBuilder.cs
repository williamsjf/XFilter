using System.Collections.Generic;

namespace XFilter.Query
{
    public class QueryBuilder
    {
        public QueryBuilder()
        {
            Clauses = new List<Clause>();
        }

        public IList<Clause> Clauses { get; private set; }

        public QueryBuilder AddClause(Clause clause)
        {
            Clauses.Add(clause);
            return this;
        }

        public QueryBuilder AddClause(
            string fieldName,
            object value,
            Operator @operator,
            Connector connector)
        {
            Clauses.Add(new Clause
            {
                Member = fieldName,
                Value = value,
                Connector = connector,
                Operator = @operator,
                DataHandlerName = string.Empty,
            });

            return this;
        }

        public QueryBuilder AddClause(
            string fieldName,
            object value,
            Operator @operator,
            Connector connector,
            string dataHandlerName)
        {
            Clauses.Add(new Clause
            {
                Member = fieldName,
                Value = value,
                Connector = connector,
                Operator = @operator,
                DataHandlerName = dataHandlerName,
            });

            return this;
        }
    }
}
