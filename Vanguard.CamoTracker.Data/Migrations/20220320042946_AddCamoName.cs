using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.CamoTracker.Data.Migrations
{
    public partial class AddCamoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CamoName",
                table: "WeaponChallenges",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CamoName",
                table: "WeaponChallenges");
        }
    }
}
