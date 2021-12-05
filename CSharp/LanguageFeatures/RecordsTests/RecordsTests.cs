using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace RecordsTests
{
    //Reference doc: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records
    public class RecordsTests
    {
        private readonly ITestOutputHelper output;

        public RecordsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void RecordsStructs_ValueEquality()
        {
            var dt1 = new DailyTemperature(25, 20);
            var dt2 = new DailyTemperature(25, 20);
            var dt3 = new DailyTemperature(25, 21);

            output.WriteLine(dt1.ToString());
            output.WriteLine(dt2.GetHashCode().ToString());

            Assert.Equal(dt1, dt2);
            Assert.NotEqual(dt1, dt3);
        }

        [Fact]
        public void RecordsClasses_ValueEquality()
        {
            var data = new[]
            {
                new DailyTemperature(25, 20),
                new DailyTemperature(25, 20),
                new DailyTemperature(25, 21)
            };


            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            output.WriteLine(heatingDegreeDays.ToString());

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            output.WriteLine(coolingDegreeDays.ToString());
        }

        [Fact]
        public void RecordsWith_ValueEquality()
        {
            var data = new[]
            {
                new DailyTemperature(25, 20),
                new DailyTemperature(25, 20),
                new DailyTemperature(25, 21)
            };

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            output.WriteLine(coolingDegreeDays.ToString());

            var growingDegreeDays = coolingDegreeDays with { BaseTemperature = 41 };
            output.WriteLine(growingDegreeDays.ToString());
        }
    
        [Fact]
        public void Records_Positional()
        {
            var firstName = "Mohamed";
            var lastName = "Nasri";

            var person = new Person(firstName, lastName);
            var person2 = new Person(firstName, lastName);

            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);

            Assert.Equal(person, person2);
        }
    }

    #region types

    //Positional Parameters
    public record Person(string FirstName, string LastName);

    public readonly record struct DailyTemperature(double HighTemp, double LowTemp)
    {
        public double Mean => (HighTemp - LowTemp) / 2.0;
    }

    public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);

    public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
    }

    public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
        : DegreeDays(BaseTemperature, TempRecords)
    {
        public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
    }
    #endregion
}