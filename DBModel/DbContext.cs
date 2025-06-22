using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel
{
    public class DbContext
    {
        public const string patient1Id = "67f5d899-4af6-42d7-b8bb-06d5082fc25a";
        public const string patient2Id = "97ac2614-584a-4639-96a6-2e0e451c742c";
        public const string doctor1Id = "6a886430-5dcf-422d-b3e8-b5a45f785627";
        public const string doctor2Id = "9aa7f041-62dd-46fd-b540-237732fc23c5";
        public const string cabin1Id = "36cc6db6-9590-4756-8087-ddeea288cba0";
        public const string cabin2Id = "b8422506-d2eb-42c4-aae2-ea407cb5684c";

        public static List<Patient> Patients { get; set; } =
        [
            new Patient()
            {
                Id = new Guid(patient1Id),
                Timezone = new Timezone()
                {
                    Name = "Romania",
                    Offset = TimeSpan.FromHours(2),
                },
            },
            new Patient()
            {
                Id = new Guid(patient2Id),
                Timezone = new Timezone()
                {
                    Name = "France",
                    Offset = TimeSpan.FromHours(1),
                }

            }
        ];
        public static List<Doctor> Doctors { get; set; } =
        [
            new Doctor()
            {
                Id = new Guid(doctor1Id),
                Timezone = new Timezone()
                {
                    Name = "Romania",
                    Offset = TimeSpan.FromHours(2),
                },
            },
            new Doctor()
            {
                Id = new Guid(doctor2Id),
                Timezone = new Timezone()
                {
                    Name = "France",
                    Offset = TimeSpan.FromHours(1),
                }

            }
        ];

        public static List<Cabin> Cabins { get; set; } =
        [
            new Cabin()
            {
                Id = new Guid(cabin1Id),
                Timezone = new Timezone()
                {
                    Name = "France",
                    Offset = TimeSpan.FromHours(1),
                },
            },
            new Cabin()
            {
                Id = new Guid(cabin2Id),
                Timezone = new Timezone()
                {
                    Name = "UK",
                    Offset = TimeSpan.FromHours(0),
                }

            }
        ];

        public static List<Appointment> Appointments { get; set; } =
        [
            new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = new Guid(patient1Id),
                DoctorId = new Guid(doctor1Id),
                CabinId = new Guid(cabin1Id),
                StartTime = new DateTime(2025,06,25,10,0,0,DateTimeKind.Utc),
                EndTime = new DateTime(2025,06,25,10,30,0,DateTimeKind.Utc)
            },
            new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = new Guid(patient2Id),
                DoctorId = new Guid(doctor2Id),
                CabinId = new Guid(cabin2Id),
                StartTime = new DateTime(2025,06,25,11,0,0,DateTimeKind.Utc),
                EndTime = new DateTime(2025,06,25,11,30,0,DateTimeKind.Utc)
            }
        ];
    }
}
