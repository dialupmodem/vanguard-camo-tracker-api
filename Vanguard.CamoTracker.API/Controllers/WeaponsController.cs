using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vanguard.CamoTracker.Data;
using Vanguard.CamoTracker.API.Models.Weapons;

namespace Vanguard.CamoTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly CamoTrackerContext _dbContext;
        private readonly IMapper _mapper;

        public WeaponsController(CamoTrackerContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetWeapons))]
        public async Task<IActionResult> GetWeapons()
        {
            var weapons = await _dbContext!.Weapons!
                .Include(w => w.WeaponCategory)
                .Include(w => w.Challenges)
                .ToListAsync();

            var mappedWeapons = _mapper.Map<List<WeaponDto>>(weapons);

            return Ok(mappedWeapons);
        }

        [HttpGet("{id:int}", Name = nameof(GetWeapon))]
        public async Task<IActionResult> GetWeapon(int id)
        {
            var weapon = await _dbContext!.Weapons!
                .Include(w => w.WeaponCategory)
                .Include(w => w.Challenges)
                .FirstOrDefaultAsync(w => w.Id == id);

            var mappedWeapon = _mapper.Map<WeaponDto>(weapon);

            return Ok(mappedWeapon);
        }

        [HttpGet("FilterByCategory/{categoryId:int}", Name = nameof(FilterByCategory))]
        public async Task<IActionResult> FilterByCategory(int categoryId)
        {
            var weapons = await _dbContext!.Weapons!
                .Include(w => w.WeaponCategory)
                .Include(w => w.Challenges)
                .Where(w => w.WeaponCategoryId == categoryId)
                .ToListAsync();

            if (weapons == null)
                return NotFound();

            var mappedWeapons = _mapper.Map<List<WeaponDto>>(weapons);

            return Ok(mappedWeapons);
        }

    }
}
