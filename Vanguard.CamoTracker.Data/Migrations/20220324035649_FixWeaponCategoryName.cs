using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.CamoTracker.Data.Migrations
{
    public partial class FixWeaponCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Weapons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Weapons",
                type: "INTEGER",
                nullable: true);
        }
    }
}
