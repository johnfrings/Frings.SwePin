using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin;
using Frings.SwePin.Exceptions;

using Xunit;

namespace Frings.SwePin.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData(1980)]
        [InlineData(2000)]
        [InlineData(0)]
        [InlineData(9999)]
        public void ValidYearIsValid(int year)
        {
            Validator.ValidateYear(year).Should().Be(Data.ValidationResult.Valid);
        }

        [Theory]
        [Category("Unit")]
        [InlineData(-1980)]
        [InlineData(-2000)]
        [InlineData(-1)]
        [InlineData(10000)]
        public void UnsupportedYearisUnsupported(int year)
        {
            Validator.ValidateYear(year).Should().Be(Data.ValidationResult.UnsupportedYear);
        }

        [Theory]
        [Category("Unit")]
        [InlineData("19791009-0045")]
        [InlineData("19791209-0045")]
        [InlineData("19791231-0045")]
        [InlineData("19791201-0045")]
        [InlineData("19790101-0045")]
        [InlineData("197901010045")]
        [InlineData("791009-0045")]
        [InlineData("791209-0045")]
        [InlineData("791231-0045")]
        [InlineData("791201-0045")]
        [InlineData("790101-0045")]
        [InlineData("791009+0045")]
        [InlineData("791209+0045")]
        [InlineData("791231+0045")]
        [InlineData("791201+0045")]
        [InlineData("790101+0045")]
        [InlineData("7910090045")]
        [InlineData("7912090045")]
        [InlineData("7912310045")]
        [InlineData("7912010045")]
        [InlineData("7901010045")]
        public void ValidInputFormatIsValid(string input)
        {
            Validator.ValidateInputFormat(input).Should().Be(Data.ValidationResult.Valid);
        }

        [Theory]
        [Category("Unit")]
        [InlineData("19791309-0045")]
        [InlineData("19791232-0045")]
        [InlineData("19791200-0045")]
        [InlineData("19790001-0045")]
        [InlineData("19790101+0045")]
        [InlineData("791309-0045")]
        [InlineData("791232-0045")]
        [InlineData("791200-0045")]
        [InlineData("790001-0045")]
        [InlineData("791309+0045")]
        [InlineData("791232+0045")]
        [InlineData("791200+0045")]
        [InlineData("790001+0045")]
        [InlineData("7913090045")]
        [InlineData("7912320045")]
        [InlineData("7912000045")]
        [InlineData("7900010045")]
        public void InvalidInputFormatIsInvalid(string input)
        {
            Validator.ValidateInputFormat(input).Should().Be(Data.ValidationResult.InvalidInputFormat);
        }

        //// TODO: valid month
        //// TODO: invalid month
        //// TODO: valid day
        //// TODO: invalid day

    }
}
