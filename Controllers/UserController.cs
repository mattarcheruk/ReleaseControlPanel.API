using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Repositories;

namespace ReleaseControlPanel.API.Controllers
{
    [Authorize]
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
                _logger.LogTrace($"Cannot create a new user: User with UserName = '{user.UserName}' already exists.");
                return StatusCode(409, "User with this UserName already exists.");
            }

            await _userRepository.Insert(user);

            return CreatedAtAction("GetUser", new { userName = user.UserName }, null);
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteUser(string userName)
        {
            if (userName == null)
            {
                _logger.LogWarning("Tried to delete user with UserName = 'null'.");
                return BadRequest("UserName cannot be null.");
            }

            var existingUser = await _userRepository.FindByUserName(userName);
            if (existingUser == null)
            {
                _logger.LogTrace($"Cannot delete user: User with UserName = '{userName}' does not exist.");
                return NotFound("User with this user name does not exist.");
            }

            var deleteResult = await _userRepository.Delete(existingUser.Id);
            if (deleteResult.DeletedCount != 1)
            {
                _logger.LogError($"Could not delete user with UserName = '{userName}'. MongoDB client returned DeleteCound = {deleteResult.DeletedCount}.");
                return StatusCode(500,
                    $"Could not delete the user with UserName = '{userName}'. Check server logs for more information.");
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userRepository.FindByUserName(User.Identity.Name);
            if (user == null)
            {
                _logger.LogCritical("Failing to get logged in user is not correctly supported yet!");
                throw new NotImplementedException();
            }

            return Json(user);
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            if (userName == null)
            {
                _logger.LogWarning("Tried to get user with UserName = 'null'.");
                return BadRequest("UserName cannot be null.");
            }

            var user = await _userRepository.FindByUserName(userName);
            if (user == null)
            {
                _logger.LogTrace($"Cannot find user with UserName = '{userName}'.");
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