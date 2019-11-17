using System.Collections.Generic;
using System.Linq;

namespace OrganizadorCampeonatoDominio.Entidades
{
    public class Campeonato : Entidade
    {
        public int CampeonatoID { get; set; }
        public string Nome { get; set; }
        public int UsuarioID { get; set; }
        public int RegulamentoID { get; set; }

        public ICollection<Fase> Fases { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (string.IsNullOrEmpty(Nome))
            {
                AdicionarMensagem("O campeonato deve ter um nome");
            }
            if (!Fases.Any())
            {
                AdicionarMensagem("O campeonato deve ter pelo menos uma fase");
            }
        }
    }
}
