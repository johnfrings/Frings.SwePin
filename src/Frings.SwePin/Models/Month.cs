using Frings.SwePin.Exceptions;

namespace Frings.SwePin.Models
{
    internal class Month
    {
        private int _month;

        public Month(int month)
        {
            if (month < 1 ||
                month > 12)
            {
                throw new InvalidMonthException();
            }

            _month = month;
        }

        public static implicit operator int(Month month)
        {
            return month._month;
        }

        public static implicit operator Month(int month)
        {
            return new Month(month);
        }
    }
}
