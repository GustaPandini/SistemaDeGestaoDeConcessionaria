using Microsoft.EntityFrameworkCore;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.EntitiesConfiguration
{
    public class AutomovelConfiguration : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Automovel> builder)
        {
            builder.HasKey(a => a.idAutomovel);
            builder.Property(a => a.PlacaOuChassi)
                .IsRequired()
                .HasMaxLength(17);
            builder.HasIndex(a => a.PlacaOuChassi)
                .IsUnique();
            builder.Property(a => a.Marca)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Modelo)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(a => a.Powertrain)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Versao)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Cor)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.Ano)
                .IsRequired();
            builder.Property(a => a.AnoModelo)
                .IsRequired();
            builder.Property(a => a.Quilometragem)
                .IsRequired();
            builder.Property(a => a.Preco)
                .IsRequired();
            builder.Property(a => a.Blindado)
                .IsRequired();
            builder.Property(a => a.QuantidadeDonos)
                .IsRequired();
        }
    }
}
