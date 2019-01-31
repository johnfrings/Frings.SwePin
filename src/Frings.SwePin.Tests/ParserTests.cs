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
        [InlineData("198012251234", 1980)]
        [InlineData("801225-1234", 1980)]
        [InlineData("801225+1234", 1880)]
        [InlineData("8012251234", 1980)]
        [InlineData("1901011234", 2019)]
        [InlineData("1902011234", 1919)]
        [InlineData("190201-1234", 1919)]
        [InlineData("190201+1234", 1919)]
        [InlineData("2001011234", 1920)]
        [InlineData("2101011234", 1921)]
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
