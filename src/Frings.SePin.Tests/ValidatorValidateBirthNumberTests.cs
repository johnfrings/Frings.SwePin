using Frings.SePin.Data;

using NUnit.Framework;

namespace Frings.SePin.Tests
{
    [TestFixture]
    public class ValidatorValidateBirthNumberTests
    {
        [Test]
        [Category("Unit")]
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(505)]
        [TestCase(600)]
        [TestCase(999)]
        public void ValidBirthNumbersAreValid(int birthNumber)
        {
            Assert.IsTrue(Validator.ValidateBirthNumber(birthNumber).HasFlag(ValidationResult.Valid));
        }

        [Test]
        [Category("Unit")]
        [TestCase(-1)]
        [TestCase(1000)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void InvalidBirthNumbersAreNotValid(int birthNumber)
        {
            Assert.IsTrue(Validator.ValidateBirthNumber(birthNumber).HasFlag(ValidationResult.InvalidBirthNumber));
        }
    }
}
