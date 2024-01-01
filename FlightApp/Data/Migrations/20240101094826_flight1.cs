using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApp.Data.Migrations
{
    public partial class flight1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDeparture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDestination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightDestinationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
