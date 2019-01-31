﻿#nullable enable

using System;
using System.Text.RegularExpressions;

using Frings.SwePin.Data;
using Frings.SwePin.Exceptions;
using Frings.SwePin.Models;

namespace Frings.SwePin
{
    internal static class Parser
    {
        public static PinParts Parse(string pinValue)
        {
            if (string.IsNullOrWhiteSpace(pinValue))
            {
                throw new ValidationException(ValidationResult.InvalidInputFormat);
            }

            var result = new PinParts();

            var cleanPinValue = InputCleaner.Clean(pinValue);

            if (Validator.ValidateInputFormat(cleanPinValue) is var validationResult &&
                !validationResult.HasFlag(ValidationResult.Valid))
            {
                throw new ValidationException(validationResult);
            }

            var matches =
                Regex.Match(
                    cleanPinValue,
                    @"(?<Century>\d\d)?(?<Year>\d\d)(?<Month>(?:0\d|1[012]))(?<Day>(?:[012]\d|3[01]))(?<Separator>[+-])?(?<BirthNumber>\d{3})(?<ControlNumber>\d)");

            if (matches.Success)
            {
                if (matches.Groups["Century"].Success)
                {
                    result.Year = int.Parse(matches.Groups["Century"].Value + matches.Groups["Year"].Value);
                }
                else
                {
                    result.Year = int.Parse(matches.Groups["Year"].Value);
                }

                result.Month = int.Parse(matches.Groups["Month"].Value);
                result.Day = int.Parse(matches.Groups["Day"].Value);

                var isYoungerThan100 = !matches.Groups["Separator"].Success ||
                                       matches.Groups["Separator"].Value.Equals("-");

                result.BirthNumber = int.Parse(matches.Groups["BirthNumber"].Value);
                result.ControlNumber = int.Parse(matches.Groups["ControlNumber"].Value);

                // Was year parsed from a 2 digit year?
                if (result.Year < 100)
                {
                    var utcNow = DateTime.UtcNow;

                    // At first assume the pin represents someone younger than 100...
                    var currentYear = utcNow.Year;

                    if (result.Year > currentYear % 100)
                    {
                        result.Year += currentYear - currentYear % 100 - 100;
                    }
                    else
                    {
                        result.Year += currentYear - currentYear % 100;
                    }

                    // .. but then make an adjustment if the pin is indeed representing a 100+ year old
                    if (!isYoungerThan100)
                    {
                        result.Year -= 100;
                    }
                    else if (result.Year.Equals(utcNow.Year))
                    {
                        // Edge case: if the year was found to be this year, check if the PIN is ahead in time
                        var pinDate = new DateTime(result.Year, result.Month, result.Day);

                        if (pinDate > utcNow)
                        {
                            // Some PIN for a person not born yet should not exist so
                            // we must assume that it is someone about to turn 100 years old
                            result.Year -= 100;
                        }
                    }
                }
            }
            else
            {
                throw new ValidationException(ValidationResult.InvalidInputFormat);
            }

            return result;
        }
    }
}
