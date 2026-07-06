using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.EntitiesConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.idVenda);
            builder.Property(v => v.DataDaVenda)
                .IsRequired();
            builder.Property(v => v.ValorPago)
                .IsRequired();
            builder.Property(v => v.FormaDePagamento)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(v => v.idAutomovel)
                .IsRequired();
            builder.Property(v => v.idCliente)
                .IsRequired();

            builder.HasOne(v => v.Automovel)
                .WithMany()
                .HasForeignKey(v => v.idAutomovel)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.idCliente)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
