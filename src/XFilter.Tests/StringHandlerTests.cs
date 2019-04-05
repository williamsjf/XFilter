using System.Collections.Generic;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class StringHandlerTests : BaseTests
    {
        [Fact]
        public void IsMatch_Equal_And_StringStatement_SimpleStatements_Success()
        {
            var builder = new QueryBuilder();
            builder.AddClause("Name", "Ana", Operator.Equal, Connector.And);
            builder.AddClause("Age", 32, Operator.Equal, Connector.Or);

            var engine = new FilterEngine();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Name", "Ana");
            dictionary.Add("Age", 32);

            var obj = dictionary.BuildTargetObject();

            var isValid = engine.Evaluate(obj, builder.Clauses);

            var expression = engine.BuildPredicate<Person>(builder.Clauses);

            var result = Persons.Where(expression);
            Assert.True(result.Count() == 1);
        }
    }
}
