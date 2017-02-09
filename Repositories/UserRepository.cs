using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ReleaseControlPanel.API.Models;
using ReleaseControlPanel.API.Services;

namespace ReleaseControlPanel.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public UserRepository(IConfigService configService)
        {
            _client = new MongoClient(configService.MongoDbAddress);
            _database = _client.GetDatabase(configService.MongoDbDatabaseName);
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
