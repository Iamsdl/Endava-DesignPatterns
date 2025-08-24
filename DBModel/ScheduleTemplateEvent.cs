using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ScheduleTemplateEvent
    {
        public Guid Id { get; set; }
        public Guid ScheduleTemplateId { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public DateTime? Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


        public virtual ScheduleTemplate ScheduleTemplate { get; set; }
    }
}
