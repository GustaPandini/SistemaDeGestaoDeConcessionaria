using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.idUsuario);
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
                .IsRequired();
            builder.Property(u => u.Perfil)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
