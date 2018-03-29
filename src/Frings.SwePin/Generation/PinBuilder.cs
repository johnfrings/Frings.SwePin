using System;

using Frings.SwePin.Abstractions;
using Frings.SwePin.Data;

namespace Frings.SwePin.Generation
{
    public class PinBuilder
    {
        private int? _age;
        private Sex _sex;
        private ICounty _county;

        private int? _year;
        private int? _month;
        private int? _day;

        public PinBuilder BornIn(ICounty county)
        {
            _county = county;

            return this;
        }

        public PinBuilder WithAge(int age)
        {
            _age = age;

            return this;
        }

        public PinBuilder WithSex(Sex sex)
        {
            _sex = sex;

            return this;
        }

        public PinBuilder WithYear(int year)
        {
            _year = year;

            return this;
        }

        public PinBuilder WithMonth(int month)
        {
            _month = month;

            return this;
        }

        public PinBuilder WithDay(int day)
        {
            _day = day;

            return this;
        }

        public Pin Build()
        {
            if (!_age.HasValue)
            {
                var birthDate = GenerateBirthDate();

                return new Pin(birthDate.Year, birthDate.Month, birthDate.Day, GenerateBirthNumber(), null);
            }

            return new Pin(0, 0, 0, 0, null);
        }

        private int GenerateBirthNumber()
        {
            if (_county != null &&
                _year.HasValue &&
                _year.Value < 1990)
            {
                var initialBirthNumber =
                    Static.Random.Next(_county.Range.From, (int) System.Math.Floor((double)_county.Range.To / 2)) * 2;

                if (_sex == Sex.Male)
                {
                    return initialBirthNumber + 1;
                }

                return initialBirthNumber;
            }

            if (_sex == Sex.Male)
            {
                return Static.Random.Next(0, 499) * 2 + 1;
            }

            if (_sex == Sex.Female)
            {
                return Static.Random.Next(0, 499) * 2;
            }

            return Static.Random.Next(1, 999);
        }

        private DateTime GenerateBirthDate()
        {
            if (!_year.HasValue)
            {
                var initialRandomYear = DateTime.Now.AddYears(-Static.Random.Next(0, 100)).Year;

                // Randomly increase or reduce the random year up or down to get a lower number of really low or really high results.
                var maxToSubtract =
                    (int) System.Math.Floor(System.Math.PI *
                                            System.Math.Tan((initialRandomYear + 60) / System.Math.PI * 110));
                _year = initialRandomYear - Static.Random.Next(System.Math.Min(0, maxToSubtract), System.Math.Max(0, maxToSubtract));
            }

            if (!_month.HasValue)
            {
                _month = Static.Random.Next(1, 12);
            }

            if (!_day.HasValue)
            {
                _day = Static.Random.Next(1, DateTime.DaysInMonth(_year.Value, _month.Value));
            }

            return new DateTime(_year.Value, _month.Value, _day.Value);
        }
    }
}
