using Microsoft.EntityFrameworkCore;
using Recibos.Core.Entities;
using Recibos.Core.Interfaces;
using Recibos.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recibos.Infrastructure.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ReceiptsDBContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Receipt>> GetReceiptByUser(int id)
        {
            return await _entities.Where(x => x.UserId == id).ToListAsync();
        }
    }
}
