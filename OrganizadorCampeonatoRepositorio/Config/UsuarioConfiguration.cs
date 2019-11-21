using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonatoDominio.Entidades;

namespace OrganizadorCampeonatoRepositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            //Builder utiliza o padrão Fluent
            builder
                .HasIndex(u => u.Email)
                .IsUnique();
                
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(80);
                

            builder
                .Property(u => u.Sexo)
                .IsRequired()
                .HasMaxLength(1);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(80);

            builder
                .Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(11);

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(600);
            builder
                .HasMany(u => u.Campeonatos)
                .WithOne(c => c.Usuario);

            builder
                .HasMany(u => u.Competidores)
                .WithOne(c => c.Usuario);
            
        }
    }
}
