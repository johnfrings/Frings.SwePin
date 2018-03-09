using System;

namespace Frings.SwePin
{
    internal static class Static
    {
        internal static Random Random = new Random((int)DateTime.Now.Ticks);
    }
}
