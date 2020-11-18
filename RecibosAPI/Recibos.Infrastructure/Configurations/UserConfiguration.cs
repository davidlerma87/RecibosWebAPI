using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recibos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recibos.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("Apellidos")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("FechaNacimiento");            

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Nombres")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("Telefono")
                .IsUnicode(false);

            builder.Property(e => e.IsActive)
                .HasColumnName("Activo");
        }
    }
}
