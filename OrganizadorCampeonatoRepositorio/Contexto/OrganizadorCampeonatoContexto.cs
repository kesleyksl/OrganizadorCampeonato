using Microsoft.EntityFrameworkCore;
using OrganizadorCampeonatoDominio.Entidades;
using OrganizadorCampeonatoDominio.ObjetoDeValor;
using OrganizadorCampeonatoRepositorio.Config;

namespace OrganizadorCampeonatoRepositorio.Contexto
{
    public class OrganizadorCampeonatoContexto : DbContext

    {


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<UsuarioFase> UsuariosFase { get; set; }
        public DbSet<TipoFase> TiposFase { get; set; }
        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<Jurado> Jurados { get; set; }
        public DbSet<StatusInscricao> StatusInscricoes { get; set; }

        public OrganizadorCampeonatoContexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new CampeonatoConfiguration());
            modelBuilder.ApplyConfiguration(new FaseConfiguration());
            modelBuilder.ApplyConfiguration(new MusicaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoFaseConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioFaseConfiguration());
            modelBuilder.ApplyConfiguration(new CompetidorConfiguration());
            modelBuilder.ApplyConfiguration(new StatusInscricaoConfiguration());
            modelBuilder.ApplyConfiguration(new JuradoConfiguration());


            modelBuilder.Entity<TipoFase>().HasData(new TipoFase() { TipoFaseId = 1, Nome = "JackAndJill" });
            modelBuilder.Entity<TipoFase>().HasData(new TipoFase() { TipoFaseId = 2, Nome = "Improviso" });
            modelBuilder.Entity<TipoFase>().HasData(new TipoFase() { TipoFaseId = 3, Nome = "Coreografia" });

            modelBuilder.Entity<StatusInscricao>().HasData(new StatusInscricao() { Id = 1, Nome = "Confirmado" });
            modelBuilder.Entity<StatusInscricao>().HasData(new StatusInscricao() { Id = 2, Nome = "Pendente" });
            modelBuilder.Entity<StatusInscricao>().HasData(new StatusInscricao() { Id = 3, Nome = "Cancelado" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
