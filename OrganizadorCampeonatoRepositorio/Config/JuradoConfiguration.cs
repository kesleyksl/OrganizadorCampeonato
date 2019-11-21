using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class JuradoConfiguration : IEntityTypeConfiguration<Jurado>
    {

        public void Configure(EntityTypeBuilder<Jurado> builder)
        {
            builder
                .HasKey(j => j.Id);

        }
    }
}
