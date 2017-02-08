using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class ReleasesController : Controller
    {
        [HttpGet]
        public IEnumerable<Release> GetUpcomingReleases()
        {
            throw new NotImplementedException();
        }
    }
}