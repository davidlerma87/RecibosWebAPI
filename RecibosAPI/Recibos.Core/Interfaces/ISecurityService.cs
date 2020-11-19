using Recibos.Core.Entities;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
