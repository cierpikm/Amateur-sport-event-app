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
    public class SponsorController : Controller
    {
        private readonly IBaseRepository<Sponsor> _baseRepository;

        public SponsorController(IBaseRepository<Sponsor> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        [HttpPost]
        public async Task<Sponsor> AddSponsor([FromBody] Sponsor sponsor)
        {
            
            return await _baseRepository.Add(sponsor);
        }
    }
}