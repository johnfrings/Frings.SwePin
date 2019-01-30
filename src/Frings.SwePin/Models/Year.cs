using Frings.SwePin.Exceptions;

namespace Frings.SwePin.Models
{
    internal class Year
    {
        private int _year;

        public Year()
        {
            _year = 0;
        }

        public Year(int year)
        {
            if (year < 0 ||
                year > 9999)
            {
                throw new UnsupportedYearException();
            }

            _year = year;
        }

        public static implicit operator int(Year year)
        {
            return year._year;
        }

        public static implicit operator Year(int year)
        {
            return new Year(year);
        }
    }
}
