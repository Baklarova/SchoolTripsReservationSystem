using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    public partial class ExursionDurationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mol",
                table: "Schools",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "School director name/MOL",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "School director name/MOL");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Excursions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Excursion duration in days");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Excursions");

            migrationBuilder.AlterColumn<string>(
                name: "Mol",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                comment: "School director name/MOL",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "School director name/MOL");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204bc6fa-b97e-4cbc-be06-9acfd2fab7ac", "AQAAAAEAACcQAAAAEIDLjTFfriPPNqZm3l8XN4lq+seePQlSMNXwgKBMAFvu+5IN6pLCXA9lDOf8QpYxaQ==", "47440ed0-8a68-496f-a5b2-3a44648401df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8e78f12-7602-407c-ac47-0cf4b77bcd0a", "AQAAAAEAACcQAAAAEOck3vwqHKz0tpC57kYgNwNSxnE0jiH7sxcLqGnjWvbmd+d2L+c+h6LprCHXm8Zfig==", "f0f904e1-eeeb-47ba-9c17-7ad0d4a9c93a" });
        }
    }
}
