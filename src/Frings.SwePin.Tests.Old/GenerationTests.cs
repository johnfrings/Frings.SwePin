using System.Linq;
using Frings.SwePin.Generation;

using NUnit.Framework;

namespace Frings.SwePin.Tests
{
    [TestFixture]
    public class GenerationTests
    {
        [Test]
        [Category("Unit")]
        public void GenerateBasedOnAge()
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
        public void Generate()
        {
            var pin =
                Pin.Generation()
                    .Generate();

            Assert.IsTrue(!Pin.IsNullOrEmpty(pin));
            Assert.AreEqual(pin.BirthDate.Year, pin.Year);
        }

        [Test]
        [Category("Unit")]
        public void GenerateManyBasedOnAge()
        {
            var pins =
                Pin.Generation()
                    .WithAge(25)
                    .GenerateMany(1000)
                    .OrderBy(p => p)
                    .ToList();

            Assert.AreEqual(1000, pins.Count);

            foreach (var pin in pins)
            {
                Assert.AreEqual(25, pin.Age);
            }
        }
    }
}
