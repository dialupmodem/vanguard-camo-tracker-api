using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vanguard.CamoTracker.API.Models.WeaponChallenges;
using Vanguard.CamoTracker.Data;

namespace Vanguard.CamoTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponChallengesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CamoTrackerContext _dbContext;

        public WeaponChallengesController(IMapper mapper, CamoTrackerContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetWeaponChallenges))]
        public async Task<IActionResult> GetWeaponChallenges()
        {
            var weaponChallenges = await _dbContext.WeaponChallenges!.ToListAsync();
            var mappedWeaponChallenges = _mapper.Map<List<WeaponChallengeDto>>(weaponChallenges);

            return Ok(mappedWeaponChallenges);
        }

        [HttpGet("{id:int}", Name = nameof(GetWeaponChallenge))]
        public async Task<IActionResult> GetWeaponChallenge(int id)
        {
            var weaponChallenge = await _dbContext.WeaponChallenges!.FirstOrDefaultAsync(w => w.Id == id);
            if (weaponChallenge == null)
                return NotFound();

            var mappedWeaponChallenge = _mapper.Map<WeaponChallengeDto>(weaponChallenge);

            return Ok(mappedWeaponChallenge);
        }

        [HttpGet("FilterByWeapon/{weaponId:int}", Name = nameof(FilterByWeapon))]
        public async Task<IActionResult> FilterByWeapon(int weaponId)
        {
            var weaponChallenges = await _dbContext.WeaponChallenges!
                .Where(w => w.WeaponId == weaponId)
                .ToListAsync();

            if (weaponChallenges == null)
                return NotFound();

            var mappedWeaponChallenges = _mapper.Map<List<WeaponChallengeDto>>(weaponChallenges);

            return Ok(mappedWeaponChallenges);
        }

        [HttpPost("UpdateProgress/{challengeId:int}", Name = nameof(Update))]
        public async Task <IActionResult> Update(int challengeId, [FromBody] UpdateChallengeProgressModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var weaponChallenge = await _dbContext.WeaponChallenges!
                .FirstOrDefaultAsync(w => w.Id == challengeId);

            if (weaponChallenge == null)
                return NotFound();

            weaponChallenge.Progress = model.Progress;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }

}




