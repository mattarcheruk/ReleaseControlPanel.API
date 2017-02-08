using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Controllers
{
    [Route("[controller]")]
    public class StoriesController : Controller
    {
        [HttpGet("for-epic/{epicKey}")]
        public IEnumerable<Story> GetStoriesForEpic(string epicKey)
        {
            throw new NotImplementedException();
        }

        [HttpGet("refresh")]
        public IEnumerable<Story> RefreshStatuses()
        {
            throw new NotImplementedException();
        }
    }
}