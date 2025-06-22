
namespace DBModel
{
    public class Patient
    {
        public Patient()
        {
        }

        public Guid Id { get; set; }

        public Timezone Timezone { get; set; }
    }
}