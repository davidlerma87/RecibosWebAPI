using Recibos.Core.Entities;
using Recibos.Core.Interfaces;
using System.Threading.Tasks;
using System;
using Recibos.Infrastructure.Data;

namespace Recibos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReceiptsDBContext _context;
        private readonly IRepository<Receipt> _receiptRepository;
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IRepository<Supplier> _supplierRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(ReceiptsDBContext context) 
        {
            _context = context;
        }
        public IRepository<Receipt> ReceiptRepository => _receiptRepository ?? new BaseRepository<Receipt>(_context);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

        public IRepository<Currency> CurrencyRepository => _currencyRepository ?? new BaseRepository<Currency>(_context);

        public IRepository<Supplier> SupplierRepository => _supplierRepository ?? new BaseRepository<Supplier>(_context);
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
