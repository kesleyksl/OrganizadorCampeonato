﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;
using System;

namespace OrganizadorCampeonatoRepositorio.Config
{
    class UsuarioFaseConfiguration : IEntityTypeConfiguration<UsuarioFase>
    {
        public void Configure(EntityTypeBuilder<UsuarioFase> builder)
        {
            builder
                .HasKey(uf => uf.Id);
            builder
                .Property(uf => uf.CompetidorId)
                .IsRequired();
            
            builder
                .Property(uf => uf.FaseId)
                .IsRequired();



        }
    }
}
