#nullable enable

using System.Text.RegularExpressions;

namespace Frings.SwePin
{
    internal static class InputCleaner
    {
        public static string Clean(string pinValue)
        {
            if (string.IsNullOrWhiteSpace(pinValue))
            {
                return string.Empty;
            }

            return Regex.Replace(pinValue, @"[^0-9\-\+]", string.Empty);
        }
    }
}
