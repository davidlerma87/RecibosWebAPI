using Recibos.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Recibos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Receipt> ReceiptRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Currency> CurrencyRepository { get; }
        IRepository<Supplier> SupplierRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

