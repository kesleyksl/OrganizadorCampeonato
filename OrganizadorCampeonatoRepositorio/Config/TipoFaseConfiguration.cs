using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class TipoFaseConfiguration : IEntityTypeConfiguration<TipoFase>
    {
        public void Configure(EntityTypeBuilder<TipoFase> builder)
        {
            throw new NotImplementedException();
        }
    }
}
