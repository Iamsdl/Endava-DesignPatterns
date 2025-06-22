using DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class CabinService
    {
        public List<AppointmentDTO> GetAppointmentsForCabin(List<Guid> cabinIds, DateTime startDate, DateTime endDate)
        {
            var appointments = DbContext.Appointments
                .Where(a => cabinIds.Contains(a.CabinId)
                    && a.StartTime >= startDate
                    && a.EndTime <= endDate)
                .Select(a => new AppointmentDTO()
                {
                    Id = a.Id,
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId,
                    CabinId = a.CabinId,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    TimezoneOwnerId = a.CabinId
                })
               .ToList();

                return appointments;
        }
    }
}
