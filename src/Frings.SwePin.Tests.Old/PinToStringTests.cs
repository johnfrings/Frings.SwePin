using Frings.SwePin.Generation;

using NUnit.Framework;

namespace Frings.SwePin.Tests
{
    [TestFixture]
    public class PinToStringTests
    {
        [Test]
        [Category("Unit")]
        public void ToStringDefault()
        {
            var pin = Pin.Generation().BornYear(1992).BornMonth(12).BornDay(24).Generate();

            var result = pin.ToString();

            Assert.AreEqual(pin.Year.ToString(), result.Substring(0, 4));
            Assert.AreEqual(pin.Month.ToString("D2"), result.Substring(4, 2));
            Assert.AreEqual(pin.Day.ToString("D2"), result.Substring(6, 2));
        }
    }
}
