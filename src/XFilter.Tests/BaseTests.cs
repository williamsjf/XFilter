using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XFilter.Tests
{
    public class BaseTests
    {
        public ICollection<Person> Persons = new Collection<Person>
        {
            new Person { Name = "Ana", Age = 32, BirthDate = new DateTime(1986, 05, 12), AccountBalance = 100000322332390323, IsActive = true },
            new Person { Name = "William", Age = 33, BirthDate = new DateTime(1990, 03, 2), AccountBalance = 1000000098987868767, IsActive = false },
        };
    }

    public class Person
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public long AccountBalance { get; set; }

        public bool IsActive { get; set; }
    }
}
