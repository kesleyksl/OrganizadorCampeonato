using System.Collections.Generic;

namespace OrganizadorCampeonatoDominio.Entidades
{
    class Campeonato : Entidade
    {
        public int CampeonatoID { get; set; }
        public string Nome { get; set; }
        public int UsuarioID { get; set; }
        public int RegulamentoID { get; set; }

        public ICollection<Fase> Fases { get; set; }

    }
}
