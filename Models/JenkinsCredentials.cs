using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Models
{
    public class JenkinsCredentials
    {
        public string ApiToken { get; set; }
        public string UserName { get; set; }
    }
}
