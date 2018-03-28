using System.Collections.Generic;

using Frings.SwePin.Data;
using Frings.SwePin.Models;

namespace Frings.SwePin.Abstractions
{
    public interface ICountiesRepository : IEnumerable<ICounty>
    {
        ICounty Get(int birthNumber);

        int GetRandomBirthNumber(County county, Sex sex = Sex.Unspecified);
    }
}
