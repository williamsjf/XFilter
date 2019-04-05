using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class LongHandlerTests
    {
        [Fact]
        public void DateTime_Equals()
        {
            var builder = new QueryBuilder();
            builder.AddClause("Balance", 1000000000000000455, Operator.Equal, Connector.And);
            builder.AddClause("Name", "William", Operator.Equal, Connector.And);

            var engine = new FilterEngine();

            var expression = engine.BuildPredicate<Account>(builder.Clauses);
            var result = Accounts.Where(expression);

            Assert.True(result.Count() == 1);
        }

        public ICollection<Account> Accounts = new Collection<Account>
        {
            new Account {  Balance = 1000000000000000455, Name = "William" },
            new Account {  Balance = 5098080987098798760, Name = "Jhon" },
            new Account {  Balance = 4321, Name = "Ana" },
        };
    }

    public class Account
    {
        public long Balance { get; set; }
        public string Name { get; set; }
    }
}
