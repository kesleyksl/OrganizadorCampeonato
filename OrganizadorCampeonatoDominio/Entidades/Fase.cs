using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Fase : Entidade
    {
        public int Id { get; set; }
        public int CampeonatoId { get; set; }
        public virtual Campeonato Campeonato { get; set; }
        public DateTime Data { get; set; }
        public int TipoFaseId { get; set; }
        public TipoFase TipoFase { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Competidor> Competidores { get; set; }
        public virtual ICollection<Musica> Musicas { get; set; }
        public virtual ICollection<Jurado> Jurados { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarMensagem("A fase deve ter um nome");

            }
        }
    }
}
