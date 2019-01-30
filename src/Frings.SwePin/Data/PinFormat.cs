#nullable enable

namespace Frings.SwePin.Data
{
    public enum PinFormat
    {
        Default, // yyyymmddbbbc
        ShortAndLossy, // yymmddbbbc
        Short, // yymmddsbbbc
        Long, // yyyymmddsbbbc
        ShortLossyBirthDate, // yymmdd
        BirthDate, // yyyymmdd
        ShortLossyBirthDateSeparated, // yy-mm-dd
        BirthDateSeparated, // yyyy-mm-dd
    }
}
