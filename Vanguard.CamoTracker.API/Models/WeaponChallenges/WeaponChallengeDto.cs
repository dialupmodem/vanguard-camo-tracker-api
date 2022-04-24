namespace Vanguard.CamoTracker.API.Models.WeaponChallenges
{
    public class WeaponChallengeDto
    {
        public int Id { get; set; }
        public int? WeaponId { get; set; }
        public string? Description { get; set; }
        public string? CamoName { get; set; }
        public int? Requirement { get; set; }
        public int? Progress { get; set; }
        public decimal? PercentCompleted { get; set; }
    }
}
