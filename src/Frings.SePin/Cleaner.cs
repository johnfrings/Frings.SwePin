using System.Text.RegularExpressions;

namespace Frings.SePin
{
    internal class Cleaner
    {
        public static string Clean(string pinValue)
        {
            return Regex.Replace(pinValue, @"[^0-9\-\+]", string.Empty);
        }
    }
}
