using After;
using DBModel;
using System.Text.Json;

var schedule = new ScheduleTemplate
{
    StartTime = new DateTime(2025, 01, 01, 00,00,00),
    EndTime = new DateTime(2025, 04, 01, 00, 00, 00),
    Active = true,
    Id = new Guid("e0691c6f-d723-4f1e-95fe-8d6fc8eb5678"),
    ScheduleTemplateEvents = new List<ScheduleTemplateEvent>()
    {
        new ScheduleTemplateEvent
        {
            Id = Guid.NewGuid(),
            ScheduleTemplateId = new Guid("e0691c6f-d723-4f1e-95fe-8d6fc8eb5678"),
            DayOfWeek = DayOfWeek.Monday,
            StartTime = new TimeSpan(08,00,00),
            EndTime = new TimeSpan(12,00,00)
        },
        new ScheduleTemplateEvent()
        {
            Id = Guid.NewGuid(),
            ScheduleTemplateId = new Guid("e0691c6f-d723-4f1e-95fe-8d6fc8eb5678"),
            Day = new DateTime(2025, 01, 15),
            StartTime = new TimeSpan(13,00,00),
            EndTime = new TimeSpan(17,00,00),
        }
    }
};

var scheduleController = new ScheduleController();

Console.WriteLine("Mock http request body:");
Console.WriteLine(JsonSerializer.Serialize(schedule));
Console.WriteLine();

//httprequest hits our controller
await scheduleController.CreateScheduleTemplateAsync(schedule);