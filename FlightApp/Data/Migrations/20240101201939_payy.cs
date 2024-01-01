using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightApp.Data.Migrations
{
    public partial class payy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Passenger_PassengerId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_PassengerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "FlightPrice",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PassengerId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PassengerName",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PassengerSurname",
                table: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FlightPrice",
                table: "Payment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerId",
                table: "Payment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerName",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassengerSurname",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PassengerId",
                table: "Payment",
                column: "PassengerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Passenger_PassengerId",
                table: "Payment",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "PassengerId");
        }
    }
}
