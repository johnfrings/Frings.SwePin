using Frings.SePin.Data;
using Frings.SePin.Models;

namespace Frings.SePin.Generation
{
    public class GenerationConfig
    {
        internal int? Age { get; set; }

        internal Sex Sex { get; set; }

        internal County County { get; set; }

        internal int? Year { get; set; }

        internal int? Month { get; set; }

        internal int? Day { get; set; }
    }
}
