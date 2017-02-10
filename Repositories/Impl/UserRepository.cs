using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Repositories.Impl
{
    class UserRepository : IUserRepository
    {
        private IMongoCollection<User> Users => _database.GetCollection<User>("users");

        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public UserRepository(IOptions<MongoDbSettings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);

            if (_client != null)
                _database = _client.GetDatabase(settings.Value.Database);
        }

        public async Task<DeleteResult> Delete(string id)
        {
            return await Users.DeleteOneAsync(Builders<User>.Filter.Eq("Id", id));
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

        public async Task<UpdateResult> Update(User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", user.Id);
            var update = Builders<User>.Update
                .Set(u => u.CiBuildApiToken, user.CiBuildApiToken)
                .Set(u => u.CiBuildUserName, user.CiBuildUserName)
                .Set(u => u.CiQaApiToken, user.CiQaApiToken)
                .Set(u => u.CiQaUserName, user.CiQaUserName)
                .Set(u => u.CiStagingApiToken, user.CiStagingApiToken)
                .Set(u => u.CiStagingUserName, user.CiStagingUserName)
                .Set(u => u.FullName, user.FullName)
                .Set(u => u.IsEncrypted, user.IsEncrypted)
                .Set(u => u.JiraPassword, user.JiraPassword)
                .Set(u => u.JiraUserName, user.JiraUserName)
                .Set(u => u.Password, user.Password)
                .Set(u => u.PasswordSalt, user.PasswordSalt)
                .Set(u => u.UserName, user.UserName)
                .Set(u => u.UserSecret, user.UserSecret)
                .CurrentDate(u => u.UpdatedOn);

            return await Users.UpdateOneAsync(filter, update);
        }
    }
}
