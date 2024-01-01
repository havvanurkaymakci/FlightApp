using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApp.Data.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Payment");

            migrationBuilder.AddColumn<double>(
                name: "FlightPrice",
                table: "Payment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightPrice",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
