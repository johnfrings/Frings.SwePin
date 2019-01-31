#nullable enable

using System;

using Frings.SwePin.Models;

namespace Frings.SwePin.Math
{
    internal static class Sex
    {
        public static Data.Sex GetGenderFromBirthNumber(BirthNumber birthNumber)
        {
            var result = Data.Sex.Unspecified;

            if (birthNumber >= 0 && birthNumber <= 999)
            {
                result = birthNumber % 2 == 0 ? Data.Sex.Female : Data.Sex.Male;
            }

            return result;
        }

        public static Data.Sex GetGenderFromBirthNumber(int birthNumber)
        {
            var result = Data.Sex.Unspecified;

            if (birthNumber >= 0 && birthNumber <= 999)
            {
                result = birthNumber % 2 == 0 ? Data.Sex.Female : Data.Sex.Male;
            }

            return result;
        }

        public static Data.Sex GetRandom()
        {
            var random = new Random();

            return random.Next(1, 100) >= 50 ? Data.Sex.Female : Data.Sex.Male;
        }

        public static int GetRandomBirthNumber(Data.Sex sex = Data.Sex.Unspecified)
        {
            int birthNumber;

            if (sex == Data.Sex.Unspecified)
            {
                sex = Static.Random.Next(1, 100) % 2 == 0 ? Data.Sex.Male : Data.Sex.Female;
            }

            if (sex.Equals(Data.Sex.Female))
            {
                birthNumber = Static.Random.Next(1, 499) * 2;
            }
            else
            {
                birthNumber = Static.Random.Next(0, 499) * 2 + 1;
            }

            return birthNumber;
        }
    }
}
