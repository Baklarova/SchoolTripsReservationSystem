using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "204bc6fa-b97e-4cbc-be06-9acfd2fab7ac", "teacher@mail.com", false, false, null, "teacher@mail.com", "teacher@mail.com", "AQAAAAEAACcQAAAAEIDLjTFfriPPNqZm3l8XN4lq+seePQlSMNXwgKBMAFvu+5IN6pLCXA9lDOf8QpYxaQ==", null, false, "47440ed0-8a68-496f-a5b2-3a44648401df", false, "teacher@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "b8e78f12-7602-407c-ac47-0cf4b77bcd0a", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEOck3vwqHKz0tpC57kYgNwNSxnE0jiH7sxcLqGnjWvbmd+d2L+c+h6LprCHXm8Zfig==", null, false, "f0f904e1-eeeb-47ba-9c17-7ad0d4a9c93a", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Northwest" },
                    { 2, "Northeast" },
                    { 3, "Southeast" },
                    { 4, "Southwest" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "Eik", "Mol", "Name" },
                values: new object[,]
                {
                    { 1, "Varna, 32 Kliment Ohridski str.", "000123654", "Ivan Ianov", "St. Kliment Ohridski" },
                    { 2, "Sofia, 78 Vardar str.", "000987456", "Petar Petrov", "St. st. Kiril and Metodi" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "Name", "TransportCapacity" },
                values: new object[,]
                {
                    { 1, "Microbus", 18 },
                    { 2, "Autobus32", 32 },
                    { 3, "Autobus55", 55 }
                });

            migrationBuilder.InsertData(
                table: "Excursions",
                columns: new[] { "Id", "Description", "Name", "PricePerAdult", "PricePerStudent", "RegionId" },
                values: new object[] { 1, "Magurata Cave, Baba Vida Fortress, Ledenika Cave, Historical Museum, Kozloduy", "Northwest Bulgaria", 600.00m, 500.00m, 1 });

            migrationBuilder.InsertData(
                table: "Excursions",
                columns: new[] { "Id", "Description", "Name", "PricePerAdult", "PricePerStudent", "RegionId" },
                values: new object[] { 2, "The Seven Rila Lakes, Rila Monastery, Tsarska Bistrica, Historical Museum", "The Seven Rila Lakes", 400.00m, 300.00m, 4 });

            migrationBuilder.InsertData(
                table: "Excursions",
                columns: new[] { "Id", "Description", "Name", "PricePerAdult", "PricePerStudent", "RegionId" },
                values: new object[] { 3, "Nessebar, Begliktash, ethnographic museum, Bulgarka-nestinari village, Bastet's cave", "Strandzha", 450.00m, 350.00m, 3 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EscortAdultCount", "ExcursionId", "GroupLeaderId", "SchoolId", "StartingDate", "StudentCount", "TeacherCount", "TransportId" },
                values: new object[] { 1, 0, 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 2, new DateTime(2024, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "EscortAdultCount", "ExcursionId", "GroupLeaderId", "SchoolId", "StartingDate", "StudentCount", "TeacherCount", "TransportId" },
                values: new object[] { 2, 2, 3, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, new DateTime(2024, 5, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Excursions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Excursions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Excursions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
