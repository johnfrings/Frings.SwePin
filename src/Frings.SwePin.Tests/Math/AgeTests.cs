using System;

using Frings.SwePin.Math;

using NUnit.Framework;

namespace Frings.SwePin.Tests.Math
{
    [TestFixture]
    public class AgeTests
    {
        [Test]
        [Category("Unit")]
        [TestCase(39, 1978, 2018, 3, 3, 12)]
        [TestCase(39, 1978, 2018, 11, 11, 12)]
        [TestCase(39, 1978, 2018, 1, 1, 12)]
        public void PossibleBirthMonths(int age, int birthYear, int nowYear, int nowMonth, int expectedFrom, int expectedTo)
        {
            var result = Age.PossibleBirthMonths(age, birthYear, new DateTime(nowYear, nowMonth, 1));

            Assert.AreEqual(expectedFrom, result.From);
            Assert.AreEqual(expectedTo, result.To);
        }

        [Test]
        [Category("Unit")]
        [TestCase(39, 2018, 1978, 1979)]
        [TestCase(25, 2018, 1992, 1993)]
        [TestCase(1, 2018, 2016, 2017)]
        [TestCase(0, 2018, 2017, 2018)]
        public void PossibleBirthYears(int age, int nowYear, int expectedFrom, int expectedTo)
        {
            var result = Age.PossibleBirthYears(age, new DateTime(nowYear, 1, 1));

            Assert.AreEqual(expectedFrom, result.From);
            Assert.AreEqual(expectedTo, result.To);
        }
    }
}
