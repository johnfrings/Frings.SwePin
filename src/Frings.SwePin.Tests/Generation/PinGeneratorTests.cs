using System;

using Frings.SwePin.Data;
using Frings.SwePin.Models;

using NUnit.Framework;

namespace Frings.SwePin.Tests.Generation
{
    [TestFixture]
    public class PinGeneratorTests
    {
        [Test]
        [Category("Unit")]
        public void BuildRandom()
        {
            var result = Pin.CreateBuilder().Build();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Year > DateTime.Now.AddYears(-101).Year && result.Year < DateTime.Now.AddYears(1).Year);
        }

        [Test]
        [Category("Unit")]
        [TestCase(1985, 12, 24, Sex.Male)]
        [TestCase(1995, 12, 24, Sex.Male)]
        [TestCase(1985, 12, 24, Sex.Female)]
        [TestCase(1995, 12, 24, Sex.Female)]
        public void Build(int year, int month, int day, Sex sex)
        {
            var result =
                Pin.CreateBuilder()
                    .WithYear(year)
                    .WithMonth(month)
                    .WithDay(day)
                    .WithSex(sex)
                    .WithBirthCounty(() => new County("Foo", new Range(100, 200)))
                    .Build();

            Assert.AreEqual(year, result.Year);
            Assert.AreEqual(month, result.Month);
            Assert.AreEqual(day, result.Day);
            Assert.AreEqual(sex, result.Sex);

            if (year >= 1990)
            {
                Assert.IsNull(result.County);
            }
        }
    }
}
