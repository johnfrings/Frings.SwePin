using System;

using Frings.SePin.Data;
using Frings.SePin.Exceptions;
using Frings.SePin.Generation;
using Frings.SePin.Models;

namespace Frings.SePin
{
    public sealed class Pin : IComparable<Pin>, IComparable<DateTime>
    {
        private int? _age;
        private Sex _sex;
        private DateTime? _birthDate;
        private County _county;

        internal Pin(int year, int month, int day, int birthNumber, int? controlNumber)
        {
            ValidationResult validationResult;

            if (!controlNumber.HasValue || controlNumber.Value < 0 || controlNumber.Value > 9)
            {
                validationResult = Validator.Validate(year, month, day, birthNumber);

                controlNumber = Math.ControlNumber.Get(year, month, day, birthNumber);
            }
            else
            {
                validationResult = Validator.Validate(year, month, day, birthNumber, controlNumber.Value);
            }

            if (!validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            Year = year;
            Month = month;
            Day = day;
            BirthNumber = birthNumber;
            ControlNumber = controlNumber.Value;
        }

        internal Pin(PinParts pinParts)
            : this(pinParts.Year, pinParts.Month, pinParts.Day, pinParts.BirthNumber, pinParts.ControlNumber)
        {
        }

        public static readonly Pin Empty;

        public int Year { get; }

        public int Month { get; }

        public int Day { get; }

        public int BirthNumber { get; }

        public int ControlNumber { get; }

        public DateTime BirthDate
        {
            get
            {
                if (!_birthDate.HasValue)
                {
                    if (Month > 0 && Day > 0)
                    {
                        try
                        {
                            _birthDate = new DateTime(Year, Month, Day);
                        }
                        catch
                        {
                            throw new Exception(
                                $"An error occured while trying to make a date out of year {Year}, month {Month} and day {Day}");
                        }
                    }
                    else
                    {
                        throw new Exception("Insufficient data");
                    }
                }

                return _birthDate.Value;
            }
        }

        public int Age
        {
            get
            {
                if (!_age.HasValue)
                {
                    _age = Math.Age.Get(BirthDate);
                }

                return _age.Value;
            }
        }

        public Sex Sex
        {
            get
            {
                if (_sex == Sex.Unspecified)
                {
                    _sex = Math.Sex.GetGenderFromBirthNumber(BirthNumber);
                }

                return _sex;
            }
        }

        public County County
        {
            get
            {
                if (County.IsNullOrEmpty(_county))
                {
                    if (Year < 1990)
                    {
                        _county = new CountiesRepository().Get(BirthNumber);
                    }

                    _county = County.Empty;
                }

                return _county;
            }
        }

        public static bool TryParse(string value, out Pin pin)
        {
            pin = null;

            try
            {
                var pinParts = Parser.Parse(value);

                pin = new Pin(pinParts.Year, pinParts.Month, pinParts.Day, pinParts.BirthNumber, pinParts.ControlNumber);

                return true;
            }
            catch (Exception)
            {
                pin = null;
            }

            return false;
        }

        public static ValidationResult Validate(string pinValue)
        {
            return Validator.Validate(pinValue);
        }

        public static GenerationConfig Generation()
        {
            return new Generator().Setup();
        }

        public static bool IsNullOrEmpty(Pin pin)
        {
            return pin == null || pin == Empty;
        }

        public int CompareTo(DateTime other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Pin other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Year}{Month:D2}{Day:D2}{SeparatorCharacter}{BirthNumber:D3}{ControlNumber}";
        }

        internal string SeparatorCharacter
        {
            get
            {
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (Age < 100)
                {
                    return "-";
                }

                return "+";
            }
        }
    }
}
