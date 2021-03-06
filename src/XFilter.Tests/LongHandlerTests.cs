﻿using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class LongHandlerTests : BaseTests
    {
        [Fact]
        public void DateTime_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("AccountBalance", 1000000098987868767, Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 1);
        }
    }
}
