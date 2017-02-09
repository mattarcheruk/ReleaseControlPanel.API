using System.Threading.Tasks;
using MongoDB.Driver;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Repositories
{
    public interface IUserRepository
    {
        Task<DeleteResult> Delete(string id);
        Task<User> Get(string id);
        Task<User> FindByUserName(string userName);
        Task Insert(User user);
        Task<UpdateResult> Update(User user);
    }
}