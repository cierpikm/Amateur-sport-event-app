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
    public class EventController : Controller
    {
        private readonly IBaseRepository<Event> _baseRepository;
        private readonly IMapper _mapper;

        public EventController(IBaseRepository<Event> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<Event> AddEvent([FromBody] Event eventSport)
        {
            return await _baseRepository.Add(eventSport);
        }
        [HttpGet]
        public async Task<List<EventDTO>> GetAllEvents(int pageNumber = 1, int pageSize = 3)
        {
            var result = await _baseRepository.GetAll(pageNumber, pageSize);
            List<EventDTO> eventDTOs = _mapper.Map<List<EventDTO>>(result);
            return eventDTOs;
        }
    }
}