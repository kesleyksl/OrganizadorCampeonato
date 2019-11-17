using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Fase : Entidade
    {
        public int FaseID { get; set; }
        public int CampeonatoID { get; set; }
        public DateTime Data { get; set; }
        public int TipoFaseID { get; set; }
        public TipoFase TipoFase { get; set; }
        public string Nome { get; set; }
        public ICollection<Usuario> Competidores { get; set; }
        public ICollection<Musica> Musicas { get; set; }
        public ICollection<Usuario> Jurados { get; set; }

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
