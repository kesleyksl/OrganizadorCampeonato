using OrganizadorCampeonatoDominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    class Fase : Entidade
    {
        public int FaseID { get; set; }
        public int CampeonatoID { get; set; }
        public DateTime Data { get; set; }
        public int TipoFaseID { get; set; }
        public TipoFase TipoFase{ get; set; }
        public string  Nome { get; set; }
        public ICollection<Usuario> Competidores { get; set; }
        public ICollection<Musica> Musicas { get; set; }
        public ICollection<Usuario> Jurados { get; set; }
    }
}
