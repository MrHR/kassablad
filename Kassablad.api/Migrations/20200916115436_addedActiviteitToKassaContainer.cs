using Microsoft.EntityFrameworkCore.Migrations;

namespace Kassablad.api.Migrations
{
    public partial class addedActiviteitToKassaContainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Activiteit",
                table: "KassaContainer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activiteit",
                table: "KassaContainer");
        }
    }
}
