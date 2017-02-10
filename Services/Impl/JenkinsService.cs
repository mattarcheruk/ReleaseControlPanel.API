using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Services.Impl
{
    abstract class JenkinsService : IJenkinsService
    {
        public abstract JenkinsType Type { get; }

        protected string Url
        {
            get
            {
                switch (Type)
                {
                    case JenkinsType.Build:
                        return AppSettings.CiBuildUrl;

                    case JenkinsType.Qa:
                        return AppSettings.CiQaUrl;

                    case JenkinsType.Staging:
                        return AppSettings.CiStagingUrl;

                    default:
                        Logger.LogCritical($"Incorrect Jenkins type is in use: {Type}");
                        throw new InvalidOperationException();
                }
            }
        }

        private readonly AppSettings AppSettings;
        private readonly ILogger Logger;

        protected JenkinsService(ILogger<JenkinsService> logger, IOptions<AppSettings> appOptions)
        {
            Logger = logger;
            AppSettings = appOptions.Value;
        }

        public bool CheckUserConfig(User user, out object errorDetails)
        {
            var credentials = GetCredentials(user);

            if (string.IsNullOrEmpty(credentials.UserName))
            {
                Logger.LogError($"Invalid user configuration: UserName is null or empty. UserName = '{user.UserName}', Jenkins = '{Type}'.");
                errorDetails = $"Invalid user configuration: UserName is null or empty. Jenkins = '{Type}'.";
                return false;
            }

            if (string.IsNullOrEmpty(credentials.ApiToken))
            {
                Logger.LogError($"Invalid user configuration: ApiToken is null or empty. UserName = '{user.UserName}', Jenkins = '{Type}'.");
                errorDetails = $"Invalid user configuration: ApiToken is null or empty. Jenkins = '{Type}'.";
                return false;
            }

            errorDetails = null;
            return true;
        }

        public async Task<BuildStatus> GetBuildStatus(User user, string projectName)
        {
            var credentials = GetCredentials(user);
            var networkCredentials = new NetworkCredential(credentials.UserName, credentials.ApiToken);

            using (var handler = new HttpClientHandler { Credentials = networkCredentials })
            using (var client = new HttpClient(handler))
            {
                var uriString = $"{Url}job/{projectName}/lastBuild/api/json";
                var response = await client.GetAsync(new Uri(uriString));
                var jsonBody = await response.Content.ReadAsStringAsync();
                
                // TODO: Parsing... 

                return null;
            }
        }

        public JenkinsCredentials GetCredentials(User user)
        {
            switch (Type)
            {
                case JenkinsType.Build:
                    return new JenkinsCredentials
                    {
                        ApiToken = user.CiBuildApiToken,
                        UserName = user.CiBuildUserName
                    };

                case JenkinsType.Qa:
                    return new JenkinsCredentials
                    {
                        ApiToken = user.CiQaApiToken,
                        UserName = user.CiQaUserName
                    };

                case JenkinsType.Staging:
                    return new JenkinsCredentials
                    {
                        ApiToken = user.CiStagingApiToken,
                        UserName = user.CiStagingUserName
                    };

                default:
                    Logger.LogCritical($"Incorrect Jenkins type is in use: {Type}");
                    throw new InvalidOperationException();
            }
        }
    }
}
