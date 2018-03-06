using System;
using System.Collections.Generic;
using System.Text;

namespace Frings.SePin.Math
{
    internal static class Sex
    {
        internal static Data.Sex GetGenderFromBirthNumber(int birthNumber)
        {
            var result = Data.Sex.Unspecified;

            if (birthNumber >= 0 && birthNumber <= 999)
            {
                result = birthNumber % 2 == 0 ? Data.Sex.Female : Data.Sex.Male;
            }

            return result;
        }

        internal static Data.Sex GetRandom()
        {
            var random = new Random();

            return random.Next(1, 100) >= 50 ? Data.Sex.Female : Data.Sex.Male;
        }

        internal static int GetRandomBirthNumber(Data.Sex sex)
        {
            var random = new Random();
            int birthNumber;

            if (sex.Equals(Data.Sex.Female))
            {
                birthNumber = random.Next(1, 499) * 2;
            }
            else
            {
                birthNumber = (random.Next(0, 499) * 2) + 1;
            }

            return birthNumber;
        }
    }
}
