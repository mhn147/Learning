using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace RecordsTests
{
    public class InitProperties
    {
        private readonly ITestOutputHelper output;

        public InitProperties(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void InitOnly_Positional()
        {
            var human = new Human("A", "B", 25);
            var human2 = new Human
            {
                FirstName = "A",
                LastName = "B",
                Age = 25,
            };
        }
    }

    class Human
    {
        public Human()
        {

        }

        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
    }
}