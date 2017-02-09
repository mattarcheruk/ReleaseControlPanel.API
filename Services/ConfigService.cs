using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Services
{
    public class ConfigService : IConfigService
    {
        public string MongoDbAddress => "mongodb://localhost:27017";
        public string MongoDbDatabaseName => "release-control-panel";
    }
}
