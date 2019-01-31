using System;
using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin.Math;
using Frings.SwePin.Models;

using Xunit;

namespace Frings.SwePin.Tests.Math
{
    public class SexTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData(0, Data.Sex.Female)]
        [InlineData(1, Data.Sex.Male)]
        [InlineData(2, Data.Sex.Female)]
        [InlineData(3, Data.Sex.Male)]
        [InlineData(4, Data.Sex.Female)]
        [InlineData(5, Data.Sex.Male)]
        [InlineData(6, Data.Sex.Female)]
        [InlineData(7, Data.Sex.Male)]
        [InlineData(8, Data.Sex.Female)]
        [InlineData(9, Data.Sex.Male)]
        public void CanGetGenderFromIntegerBirthNumber(int birthNumber, Data.Sex expected) =>
            Sex.GetGenderFromBirthNumber(birthNumber).Should().Be(expected);

        [Theory]
        [Category("Unit")]
        [InlineData(0, Data.Sex.Female)]
        [InlineData(1, Data.Sex.Male)]
        [InlineData(2, Data.Sex.Female)]
        [InlineData(3, Data.Sex.Male)]
        [InlineData(4, Data.Sex.Female)]
        [InlineData(5, Data.Sex.Male)]
        [InlineData(6, Data.Sex.Female)]
        [InlineData(7, Data.Sex.Male)]
        [InlineData(8, Data.Sex.Female)]
        [InlineData(9, Data.Sex.Male)]
        public void CanGetGenderFromBirthNumber(int birthNumber, Data.Sex expected) =>
            Sex.GetGenderFromBirthNumber((BirthNumber)birthNumber).Should().Be(expected);

        [Fact]
        [Category("Unit")]
        public void CanGetRandom()
        {
            Sex.GetRandom().Should().Match<Data.Sex>(r => r == Data.Sex.Male || r == Data.Sex.Female);
        }

        [Fact]
        [Category("Unit")]
        public void CanGetRandomBirthNumber()
        {
            (Sex.GetRandomBirthNumber(Data.Sex.Female) % 2 == 0).Should().BeTrue();
            (Sex.GetRandomBirthNumber(Data.Sex.Male) % 2 == 0).Should().BeFalse();

            for (var i = 0; i < 200; ++i)
            {
                Sex.GetRandomBirthNumber().Should().BeInRange(0, 999);
            }
        }
    }
}
