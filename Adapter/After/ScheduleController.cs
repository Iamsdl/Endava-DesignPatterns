using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdParty;

namespace After
{
    public class ScheduleController
    {
        Adapter adapter = new Adapter();
        public async Task CreateScheduleTemplateAsync(ScheduleTemplate scheduleTemplate)
        {
            //validate for format, logic, and conflicts

            //send events to third party system
            bool ok = await adapter.CreateScheduleTemplateAsync(scheduleTemplate);

            //if ok, save to our database
            if (!ok)
            {
                //throw new Exception("Failed to create schedule template in third party system.");
                Console.WriteLine("Failed to create schedule template in third party system.");
            }

            DbContext.ScheduleTemplates.Add(scheduleTemplate);
            await DbContext.SaveChangesAsync();
        }
    }

    
}
