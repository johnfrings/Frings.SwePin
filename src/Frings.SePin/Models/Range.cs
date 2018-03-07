using System;

namespace Frings.SePin.Models
{
    public class Range : IComparable<int>
    {
        public Range(int from, int to)
        {
            if (from > to)
            {
                throw new ArgumentException("The 'from' value must be lower than or equal to the 'to' value");
            }

            From = from;
            To = to;
        }

        public int From { get; }

        public int To { get; }

        public bool Contains(int value)
        {
            return value >= From && value <= To;
        }

        public int CompareTo(int value)
        {
            if (value < From)
            {
                return -1;
            }

            if (value > To)
            {
                return 1;
            }

            return 0;
        }
    }
}
