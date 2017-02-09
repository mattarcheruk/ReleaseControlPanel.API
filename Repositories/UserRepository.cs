using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IMongoCollection<User> Users => _database.GetCollection<User>("users");

        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public UserRepository(IOptions<Settings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);

            if (_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        public async Task Delete(string id)
        {
            await Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
        }

        public async Task<User> Get(string id)
        {
            return await Users
                .Find(Builders<User>.Filter.Eq("Id", id))
                .FirstOrDefaultAsync();
        }

        public async Task<User> FindByUserName(string userName)
        {
            return await Users
                .Find(Builders<User>.Filter.Eq("UserName", userName))
                .FirstOrDefaultAsync();
        }

        public async Task Insert(User user)
        {
            await Users.InsertOneAsync(user);
        }

        public async Task Update(User user)
        {
            await Users.ReplaceOneAsync(u => u.Id.Equals(user.Id), user, new UpdateOptions { IsUpsert = false });
        }
    }
}
