using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFilter.Engine;
using XFilter.Query;
using Xunit;

namespace XFilter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsMatch_Equal_And_StringStatement_SimpleStatements_Success()
        {
            var builder = new QueryBuilder();
            builder.AddClause("Name", "Ana", Operator.Equal, Connector.And);
            builder.AddClause("Age", 32, Operator.Equal, Connector.Or);
            builder.AddClause("Name", "William", Operator.Equal, Connector.None);

            var engine = new FilterEngine();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Name", "Ana");
            dictionary.Add("Age", 31);

            var obj = dictionary.BuildTargetObject();

            var isValid = engine.Evaluate(obj, builder.Clauses);


            var expression = engine.BuildPredicate<Person>(builder.Clauses);

            var result = Persons.Where(expression);
            Assert.True(result.Count() == 2);
        }

        #region Mock
        private ICollection<Person> Persons = new Collection<Person>
        {
            new Person{  Name = "Ana", Age = 32, Occupation = "Hairdresser", Hobby = "To Sleep" },
            new Person{  Name = "William", Age = 33, Occupation = "Programmer", Hobby = "Play soccer" },
            new Person{  Name = "Guilherme", Age = 1, Occupation = "Baby", Hobby = "Drive a car" },
        };

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Occupation { get; set; }
            public string Hobby { get; set; }
        }

        #endregion
    }
}
