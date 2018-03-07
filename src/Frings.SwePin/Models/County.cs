using System;

namespace Frings.SwePin.Models
{
    public class County
    {
        public County(string name, Range range)
        {
            Name = name ?? throw new ArgumentException("Missing parameter value", nameof(name));
            Range = range ?? throw new ArgumentException("Missing parameter value", nameof(range));
        }

        public static County Empty;

        public string Name { get; set; }

        public Range Range { get; set; }

        public static bool IsNullOrEmpty(County county)
        {
            return county == null || county == Empty;
        }
    }
}
