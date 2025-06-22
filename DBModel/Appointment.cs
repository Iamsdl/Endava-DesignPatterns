using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid CabinId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class AppointmentDTO : Appointment, ICloneable
    {
        public Guid TimezoneOwnerId { get; set; }

        public object Clone()
        {
            return new AppointmentDTO
            {
                Id = this.Id,
                PatientId = this.PatientId,
                DoctorId = this.DoctorId,
                CabinId = this.CabinId,
                StartTime = this.StartTime,
                EndTime = this.EndTime,
                TimezoneOwnerId = this.TimezoneOwnerId
            };
        }
    }
}
