using Microsoft.EntityFrameworkCore.Migrations;

namespace Kassablad.api.Migrations
{
    public partial class capitaliseConceptField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "concept",
                table: "KassaContainer",
                newName: "Concept");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Concept",
                table: "KassaContainer",
                newName: "concept");
        }
    }
}
