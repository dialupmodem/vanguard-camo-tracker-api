using Microsoft.EntityFrameworkCore;
using Vanguard.CamoTracker.Data.Entities;

namespace Vanguard.CamoTracker.Data
{
    public class CamoTrackerContext : DbContext
    {
        public DbSet<Weapon>? Weapons { get; set; }
        public DbSet<WeaponCategory>? WeaponCategories { get; set; }
        public DbSet<WeaponChallenge>? WeaponChallenges { get; set; }

        public CamoTrackerContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CamoTrackerContext>();
            optionsBuilder.UseSqlite("Data Source=CamoTracker.db");
        }
        public CamoTrackerContext(string databasePath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CamoTrackerContext>();
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
        public CamoTrackerContext(DbContextOptions<CamoTrackerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=CamoTracker.db");
        }
    }
}