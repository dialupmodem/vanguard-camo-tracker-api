using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vanguard.CamoTracker.API.Models.WeaponCategories;
using Vanguard.CamoTracker.Data;

namespace Vanguard.CamoTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponCategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CamoTrackerContext _dbContext;

        public WeaponCategoriesController(IMapper mapper, CamoTrackerContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetWeaponCategories))]
        public async Task<IActionResult> GetWeaponCategories()
        {
            var weaponCategories = await _dbContext.WeaponCategories!
                .Include(w => w.Weapons)
                .ToListAsync();

            var mappedWeaponCategories = _mapper.Map<List<WeaponCategoryDto>>(weaponCategories);

            return Ok(mappedWeaponCategories);
        }

        [HttpGet("{id:int}", Name = nameof(GetWeaponCategory))]
        public async Task<IActionResult> GetWeaponCategory(int id)
        {
            var weaponCategory = await _dbContext.WeaponCategories!.FirstOrDefaultAsync(w => w.Id == id);
            if (weaponCategory == null)
                return NotFound();

            var mappedCategory = _mapper.Map<WeaponCategoryDto>(weaponCategory);

            return Ok(mappedCategory);
        }
    }
}
