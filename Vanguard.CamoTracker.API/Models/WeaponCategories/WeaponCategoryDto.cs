using Vanguard.CamoTracker.API.Models.Weapons;

namespace Vanguard.CamoTracker.API.Models.WeaponCategories
{
    public class WeaponCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = default;
        public IEnumerable<SimpleWeaponDto>? Weapons { get; set; } = default;
    }
}
