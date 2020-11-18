using Recibos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<IEnumerable<Receipt>> GetReceiptByUser(int id);
    }
}
