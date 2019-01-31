#nullable enable

using System;

namespace Frings.SwePin
{
    internal static class Static
    {
        private static readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        internal static Random Random => _random;

        internal static TimeProvider TimeProvider
    }
}
