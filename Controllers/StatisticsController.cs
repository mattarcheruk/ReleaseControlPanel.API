using System;
using Microsoft.AspNetCore.Mvc;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class StatisticsController : Controller
    {
        [HttpGet]
        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}