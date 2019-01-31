using System;
using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin.Math;

using Xunit;

namespace Frings.SwePin.Tests.Math
{
    public class ControlNumberTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData(1980, 12, 25, 123, 0)]
        public void CanGetFromDateTime(int year, int month, int day, int birthNumber, int expectedControlNumber)
        {
            ControlNumber.Get(new DateTime(year, month, day), birthNumber).Should().Be(expectedControlNumber);
        }

        [Theory]
        [Category("Unit")]
        [InlineData(1980, 12, 25, 123, 0)]
        public void CanGet(int year, int month, int day, int birthNumber, int expectedControlNumber)
        {
            ControlNumber.Get(year, month, day, birthNumber).Should().Be(expectedControlNumber);
        }
    }
}
