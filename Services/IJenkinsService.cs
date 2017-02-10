using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Services
{
    public interface IJenkinsService
    {
        JenkinsType Type { get; }

        bool CheckUserConfig(User user, out object errorDetails);
        Task<BuildStatus> GetBuildStatus(User user, string projectName);
        JenkinsCredentials GetCredentials(User user);
    }
}
