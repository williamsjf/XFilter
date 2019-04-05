using System;
using System.Collections.ObjectModel;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class DateTimeHandlerTests
    {
        [Fact]
        public void DateTime_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 12), Operator.Equal, Connector.And);
            builder.AddClause("SendDate", new DateTime(2018, 08, 01), Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void DateTime_NotEquals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 11), Operator.NotEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void DateTime_GreaterThan()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1990, 05, 10), Operator.GreaterThan, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void DateTime_GreaterThanOrEqual()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1986, 05, 12), Operator.GreaterThanOrEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 2);
        }

        [Fact]
        public void DateTime_LessThan()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1990, 05, 12), Operator.LessThan, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void DateTime_LessThanOrEqual()
        {
            var builder = new QueryBuilder();
            builder.AddClause("BirthDate", new DateTime(1990, 05, 12), Operator.LessThanOrEqual, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<DateTimeMock>(builder.Clauses);
            var result = DateTimeMock.Where(expression);

            Assert.True(result.Count() == 2);
        }

        private readonly Collection<DateTimeMock> DateTimeMock = new Collection<DateTimeMock>()
        {
            new DateTimeMock { BirthDate = new DateTime(1986, 05, 12), SendDate = new DateTime(2018, 08, 01) },
            new DateTimeMock { BirthDate = new DateTime(1990, 05, 12), SendDate = new DateTime(2017, 09, 01) },
        };
    }

    public class DateTimeMock
    {
        public DateTime BirthDate { get; set; }
        public DateTime SendDate { get; set; }
    }
}
