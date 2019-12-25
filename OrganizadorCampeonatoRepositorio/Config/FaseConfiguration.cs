using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    class FaseConfiguration : IEntityTypeConfiguration<Fase>
    {
        public void Configure(EntityTypeBuilder<Fase> builder)
        {
            builder
                .HasKey(f => f.Id);

            builder
                .Property(f => f.Data)
                .IsRequired();

            builder
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);

          

            builder
                .HasMany(f => f.Competidores)
                .WithOne(c => c.Fase);

            builder
                .HasMany(f => f.Musicas)
                .WithOne(m => m.Fase);

            builder
                .HasMany(f => f.Jurados)
                .WithOne(j => j.Fase);

        }
    }
}
