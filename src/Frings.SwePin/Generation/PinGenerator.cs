using System;
using Frings.SwePin.Abstractions;
using Frings.SwePin.Data;

namespace Frings.SwePin.Generation
{
    public class PinGenerator
    {
        private int? _age;
        private Sex _sex;
        private ICounty _county;

        private int? _year;
        private int? _month;
        private int? _day;

        private PinGenerator()
        {
        }

        public static PinGenerator Configure()
        {
            return new PinGenerator();
        }

        public PinGenerator BornIn(ICounty county)
        {
            _county = county;

            return this;
        }

        public PinGenerator WithAge(int age)
        {
            _age = age;

            return this;
        }

        public PinGenerator WithSex(Sex sex)
        {
            _sex = sex;

            return this;
        }

        public PinGenerator WithYear(int year)
        {
            _year = year;

            return this;
        }

        public PinGenerator WithMonth(int month)
        {
            _month = month;

            return this;
        }

        public PinGenerator WithDay(int day)
        {
            _day = day;

            return this;
        }

        public Pin Generate()
        {
            if (!_year.HasValue)
            {
                
            }

            return new Pin(0, 0, 0, 0, null);
        }

        private DateTime GetBirthDateFromAge()
        {
            var now = DateTime.Now;

            if (!_year.HasValue)
            {

            }

            return DateTime.MaxValue;
        }
    }
}
