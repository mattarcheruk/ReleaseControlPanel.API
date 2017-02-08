using System;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        [HttpGet]
        public ClientConfig GetConfig()
        {
            throw new NotImplementedException();
        }
    }
}