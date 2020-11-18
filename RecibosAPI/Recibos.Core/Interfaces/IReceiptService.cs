using Recibos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface IReceiptService
    {
        IEnumerable<Receipt> GetReceipt();

        Task<Receipt> GetReceipt(int id);

        Task AddReceipt(Receipt receipt);

        Task<bool> UpdateReceipt(Receipt receipt);

        Task<bool> DeleteReceipt(int id);
    }
}