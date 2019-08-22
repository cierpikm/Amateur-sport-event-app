using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCode.Model;
using ServerCode.Model.DTOs;

using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IUserRepository _userRepository;

        public AdvertisementController(IMapper mapper, IAdvertisementRepository advertisementRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _advertisementRepository = advertisementRepository;
            _userRepository = userRepository;

        }
        [HttpGet]
        public async Task<List<Advertisement>> GetAll()
        {
            return await _advertisementRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<List<AdvertisementDTO>> GetAllAdvertisement(string id, string city)
        {
            var result = await _advertisementRepository.GetAllAdvertisementsAsync(city, id);
            List<AdvertisementDTO> advertisementDTOs = _mapper.Map<List<AdvertisementDTO>>(result);
            return advertisementDTOs;
        }
        [HttpGet("{id}")]
        public async Task<List<AdvertisementDTO>> GetAllOneAdvertisements(string id)
        {
            var result = await _advertisementRepository.GetAllOneAdvertisementsAsync(id);
            List<AdvertisementDTO> advertisementDTOs = _mapper.Map<List<AdvertisementDTO>>(result);
            return advertisementDTOs;
        }
        [HttpGet("{id}")]
        public async Task<List<AdvertisementDTO>> GetAllAcceptedAdvertisements(string id)
        {
            var result = await _advertisementRepository.GetAllAcceptedAdvertisementsAsync(id);
            List<AdvertisementDTO> advertisementDTOs = _mapper.Map<List<AdvertisementDTO>>(result);
            return advertisementDTOs;
        }
        [HttpPost]
        public async Task<IActionResult> AddAdvertisement([FromBody] Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var result = await _advertisementRepository.AddAdvertisement(advertisement);
                AdvertisementDTO advertisementDTO = _mapper.Map<AdvertisementDTO>(advertisement);
                return new JsonResult(advertisementDTO);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }


        }
        [HttpGet]
        public async Task<IActionResult> GetAdvertisment(int advertisementID)
        {
            return new JsonResult(await _advertisementRepository.GetAdvertisement(advertisementID));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdvertisement([FromBody] Advertisement advertisement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _advertisementRepository.UpdateAdvertisement(advertisement);
            return new JsonResult(advertisement);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                await _advertisementRepository.DeleteAdvertisement(id);
                return Ok("Advertisement removed");
            }
            catch (ArgumentNullException)
            {
                return NotFound("Member not found");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
        [HttpPost("{userId}/{advertisementId}")]
        public async Task<IActionResult> AddMemberToAdvertisement(string userId, int advertisementId)
        {
            try
            {
                await _advertisementRepository.AddMemberToAdvertisement(userId, advertisementId);
                return Ok("Added member to advertisement");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }
    }
}