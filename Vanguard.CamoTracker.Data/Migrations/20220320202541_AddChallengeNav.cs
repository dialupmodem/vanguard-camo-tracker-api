using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.CamoTracker.Data.Migrations
{
    public partial class AddChallengeNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeaponChallengeProgress_WeaponChallengeId",
                table: "WeaponChallengeProgress");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponChallengeProgress_WeaponChallengeId",
                table: "WeaponChallengeProgress",
                column: "WeaponChallengeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeaponChallengeProgress_WeaponChallengeId",
                table: "WeaponChallengeProgress");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponChallengeProgress_WeaponChallengeId",
                table: "WeaponChallengeProgress",
                column: "WeaponChallengeId");
        }
    }
}
