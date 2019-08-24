using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerCode.ChatHubs;
using ServerCode.Model;
using ServerCode.Model.DTOs.ChatDTOs;
using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : Controller
    {
        private IHubContext<ChatHub> _messageHub;
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MessageController(IHubContext<ChatHub> messageHub, IMessageRepository messageRepository, IUserRepository userRepository, IMapper mapper)
        {
            _messageHub = messageHub;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            await _messageRepository.AddMessage(message);
            message.Reciver = await _userRepository.GetUser(message.ReciverId);
            message.Sender = await _userRepository.GetUser(message.SenderId);
            await _messageHub.Clients
               .User(message.ReciverId)
               .SendAsync("send", message);
            return Ok();
        }
        [HttpPost]
        public async Task<Chat> OpenChat([FromBody] ChatUsers chatUsers)
        {
            return await _messageRepository.OpenChat(chatUsers.ReciverId, chatUsers.SenderId);
        }
        [HttpGet("{chatId}")]
        public async Task<ChatDTO> GetChat(int chatId)
        {
            var result = await _messageRepository.GetChat(chatId);
            ChatDTO chatDTO = _mapper.Map<ChatDTO>(result);
            return chatDTO;
        }
        [HttpGet("{userId}")]
        public async Task<List<ChatDTO>> GetChats(string userId)
        {
            var result = await _messageRepository.GetChats(userId);
            List<ChatDTO> chatDTOs = _mapper.Map<List<ChatDTO>>(result);
            return chatDTOs;
        }
    }
}