using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recibos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Infrastructure.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {       
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Recibos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Comments)
                .HasMaxLength(200)
                .HasColumnName("Comentario")
                .IsUnicode(false);

            builder.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("Fecha");

            builder.Property(e => e.CurrencyId)
                .HasColumnName("MonedaId_FK");

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("Monto");

            builder.Property(e => e.SupplierId)
                .HasColumnName("ProveedorId_FK");

            builder.Property(e => e.UserId)
                .HasColumnName("UsuarioId_FK");

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recibos__MonedaI__2B3F6F97");

            builder.HasOne(d => d.Supplier)
                .WithMany(p => p.Receipts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recibos__Proveed__2A4B4B5E");

            builder.HasOne(d => d.User)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recibos__Usuario__300424B4");
        }
    }
}
