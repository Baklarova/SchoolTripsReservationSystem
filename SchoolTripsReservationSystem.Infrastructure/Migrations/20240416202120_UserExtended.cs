using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c40cc6c-15b7-4b2f-b1de-160688114e35", "", "", "AQAAAAEAACcQAAAAEG0i+xaKKa3yqoZFikyQBGfwM8howRm9Hrwuu47ZfKRFMhJtnmV3j2/SmmjeX4m25g==", "fb096b45-8c1d-4958-b2ea-480f82759703" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58bcd6e0-cebb-48d9-8192-f50f3eabc1c9", "", "", "AQAAAAEAACcQAAAAEKlNUYnu4EvDA9ZlYDAeA3PpaHUNYzDmxCwmsqF9bqXbmx9bkr91q7EUoi1kwQVroA==", "dccbc30b-37a4-4892-b8be-23d3e343257c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0861b64c-247a-4b5b-ba89-a681b188e9a5", "AQAAAAEAACcQAAAAEFOI8+F+ZPOIxBY5jEWmqTLw9ZwZuBEs+kn7nZILkOSOLH+o4RxTPTexaUxqJ0u88Q==", "899fcd51-8df3-454e-b14c-360591b2665a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "316aa93e-acdf-4b26-a08f-8956c4c27182", "AQAAAAEAACcQAAAAEBSAcWKRtIGD5I7T3u6phN0Ta11N28K1lQ/cPuDti8b4xcAwQCmp2DoOvauYkYxBHw==", "15de9f6b-cd9e-4870-ab7d-8b61f2b6aace" });
        }
    }
}
