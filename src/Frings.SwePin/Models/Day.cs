using Frings.SwePin.Exceptions;

namespace Frings.SwePin.Models
{
    internal class Day
    {
        private int _day;

        public Day(int day)
        {
            if (day < 1 ||
                day > 31)
            {
                throw new InvalidDayException();
            }

            _day = day;
        }

        public static implicit operator int(Day day)
        {
            return day._day;
        }

        public static implicit operator Day(int day)
        {
            return new Day(day);
        }
    }
}
