using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class StatusInscricaoConfiguration : IEntityTypeConfiguration<StatusInscricao>
    {
        public void Configure(EntityTypeBuilder<StatusInscricao> builder)
        {

        }
    }
}
