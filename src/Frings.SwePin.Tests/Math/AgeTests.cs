using System.ComponentModel;

using FluentAssertions;

using Frings.SwePin.Math;

using Xunit;

namespace Frings.SwePin.Tests.Math
{
    public class AgeTests
    {
        [Theory]
        [Category("Unit")]
        [InlineData(0, Data.Sex.Female)]
        public void CanGetGenderFromIntegerBirthNumber(int birthNumber, Data.Sex expected)
        {
            Age.Get
            
        }
            
    }
}
