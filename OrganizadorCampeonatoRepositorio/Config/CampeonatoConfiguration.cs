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
            throw new NotImplementedException();
        }
    }
}
