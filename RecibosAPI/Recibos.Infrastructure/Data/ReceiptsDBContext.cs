using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Recibos.Core.Entities;
using Recibos.Infrastructure.Configurations;

namespace Recibos.Infrastructure.Data
{
    public partial class ReceiptsDBContext : DbContext
    {
        public ReceiptsDBContext()
        {
        }

        public ReceiptsDBContext(DbContextOptions<ReceiptsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }
    }
}
