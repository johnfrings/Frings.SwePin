using Frings.SwePin.Models;

namespace Frings.SwePin.Abstractions
{
    public interface ICounty
    {
        string Name { get; set; }

        Range Range { get; set; }
    }
}
