using DBModel;
using Prototype;

//get cabin appointments from DB
CabinService cabinService = new CabinService();
var appointments = cabinService.GetAppointmentsForCabin([new Guid(DbContext.cabin1Id), new Guid(DbContext.cabin2Id)],
                                                        startDate: new DateTime(2025, 06, 25),
                                                        endDate: new DateTime(2025, 06, 26));


Console.WriteLine($"Appointments as they are in the DB.");
foreach (var appointment in appointments)
{
    Console.WriteLine($"{appointment.StartTime} - {appointment.EndTime}");
}

//clone them for doctors
List<AppointmentDTO> docAppointments = appointments.Select(x =>
{
    //var appointmentDTO = new AppointmentDTO()
    //{
    //    Id = x.Id,
    //    PatientId = x.PatientId,
    //    DoctorId = x.DoctorId,
    //    CabinId = x.CabinId,
    //    StartTime = x.StartTime,
    //    EndTime = x.EndTime,
    //    TimezoneOwnerId = x.TimezoneOwnerId
    //};
    var appointmentDTO = (AppointmentDTO)x.Clone();
    appointmentDTO.TimezoneOwnerId = appointmentDTO.DoctorId;
    return appointmentDTO;
}).ToList();

appointments.AddRange(docAppointments);

Console.WriteLine($"Appointments after they are cloned.");
foreach (var appointment in appointments)
{
    Console.WriteLine($"{appointment.StartTime} - {appointment.EndTime}");
}

//adjust the StartDates based on the owner before returning to UI.
TimezoneMiddleware.Convert(appointments);

Console.WriteLine($"Appointments after they are adjusted by the custom middleware.");
foreach (var appointment in appointments)
{
    string owner = appointment.TimezoneOwnerId == appointment.CabinId ? "cabin" : "doctor";
    TimeSpan offset = appointment.TimezoneOwnerId == appointment.CabinId
        ? DbContext.Cabins.FirstOrDefault(c => c.Id == appointment.TimezoneOwnerId)?.Timezone?.Offset ?? TimeSpan.Zero
        : DbContext.Doctors.FirstOrDefault(d => d.Id == appointment.TimezoneOwnerId)?.Timezone?.Offset ?? TimeSpan.Zero;
    Console.WriteLine($"Owned by {owner} in {offset}: {appointment.StartTime} - {appointment.EndTime}");
}