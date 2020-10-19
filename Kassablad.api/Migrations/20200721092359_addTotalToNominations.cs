using Microsoft.EntityFrameworkCore.Migrations;

namespace Kassablad.api.Migrations
{
    public partial class addTotalToNominations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Total",
                table: "Nominations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Nominations");
        }
    }
}
