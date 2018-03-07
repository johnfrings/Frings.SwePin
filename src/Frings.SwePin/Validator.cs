using System;
using System.Text.RegularExpressions;

using Frings.SwePin.Data;
using Frings.SwePin.Exceptions;
using Frings.SwePin.Models;

namespace Frings.SwePin
{
    internal static class Validator
    {
        public static ValidationResult Validate(int year, int month, int day, int birthNumber, int controlNumber)
        {
            var result = Validate(year, month, day, birthNumber);

            if (result.HasFlag(ValidationResult.Valid))
            {
                var validControlNumber = Math.ControlNumber.Get(year, month, day, birthNumber);

                if (controlNumber != validControlNumber)
                {
                    result = ValidationResult.InvalidControlNumber;
                }
            }

            return result;
        }

        public static ValidationResult Validate(int year, int month, int day, int birthNumber)
        {
            return Validate(year, month, day) | ValidateBirthNumber(birthNumber);
        }

        public static ValidationResult Validate(string pinValue)
        {
            var result = ValidationResult.Valid;

            try
            {
                var pinParts = Parser.Parse(pinValue);

                result = Validate(pinParts);
            }
            catch (ValidationException validationException)
            {
                result = validationException.Error;
            }

            return result;
        }

        public static ValidationResult Validate(PinParts pinParts)
        {
            var result = ValidationResult.Valid;

            if (pinParts.ControlNumber.HasValue)
            {
                if (Validate(pinParts.Year, pinParts.Month, pinParts.Day, pinParts.BirthNumber, pinParts.ControlNumber.Value) is var validationResult &&
                    !validationResult.HasFlag(ValidationResult.Valid))
                {
                    result = validationResult;
                }
            }
            else if (Validate(pinParts.Year, pinParts.Month, pinParts.Day, pinParts.BirthNumber) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                result = validationResult;
            }

            return result;
        }

        public static ValidationResult Validate(int year, int month, int day)
        {
            var result = ValidateYear(year) | ValidateMonth(month) | ValidateDay(day);

            if (result == ValidationResult.Valid)
            {
                try
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new DateTime(year, month, day);
                }
                catch (ArgumentOutOfRangeException)
                {
                    result = ValidationResult.InvalidDate;
                }
                catch (Exception)
                {
                    result = ValidationResult.InvalidDate;
                }
            }

            return result;
        }

        public static ValidationResult ValidateYear(int year)
        {
            var result = ValidationResult.Valid;

            if (year < 0 || year > 9999)
            {
                result = ValidationResult.UnsupportedYear;
            }

            return result;
        }

        public static ValidationResult ValidateMonth(int month)
        {
            var result = ValidationResult.Valid;

            if (month < 1 || month > 12)
            {
                result = ValidationResult.InvalidMonthNumber;
            }

            return result;
        }

        public static ValidationResult ValidateDay(int day)
        {
            var result = ValidationResult.Valid;

            if (day < 1 || day > 31)
            {
                result = ValidationResult.InvalidDayNumber;
            }

            return result;
        }

        public static ValidationResult ValidateBirthNumber(int birthNumber)
        {
            var result = ValidationResult.Valid;

            if (birthNumber < 0 || birthNumber > 999)
            {
                result = ValidationResult.InvalidBirthNumber;
            }

            return result;
        }

        public static ValidationResult ValidateInput(string pinValue)
        {
            var result = ValidationResult.Valid;

            // For a clean input string, the length has to be between 10 and 13
            //
            // Accepted formats are:
            //      YYYYMMDD-XXXC
            //      YYYYMMDDXXXC
            //      YYMMDD-XXXC
            //      YYMMDD+XXXC
            //      YYMMDDXXXC
            // (Y = year, M = month, D = day, X = birth number, C = control number)
            //
            // The separator between birth date (YYMMDD) and the birth number (XXX)
            // is "+" if the birth date was more than 100 years ago, otherwise "-"
            if (!Regex.IsMatch(pinValue, @"\d{6,8}[-+]?\d{4}"))
            {
                result = ValidationResult.InvalidInputFormat;
            }

            return result;
        }
    }
}
