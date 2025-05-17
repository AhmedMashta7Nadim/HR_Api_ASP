using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class x1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "departments",
                columns: new[] { "Id", "DepartmentName", "IsActive", "Type_Departmint" },
                values: new object[] { new Guid("d3d4359a-0036-483b-bf10-59d1a0833872"), "x", true, 0 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AccountId", "AddedEmployee", "DepartmentId", "FirstName", "IsActive", "LastName", "MiddleName", "Position" },
                values: new object[] { new Guid("d3d4359a-0036-483b-bf10-59d1a0833870"), new Guid("d3d4359a-0036-483b-bf10-59d1a0833871"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d3d4359a-0036-483b-bf10-59d1a0833872"), "محمد", true, "الزهير", "علي", "مدير موارد بشرية" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: new Guid("d3d4359a-0036-483b-bf10-59d1a0833870"));

            migrationBuilder.DeleteData(
                table: "departments",
                keyColumn: "Id",
                keyValue: new Guid("d3d4359a-0036-483b-bf10-59d1a0833872"));
        }
    }
}
