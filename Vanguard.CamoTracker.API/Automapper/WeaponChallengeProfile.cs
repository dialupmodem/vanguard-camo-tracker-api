using AutoMapper;
using Vanguard.CamoTracker.API.Models.WeaponChallenges;
using Vanguard.CamoTracker.Data.Entities;

namespace Vanguard.CamoTracker.API.Automapper
{
    public class WeaponChallengeProfile : Profile
    {
        public WeaponChallengeProfile()
        {
            CreateMap<WeaponChallenge, WeaponChallengeDto>()
                .ForMember(dst => dst.WeaponId, opt => opt.MapFrom(src => src.WeaponId))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.CamoName, opt => opt.MapFrom(src => src.CamoName))
                .ForMember(dst => dst.Requirement, opt => opt.MapFrom(src => src.Requirement))
                .ForMember(dst => dst.Progress, opt => {
                    opt.NullSubstitute(0);
                    opt.MapFrom(src => src.Progress);
                })
                .ForMember(dst => dst.PercentCompleted, opt => opt.MapFrom(src => CalculatePercentCompleted(src)))
            ;

        }
        private decimal? CalculatePercentCompleted(WeaponChallenge challenge)
        {
            var requirement = (decimal?)challenge.Requirement;
            var progress = (decimal?)challenge.Progress ?? 0;

            if (requirement == null)
                return 0;

            var percentCompleted = (progress / requirement * 100);
            
            return percentCompleted;
        }
    }
}
