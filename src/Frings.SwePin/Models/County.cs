using System;

using Frings.SwePin.Abstractions;

namespace Frings.SwePin.Models
{
    public class County : ICounty
    {
        public County(string name, Range range)
        {
            Name = name ?? throw new ArgumentException("Missing parameter value", nameof(name));
            Range = range ?? throw new ArgumentException("Missing parameter value", nameof(range));
        }

        public string Name { get; set; }

        public Range Range { get; set; }
    }
}
