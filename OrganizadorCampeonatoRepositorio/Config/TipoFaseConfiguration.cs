﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class TipoFaseConfiguration : IEntityTypeConfiguration<TipoFase>
    {
        public void Configure(EntityTypeBuilder<TipoFase> builder)
        {

        }
    }
}
