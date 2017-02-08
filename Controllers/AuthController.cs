using System;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("login")]
        public User Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        [HttpPost("logout")]
        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}