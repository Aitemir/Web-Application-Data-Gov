using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationDataGov.Migrations
{
    public partial class AzureMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_schools",
                table: "schools");

            migrationBuilder.RenameTable(
                name: "schools",
                newName: "Schools");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "schools");

            migrationBuilder.AddPrimaryKey(
                name: "PK_schools",
                table: "schools",
                column: "id");
        }
    }
}
