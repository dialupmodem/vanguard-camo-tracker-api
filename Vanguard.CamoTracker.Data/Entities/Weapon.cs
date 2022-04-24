namespace Vanguard.CamoTracker.Data.Entities
{
    public class Weapon
    {
        public int Id { get; set; }
        public int? WeaponCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }

        public List<WeaponChallenge>? Challenges { get; set; }
        public WeaponCategory? WeaponCategory { get; set; }
       
    }
}
