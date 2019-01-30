using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin;
using Frings.SwePin.Exceptions;

using Xunit;

namespace Frings.SwePin.Tests
{
    public class ParserTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData("19801225-1234", 1980)]
        [InlineData("801225-1234", 1980)]
        public void CanParse(string input, int expectedYear)
        {
            var result = Parser.Parse(input);

            result.Year.Should().Be(expectedYear);
        }

        [Theory]
        [Category("Unit")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abc")]
        [InlineData("1234123412341234")]
        public void ShouldThrowValidationException(string input)
        {
            Assert.Throws<ValidationException>(() => Parser.Parse(input));
        }
    }
}
