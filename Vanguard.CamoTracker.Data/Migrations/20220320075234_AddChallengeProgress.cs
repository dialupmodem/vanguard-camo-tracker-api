using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vanguard.CamoTracker.Data.Migrations
{
    public partial class AddChallengeProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeaponChallengeProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeaponChallengeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Progress = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponChallengeProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponChallengeProgress_WeaponChallenges_WeaponChallengeId",
                        column: x => x.WeaponChallengeId,
                        principalTable: "WeaponChallenges",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponChallengeProgress_WeaponChallengeId",
                table: "WeaponChallengeProgress",
                column: "WeaponChallengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeaponChallengeProgress");
        }
    }
}
