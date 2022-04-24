using System.ComponentModel.DataAnnotations;

namespace Vanguard.CamoTracker.API.Models.WeaponChallenges
{
    public class UpdateChallengeProgressModel
    {
        [Required]
        public int? Progress { get; set; }
    }
}
