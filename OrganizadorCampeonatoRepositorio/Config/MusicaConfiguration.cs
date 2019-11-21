using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    class MusicaConfiguration : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Cantor)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
