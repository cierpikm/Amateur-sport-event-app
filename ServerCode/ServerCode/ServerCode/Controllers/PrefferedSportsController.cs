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
    public class PrefferedSportsController : Controller
    {
        private readonly IBaseRepository<SportName> _baseRepository;

        public PrefferedSportsController(IBaseRepository<SportName> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        [HttpPost]
        public async Task<SportName> AddPrefferedSport([FromBody] SportName sportName)
        {
            return await _baseRepository.Add(sportName);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _baseRepository.Delete(id);
        }
    }
}