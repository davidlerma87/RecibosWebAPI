using Microsoft.EntityFrameworkCore;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;
using Recibos.Infrastructure.Data;
using System.Threading.Tasks;

namespace Recibos.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(ReceiptsDBContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
