﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrganizadorCampeonatoRepositorio.Contexto;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    [DbContext(typeof(OrganizadorCampeonatoContexto))]
    [Migration("20200222143345_TesteTipoFas3")]
    partial class TesteTipoFas3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Campeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NomeArquivo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Competidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampeonatoId");

                    b.Property<int>("FaseId");

                    b.Property<int>("StatusInscricaoId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.HasIndex("StatusInscricaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Competidores");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Fase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampeonatoId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TipoFaseId");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("TipoFaseId");

                    b.ToTable("Fases");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Jurado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FaseId");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Jurados");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cantor")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("FaseId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("FaseId");

                    b.ToTable("Musicas");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasMaxLength(1);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.UsuarioFase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompetidorId");

                    b.Property<int>("FaseId");

                    b.Property<int>("MusicaId");

                    b.Property<double>("Nota");

                    b.HasKey("Id");

                    b.ToTable("UsuariosFase");
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.ObjetoDeValor.StatusInscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("StatusInscricoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Confirmado"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Pendente"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Cancelado"
                        });
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.ObjetoDeValor.TipoFase", b =>
                {
                    b.Property<int>("TipoFaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("TipoFaseId");

                    b.ToTable("TiposFase");

                    b.HasData(
                        new
                        {
                            TipoFaseId = 1,
                            Nome = "JackAndJill"
                        },
                        new
                        {
                            TipoFaseId = 2,
                            Nome = "Improviso"
                        },
                        new
                        {
                            TipoFaseId = 3,
                            Nome = "Coreografia"
                        });
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Competidor", b =>
                {
                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Fase", "Fase")
                        .WithMany("Competidores")
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrganizadorCampeonatoDominio.ObjetoDeValor.StatusInscricao", "StatusInscricao")
                        .WithMany()
                        .HasForeignKey("StatusInscricaoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Usuario", "Usuario")
                        .WithMany("Competidores")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Fase", b =>
                {
                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Campeonato")
                        .WithMany("Fases")
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrganizadorCampeonatoDominio.ObjetoDeValor.TipoFase", "TipoFase")
                        .WithMany()
                        .HasForeignKey("TipoFaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Jurado", b =>
                {
                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Fase", "Fase")
                        .WithMany("Jurados")
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Usuario", "Usuario")
                        .WithMany("Jurados")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OrganizadorCampeonatoDominio.Entidades.Musica", b =>
                {
                    b.HasOne("OrganizadorCampeonatoDominio.Entidades.Fase", "Fase")
                        .WithMany("Musicas")
                        .HasForeignKey("FaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
