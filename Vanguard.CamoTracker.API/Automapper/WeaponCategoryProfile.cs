using AutoMapper;
using Vanguard.CamoTracker.API.Models.WeaponCategories;
using Vanguard.CamoTracker.API.Models.Weapons;
using Vanguard.CamoTracker.Data.Entities;

namespace Vanguard.CamoTracker.API.Automapper
{
    public class WeaponCategoryProfile : Profile
    {
        public WeaponCategoryProfile()
        {
            CreateMap<WeaponCategory, WeaponCategoryDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Weapons, opt =>
                {
                    opt.PreCondition(src => src.Weapons != null);
                    opt.MapFrom(src => src.Weapons!.Select(w => new SimpleWeaponDto()
                    {
                        Id = w.Id,
                        Name = w.Name
                    }));
                })
            ;
        }
    }
}
