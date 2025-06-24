using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class TimezoneMiddleware
    {
        public static void Convert(List<AppointmentDTO> appointments)
        {
            foreach (var appointment in appointments)
            {
                TimeSpan? offset = TimeSpan.Zero;
                if (appointment.TimezoneOwnerId != Guid.Empty)
                {
                    Cabin? cabin = DbContext.Cabins.FirstOrDefault(c => c.Id == appointment.TimezoneOwnerId);
                    Doctor? doctor = DbContext.Doctors.FirstOrDefault(d => d.Id == appointment.TimezoneOwnerId);

                    offset = cabin?.Timezone?.Offset ?? doctor?.Timezone?.Offset;

                    if (offset != null)
                    {
                        appointment.StartTime = appointment.StartTime.Add(offset.Value);
                        appointment.EndTime = appointment.EndTime.Add(offset.Value);
                    }
                }
            }
        }
    }
}
