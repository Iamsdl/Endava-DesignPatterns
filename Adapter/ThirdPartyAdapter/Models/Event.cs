namespace ThirdParty.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Recurrency? Recurrency { get; set; }
    }
}