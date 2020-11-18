using Recibos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers();

        Task<Supplier> GetSupplier(int id);

        Task AddSupplier(Supplier supplier);

        Task<bool> UpdateSupplier(Supplier supplier);

        Task<bool> DeleteSupplier(int id);
    }
}
