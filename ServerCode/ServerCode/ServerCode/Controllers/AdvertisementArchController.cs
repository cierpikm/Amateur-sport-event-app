using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerCode.Model;
using ServerCode.Model.DTOs;
using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementArchController : Controller
    {
        private readonly IAdvertisementRepositoryHistory _advertisementRepositoryHistory;
        private readonly IMapper _mapper;

        public AdvertisementArchController(IAdvertisementRepositoryHistory advertisementRepositoryHistory, IMapper mapper)
        {
            _advertisementRepositoryHistory = advertisementRepositoryHistory;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<List<AdvertisementDTO>> GetAllOneAdvertisements(string id)
        {
            var result = await _advertisementRepositoryHistory.GetAllOneAdvertisementsAsync(id);
            List<AdvertisementDTO> advertisementDTOs = _mapper.Map<List<AdvertisementDTO>>(result);
            return advertisementDTOs;
        }
        [HttpGet("{id}")]
        public async Task<List<AdvertisementDTO>> GetAllAcceptedAdvertisements(string id)
        {
            var result = await _advertisementRepositoryHistory.GetAllAcceptedAdvertisementsAsync(id);
            List<AdvertisementDTO> advertisementDTOs = _mapper.Map<List<AdvertisementDTO>>(result);
            return advertisementDTOs;
        }
    }
}