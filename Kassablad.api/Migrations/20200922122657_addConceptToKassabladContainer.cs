using Microsoft.EntityFrameworkCore.Migrations;

namespace Kassablad.api.Migrations
{
    public partial class addConceptToKassabladContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "concept",
                table: "KassaContainer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "concept",
                table: "KassaContainer");
        }
    }
}
