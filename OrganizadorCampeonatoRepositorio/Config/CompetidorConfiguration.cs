using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class CompetidorConfiguration : IEntityTypeConfiguration<Competidor>
    {
        public void Configure(EntityTypeBuilder<Competidor> builder)
        {
            builder
                  .HasKey(c => c.Id);




        }
    }
}
