namespace ThirdParty.Models
{
    internal class Recurrency
    {
        public string Unit { get; private set; }

        public void SetUnit(RecurrencyUnit value)
        {
            Unit = value.EnumToString();
        }

        public int Value { get; set; } // e.g., every 2 weeks
        public DateTime? EndDate { get; set; } // optional end date
        public int? Occurrences { get; set; } // optional number of occurrences
    }
}