using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Models
{
    public class AppSettings
    {
        public string CiBuildUrl { get; set; }
        public string CiQaUrl { get; set; }
        public string CiStagingUrl { get; set; }
        public string GitRepositoriesPath { get; set; }
        public string ManifestIndexUrl { get; set; }
        public string JiraUrl { get; set; }
        public string ProdUrl { get; set; }
        public ProjectSettings[] Projects { get; set; }
        public string ReleasesHistoryUrl { get; set; }
    }
}
