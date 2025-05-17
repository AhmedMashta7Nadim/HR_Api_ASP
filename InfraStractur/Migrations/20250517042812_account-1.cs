using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class account1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "Id", "EmployeeId", "IsActive", "Password", "Role", "UserName" },
                values: new object[] { new Guid("d3d4359a-0036-483b-bf10-59d1a0833871"), new Guid("d3d4359a-0036-483b-bf10-59d1a0833870"), true, "xxx", 0, "xxx" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "Id",
                keyValue: new Guid("d3d4359a-0036-483b-bf10-59d1a0833871"));
        }
    }
}
