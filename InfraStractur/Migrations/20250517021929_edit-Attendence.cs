using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class editAttendence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "attendences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_attendences_EmployeeId",
                table: "attendences",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendences_employees_EmployeeId",
                table: "attendences",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendences_employees_EmployeeId",
                table: "attendences");

            migrationBuilder.DropIndex(
                name: "IX_attendences_EmployeeId",
                table: "attendences");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "attendences");
        }
    }
}
