using System;
using System.Collections.Generic;
using System.Text;

namespace Frings.SePin.Generation
{
    public static class GeneratorExtensions
    {
        public static GenerationConfig Setup(this Generator generator)
        {
            return new GenerationConfig();
        }
    }
}
