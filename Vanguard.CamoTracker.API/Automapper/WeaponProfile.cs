using AutoMapper;
using Vanguard.CamoTracker.Data.Entities;
using Vanguard.CamoTracker.API.Models.Weapons;

namespace Vanguard.CamoTracker.API.Automapper
{
    public class WeaponProfile : Profile
    {
        public WeaponProfile()
        {
            CreateMap<Weapon, WeaponDto>()
                .ForMember(dst => dst.CategoryId, opt => opt.MapFrom(s => s.WeaponCategoryId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dst => dst.Image, opt => opt.MapFrom(s => s.Image))
                .ForMember(dst => dst.PercentCompleted, opt => {
                    opt.NullSubstitute(0);
                    opt.MapFrom(src => GetPercentageComplete(src));
                })
                .ForMember(dst => dst.CategoryName, opt =>
                {
                    opt.PreCondition(src => src.WeaponCategory != null);
                    opt.MapFrom(src => src.WeaponCategory!.Name);
                })
            ;
        }

        private decimal? GetPercentageComplete(Weapon weapon)
        {
            var totalRequired = (decimal?)weapon.Challenges!.Sum(c => c.Requirement);
            var totalProgress = (decimal?)weapon.Challenges!.Sum(c => c.Progress);

            if (!totalProgress.HasValue || totalProgress == 0)
                return 0;

            decimal? percentCompleted = (totalProgress / totalRequired) * 100;
            percentCompleted = decimal.Round(percentCompleted!.Value, 2);

            return percentCompleted;
        }
    }
}
