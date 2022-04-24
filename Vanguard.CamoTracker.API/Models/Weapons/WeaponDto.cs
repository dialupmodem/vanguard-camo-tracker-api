namespace Vanguard.CamoTracker.API.Models.Weapons
{
    public class WeaponDto
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; } = default;
        public string? Image { get; set; } = default;
        public decimal? PercentCompleted { get; set; } = default;
        public string? CategoryName { get; set; } = default;
    }
}
