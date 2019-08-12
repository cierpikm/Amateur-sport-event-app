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
    public class AdvertisementArchController : Controller
    {
        private readonly IBaseRepository<AdvertisementArch> _baseRepository;

        public AdvertisementArchController(IBaseRepository<AdvertisementArch> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        [HttpGet("{id}")]
        public async Task<List<AdvertisementArch>> GetAllAdvertisementArch(string id)
        {
            return await _baseRepository.GetAllOneUser(id);
        }
    }
}