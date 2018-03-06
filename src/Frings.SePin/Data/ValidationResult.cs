using System;

namespace Frings.SePin.Data
{
    [Flags]
    public enum ValidationResult
    {
        Valid = 0,
        InvalidInputFormat = 1,
        UnsupportedYear = 2,
        InvalidMonthNumber = 4,
        InvalidDayNumber = 8,
        InvalidDate = 16,
        InvalidBirthNumber = 32,
        InvalidControlNumber = 64
    }
}
