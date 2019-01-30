#nullable enable

using Frings.SwePin.Data;
using Frings.SwePin.Models;

namespace Frings.SwePin.Generation
{
    public class GenerationConfig
    {
        internal int? Age { get; set; }

        internal Sex Sex { get; set; }

        internal int? Year { get; set; }

        internal int? Month { get; set; }

        internal int? Day { get; set; }
    }
}
