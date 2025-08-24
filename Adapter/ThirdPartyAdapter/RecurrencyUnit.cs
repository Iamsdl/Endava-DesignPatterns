namespace ThirdPartyAdapter
{
    public enum RecurrencyUnit
    {
        Minutes,
        Hours,
        Days,
        Weeks,
        Months,
        Years
    }

    public static class RecurrencyUnitExtensions
    {
        public static string EnumToString(this RecurrencyUnit unit)
        {
            return unit switch
            {
                RecurrencyUnit.Minutes => "m",
                RecurrencyUnit.Hours => "h",
                RecurrencyUnit.Days => "d",
                RecurrencyUnit.Weeks => "w",
                RecurrencyUnit.Months => "M",
                RecurrencyUnit.Years => "y",
                _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, null)
            };
        }
    }
}