using System.Threading.Tasks;
using ReleaseControlPanel.API.Models;

namespace ReleaseControlPanel.API.Repositories
{
    public interface IUserRepository
    {
        Task Delete(string id);
        Task<User> Get(string id);
        Task<User> FindByUserName(string userName);
        Task Insert(User user);
        Task Update(User user);
    }
}