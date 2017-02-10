using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Services.Impl
{
    class CiBuildService : JenkinsService, ICiBuildService
    {
        public override JenkinsType Type => JenkinsType.Build;

        public CiBuildService(ILogger<JenkinsService> logger, IOptions<AppSettings> appOptions) : base(logger, appOptions)
        {
        }
    }
}
