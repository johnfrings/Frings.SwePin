using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin;

using Xunit;

namespace Frings.SwePin.Tests
{
    public class InputCleanerTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData("09ma8e-rt907+835890w7", "098-907+8358907")]
        [InlineData("abcdefghijklmnopqrstuvwxyzåäö!\"#¤%&/()=[]{}*/\\`´§½@£$^¨'", "")]
        [InlineData("0123456789+-", "0123456789+-")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Test1(string input, string expected)
        {
            InputCleaner.Clean(input).Should().Be(expected);
        }
    }
}
