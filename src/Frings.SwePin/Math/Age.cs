﻿using System;
using System.Collections.Generic;

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

        internal static int[] PossibleBirthYears(int age)
        {
            var latestPossibleYearDate = DateTime.Now.AddYears(-age);
            var earliestPossibleYearDate = latestPossibleYearDate.AddDays(-364); //// TODO: account for leap year

            return new int[2] { earliestPossibleYearDate.Year, earliestPossibleYearDate.Year };
        }
    }
}
