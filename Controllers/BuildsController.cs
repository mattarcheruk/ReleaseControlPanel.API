using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Repositories;
using ReleaseControlPanel.API.Services;

namespace ReleaseControlPanel.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class BuildsController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ICiBuildService _ciBuildService;
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;

        public BuildsController(IOptions<AppSettings> appOptions,
                                ICiBuildService ciBuildService,
                                ILogger<BuildsController> logger,
                                IUserRepository userRepository)
        {
            _appSettings = appOptions.Value;
            _ciBuildService = ciBuildService;
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("statuses")]
        public async Task<IActionResult> GetBuildStatuses()
        {
            var currentUser = await _userRepository.FindByUserName(User.Identity.Name);
            if (currentUser == null)
            {
                _logger.LogError($"Could not find currently logged in user in the database. UserName: {User.Identity.Name}");
                return StatusCode(500, "Could not find currently logged in user in the dabase. Check server logs for more information.");
            }

            object errorDetails;
            if (!_ciBuildService.CheckUserConfig(currentUser, out errorDetails))
            {
                return BadRequest(errorDetails);
            }

            if (_appSettings.Projects == null || _appSettings.Projects.Length == 0)
            {
                _logger.LogWarning("Config: 'App.Projects' is empty. The tool requies some projects to be defined!");
                return NoContent();
            }

            var getBuildStatusesTasks = _appSettings.Projects.Select(p => _ciBuildService.GetBuildStatus(currentUser, p.Name)).ToArray();

            Task.WaitAll(getBuildStatusesTasks);

            var buildStatuses = getBuildStatusesTasks.Select(gbs => gbs.Result).ToArray();
            return Json(buildStatuses);
        }

        [HttpGet("successful")]
        public async Task<IActionResult> GetSuccessfulBuildsForProjects()
        {
            throw new NotImplementedException();
        }

        [HttpPost("start")]
        public void StartBuild(string projectName, string version)
        {
            throw new NotImplementedException();
        }
    }
}