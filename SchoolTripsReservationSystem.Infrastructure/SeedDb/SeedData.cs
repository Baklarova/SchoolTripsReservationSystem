using Microsoft.AspNetCore.Identity;
using SchoolTripsReservationSystem.Infrastructure.Data.Models;
using System.Globalization;

namespace SchoolTripsReservationSystem.Infrastructure.SeedDb
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; }
        public IdentityUser TeacherUser { get; set; }

        public Region NorthwestRegion { get; set; }
        public Region NortheastRegion { get; set; }
        public Region SoutheastRegion { get; set; }
        public Region SouthwestRegion { get; set; }

        public Transport Microbus { get; set; }
        public Transport Autobus32 { get; set; }
        public Transport Autobus55 { get; set; }

        public School FirstSchool { get; set; }
        public School SecondSchool { get; set; }

        public Excursion FirstExcursion { get; set; }
        public Excursion SecondExcursion { get; set; }
        public Excursion ThirdExcursion { get; set; }

        public Reservation FirstReservation { get; set; }
        public Reservation SecondReservation { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedRegion();
            SeedTransport();
            SeedSchool();
            SeedExcursion();
            SeedReservation();
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"
            };

            AdminUser.PasswordHash =
                 hasher.HashPassword(AdminUser, "admin123");

            TeacherUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "teacher@mail.com",
                NormalizedUserName = "teacher@mail.com",
                Email = "teacher@mail.com",
                NormalizedEmail = "teacher@mail.com"
            };

            TeacherUser.PasswordHash =
            hasher.HashPassword(TeacherUser, "teacher123");
        }

        private void SeedRegion()
        {
            NorthwestRegion = new Region()
            {
                Id = 1,
                Name = "Northwest"
            };

            NortheastRegion = new Region()
            {
                Id = 2,
                Name = "Northeast"
            };

            SoutheastRegion = new Region()
            {
                Id = 3,
                Name = "Southeast"
            };

            SouthwestRegion = new Region()
            {
                Id = 4,
                Name = "Southwest"
            };

        }

        private void SeedTransport()
        {
            Microbus = new Transport()
            {
                Id = 1,
                Name = "Microbus",
                TransportCapacity = 18
            };

            Autobus32 = new Transport()
            {
                Id = 2,
                Name = "Autobus32",
                TransportCapacity = 32
            };

            Autobus55 = new Transport()
            {
                Id = 3,
                Name = "Autobus55",
                TransportCapacity = 55
            };


        }

        private void SeedSchool()
        {
            FirstSchool = new School()
            {
                Id = 1,
                Name = "St. Kliment Ohridski",
                Address = "Varna, 32 Kliment Ohridski str.",
                Eik = "000123654",
                Mol = "Ivan Ianov"
            };

            SecondSchool = new School()
            {
                Id = 2,
                Name = "St. st. Kiril and Metodi",
                Address = "Sofia, 78 Vardar str.",
                Eik = "000987456",
                Mol = "Petar Petrov"
            };

        }

        private void SeedExcursion()
        {
            FirstExcursion = new Excursion()
            {
                Id = 1,
                Name = "Northwest Bulgaria",
                Description = "Magurata Cave, Baba Vida Fortress, Ledenika Cave, Historical Museum, Kozloduy",
                PricePerStudent = 500.00M,
                PricePerAdult = 600.00M,
                RegionId = NorthwestRegion.Id
            };

            SecondExcursion = new Excursion()
            {
                Id = 2,
                Name = "The Seven Rila Lakes",
                Description = "The Seven Rila Lakes, Rila Monastery, Tsarska Bistrica, Historical Museum",
                PricePerStudent = 300.00M,
                PricePerAdult = 400.00M,
                RegionId = SouthwestRegion.Id
            };

            ThirdExcursion = new Excursion()
            {
                Id = 3,
                Name = "Strandzha",
                Description = "Nessebar, Begliktash, ethnographic museum, Bulgarka-nestinari village, Bastet's cave",
                PricePerStudent = 350.00M,
                PricePerAdult = 450.00M,
                RegionId = SoutheastRegion.Id
            };
        }

        private void SeedReservation()
        {
            FirstReservation = new Reservation()
            {
                Id = 1,
                ExcursionId = FirstExcursion.Id,
                StudentCount = 10,
                TransportId = Microbus.Id,
                SchoolId = SecondSchool.Id,
                GroupLeaderId = TeacherUser.Id,
                TeacherCount = 1,
                StartingDate = DateTime.ParseExact("15.06.2024 10:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };

            SecondReservation = new Reservation()
            {
                Id = 2,
                ExcursionId = ThirdExcursion.Id,
                StudentCount = 44,
                EscortAdultCount = 2,
                TransportId = Autobus55.Id,
                SchoolId = FirstSchool.Id,
                GroupLeaderId = TeacherUser.Id,
                TeacherCount = 3,
                StartingDate = DateTime.ParseExact("20.05.2024 10:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture)
            };

        }

    }
}
