using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerCode.Model;
using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AchievementController : Controller
    {
        private readonly IBaseRepository<Achievement> _baseRepository;

        public AchievementController(IBaseRepository<Achievement> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public async Task<List<Achievement>> GetAllAchievement()
        {
            return await _baseRepository.GetAll();
        }
        [HttpGet("{userId}")]
        public async Task<List<Achievement>> GetAllUserAchievement(string userId)
        {
            return await _baseRepository.GetAllOneUser(userId);
        }
        [HttpPost]
        public async Task<Achievement> AddAchievement([FromBody] Achievement achievement)
        {
            return await _baseRepository.Add(achievement);
        }
        [HttpDelete("{id}")]
        public async Task DeleteAchievement(int id)
        {
            await _baseRepository.Delete(id);
        }
        [HttpPost]
        public async Task<int> UpdateAchievement(Achievement achievement)
        {
            return await _baseRepository.UpdateAdvertisement(achievement);
        }
    }
}