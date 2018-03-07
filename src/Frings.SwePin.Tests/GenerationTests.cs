using Frings.SwePin.Generation;

using NUnit.Framework;

namespace Frings.SwePin.Tests
{
    [TestFixture]
    public class GenerationTests
    {
        [Test]
        [Category("Unit")]
        public void GeneratePinBasedOnAge()
        {
            for (var age = 1; age < 110; ++age)
            {
                var pin =
                    Pin.Generation()
                        .WithAge(age)
                        .Generate();

                Assert.AreEqual(age, pin.Age);
            }
        }

        [Test]
        [Category("Unit")]
        public void GeneratePin()
        {
            var pin =
                Pin.Generation()
                    .Generate();

            Assert.IsTrue(!Pin.IsNullOrEmpty(pin));
            Assert.AreEqual(pin.BirthDate.Year, pin.Year);
        }
    }
}
