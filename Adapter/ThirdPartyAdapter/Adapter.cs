using DBModel;
using System.Text.Json;
using ThirdParty.Models;

namespace ThirdParty
{
    public class Adapter
    {
        public Adapter()
        {
        }

        public Task<bool> CreateScheduleTemplateAsync(ScheduleTemplate scheduleTemplate)
        {
            List<Event> events = ConvertToThirdPartyEvents(scheduleTemplate);

            Console.WriteLine("Converted events to third party format:");
            Console.WriteLine(JsonSerializer.Serialize(events));

            //HttpRequest to third party system to create events
            Task.Delay(1000).Wait(); // Simulate async work

            return Task.FromResult(true);
        }

        private List<Event> ConvertToThirdPartyEvents(ScheduleTemplate scheduleTemplate)
        {
            if (scheduleTemplate == null || scheduleTemplate.ScheduleTemplateEvents == null)
            {
                return new List<Event>();
            }

            var result = new List<Event>();

            Event @event;
            foreach (var templateEvent in scheduleTemplate.ScheduleTemplateEvents)
            {
                @event = new Event();
                //this is a recurring event
                if (templateEvent.DayOfWeek.HasValue)
                {
                    @event.StartTime = scheduleTemplate.StartTime.Date + templateEvent.StartTime;
                    @event.Duration = scheduleTemplate.StartTime.Date + templateEvent.EndTime - @event.StartTime;

                    @event.Recurrency = new Recurrency
                    {
                        Value = 1,
                        EndDate = scheduleTemplate.EndTime,
                        Occurrences = null
                    };
                    @event.Recurrency.SetUnit(RecurrencyUnit.Weeks);
                }
                //this is a one-time event, and Day is not null
                else
                {
                    ArgumentNullException.ThrowIfNull(templateEvent.Day, nameof(templateEvent.Day));

                    @event.StartTime = templateEvent.Day.Value.Date + templateEvent.StartTime;
                    @event.Duration = templateEvent.Day.Value.Date + templateEvent.EndTime - @event.StartTime;
                    @event.Recurrency = null;
                }

                result.Add(@event);
            }

            return result;
        }
    }
}