﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class DeploymentController : Controller
    {
        [HttpPost("qa")]
        public void DeployToQA(string projectName, string version)
        {
            throw new NotImplementedException();
        }

        [HttpPost("staging")]
        public void DeployToStaging(string projectName, string version)
        {
            throw new NotImplementedException();
        }
    }
}