using System;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Repositories;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPut]
        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{userName}")]
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public User GetCurrentUser()
        {
            return new User();
            throw new NotImplementedException();
        }

        [HttpGet("{userName}")]
        public User GetUser(string userName)
        {
            throw new NotImplementedException();
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