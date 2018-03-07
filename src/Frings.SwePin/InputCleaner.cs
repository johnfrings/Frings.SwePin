using System.Text.RegularExpressions;

namespace Frings.SwePin
{
    internal static class InputCleaner
    {
        public static string Clean(string pinValue)
        {
            return Regex.Replace(pinValue, @"[^0-9\-\+]", string.Empty);
        }
    }
}
