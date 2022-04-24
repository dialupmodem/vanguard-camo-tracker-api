namespace Vanguard.CamoTracker.Data.Entities
{
    public class WeaponCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Weapon>? Weapons { get; set; }
    }
}
