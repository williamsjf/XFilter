using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class BooleanHandlerTests : BaseTests
    {
        [Fact]
        public void DateTime_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("IsActive", true, Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 1);
        }
    }
}
