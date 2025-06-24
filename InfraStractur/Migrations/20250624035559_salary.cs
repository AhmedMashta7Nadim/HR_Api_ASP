using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraStractur.Migrations
{
    /// <inheritdoc />
    public partial class salary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReceiveSalary",
                table: "salarys",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReceiveSalary",
                table: "salarys");
        }
    }
}
