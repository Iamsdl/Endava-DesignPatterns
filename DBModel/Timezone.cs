namespace DBModel
{
    public class Timezone
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Offset { get; set; }
    }
}