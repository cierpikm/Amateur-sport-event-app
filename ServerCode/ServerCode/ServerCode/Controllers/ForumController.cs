using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServerCode.ChatHubs;
using ServerCode.Model;
using ServerCode.Model.DTOs.ForumDTOs;
using ServerCode.Model.Entity;
using ServerCode.Model.Helpers;
using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForumController : Controller
    {
        private IHubContext<ChatHub> _messageHub;
        private IForumRepository _forumRepository;
        private readonly IMapper _mapper;

        public ForumController(IHubContext<ChatHub> messageHub, IForumRepository forumRepository, IMapper mapper)
        {
            _messageHub = messageHub;
            _forumRepository = forumRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> SendPost(PostAndReciver postAndReciver)
        {
            try
            {
                Post post = new Post()
                {
                    DateSendMessage = postAndReciver.DateSendMessage,
                    Forum = postAndReciver.Forum,
                    ForumId = postAndReciver.ForumId,
                    Owner = postAndReciver.Owner,
                    OwnerId = postAndReciver.OwnerId,
                    PostText = postAndReciver.PostText
                };
                await _forumRepository.AddPost(post);
                await _messageHub.Clients
                   .Users(postAndReciver.Reciver)
                   .SendAsync("SendPost", post);
                return Ok(post);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
        [HttpGet("{adverticementId}")]
        public async Task<ForumDTO> GetForum(int adverticementId)
        {
            var result = await _forumRepository.GetForum(adverticementId);
            ForumDTO forumDTO = _mapper.Map<ForumDTO>(result);
            return forumDTO;
        }

    }
}