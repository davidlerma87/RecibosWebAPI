using Recibos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        Task<User> GetUser(int id);

        Task AddUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);
    }
}
