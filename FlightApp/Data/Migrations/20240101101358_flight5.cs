using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApp.Data.Migrations
{
    public partial class flight5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightDepartureTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FlightDestinationTime",
                table: "Flights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "FlightDepartureTime",
                table: "Flights",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FlightDestinationTime",
                table: "Flights",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
