using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskBookingAPI.Data.Migrations
{
    public partial class AddedEmployeeBookingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Employees_EmployeeId",
                table: "Desks");

            migrationBuilder.DropIndex(
                name: "IX_Desks_EmployeeId",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Desks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Desks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desks_EmployeeId",
                table: "Desks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Employees_EmployeeId",
                table: "Desks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
