using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Models
{
    public class AppSettings
    {
        public string GitRepositoriesPath { get; set; }
        public ProjectSettings[] Projects { get; set; }
    }
}
