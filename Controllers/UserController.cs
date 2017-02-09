using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Repositories;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private ILogger _logger;
        private IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                _logger.LogWarning("Tried to create a 'null' user.");
                return BadRequest("User cannot be null.");
            }

            var existingUser = await _userRepository.FindByUserName(user.UserName);
            if (existingUser != null)
            {
                _logger.LogTrace($"Cannot create a new user: user with UserName = '{user.UserName}' already exists.");
                return StatusCode(409, "User with this UserName already exists.");
            }

            await _userRepository.Insert(user);

            return CreatedAtAction("GetUser", new { userName = user.UserName }, null);
        }

        [HttpDelete("{userName}")]
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult> GetUser(string userName)
        {
            if (userName == null)
            {
                _logger.LogWarning("Tried to get a 'null' user.");
                return BadRequest("UserName cannot be null.");
            }

            var user = await _userRepository.FindByUserName(userName);
            if (user == null)
            {
                _logger.LogWarning($"Cannot find user with UserName = '{userName}'.");
                return NotFound("Cannot find user with this UserName.");
            }

            return Json(user);
        }

        [HttpPost]
        public void SaveCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{userName}")]
        public void SaveUser(string userName, User user)
        {
            throw new NotImplementedException();
        }
    }
}