using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaGestaoDeConcessionaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.EntitiesConfiguration
{
    public class ImagensConfigurantion : IEntityTypeConfiguration<ImagensAutomovel>
    {
        public void Configure(EntityTypeBuilder<ImagensAutomovel> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Url)
                .IsRequired();
            builder.Property(i => i.PublicId)
                .IsRequired();
            builder.Property(i => i.idAutomovel)
                .IsRequired();

            builder.HasOne(v => v.Automovel)
                .WithMany(a => a.Imagens)
                .HasForeignKey(v => v.idAutomovel)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
