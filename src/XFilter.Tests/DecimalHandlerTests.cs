using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class DecimalHandlerTests : BaseTests
    {
        [Fact]
        public void Decimal_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("Debit", 100m, Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 1);
        }
    }
}
