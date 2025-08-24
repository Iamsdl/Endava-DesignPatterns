using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class ScheduleTemplate
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Active { get; set; }

        public virtual List<ScheduleTemplateEvent> ScheduleTemplateEvents { get; set; }
    }
}
