using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class CampeonatoConfiguration : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(c => c.UsuarioId)
                .IsRequired();

            builder
                .HasMany(c => c.Fases);

        
        }
    }
}
