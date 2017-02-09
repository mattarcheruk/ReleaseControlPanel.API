using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseControlPanel.API.Services
{
    public interface IConfigService
    {
        string MongoDbAddress { get; }
        string MongoDbDatabaseName { get; }
    }
}
