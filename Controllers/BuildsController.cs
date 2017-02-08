﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class BuildsController : Controller
    {
        [HttpGet("statuses")]
        public IEnumerable<BuildStatus> GetBuildStatuses()
        {
            throw new NotImplementedException();
        }

        [HttpGet("upcoming-releases")]
        public IEnumerable<Release> GetUpcomingReleases()
        {
            throw new NotImplementedException();
        }

        [HttpGet("successful-builds")]
        public IEnumerable<string> GetSuccessfulBuildsForProjects()
        {
            throw new NotImplementedException();
        }

        [HttpPost("start-build")]
        public void StartBuild(string projectName, string version)
        {
            throw new NotImplementedException();
        }
    }
}