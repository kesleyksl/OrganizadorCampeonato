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
            throw new NotImplementedException();
        }
    }
}
