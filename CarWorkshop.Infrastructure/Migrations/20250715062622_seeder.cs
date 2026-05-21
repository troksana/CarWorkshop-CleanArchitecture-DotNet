using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarWorkshop",
                table: "CarWorkshop");

            migrationBuilder.RenameTable(
                name: "CarWorkshop",
                newName: "CarWorkshops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarWorkshops",
                table: "CarWorkshops",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarWorkshops",
                table: "CarWorkshops");

            migrationBuilder.RenameTable(
                name: "CarWorkshops",
                newName: "CarWorkshop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarWorkshop",
                table: "CarWorkshop",
                column: "Id");
        }
    }
}
