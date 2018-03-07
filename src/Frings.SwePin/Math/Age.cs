using System;

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
            var random = new Random();

            return DateTime.Now.AddYears(age * -1)
                .AddMonths(random.Next(0, 11) * -1)
                .AddDays(random.Next(0, 27) * -1);
        }
    }
}
