using Frings.SwePin.Data;

using NUnit.Framework;

namespace Frings.SwePin.Tests
{
    [TestFixture]
    public class ValidatorValidateDayTests
    {
        [Test]
        [Category("Unit")]
        [TestCase(1)]
        [TestCase(8)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(23)]
        [TestCase(31)]
        public void ValidDaysAreValid(int dayNumber)
        {
            Assert.IsTrue(Validator.ValidateDay(dayNumber).HasFlag(ValidationResult.Valid));
        }

        [Test]
        [Category("Unit")]
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(32)]
        [TestCase(99)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void InvalidDaysAreNotValid(int dayNumber)
        {
            Assert.IsTrue(Validator.ValidateDay(dayNumber).HasFlag(ValidationResult.InvalidDayNumber));
        }
    }
}
