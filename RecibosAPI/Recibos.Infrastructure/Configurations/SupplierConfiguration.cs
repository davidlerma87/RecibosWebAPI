using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recibos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Proveedores");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Nombre")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
