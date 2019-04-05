using System;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class DateTimeHandlerTests : BaseTests
    {
        [Fact]
        public void DateTime_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 12), Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void DateTime_NotEquals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 11), Operator.NotEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void DateTime_GreaterThan()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 10), Operator.GreaterThan, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void DateTime_GreaterThanOrEqual()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 12), Operator.GreaterThanOrEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void DateTime_LessThan()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1990, 03, 2), Operator.LessThan, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void DateTime_LessThanOrEqual()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1990, 03, 2), Operator.LessThanOrEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Person>(builder.Clauses);
            var result = Persons.Where(expression);

            Assert.True(result.Count() == 2);
        }
    }
}
