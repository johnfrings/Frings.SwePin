using System;
using System.Linq;
using System.Text;

namespace Frings.SePin.Math
{
    internal static class ControlNumber
    {
        internal static int Get(int year, int month, int day, int birthNumber)
        {
            /*  Example calculation:
                 *
                 *  Step 1:
                 *  8  1 1 2 1 8  9 8  7  <-- birthdate and birth number yyMMddbbb
                 *  2  1 2 1 2 1  2 1  2  <-- multiplier
                 *  ---------------------
                 *  ^  ^ ^ ^ ^ ^  ^ ^  ^
                 *  16  1 2 2 2 8 18 8 14 <-- multiplication result
                 *
                 *  Step 2:
                 *  1+6+1+2+2+2+8+1+8+8+1+4 = 44
                 *
                 *  Step 3:
                 *  10 - (44 % 10) = 6
                 */

            var firstPart = $"{year % 100:D2}{month:D2}{day:D2}{birthNumber:D3}";
            var numbers = new int[9];

            for (var i = 0; i < 9; ++i)
            {
                numbers[i] = int.Parse(firstPart[i].ToString());
            }

            numbers[0] *= 2;
            numbers[2] *= 2;
            numbers[4] *= 2;
            numbers[6] *= 2;
            numbers[8] *= 2;

            var sb = new StringBuilder();

            foreach (var t in numbers)
            {
                sb.Append(t);
            }

            var altered = sb.ToString();
            var sum = altered.ToCharArray().Sum(t => int.Parse(t.ToString()));

            var modded = sum % 10;

            return modded == 10 || modded == 0 ? 0 : 10 - modded;
        }

        internal static int Get(DateTime birthDate, int birthNumber)
        {
            return Get(birthDate.Year, birthDate.Month, birthDate.Day, birthNumber);
        }
    }
}
