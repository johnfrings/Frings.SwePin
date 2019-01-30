#nullable enable

using System;

using Frings.SwePin.Models;

namespace Frings.SwePin.Math
{
    internal static class Age
    {
        internal static int Get(int year, int month, int day)
        {
            var now = DateTime.Now;
            var age = now.Year - year;

            if (now.Month < month || (now.Month == month && now.Day < day))
            {
                --age;
            }

            return age;
        }

        internal static int Get(DateTime birthDate)
        {
            if (birthDate == null)
            {
                throw new ArgumentNullException();
            }

            return Get(birthDate.Year, birthDate.Month, birthDate.Day);
        }

        internal static DateTime GetRandomBirthDate(int age)
        {
            return DateTime.Now.AddYears(age * -1)
                .AddMonths(Static.Random.Next(0, 11) * -1)
                .AddDays(Static.Random.Next(0, 27) * -1);
        }

        internal static Range PossibleBirthYears(int age)
        {
            return PossibleBirthYears(age, DateTime.Now);
        }

        internal static Range PossibleBirthYears(int age, DateTime basedOnDate)
        {
            var latestPossibleYear = basedOnDate.AddYears(-age).Year;

            return new Range(latestPossibleYear - 1, latestPossibleYear);
        }

        internal static Range PossibleBirthMonths(int age, int year)
        {
            return PossibleBirthMonths(age, year, DateTime.Now);
        }

        internal static Range PossibleBirthMonths(int age, int year, DateTime basedOnDate)
        {
            var thisYearShouldBecomeAge = basedOnDate.Year - age;

            var firstPossibleBirthMonth = 1;
            var lastPossibleBirthMonth = 12;

            if (thisYearShouldBecomeAge > age)
            {
                // Not yet had birthday
                firstPossibleBirthMonth = basedOnDate.Month;
            }
            else
            {
                // Already had birthday
                lastPossibleBirthMonth = basedOnDate.Month;
            }

            return new Range(firstPossibleBirthMonth, lastPossibleBirthMonth);
        }

        ////internal static Range PossibleBirthDayOfMonth(int age, int year, int month, DateTime basedOnDate)
        ////{

        ////}
    }
}
