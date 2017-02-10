using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Services;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class ReleasesController : Controller
    {
        private readonly IGitService _gitService;

        public ReleasesController(IGitService gitService)
        {
            _gitService = gitService;
        }

        [HttpGet]
        public IEnumerable<Release> GetUpcomingReleases()
        {
            _gitService.EnsureProjectsCloned();
            return null;
        }
    }
}