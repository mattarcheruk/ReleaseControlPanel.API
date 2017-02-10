﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Models
{
    public class Settings
    {
        public string AuthenticationScheme { get; set; }
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
