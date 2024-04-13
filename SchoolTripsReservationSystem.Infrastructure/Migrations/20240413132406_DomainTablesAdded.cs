using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolTripsReservationSystem.Infrastructure.Migrations
{
    public partial class DomainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Region identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                },
                comment: "Geographic region");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "School identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "School official name"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "School address"),
                    Eik = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "School identification number"),
                    Mol = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "School director name/MOL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                },
                comment: "School data");

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Transport identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Transport name"),
                    TransportCapacity = table.Column<int>(type: "int", nullable: false, comment: "Мaximum number of seats in the vehicle")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                },
                comment: "Transport for excursion");

            migrationBuilder.CreateTable(
                name: "Excursions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Excursion identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Excursion name"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Excursion Description"),
                    PricePerStudent = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Excursion price per student"),
                    PricePerAdult = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Excursion price per adult-escort"),
                    RegionId = table.Column<int>(type: "int", nullable: false, comment: "Region identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Excursions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "School excursion");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Reservation identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcursionId = table.Column<int>(type: "int", nullable: false, comment: "Excursion identifier"),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of departure"),
                    StudentCount = table.Column<int>(type: "int", nullable: false, comment: "Count of the students"),
                    EscortAdultCount = table.Column<int>(type: "int", nullable: false, comment: "Count of the adults"),
                    TransportId = table.Column<int>(type: "int", nullable: false, comment: "Transport identifier"),
                    SchoolId = table.Column<int>(type: "int", nullable: false, comment: "School identifier"),
                    GroupLeaderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User ID of the group leader - teacher"),
                    TeacherCount = table.Column<int>(type: "int", nullable: false, comment: "Count of the teachers, without group leader")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_GroupLeaderId",
                        column: x => x.GroupLeaderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Excursions_ExcursionId",
                        column: x => x.ExcursionId,
                        principalTable: "Excursions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Reservation for school trip");

            migrationBuilder.CreateIndex(
                name: "IX_Excursions_RegionId",
                table: "Excursions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExcursionId",
                table: "Reservations",
                column: "ExcursionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GroupLeaderId",
                table: "Reservations",
                column: "GroupLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SchoolId",
                table: "Reservations",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TransportId",
                table: "Reservations",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Eik",
                table: "Schools",
                column: "Eik",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Excursions");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
