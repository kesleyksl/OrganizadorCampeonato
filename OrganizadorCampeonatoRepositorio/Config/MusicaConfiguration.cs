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
            throw new NotImplementedException();
        }
    }
}
