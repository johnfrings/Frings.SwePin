using Frings.SePin.Data;

using NUnit.Framework;

namespace Frings.SePin.Tests
{
    [TestFixture]
    public class ValidatorValidateMonthTests
    {
        [Test]
        [Category("Unit")]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(12)]
        public void ValidMonthsAreValid(int monthNumber)
        {
            Assert.IsTrue(Validator.ValidateMonth(monthNumber).HasFlag(ValidationResult.Valid));
        }

        [Test]
        [Category("Unit")]
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(13)]
        [TestCase(99)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void InvalidMonthsAreNotValid(int monthNumber)
        {
            Assert.IsTrue(Validator.ValidateMonth(monthNumber).HasFlag(ValidationResult.InvalidMonthNumber));
        }
    }
}
