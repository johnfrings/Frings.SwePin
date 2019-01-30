#nullable enable

using System;
using System.Collections.Generic;

using Frings.SwePin.Data;
using Frings.SwePin.Exceptions;
using Frings.SwePin.Math;
using Frings.SwePin.Models;

namespace Frings.SwePin.Generation
{
    public static class GenerationConfigExtensions
    {
        public static GenerationConfig WithAge(this GenerationConfig config, int age)
        {
            config.Age = age;

            return config;
        }

        public static GenerationConfig WithSex(this GenerationConfig config, Data.Sex sex)
        {
            config.Sex = sex;

            return config;
        }

        public static GenerationConfig BornYear(this GenerationConfig config, int year)
        {
            if (Validator.ValidateYear(year) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            config.Year = year;

            return config;
        }

        public static GenerationConfig BornMonth(this GenerationConfig config, int month)
        {
            if (Validator.ValidateMonth(month) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            config.Month = month;

            return config;
        }

        public static GenerationConfig BornDay(this GenerationConfig config, int day)
        {
            if (Validator.ValidateDay(day) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            config.Day = day;

            return config;
        }

        public static IEnumerable<Pin> GenerateMany(this GenerationConfig config, int count)
        {
            for (var i = 0; i < count; ++i)
            {
                yield return Generate(config);
            }
        }

        public static Pin Generate(this GenerationConfig config)
        {
            var pinParts = new PinParts();

            if (config.Age.HasValue)
            {
                var randomBirthDate = Age.GetRandomBirthDate(config.Age.Value);

                //// TODO: if year, month, day has been set in combination with age, try to keep as many of those settings as possible.
                //// TODO: if age in combination with year, month day are set and those things don't work out together we should probably throw an exception

                pinParts.Year = randomBirthDate.Year;
                pinParts.Month = randomBirthDate.Month;
                pinParts.Day = randomBirthDate.Day;
            }
            else
            {
                // When Age is not specified
                if (config.Year.HasValue)
                {
                    pinParts.Year = config.Year.Value;
                }
                else
                {
                    pinParts.Year = Static.Random.Next(DateTime.Now.AddYears(-110).Year, DateTime.Now.Year);
                }

                if (config.Month.HasValue)
                {
                    pinParts.Month = config.Month.Value;
                }
                else
                {
                    pinParts.Month = Static.Random.Next(1, 12);
                }

                var validDays = DateTime.DaysInMonth(pinParts.Year, pinParts.Month);

                if (config.Day.HasValue &&
                    config.Day.Value <= validDays)
                {
                    pinParts.Day = config.Day.Value;
                }
                else
                {
                    //// TODO: If a day is specifically specified and is generally valid but NOT valid for the year&month, should we 1) throw 2) adjust the day 3) adjust the month
                    pinParts.Day = Static.Random.Next(1, validDays);
                }
            }

            pinParts.BirthNumber = Math.Sex.GetRandomBirthNumber(config.Sex);

            return new Pin(pinParts);
        }
    }
}