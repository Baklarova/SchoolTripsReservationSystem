using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is reservation approved by administrator");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c8a9efe-b1d4-4754-be71-5c899abeda77", "Ivan", "Ivanov", "TEACHER@MAIL.COM", "TEACHER@MAIL.COM", "AQAAAAEAACcQAAAAEBHJ7qrjrSY31BOmvDz784a/pdE7JBwq+8MfJ8QOCYN+jnp+KQDMEazRkq7banTyGQ==", "a71ed6bc-7afc-4da3-963e-d095b3ef15f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d48965f-80f2-40a0-ae02-686ad3c5c83a", "Admin", "Admin", "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEORhfogTDDn6m8jniiELfEXjUgsGi+ix/HZIjZ+YDYspnrD7UrJflvQICjUBJGbioQ==", "d628c301-08a0-499d-a215-71c4eaa7b8eb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c40cc6c-15b7-4b2f-b1de-160688114e35", "", "", "teacher@mail.com", "teacher@mail.com", "AQAAAAEAACcQAAAAEG0i+xaKKa3yqoZFikyQBGfwM8howRm9Hrwuu47ZfKRFMhJtnmV3j2/SmmjeX4m25g==", "fb096b45-8c1d-4958-b2ea-480f82759703" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58bcd6e0-cebb-48d9-8192-f50f3eabc1c9", "", "", "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEKlNUYnu4EvDA9ZlYDAeA3PpaHUNYzDmxCwmsqF9bqXbmx9bkr91q7EUoi1kwQVroA==", "dccbc30b-37a4-4892-b8be-23d3e343257c" });
        }
    }
}
