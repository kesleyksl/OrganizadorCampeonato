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

            base.OnModelCreating(modelBuilder);
        }
    }
}
