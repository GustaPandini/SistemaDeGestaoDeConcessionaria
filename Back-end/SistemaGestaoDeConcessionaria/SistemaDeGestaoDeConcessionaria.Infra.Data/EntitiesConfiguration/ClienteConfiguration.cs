using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.EntitiesConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.idCliente);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(13);
            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
