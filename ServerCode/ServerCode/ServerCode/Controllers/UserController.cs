using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServerCode.Model;
using ServerCode.Model.DTOs;
using ServerCode.Model.Helpers;
using ServerCode.Model.Interfaces;

namespace ServerCode.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GerUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new JsonResult(user);
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return new JsonResult(_userRepository.GetAll());
        }
        [HttpPost]
        public async Task<Object> PostUser([FromBody] UserLogin model)
        {
            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                return Ok(result);
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword changePassword)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            try
            {
                var user = await _userManager.FindByIdAsync(changePassword.UserId);
                var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
                return Ok(result);
            }
            catch (ArgumentNullException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }


        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _userRepository.GetUser(userId);
            var userProfileDTO = _mapper.Map<UserProfileDTO>(result);
            return Ok(userProfileDTO);
        }
        [HttpGet("{userName}")]
        [Authorize]
        public async Task<Object> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _userRepository.GetUser(user.Id);
            var userProfileDTO = _mapper.Map<UserProfileDTO>(result);
            return userProfileDTO;
        }

        [HttpPost]
        [Authorize]
        public async Task<string> UpdateUser(UserProfile model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);

            user.UserName = model.UserName;
            user.ImageURL = model.ImageURL;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Age = model.Age;
            user.Description = model.Description;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.City = model.City;


            await _userManager.UpdateAsync(user);
            return model.Id;
        }
    }

}